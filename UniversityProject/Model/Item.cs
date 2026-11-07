using UniversityProject.Model.Enums;
using UniversityProject.Services;

namespace UniversityProject.Model;

/// <summary>Товар магазина с уникальным идентификатором.</summary>
public class Item : ICloneable, IEquatable<Item>, IComparable<Item>
{
    /// <summary>Уведомляет об изменении названия после проверки значения.</summary>
    public event EventHandler<EventArgs>? NameChanged;
    /// <summary>Уведомляет об изменении описания после проверки значения.</summary>
    public event EventHandler<EventArgs>? InfoChanged;
    /// <summary>Уведомляет об изменении стоимости после проверки значения.</summary>
    public event EventHandler<EventArgs>? CostChanged;

    /// <summary>Уникальный номер.</summary>
    private readonly int _id;
    /// <summary>Название.</summary>
    private string _name = string.Empty;
    /// <summary>Описание.</summary>
    private string _info = string.Empty;
    /// <summary>Стоимость.</summary>
    private double _cost;

    /// <summary>Идентификатор, доступный только для чтения.</summary>
    public int Id => _id;
    /// <summary>Название длиной до 200 символов.</summary>
    public string Name
    {
        get => _name;
        set
        {
            ValueValidator.AssertStringOnLength(value, 200, nameof(Name));
            if (_name == value) return;
            _name = value;
            NameChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Описание длиной до 1000 символов.</summary>
    public string Info
    {
        get => _info;
        set
        {
            ValueValidator.AssertStringOnLength(value, 1000, nameof(Info));
            if (_info == value) return;
            _info = value;
            InfoChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Конечная стоимость от 0 до 100000 включительно.</summary>
    public double Cost
    {
        get => _cost;
        set
        {
            ValueValidator.AssertDoubleValue(value, 100000, nameof(Cost));
            if (_cost == value) return;
            _cost = value;
            CostChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    /// <summary>Категория товара.</summary>
    public Category Category { get; set; }

    /// <summary>Создаёт товар с проверкой значений через свойства.</summary>
    /// <param name="name">Название.</param>
    /// <param name="info">Описание.</param>
    /// <param name="cost">Стоимость.</param>
    /// <param name="category">Категория.</param>
    public Item(string name, string info, double cost, Category category)
    {
        Name = name;
        Info = info;
        Cost = cost;
        Category = category;
        _id = IdGenerator.GetNextItemId();
    }

    /// <summary>Возвращает краткое представление для списка.</summary>
    public override string ToString() => $"{Id}: {Name}";

    /// <summary>Создаёт независимый товар с новым Id и теми же данными.</summary>
    public object Clone() => new Item(Name, Info, Cost, Category);

    /// <summary>Сравнивает товары по неизменяемому уникальному Id.</summary>
    public bool Equals(Item? other) => other is not null && Id == other.Id;

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is Item other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>Сравнивает стоимость; любой товар больше null.</summary>
    public int CompareTo(Item? other) => other is null ? 1 : Cost.CompareTo(other.Cost);

}
