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
        MainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
    }

    /// <summary>Обновляет зависимые вкладки только при переходе на них.</summary>
    private void MainTabControl_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (MainTabControl.SelectedTab == CartsTabPage) CartsTabControl.RefreshData();
        else if (MainTabControl.SelectedTab == OrdersTabPage) OrdersTabControl.RefreshData();
    }
}
