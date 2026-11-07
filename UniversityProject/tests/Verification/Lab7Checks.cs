using UniversityProject.Model;
using UniversityProject.Model.Enums;
using UniversityProject.Services;
using UniversityProject.View.Tabs;

internal static partial class Program
{
    private static void VerifyLab7()
    {
        var a = new Item("Beta", "", 5000, Category.Food);
        var b = new Item("Alpha", "", 6000, Category.Electronics);
        var c = new Item("Alphabet", "", 10, Category.Books);
        var d = new Item("Same cost", "", 10, Category.Books);
        var items = new List<Item> { a, b, c, d };
        Check(DataTools.Filter(items, DataTools.CostAbove5000).SequenceEqual(new[] { b }), "Strict 5000 filter");
        Check(DataTools.Filter(items, DataTools.IsElectronics).SequenceEqual(new[] { b }), "Category filter");
        Check(DataTools.Filter(items, _ => false).Count == 0 && DataTools.Filter(items, _ => true).Count == 4, "External predicates");
        Check(DataTools.Sort(items, DataTools.NameAscending).SequenceEqual(new[] { b, c, a, d }), "Name sort");
        Check(DataTools.Sort(items, DataTools.CostAscending).SequenceEqual(new[] { c, d, a, b }), "Stable ascending sort");
        Check(DataTools.Sort(items, DataTools.CostDescending).SequenceEqual(new[] { b, a, c, d }), "Stable descending sort");
        Check(items.SequenceEqual(new[] { a, b, c, d }), "Algorithms changed source");
        Check(DataTools.Sort(new(), DataTools.CostAscending).Count == 0, "Empty sort");
        Reject(() => DataTools.Filter(null!, _ => true));
        Reject(() => DataTools.Filter(items, null!));
        Reject(() => DataTools.Sort(null!, DataTools.CostAscending));
        Reject(() => DataTools.Sort(items, null!));
        using var tab = new ItemsTab { Items = items };
        var list = Field<ListBox>(tab, "ItemsListBox");
        var search = Field<TextBox>(tab, "SearchTextBox");
        var sort = Field<ComboBox>(tab, "SortComboBox");
        Check(ReferenceEquals(list.Items[0], b) && sort.SelectedIndex == 0, "Default name order");
        list.SelectedItem = c;
        search.Text = "ALPH";
        Check(list.Items.Count == 2 && ReferenceEquals(list.SelectedItem, c), "Case-insensitive filter selection");
        sort.SelectedIndex = 2;
        Check(list.Items.Count == 2 && ReferenceEquals(list.Items[0], b) && ReferenceEquals(list.SelectedItem, c), "Filter and sort selection");
        Field<TextBox>(tab, "CostTextBox").Text = "7000";
        Check(c.Cost == 7000 && b.Cost == 6000 && ReferenceEquals(list.Items[0], c) && ReferenceEquals(list.SelectedItem, c), "Edit filtered sorted item");
        Field<Button>(tab, "RemoveButton").PerformClick();
        Check(!items.Contains(c) && items.Contains(a) && items.Contains(b), "Delete correct filtered item");
        search.Text = "No matches";
        Check(list.Items.Count == 0 && !Field<TextBox>(tab, "NameTextBox").Enabled, "Empty search state");
        search.Clear();
        Check(list.Items.Count == 3 && sort.SelectedIndex == 2 && ReferenceEquals(list.Items[0], b), "Clear search retains order");
        search.Text = "Beta";
        list.SelectedItem = a;
        Field<TextBox>(tab, "NameTextBox").Text = "Else";
        Check(a.Name == "Else" && list.Items.Count == 0 && !Field<TextBox>(tab, "NameTextBox").Enabled, "Rename leaves filter");
        Field<Button>(tab, "AddButton").PerformClick();
        Check(search.Text == "" && list.SelectedItem is Item && items.Count == 4, "Add while filtered");
        Directory.CreateDirectory("tmp/lab7");
        using var form = new Form { ClientSize = new Size(820, 490), ShowInTaskbar = false, StartPosition = FormStartPosition.Manual, Location = new Point(-3000, -3000) };
        tab.Dock = DockStyle.Fill;
        form.Controls.Add(tab);
        form.Show();
        Application.DoEvents();
        using var bitmap = new Bitmap(form.Width, form.Height);
        form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
        bitmap.Save("tmp/lab7/items.png");
        Check(search.Width > 100 && sort.Width > 100 && list.Height > 100, "Search layout");
        form.Close();
    }
}
