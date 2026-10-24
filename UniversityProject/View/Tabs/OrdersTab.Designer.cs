namespace UniversityProject.View.Tabs;

partial class OrdersTab
{
    /// <summary>Контейнер компонентов.</summary>
    private System.ComponentModel.IContainer components = null;
    /// <summary>Элемент интерфейса MainLayout.</summary>
    private TableLayoutPanel MainLayout;
    /// <summary>Элемент интерфейса OrdersLayout.</summary>
    private TableLayoutPanel OrdersLayout;
    /// <summary>Элемент интерфейса EditorLayout.</summary>
    private TableLayoutPanel EditorLayout;
    /// <summary>Элемент интерфейса EditorPanel.</summary>
    private Panel EditorPanel;
    /// <summary>Элемент интерфейса OrdersDataGridView.</summary>
    private DataGridView OrdersDataGridView;
    /// <summary>Элемент интерфейса IdTextBox.</summary>
    private TextBox IdTextBox;
    /// <summary>Элемент интерфейса CreatedTextBox.</summary>
    private TextBox CreatedTextBox;
    /// <summary>Элемент интерфейса StatusComboBox.</summary>
    private ComboBox StatusComboBox;
    /// <summary>Элемент интерфейса DeliveryAddressControl.</summary>
    private UniversityProject.View.Controls.AddressControl DeliveryAddressControl;
    /// <summary>Элемент интерфейса OrderItemsListBox.</summary>
    private ListBox OrderItemsListBox;
    /// <summary>Элемент интерфейса OrdersLabel.</summary>
    private Label OrdersLabel;
    /// <summary>Элемент интерфейса SelectedOrderLabel.</summary>
    private Label SelectedOrderLabel;
    /// <summary>Элемент интерфейса IdLabel.</summary>
    private Label IdLabel;
    /// <summary>Элемент интерфейса CreatedLabel.</summary>
    private Label CreatedLabel;
    /// <summary>Элемент интерфейса StatusLabel.</summary>
    private Label StatusLabel;
    /// <summary>Элемент интерфейса OrderItemsLabel.</summary>
    private Label OrderItemsLabel;
    /// <summary>Элемент интерфейса AmountCaptionLabel.</summary>
    private Label AmountCaptionLabel;
    /// <summary>Элемент интерфейса AmountLabel.</summary>
    private Label AmountLabel;
    /// <summary>Элемент интерфейса IdColumn.</summary>
    private DataGridViewTextBoxColumn IdColumn;
    /// <summary>Элемент интерфейса CreatedColumn.</summary>
    private DataGridViewTextBoxColumn CreatedColumn;
    /// <summary>Элемент интерфейса CustomerColumn.</summary>
    private DataGridViewTextBoxColumn CustomerColumn;
    /// <summary>Элемент интерфейса AddressColumn.</summary>
    private DataGridViewTextBoxColumn AddressColumn;
    /// <summary>Элемент интерфейса AmountColumn.</summary>
    private DataGridViewTextBoxColumn AmountColumn;
    /// <summary>Элемент интерфейса StatusColumn.</summary>
    private DataGridViewTextBoxColumn StatusColumn;
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
        OrdersLayout = new TableLayoutPanel();
        OrdersLayout.Name = "OrdersLayout";
        EditorLayout = new TableLayoutPanel();
        EditorLayout.Name = "EditorLayout";
        EditorPanel = new Panel();
        EditorPanel.Name = "EditorPanel";
        OrdersDataGridView = new DataGridView();
        OrdersDataGridView.Name = "OrdersDataGridView";
        IdTextBox = new TextBox();
        IdTextBox.Name = "IdTextBox";
        CreatedTextBox = new TextBox();
        CreatedTextBox.Name = "CreatedTextBox";
        StatusComboBox = new ComboBox();
        StatusComboBox.Name = "StatusComboBox";
        DeliveryAddressControl = new UniversityProject.View.Controls.AddressControl();
        DeliveryAddressControl.Name = "DeliveryAddressControl";
        OrderItemsListBox = new ListBox();
        OrderItemsListBox.Name = "OrderItemsListBox";
        OrdersLabel = new Label();
        OrdersLabel.Name = "OrdersLabel";
        SelectedOrderLabel = new Label();
        SelectedOrderLabel.Name = "SelectedOrderLabel";
        IdLabel = new Label();
        IdLabel.Name = "IdLabel";
        CreatedLabel = new Label();
        CreatedLabel.Name = "CreatedLabel";
        StatusLabel = new Label();
        StatusLabel.Name = "StatusLabel";
        OrderItemsLabel = new Label();
        OrderItemsLabel.Name = "OrderItemsLabel";
        AmountCaptionLabel = new Label();
        AmountCaptionLabel.Name = "AmountCaptionLabel";
        AmountLabel = new Label();
        AmountLabel.Name = "AmountLabel";
        IdColumn = new DataGridViewTextBoxColumn();
        IdColumn.Name = "IdColumn";
        CreatedColumn = new DataGridViewTextBoxColumn();
        CreatedColumn.Name = "CreatedColumn";
        CustomerColumn = new DataGridViewTextBoxColumn();
        CustomerColumn.Name = "CustomerColumn";
        AddressColumn = new DataGridViewTextBoxColumn();
        AddressColumn.Name = "AddressColumn";
        AmountColumn = new DataGridViewTextBoxColumn();
        AmountColumn.Name = "AmountColumn";
        StatusColumn = new DataGridViewTextBoxColumn();
        StatusColumn.Name = "StatusColumn";
        SuspendLayout();
        MainLayout.Dock = DockStyle.Fill;
        MainLayout.Padding = new Padding(8);
        MainLayout.ColumnCount = 2;
        MainLayout.RowCount = 1;
        MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        OrdersLayout.Dock = DockStyle.Fill;
        OrdersLayout.ColumnCount = 1;
        OrdersLayout.RowCount = 2;
        OrdersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        OrdersLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        OrdersLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        OrdersLabel.Text = "Orders";
        OrdersLabel.AutoSize = true;
        OrdersLabel.Font = new Font(Font, FontStyle.Bold);
        OrdersDataGridView.Dock = DockStyle.Fill;
        OrdersDataGridView.ReadOnly = true;
        OrdersDataGridView.MultiSelect = false;
        OrdersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        OrdersDataGridView.AllowUserToAddRows = false;
        OrdersDataGridView.AllowUserToDeleteRows = false;
        OrdersDataGridView.AllowUserToResizeRows = false;
        OrdersDataGridView.AllowUserToOrderColumns = false;
        OrdersDataGridView.AutoGenerateColumns = false;
        OrdersDataGridView.RowHeadersVisible = false;
        IdColumn.HeaderText = "Id";
        IdColumn.Width = 55;
        IdColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        OrdersDataGridView.Columns.Add(IdColumn);
        CreatedColumn.HeaderText = "Created";
        CreatedColumn.Width = 135;
        CreatedColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        CreatedColumn.DefaultCellStyle.Format = "g";
        OrdersDataGridView.Columns.Add(CreatedColumn);
        CustomerColumn.HeaderText = "Customer Full Name";
        CustomerColumn.Width = 170;
        CustomerColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        OrdersDataGridView.Columns.Add(CustomerColumn);
        AddressColumn.HeaderText = "Delivery Address";
        AddressColumn.Width = 250;
        AddressColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        OrdersDataGridView.Columns.Add(AddressColumn);
        AmountColumn.HeaderText = "Amount";
        AmountColumn.Width = 100;
        AmountColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        AmountColumn.DefaultCellStyle.Format = "N2";
        OrdersDataGridView.Columns.Add(AmountColumn);
        StatusColumn.HeaderText = "Order Status";
        StatusColumn.Width = 100;
        StatusColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        OrdersDataGridView.Columns.Add(StatusColumn);
        OrdersLayout.Controls.Add(OrdersLabel, 0, 0);
        OrdersLayout.Controls.Add(OrdersDataGridView, 0, 1);
        EditorPanel.Dock = DockStyle.Fill;
        EditorPanel.AutoScroll = true;
        EditorPanel.Padding = new Padding(8, 0, 0, 0);
        EditorLayout.Dock = DockStyle.Fill;
        EditorLayout.AutoSize = false;
        EditorLayout.MinimumSize = new Size(350, 390);
        EditorLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        EditorLayout.ColumnCount = 2;
        EditorLayout.RowCount = 9;
        EditorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72));
        EditorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        SelectedOrderLabel.Text = "Selected Order";
        SelectedOrderLabel.AutoSize = true;
        SelectedOrderLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(SelectedOrderLabel, 0, 0);
        EditorLayout.SetColumnSpan(SelectedOrderLabel, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        IdLabel.Text = "ID:";
        IdLabel.AutoSize = true;
        IdLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(IdLabel, 0, 1);
        IdTextBox.Anchor = AnchorStyles.Left;
        IdTextBox.Width = 140;
        EditorLayout.Controls.Add(IdTextBox, 1, 1);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        CreatedLabel.Text = "Created:";
        CreatedLabel.AutoSize = true;
        CreatedLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(CreatedLabel, 0, 2);
        CreatedTextBox.Anchor = AnchorStyles.Left;
        CreatedTextBox.Width = 170;
        EditorLayout.Controls.Add(CreatedTextBox, 1, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        StatusLabel.Text = "Status:";
        StatusLabel.AutoSize = true;
        StatusLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(StatusLabel, 0, 3);
        StatusComboBox.Anchor = AnchorStyles.Left;
        StatusComboBox.Width = 140;
        EditorLayout.Controls.Add(StatusComboBox, 1, 3);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 154));
        DeliveryAddressControl.Dock = DockStyle.Fill;
        EditorLayout.Controls.Add(DeliveryAddressControl, 0, 4);
        EditorLayout.SetColumnSpan(DeliveryAddressControl, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        OrderItemsLabel.Text = "Order items";
        OrderItemsLabel.AutoSize = true;
        OrderItemsLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(OrderItemsLabel, 0, 5);
        EditorLayout.SetColumnSpan(OrderItemsLabel, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        OrderItemsListBox.Dock = DockStyle.Fill;
        EditorLayout.Controls.Add(OrderItemsListBox, 0, 6);
        EditorLayout.SetColumnSpan(OrderItemsListBox, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
        AmountCaptionLabel.Text = "Amount:";
        AmountCaptionLabel.AutoSize = true;
        AmountCaptionLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(AmountCaptionLabel, 0, 7);
        EditorLayout.SetColumnSpan(AmountCaptionLabel, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        AmountLabel.Text = "0.00";
        AmountLabel.AutoSize = true;
        AmountLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(AmountLabel, 0, 8);
        EditorLayout.SetColumnSpan(AmountLabel, 2);
        SelectedOrderLabel.Font = new Font(Font, FontStyle.Bold);
        OrderItemsLabel.Font = new Font(Font, FontStyle.Bold);
        AmountCaptionLabel.Font = new Font(Font, FontStyle.Bold);
        AmountCaptionLabel.Anchor = AnchorStyles.Right;
        AmountLabel.Font = new Font(Font.FontFamily, 14F, FontStyle.Bold);
        AmountLabel.Anchor = AnchorStyles.Right;
        IdTextBox.ReadOnly = true;
        CreatedTextBox.ReadOnly = true;
        IdTextBox.TabStop = false;
        CreatedTextBox.TabStop = false;
        StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        OrderItemsListBox.IntegralHeight = false;
        OrderItemsListBox.HorizontalScrollbar = true;
        EditorPanel.Controls.Add(EditorLayout);
        MainLayout.Controls.Add(OrdersLayout, 0, 0);
        MainLayout.Controls.Add(EditorPanel, 1, 0);
        Controls.Add(MainLayout);
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "OrdersTab";
        Size = new Size(1000, 620);
        ResumeLayout(false);
    }
}
