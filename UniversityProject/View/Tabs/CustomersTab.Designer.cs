namespace UniversityProject.View.Tabs;

partial class CustomersTab
{
    /// <summary>Контейнер компонентов формы.</summary>
    private System.ComponentModel.IContainer components = null;
    /// <summary>Основная компоновка вкладки.</summary>
    private TableLayoutPanel MainLayout;
    /// <summary>Список записей.</summary>
    private ListBox CustomersListBox;
    /// <summary>Кнопки управления списком.</summary>
    private FlowLayoutPanel ButtonsPanel;
    /// <summary>Добавление записи.</summary>
    private Button AddButton;
    /// <summary>Удаление записи.</summary>
    private Button RemoveButton;
    /// <summary>Прокручиваемая область редактора.</summary>
    private Panel EditorPanel;
    /// <summary>Поля выбранной записи.</summary>
    private TableLayoutPanel EditorLayout;
    /// <summary>Элемент ввода IdTextBox.</summary>
    private TextBox IdTextBox;
    /// <summary>Элемент ввода FullnameTextBox.</summary>
    private TextBox FullnameTextBox;
    /// <summary>Элемент ввода DeliveryAddressControl.</summary>
    private UniversityProject.View.Controls.AddressControl DeliveryAddressControl;

    /// <summary>Подпись SelectedCustomerLabel.</summary>
    private Label SelectedCustomerLabel;
    /// <summary>Подпись IdTextBoxLabel.</summary>
    private Label IdTextBoxLabel;
    /// <summary>Подпись FullnameTextBoxLabel.</summary>
    private Label FullnameTextBoxLabel;
    /// <summary>Подпись ListLabel.</summary>
    private Label ListLabel;

    /// <summary>Освобождает компоненты вкладки.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>Создаёт адаптивную компоновку и элементы редактора.</summary>
    private void InitializeComponent()
    {
        MainLayout = new TableLayoutPanel();
        ButtonsPanel = new FlowLayoutPanel();
        AddButton = new Button();
        RemoveButton = new Button();
        EditorPanel = new Panel();
        EditorLayout = new TableLayoutPanel();
        CustomersListBox = new ListBox();
        IdTextBox = new TextBox();
        FullnameTextBox = new TextBox();
        DeliveryAddressControl = new UniversityProject.View.Controls.AddressControl();
        SuspendLayout();
        MainLayout.SuspendLayout();
        EditorLayout.SuspendLayout();
        MainLayout.Dock = DockStyle.Fill;
        MainLayout.Padding = new Padding(8);
        MainLayout.ColumnCount = 2;
        MainLayout.RowCount = 3;
        MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
        MainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        MainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        ListLabel = new Label();
        ListLabel.Name = "ListLabel";
        ListLabel.Text = "Customers";
        ListLabel.AutoSize = true;
        ListLabel.Font = new Font(Font, FontStyle.Bold);
        MainLayout.Controls.Add(ListLabel, 0, 0);
        CustomersListBox.Name = "CustomersListBox";
        CustomersListBox.Dock = DockStyle.Fill;
        CustomersListBox.IntegralHeight = false;
        CustomersListBox.HorizontalScrollbar = true;
        CustomersListBox.TabIndex = 0;
        MainLayout.Controls.Add(CustomersListBox, 0, 1);
        ButtonsPanel.Dock = DockStyle.Fill;
        ButtonsPanel.WrapContents = false;
        AddButton.Name = "AddButton";
        AddButton.Text = "Add";
        AddButton.Size = new Size(90, 30);
        AddButton.TabIndex = 0;
        AddButton.Click += AddButton_Click;
        RemoveButton.Name = "RemoveButton";
        RemoveButton.Text = "Remove";
        RemoveButton.Size = new Size(90, 30);
        RemoveButton.TabIndex = 1;
        RemoveButton.Click += RemoveButton_Click;
        ButtonsPanel.Controls.Add(AddButton);
        ButtonsPanel.Controls.Add(RemoveButton);
        MainLayout.Controls.Add(ButtonsPanel, 0, 2);
        EditorPanel.Dock = DockStyle.Fill;
        EditorPanel.AutoScroll = true;
        EditorPanel.Padding = new Padding(12, 0, 0, 0);
        MainLayout.Controls.Add(EditorPanel, 1, 0);
        MainLayout.SetRowSpan(EditorPanel, 3);
        EditorLayout.Dock = DockStyle.Top;
        EditorLayout.AutoSize = true;
        EditorLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        EditorLayout.ColumnCount = 2;
        EditorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72));
        EditorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        EditorLayout.RowCount = 4;
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        SelectedCustomerLabel = new Label();
        SelectedCustomerLabel.Name = "SelectedCustomerLabel";
        SelectedCustomerLabel.Text = "Selected Customer";
        SelectedCustomerLabel.AutoSize = true;
        SelectedCustomerLabel.Font = new Font(Font, FontStyle.Bold);
        SelectedCustomerLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(SelectedCustomerLabel, 0, 0);
        EditorLayout.SetColumnSpan(SelectedCustomerLabel, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        IdTextBoxLabel = new Label();
        IdTextBoxLabel.Name = "IdTextBoxLabel";
        IdTextBoxLabel.Text = "Id:";
        IdTextBoxLabel.AutoSize = true;
        IdTextBoxLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(IdTextBoxLabel, 0, 1);
        IdTextBox.Name = "IdTextBox";
        IdTextBox.Anchor = AnchorStyles.Left;
        IdTextBox.Width = 100;
        IdTextBox.TabIndex = 1;
        IdTextBox.Margin = new Padding(3, 3, 24, 3);
        EditorLayout.Controls.Add(IdTextBox, 1, 1);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        FullnameTextBoxLabel = new Label();
        FullnameTextBoxLabel.Name = "FullnameTextBoxLabel";
        FullnameTextBoxLabel.Text = "Full Name:";
        FullnameTextBoxLabel.AutoSize = true;
        FullnameTextBoxLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(FullnameTextBoxLabel, 0, 2);
        FullnameTextBox.Name = "FullnameTextBox";
        FullnameTextBox.Dock = DockStyle.Fill;
        FullnameTextBox.TabIndex = 2;
        FullnameTextBox.Margin = new Padding(3, 3, 24, 3);
        EditorLayout.Controls.Add(FullnameTextBox, 1, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 156));
        DeliveryAddressControl.Name = "DeliveryAddressControl";
        DeliveryAddressControl.Dock = DockStyle.Fill;
        DeliveryAddressControl.TabIndex = 3;
        DeliveryAddressControl.Margin = new Padding(0, 8, 4, 0);
        EditorLayout.Controls.Add(DeliveryAddressControl, 0, 3);
        EditorLayout.SetColumnSpan(DeliveryAddressControl, 2);
        IdTextBox.ReadOnly = true;
        IdTextBox.TabStop = false;
        IdTextBox.BackColor = SystemColors.Control;
        EditorPanel.Controls.Add(EditorLayout);
        Controls.Add(MainLayout);
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "CustomersTab";
        Size = new Size(800, 450);
        EditorLayout.ResumeLayout(false);
        EditorLayout.PerformLayout();
        MainLayout.ResumeLayout(false);
        MainLayout.PerformLayout();
        ResumeLayout(false);
    }
}
