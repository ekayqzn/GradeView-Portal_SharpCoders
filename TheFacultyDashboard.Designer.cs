namespace gradesBookApp
{
    partial class TheFacultyDashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheFacultyDashboard));
            this.toolTipHome = new System.Windows.Forms.ToolTip(this.components);
            this.cMenuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteClass = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnAddClass = new gradesBookApp.RoundedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.cMenuDelete.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cMenuDelete
            // 
            this.cMenuDelete.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMenuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteClass});
            this.cMenuDelete.Name = "cMenuDelete";
            this.cMenuDelete.Size = new System.Drawing.Size(160, 28);
            // 
            // menuDeleteClass
            // 
            this.menuDeleteClass.Name = "menuDeleteClass";
            this.menuDeleteClass.Size = new System.Drawing.Size(159, 24);
            this.menuDeleteClass.Text = "Delete Class";
            this.menuDeleteClass.Click += new System.EventHandler(this.menuDeleteClass_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::gradesBookApp.Properties.Resources.BG_Color__5454542;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.320872F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.12461F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.476635F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtnAddClass, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.89957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.643357F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.226107F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.39627F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.738881F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 858);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // rbtnAddClass
            // 
            this.rbtnAddClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtnAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAddClass.FlatAppearance.BorderSize = 0;
            this.rbtnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddClass.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAddClass.ForeColor = System.Drawing.Color.White;
            this.rbtnAddClass.Location = new System.Drawing.Point(1033, 149);
            this.rbtnAddClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnAddClass.Name = "rbtnAddClass";
            this.rbtnAddClass.Size = new System.Drawing.Size(151, 48);
            this.rbtnAddClass.TabIndex = 77;
            this.rbtnAddClass.Text = "Add Subject";
            this.rbtnAddClass.UseVisualStyleBackColor = false;
            this.rbtnAddClass.Click += new System.EventHandler(this.rbtnAddClass_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(97, 206);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 600);
            this.panel2.TabIndex = 76;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenu});
            this.menuStrip1.Location = new System.Drawing.Point(1187, 23);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(54, 38);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 77;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolMenu
            // 
            this.toolMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.toolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPassword,
            this.toolStripSeparator1,
            this.menuLogOut});
            this.toolMenu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenu.Image = global::gradesBookApp.Properties.Resources.BULACAN__5___1_1;
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(44, 34);
            this.toolMenu.ToolTipText = "Menu";
            // 
            // menuPassword
            // 
            this.menuPassword.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuPassword.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.menuPassword.Name = "menuPassword";
            this.menuPassword.Size = new System.Drawing.Size(241, 26);
            this.menuPassword.Text = "Manage Password";
            this.menuPassword.Click += new System.EventHandler(this.menuPassword_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // menuLogOut
            // 
            this.menuLogOut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuLogOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuLogOut.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.menuLogOut.Name = "menuLogOut";
            this.menuLogOut.ShortcutKeyDisplayString = "Ctrl+Shift+L";
            this.menuLogOut.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.menuLogOut.Size = new System.Drawing.Size(241, 26);
            this.menuLogOut.Text = "Log Out";
            this.menuLogOut.Click += new System.EventHandler(this.menuLogOut_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(110)))));
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(441, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(398, 85);
            this.label7.TabIndex = 88;
            this.label7.Text = "TEACHER DASHBOARD";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TheFacultyDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1284, 858);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TheFacultyDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulacan Technological University";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TheFacultyDashboard_Load);
            this.cMenuDelete.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTipHome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteClass;
        private RoundedButton rbtnAddClass;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolMenu;
        private System.Windows.Forms.ToolStripMenuItem menuPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuLogOut;
        private System.Windows.Forms.Label label7;
    }
}