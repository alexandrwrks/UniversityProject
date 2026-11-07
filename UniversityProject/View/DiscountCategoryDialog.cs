using UniversityProject.Model.Enums;

namespace UniversityProject.View;

/// <summary>Выбор категории новой процентной скидки.</summary>
public sealed class DiscountCategoryDialog : Form
{
    /// <summary>Список доступных категорий.</summary>
    private readonly ComboBox _categoryComboBox = new()
    {
        Name = "CategoryComboBox", DropDownStyle = ComboBoxStyle.DropDownList,
        Dock = DockStyle.Fill, DataSource = Enum.GetValues<Category>()
    };

    /// <summary>Категория, подтверждённая пользователем.</summary>
    public Category SelectedCategory => (Category)_categoryComboBox.SelectedItem!;

    /// <summary>Создаёт модальный диалог с подтверждением и отменой.</summary>
    public DiscountCategoryDialog()
    {
        Text = "Add Discount";
        ClientSize = new Size(330, 110);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = MinimizeBox = ShowInTaskbar = false;
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), RowCount = 3 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.Controls.Add(new Label { Text = "Category:", AutoSize = true });
        layout.Controls.Add(_categoryComboBox);
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
        var ok = new Button { Name = "OkButton", Text = "OK", DialogResult = DialogResult.OK };
        var cancel = new Button { Name = "CancelButton", Text = "Cancel", DialogResult = DialogResult.Cancel };
        buttons.Controls.AddRange(new Control[] { ok, cancel });
        layout.Controls.Add(buttons);
        Controls.Add(layout);
        AcceptButton = ok;
        CancelButton = cancel;
    }
}
