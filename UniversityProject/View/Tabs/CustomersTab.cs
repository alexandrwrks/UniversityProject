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
        set { _customers = value ?? throw new ArgumentNullException(nameof(value)); RefreshCustomers(); }
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
            }
        };
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
        FullnameTextBox.Enabled = DeliveryAddressControl.Enabled = RemoveButton.Enabled = customer != null;
        FullnameTextBox.BackColor = SystemColors.Window; _errors.SetError(FullnameTextBox, string.Empty);
        DeliveryAddressControl.Address = customer?.Address ?? new Address();
        _loading = false;
    }

    /// <summary>Удаляет выбранного покупателя.</summary>
    private void RemoveButton_Click(object sender, EventArgs e)
    {
        if (CustomersListBox.SelectedItem is not Customer customer) return;
        int index = _customers.IndexOf(customer); _customers.Remove(customer);
        RefreshCustomers(_customers.Count == 0 ? null : _customers[Math.Min(index, _customers.Count - 1)]);
    }

    /// <summary>Создаёт покупателя с отдельным адресом.</summary>
    private void AddButton_Click(object sender, EventArgs e)
    {
        var customer = new Customer("Новый покупатель", new Address());
        _customers.Add(customer); RefreshCustomers(customer);
    }
}
