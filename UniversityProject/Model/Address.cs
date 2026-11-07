using UniversityProject.Services;

namespace UniversityProject.Model;

/// <summary>Составной адрес доставки.</summary>
public class Address : ICloneable, IEquatable<Address>
{
    /// <summary>Уведомляет о фактическом изменении любой составляющей адреса.</summary>
    public event EventHandler<EventArgs>? AddressChanged;

    /// <summary>Почтовый индекс из шести цифр.</summary>
    private int _index = 100000;
    /// <summary>Страна, до 50 символов.</summary>
    private string _country = string.Empty;
    /// <summary>Город, до 50 символов.</summary>
    private string _city = string.Empty;
    /// <summary>Улица, до 100 символов.</summary>
    private string _street = string.Empty;
    /// <summary>Дом, до 10 символов.</summary>
    private string _building = string.Empty;
    /// <summary>Квартира, до 10 символов.</summary>
    private string _apartment = string.Empty;
    /// <summary>Почтовый индекс из шести цифр.</summary>
    public int Index
    {
        get => _index;
        set
        {
            if (value < 100000 || value > 999999) throw new ArgumentOutOfRangeException(nameof(Index), "Индекс должен содержать шесть цифр.");
            if (_index == value) return;
            _index = value;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Страна, до 50 символов.</summary>
    public string Country
    {
        get => _country;
        set
        {
            ValueValidator.AssertStringOnLength(value, 50, nameof(Country));
            if (_country == value) return;
            _country = value;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Город, до 50 символов.</summary>
    public string City
    {
        get => _city;
        set
        {
            ValueValidator.AssertStringOnLength(value, 50, nameof(City));
            if (_city == value) return;
            _city = value;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Улица, до 100 символов.</summary>
    public string Street
    {
        get => _street;
        set
        {
            ValueValidator.AssertStringOnLength(value, 100, nameof(Street));
            if (_street == value) return;
            _street = value;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Дом, до 10 символов.</summary>
    public string Building
    {
        get => _building;
        set
        {
            ValueValidator.AssertStringOnLength(value, 10, nameof(Building));
            if (_building == value) return;
            _building = value;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Квартира, до 10 символов.</summary>
    public string Apartment
    {
        get => _apartment;
        set
        {
            ValueValidator.AssertStringOnLength(value, 10, nameof(Apartment));
            if (_apartment == value) return;
            _apartment = value;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Создаёт пустой адрес с минимальным допустимым индексом.</summary>
    public Address() { }

    /// <summary>Создаёт адрес с проверкой всех составляющих.</summary>
    /// <param name="index">Шестизначный индекс.</param>
    /// <param name="country">Страна.</param>
    /// <param name="city">Город.</param>
    /// <param name="street">Улица.</param>
    /// <param name="building">Номер дома.</param>
    /// <param name="apartment">Номер квартиры.</param>
    public Address(int index, string country, string city, string street, string building, string apartment)
    {
        Index = index;
        Country = country;
        City = city;
        Street = street;
        Building = building;
        Apartment = apartment;
    }

    /// <summary>Возвращает почтовое представление адреса.</summary>
    public override string ToString() => $"{Index}, {Country}, {City}, {Street}, {Building}, {Apartment}";

    /// <summary>Создаёт независимую копию всех составляющих адреса.</summary>
    public object Clone() => new Address(Index, Country, City, Street, Building, Apartment);

    /// <summary>Сравнивает все составляющие адреса с учётом регистра.</summary>
    public bool Equals(Address? other) => other is not null &&
        Index == other.Index && Country == other.Country && City == other.City &&
        Street == other.Street && Building == other.Building && Apartment == other.Apartment;

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is Address other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(Index, Country, City, Street, Building, Apartment);

}
