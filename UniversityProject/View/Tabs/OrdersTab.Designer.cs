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
    /// <summary>Параметры доставки: HeaderLayout.</summary>
    private TableLayoutPanel HeaderLayout;
    /// <summary>Параметры доставки: CommonHeaderLayout.</summary>
    private TableLayoutPanel CommonHeaderLayout;
    /// <summary>Параметры доставки: PriorityOptionsPanel.</summary>
    private TableLayoutPanel PriorityOptionsPanel;
    /// <summary>Параметры доставки: PriorityOptionsLabel.</summary>
    private Label PriorityOptionsLabel;
    /// <summary>Параметры доставки: DeliveryTimeLabel.</summary>
    private Label DeliveryTimeLabel;
    /// <summary>Параметры доставки: DeliveryTimeComboBox.</summary>
    private ComboBox DeliveryTimeComboBox;
    /// <summary>Параметры доставки: DeliveryDateLabel.</summary>
    private Label DeliveryDateLabel;
    /// <summary>Параметры доставки: DeliveryDatePicker.</summary>
    private DateTimePicker DeliveryDatePicker;
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
        HeaderLayout = new TableLayoutPanel();
        HeaderLayout.Name = "HeaderLayout";
        CommonHeaderLayout = new TableLayoutPanel();
        CommonHeaderLayout.Name = "CommonHeaderLayout";
        PriorityOptionsPanel = new TableLayoutPanel();
        PriorityOptionsPanel.Name = "PriorityOptionsPanel";
        PriorityOptionsLabel = new Label();
        PriorityOptionsLabel.Name = "PriorityOptionsLabel";
        DeliveryTimeLabel = new Label();
        DeliveryTimeLabel.Name = "DeliveryTimeLabel";
        DeliveryTimeComboBox = new ComboBox();
        DeliveryTimeComboBox.Name = "DeliveryTimeComboBox";
        DeliveryDateLabel = new Label();
        DeliveryDateLabel.Name = "DeliveryDateLabel";
        DeliveryDatePicker = new DateTimePicker();
        DeliveryDatePicker.Name = "DeliveryDatePicker";
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
        EditorLayout.ColumnCount = 1;
        EditorLayout.RowCount = 6;
        EditorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 108));
        HeaderLayout.Dock = DockStyle.Fill;
        HeaderLayout.Margin = new Padding(0);
        HeaderLayout.ColumnCount = 2;
        HeaderLayout.RowCount = 1;
        HeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        HeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        HeaderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        CommonHeaderLayout.Dock = DockStyle.Fill;
        CommonHeaderLayout.Margin = new Padding(0);
        CommonHeaderLayout.ColumnCount = 2;
        CommonHeaderLayout.RowCount = 4;
        CommonHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60));
        CommonHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        CommonHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        CommonHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        CommonHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        CommonHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        SelectedOrderLabel.Text = "Selected Order";
        SelectedOrderLabel.AutoSize = true;
        SelectedOrderLabel.Anchor = AnchorStyles.Left;
        SelectedOrderLabel.Font = new Font(Font, FontStyle.Bold);
        CommonHeaderLayout.Controls.Add(SelectedOrderLabel, 0, 0);
        CommonHeaderLayout.SetColumnSpan(SelectedOrderLabel, 2);
        IdLabel.Text = "ID:";
        IdLabel.AutoSize = true;
        IdLabel.Anchor = AnchorStyles.Left;
        CreatedLabel.Text = "Created:";
        CreatedLabel.AutoSize = true;
        CreatedLabel.Anchor = AnchorStyles.Left;
        StatusLabel.Text = "Status:";
        StatusLabel.AutoSize = true;
        StatusLabel.Anchor = AnchorStyles.Left;
        IdTextBox.Dock = DockStyle.Fill;
        IdTextBox.ReadOnly = true;
        IdTextBox.TabStop = false;
        CreatedTextBox.Dock = DockStyle.Fill;
        CreatedTextBox.ReadOnly = true;
        CreatedTextBox.TabStop = false;
        StatusComboBox.Dock = DockStyle.Fill;
        StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        CommonHeaderLayout.Controls.Add(IdLabel, 0, 1);
        CommonHeaderLayout.Controls.Add(IdTextBox, 1, 1);
        CommonHeaderLayout.Controls.Add(CreatedLabel, 0, 2);
        CommonHeaderLayout.Controls.Add(CreatedTextBox, 1, 2);
        CommonHeaderLayout.Controls.Add(StatusLabel, 0, 3);
        CommonHeaderLayout.Controls.Add(StatusComboBox, 1, 3);
        PriorityOptionsPanel.Dock = DockStyle.Fill;
        PriorityOptionsPanel.Margin = new Padding(6, 0, 0, 0);
        PriorityOptionsPanel.ColumnCount = 2;
        PriorityOptionsPanel.RowCount = 4;
        PriorityOptionsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85));
        PriorityOptionsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        PriorityOptionsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        PriorityOptionsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        PriorityOptionsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        PriorityOptionsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        PriorityOptionsLabel.Text = "Priority Options";
        PriorityOptionsLabel.AutoSize = true;
        PriorityOptionsLabel.Anchor = AnchorStyles.Left;
        PriorityOptionsLabel.Font = new Font(Font, FontStyle.Bold);
        DeliveryTimeLabel.Text = "Delivery Time:";
        DeliveryTimeLabel.AutoSize = true;
        DeliveryTimeLabel.Margin = new Padding(0);
        DeliveryTimeLabel.Anchor = AnchorStyles.Left;
        DeliveryTimeComboBox.Dock = DockStyle.Fill;
        DeliveryTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        DeliveryDateLabel.Text = "Delivery Date:";
        DeliveryDateLabel.AutoSize = true;
        DeliveryDateLabel.Margin = new Padding(0);
        DeliveryDateLabel.Anchor = AnchorStyles.Left;
        DeliveryDatePicker.Dock = DockStyle.Fill;
        DeliveryDatePicker.Format = DateTimePickerFormat.Short;
        DeliveryDatePicker.MinDate = new DateTime(1753, 1, 1);
        DeliveryDatePicker.MaxDate = new DateTime(9998, 12, 31);
        PriorityOptionsPanel.Controls.Add(PriorityOptionsLabel, 0, 0);
        PriorityOptionsPanel.SetColumnSpan(PriorityOptionsLabel, 2);
        PriorityOptionsPanel.Controls.Add(DeliveryTimeLabel, 0, 1);
        PriorityOptionsPanel.Controls.Add(DeliveryTimeComboBox, 1, 1);
        PriorityOptionsPanel.Controls.Add(DeliveryDateLabel, 0, 2);
        PriorityOptionsPanel.Controls.Add(DeliveryDatePicker, 1, 2);
        HeaderLayout.Controls.Add(CommonHeaderLayout, 0, 0);
        HeaderLayout.Controls.Add(PriorityOptionsPanel, 1, 0);
        EditorLayout.Controls.Add(HeaderLayout, 0, 0);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 154));
        DeliveryAddressControl.Dock = DockStyle.Fill;
        EditorLayout.Controls.Add(DeliveryAddressControl, 0, 1);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        OrderItemsLabel.Text = "Order items";
        OrderItemsLabel.AutoSize = true;
        OrderItemsLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(OrderItemsLabel, 0, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        OrderItemsListBox.Dock = DockStyle.Fill;
        EditorLayout.Controls.Add(OrderItemsListBox, 0, 3);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
        AmountCaptionLabel.Text = "Amount:";
        AmountCaptionLabel.AutoSize = true;
        AmountCaptionLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(AmountCaptionLabel, 0, 4);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        AmountLabel.Text = "0.00";
        AmountLabel.AutoSize = true;
        AmountLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(AmountLabel, 0, 5);
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
