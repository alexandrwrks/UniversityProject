namespace UniversityProject.View.Tabs
{
    partial class ItemsTab
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
            splitContainer3 = new SplitContainer();
            label1 = new Label();
            ItemsListBox = new ListBox();
            splitContainer4 = new SplitContainer();
            addButton = new Button();
            splitContainer5 = new SplitContainer();
            removeButton = new Button();
            textBoxDescription = new TextBox();
            label6 = new Label();
            textBoxName = new TextBox();
            label5 = new Label();
            textBoxCost = new TextBox();
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
            splitContainer1.Panel2.Controls.Add(textBoxDescription);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(textBoxName);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(textBoxCost);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(textBoxID);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 322;
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
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer4);
            splitContainer2.Size = new Size(322, 450);
            splitContainer2.SplitterDistance = 395;
            splitContainer2.TabIndex = 0;
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
            splitContainer3.Panel1.Controls.Add(label1);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(ItemsListBox);
            splitContainer3.Size = new Size(322, 395);
            splitContainer3.SplitterDistance = 35;
            splitContainer3.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Items";
            // 
            // ItemsListBox
            // 
            ItemsListBox.Dock = DockStyle.Fill;
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(0, 0);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(322, 356);
            ItemsListBox.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(addButton);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(splitContainer5);
            splitContainer4.Size = new Size(322, 51);
            splitContainer4.SplitterDistance = 96;
            splitContainer4.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Fill;
            addButton.Location = new Point(0, 0);
            addButton.Name = "addButton";
            addButton.Size = new Size(96, 51);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(removeButton);
            splitContainer5.Size = new Size(222, 51);
            splitContainer5.SplitterDistance = 99;
            splitContainer5.TabIndex = 0;
            // 
            // removeButton
            // 
            removeButton.Dock = DockStyle.Fill;
            removeButton.Location = new Point(0, 0);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(99, 51);
            removeButton.TabIndex = 0;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(19, 224);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(443, 118);
            textBoxDescription.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 201);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 7;
            label6.Text = "Description:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(14, 118);
            textBoxName.Multiline = true;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(448, 80);
            textBoxName.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 100);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 5;
            label5.Text = "Name:";
            // 
            // textBoxCost
            // 
            textBoxCost.Location = new Point(54, 59);
            textBoxCost.Name = "textBoxCost";
            textBoxCost.Size = new Size(131, 23);
            textBoxCost.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 67);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 3;
            label4.Text = "Cost:";
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(54, 30);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(131, 23);
            textBoxID.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 39);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 1;
            label3.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 9);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 0;
            label2.Text = "Selected Items";
            // 
            // ItemsTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "ItemsTab";
            Size = new Size(800, 450);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
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
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private Button addButton;
        private SplitContainer splitContainer5;
        private Button removeButton;
        private Label label1;
        private ListBox ItemsListBox;
        private Label label2;
        private Label label4;
        private TextBox textBoxID;
        private Label label3;
        private TextBox textBoxDescription;
        private Label label6;
        private TextBox textBoxName;
        private Label label5;
        private TextBox textBoxCost;
    }
}