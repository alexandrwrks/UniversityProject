namespace UniversityProject.Model;

/// <summary>Состояние заказа в процессе выполнения.</summary>
public enum OrderStatus
{
    /// <summary>Новый заказ.</summary>
    New,
    /// <summary>Обрабатывается.</summary>
    Processing,
    /// <summary>Собирается на складе.</summary>
    Assembly,
    /// <summary>Отправлен.</summary>
    Sent,
    /// <summary>Доставлен.</summary>
    Delivered,
    /// <summary>Возврат.</summary>
    Returned,
    /// <summary>Отменён магазином.</summary>
    Abandoned
}
