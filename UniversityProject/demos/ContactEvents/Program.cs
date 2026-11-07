namespace ContactEvents;

internal static class Program
{
    /// <summary>Запускает три редактора одного контакта.</summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var context = new ContactApplicationContext();
        Application.Run(context);
    }
}
