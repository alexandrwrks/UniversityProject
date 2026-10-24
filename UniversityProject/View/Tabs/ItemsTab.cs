using System.ComponentModel;
using System.Globalization;
using UniversityProject.Model;
using UniversityProject.View.Controls;

namespace UniversityProject.View.Tabs;

/// <summary>Просмотр и редактирование товаров магазина.</summary>
public partial class ItemsTab : UserControl
{
    /// <summary>Подсказки ошибок ввода.</summary>
    private readonly ErrorProvider _errors;
    /// <summary>Отображаемая коллекция товаров.</summary>
    private List<Item> _items = new();
    /// <summary>Подавляет обработку изменений при отображении модели.</summary>
    private bool _loading;

    /// <summary>Список товаров, переданный главным окном.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Item> Items
    {
        get => _items;
        set { _items = value ?? throw new ArgumentNullException(nameof(value)); RefreshItems(); }
    }

    /// <summary>Создаёт редактор товара и подписки на изменение полей.</summary>
    public ItemsTab()
    {
        InitializeComponent();
        components ??= new Container();
        _errors = new ErrorProvider(components) { ContainerControl = this };
        CategoryComboBox.DataSource = Enum.GetValues<Category>();
        ItemsListBox.SelectedIndexChanged += (_, _) => ShowItem();
        NameTextBox.TextChanged += (_, _) => UpdateField(NameTextBox, item => item.Name = NameTextBox.Text);
        DescriptionTextBox.TextChanged += (_, _) => UpdateField(DescriptionTextBox, item => item.Info = DescriptionTextBox.Text);
        CostTextBox.TextChanged += (_, _) => UpdateField(CostTextBox, item =>
        {
            if (!double.TryParse(CostTextBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out double cost))
                throw new ArgumentException("Введите числовую стоимость от 0 до 100000.");
            item.Cost = cost;
        });
        CategoryComboBox.SelectedIndexChanged += (_, _) => UpdateField(CategoryComboBox, item => { if (CategoryComboBox.SelectedItem is Category category) item.Category = category; });
        ShowItem();
    }

    /// <summary>Обновляет список, сохраняя выбор по ссылке на объект.</summary>
    private void RefreshItems(Item? selected = null)
    {
        _loading = true;
        ItemsListBox.DataSource = null; ItemsListBox.DataSource = _items;
        ItemsListBox.SelectedIndex = selected == null ? -1 : _items.IndexOf(selected);
        _loading = false; ShowItem();
    }

    /// <summary>Отображает выбранный товар; без выбора поля недоступны.</summary>
    private void ShowItem()
    {
        if (_loading) return;
        _loading = true;
        var item = ItemsListBox.SelectedItem as Item;
        IdTextBox.Text = item?.Id.ToString() ?? string.Empty;
        NameTextBox.Text = item?.Name ?? string.Empty; DescriptionTextBox.Text = item?.Info ?? string.Empty;
        CostTextBox.Text = item?.Cost.ToString(CultureInfo.CurrentCulture) ?? string.Empty;
        CategoryComboBox.SelectedItem = item?.Category;
        foreach (Control field in new Control[] { NameTextBox, DescriptionTextBox, CostTextBox, CategoryComboBox })
        {
            field.Enabled = item != null; field.BackColor = SystemColors.Window; _errors.SetError(field, string.Empty);
        }
        RemoveButton.Enabled = item != null; _loading = false;
    }

    /// <summary>Сохраняет корректное изменение и обновляет название в списке.</summary>
    private void UpdateField(Control field, Action<Item> update)
    {
        if (_loading || ItemsListBox.SelectedItem is not Item item) return;
        if (InputValidation.Apply(field, _errors, () => update(item)))
        {
            _loading = true;
            ((CurrencyManager)BindingContext![_items]!).Refresh();
            ItemsListBox.SelectedItem = item;
            _loading = false;
        }
    }

    /// <summary>Удаляет выбранный товар.</summary>
    private void RemoveButton_Click(object sender, EventArgs e)
    {
        if (ItemsListBox.SelectedItem is not Item item) return;
        int index = _items.IndexOf(item); _items.Remove(item);
        RefreshItems(_items.Count == 0 ? null : _items[Math.Min(index, _items.Count - 1)]);
    }

    /// <summary>Создаёт и выбирает новый товар.</summary>
    private void AddButton_Click(object sender, EventArgs e)
    {
        var item = new Item("Новый товар", string.Empty, 0, Category.Electronics);
        _items.Add(item); RefreshItems(item);
    }
}
