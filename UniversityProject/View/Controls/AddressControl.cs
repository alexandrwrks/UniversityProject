using UniversityProject.Model;

namespace UniversityProject.View.Controls;

/// <summary>Редактор адреса с независимой проверкой каждого поля.</summary>
public partial class AddressControl : UserControl
{
    /// <summary>Редакторы составляющих адреса.</summary>
    private readonly TextBox[] _fields;
    /// <summary>Ошибки ввода.</summary>
    private readonly ErrorProvider _errors;
    /// <summary>Текущий адрес.</summary>
    private Address _address = new();
    /// <summary>Защита от изменения модели во время отображения.</summary>
    private bool _loading;

    /// <summary>Запрещает пользовательское редактирование полей.</summary>
    private bool _readOnly;

    /// <summary>Показывает адрес для чтения, сохраняя возможность выделять и копировать текст.</summary>
    [System.ComponentModel.DefaultValue(false)]
    public bool ReadOnly
    {
        get => _readOnly;
        set
        {
            _readOnly = value;
            foreach (TextBox textBox in _fields) textBox.ReadOnly = value;
        }
    }

    /// <summary>Отображаемый адрес. Некорректный ввод не заменяет последнее корректное значение.</summary>
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public Address Address
    {
        get => _address;
        set { _address = value ?? throw new ArgumentNullException(nameof(value)); ShowAddress(); }
    }

    /// <summary>Создаёт поля редактора.</summary>
    public AddressControl()
    {
        InitializeComponent();
        _fields = [IndexTextBox, CountryTextBox, CityTextBox, StreetTextBox, BuildingTextBox, ApartmentTextBox];
        _errors = new ErrorProvider { ContainerControl = this };
        for (int i = 0; i < _fields.Length; i++)
        {
            int field = i;
            _fields[i].TextChanged += (_, _) =>
            {
                if (!_loading) ValidateField(field);
            };
        }
        ShowAddress();
    }

    /// <summary>Проверяет все поля, например перед созданием покупателя.</summary>
    public bool ValidateAddress()
    {
        bool valid = true;
        for (int i = 0; i < _fields.Length; i++) valid &= ValidateField(i);
        return valid;
    }

    /// <summary>Отображает модель, очищая ошибки предыдущего адреса.</summary>
    private void ShowAddress()
    {
        _loading = true;
        string[] values = [_address.Index.ToString(), _address.Country, _address.City, _address.Street, _address.Building, _address.Apartment];
        for (int i = 0; i < values.Length; i++)
        {
            _fields[i].Text = values[i]; _fields[i].BackColor = SystemColors.Window; _errors.SetError(_fields[i], string.Empty);
        }
        _loading = false;
    }

    /// <summary>Проверяет и сохраняет одно поле без потери остальных корректных полей.</summary>
    private bool ValidateField(int index) => InputValidation.Apply(_fields[index], _errors, () =>
    {
        string text = _fields[index].Text;
        switch (index)
        {
            case 0:
                if (text.Length != 6 || text.Any(c => c < '0' || c > '9') || !int.TryParse(text, out int postalIndex))
                    throw new ArgumentException("Индекс должен содержать шесть цифр.");
                _address.Index = postalIndex; break;
            case 1: _address.Country = text; break;
            case 2: _address.City = text; break;
            case 3: _address.Street = text; break;
            case 4: _address.Building = text; break;
            case 5: _address.Apartment = text; break;
        }
    });

    /// <summary>Освобождает ресурсы подсказок.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _errors.Dispose();
        base.Dispose(disposing);
    }
}
