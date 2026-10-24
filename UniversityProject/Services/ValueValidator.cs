namespace UniversityProject.Services;

/// <summary>Проверяет ограничения значений свойств моделей.</summary>
public static class ValueValidator
{
    /// <summary>Проверяет, что строка не null и не превышает максимальную длину.</summary>
    public static void AssertStringOnLength(string value, int maxLength, string propertyName)
    {
        ArgumentNullException.ThrowIfNull(value, propertyName);
        if (value.Length > maxLength)
            throw new ArgumentException($"{propertyName}: не более {maxLength} символов.", propertyName);
    }

    /// <summary>Проверяет конечную стоимость в диапазоне от нуля до максимума.</summary>
    public static void AssertDoubleValue(double value, int maxPrice, string propertyName)
    {
        if (!double.IsFinite(value) || value < 0 || value > maxPrice)
            throw new ArgumentOutOfRangeException(propertyName, $"{propertyName}: число от 0 до {maxPrice}.");
    }
}
