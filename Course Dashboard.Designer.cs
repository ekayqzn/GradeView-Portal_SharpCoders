﻿namespace gradesBookApp
{
    partial class Course_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Course_Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBackButton = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbtnSection = new gradesBookApp.RoundedButton();
            this.TDB_Bg = new gradesBookApp.RoundedButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picBackButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.rbtnSection);
            this.panel1.Controls.Add(this.TDB_Bg);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 765);
            this.panel1.TabIndex = 0;
            // 
            // picBackButton
            // 
            this.picBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.picBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackButton.Image = global::gradesBookApp.Properties.Resources.k__1_;
            this.picBackButton.Location = new System.Drawing.Point(21, 15);
            this.picBackButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBackButton.Name = "picBackButton";
            this.picBackButton.Size = new System.Drawing.Size(41, 41);
            this.picBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackButton.TabIndex = 64;
            this.picBackButton.TabStop = false;
            this.picBackButton.Click += new System.EventHandler(this.picBackButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Location = new System.Drawing.Point(88, 200);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 591);
            this.panel2.TabIndex = 60;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(83, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 35);
            this.label1.TabIndex = 59;
            this.label1.Text = "DASHBOARD";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(460, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(474, 25);
            this.label4.TabIndex = 56;
            this.label4.Tag = "";
            this.label4.Text = " BULACAN TECHNOLOGICAL UNIVERSITY";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(963, 74);
            this.textBox2.TabIndex = 55;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnSection
            // 
            this.rbtnSection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbtnSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSection.FlatAppearance.BorderSize = 0;
            this.rbtnSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSection.ForeColor = System.Drawing.Color.White;
            this.rbtnSection.Location = new System.Drawing.Point(711, 143);
            this.rbtnSection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnSection.Name = "rbtnSection";
            this.rbtnSection.Size = new System.Drawing.Size(196, 39);
            this.rbtnSection.TabIndex = 1;
            this.rbtnSection.Text = "Add Section";
            this.rbtnSection.UseVisualStyleBackColor = false;
            this.rbtnSection.Click += new System.EventHandler(this.rbtnSection_Click);
            // 
            // TDB_Bg
            // 
            this.TDB_Bg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TDB_Bg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TDB_Bg.Enabled = false;
            this.TDB_Bg.FlatAppearance.BorderSize = 0;
            this.TDB_Bg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TDB_Bg.ForeColor = System.Drawing.Color.White;
            this.TDB_Bg.Location = new System.Drawing.Point(38, 115);
            this.TDB_Bg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TDB_Bg.Name = "TDB_Bg";
            this.TDB_Bg.Size = new System.Drawing.Size(907, 726);
            this.TDB_Bg.TabIndex = 58;
            this.TDB_Bg.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::gradesBookApp.Properties.Resources.BULACAN_TECHNOLOGICAL_UNIVERSITY__2_;
            this.pictureBox3.Location = new System.Drawing.Point(-216, -193);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1395, 1151);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 57;
            this.pictureBox3.TabStop = false;
            // 
            // Course_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 765);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Course_Dashboard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulacan Technological University";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Course_Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RoundedButton rbtnSection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private RoundedButton TDB_Bg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picBackButton;
    }
}