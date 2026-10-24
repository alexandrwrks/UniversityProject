using System.Reflection;
using UniversityProject.Model;
using UniversityProject.Services;
using UniversityProject.View.Controls;
using UniversityProject.View.Tabs;

internal static partial class Program
{
    private static int _checks;
    private static void Check(bool condition, string message)
    {
        if (!condition) throw new Exception(message);
        _checks++;
    }
    private static void Reject(Action action)
    {
        try { action(); } catch (ArgumentException) { _checks++; return; }
        throw new Exception("Invalid value accepted");
    }
    private static T Field<T>(object target, string name) => (T)target.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(target)!;
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        var item = new Item(new string('a',200), new string('b',1000),100000,Category.Books);
        Reject(() => item.Name = new string('a',201));
        Reject(() => item.Info = new string('a',1001));
        foreach (double value in new[] { -1d,100001,double.NaN,double.PositiveInfinity,double.NegativeInfinity }) Reject(() => item.Cost = value);
        item.Cost = 0; Check(item.Name.Length == 200 && item.Info.Length == 1000, "Rejected edit changed data");
        var address = new Address(999999,new string('a',50),new string('b',50),new string('c',100),new string('d',10),new string('e',10));
        Reject(() => address.Index = 99999); Reject(() => address.Index = 1000000);
        Reject(() => address.Country = new string('a',51)); Reject(() => address.City = new string('a',51));
        Reject(() => address.Street = new string('a',101)); Reject(() => address.Building = new string('a',11)); Reject(() => address.Apartment = new string('a',11));
        var customer = new Customer(new string('a',200),address);
        Reject(() => customer.Fullname = new string('a',201)); Reject(() => customer.Address = null!);
        Check(item.Id == 1 && customer.Id == 1, "Each entity type must start at 1");
        var secondItem = new Item("Second", "", 0, Category.Books);
        var secondCustomer = new Customer("Second", new Address());
        Check(secondItem.Id == 2 && secondCustomer.Id == 2, "Entity counters are not independent");
        var ids = new System.Collections.Concurrent.ConcurrentBag<int>();
        Parallel.For(0,1000,_ => ids.Add(IdGenerator.GetNextItemId())); Check(ids.Distinct().Count()==1000,"IDs repeat");
        var customerIds = new System.Collections.Concurrent.ConcurrentBag<int>();
        Parallel.For(0, 1000, _ => customerIds.Add(IdGenerator.GetNextCustomerId()));
        Check(customerIds.Distinct().Count() == 1000, "Customer IDs repeat");
        Check(ids.Min() == 3 && customerIds.Min() == 3, "Counters affected each other");
        using var editor = new AddressControl { Address = address };
        var fields = Field<TextBox[]>(editor,"_fields");
        fields[0].Text = "abc"; Check(address.Index==999999 && fields[0].BackColor==Color.MistyRose,"Invalid index not highlighted");
        fields[1].Text = "Россия"; Check(editor.Address.Country=="Россия","Valid edit was lost");
        Check(!editor.ValidateAddress(),"Invalid address accepted");
        fields[0].Text = "123456"; Check(editor.ValidateAddress() && address.Index==123456,"Index correction failed");
        using var otherEditor = new AddressControl { Address = new Address(654321, "Страна", "Город", "Улица", "131/1", "251а") };
        var otherFields = Field<TextBox[]>(otherEditor, "_fields");
        Check(otherFields[0].Text == "654321" && otherFields[4].Text == "131/1" && otherFields[5].Text == "251а", "Assigned address was not fully displayed");
        otherFields[4].Text = new string('a', 11);
        otherFields[2].Text = "Новый город";
        Check(otherEditor.Address.Building == "131/1" && otherEditor.Address.City == "Новый город", "Getter lost valid edits after another field failed");
        var store = new Store();
        using var items = new ItemsTab { Items = store.Items };
        Field<Button>(items,"AddButton").PerformClick();
        Check(store.Items.Count==1,"Tab copied store list");
        Field<TextBox>(items,"NameTextBox").Text="Книга";
        Field<TextBox>(items,"CostTextBox").Text="NaN";
        Check(store.Items[0].Name=="Книга" && store.Items[0].Cost==0,"Item edit failed");
        Field<ComboBox>(items,"CategoryComboBox").SelectedItem=Category.Books;
        Check(store.Items[0].Category==Category.Books,"Category edit failed");
        Field<Button>(items,"RemoveButton").PerformClick(); Check(store.Items.Count==0,"Removal failed");
        Check(!Field<TextBox>(items,"NameTextBox").Enabled,"Empty tab editable");
        var replacement = new List<Item> { item }; items.Items=replacement;
        Field<ListBox>(items,"ItemsListBox").SelectedIndex=0; Check(Field<TextBox>(items,"IdTextBox").Text==item.Id.ToString(),"Selection failed");
        using var customers = new CustomersTab { Customers=store.Customers };
        Field<Button>(customers,"AddButton").PerformClick();
        Field<TextBox>(customers,"FullnameTextBox").Text="Иван Иванов";
        var customerAddress=Field<AddressControl>(customers,"DeliveryAddressControl");
        Field<TextBox[]>(customerAddress,"_fields")[2].Text="Томск";
        Check(store.Customers.Count==1 && store.Customers[0].Fullname=="Иван Иванов" && store.Customers[0].Address.City=="Томск","Customer edit failed");
        Field<Button>(customers,"RemoveButton").PerformClick(); Check(store.Customers.Count==0,"Customer removal failed");
        // Regression: editing a non-first row must not move the selection or edit another object.
        var first = new Item("Первый", "Описание 1", 10, Category.Food);
        var second = new Item("Второй", "Описание 2", 20, Category.Books);
        items.Items = new List<Item> { first, second };
        var itemList = Field<ListBox>(items, "ItemsListBox");
        itemList.SelectedIndex = 1;
        Field<TextBox>(items, "NameTextBox").Text = "Второй изменён";
        Check(ReferenceEquals(itemList.SelectedItem, second) && first.Name == "Первый" && second.Name == "Второй изменён", "Editing changed selected row");
        Field<TextBox>(items, "CostTextBox").Text = "-1";
        Check(second.Cost == 20 && Field<TextBox>(items, "CostTextBox").BackColor == Color.MistyRose, "Invalid cost changed model");
        itemList.SelectedIndex = 0;
        Check(Field<TextBox>(items, "CostTextBox").Text == "10" && Field<TextBox>(items, "CostTextBox").BackColor != Color.MistyRose, "Selection retained previous error");
        Check((Category)Field<ComboBox>(items, "CategoryComboBox").SelectedItem! == Category.Food, "Selected category differs from model");
        Reject(() => items.Items = null!);
        Reject(() => customers.Customers = null!);
        Reject(() => editor.Address = null!);
        Reject(() => item.Name = null!);
        Reject(() => address.City = null!);
        var customer1 = new Customer("Первый", new Address());
        var customer2 = new Customer("Второй", new Address());
        customers.Customers = new List<Customer> { customer1, customer2 };
        var customerList = Field<ListBox>(customers, "CustomersListBox");
        customerList.SelectedIndex = 1;
        Field<TextBox>(customers, "FullnameTextBox").Text = "Второй изменён";
        Check(ReferenceEquals(customerList.SelectedItem, customer2) && customer1.Fullname == "Первый", "Customer selection changed");
        var addressFields = Field<TextBox[]>(Field<AddressControl>(customers, "DeliveryAddressControl"), "_fields");
        addressFields[2].Text = "Томск";
        customerList.SelectedIndex = 0;
        addressFields[2].Text = "Омск";
        Check(customer1.Address.City == "Омск" && customer2.Address.City == "Томск", "Address editing affected another customer");
        Field<Button>(customers, "RemoveButton").PerformClick();
        Check(ReferenceEquals(customerList.SelectedItem, customer2), "Neighbor not selected after deletion");
        using var form = new UniversityProject.MainForm();
        Check(form.Text=="Object Oriented Practics","Window title failed");
        Check(form.Icon != null, "Window icon missing");
        form.ShowInTaskbar = false;
        form.StartPosition = FormStartPosition.Manual;
        form.Location = new Point(-30000, -30000);
        form.Show();
        Application.DoEvents();
        Field<Button>(Field<ItemsTab>(form, "ItemsTabControl"), "AddButton").PerformClick();
        var customerTab = Field<CustomersTab>(form, "CustomersTabControl");
        Field<TabControl>(form, "MainTabControl").SelectedIndex = 1;
        Field<Button>(customerTab, "AddButton").PerformClick();
        form.CreateControl();
        form.PerformLayout();
        Directory.CreateDirectory("tmp/review");
        var tabs = Field<TabControl>(form, "MainTabControl");
        foreach (var size in new[] { new Size(820,490), new Size(1200,800) })
        {
            form.Size = size;
            for (int index = 0; index < 2; index++)
            {
                tabs.SelectedIndex = index;
                form.PerformLayout();
                Application.DoEvents();
                using var bitmap = new Bitmap(form.Width, form.Height);
                form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
                bitmap.Save($"tmp/review/window-{size.Width}-{index}.png");
                var tab = tabs.TabPages[index].Controls[0];
                var layout = Field<TableLayoutPanel>(tab, "EditorLayout");
                var lastField = index == 0 ? (Control)Field<ComboBox>(tab, "CategoryComboBox") : Field<AddressControl>(tab, "DeliveryAddressControl");
                Check(lastField.Width > 100 && lastField.Right <= layout.ClientSize.Width, "Editor clipped at minimum size");
                if (index == 1)
                {
                    var addressEditor = (AddressControl)lastField;
                    var controls = Field<TextBox[]>(addressEditor, "_fields");
                    Point Position(int field) => addressEditor.PointToClient(controls[field].PointToScreen(Point.Empty));
                    Check(Position(1).Y == Position(2).Y && Position(1).X < Position(2).X, "Country and city must share a row");
                    Check(Position(4).Y == Position(5).Y && Position(4).X < Position(5).X, "Building and apartment must share a row");
                    Check(Position(0).Y < Position(1).Y && Position(1).Y < Position(3).Y && Position(3).Y < Position(4).Y, "Address row order differs from mockup");
                    Check(controls[3].Width > controls[1].Width + controls[2].Width, "Street must span the address width");
                    Check(controls[0].Width < controls[3].Width / 2 && controls[4].Width < controls[3].Width / 2, "Index and building must be short fields");
                    Check(controls.All(control => { var origin = addressEditor.PointToClient(control.PointToScreen(Point.Empty)); return origin.X >= 0 && origin.Y >= 0 && origin.X + control.Width <= addressEditor.Width && origin.Y + control.Height <= addressEditor.Height; }), "Address fields are clipped");
                }
            }
        }
        VerifyLab3(form);
        VerifyLab4(form);
        form.Close();
        Application.DoEvents();
        Application.ExitThread();
        Console.WriteLine($"PASS: {_checks} checks");
    }
}
