using UniversityProject.Model;
using UniversityProject.Model.Discounts;

namespace UniversityProject.View.Tabs;

public partial class CustomersTab
{
    /// <summary>Скидки выбранного покупателя.</summary>
    private readonly ListBox DiscountsListBox = new()
    {
        Name = "DiscountsListBox", Dock = DockStyle.Fill, DisplayMember = nameof(IDiscount.Info),
        IntegralHeight = false, HorizontalScrollbar = true
    };
    /// <summary>Добавление процентной скидки.</summary>
    private readonly Button AddDiscountButton = new() { Name = "AddDiscountButton", Text = "Add", Width = 90 };
    /// <summary>Удаление необязательной скидки.</summary>
    private readonly Button RemoveDiscountButton = new() { Name = "RemoveDiscountButton", Text = "Remove", Width = 90 };

    /// <summary>Добавляет панель скидок под адресом.</summary>
    private void InitializeDiscounts()
    {
        EditorLayout.RowCount = 6;
        EditorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 210));
        var group = new GroupBox { Name = "DiscountsGroupBox", Text = "Discounts", Dock = DockStyle.Fill };
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill };
        buttons.Controls.AddRange(new Control[] { AddDiscountButton, RemoveDiscountButton });
        layout.Controls.Add(DiscountsListBox, 0, 0);
        layout.Controls.Add(buttons, 0, 1);
        group.Controls.Add(layout);
        EditorLayout.Controls.Add(group, 0, 5);
        EditorLayout.SetColumnSpan(group, 2);
        DiscountsListBox.SelectedIndexChanged += (_, _) =>
            RemoveDiscountButton.Enabled = DiscountsListBox.SelectedItem is IDiscount and not PointsDiscount;
        AddDiscountButton.Click += (_, _) =>
        {
            if (CustomersListBox.SelectedItem is not Customer customer) return;
            using var dialog = new DiscountCategoryDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            customer.Discounts.Add(new PercentDiscount(dialog.SelectedCategory));
            ShowDiscounts();
        };
        RemoveDiscountButton.Click += (_, _) =>
        {
            if (CustomersListBox.SelectedItem is not Customer customer ||
                DiscountsListBox.SelectedItem is not IDiscount discount || discount is PointsDiscount) return;
            customer.Discounts.Remove(discount);
            ShowDiscounts();
        };
    }

    /// <summary>Обновляет описания и доступность операций со скидками.</summary>
    private void ShowDiscounts()
    {
        DiscountsListBox.Items.Clear();
        var customer = CustomersListBox.SelectedItem as Customer;
        if (customer != null) DiscountsListBox.Items.AddRange(customer.Discounts.ToArray());
        AddDiscountButton.Enabled = customer != null;
        RemoveDiscountButton.Enabled = false;
    }
}
