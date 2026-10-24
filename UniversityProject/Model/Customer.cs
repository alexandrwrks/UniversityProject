using UniversityProject.Services;

namespace UniversityProject.Model;

/// <summary>Покупатель и его обязательный адрес доставки.</summary>
public class Customer
{
    /// <summary>Уникальный номер.</summary>
    private readonly int _id;
    /// <summary>Полное имя.</summary>
    private string _fullname = string.Empty;
    /// <summary>Адрес доставки.</summary>
    private Address _address = new();

    /// <summary>Идентификатор только для чтения.</summary>
    public int Id => _id;
    /// <summary>Полное имя длиной до 200 символов.</summary>
    public string Fullname
    {
        get => _fullname;
        set
        {
            ValueValidator.AssertStringOnLength(value, 200, nameof(Fullname));
            _fullname = value;
        }
    }
    /// <summary>Обязательный составной адрес.</summary>
    public Address Address
    {
        get => _address;
        set => _address = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>Создаёт покупателя с проверенным именем и адресом.</summary>
    /// <param name="fullname">Полное имя.</param>
    /// <param name="address">Адрес доставки.</param>
    public Customer(string fullname, Address address)
    {
        Fullname = fullname;
        Address = address;
        _id = IdGenerator.GetNextCustomerId();
    }

    /// <summary>Возвращает краткое представление для списка.</summary>
    public override string ToString() => $"{Id}: {Fullname}";
}
