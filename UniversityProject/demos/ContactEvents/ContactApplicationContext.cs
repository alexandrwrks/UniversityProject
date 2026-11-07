using ContactEvents.Model;

namespace ContactEvents;

/// <summary>Поддерживает три равноправных окна до закрытия последнего.</summary>
public sealed class ContactApplicationContext : ApplicationContext
{
    /// <summary>Открытые редакторы общего контакта.</summary>
    private readonly List<EventForm> _forms = new();

    /// <summary>Открывает ровно три редактора одного объекта.</summary>
    public ContactApplicationContext()
    {
        var contact = new Contact { FullName = "Some Name", PhoneNumber = "+7-999-123-12-12", Address = "ул. Чкалова, 217" };
        Rectangle area = Screen.PrimaryScreen!.WorkingArea;
        for (int i = 0; i < 3; i++)
        {
            var form = new EventForm { Contact = contact, StartPosition = FormStartPosition.Manual };
            // На узком экране окна слегка перекрываются, оставаясь внутри рабочей области.
            int step = Math.Min(form.Width + 15, Math.Max(0, (area.Width - form.Width) / 2));
            form.Location = new Point(area.Left + Math.Max(0, (area.Width - (2 * step + form.Width)) / 2) + i * step,
                area.Top + Math.Max(0, (area.Height - form.Height) / 2));
            form.FormClosed += Form_Closed;
            _forms.Add(form);
            form.Show();
        }
    }

    /// <summary>Закрытие одного редактора не останавливает два оставшихся.</summary>
    private void Form_Closed(object? sender, FormClosedEventArgs e)
    {
        if (sender is not EventForm form) return;
        form.FormClosed -= Form_Closed;
        _forms.Remove(form);
        if (_forms.Count == 0) ExitThread();
    }

    /// <summary>Закрывает оставшиеся окна при завершении контекста.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            foreach (EventForm form in _forms.ToArray())
            {
                form.FormClosed -= Form_Closed;
                form.Dispose();
            }
            _forms.Clear();
        }
        base.Dispose(disposing);
    }
}
