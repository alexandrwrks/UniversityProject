using UniversityProject.Model;
using UniversityProject.View.Tabs;

namespace UniversityProject;

/// <summary>Точка входа в приложение и отдельную учебную демонстрацию.</summary>
internal static class Program
{
    /// <summary>Запускает главное окно или учебный редактор по флагу --priority-demo.</summary>
    /// <param name="args">Аргументы командной строки.</param>
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        if (args.Contains("--priority-demo"))
        {
            using var demo = new Form
            {
                Text = "Priority Order — учебный редактор",
                ClientSize = new Size(700, 620),
                MinimumSize = new Size(480, 520)
            };
            demo.Controls.Add(new PriorityOrdersTab
            {
                Dock = DockStyle.Fill,
                Items = new List<Item>
                {
                    new Item("Учебник C#", "Товар для демонстрации наследования", 1500, Category.Books),
                    new Item("Клавиатура", "Товар для демонстрации наследования", 2500, Category.Electronics)
                }
            });
            Application.Run(demo);
            return;
        }
        Application.Run(new MainForm());
    }
}
