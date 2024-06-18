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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logoutButton = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cMenuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteClass = new System.Windows.Forms.ToolStripMenuItem();
            this.rbtnAddClass = new gradesBookApp.RoundedButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoutButton)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMenuDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::gradesBookApp.Properties.Resources.BG_Color__5454542;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.361371F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.96573F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.776739F));
            this.tableLayoutPanel1.Controls.Add(this.logoutButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.89957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.156384F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.751794F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.45337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.738881F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 858);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoutButton.BackColor = System.Drawing.Color.Transparent;
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.Image = global::gradesBookApp.Properties.Resources.k__2_;
            this.logoutButton.Location = new System.Drawing.Point(1227, 5);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(51, 73);
            this.logoutButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoutButton.TabIndex = 71;
            this.logoutButton.TabStop = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.rbtnAddClass);
            this.panel2.Location = new System.Drawing.Point(58, 188);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 617);
            this.panel2.TabIndex = 76;
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
            // rbtnAddClass
            // 
            this.rbtnAddClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtnAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAddClass.FlatAppearance.BorderSize = 0;
            this.rbtnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddClass.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAddClass.ForeColor = System.Drawing.Color.White;
            this.rbtnAddClass.Location = new System.Drawing.Point(921, 84);
            this.rbtnAddClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnAddClass.Name = "rbtnAddClass";
            this.rbtnAddClass.Size = new System.Drawing.Size(151, 48);
            this.rbtnAddClass.TabIndex = 77;
            this.rbtnAddClass.Text = "Add Subject";
            this.rbtnAddClass.UseVisualStyleBackColor = false;
            this.rbtnAddClass.Click += new System.EventHandler(this.rbtnAddClass_Click);
            // 
            // TheFacultyDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1284, 858);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TheFacultyDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faculty Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TheFacultyDashboard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoutButton)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMenuDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTipHome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox logoutButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteClass;
        private RoundedButton rbtnAddClass;
    }
}