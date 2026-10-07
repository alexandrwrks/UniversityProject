namespace UniversityProject.View.Tabs
{
    partial class CustomersTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            label1 = new Label();
            splitContainer3 = new SplitContainer();
            CustomersListBox = new ListBox();
            splitContainer4 = new SplitContainer();
            buttonAdd = new Button();
            splitContainer5 = new SplitContainer();
            buttonRemove = new Button();
            splitContainer6 = new SplitContainer();
            textBoxAddress = new TextBox();
            textBoxFullaName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            textBoxID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer6);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 331;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(label1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(331, 450);
            splitContainer2.SplitterDistance = 29;
            splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Customers";
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(CustomersListBox);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Size = new Size(331, 417);
            splitContainer3.SplitterDistance = 344;
            splitContainer3.TabIndex = 0;
            // 
            // CustomersListBox
            // 
            CustomersListBox.Dock = DockStyle.Fill;
            CustomersListBox.FormattingEnabled = true;
            CustomersListBox.Location = new Point(0, 0);
            CustomersListBox.Name = "CustomersListBox";
            CustomersListBox.Size = new Size(331, 344);
            CustomersListBox.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(buttonAdd);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(splitContainer5);
            splitContainer4.Size = new Size(331, 69);
            splitContainer4.SplitterDistance = 110;
            splitContainer4.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Dock = DockStyle.Fill;
            buttonAdd.Location = new Point(0, 0);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(110, 69);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(buttonRemove);
            splitContainer5.Size = new Size(217, 69);
            splitContainer5.SplitterDistance = 106;
            splitContainer5.TabIndex = 0;
            // 
            // buttonRemove
            // 
            buttonRemove.Dock = DockStyle.Fill;
            buttonRemove.Location = new Point(0, 0);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(106, 69);
            buttonRemove.TabIndex = 0;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // splitContainer6
            // 
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Name = "splitContainer6";
            splitContainer6.Orientation = Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(textBoxAddress);
            splitContainer6.Panel1.Controls.Add(textBoxFullaName);
            splitContainer6.Panel1.Controls.Add(label5);
            splitContainer6.Panel1.Controls.Add(label4);
            splitContainer6.Panel1.Controls.Add(textBoxID);
            splitContainer6.Panel1.Controls.Add(label3);
            splitContainer6.Panel1.Controls.Add(label2);
            splitContainer6.Size = new Size(465, 450);
            splitContainer6.SplitterDistance = 193;
            splitContainer6.TabIndex = 0;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(91, 88);
            textBoxAddress.Multiline = true;
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(371, 95);
            textBoxAddress.TabIndex = 6;
            // 
            // textBoxFullaName
            // 
            textBoxFullaName.Location = new Point(91, 59);
            textBoxFullaName.Name = "textBoxFullaName";
            textBoxFullaName.Size = new Size(371, 23);
            textBoxFullaName.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 84);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 4;
            label5.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 59);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "FullName:";
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(91, 33);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(100, 23);
            textBoxID.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 33);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 1;
            label3.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 10);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 0;
            label2.Text = "Selected Customers";
            // 
            // CustomersTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "CustomersTab";
            Size = new Size(800, 450);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label label1;
        private SplitContainer splitContainer3;
        private ListBox CustomersListBox;
        private SplitContainer splitContainer4;
        private Button buttonAdd;
        private SplitContainer splitContainer5;
        private Button buttonRemove;
        private SplitContainer splitContainer6;
        private TextBox textBoxAddress;
        private TextBox textBoxFullaName;
        private Label label5;
        private Label label4;
        private TextBox textBoxID;
        private Label label3;
        private Label label2;
    }
}