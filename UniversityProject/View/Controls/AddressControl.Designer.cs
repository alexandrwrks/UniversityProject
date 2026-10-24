namespace UniversityProject.View.Controls;

partial class AddressControl
{
    /// <summary>Элемент макета адреса: AddressLayout.</summary>
    private TableLayoutPanel AddressLayout;
    /// <summary>Элемент макета адреса: IndexLayout.</summary>
    private TableLayoutPanel IndexLayout;
    /// <summary>Элемент макета адреса: LocationLayout.</summary>
    private TableLayoutPanel LocationLayout;
    /// <summary>Элемент макета адреса: StreetLayout.</summary>
    private TableLayoutPanel StreetLayout;
    /// <summary>Элемент макета адреса: BuildingLayout.</summary>
    private TableLayoutPanel BuildingLayout;
    /// <summary>Элемент макета адреса: DeliveryAddressLabel.</summary>
    private Label DeliveryAddressLabel;
    /// <summary>Элемент макета адреса: IndexLabel.</summary>
    private Label IndexLabel;
    /// <summary>Элемент макета адреса: CountryLabel.</summary>
    private Label CountryLabel;
    /// <summary>Элемент макета адреса: CityLabel.</summary>
    private Label CityLabel;
    /// <summary>Элемент макета адреса: StreetLabel.</summary>
    private Label StreetLabel;
    /// <summary>Элемент макета адреса: BuildingLabel.</summary>
    private Label BuildingLabel;
    /// <summary>Элемент макета адреса: ApartmentLabel.</summary>
    private Label ApartmentLabel;
    /// <summary>Элемент макета адреса: IndexTextBox.</summary>
    private TextBox IndexTextBox;
    /// <summary>Элемент макета адреса: CountryTextBox.</summary>
    private TextBox CountryTextBox;
    /// <summary>Элемент макета адреса: CityTextBox.</summary>
    private TextBox CityTextBox;
    /// <summary>Элемент макета адреса: StreetTextBox.</summary>
    private TextBox StreetTextBox;
    /// <summary>Элемент макета адреса: BuildingTextBox.</summary>
    private TextBox BuildingTextBox;
    /// <summary>Элемент макета адреса: ApartmentTextBox.</summary>
    private TextBox ApartmentTextBox;

