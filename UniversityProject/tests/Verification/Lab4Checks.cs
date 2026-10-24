using UniversityProject.Model;
using UniversityProject.View.Controls;
using UniversityProject.View.Tabs;

internal static partial class Program
{
    private static void VerifyLab4(UniversityProject.MainForm form)
    {
        Directory.CreateDirectory("tmp/lab4");
        var item = new Item("Учебник", "Проверка наследования", 50, Category.Books);
        var address = new Address(634000, "Россия", "Томск", "Ленина", "40", "101");
        var date = DateTime.Today.AddDays(2);
        var priority = new PriorityOrder(address, new[] { item }, date, PriorityOrder.DeliveryTimes[2]);
        Order asBase = priority;
        Check(ReferenceEquals(asBase, priority) && asBase.Amount == 50 && asBase.Status == OrderStatus.New, "Priority order does not work through base reference");
        Check(priority.DeliveryDate == date && priority.DeliveryTime == PriorityOrder.DeliveryTimes[2], "Priority constructor parameters");
        Check(ReferenceEquals(priority.Items[0], item) && !ReferenceEquals(priority.Address, address), "Priority base constructor lost aggregation/address snapshot");
        var ordinary = new Order(address, new[] { item });
        Check(ordinary.Id != priority.Id && ordinary.Id > priority.Id, "Order and PriorityOrder must share ID sequence");
        priority.DeliveryDate = date.AddHours(13);
        Check(priority.DeliveryDate == date, "Delivery date includes a hidden time component");
        Check(PriorityOrder.DeliveryTimes.Count == 6 && PriorityOrder.DeliveryTimes.Distinct().Count() == 6, "Delivery slots must contain six unique values");
        foreach (string time in PriorityOrder.DeliveryTimes)
        {
            priority.DeliveryTime = time;
            Check(priority.DeliveryTime == time, "Valid delivery interval rejected");
        }
        string previous = priority.DeliveryTime;
        Reject(() => priority.DeliveryTime = "22:00 – 23:00");
        Reject(() => priority.DeliveryTime = string.Empty);
        Reject(() => priority.DeliveryTime = null!);
        Check(priority.DeliveryTime == previous, "Rejected interval modified model");
        bool immutable = false;
        try { ((IList<string>)PriorityOrder.DeliveryTimes)[0] = "invalid"; }
        catch (NotSupportedException) { immutable = true; }
        Check(immutable, "Delivery slots can be changed externally");
        var empty = new PriorityOrder();
        Check(empty.Items.Count == 0 && empty.Amount == 0 && empty.DeliveryDate == DateTime.Today && empty.DeliveryTime == PriorityOrder.DeliveryTimes[0], "Default priority order");

        // DateTime supports years that the Windows calendar cannot display.
        DateTime previousDate = priority.DeliveryDate;
        Reject(() => priority.DeliveryDate = DateTime.MinValue);
        Reject(() => priority.DeliveryDate = DateTime.MaxValue);
        Check(priority.DeliveryDate == previousDate, "Rejected delivery date changed model");
        Reject(() => new PriorityOrder(address, new[] { item }, DateTime.MinValue, PriorityOrder.DeliveryTimes[0]));
        Reject(() => new PriorityOrder(address, new[] { item }, DateTime.MaxValue, PriorityOrder.DeliveryTimes[0]));
        foreach (DateTime boundary in new[] { new DateTime(1753, 1, 1), new DateTime(9998, 12, 31) })
        {
            priority.DeliveryDate = boundary;
            using var view = new OrdersTab { Customers = new List<Customer> { new Customer("Boundary", address) } };
            view.Customers[0].Orders.Add(priority);
            view.RefreshData();
            var boundaryGrid = Field<DataGridView>(view, "OrdersDataGridView");
            boundaryGrid.CurrentCell = boundaryGrid.Rows[0].Cells[0];
            boundaryGrid.Rows[0].Selected = true;
            Check(Field<DateTimePicker>(view, "DeliveryDatePicker").Value.Date == boundary, "Supported boundary date cannot be displayed");
        }
        priority.DeliveryDate = previousDate;

        var tabs = Field<TabControl>(form, "MainTabControl");
        var store = Field<Store>(form, "_store");
        store.Items.Clear(); store.Customers.Clear();
        store.Items.Add(item);
        var customerTab = Field<CustomersTab>(form, "CustomersTabControl");
        customerTab.Customers = store.Customers;
        tabs.SelectedIndex = 1;
        var flag = Field<CheckBox>(customerTab, "IsPriorityCheckBox");
        Check(!flag.Checked && !flag.Enabled, "Priority flag active without customer");
        Field<Button>(customerTab, "AddButton").PerformClick();
        var priorityBuyer = store.Customers[0];
        Check(!priorityBuyer.IsPriority && flag.Enabled && !flag.Checked, "New customer must not be priority");
        flag.Checked = true;
        Check(priorityBuyer.IsPriority, "Priority checkbox not saved");
        Field<Button>(customerTab, "AddButton").PerformClick();
        var normalBuyer = store.Customers[1];
        Check(!flag.Checked && !normalBuyer.IsPriority && priorityBuyer.IsPriority, "Priority flag leaked between customers");
        Field<ListBox>(customerTab, "CustomersListBox").SelectedIndex = 0;
        Check(flag.Checked, "Customer priority not displayed");
        var carts = Field<CartsTab>(form, "CartsTabControl");
        tabs.SelectedIndex = 2;
        var buyers = Field<ComboBox>(carts, "CustomersComboBox");
        var catalog = Field<ListBox>(carts, "ItemsListBox");
        catalog.SelectedIndex = 0;
        buyers.SelectedIndex = 1;
        Field<Button>(carts, "AddToCartButton").PerformClick();
        Field<Button>(carts, "CreateOrderButton").PerformClick();
        Check(normalBuyer.Orders.Count == 1 && normalBuyer.Orders[0].GetType() == typeof(Order), "Regular buyer must receive ordinary order");
        buyers.SelectedIndex = 0;
        Field<Button>(carts, "AddToCartButton").PerformClick();
        Field<Button>(carts, "CreateOrderButton").PerformClick();
        Check(priorityBuyer.Orders.Count == 1 && priorityBuyer.Orders[0] is PriorityOrder && priorityBuyer.Cart.Items.Count == 0, "Priority buyer must receive priority order and clear cart");
        var placed = (PriorityOrder)priorityBuyer.Orders[0];
        Check(ReferenceEquals(placed.Items[0], item) && placed.Status == OrderStatus.New && placed.Id != normalBuyer.Orders[0].Id, "Priority order inherited fields or shared IDs");
        tabs.SelectedIndex = 3;
        var orders = Field<OrdersTab>(form, "OrdersTabControl");
        var grid = Field<DataGridView>(orders, "OrdersDataGridView");
        Check(grid.Rows.Count == 2 && orders.Orders.Any(o => o is PriorityOrder) && orders.Orders.Any(o => o.GetType() == typeof(Order)), "Mixed orders not displayed");
        var priorityRow = grid.Rows.Cast<DataGridViewRow>().Single(row => ReferenceEquals(row.Tag, placed));
        var normalRow = grid.Rows.Cast<DataGridViewRow>().Single(row => ReferenceEquals(row.Tag, normalBuyer.Orders[0]));
        grid.CurrentCell = priorityRow.Cells[0]; priorityRow.Selected = true;
        var options = Field<TableLayoutPanel>(orders, "PriorityOptionsPanel");
        var times = Field<ComboBox>(orders, "DeliveryTimeComboBox");
        var picker = Field<DateTimePicker>(orders, "DeliveryDatePicker");
        Check(options.Visible && ReferenceEquals(Field<Order?>(orders, "_selectedOrder"), placed) && ReferenceEquals(Field<PriorityOrder?>(orders, "_selectedPriorityOrder"), placed), "Selected priority references differ");
        Check(times.DropDownStyle == ComboBoxStyle.DropDownList && times.Items.Count == 6 && (string)times.SelectedItem! == placed.DeliveryTime, "Priority interval selector");
        times.SelectedIndex = 5; picker.Value = date;
        Check(placed.DeliveryTime == PriorityOrder.DeliveryTimes[5] && placed.DeliveryDate == date, "Priority delivery edits not saved");
        grid.CurrentCell = normalRow.Cells[0]; normalRow.Selected = true;
        Check(!options.Visible && Field<PriorityOrder?>(orders, "_selectedPriorityOrder") == null && ReferenceEquals(Field<Order?>(orders, "_selectedOrder"), normalBuyer.Orders[0]), "Ordinary order retains priority options/reference");
        Field<ComboBox>(orders, "StatusComboBox").SelectedItem = OrderStatus.Processing;
        Check(normalBuyer.Orders[0].Status == OrderStatus.Processing && placed.Status == OrderStatus.New, "Status changed wrong order type");
        grid.ClearSelection();
        Check(!options.Visible && Field<Order?>(orders, "_selectedOrder") == null && Field<PriorityOrder?>(orders, "_selectedPriorityOrder") == null, "Clear selection retains priority state");
        grid.CurrentCell = priorityRow.Cells[0]; priorityRow.Selected = true;
        Field<ComboBox>(orders, "StatusComboBox").SelectedItem = OrderStatus.Sent;
        orders.RefreshData();
        Check(ReferenceEquals(grid.CurrentRow?.Tag, placed) && options.Visible && times.SelectedIndex == 5 && placed.Status == OrderStatus.Sent && picker.Value.Date == date, "Priority selection not restored on refresh");
        // Toggling buyer priority affects future orders, not the runtime type of existing orders.
        tabs.SelectedIndex = 1;
        flag.Checked = false;
        tabs.SelectedIndex = 2;
        Field<Button>(carts, "AddToCartButton").PerformClick();
        Field<Button>(carts, "CreateOrderButton").PerformClick();
        Check(priorityBuyer.Orders.Count == 2 && priorityBuyer.Orders[0] is PriorityOrder && priorityBuyer.Orders[1].GetType() == typeof(Order), "Priority toggle rewrites previous orders");
        Check(tabs.TabPages.Count == 4 && tabs.TabPages.Cast<TabPage>().All(page => !page.Controls.OfType<PriorityOrdersTab>().Any()), "Training tab should be retained in source, not main window");

        using var trainingForm = new Form { ShowInTaskbar = false, StartPosition = FormStartPosition.Manual, Location = new Point(-30000, -30000), ClientSize = new Size(700, 620) };
        using var training = new PriorityOrdersTab { Dock = DockStyle.Fill };
        trainingForm.Controls.Add(training); trainingForm.Show(); Application.DoEvents();
        Check(!Field<Button>(training, "AddItemButton").Enabled && !Field<Button>(training, "RemoveItemButton").Enabled, "Empty training actions");
        training.Items = store.Items;
        var add = Field<Button>(training, "AddItemButton");
        var remove = Field<Button>(training, "RemoveItemButton");
        var contents = Field<ListBox>(training, "OrderItemsListBox");
        add.PerformClick(); add.PerformClick(); add.PerformClick();
        Check(training.Order.Items.Count == 3 && training.Order.Items.All(value => ReferenceEquals(value, item)), "Training add must choose existing catalog item");
        contents.SelectedIndex = 1; remove.PerformClick();
        Check(contents.Items.Count == 2 && contents.SelectedIndex == 1, "Remove must select next item");
        remove.PerformClick();
        Check(contents.Items.Count == 1 && contents.SelectedIndex == 0, "Removing last must select previous last item");
        remove.PerformClick();
        Check(contents.Items.Count == 0 && contents.SelectedIndex == -1 && !remove.Enabled, "Empty training selection");
        add.PerformClick();
        var old = training.Order;
        Field<ComboBox>(training, "StatusComboBox").SelectedItem = OrderStatus.Processing;
        Field<ComboBox>(training, "DeliveryTimeComboBox").SelectedIndex = 3;
        Field<DateTimePicker>(training, "DeliveryDatePicker").Value = date;
        var addressEditor = Field<AddressControl>(training, "DeliveryAddressControl");
        var addressFields = Field<TextBox[]>(addressEditor, "_fields");
        addressFields[2].Text = "Томск";
        Check(old.Status == OrderStatus.Processing && old.DeliveryTime == PriorityOrder.DeliveryTimes[3] && old.DeliveryDate == date && old.Address.City == "Томск", "Training edits not saved");
        addressFields[0].Text = "wrong";
        Check(addressFields[0].BackColor == Color.MistyRose && old.Address.Index == 100000, "Training address validation");
        Field<Button>(training, "ClearOrderButton").PerformClick();
        Check(!ReferenceEquals(old, training.Order) && old.Id != training.Order.Id && old.Items.Count == 1 && training.Order.Items.Count == 0, "Clear Order must replace object without changing old order");
        Check(training.Order.Status == OrderStatus.New && training.Order.DeliveryDate == DateTime.Today && training.Order.DeliveryTime == PriorityOrder.DeliveryTimes[0] && training.Order.Address.City == "", "Clear Order did not restore defaults");
        Check(addressFields[0].Text == "100000" && addressFields[0].BackColor != Color.MistyRose, "Clear Order retains address errors");
        Check(Field<TextBox>(training, "IdTextBox").ReadOnly && Field<TextBox>(training, "CreatedTextBox").ReadOnly, "Training Id/date are editable");
        add.PerformClick();
        using (var bitmap = new Bitmap(trainingForm.Width, trainingForm.Height))
        {
            trainingForm.DrawToBitmap(bitmap, new Rectangle(Point.Empty, trainingForm.Size));
            bitmap.Save("tmp/lab4/training.png");
        }
        trainingForm.Close();
        // Verify the integrated mockups at both supported window sizes.
        foreach (Size size in new[] { new Size(820, 490), new Size(1100, 730) })
        {
            form.Size = size;
            tabs.SelectedIndex = 1;
            Field<ListBox>(customerTab, "CustomersListBox").SelectedIndex = 0;
            flag.Checked = true;
            Application.DoEvents();
            using (var bitmap = new Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
                bitmap.Save($"tmp/lab4/customers-{form.Width}.png");
            }
            tabs.SelectedIndex = 3;
            priorityRow = grid.Rows.Cast<DataGridViewRow>().Single(row => ReferenceEquals(row.Tag, placed));
            grid.CurrentCell = priorityRow.Cells[0]; priorityRow.Selected = true;
            Application.DoEvents();
            using var snapshot = new Bitmap(form.Width, form.Height);
            form.DrawToBitmap(snapshot, new Rectangle(Point.Empty, form.Size));
            snapshot.Save($"tmp/lab4/orders-{form.Width}.png");
            var timeLabel = Field<Label>(orders, "DeliveryTimeLabel");
            Check(timeLabel.GetPreferredSize(new Size(timeLabel.Width, 0)).Height <= timeLabel.Height, "Delivery Time label wraps/clips");
            Check(options.Visible && times.Width >= 90 && times.Right <= options.ClientSize.Width, "Priority options clipped");
            Check(Field<Label>(orders, "AmountLabel").Bottom <= Field<TableLayoutPanel>(orders, "EditorLayout").ClientSize.Height, "Priority order amount clipped");
        }
    }
}
