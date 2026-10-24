namespace UniversityProject.Model;

/// <summary>Заказ с возможностью выбрать дату и интервал доставки.</summary>
public class PriorityOrder : Order
{
    /// <summary>Неизменяемый набор допустимых интервалов доставки.</summary>
    private static readonly IReadOnlyList<string> _deliveryTimes = Array.AsReadOnly(new[]
    {
        "9:00 – 11:00", "11:00 – 13:00", "13:00 – 15:00",
        "15:00 – 17:00", "17:00 – 19:00", "19:00 – 21:00"
    });

    /// <summary>Желаемая дата доставки.</summary>
    private DateTime _deliveryDate;
    /// <summary>Желаемый интервал доставки.</summary>
    private string _deliveryTime = string.Empty;

    /// <summary>Все допустимые интервалы; коллекцию нельзя изменить извне.</summary>
    public static IReadOnlyList<string> DeliveryTimes => _deliveryTimes;

    /// <summary>Желаемая дата доставки без временной составляющей.</summary>
    public DateTime DeliveryDate
    {
        get => _deliveryDate;
        set => _deliveryDate = value.Date;
    }

    /// <summary>Один из шести допустимых интервалов доставки.</summary>
    public string DeliveryTime
    {
        get => _deliveryTime;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            if (!_deliveryTimes.Contains(value))
                throw new ArgumentException("Выберите один из шести доступных интервалов доставки.", nameof(value));
            _deliveryTime = value;
        }
    }

    /// <summary>Создаёт пустой приоритетный заказ с сегодняшней датой и первым интервалом.</summary>
    public PriorityOrder() : this(new Address(), new List<Item>(), DateTime.Today, DeliveryTimes[0]) { }

    /// <summary>Создаёт заказ через базовый конструктор и задаёт параметры доставки.</summary>
    /// <param name="address">Адрес доставки.</param>
    /// <param name="items">Существующие товары заказа.</param>
    /// <param name="deliveryDate">Желаемая дата доставки.</param>
    /// <param name="deliveryTime">Один из допустимых интервалов.</param>
    public PriorityOrder(Address address, IEnumerable<Item> items, DateTime deliveryDate, string deliveryTime)
        : base(address, items)
    {
        DeliveryDate = deliveryDate;
        DeliveryTime = deliveryTime;
    }
}
