using UniversityProject.Model;

namespace UniversityProject;

/// <summary>Главное окно, владеющее данными магазина.</summary>
public partial class MainForm : Form
{
    /// <summary>Общее хранилище данных приложения.</summary>
    private readonly Store _store = new();

    /// <summary>Создаёт вкладки и передаёт им общие коллекции.</summary>
    public MainForm()
    {
        InitializeComponent();
        Text = "Object Oriented Practics";
        using var iconStream = typeof(MainForm).Assembly.GetManifestResourceStream("UniversityProject.View.Resources.Store.ico");
        if (iconStream != null)
        {
            using var icon = new Icon(iconStream);
            Icon = (Icon)icon.Clone();
        }
        ClientSize = new Size(1050, 650);
        MinimumSize = new Size(820, 490);
        ItemsTabControl.Items = _store.Items;
        CustomersTabControl.Customers = _store.Customers;
        CartsTabControl.Items = _store.Items;
        CartsTabControl.Customers = _store.Customers;
        OrdersTabControl.Customers = _store.Customers;
        ItemsTabControl.ItemsChanged += ItemsTab_ItemsChanged;
        CustomersTabControl.CustomersChanged += CustomersTab_CustomersChanged;
        CartsTabControl.OrderCreated += CartsTab_OrderCreated;
    }

    /// <summary>Немедленно обновляет каталог корзины и суммы существующих заказов.</summary>
    private void ItemsTab_ItemsChanged(object? sender, EventArgs e) => RefreshDependentTabs();

    /// <summary>Немедленно обновляет покупателей корзины и строки заказов.</summary>
    private void CustomersTab_CustomersChanged(object? sender, EventArgs e) => RefreshDependentTabs();

    /// <summary>Показывает созданный заказ и начисленные скидки покупателя.</summary>
    private void CartsTab_OrderCreated(object? sender, EventArgs e)
    {
        OrdersTabControl.RefreshData();
        CustomersTabControl.RefreshData();
    }

    /// <summary>Синхронизирует зависимые вкладки по событиям источников данных.</summary>
    private void RefreshDependentTabs()
    {
        CartsTabControl.RefreshData();
        OrdersTabControl.RefreshData();
    }
}
