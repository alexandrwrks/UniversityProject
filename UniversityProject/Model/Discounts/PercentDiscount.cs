using UniversityProject.Model.Enums;
namespace UniversityProject.Model.Discounts;

/// <summary>Процентная скидка на одну категорию: от 1 до 10%.</summary>
public class PercentDiscount : IDiscount, IComparable<PercentDiscount>
{
    /// <summary>Сумма покупок товаров данной категории.</summary>
    private double _purchases;

    /// <summary>Категория, выбранная при создании скидки.</summary>
    public Category Category { get; }

    /// <summary>Текущий процент, повышающийся за каждую полную тысячу рублей.</summary>
    public int Percent => 1 + (int)Math.Min(9, Math.Floor(_purchases / 1000));

    /// <summary>Описание категории и текущего процента.</summary>
    public string Info => $"Процентная «{Category}» - {Percent}%";

    /// <summary>Создаёт скидку на существующую категорию.</summary>
    public PercentDiscount(Category category)
    {
        if (!Enum.IsDefined(category)) throw new ArgumentOutOfRangeException(nameof(category));
        Category = category;
    }

    /// <summary>Рассчитывает скидку только на товары своей категории.</summary>
    public double Calculate(List<Item> items) => CategoryAmount(items) * Percent / 100;

    /// <summary>Применяет процент без расходования накопленной скидки.</summary>
    public double Apply(List<Item> items) => Calculate(items);

    /// <summary>Учитывает покупки своей категории для следующих заказов.</summary>
    public void Update(List<Item> items)
    {
        _purchases += CategoryAmount(items);
    }

    /// <summary>Суммирует цены товаров соответствующей категории.</summary>
    private double CategoryAmount(List<Item> items)
    {
        ArgumentNullException.ThrowIfNull(items);
        double sum = 0;
        foreach (Item item in items)
            if (item.Category == Category) sum += item.Cost;
        return sum;
    }

    /// <summary>Сравнивает текущие проценты независимо от категории.</summary>
    public int CompareTo(PercentDiscount? other) => other is null ? 1 : Percent.CompareTo(other.Percent);

}
