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
        MinimumSize = new Size(820, 490);
        ItemsTabControl.Items = _store.Items;
        CustomersTabControl.Customers = _store.Customers;
    }
}
