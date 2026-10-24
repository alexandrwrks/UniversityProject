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
        MainTabControl = new TabControl();
        ItemsTabPage = new TabPage();
        ItemsTabControl = new UniversityProject.View.Tabs.ItemsTab();
        CustomersTabPage = new TabPage();
        CustomersTabControl = new UniversityProject.View.Tabs.CustomersTab();
        CartsTabPage = new TabPage();
        CartsTabControl = new UniversityProject.View.Tabs.CartsTab();
        OrdersTabPage = new TabPage();
        OrdersTabControl = new UniversityProject.View.Tabs.OrdersTab();
        MainTabControl.SuspendLayout();
        ItemsTabPage.SuspendLayout();
        CustomersTabPage.SuspendLayout();
        SuspendLayout();
        // 
        // MainTabControl
        // 
        MainTabControl.Controls.Add(ItemsTabPage);
        MainTabControl.Controls.Add(CustomersTabPage);
        CartsTabPage.Text = "Carts";
        CartsTabPage.Name = "CartsTabPage";
        CartsTabPage.UseVisualStyleBackColor = true;
        CartsTabPage.Controls.Add(CartsTabControl);
        CartsTabControl.Dock = DockStyle.Fill;
        OrdersTabPage.Text = "Orders";
        OrdersTabPage.Name = "OrdersTabPage";
        OrdersTabPage.UseVisualStyleBackColor = true;
        OrdersTabPage.Controls.Add(OrdersTabControl);
        OrdersTabControl.Dock = DockStyle.Fill;
        MainTabControl.Controls.Add(CartsTabPage);
        MainTabControl.Controls.Add(OrdersTabPage);
        MainTabControl.Dock = DockStyle.Fill;
        MainTabControl.Location = new Point(0, 0);
        MainTabControl.Name = "MainTabControl";
        MainTabControl.SelectedIndex = 0;
        MainTabControl.Size = new Size(800, 450);
        MainTabControl.TabIndex = 0;
        // 
        // ItemsTabPage
        // 
        ItemsTabPage.Controls.Add(ItemsTabControl);
        ItemsTabPage.Location = new Point(4, 24);
        ItemsTabPage.Name = "ItemsTabPage";
        ItemsTabPage.Padding = new Padding(3);
        ItemsTabPage.Size = new Size(792, 422);
        ItemsTabPage.TabIndex = 0;
        ItemsTabPage.Text = "Items";
        ItemsTabPage.UseVisualStyleBackColor = true;
        // 
        // ItemsTabControl
        // 
        ItemsTabControl.Dock = DockStyle.Fill;
        ItemsTabControl.Location = new Point(3, 3);
        ItemsTabControl.Name = "ItemsTabControl";
        ItemsTabControl.Size = new Size(786, 416);
        ItemsTabControl.TabIndex = 0;
        // 
        // CustomersTabPage
        // 
        CustomersTabPage.Controls.Add(CustomersTabControl);
        CustomersTabPage.Location = new Point(4, 24);
        CustomersTabPage.Name = "CustomersTabPage";
        CustomersTabPage.Padding = new Padding(3);
        CustomersTabPage.Size = new Size(792, 422);
        CustomersTabPage.TabIndex = 1;
        CustomersTabPage.Text = "Customers";
        CustomersTabPage.UseVisualStyleBackColor = true;
        // 
        // CustomersTabControl
        // 
        CustomersTabControl.Dock = DockStyle.Fill;
        CustomersTabControl.Location = new Point(3, 3);
        CustomersTabControl.Name = "CustomersTabControl";
        CustomersTabControl.Size = new Size(786, 416);
        CustomersTabControl.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(MainTabControl);
        Name = "MainForm";
        Text = "Form1";
        MainTabControl.ResumeLayout(false);
        ItemsTabPage.ResumeLayout(false);
        CustomersTabPage.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TabControl MainTabControl;
    private TabPage ItemsTabPage;
    private TabPage CustomersTabPage;
    private View.Tabs.ItemsTab ItemsTabControl;
    private View.Tabs.CustomersTab CustomersTabControl;
    /// <summary>Вкладка корзин.</summary>
    private TabPage CartsTabPage;
    /// <summary>Управление корзинами.</summary>
    private UniversityProject.View.Tabs.CartsTab CartsTabControl;
    /// <summary>Вкладка заказов.</summary>
    private TabPage OrdersTabPage;
    /// <summary>Управление заказами.</summary>
    private UniversityProject.View.Tabs.OrdersTab OrdersTabControl;
}
