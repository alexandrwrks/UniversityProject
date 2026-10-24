using System.ComponentModel;
using UniversityProject.Model;

namespace UniversityProject.View.Tabs;

/// <summary>Выбор товаров, работа с корзинами и оформление заказов.</summary>
public partial class CartsTab : UserControl
{
    /// <summary>Каталог товаров магазина.</summary>
    private List<Item> _items = new();
    /// <summary>Покупатели магазина.</summary>
    private List<Customer> _customers = new();
    /// <summary>Подавляет события во время заполнения списков.</summary>
    private bool _loading;

    /// <summary>Общий список товаров Store.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Item> Items
    {
        get => _items;
        set { _items = value ?? throw new ArgumentNullException(nameof(value)); RefreshData(); }
    }
    /// <summary>Общий список покупателей Store.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Customer> Customers
    {
        get => _customers;
        set { _customers = value ?? throw new ArgumentNullException(nameof(value)); RefreshData(); }
    }
    /// <summary>Выбранный покупатель либо null, если выбор отсутствует.</summary>
    private Customer? CurrentCustomer { get; set; }

    /// <summary>Создаёт элементы и обработчики корзины.</summary>
    public CartsTab()
    {
        InitializeComponent();
        CustomersComboBox.SelectedIndexChanged += (_, _) =>
        {
            if (_loading) return;
            CurrentCustomer = CustomersComboBox.SelectedItem as Customer;
            ShowCart();
        };
        ItemsListBox.SelectedIndexChanged += (_, _) => UpdateButtons();
        CartListBox.SelectedIndexChanged += (_, _) => UpdateButtons();
        AddToCartButton.Click += AddToCartButton_Click;
        RemoveItemButton.Click += RemoveItemButton_Click;
        ClearCartButton.Click += ClearCartButton_Click;
        CreateOrderButton.Click += CreateOrderButton_Click;
        RefreshData();
    }

    /// <summary>Заново отображает данные, сохраняя существующий выбор по ссылке.</summary>
    public void RefreshData()
    {
        var selectedItem = ItemsListBox.SelectedItem as Item;
        var customer = CurrentCustomer;
        _loading = true;
        ItemsListBox.Items.Clear();
        ItemsListBox.Items.AddRange(_items.Cast<object>().ToArray());
        ItemsListBox.SelectedItem = selectedItem;
        CustomersComboBox.Items.Clear();
        CustomersComboBox.Items.AddRange(_customers.Cast<object>().ToArray());
        CurrentCustomer = customer != null && _customers.Contains(customer) ? customer : null;
        CustomersComboBox.SelectedItem = CurrentCustomer;
        _loading = false;
        ShowCart();
    }

    /// <summary>Обновляет содержимое корзины и общую стоимость.</summary>
    private void ShowCart(int selectedIndex = -1)
    {
        CartListBox.Items.Clear();
        if (CurrentCustomer != null)
            CartListBox.Items.AddRange(CurrentCustomer.Cart.Items.Cast<object>().ToArray());
        if (selectedIndex >= 0 && CartListBox.Items.Count > 0)
            CartListBox.SelectedIndex = Math.Min(selectedIndex, CartListBox.Items.Count - 1);
        AmountLabel.Text = (CurrentCustomer?.Cart.Amount ?? 0).ToString("N2");
        UpdateButtons();
    }

    /// <summary>Блокирует действия без покупателя, товара или наполненной корзины.</summary>
    private void UpdateButtons()
    {
        bool hasCustomer = CurrentCustomer != null;
        bool hasItems = hasCustomer && CurrentCustomer!.Cart.Items.Count > 0;
        AddToCartButton.Enabled = hasCustomer && ItemsListBox.SelectedItem is Item;
        RemoveItemButton.Enabled = hasCustomer && CartListBox.SelectedIndex >= 0;
        ClearCartButton.Enabled = CreateOrderButton.Enabled = hasItems;
    }

    /// <summary>Добавляет ссылку на выбранный товар в корзину.</summary>
    private void AddToCartButton_Click(object? sender, EventArgs e)
    {
        if (CurrentCustomer == null || ItemsListBox.SelectedItem is not Item item) return;
        CurrentCustomer.Cart.Items.Add(item);
        ShowCart(CurrentCustomer.Cart.Items.Count - 1);
    }

    /// <summary>Удаляет только одно выбранное вхождение товара.</summary>
    private void RemoveItemButton_Click(object? sender, EventArgs e)
    {
        int index = CartListBox.SelectedIndex;
        if (CurrentCustomer == null || index < 0) return;
        CurrentCustomer.Cart.Items.RemoveAt(index);
        ShowCart(index);
    }

    /// <summary>Очищает корзину выбранного покупателя.</summary>
    private void ClearCartButton_Click(object? sender, EventArgs e)
    {
        if (CurrentCustomer == null) return;
        CurrentCustomer.Cart.Items.Clear();
        ShowCart();
    }

    /// <summary>Создаёт заказ до очистки корзины; товары продолжают существовать в каталоге.</summary>
    private void CreateOrderButton_Click(object? sender, EventArgs e)
    {
        if (CurrentCustomer == null || CurrentCustomer.Cart.Items.Count == 0) return;
        Order order = CurrentCustomer.IsPriority
            ? new PriorityOrder(CurrentCustomer.Address, CurrentCustomer.Cart.Items, DateTime.Today, PriorityOrder.DeliveryTimes[0])
            : new Order(CurrentCustomer.Address, CurrentCustomer.Cart.Items);
        CurrentCustomer.Orders.Add(order);
        CurrentCustomer.Cart.Items.Clear();
        ShowCart();
    }
}
