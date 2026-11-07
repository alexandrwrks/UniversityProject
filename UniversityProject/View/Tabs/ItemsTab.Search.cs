namespace UniversityProject.View.Tabs;

public partial class ItemsTab
{
    /// <summary>Отдельный список отображаемых ссылок после фильтрации и сортировки.</summary>
    private List<UniversityProject.Model.Item> _displayedItems = new();
    /// <summary>Подстрока поиска в названии товара.</summary>
    private readonly TextBox SearchTextBox = new() { Name = "SearchTextBox", Dock = DockStyle.Fill };
    /// <summary>Способ упорядочивания, независимый от текста поиска.</summary>
    private readonly ComboBox SortComboBox = new()
    {
        Name = "SortComboBox", Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList
    };

    /// <summary>Размещает поиск над каталогом и сортировку под ним.</summary>
    private void InitializeSearch()
    {
        var catalog = new TableLayoutPanel { Name = "CatalogLayout", Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
        catalog.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        catalog.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        catalog.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        catalog.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        MainLayout.Controls.Remove(ItemsListBox);
        var search = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Margin = Padding.Empty };
        search.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75));
        search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        search.Controls.Add(new Label { Text = "Search:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
        search.Controls.Add(SearchTextBox, 1, 0);
        var sort = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Margin = Padding.Empty };
        sort.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75));
        sort.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        sort.Controls.Add(new Label { Text = "Order By:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
        sort.Controls.Add(SortComboBox, 1, 0);
        SortComboBox.Items.AddRange(new object[] { "Name", "Cost Ascending", "Cost Descending" });
        SortComboBox.SelectedIndex = 0;
        catalog.Controls.Add(search, 0, 0);
        catalog.Controls.Add(ItemsListBox, 0, 1);
        catalog.Controls.Add(sort, 0, 2);
        MainLayout.Controls.Add(catalog, 0, 1);
        SearchTextBox.TextChanged += (_, _) => RefreshItems(ItemsListBox.SelectedItem as UniversityProject.Model.Item);
        SortComboBox.SelectedIndexChanged += (_, _) => RefreshItems(ItemsListBox.SelectedItem as UniversityProject.Model.Item);
    }
}
