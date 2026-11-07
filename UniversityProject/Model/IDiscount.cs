namespace UniversityProject.Model;

/// <summary>Общий контракт скидки независимо от способа её расчёта.</summary>
public interface IDiscount
{
    /// <summary>Описание текущего состояния скидки.</summary>
    string Info { get; }
    /// <summary>Оценивает доступную скидку, не изменяя её состояния.</summary>
    double Calculate(List<Item> items);
    /// <summary>Применяет скидку, возвращая фактически списанную сумму.</summary>
    double Apply(List<Item> items);
    /// <summary>Учитывает покупку для последующих заказов.</summary>
    void Update(List<Item> items);
}
