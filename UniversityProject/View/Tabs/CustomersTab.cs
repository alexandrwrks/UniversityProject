using System.ComponentModel;
using UniversityProject.Model;
using UniversityProject.View.Controls;

namespace UniversityProject.View.Tabs;

/// <summary>Просмотр и редактирование покупателей и адресов доставки.</summary>
public partial class CustomersTab : UserControl
{
    /// <summary>Подсказки ошибок ввода.</summary>
    private readonly ErrorProvider _errors;
    /// <summary>Отображаемая коллекция покупателей.</summary>
    private List<Customer> _customers = new();
    /// <summary>Подавляет обработку изменений при отображении модели.</summary>
    private bool _loading;

    /// <summary>Коллекция покупателей магазина.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Customer> Customers
    {
        get => _customers;
        set
        {
            _customers = value ?? throw new ArgumentNullException(nameof(value));
            RefreshCustomers();
            CustomersChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>Создаёт редактор покупателя со встроенным редактором адреса.</summary>
    public CustomersTab()
    {
        InitializeComponent();
        components ??= new Container();
        _errors = new ErrorProvider(components) { ContainerControl = this };
        CustomersListBox.SelectedIndexChanged += (_, _) => ShowCustomer();
        FullnameTextBox.TextChanged += (_, _) =>
        {
            if (_loading || CustomersListBox.SelectedItem is not Customer customer) return;
            if (InputValidation.Apply(FullnameTextBox, _errors, () => customer.Fullname = FullnameTextBox.Text))
            {
                _loading = true; ((CurrencyManager)BindingContext![_customers]!).Refresh(); CustomersListBox.SelectedItem = customer; _loading = false;
                CustomersChanged?.Invoke(this, EventArgs.Empty);
            }
        };
        IsPriorityCheckBox.CheckedChanged += (_, _) =>
        {
            if (!_loading && CustomersListBox.SelectedItem is Customer customer)
            {
                customer.IsPriority = IsPriorityCheckBox.Checked;
                CustomersChanged?.Invoke(this, EventArgs.Empty);
            }
        };
        InitializeDiscounts();
        ShowCustomer();
    }

    /// <summary>Обновляет список покупателей и выбор.</summary>
    private void RefreshCustomers(Customer? selected = null)
    {
        _loading = true; CustomersListBox.DataSource = null; CustomersListBox.DataSource = _customers;
        CustomersListBox.SelectedIndex = selected == null ? -1 : _customers.IndexOf(selected);
        _loading = false; ShowCustomer();
    }

    /// <summary>Показывает выбранного покупателя или отключает редакторы.</summary>
    private void ShowCustomer()
    {
        if (_loading) return;
        _loading = true;
        var customer = CustomersListBox.SelectedItem as Customer;
        IdTextBox.Text = customer?.Id.ToString() ?? string.Empty;
        FullnameTextBox.Text = customer?.Fullname ?? string.Empty;
        IsPriorityCheckBox.Checked = customer?.IsPriority ?? false;
        IsPriorityCheckBox.Enabled = customer != null;
        FullnameTextBox.Enabled = DeliveryAddressControl.Enabled = RemoveButton.Enabled = customer != null;
        FullnameTextBox.BackColor = SystemColors.Window; _errors.SetError(FullnameTextBox, string.Empty);
        if (_observedAddress != null) _observedAddress.AddressChanged -= Customer_AddressChanged;
        _observedAddress = customer?.Address;
        if (_observedAddress != null) _observedAddress.AddressChanged += Customer_AddressChanged;
        DeliveryAddressControl.Address = customer?.Address ?? new Address();
        _loading = false;
        ShowDiscounts();
    }

    /// <summary>Удаляет выбранного покупателя.</summary>
    private void RemoveButton_Click(object sender, EventArgs e)
    {
        if (CustomersListBox.SelectedItem is not Customer customer) return;
        int index = _customers.IndexOf(customer); _customers.Remove(customer);
        RefreshCustomers(_customers.Count == 0 ? null : _customers[Math.Min(index, _customers.Count - 1)]);
        CustomersChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>Создаёт покупателя с отдельным адресом.</summary>
    private void AddButton_Click(object sender, EventArgs e)
    {
        var customer = new Customer("Новый покупатель", new Address());
        _customers.Add(customer); RefreshCustomers(customer);
        CustomersChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>Изменение состава покупателей, их данных или скидок.</summary>
    public event EventHandler<EventArgs>? CustomersChanged;
    /// <summary>Адрес выбранного покупателя, подписка которого должна освобождаться.</summary>
    private Address? _observedAddress;

    /// <summary>Обновляет покупателей и скидки после оформления заказа.</summary>
    public void RefreshData() => RefreshCustomers(CustomersListBox.SelectedItem as Customer);

    /// <summary>Передаёт изменение адреса заинтересованным вкладкам.</summary>
    private void Customer_AddressChanged(object? sender, EventArgs e)
    {
        if (!_loading) CustomersChanged?.Invoke(this, EventArgs.Empty);
    }
}
