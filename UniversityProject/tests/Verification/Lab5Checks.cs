using UniversityProject.Model.Enums;
using UniversityProject.Model.Discounts;
using UniversityProject.Model;

internal static partial class Program
{
    private static void VerifyLab5Customers()
    {
        var customer = new Customer("Покупатель", new Address());
        Check(customer.Discounts.Count == 1 && customer.Discounts[0] is PointsDiscount, "Mandatory discount");
        using var tab = new UniversityProject.View.Tabs.CustomersTab { Customers = new() { customer } };
        Field<ListBox>(tab, "CustomersListBox").SelectedItem = customer;
        var list = Field<ListBox>(tab, "DiscountsListBox");
        list.SelectedIndex = 0;
        Check(!Field<Button>(tab, "RemoveDiscountButton").Enabled, "Mandatory discount removable");
        customer.Discounts.Add(new PercentDiscount(Category.Food));
        // Re-select the customer to display the changed model.
        Field<ListBox>(tab, "CustomersListBox").SelectedIndex = -1;
        Field<ListBox>(tab, "CustomersListBox").SelectedIndex = 0;
        list.SelectedIndex = 1;
        Field<Button>(tab, "RemoveDiscountButton").PerformClick();
        Check(customer.Discounts.Count == 1 && list.Items.Count == 1, "Remove category discount");
    }

    private static void VerifyLab5Discounts()
    {
        var goods = new List<Item> { new("Книга", "", 1000, Category.Books), new("Еда", "", 10, Category.Food) };
        var points = new PointsDiscount();
        Check(points.Points == 0 && points.Calculate(goods) == 0, "Initial points");
        points.Update(goods);
        Check(points.Points == 101, "Points round upward");
        Check(points.Calculate(goods) == 101 && points.Points == 101, "Calculate must be pure");
        Check(points.Apply(goods) == 101 && points.Points == 0, "Apply must spend points");
        points.Update(goods);
        var small = new List<Item> { new("Мелочь", "", 9, Category.Food) };
        Check(points.Apply(small) == 2 && points.Points == 99, "Whole points cannot exceed 30 percent");
        points.Update(small);
        Check(points.Points == 100, "Fractional earnings round up");
        var percent = new PercentDiscount(Category.Books);
        Check(percent.Percent == 1 && percent.Calculate(goods) == 10, "Initial category percentage");
        percent.Update(small);
        Check(percent.Percent == 1 && percent.Apply(small) == 0, "Other category ignored");
        percent.Update(goods);
        Check(percent.Percent == 2 && percent.Calculate(goods) == 20, "Thousand threshold");
        for (int i = 0; i < 20; i++) percent.Update(goods);
        Check(percent.Percent == 10 && percent.Apply(goods) == 100, "Maximum percentage");
        Check(points.Calculate(new()) == 0 && percent.Calculate(new()) == 0, "Empty discounts");
        Reject(() => points.Calculate(null!));
        Reject(() => percent.Update(null!));
        Reject(() => new PercentDiscount((Category)99));
    }
    private static void VerifyLab5Checkout()
    {
        var buyer = new Customer("Проверка скидок", new Address());
        var item = new Item("Книга", "", 1000, Category.Books);
        var goods = new List<Item> { item };
        buyer.Discounts[0].Update(goods);
        buyer.Discounts.Add(new PercentDiscount(Category.Books));
        using var tab = new UniversityProject.View.Tabs.CartsTab { Items = goods, Customers = new() { buyer } };
        Field<ComboBox>(tab, "CustomersComboBox").SelectedItem = buyer;
        Field<ListBox>(tab, "ItemsListBox").SelectedIndex = 0;
        Field<Button>(tab, "AddToCartButton").PerformClick();
        var checks = Field<CheckedListBox>(tab, "DiscountsCheckedListBox");
        Check(checks.CheckedItems.Count == 2, "All discounts initially checked");
        Check(Field<Label>(tab, "DiscountAmountLabel").Text == 110d.ToString("N2"), "Preview discount");
        checks.SetItemChecked(0, false);
        Check(Field<Label>(tab, "TotalLabel").Text == 990d.ToString("N2"), "Immediate checkbox preview");
        tab.RefreshData();
        Check(!checks.GetItemChecked(0), "Refresh reset discount choice");
        Field<Button>(tab, "CreateOrderButton").PerformClick();
        Check(buyer.Orders[0].DiscountAmount == 10 && buyer.Orders[0].Total == 990, "Persist checkout discount");
        Check(((PointsDiscount)buyer.Discounts[0]).Points == 200 && ((PercentDiscount)buyer.Discounts[1]).Percent == 2, "Update all discounts after checkout");
        Field<Button>(tab, "AddToCartButton").PerformClick();
        checks.SetItemChecked(0, true);
        Field<Button>(tab, "CreateOrderButton").PerformClick();
        Check(buyer.Orders[1].DiscountAmount == 220 && ((PointsDiscount)buyer.Discounts[0]).Points == 100, "Apply before update");
        Reject(() => buyer.Orders[0].DiscountAmount = double.NaN);
        Reject(() => buyer.Orders[0].DiscountAmount = -1);
        Directory.CreateDirectory("tmp/lab5");
        using var form = new Form { ClientSize = new Size(1050, 650), ShowInTaskbar = false, StartPosition = FormStartPosition.Manual, Location = new Point(-3000, -3000) };
        tab.Dock = DockStyle.Fill;
        form.Controls.Add(tab);
        form.Show();
        Application.DoEvents();
        using var bitmap = new Bitmap(form.Width, form.Height);
        form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
        bitmap.Save("tmp/lab5/carts.png");
        Check(checks.Height >= checks.ItemHeight * 7, "At least seven visible discounts");
        form.Close();
    }

}
