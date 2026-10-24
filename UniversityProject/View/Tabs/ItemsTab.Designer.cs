namespace UniversityProject.View.Tabs;

partial class ItemsTab
{
    /// <summary>Контейнер компонентов формы.</summary>
    private System.ComponentModel.IContainer components = null;
    /// <summary>Основная компоновка вкладки.</summary>
    private TableLayoutPanel MainLayout;
    /// <summary>Список записей.</summary>
    private ListBox ItemsListBox;
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
    /// <summary>Элемент ввода CostTextBox.</summary>
    private TextBox CostTextBox;
    /// <summary>Элемент ввода CategoryComboBox.</summary>
    private ComboBox CategoryComboBox;
    /// <summary>Элемент ввода NameTextBox.</summary>
    private TextBox NameTextBox;
    /// <summary>Элемент ввода DescriptionTextBox.</summary>
    private TextBox DescriptionTextBox;

    /// <summary>Подпись SelectedItemLabel.</summary>
    private Label SelectedItemLabel;
    /// <summary>Подпись IdTextBoxLabel.</summary>
    private Label IdTextBoxLabel;
    /// <summary>Подпись CostTextBoxLabel.</summary>
    private Label CostTextBoxLabel;
    /// <summary>Подпись CategoryComboBoxLabel.</summary>
    private Label CategoryComboBoxLabel;
    /// <summary>Подпись NameLabel.</summary>
    private Label NameLabel;
    /// <summary>Подпись DescriptionLabel.</summary>
    private Label DescriptionLabel;
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
        ItemsListBox = new ListBox();
        IdTextBox = new TextBox();
        CostTextBox = new TextBox();
        CategoryComboBox = new ComboBox();
        NameTextBox = new TextBox();
        DescriptionTextBox = new TextBox();
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
        ListLabel.Text = "Items";
        ListLabel.AutoSize = true;
        ListLabel.Font = new Font(Font, FontStyle.Bold);
        MainLayout.Controls.Add(ListLabel, 0, 0);
        ItemsListBox.Name = "ItemsListBox";
        ItemsListBox.Dock = DockStyle.Fill;
        ItemsListBox.IntegralHeight = false;
        ItemsListBox.HorizontalScrollbar = true;
        ItemsListBox.TabIndex = 0;
        MainLayout.Controls.Add(ItemsListBox, 0, 1);
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
        EditorLayout.RowCount = 8;
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        SelectedItemLabel = new Label();
        SelectedItemLabel.Name = "SelectedItemLabel";
        SelectedItemLabel.Text = "Selected Item";
        SelectedItemLabel.AutoSize = true;
        SelectedItemLabel.Font = new Font(Font, FontStyle.Bold);
        SelectedItemLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(SelectedItemLabel, 0, 0);
        EditorLayout.SetColumnSpan(SelectedItemLabel, 2);
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
        CostTextBoxLabel = new Label();
        CostTextBoxLabel.Name = "CostTextBoxLabel";
        CostTextBoxLabel.Text = "Cost:";
        CostTextBoxLabel.AutoSize = true;
        CostTextBoxLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(CostTextBoxLabel, 0, 2);
        CostTextBox.Name = "CostTextBox";
        CostTextBox.Anchor = AnchorStyles.Left;
        CostTextBox.Width = 140;
        CostTextBox.TabIndex = 2;
        CostTextBox.Margin = new Padding(3, 3, 24, 3);
        EditorLayout.Controls.Add(CostTextBox, 1, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        CategoryComboBoxLabel = new Label();
        CategoryComboBoxLabel.Name = "CategoryComboBoxLabel";
        CategoryComboBoxLabel.Text = "Category:";
        CategoryComboBoxLabel.AutoSize = true;
        CategoryComboBoxLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(CategoryComboBoxLabel, 0, 3);
        CategoryComboBox.Name = "CategoryComboBox";
        CategoryComboBox.Anchor = AnchorStyles.Left;
        CategoryComboBox.Width = 140;
        CategoryComboBox.TabIndex = 3;
        CategoryComboBox.Margin = new Padding(3, 3, 24, 3);
        EditorLayout.Controls.Add(CategoryComboBox, 1, 3);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        NameLabel = new Label();
        NameLabel.Name = "NameLabel";
        NameLabel.Text = "Name:";
        NameLabel.AutoSize = true;
        NameLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(NameLabel, 0, 4);
        EditorLayout.SetColumnSpan(NameLabel, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88));
        NameTextBox.Name = "NameTextBox";
        NameTextBox.Dock = DockStyle.Fill;
        NameTextBox.TabIndex = 5;
        NameTextBox.Margin = new Padding(3, 3, 24, 3);
        EditorLayout.Controls.Add(NameTextBox, 0, 5);
        EditorLayout.SetColumnSpan(NameTextBox, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        DescriptionLabel = new Label();
        DescriptionLabel.Name = "DescriptionLabel";
        DescriptionLabel.Text = "Description:";
        DescriptionLabel.AutoSize = true;
        DescriptionLabel.Anchor = AnchorStyles.Left;
        EditorLayout.Controls.Add(DescriptionLabel, 0, 6);
        EditorLayout.SetColumnSpan(DescriptionLabel, 2);
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 128));
        DescriptionTextBox.Name = "DescriptionTextBox";
        DescriptionTextBox.Dock = DockStyle.Fill;
        DescriptionTextBox.TabIndex = 7;
        DescriptionTextBox.Margin = new Padding(3, 3, 24, 3);
        EditorLayout.Controls.Add(DescriptionTextBox, 0, 7);
        EditorLayout.SetColumnSpan(DescriptionTextBox, 2);
        IdTextBox.ReadOnly = true;
        IdTextBox.TabStop = false;
        IdTextBox.BackColor = SystemColors.Control;
        CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        NameTextBox.Multiline = true;
        NameTextBox.ScrollBars = ScrollBars.Vertical;
        DescriptionTextBox.Multiline = true;
        DescriptionTextBox.ScrollBars = ScrollBars.Vertical;
        EditorPanel.Controls.Add(EditorLayout);
        Controls.Add(MainLayout);
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "ItemsTab";
        Size = new Size(800, 450);
        EditorLayout.ResumeLayout(false);
        EditorLayout.PerformLayout();
        MainLayout.ResumeLayout(false);
        MainLayout.PerformLayout();
        ResumeLayout(false);
    }
}
