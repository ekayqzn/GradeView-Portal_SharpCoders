namespace gradesBookApp
{
    partial class Teacher_s_Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.LinkLBLlogout = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbtnAddSubject = new gradesBookApp.RoundedButton();
            this.TDB_Bg = new gradesBookApp.RoundedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rbtnAddSubject);
            this.panel1.Controls.Add(this.LinkLBLlogout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.TDB_Bg);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 942);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(28, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(598, 32);
            this.label4.TabIndex = 54;
            this.label4.Tag = "";
            this.label4.Text = " BULACAN TECHNOLOGICAL UNIVERSITY";
            // 
            // LinkLBLlogout
            // 
            this.LinkLBLlogout.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.LinkLBLlogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkLBLlogout.AutoSize = true;
            this.LinkLBLlogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.LinkLBLlogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLBLlogout.LinkColor = System.Drawing.Color.White;
            this.LinkLBLlogout.Location = new System.Drawing.Point(1421, 30);
            this.LinkLBLlogout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LinkLBLlogout.Name = "LinkLBLlogout";
            this.LinkLBLlogout.Size = new System.Drawing.Size(89, 25);
            this.LinkLBLlogout.TabIndex = 44;
            this.LinkLBLlogout.TabStop = true;
            this.LinkLBLlogout.Text = "Log Out";
            this.LinkLBLlogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLBLHome_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(239, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "DASHBOARD";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(-1, -6);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1543, 91);
            this.textBox2.TabIndex = 34;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnAddSubject
            // 
            this.rbtnAddSubject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbtnAddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddSubject.FlatAppearance.BorderSize = 0;
            this.rbtnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAddSubject.ForeColor = System.Drawing.Color.White;
            this.rbtnAddSubject.Location = new System.Drawing.Point(1076, 176);
            this.rbtnAddSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnAddSubject.Name = "rbtnAddSubject";
            this.rbtnAddSubject.Size = new System.Drawing.Size(261, 48);
            this.rbtnAddSubject.TabIndex = 3;
            this.rbtnAddSubject.Text = "Add Subject";
            this.rbtnAddSubject.UseVisualStyleBackColor = false;
            this.rbtnAddSubject.Click += new System.EventHandler(this.rbtnAddSubject_Click);
            // 
            // TDB_Bg
            // 
            this.TDB_Bg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TDB_Bg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TDB_Bg.Enabled = false;
            this.TDB_Bg.FlatAppearance.BorderSize = 0;
            this.TDB_Bg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TDB_Bg.ForeColor = System.Drawing.Color.White;
            this.TDB_Bg.Location = new System.Drawing.Point(179, 142);
            this.TDB_Bg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TDB_Bg.Name = "TDB_Bg";
            this.TDB_Bg.Size = new System.Drawing.Size(1209, 893);
            this.TDB_Bg.TabIndex = 53;
            this.TDB_Bg.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Location = new System.Drawing.Point(246, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 751);
            this.panel2.TabIndex = 55;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::gradesBookApp.Properties.Resources.BULACAN_TECHNOLOGICAL_UNIVERSITY__2_;
            this.pictureBox3.Location = new System.Drawing.Point(-288, -237);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(2370, 1633);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 56;
            this.pictureBox3.TabStop = false;
            // 
            // Teacher_s_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 942);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Teacher_s_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher\'s Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Teacher_s_Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RoundedButton rbtnAddSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.LinkLabel LinkLBLlogout;
        private System.Windows.Forms.Label label4;
        private RoundedButton TDB_Bg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}