namespace UniversityProject.Model;

/// <summary>Корзина покупателя, агрегирующая существующие товары.</summary>
public class Cart
{
    /// <summary>Товары корзины; одинаковый товар может встречаться несколько раз.</summary>
    private List<Item> _items = new();

    /// <summary>Товары корзины. Присваивание null заменяет список пустым.</summary>
    public List<Item> Items
    {
        get => _items;
        set => _items = value ?? new List<Item>();
    }

    /// <summary>Текущая сумма цен всех товаров, для пустой корзины — ноль.</summary>
    public double Amount
    {
        get
        {
            double amount = 0;
            foreach (Item item in _items) amount += item.Cost;
            return amount;
        }
    }
}
