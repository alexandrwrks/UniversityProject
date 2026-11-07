namespace UniversityProject.Model.Discounts;

/// <summary>Накопительная скидка: один балл равен одному рублю.</summary>
public class PointsDiscount : IDiscount, IComparable<PointsDiscount>
{
    /// <summary>Целые накопленные баллы, не меньше нуля.</summary>
    public int Points { get; private set; }

    /// <summary>Описание текущего состояния скидки.</summary>
    public string Info => $"Накопительная – {Points} баллов";

    /// <summary>Возвращает доступные целые баллы, не более 30% суммы.</summary>
    public double Calculate(List<Item> items)
    {
        return Math.Min(Points, Math.Floor(Sum(items) * 0.3));
    }

    /// <summary>Списывает только баллы, фактически предоставленные как скидка.</summary>
    public double Apply(List<Item> items)
    {
        int discount = (int)Calculate(items);
        Points -= discount;
        return discount;
    }

    /// <summary>Начисляет 10% суммы покупки с округлением вверх.</summary>
    public void Update(List<Item> items)
    {
        Points = checked(Points + (int)Math.Ceiling(Sum(items) * 0.1));
    }

    /// <summary>Суммирует цены без изменения списка товаров.</summary>
    private static double Sum(List<Item> items)
    {
        ArgumentNullException.ThrowIfNull(items);
        double sum = 0;
        foreach (Item item in items) sum += item.Cost;
        return sum;
    }

    /// <summary>Сравнивает накопленные баллы; скидка больше null.</summary>
    public int CompareTo(PointsDiscount? other) => other is null ? 1 : Points.CompareTo(other.Points);

}
