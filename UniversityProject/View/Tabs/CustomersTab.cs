using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniversityProject.Model;

namespace UniversityProject.View.Tabs;

public partial class CustomersTab : UserControl
{
    BindingList<Customers> customers = new BindingList<Customers>();
    public CustomersTab()
    {
        InitializeComponent();
        CustomersListBox.DataSource = customers;
    }

    private void buttonRemove_Click(object sender, EventArgs e)
    {
        if (CustomersListBox.SelectedItem is Customers customer)
        {
            customers.Remove(customer);
        }
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
        Customers newCustomer = new Customers(textBoxFullaName.Text, textBoxAddress.Text);

        customers.Add(newCustomer);
    }
}
