namespace gradesBookApp
{
    partial class TheCourseDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheCourseDashboard));
            this.toolTipHome = new System.Windows.Forms.ToolTip(this.components);
            this.cMenuDeleteProgram = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnAddClass = new gradesBookApp.RoundedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.PictureBox();
            this.cMenuDeleteProgram.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoutButton)).BeginInit();
            this.SuspendLayout();
            // 
            // cMenuDeleteProgram
            // 
            this.cMenuDeleteProgram.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMenuDeleteProgram.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteProgramToolStripMenuItem});
            this.cMenuDeleteProgram.Name = "cMenuDeleteProgram";
            this.cMenuDeleteProgram.Size = new System.Drawing.Size(253, 28);
            // 
            // deleteProgramToolStripMenuItem
            // 
            this.deleteProgramToolStripMenuItem.Name = "deleteProgramToolStripMenuItem";
            this.deleteProgramToolStripMenuItem.Size = new System.Drawing.Size(252, 24);
            this.deleteProgramToolStripMenuItem.Text = "Delete Program && Section";
            this.deleteProgramToolStripMenuItem.Click += new System.EventHandler(this.deleteProgramToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::gradesBookApp.Properties.Resources.BG_Color__5454541;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.476635F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.65732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.619938F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.168224F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.picHome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.909065F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.583024F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.233037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.53049F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.744385F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 858);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(110)))));
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(446, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(386, 85);
            this.label7.TabIndex = 87;
            this.label7.Text = "COURSE DASHBOARD";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.rbtnAddClass);
            this.panel1.Location = new System.Drawing.Point(116, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 56);
            this.panel1.TabIndex = 88;
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
            this.rbtnAddClass.Location = new System.Drawing.Point(875, 8);
            this.rbtnAddClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnAddClass.Name = "rbtnAddClass";
            this.rbtnAddClass.Size = new System.Drawing.Size(173, 48);
            this.rbtnAddClass.TabIndex = 77;
            this.rbtnAddClass.Text = "Add Section";
            this.rbtnAddClass.UseVisualStyleBackColor = false;
            this.rbtnAddClass.Click += new System.EventHandler(this.rbtnAddClass_Click_1);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(99, 214);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 592);
            this.panel2.TabIndex = 76;
            // 
            // picHome
            // 
            this.picHome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picHome.BackColor = System.Drawing.Color.Transparent;
            this.picHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHome.Image = global::gradesBookApp.Properties.Resources.k__1_1;
            this.picHome.Location = new System.Drawing.Point(19, 14);
            this.picHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(74, 56);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 74;
            this.picHome.TabStop = false;
            this.toolTipHome.SetToolTip(this.picHome, "Home");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.logoutButton);
            this.panel3.Location = new System.Drawing.Point(1186, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(55, 79);
            this.panel3.TabIndex = 89;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.Transparent;
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoutButton.Image = global::gradesBookApp.Properties.Resources.BULACAN__5___1_;
            this.logoutButton.Location = new System.Drawing.Point(0, 0);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(55, 79);
            this.logoutButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoutButton.TabIndex = 71;
            this.logoutButton.TabStop = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // TheCourseDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 858);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TheCourseDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulacan Technological University";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TheCourseDashboard_Load);
            this.cMenuDeleteProgram.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoutButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipHome;
        private System.Windows.Forms.ContextMenuStrip cMenuDeleteProgram;
        private System.Windows.Forms.ToolStripMenuItem deleteProgramToolStripMenuItem;
        private System.Windows.Forms.PictureBox logoutButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedButton rbtnAddClass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picHome;
    }
}