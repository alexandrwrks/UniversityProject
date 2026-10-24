namespace UniversityProject.View.Controls;

/// <summary>Проверка редактора с подсветкой и пояснением ошибки.</summary>
internal static class InputValidation
{
    /// <summary>Применяет корректное значение, оставляя модель прежней при ошибке.</summary>
    internal static bool Apply(Control control, ErrorProvider errors, Action update)
    {
        try
        {
            update(); control.BackColor = SystemColors.Window; errors.SetError(control, string.Empty);
            return true;
        }
        catch (ArgumentException exception)
        {
            control.BackColor = Color.MistyRose; errors.SetError(control, exception.Message);
            return false;
        }
    }
}
