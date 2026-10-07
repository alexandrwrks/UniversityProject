using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UniversityProject.Model;

namespace UniversityProject.View.Tabs;

public partial class ItemsTab : UserControl
{
    BindingList<Items> items = new BindingList<Items>();
    public ItemsTab()
    {
        InitializeComponent();
        ItemsListBox.DataSource = items;
    }

    private void removeButton_Click(object sender, EventArgs e)
    {
        if (ItemsListBox.SelectedItem is Items item) { 
            items.Remove(item);
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        double cost = double.Parse(textBoxCost.Text);
        Items newItems = new Items(textBoxName.Text, textBoxDescription.Text, cost);

        items.Add(newItems);

        textBoxCost.Clear();
        textBoxName.Clear();
        textBoxDescription.Clear();
    }
}
