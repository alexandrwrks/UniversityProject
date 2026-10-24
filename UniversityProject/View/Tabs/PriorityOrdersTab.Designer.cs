namespace UniversityProject.View.Tabs;

partial class PriorityOrdersTab
{
    /// <summary>Элемент учебного редактора HeaderLayout.</summary>
    private TableLayoutPanel HeaderLayout;
    /// <summary>Элемент учебного редактора CommonHeaderLayout.</summary>
    private TableLayoutPanel CommonHeaderLayout;
    /// <summary>Элемент учебного редактора PriorityOptionsPanel.</summary>
    private TableLayoutPanel PriorityOptionsPanel;
    /// <summary>Элемент учебного редактора PriorityOptionsLabel.</summary>
    private Label PriorityOptionsLabel;
    /// <summary>Элемент учебного редактора DeliveryTimeLabel.</summary>
    private Label DeliveryTimeLabel;
    /// <summary>Элемент учебного редактора DeliveryTimeComboBox.</summary>
    private ComboBox DeliveryTimeComboBox;
    /// <summary>Элемент учебного редактора DeliveryDateLabel.</summary>
    private Label DeliveryDateLabel;
    /// <summary>Элемент учебного редактора DeliveryDatePicker.</summary>
    private DateTimePicker DeliveryDatePicker;
    /// <summary>Элемент учебного редактора EditorLayout.</summary>
    private TableLayoutPanel EditorLayout;
    /// <summary>Элемент учебного редактора ButtonsLayout.</summary>
    private TableLayoutPanel ButtonsLayout;
    /// <summary>Элемент учебного редактора ScrollPanel.</summary>
    private Panel ScrollPanel;
    /// <summary>Элемент учебного редактора SelectedOrderLabel.</summary>
    private Label SelectedOrderLabel;
    /// <summary>Элемент учебного редактора IdLabel.</summary>
    private Label IdLabel;
    /// <summary>Элемент учебного редактора CreatedLabel.</summary>
    private Label CreatedLabel;
    /// <summary>Элемент учебного редактора StatusLabel.</summary>
    private Label StatusLabel;
    /// <summary>Элемент учебного редактора OrderItemsLabel.</summary>
    private Label OrderItemsLabel;
    /// <summary>Элемент учебного редактора AmountCaptionLabel.</summary>
    private Label AmountCaptionLabel;
    /// <summary>Элемент учебного редактора AmountLabel.</summary>
    private Label AmountLabel;
    /// <summary>Элемент учебного редактора IdTextBox.</summary>
    private TextBox IdTextBox;
    /// <summary>Элемент учебного редактора CreatedTextBox.</summary>
    private TextBox CreatedTextBox;
    /// <summary>Элемент учебного редактора StatusComboBox.</summary>
    private ComboBox StatusComboBox;
    /// <summary>Элемент учебного редактора DeliveryAddressControl.</summary>
    private UniversityProject.View.Controls.AddressControl DeliveryAddressControl;
    /// <summary>Элемент учебного редактора OrderItemsListBox.</summary>
    private ListBox OrderItemsListBox;
    /// <summary>Элемент учебного редактора AddItemButton.</summary>
    private Button AddItemButton;
    /// <summary>Элемент учебного редактора RemoveItemButton.</summary>
    private Button RemoveItemButton;
    /// <summary>Элемент учебного редактора ClearOrderButton.</summary>
    private Button ClearOrderButton;

    /// <summary>Создаёт учебный редактор по макету четвёртой лабораторной.</summary>
    private void InitializeComponent()
    {
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
        EditorLayout = new TableLayoutPanel();
        EditorLayout.Name = "EditorLayout";
        ButtonsLayout = new TableLayoutPanel();
        ButtonsLayout.Name = "ButtonsLayout";
        ScrollPanel = new Panel();
        ScrollPanel.Name = "ScrollPanel";
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
        AddItemButton = new Button();
        AddItemButton.Name = "AddItemButton";
        RemoveItemButton = new Button();
        RemoveItemButton.Name = "RemoveItemButton";
        ClearOrderButton = new Button();
        ClearOrderButton.Name = "ClearOrderButton";
        SuspendLayout();
        ScrollPanel.Dock = DockStyle.Fill;
        ScrollPanel.AutoScroll = true;
        ScrollPanel.Padding = new Padding(12);
        EditorLayout.Dock = DockStyle.Fill;
        EditorLayout.MinimumSize = new Size(440, 440);
        EditorLayout.ColumnCount = 1;
        EditorLayout.RowCount = 7;
        EditorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 108));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 154));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
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
        DeliveryAddressControl.Dock = DockStyle.Fill;
        OrderItemsLabel.Text = "Order items";
        OrderItemsLabel.Font = new Font(Font, FontStyle.Bold);
        OrderItemsLabel.AutoSize = true;
        OrderItemsLabel.Anchor = AnchorStyles.Left;
        OrderItemsListBox.Dock = DockStyle.Fill;
        OrderItemsListBox.IntegralHeight = false;
        OrderItemsListBox.HorizontalScrollbar = true;
        AmountCaptionLabel.Text = "Amount:";
        AmountCaptionLabel.AutoSize = true;
        AmountCaptionLabel.Font = new Font(Font, FontStyle.Bold);
        AmountCaptionLabel.Anchor = AnchorStyles.Right;
        AmountLabel.Text = "0.00";
        AmountLabel.AutoSize = true;
        AmountLabel.Font = new Font(Font.FontFamily, 14F, FontStyle.Bold);
        AmountLabel.Anchor = AnchorStyles.Right;
        ButtonsLayout.Dock = DockStyle.Fill;
        ButtonsLayout.Margin = new Padding(0);
        ButtonsLayout.ColumnCount = 4;
        ButtonsLayout.RowCount = 1;
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        ButtonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
        AddItemButton.Text = "Add Item";
        AddItemButton.Dock = DockStyle.Fill;
        RemoveItemButton.Text = "Remove Item";
        RemoveItemButton.Dock = DockStyle.Fill;
        ClearOrderButton.Text = "Clear Order";
        ClearOrderButton.Dock = DockStyle.Fill;
        ButtonsLayout.Controls.Add(AddItemButton, 0, 0);
        ButtonsLayout.Controls.Add(RemoveItemButton, 1, 0);
        ButtonsLayout.Controls.Add(ClearOrderButton, 3, 0);
        EditorLayout.Controls.Add(HeaderLayout, 0, 0);
        EditorLayout.Controls.Add(DeliveryAddressControl, 0, 1);
        EditorLayout.Controls.Add(OrderItemsLabel, 0, 2);
        EditorLayout.Controls.Add(OrderItemsListBox, 0, 3);
        EditorLayout.Controls.Add(AmountCaptionLabel, 0, 4);
        EditorLayout.Controls.Add(AmountLabel, 0, 5);
        EditorLayout.Controls.Add(ButtonsLayout, 0, 6);
        ScrollPanel.Controls.Add(EditorLayout);
        Controls.Add(ScrollPanel);
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "PriorityOrdersTab";
        Size = new Size(700, 620);
        ResumeLayout(false);
    }
}
