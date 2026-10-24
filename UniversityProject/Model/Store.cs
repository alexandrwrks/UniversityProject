namespace UniversityProject.Model;

/// <summary>Единая точка хранения товаров и покупателей магазина.</summary>
public class Store
{
    /// <summary>Список товаров.</summary>
    private readonly List<Item> _items;
    /// <summary>Список покупателей.</summary>
    private readonly List<Customer> _customers;
    /// <summary>Товары магазина, всегда не null.</summary>
    public List<Item> Items => _items;
    /// <summary>Покупатели магазина, всегда не null.</summary>
    public List<Customer> Customers => _customers;

    /// <summary>Создаёт магазин с пустыми коллекциями.</summary>
    public Store()
    {
        _items = new();
        _customers = new();
    }
}
