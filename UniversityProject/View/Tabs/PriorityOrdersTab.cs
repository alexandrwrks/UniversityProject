using System.ComponentModel;
using UniversityProject.Model;

namespace UniversityProject.View.Tabs;

/// <summary>Учебный редактор одного приоритетного заказа для демонстрации наследования.</summary>
public partial class PriorityOrdersTab : UserControl
{
    /// <summary>Редактируемый приоритетный заказ.</summary>
    private PriorityOrder _order;
    /// <summary>Товары, из которых случайным образом выбирается добавляемый.</summary>
    private List<Item> _items = new();
    /// <summary>Подавляет обработчики во время отображения модели.</summary>
    private bool _loading;

    /// <summary>Общий каталог товаров для кнопки Add Item.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Item> Items
    {
        get => _items;
        set
        {
            _items = value ?? throw new ArgumentNullException(nameof(value));
            AddItemButton.Enabled = _items.Count > 0;
        }
    }

    /// <summary>Текущий учебный заказ; Clear Order заменяет этот объект новым.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PriorityOrder Order => _order;

    /// <summary>Создаёт редактор одного нового приоритетного заказа.</summary>
    public PriorityOrdersTab()
    {
        InitializeComponent();
        _order = new PriorityOrder();
        StatusComboBox.DataSource = Enum.GetValues<OrderStatus>();
        DeliveryTimeComboBox.DataSource = PriorityOrder.DeliveryTimes.ToArray();
        StatusComboBox.SelectedIndexChanged += (_, _) =>
        {
            if (!_loading && StatusComboBox.SelectedItem is OrderStatus status) _order.Status = status;
        };
        DeliveryTimeComboBox.SelectedIndexChanged += (_, _) =>
        {
            if (!_loading && DeliveryTimeComboBox.SelectedItem is string time) _order.DeliveryTime = time;
        };
        DeliveryDatePicker.ValueChanged += (_, _) =>
        {
            if (!_loading) _order.DeliveryDate = DeliveryDatePicker.Value;
        };
        OrderItemsListBox.SelectedIndexChanged += (_, _) => RemoveItemButton.Enabled = OrderItemsListBox.SelectedIndex >= 0;
        AddItemButton.Click += AddItemButton_Click;
        RemoveItemButton.Click += RemoveItemButton_Click;
        ClearOrderButton.Click += ClearOrderButton_Click;
        ShowOrder();
    }

    /// <summary>Отображает все поля текущего объекта и сбрасывает ошибки адреса.</summary>
    private void ShowOrder()
    {
        _loading = true;
        IdTextBox.Text = _order.Id.ToString();
        CreatedTextBox.Text = _order.CreationDate.ToString("g");
        StatusComboBox.SelectedItem = _order.Status;
        DeliveryTimeComboBox.SelectedItem = _order.DeliveryTime;
        DeliveryDatePicker.Value = _order.DeliveryDate;
        DeliveryAddressControl.Address = _order.Address;
        _loading = false;
        ShowItems();
    }

    /// <summary>Обновляет товары, сумму и выбор соседнего вхождения.</summary>
    private void ShowItems(int selectedIndex = -1)
    {
        OrderItemsListBox.Items.Clear();
        OrderItemsListBox.Items.AddRange(_order.Items.Cast<object>().ToArray());
        if (selectedIndex >= 0 && _order.Items.Count > 0)
            OrderItemsListBox.SelectedIndex = Math.Min(selectedIndex, _order.Items.Count - 1);
        AmountLabel.Text = _order.Amount.ToString("N2");
        RemoveItemButton.Enabled = OrderItemsListBox.SelectedIndex >= 0;
        AddItemButton.Enabled = _items.Count > 0;
    }

    /// <summary>Добавляет случайный существующий товар из каталога.</summary>
    private void AddItemButton_Click(object? sender, EventArgs e)
    {
        if (_items.Count == 0) return;
        _order.Items.Add(_items[Random.Shared.Next(_items.Count)]);
        ShowItems(_order.Items.Count - 1);
    }

    /// <summary>Удаляет выбранное вхождение; выбирает следующее или последнее.</summary>
    private void RemoveItemButton_Click(object? sender, EventArgs e)
    {
        int index = OrderItemsListBox.SelectedIndex;
        if (index < 0) return;
        _order.Items.RemoveAt(index);
        ShowItems(index);
    }

    /// <summary>Заменяет прежний объект заказа новым экземпляром.</summary>
    private void ClearOrderButton_Click(object? sender, EventArgs e)
    {
        _order = new PriorityOrder();
        ShowOrder();
    }
}
