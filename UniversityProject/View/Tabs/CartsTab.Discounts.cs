using UniversityProject.Model;

namespace UniversityProject.View.Tabs;

public partial class CartsTab
{
    /// <summary>Выбор скидок через единый интерфейс.</summary>
    private readonly CheckedListBox DiscountsCheckedListBox = new()
    {
        Name = "DiscountsCheckedListBox", Dock = DockStyle.Fill, BorderStyle = BorderStyle.None,
        BackColor = SystemColors.Control, CheckOnClick = true, IntegralHeight = false,
        DisplayMember = nameof(IDiscount.Info), HorizontalScrollbar = true
    };
    /// <summary>Сумма выбранных скидок.</summary>
    private readonly Label DiscountAmountLabel = new() { Name = "DiscountAmountLabel", AutoSize = true };
    /// <summary>Итоговая стоимость корзины.</summary>
    private readonly Label TotalLabel = new() { Name = "TotalLabel", AutoSize = true };
    /// <summary>Предотвращает расчёт во время заполнения списка.</summary>
    private bool _loadingDiscounts;
    /// <summary>Покупатель, для которого заполнен список скидок.</summary>
    private Customer? _discountCustomer;

    /// <summary>Создаёт панель скидок и итогов под кнопками корзины.</summary>
    private void InitializeDiscounts()
    {
        CartLayout.AutoScroll = true;
        CartLayout.RowCount = 7;
        CartLayout.RowStyles[6] = new RowStyle(SizeType.Absolute, 215);
        var layout = new TableLayoutPanel { Name = "DiscountsLayout", Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 3 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        layout.Controls.Add(new Label { Text = "Discounts:", AutoSize = true, Font = new Font(Font, FontStyle.Bold) }, 0, 0);
        layout.Controls.Add(DiscountsCheckedListBox, 0, 1);
        var discountPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown };
        discountPanel.Controls.Add(new Label { Text = "Discount Amount:", AutoSize = true });
        discountPanel.Controls.Add(DiscountAmountLabel);
        layout.Controls.Add(discountPanel, 1, 1);
        var totalPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
        TotalLabel.Font = new Font(Font.FontFamily, 14, FontStyle.Bold);
        totalPanel.Controls.Add(TotalLabel);
        totalPanel.Controls.Add(new Label { Text = "TOTAL:", AutoSize = true, Margin = new Padding(3, 8, 3, 3) });
        layout.Controls.Add(totalPanel, 0, 2);
        layout.SetColumnSpan(totalPanel, 2);
        CartLayout.Controls.Add(layout, 0, 6);
        DiscountsCheckedListBox.ItemCheck += (_, e) =>
        {
            if (!_loadingDiscounts) UpdateDiscountTotals(e.Index, e.NewValue);
        };
    }

    /// <summary>Сохраняет выбор скидок текущего покупателя; новый получает все галочки.</summary>
    private void ShowDiscounts(bool reset)
    {
        var uncheckedDiscounts = new HashSet<IDiscount>(ReferenceEqualityComparer.Instance);
        if (!reset && ReferenceEquals(_discountCustomer, CurrentCustomer))
            for (int i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
                if (!DiscountsCheckedListBox.GetItemChecked(i))
                    uncheckedDiscounts.Add((IDiscount)DiscountsCheckedListBox.Items[i]);
        _loadingDiscounts = true;
        DiscountsCheckedListBox.Items.Clear();
        if (CurrentCustomer != null)
            foreach (IDiscount discount in CurrentCustomer.Discounts)
                DiscountsCheckedListBox.Items.Add(discount, !uncheckedDiscounts.Contains(discount));
        _discountCustomer = CurrentCustomer;
        _loadingDiscounts = false;
    }

    /// <summary>Учитывает новое состояние галочки до изменения коллекции CheckedItems.</summary>
    private void UpdateDiscountTotals(int changingIndex = -1, CheckState newValue = CheckState.Unchecked)
    {
        double amount = 0;
        if (CurrentCustomer != null)
            for (int i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
            {
                bool selected = i == changingIndex ? newValue == CheckState.Checked : DiscountsCheckedListBox.GetItemChecked(i);
                if (selected) amount += ((IDiscount)DiscountsCheckedListBox.Items[i]).Calculate(CurrentCustomer.Cart.Items);
            }
        DiscountAmountLabel.Text = amount.ToString("N2");
        TotalLabel.Text = ((CurrentCustomer?.Cart.Amount ?? 0) - amount).ToString("N2");
    }
}
