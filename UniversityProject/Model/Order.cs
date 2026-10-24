using UniversityProject.Services;

namespace UniversityProject.Model;

/// <summary>Заказ с отдельным списком ссылок на купленные товары.</summary>
public class Order
{
    /// <summary>Уникальный номер заказа.</summary>
    private readonly int _id;
    /// <summary>Время создания заказа.</summary>
    private readonly DateTime _creationDate;
    /// <summary>Адрес доставки на момент оформления.</summary>
    private Address _address;
    /// <summary>Агрегируемые товары.</summary>
    private List<Item> _items;

    /// <summary>Номер заказа только для чтения.</summary>
    public int Id => _id;
    /// <summary>Время создания только для чтения.</summary>
    public DateTime CreationDate => _creationDate;
    /// <summary>Обязательный адрес доставки.</summary>
    public Address Address
    {
        get => _address;
        set => _address = value ?? throw new ArgumentNullException(nameof(value));
    }
    /// <summary>Товары заказа. Null трактуется как пустой список.</summary>
    public List<Item> Items
    {
        get => _items;
        set => _items = value ?? new List<Item>();
    }
    /// <summary>Текущая общая стоимость товаров заказа.</summary>
    public double Amount
    {
        get
        {
            double amount = 0;
            foreach (Item item in _items) amount += item.Cost;
            return amount;
        }
    }
    /// <summary>Текущий статус заказа.</summary>
    public OrderStatus Status { get; set; } = OrderStatus.New;

    /// <summary>Создаёт заказ с копией адреса и отдельным списком тех же объектов товаров.</summary>
    /// <param name="address">Адрес покупателя на момент оформления.</param>
    /// <param name="items">Товары корзины.</param>
    public Order(Address address, IEnumerable<Item> items)
    {
        ArgumentNullException.ThrowIfNull(address);
        ArgumentNullException.ThrowIfNull(items);
        _address = new Address(address.Index, address.Country, address.City, address.Street, address.Building, address.Apartment);
        _items = new List<Item>(items);
        _id = IdGenerator.GetNextOrderId();
        _creationDate = DateTime.Now;
    }
}
