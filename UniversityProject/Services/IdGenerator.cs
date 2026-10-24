namespace UniversityProject.Services;

/// <summary>Выдаёт отдельные последовательности идентификаторов товаров и покупателей.</summary>
public static class IdGenerator
{
    /// <summary>Последний выданный идентификатор товара.</summary>
    private static int _itemId;

    /// <summary>Последний выданный идентификатор покупателя.</summary>
    private static int _customerId;

    /// <summary>Возвращает следующий идентификатор товара, начиная с 1.</summary>
    public static int GetNextItemId() => Interlocked.Increment(ref _itemId);

    /// <summary>Возвращает следующий идентификатор покупателя, начиная с 1.</summary>
    public static int GetNextCustomerId() => Interlocked.Increment(ref _customerId);
}
