namespace UniversityProject.View.Tabs;

partial class CartsTab
{
    /// <summary>Контейнер компонентов.</summary>
    private System.ComponentModel.IContainer components = null;
    /// <summary>Элемент интерфейса MainLayout.</summary>
    private TableLayoutPanel MainLayout;
    /// <summary>Элемент интерфейса CatalogLayout.</summary>
    private TableLayoutPanel CatalogLayout;
    /// <summary>Элемент интерфейса CartLayout.</summary>
    private TableLayoutPanel CartLayout;
    /// <summary>Элемент интерфейса CustomerLayout.</summary>
    private TableLayoutPanel CustomerLayout;
    /// <summary>Элемент интерфейса ButtonsLayout.</summary>
    private TableLayoutPanel ButtonsLayout;
    /// <summary>Элемент интерфейса ItemsListBox.</summary>
    private ListBox ItemsListBox;
    /// <summary>Элемент интерфейса CartListBox.</summary>
    private ListBox CartListBox;
    /// <summary>Элемент интерфейса CustomersComboBox.</summary>
    private ComboBox CustomersComboBox;
    /// <summary>Элемент интерфейса ItemsLabel.</summary>
    private Label ItemsLabel;
    /// <summary>Элемент интерфейса CustomerLabel.</summary>
    private Label CustomerLabel;
    /// <summary>Элемент интерфейса CartLabel.</summary>
    private Label CartLabel;
    /// <summary>Элемент интерфейса AmountCaptionLabel.</summary>
    private Label AmountCaptionLabel;
    /// <summary>Элемент интерфейса AmountLabel.</summary>
    private Label AmountLabel;
    /// <summary>Элемент интерфейса AddToCartButton.</summary>
    private Button AddToCartButton;
    /// <summary>Элемент интерфейса CreateOrderButton.</summary>
    private Button CreateOrderButton;
    /// <summary>Элемент интерфейса RemoveItemButton.</summary>
    private Button RemoveItemButton;
    /// <summary>Элемент интерфейса ClearCartButton.</summary>
    private Button ClearCartButton;
    /// <summary>Освобождает ресурсы вкладки.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>Создаёт элементы по макету третьей лабораторной.</summary>
    private void InitializeComponent()
    {
        MainLayout = new TableLayoutPanel();
        MainLayout.Name = "MainLayout";
        CatalogLayout = new TableLayoutPanel();
        CatalogLayout.Name = "CatalogLayout";
        CartLayout = new TableLayoutPanel();
        CartLayout.Name = "CartLayout";
        CustomerLayout = new TableLayoutPanel();
        CustomerLayout.Name = "CustomerLayout";
        ButtonsLayout = new TableLayoutPanel();
        ButtonsLayout.Name = "ButtonsLayout";
        ItemsListBox = new ListBox();
        ItemsListBox.Name = "ItemsListBox";
        CartListBox = new ListBox();
        CartListBox.Name = "CartListBox";
        CustomersComboBox = new ComboBox();
        CustomersComboBox.Name = "CustomersComboBox";
        ItemsLabel = new Label();
        ItemsLabel.Name = "ItemsLabel";
        CustomerLabel = new Label();
        CustomerLabel.Name = "CustomerLabel";
        CartLabel = new Label();
        CartLabel.Name = "CartLabel";
        AmountCaptionLabel = new Label();
        AmountCaptionLabel.Name = "AmountCaptionLabel";
        AmountLabel = new Label();
        AmountLabel.Name = "AmountLabel";
        AddToCartButton = new Button();
        AddToCartButton.Name = "AddToCartButton";
        CreateOrderButton = new Button();
        CreateOrderButton.Name = "CreateOrderButton";
        RemoveItemButton = new Button();
        RemoveItemButton.Name = "RemoveItemButton";
        ClearCartButton = new Button();
        ClearCartButton.Name = "ClearCartButton";
        SuspendLayout();
        MainLayout.Dock = DockStyle.Fill;
        MainLayout.Padding = new Padding(8);
        MainLayout.ColumnCount = 2;
        MainLayout.RowCount = 1;
        MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
        MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        CatalogLayout.Dock = DockStyle.Fill;
        CatalogLayout.ColumnCount = 1;
        CatalogLayout.RowCount = 3;
        CatalogLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        CatalogLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        CatalogLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        CatalogLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        ItemsLabel.Text = "Items";
        ItemsLabel.AutoSize = true;
        ItemsLabel.Font = new Font(Font, FontStyle.Bold);
        ItemsListBox.Dock = DockStyle.Fill;
        ItemsListBox.IntegralHeight = false;
        ItemsListBox.HorizontalScrollbar = true;
        AddToCartButton.Text = "Add To Cart";
        AddToCartButton.Size = new Size(100, 30);
        CatalogLayout.Controls.Add(ItemsLabel, 0, 0);
        CatalogLayout.Controls.Add(ItemsListBox, 0, 1);
        CatalogLayout.Controls.Add(AddToCartButton, 0, 2);
        CartLayout.Dock = DockStyle.Fill;
        CartLayout.Padding = new Padding(8, 0, 0, 0);
        CartLayout.ColumnCount = 1;
        CartLayout.RowCount = 7;
        CartLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        CartLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        CartLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        CartLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 170));
        CartLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
        CartLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        CartLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        CartLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        CustomerLayout.Dock = DockStyle.Fill;
        CustomerLayout.Margin = new Padding(0);
        CustomerLayout.ColumnCount = 2;
        CustomerLayout.RowCount = 1;
        CustomerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85));
        CustomerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        CustomerLabel.Text = "Customer:";
        CustomerLabel.AutoSize = true;
        CustomerLabel.Anchor = AnchorStyles.Left;
        CustomerLabel.Font = new Font(Font, FontStyle.Bold);
        CustomersComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        CustomersComboBox.Dock = DockStyle.Fill;
        CustomerLayout.Controls.Add(CustomerLabel, 0, 0);
        CustomerLayout.Controls.Add(CustomersComboBox, 1, 0);
        CartLabel.Text = "Cart:";
        CartLabel.AutoSize = true;
        CartLabel.Anchor = AnchorStyles.Left;
        CartListBox.Dock = DockStyle.Fill;
        CartListBox.IntegralHeight = false;
        CartListBox.HorizontalScrollbar = true;
        AmountCaptionLabel.Text = "Amount:";
        AmountCaptionLabel.AutoSize = true;
        AmountCaptionLabel.Anchor = AnchorStyles.Right;
        AmountCaptionLabel.Font = new Font(Font, FontStyle.Bold);
        AmountLabel.Text = "0.00";
        AmountLabel.AutoSize = true;
        AmountLabel.Anchor = AnchorStyles.Right;
        AmountLabel.Font = new Font(Font.FontFamily, 14F, FontStyle.Bold);
        ButtonsLayout.Dock = DockStyle.Fill;
        ButtonsLayout.Margin = new Padding(0);
        ButtonsLayout.ColumnCount = 4;
        ButtonsLayout.RowCount = 1;
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        CreateOrderButton.Text = "Create Order";
        CreateOrderButton.Dock = DockStyle.Fill;
        RemoveItemButton.Text = "Remove Item";
        RemoveItemButton.Dock = DockStyle.Fill;
        ClearCartButton.Text = "Clear Cart";
        ClearCartButton.Dock = DockStyle.Fill;
        ButtonsLayout.Controls.Add(CreateOrderButton, 0, 0);
        ButtonsLayout.Controls.Add(RemoveItemButton, 2, 0);
        ButtonsLayout.Controls.Add(ClearCartButton, 3, 0);
        CartLayout.Controls.Add(CustomerLayout, 0, 0);
        CartLayout.Controls.Add(CartLabel, 0, 1);
        CartLayout.Controls.Add(CartListBox, 0, 2);
        CartLayout.Controls.Add(AmountCaptionLabel, 0, 3);
        CartLayout.Controls.Add(AmountLabel, 0, 4);
        CartLayout.Controls.Add(ButtonsLayout, 0, 5);
        MainLayout.Controls.Add(CatalogLayout, 0, 0);
        MainLayout.Controls.Add(CartLayout, 1, 0);
        Controls.Add(MainLayout);
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "CartsTab";
        Size = new Size(1000, 620);
        ResumeLayout(false);
    }
}