    /// <summary>Создаёт редактор по макету второй лабораторной работы.</summary>
    private void InitializeComponent()
    {
        AddressLayout = new TableLayoutPanel();
        IndexLayout = new TableLayoutPanel();
        LocationLayout = new TableLayoutPanel();
        StreetLayout = new TableLayoutPanel();
        BuildingLayout = new TableLayoutPanel();
        DeliveryAddressLabel = new Label();
        IndexLabel = new Label();
        CountryLabel = new Label();
        CityLabel = new Label();
        StreetLabel = new Label();
        BuildingLabel = new Label();
        ApartmentLabel = new Label();
        IndexTextBox = new TextBox();
        CountryTextBox = new TextBox();
        CityTextBox = new TextBox();
        StreetTextBox = new TextBox();
        BuildingTextBox = new TextBox();
        ApartmentTextBox = new TextBox();
        SuspendLayout();
        AddressLayout.SuspendLayout();
        AddressLayout.Name = "AddressLayout";
        AddressLayout.Dock = DockStyle.Fill;
        AddressLayout.ColumnCount = 1;
        AddressLayout.RowCount = 5;
        AddressLayout.Margin = new Padding(0);
        AddressLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AddressLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        AddressLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        AddressLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        AddressLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        AddressLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        DeliveryAddressLabel.Name = "DeliveryAddressLabel";
        DeliveryAddressLabel.Text = "Delivery Address";
        DeliveryAddressLabel.AutoSize = true;
        DeliveryAddressLabel.Anchor = AnchorStyles.Left;
        DeliveryAddressLabel.Font = new Font(Font, FontStyle.Bold);
        AddressLayout.Controls.Add(DeliveryAddressLabel, 0, 0);
        IndexLayout.Name = "IndexLayout";
        IndexLayout.Dock = DockStyle.Fill;
        IndexLayout.Margin = new Padding(0);
        IndexLayout.ColumnCount = 3;
        IndexLayout.RowCount = 1;
        IndexLayout.TabIndex = 0;
        IndexLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        IndexLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72));
        IndexLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118));
        IndexLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        IndexLabel.Name = "IndexLabel";
        IndexLabel.Text = "Post Index:";
        IndexLabel.AutoSize = true;
        IndexLabel.Anchor = AnchorStyles.Left;
        IndexLayout.Controls.Add(IndexLabel, 0, 0);
        IndexTextBox.Name = "IndexTextBox";
        IndexTextBox.Dock = DockStyle.Fill;
        IndexTextBox.Margin = new Padding(3, 3, 20, 3);
        IndexTextBox.TabIndex = 0;
        IndexLayout.Controls.Add(IndexTextBox, 1, 0);
        AddressLayout.Controls.Add(IndexLayout, 0, 1);
        LocationLayout.Name = "LocationLayout";
        LocationLayout.Dock = DockStyle.Fill;
        LocationLayout.Margin = new Padding(0);
        LocationLayout.ColumnCount = 4;
        LocationLayout.RowCount = 1;
        LocationLayout.TabIndex = 1;
        LocationLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        LocationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72));
        LocationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        LocationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44));
        LocationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        CountryLabel.Name = "CountryLabel";
        CountryLabel.Text = "Country:";
        CountryLabel.AutoSize = true;
        CountryLabel.Anchor = AnchorStyles.Left;
        LocationLayout.Controls.Add(CountryLabel, 0, 0);
        CountryTextBox.Name = "CountryTextBox";
        CountryTextBox.Dock = DockStyle.Fill;
        CountryTextBox.Margin = new Padding(3, 3, 20, 3);
        CountryTextBox.TabIndex = 1;
        LocationLayout.Controls.Add(CountryTextBox, 1, 0);
        CityLabel.Name = "CityLabel";
        CityLabel.Text = "City:";
        CityLabel.AutoSize = true;
        CityLabel.Anchor = AnchorStyles.Left;
        LocationLayout.Controls.Add(CityLabel, 2, 0);
        CityTextBox.Name = "CityTextBox";
        CityTextBox.Dock = DockStyle.Fill;
        CityTextBox.Margin = new Padding(3, 3, 20, 3);
        CityTextBox.TabIndex = 2;
        LocationLayout.Controls.Add(CityTextBox, 3, 0);
        AddressLayout.Controls.Add(LocationLayout, 0, 2);
        StreetLayout.Name = "StreetLayout";
        StreetLayout.Dock = DockStyle.Fill;
        StreetLayout.Margin = new Padding(0);
        StreetLayout.ColumnCount = 2;
        StreetLayout.RowCount = 1;
        StreetLayout.TabIndex = 2;
        StreetLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        StreetLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72));
        StreetLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        StreetLabel.Name = "StreetLabel";
        StreetLabel.Text = "Street:";
        StreetLabel.AutoSize = true;
        StreetLabel.Anchor = AnchorStyles.Left;
        StreetLayout.Controls.Add(StreetLabel, 0, 0);
        StreetTextBox.Name = "StreetTextBox";
        StreetTextBox.Dock = DockStyle.Fill;
        StreetTextBox.Margin = new Padding(3, 3, 20, 3);
        StreetTextBox.TabIndex = 3;
        StreetLayout.Controls.Add(StreetTextBox, 1, 0);
        AddressLayout.Controls.Add(StreetLayout, 0, 3);
        BuildingLayout.Name = "BuildingLayout";
        BuildingLayout.Dock = DockStyle.Fill;
        BuildingLayout.Margin = new Padding(0);
        BuildingLayout.ColumnCount = 5;
        BuildingLayout.RowCount = 1;
        BuildingLayout.TabIndex = 3;
        BuildingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        BuildingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72));
        BuildingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88));
        BuildingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84));
        BuildingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88));
        BuildingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        BuildingLabel.Name = "BuildingLabel";
        BuildingLabel.Text = "Building:";
        BuildingLabel.AutoSize = true;
        BuildingLabel.Anchor = AnchorStyles.Left;
        BuildingLayout.Controls.Add(BuildingLabel, 0, 0);
        BuildingTextBox.Name = "BuildingTextBox";
        BuildingTextBox.Dock = DockStyle.Fill;
        BuildingTextBox.Margin = new Padding(3, 3, 20, 3);
        BuildingTextBox.TabIndex = 4;
        BuildingLayout.Controls.Add(BuildingTextBox, 1, 0);
        ApartmentLabel.Name = "ApartmentLabel";
        ApartmentLabel.Text = "Apartment:";
        ApartmentLabel.AutoSize = true;
        ApartmentLabel.Anchor = AnchorStyles.Left;
        BuildingLayout.Controls.Add(ApartmentLabel, 2, 0);
        ApartmentTextBox.Name = "ApartmentTextBox";
        ApartmentTextBox.Dock = DockStyle.Fill;
        ApartmentTextBox.Margin = new Padding(3, 3, 20, 3);
        ApartmentTextBox.TabIndex = 5;
        BuildingLayout.Controls.Add(ApartmentTextBox, 3, 0);
        AddressLayout.Controls.Add(BuildingLayout, 0, 4);
        Controls.Add(AddressLayout);
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "AddressControl";
        MinimumSize = new Size(350, 144);
        Size = new Size(460, 144);
        AddressLayout.ResumeLayout(false);
        AddressLayout.PerformLayout();
        ResumeLayout(false);
    }
}
