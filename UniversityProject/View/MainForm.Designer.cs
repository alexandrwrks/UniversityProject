namespace UniversityProject;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl1 = new TabControl();
        ItemsTabPage = new TabPage();
        items1 = new UniversityProject.View.Tabs.ItemsTab();
        CustomersTabPage = new TabPage();
        customers1 = new UniversityProject.View.Tabs.CustomersTab();
        tabControl1.SuspendLayout();
        ItemsTabPage.SuspendLayout();
        CustomersTabPage.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(ItemsTabPage);
        tabControl1.Controls.Add(CustomersTabPage);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(800, 450);
        tabControl1.TabIndex = 0;
        // 
        // ItemsTabPage
        // 
        ItemsTabPage.Controls.Add(items1);
        ItemsTabPage.Location = new Point(4, 24);
        ItemsTabPage.Name = "ItemsTabPage";
        ItemsTabPage.Padding = new Padding(3);
        ItemsTabPage.Size = new Size(792, 422);
        ItemsTabPage.TabIndex = 0;
        ItemsTabPage.Text = "Items";
        ItemsTabPage.UseVisualStyleBackColor = true;
        // 
        // items1
        // 
        items1.Dock = DockStyle.Fill;
        items1.Location = new Point(3, 3);
        items1.Name = "items1";
        items1.Size = new Size(786, 416);
        items1.TabIndex = 0;
        // 
        // CustomersTabPage
        // 
        CustomersTabPage.Controls.Add(customers1);
        CustomersTabPage.Location = new Point(4, 24);
        CustomersTabPage.Name = "CustomersTabPage";
        CustomersTabPage.Padding = new Padding(3);
        CustomersTabPage.Size = new Size(792, 422);
        CustomersTabPage.TabIndex = 1;
        CustomersTabPage.Text = "Customers";
        CustomersTabPage.UseVisualStyleBackColor = true;
        // 
        // customers1
        // 
        customers1.Dock = DockStyle.Fill;
        customers1.Location = new Point(3, 3);
        customers1.Name = "customers1";
        customers1.Size = new Size(786, 416);
        customers1.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tabControl1);
        Name = "MainForm";
        Text = "Form1";
        tabControl1.ResumeLayout(false);
        ItemsTabPage.ResumeLayout(false);
        CustomersTabPage.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage ItemsTabPage;
    private TabPage CustomersTabPage;
    private View.Tabs.ItemsTab items1;
    private View.Tabs.CustomersTab customers1;
}
