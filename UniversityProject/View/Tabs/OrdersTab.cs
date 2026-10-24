using System.ComponentModel;
using UniversityProject.Model;

namespace UniversityProject.View.Tabs;

/// <summary>Сводная таблица заказов и просмотр выбранного заказа.</summary>
public partial class OrdersTab : UserControl
{
    /// <summary>Покупатели, чьи заказы показываются в таблице.</summary>
    private List<Customer> _customers = new();
    /// <summary>Подавляет обработку выбора при заполнении редакторов.</summary>
    private bool _loading;

    /// <summary>Выбранный заказ через ссылку базового класса.</summary>
    private Order? _selectedOrder;
    /// <summary>Тот же объект через ссылку дочернего класса, если заказ приоритетный.</summary>
    private PriorityOrder? _selectedPriorityOrder;

    /// <summary>Общий список покупателей Store.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Customer> Customers
    {
        get => _customers;
        set { _customers = value ?? throw new ArgumentNullException(nameof(value)); RefreshData(); }
    }
    /// <summary>Объединённый список заказов всех покупателей.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Order> Orders { get; private set; } = new();
    /// <summary>Заказ выбранной строки; привязка по объекту, а не по индексу строки.</summary>
    private Order? CurrentOrder => OrdersDataGridView.CurrentRow is { Selected: true, Tag: Order order }
        ? order
        : null;

    /// <summary>Создаёт таблицу и панель просмотра заказа.</summary>
    public OrdersTab()
    {
        InitializeComponent();
        StatusComboBox.DataSource = Enum.GetValues<OrderStatus>();
        DeliveryTimeComboBox.DataSource = PriorityOrder.DeliveryTimes.ToArray();
        DeliveryTimeComboBox.SelectedIndexChanged += (_, _) =>
        {
            if (!_loading && _selectedPriorityOrder != null && ReferenceEquals(CurrentOrder, _selectedPriorityOrder)
                && DeliveryTimeComboBox.SelectedItem is string time)
                _selectedPriorityOrder.DeliveryTime = time;
        };
        DeliveryDatePicker.ValueChanged += (_, _) =>
        {
            if (!_loading && _selectedPriorityOrder != null && ReferenceEquals(CurrentOrder, _selectedPriorityOrder))
                _selectedPriorityOrder.DeliveryDate = DeliveryDatePicker.Value;
        };
        DeliveryAddressControl.ReadOnly = true;
        OrdersDataGridView.CurrentCellChanged += (_, _) => { if (!_loading) ShowOrder(); };
        OrdersDataGridView.SelectionChanged += (_, _) => { if (!_loading) ShowOrder(); };
        StatusComboBox.SelectedIndexChanged += (_, _) =>
        {
            if (_loading || CurrentOrder is not Order order || StatusComboBox.SelectedItem is not OrderStatus status) return;
            order.Status = status;
            OrdersDataGridView.CurrentRow!.Cells[5].Value = status;
        };
        RefreshData();
    }

    /// <summary>Обновляет список заказов и строки таблицы.</summary>
    public void UpdateOrders()
    {
        Order? selected = CurrentOrder;
        _loading = true;
        Orders = _customers.SelectMany(customer => customer.Orders).ToList();
        OrdersDataGridView.Rows.Clear();
        foreach (Customer customer in _customers)
        {
            foreach (Order order in customer.Orders)
            {
                int index = OrdersDataGridView.Rows.Add(order.Id, order.CreationDate, customer.Fullname, order.Address.ToString(), order.Amount, order.Status);
                OrdersDataGridView.Rows[index].Tag = order;
            }
        }
        OrdersDataGridView.ClearSelection();
        OrdersDataGridView.CurrentCell = null;
        if (selected != null)
        {
            foreach (DataGridViewRow row in OrdersDataGridView.Rows)
                if (ReferenceEquals(row.Tag, selected))
                {
                    OrdersDataGridView.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    break;
                }
        }
        _loading = false;
        ShowOrder();
    }

    /// <summary>Обновляет данные при переходе на вкладку.</summary>
    public void RefreshData() => UpdateOrders();

    /// <summary>Показывает заказ только для чтения, разрешая менять лишь статус.</summary>
    private void ShowOrder()
    {
        _loading = true;
        _selectedOrder = CurrentOrder;
        _selectedPriorityOrder = _selectedOrder as PriorityOrder;
        Order? order = _selectedOrder;
        PriorityOptionsPanel.Visible = _selectedPriorityOrder != null;
        DeliveryTimeComboBox.SelectedItem = _selectedPriorityOrder?.DeliveryTime;
        DeliveryDatePicker.Value = _selectedPriorityOrder?.DeliveryDate ?? DateTime.Today;
        IdTextBox.Text = order?.Id.ToString() ?? string.Empty;
        CreatedTextBox.Text = order?.CreationDate.ToString("g") ?? string.Empty;
        StatusComboBox.SelectedItem = order?.Status;
        StatusComboBox.Enabled = order != null;
        DeliveryAddressControl.Visible = order != null;
        DeliveryAddressControl.Address = order?.Address ?? new Address();
        OrderItemsListBox.Items.Clear();
        if (order != null) OrderItemsListBox.Items.AddRange(order.Items.Cast<object>().ToArray());
        AmountLabel.Text = (order?.Amount ?? 0).ToString("N2");
        _loading = false;
    }
}
