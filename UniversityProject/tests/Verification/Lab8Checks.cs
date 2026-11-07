using System.Reflection;
using ContactEvents;
using ContactEvents.Model;
using UniversityProject.Model;
using UniversityProject.Model.Enums;
using UniversityProject.View.Controls;
using UniversityProject.View.Tabs;

internal static partial class Program
{
    private static int Subscribers(object publisher, string eventName)
    {
        var field = publisher.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic)!;
        return (field.GetValue(publisher) as Delegate)?.GetInvocationList().Length ?? 0;
    }

    private static void VerifyLab8()
    {
        var item = new Item("Имя", "Описание", 10, Category.Books);
        int names = 0, infos = 0, costs = 0;
        item.NameChanged += (sender, e) => { Check(ReferenceEquals(sender, item) && item.Name == "Новое имя", "Name event state and sender"); names++; };
        item.InfoChanged += (sender, e) => { Check(ReferenceEquals(sender, item) && item.Info == "Новое описание", "Info event state and sender"); infos++; };
        item.CostChanged += (sender, e) => { Check(ReferenceEquals(sender, item) && item.Cost == 20, "Cost event state and sender"); costs++; };
        item.Name = item.Name; item.Info = item.Info; item.Cost = item.Cost;
        Check(names == 0 && infos == 0 && costs == 0, "No-op item notifications");
        Reject(() => item.Name = null!);
        Reject(() => item.Info = new string('X', 1001));
        Reject(() => item.Cost = -1);
        Check(names == 0 && infos == 0 && costs == 0, "Invalid item notifications");
        item.Name = "Новое имя"; item.Info = "Новое описание"; item.Cost = 20;
        Check(names == 1 && infos == 1 && costs == 1, "Exactly one item event");
        var clone = (Item)item.Clone();
        clone.Name = "Копия"; clone.Info = "Другое"; clone.Cost = 30;
        Check(names == 1 && infos == 1 && costs == 1 && Subscribers(clone, "NameChanged") == 0, "Clone has no inherited subscribers");
        var address = new Address();
        int changes = 0;
        address.AddressChanged += (sender, e) => { Check(ReferenceEquals(sender, address), "Address event sender"); changes++; };
        address.Index = 123456; address.Country = "Россия"; address.City = "Томск";
        address.Street = "Ленина"; address.Building = "1"; address.Apartment = "2";
        Check(changes == 6, "All six address properties notify");
        address.Index = address.Index; address.Country = address.Country; address.City = address.City;
        address.Street = address.Street; address.Building = address.Building; address.Apartment = address.Apartment;
        Reject(() => address.Index = 1);
        Reject(() => address.City = null!);
        Check(changes == 6, "Address no-op and invalid assignment");
        using (var editor = new AddressControl { Address = address })
        {
            address.City = "Омск";
            Check(Field<TextBox[]>(editor, "_fields")[2].Text == "Омск", "Address external update");
            var replacement = new Address();
            editor.Address = replacement;
            Check(Subscribers(address, "AddressChanged") == 1 && Subscribers(replacement, "AddressChanged") == 1, "Address replacement releases old subscription");
            editor.Dispose();
            Check(Subscribers(replacement, "AddressChanged") == 0, "Address disposal releases subscription");
        }
        using (var tab = new ItemsTab())
        {
            var old = new Item("Old", "", 1, Category.Food);
            var current = new Item("Current", "", 2, Category.Food);
            int notifications = 0;
            tab.Items = new() { old };
            tab.ItemsChanged += (_, _) => notifications++;
            tab.Items = new() { current };
            Check(Subscribers(old, "CostChanged") == 0 && Subscribers(current, "CostChanged") == 1, "Items list replacement subscriptions");
            current.Cost = 3;
            Check(notifications == 2, "External item edit notifies once");
            old.Cost = 4;
            Check(notifications == 2, "Old item still notifies view");
            tab.Dispose();
            Check(Subscribers(current, "CostChanged") == 0, "Items disposal unsubscribes");
        }
        VerifyLab8MainSynchronization();
        VerifyLab8Contacts();
    }

    private static void VerifyLab8MainSynchronization()
    {
        using var form = new UniversityProject.MainForm { ShowInTaskbar = false, StartPosition = FormStartPosition.Manual, Location = new Point(-3000, -3000) };
        form.Show();
        var store = Field<Store>(form, "_store");
        var tabs = Field<TabControl>(form, "MainTabControl");
        var items = Field<ItemsTab>(form, "ItemsTabControl");
        var customers = Field<CustomersTab>(form, "CustomersTabControl");
        var carts = Field<CartsTab>(form, "CartsTabControl");
        var orders = Field<OrdersTab>(form, "OrdersTabControl");
        int changed = 0;
        items.ItemsChanged += (_, _) => changed++;
        Field<Button>(items, "AddButton").PerformClick();
        Check(changed == 1 && Field<ListBox>(carts, "ItemsListBox").Items.Count == 1 && tabs.SelectedIndex == 0, "Add event synchronizes without navigation");
        Field<TextBox>(items, "NameTextBox").Text = "События";
        Field<TextBox>(items, "CostTextBox").Text = "1000";
        Field<TextBox>(items, "DescriptionTextBox").Text = "Описание";
        Field<ComboBox>(items, "CategoryComboBox").SelectedItem = Category.Books;
        Check(changed == 5, "UI edits notify once including category");
        Field<TextBox>(items, "CostTextBox").Text = "-1";
        Check(changed == 5 && store.Items[0].Cost == 1000, "Invalid UI edit does not notify");
        tabs.SelectedIndex = 1;
        Field<Button>(customers, "AddButton").PerformClick();
        Check(Field<ComboBox>(carts, "CustomersComboBox").Items.Count == 1 && tabs.SelectedIndex == 1, "Customer event synchronizes without navigation");
        Field<TextBox>(customers, "FullnameTextBox").Text = "Общий покупатель";
        tabs.SelectedIndex = 2;
        Field<ComboBox>(carts, "CustomersComboBox").SelectedIndex = 0;
        Field<ListBox>(carts, "ItemsListBox").SelectedIndex = 0;
        Field<Button>(carts, "AddToCartButton").PerformClick();
        Field<Button>(carts, "CreateOrderButton").PerformClick();
        var grid = Field<DataGridView>(orders, "OrdersDataGridView");
        Check(grid.Rows.Count == 1 && orders.Orders.Count == 1 && tabs.SelectedIndex == 2, "Order event synchronizes without navigation");
        Check(Field<ListBox>(customers, "DiscountsListBox").GetItemText(Field<ListBox>(customers, "DiscountsListBox").Items[0])!.Contains("100"), "Earned points refresh customer panel");
        store.Items[0].Cost = 2000;
        Check((double)grid.Rows[0].Cells[4].Value! == 2000 && (double)grid.Rows[0].Cells[6].Value! == 2000, "External model event synchronizes order totals");
        tabs.SelectedIndex = 0;
        Field<TextBox>(items, "CostTextBox").Text = "2000";
        Field<Button>(items, "RemoveButton").PerformClick();
        Check(Field<ListBox>(carts, "ItemsListBox").Items.Count == 0 && store.Customers[0].Orders[0].Items.Count == 1, "Removal event preserves aggregation");
        tabs.SelectedIndex = 1;
        Field<Button>(customers, "RemoveButton").PerformClick();
        Check(grid.Rows.Count == 0 && Field<ComboBox>(carts, "CustomersComboBox").SelectedIndex == -1, "Customer removal clears dependent views immediately");
        form.Close();
    }

    private static void VerifyLab8Contacts()
    {
        var contact = new Contact { FullName = "Имя", PhoneNumber = "123", Address = "Томск" };
        using var first = new EventForm { Contact = contact };
        using var second = new EventForm { Contact = contact };
        using var third = new EventForm { Contact = contact };
        int changed = 0;
        contact.FullNameChanged += (_, _) => changed++;
        Field<TextBox>(first, "FullNameTextBox").Text = "Иван";
        Check(changed == 1 && contact.FullName == "Иван" && Field<TextBox>(second, "FullNameTextBox").Text == "Иван" && Field<TextBox>(third, "FullNameTextBox").Text == "Иван", "Three windows name synchronization without recursion");
        Field<TextBox>(second, "PhoneNumberTextBox").Text = "+7-123";
        Check(contact.PhoneNumber == "+7-123" && Field<TextBox>(first, "PhoneNumberTextBox").Text == "+7-123" && Field<TextBox>(third, "PhoneNumberTextBox").Text == "+7-123", "Three windows phone synchronization");
        Field<TextBox>(third, "AddressTextBox").Text = "Омск";
        Check(contact.Address == "Омск" && Field<TextBox>(first, "AddressTextBox").Text == "Омск" && Field<TextBox>(second, "AddressTextBox").Text == "Омск", "Three windows address synchronization");
        contact.FullName = contact.FullName;
        Check(changed == 1, "Contact equal assignment suppressed");
        var replacement = new Contact { FullName = "Другой" };
        first.Contact = replacement;
        Check(Subscribers(contact, "PhoneNumberChanged") == 2 && Subscribers(replacement, "PhoneNumberChanged") == 1, "Contact replacement subscriptions");
        contact.FullName = "Старый";
        Check(Field<TextBox>(first, "FullNameTextBox").Text == "Другой", "Old contact no longer updates replaced window");
        first.Contact = null;
        Check(!Field<TextBox>(first, "FullNameTextBox").Enabled && Subscribers(replacement, "PhoneNumberChanged") == 0, "Null contact detaches and disables");
        second.Dispose();
        Check(Subscribers(contact, "PhoneNumberChanged") == 1, "Disposed contact window detaches");
        third.Dispose();
        Check(Subscribers(contact, "PhoneNumberChanged") == 0, "All contact window subscriptions released");
        using var context = new ContactApplicationContext();
        var windows = Field<List<EventForm>>(context, "_forms");
        Check(windows.Count == 3 && windows.All(w => ReferenceEquals(w.Contact, windows[0].Contact)), "Demo opens exactly three windows for one model");
        Contact shared = windows[0].Contact!;
        Directory.CreateDirectory("tmp/lab8");
        using (var snapshot = new Bitmap(windows[0].Width, windows[0].Height))
        {
            windows[0].DrawToBitmap(snapshot, new Rectangle(Point.Empty, windows[0].Size));
            snapshot.Save("tmp/lab8/contact.png");
        }
        windows[0].Close();
        Check(windows.Count == 2 && windows.All(w => !w.IsDisposed) && Subscribers(shared, "FullNameChanged") == 2, "Closing one window preserves other editors");
        windows[0].Close(); windows[0].Close();
        Check(windows.Count == 0 && Subscribers(shared, "FullNameChanged") == 0, "Closing last contact editor releases model");
    }
}
