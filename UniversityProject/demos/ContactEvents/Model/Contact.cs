namespace ContactEvents.Model;

/// <summary>Один контакт, общий для нескольких редакторов.</summary>
public sealed class Contact
{
    /// <summary>Полное имя.</summary>
    private string _fullName = string.Empty;
    /// <summary>Телефон в строковом виде с сохранением форматирования.</summary>
    private string _phoneNumber = string.Empty;
    /// <summary>Адрес в свободной форме.</summary>
    private string _address = string.Empty;

    /// <summary>Фактическое изменение полного имени.</summary>
    public event EventHandler<EventArgs>? FullNameChanged;
    /// <summary>Фактическое изменение телефона.</summary>
    public event EventHandler<EventArgs>? PhoneNumberChanged;
    /// <summary>Фактическое изменение адреса.</summary>
    public event EventHandler<EventArgs>? AddressChanged;

    /// <summary>Полное имя контакта.</summary>
    public string FullName
    {
        get => _fullName;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            if (_fullName == value) return;
            _fullName = value;
            FullNameChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>Телефон контакта.</summary>
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            if (_phoneNumber == value) return;
            _phoneNumber = value;
            PhoneNumberChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>Адрес контакта.</summary>
    public string Address
    {
        get => _address;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            if (_address == value) return;
            _address = value;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
