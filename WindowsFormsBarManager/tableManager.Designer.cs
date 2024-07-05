namespace WindowsFormsBarManager
{
    partial class tableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ViewOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.cbxSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnChangeTable = new System.Windows.Forms.Button();
            this.numberDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numberDrinkQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbxDrinks = new System.Windows.Forms.ComboBox();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberDrinkQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.accountInformationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(935, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // accountInformationToolStripMenuItem
            // 
            this.accountInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userInformationToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountInformationToolStripMenuItem.Name = "accountInformationToolStripMenuItem";
            this.accountInformationToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.accountInformationToolStripMenuItem.Text = "Account Information";
            // 
            // userInformationToolStripMenuItem
            // 
            this.userInformationToolStripMenuItem.Name = "userInformationToolStripMenuItem";
            this.userInformationToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.userInformationToolStripMenuItem.Text = "User Information";
            this.userInformationToolStripMenuItem.Click += new System.EventHandler(this.userInformationToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ViewOrder);
            this.panel2.Location = new System.Drawing.Point(490, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 280);
            this.panel2.TabIndex = 0;
            // 
            // ViewOrder
            // 
            this.ViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.ViewOrder.GridLines = true;
            this.ViewOrder.HideSelection = false;
            this.ViewOrder.Location = new System.Drawing.Point(3, 3);
            this.ViewOrder.Name = "ViewOrder";
            this.ViewOrder.Size = new System.Drawing.Size(424, 277);
            this.ViewOrder.TabIndex = 0;
            this.ViewOrder.UseCompatibleStateImageBehavior = false;
            this.ViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Drink Name";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 84;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total";
            this.columnHeader4.Width = 115;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.cbxSwitchTable);
            this.panel3.Controls.Add(this.btnChangeTable);
            this.panel3.Controls.Add(this.numberDiscount);
            this.panel3.Controls.Add(this.btnDiscount);
            this.panel3.Controls.Add(this.btnCheckout);
            this.panel3.Location = new System.Drawing.Point(489, 423);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(429, 83);
            this.panel3.TabIndex = 0;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(222, 33);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(94, 22);
            this.txtTotalPrice.TabIndex = 0;
            this.txtTotalPrice.Text = "0";
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxSwitchTable
            // 
            this.cbxSwitchTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSwitchTable.FormattingEnabled = true;
            this.cbxSwitchTable.Location = new System.Drawing.Point(4, 52);
            this.cbxSwitchTable.Name = "cbxSwitchTable";
            this.cbxSwitchTable.Size = new System.Drawing.Size(103, 28);
            this.cbxSwitchTable.TabIndex = 3;
            // 
            // btnChangeTable
            // 
            this.btnChangeTable.Location = new System.Drawing.Point(4, 12);
            this.btnChangeTable.Name = "btnChangeTable";
            this.btnChangeTable.Size = new System.Drawing.Size(103, 34);
            this.btnChangeTable.TabIndex = 6;
            this.btnChangeTable.Text = "Change Table";
            this.btnChangeTable.UseVisualStyleBackColor = true;
            // 
            // numberDiscount
            // 
            this.numberDiscount.Location = new System.Drawing.Point(113, 52);
            this.numberDiscount.Name = "numberDiscount";
            this.numberDiscount.Size = new System.Drawing.Size(103, 22);
            this.numberDiscount.TabIndex = 5;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(113, 12);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(103, 34);
            this.btnDiscount.TabIndex = 4;
            this.btnDiscount.Text = "Discount";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(322, 10);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(103, 68);
            this.btnCheckout.TabIndex = 3;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numberDrinkQuantity);
            this.panel4.Controls.Add(this.btnAdd);
            this.panel4.Controls.Add(this.cbxDrinks);
            this.panel4.Controls.Add(this.cbxCategory);
            this.panel4.Location = new System.Drawing.Point(490, 41);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(429, 90);
            this.panel4.TabIndex = 2;
            // 
            // numberDrinkQuantity
            // 
            this.numberDrinkQuantity.Location = new System.Drawing.Point(232, 36);
            this.numberDrinkQuantity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numberDrinkQuantity.Name = "numberDrinkQuantity";
            this.numberDrinkQuantity.Size = new System.Drawing.Size(72, 22);
            this.numberDrinkQuantity.TabIndex = 2;
            this.numberDrinkQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(310, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 62);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add order";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbxDrinks
            // 
            this.cbxDrinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDrinks.FormattingEnabled = true;
            this.cbxDrinks.Location = new System.Drawing.Point(14, 49);
            this.cbxDrinks.Name = "cbxDrinks";
            this.cbxDrinks.Size = new System.Drawing.Size(209, 28);
            this.cbxDrinks.TabIndex = 1;
            // 
            // cbxCategory
            // 
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(14, 15);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(209, 28);
            this.cbxCategory.TabIndex = 0;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(12, 41);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(472, 465);
            this.flpTable.TabIndex = 3;
            // 
            // tableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 520);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "tableManager";
            this.Text = "Bar Management System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numberDrinkQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView ViewOrder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numberDrinkQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbxDrinks;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.NumericUpDown numberDiscount;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.ComboBox cbxSwitchTable;
        private System.Windows.Forms.Button btnChangeTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtTotalPrice;
    }
}