using System.ComponentModel;
using ContactEvents.Model;

namespace ContactEvents;

/// <summary>Редактор общего контакта, подписывающийся на текущую модель.</summary>
public sealed class EventForm : Form
{
    /// <summary>Текущий контакт либо null при отсутствии модели.</summary>
    private Contact? _contact;
    /// <summary>Защищает модель от обратной записи во время отображения.</summary>
    private bool _loading;
    /// <summary>Редактор имени.</summary>
    private readonly TextBox FullNameTextBox = new() { Name = "FullNameTextBox", Dock = DockStyle.Fill };
    /// <summary>Редактор телефона.</summary>
    private readonly TextBox PhoneNumberTextBox = new() { Name = "PhoneNumberTextBox", Dock = DockStyle.Fill };
    /// <summary>Редактор адреса.</summary>
    private readonly TextBox AddressTextBox = new() { Name = "AddressTextBox", Dock = DockStyle.Fill };

    /// <summary>При замене отписывается от прежнего контакта и подписывается на новый.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Contact? Contact
    {
        get => _contact;
        set
        {
            if (_contact != null)
            {
                _contact.FullNameChanged -= Contact_FullNameChanged;
                _contact.PhoneNumberChanged -= Contact_PhoneNumberChanged;
                _contact.AddressChanged -= Contact_AddressChanged;
            }
            _contact = value;
            if (_contact != null)
            {
                _contact.FullNameChanged += Contact_FullNameChanged;
                _contact.PhoneNumberChanged += Contact_PhoneNumberChanged;
                _contact.AddressChanged += Contact_AddressChanged;
            }
            ShowContact();
        }
    }

    /// <summary>Создаёт окно по макету задания с тремя полями и кнопкой Close.</summary>
    public EventForm()
    {
        Text = "Main Window";
        ClientSize = new Size(300, 310);
        MinimumSize = new Size(290, 320);
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 1, RowCount = 8 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        Control[] fields =
        {
            new Label { Text = "Full Name:", AutoSize = true }, FullNameTextBox,
            new Label { Text = "Phone Number:", AutoSize = true }, PhoneNumberTextBox,
            new Label { Text = "Address:", AutoSize = true }, AddressTextBox
        };
        for (int i = 0; i < fields.Length; i++)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, i % 2 == 0 ? 25 : 32));
            layout.Controls.Add(fields[i], 0, i);
        }
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
        var close = new Button { Name = "CloseButton", Text = "Close", Anchor = AnchorStyles.Right };
        close.Click += (_, _) => Close();
        layout.Controls.Add(close, 0, 7);
        Controls.Add(layout);
        FullNameTextBox.TextChanged += (_, _) => { if (!_loading && _contact != null) _contact.FullName = FullNameTextBox.Text; };
        PhoneNumberTextBox.TextChanged += (_, _) => { if (!_loading && _contact != null) _contact.PhoneNumber = PhoneNumberTextBox.Text; };
        AddressTextBox.TextChanged += (_, _) => { if (!_loading && _contact != null) _contact.Address = AddressTextBox.Text; };
        ShowContact();
    }

    /// <summary>Обновляет только поле имени, сохраняя позицию ввода в исходном окне.</summary>
    private void Contact_FullNameChanged(object? sender, EventArgs e) => SetText(FullNameTextBox, _contact?.FullName ?? "");
    /// <summary>Обновляет телефон при событии модели.</summary>
    private void Contact_PhoneNumberChanged(object? sender, EventArgs e) => SetText(PhoneNumberTextBox, _contact?.PhoneNumber ?? "");
    /// <summary>Обновляет адрес при событии модели.</summary>
    private void Contact_AddressChanged(object? sender, EventArgs e) => SetText(AddressTextBox, _contact?.Address ?? "");

    /// <summary>Отображает одно значение без обратного изменения модели.</summary>
    private void SetText(TextBox editor, string value)
    {
        if (editor.Text == value) return;
        _loading = true;
        try { editor.Text = value; }
        finally { _loading = false; }
    }

    /// <summary>Отображает заменённую модель и доступность полей.</summary>
    private void ShowContact()
    {
        SetText(FullNameTextBox, _contact?.FullName ?? "");
        SetText(PhoneNumberTextBox, _contact?.PhoneNumber ?? "");
        SetText(AddressTextBox, _contact?.Address ?? "");
        FullNameTextBox.Enabled = PhoneNumberTextBox.Enabled = AddressTextBox.Enabled = _contact != null;
    }

    /// <summary>Освобождает подписки до уничтожения окна.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) Contact = null;
        base.Dispose(disposing);
    }
}
