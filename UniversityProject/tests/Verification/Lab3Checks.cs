using System.Globalization;
using UniversityProject.Model;
using UniversityProject.View.Controls;
using UniversityProject.View.Tabs;

internal static partial class Program
{
    private static void VerifyLab3(UniversityProject.MainForm form)
    {
        Directory.CreateDirectory("tmp/lab3");
        var product = new Item("Aggregation", "", 12.5, Category.Books);
        var cart = new Cart();
        Check(cart.Amount == 0, "Empty cart amount");
        cart.Items = null!;
        Check(cart.Amount == 0 && cart.Items != null, "Null cart amount");
        cart.Items = new List<Item> { product, product };
        Check(cart.Amount == 25, "Cart must count duplicate items");
        var address = new Address(123456, "Россия", "Томск", "Ленина", "1а", "2");
        DateTime before = DateTime.Now;
        var order = new Order(address, cart.Items);
        Check(order.Id == 1 && order.CreationDate >= before && order.CreationDate <= DateTime.Now && order.Status == OrderStatus.New, "Order initialization");
        Check(!ReferenceEquals(order.Items, cart.Items) && ReferenceEquals(order.Items[0], product), "Order must copy list, retain items");
        cart.Items.Clear();
        Check(order.Items.Count == 2 && order.Amount == 25, "Clearing cart cleared order");
        product.Cost = 15;
        Check(order.Amount == 30, "Order amount must use shared item prices");
        address.City = "Омск";
        Check(order.Address.City == "Томск" && !ReferenceEquals(address, order.Address), "Order delivery address changed with customer");
        var nextOrder = new Order(address, new List<Item>());
        Check(nextOrder.Id == 2 && nextOrder.Amount == 0, "Order IDs or empty amount");
        nextOrder.Items = null!;
        Check(nextOrder.Amount == 0, "Null order amount");
        Check(typeof(Order).GetProperty(nameof(Order.Id))!.SetMethod == null && typeof(Order).GetProperty(nameof(Order.CreationDate))!.SetMethod == null && typeof(Order).GetProperty(nameof(Order.Amount))!.SetMethod == null, "Order readonly properties");
        Reject(() => order.Address = null!);
        Reject(() => new Order(null!, new List<Item>()));
        Reject(() => new Order(address, null!));
        var independent = new Customer("Independent", new Address());
        var another = new Customer("Another", new Address());
        Check(!ReferenceEquals(independent.Cart, another.Cart) && !ReferenceEquals(independent.Orders, another.Orders), "Customers share owned collections");

        var tabs = Field<TabControl>(form, "MainTabControl");
        var store = Field<Store>(form, "_store");
        var carts = Field<CartsTab>(form, "CartsTabControl");
        var orders = Field<OrdersTab>(form, "OrdersTabControl");
        Check(ReferenceEquals(store.Items, carts.Items) && ReferenceEquals(store.Customers, carts.Customers) && ReferenceEquals(store.Customers, orders.Customers), "Tabs copied Store lists");
        tabs.SelectedIndex = 2;
        Application.DoEvents();
        var catalog = Field<ListBox>(carts, "ItemsListBox");
        var customers = Field<ComboBox>(carts, "CustomersComboBox");
        var contents = Field<ListBox>(carts, "CartListBox");
        var add = Field<Button>(carts, "AddToCartButton");
        var create = Field<Button>(carts, "CreateOrderButton");
        Check(catalog.Items.Count == store.Items.Count && customers.Items.Count == store.Customers.Count, "Carts did not refresh on navigation");
        Check(customers.SelectedIndex == -1 && contents.Items.Count == 0 && !add.Enabled && !create.Enabled, "No customer state");
        customers.SelectedIndex = 0;
        catalog.SelectedIndex = 0;
        var buyer1 = store.Customers[0];
        add.PerformClick(); add.PerformClick();
        Check(buyer1.Cart.Items.Count == 2 && ReferenceEquals(buyer1.Cart.Items[0], store.Items[0]), "Add must aggregate existing items");
        Check(Field<Label>(carts, "AmountLabel").Text == buyer1.Cart.Amount.ToString("N2"), "Cart amount display");
        contents.SelectedIndex = 1;
        Field<Button>(carts, "RemoveItemButton").PerformClick();
        Check(buyer1.Cart.Items.Count == 1 && contents.Items.Count == 1, "Remove only one occurrence");
        tabs.SelectedIndex = 1;
        Field<Button>(Field<CustomersTab>(form, "CustomersTabControl"), "AddButton").PerformClick();
        var buyer2 = store.Customers[1];
        tabs.SelectedIndex = 2;
        Check(customers.Items.Count == 2 && ReferenceEquals(customers.SelectedItem, buyer1), "Customer navigation refresh");
        customers.SelectedIndex = 1;
        Check(contents.Items.Count == 0 && !create.Enabled, "Different customers share carts");
        add.PerformClick();
        create.PerformClick();
        Check(buyer2.Cart.Items.Count == 0 && buyer2.Orders.Count == 1 && buyer1.Cart.Items.Count == 1, "Order creation or cart isolation");
        Order placed = buyer2.Orders[0];
        Check(placed.Items.Count == 1 && ReferenceEquals(placed.Items[0], store.Items[0]) && placed.Status == OrderStatus.New, "Placed order contents/status");
        Check(!create.Enabled && contents.Items.Count == 0, "Cart UI not cleared after order");
        customers.SelectedIndex = 0;
        Field<Button>(carts, "ClearCartButton").PerformClick();
        Check(buyer1.Cart.Amount == 0 && contents.Items.Count == 0, "Clear cart");
        tabs.SelectedIndex = 3;
        var grid = Field<DataGridView>(orders, "OrdersDataGridView");
        Check(grid.Rows.Count == 1 && orders.Orders.Count == 1 && ReferenceEquals(grid.Rows[0].Tag, placed), "Orders did not refresh");
        Check(grid.ReadOnly && !grid.MultiSelect && !grid.AllowUserToAddRows && !grid.AllowUserToDeleteRows && !grid.AllowUserToResizeRows && !grid.AllowUserToOrderColumns && grid.Columns.Cast<DataGridViewColumn>().All(column => column.SortMode == DataGridViewColumnSortMode.NotSortable), "Grid restrictions");
        Check(grid.Columns.Count == 6 && (string)grid.Rows[0].Cells[2].Value! == buyer2.Fullname, "Order columns");
        grid.CurrentCell = grid.Rows[0].Cells[0];
        grid.Rows[0].Selected = true;
        var status = Field<ComboBox>(orders, "StatusComboBox");
        Check(Field<TextBox>(orders, "IdTextBox").Text == placed.Id.ToString() && Field<ListBox>(orders, "OrderItemsListBox").Items.Count == 1, "Order details selection");
        Check(Field<TextBox>(orders, "IdTextBox").ReadOnly && Field<TextBox>(orders, "CreatedTextBox").ReadOnly && Field<AddressControl>(orders, "DeliveryAddressControl").ReadOnly, "Order details editable");
        status.SelectedItem = OrderStatus.Delivered;
        Check(placed.Status == OrderStatus.Delivered && (OrderStatus)grid.Rows[0].Cells[5].Value! == OrderStatus.Delivered, "Status change not propagated");
        tabs.SelectedIndex = 0;
        var itemsTab = Field<ItemsTab>(form, "ItemsTabControl");
        Field<ListBox>(itemsTab, "ItemsListBox").SelectedIndex = 0;
        Field<TextBox>(itemsTab, "CostTextBox").Text = 125.5.ToString(CultureInfo.CurrentCulture);
        tabs.SelectedIndex = 3;
        Check(placed.Amount == 125.5 && (double)grid.Rows[0].Cells[4].Value! == 125.5 && Field<Label>(orders, "AmountLabel").Text == 125.5.ToString("N2"), "Shared price or orders refresh failed");
        Check(ReferenceEquals(grid.CurrentRow?.Tag, placed), "Order selection lost after refresh");
        store.Items.RemoveAt(0);
        tabs.SelectedIndex = 2;
        Check(catalog.Items.Count == 0 && placed.Items.Count == 1, "Catalog deletion destroyed aggregated item");
        store.Customers.Remove(buyer1);
        carts.RefreshData();
        Check(customers.SelectedIndex == -1 && contents.Items.Count == 0 && !create.Enabled, "Deleted customer remains active");
        // Render with realistic content in both columns and multiple orders.
        store.Items.Add(product);
        buyer2.Cart.Items.Add(product);
        buyer2.Orders.Add(new Order(buyer2.Address, new List<Item> { product, product }));
        carts.RefreshData();
        for (int widthIndex = 0; widthIndex < 2; widthIndex++)
        {
            form.Size = widthIndex == 0 ? new Size(820, 490) : new Size(1100, 730);
            foreach (int index in new[] { 2, 3 })
            {
                tabs.SelectedIndex = index;
                Application.DoEvents();
                if (index == 2) { customers.SelectedIndex = 0; catalog.SelectedIndex = 0; }
                else { grid.CurrentCell = grid.Rows[1].Cells[0]; grid.Rows[1].Selected = true; }
                using var bitmap = new Bitmap(form.Width, form.Height);
                form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
                bitmap.Save($"tmp/lab3/window-{form.Width}-{index}.png");
                if (index == 2)
                    Check(Field<Button>(carts, "ClearCartButton").Right <= Field<TableLayoutPanel>(carts, "ButtonsLayout").Width && catalog.Width > 100, "Carts layout clipped");
                else
                    Check(grid.Width > 100 && Field<AddressControl>(orders, "DeliveryAddressControl").Width >= 350, "Orders layout clipped");
                if (index == 3)
                {
                    var editor = Field<TableLayoutPanel>(orders, "EditorLayout");
                    var amount = Field<Label>(orders, "AmountLabel");
                    Check(amount.Bottom <= editor.ClientSize.Height && Field<ListBox>(orders, "OrderItemsListBox").Height > 30, "Order amount not visible at minimum size");
                }
            }
        }
        store.Customers.Clear();
        orders.RefreshData();
        Check(grid.Rows.Count == 0 && orders.Orders.Count == 0 && Field<TextBox>(orders, "IdTextBox").Text == "" && !status.Enabled, "Empty orders state");
    }
}
