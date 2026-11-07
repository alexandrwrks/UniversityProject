using UniversityProject.Model;

namespace UniversityProject.View.Tabs;

public partial class ItemsTab
{
    /// <summary>Добавление, удаление или изменение данных товара.</summary>
    public event EventHandler<EventArgs>? ItemsChanged;
    /// <summary>Объекты, на события которых подписана вкладка.</summary>
    private readonly HashSet<Item> _observedItems = new(ReferenceEqualityComparer.Instance);
    /// <summary>Позволяет закончить проверку и обновление редактора до уведомления вкладок.</summary>
    private bool _editingItem;

    /// <summary>Подписывается на объект не более одного раза.</summary>
    private void SubscribeItem(Item item)
    {
        if (!_observedItems.Add(item)) return;
        item.NameChanged += Item_Changed;
        item.InfoChanged += Item_Changed;
        item.CostChanged += Item_Changed;
    }

    /// <summary>Освобождает подписки удалённого объекта.</summary>
    private void UnsubscribeItem(Item item)
    {
        item.NameChanged -= Item_Changed;
        item.InfoChanged -= Item_Changed;
        item.CostChanged -= Item_Changed;
        _observedItems.Remove(item);
    }

    /// <summary>Освобождает подписки при замене списка или уничтожении вкладки.</summary>
    private void UnsubscribeItems()
    {
        foreach (Item item in _observedItems.ToArray()) UnsubscribeItem(item);
    }

    /// <summary>Показывает внешние изменения и уведомляет зависимые вкладки.</summary>
    private void Item_Changed(object? sender, EventArgs e)
    {
        if (_editingItem) return;
        RefreshItems(ItemsListBox.SelectedItem as Item);
        ItemsChanged?.Invoke(this, EventArgs.Empty);
    }
}
