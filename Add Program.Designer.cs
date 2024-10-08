﻿namespace gradesBookApp
{
    partial class Add_Program
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Program));
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.numSection = new System.Windows.Forms.NumericUpDown();
            this.rbtnBack = new gradesBookApp.RoundedButton();
            this.rbtnAdd = new gradesBookApp.RoundedButton();
            this.picBackButton = new System.Windows.Forms.PictureBox();
            this.toolTipHome = new System.Windows.Forms.ToolTip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(219, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 26);
            this.label7.TabIndex = 58;
            this.label7.Text = "ADD PROGRAM";
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
            this.textBox2.Size = new System.Drawing.Size(646, 67);
            this.textBox2.TabIndex = 57;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label4.Location = new System.Drawing.Point(31, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 23);
            this.label4.TabIndex = 61;
            this.label4.Text = "No. of Section per Year Level:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label5.Location = new System.Drawing.Point(31, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 23);
            this.label5.TabIndex = 60;
            this.label5.Text = "Program Duration (Years): ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label6.Location = new System.Drawing.Point(31, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 23);
            this.label6.TabIndex = 59;
            this.label6.Text = "Program Name:";
            // 
            // txtProgramName
            // 
            this.txtProgramName.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramName.Location = new System.Drawing.Point(162, 121);
            this.txtProgramName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(443, 29);
            this.txtProgramName.TabIndex = 62;
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(235, 159);
            this.numYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numYear.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.ReadOnly = true;
            this.numYear.Size = new System.Drawing.Size(369, 29);
            this.numYear.TabIndex = 63;
            this.numYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numSection
            // 
            this.numSection.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSection.Location = new System.Drawing.Point(262, 197);
            this.numSection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numSection.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSection.Name = "numSection";
            this.numSection.ReadOnly = true;
            this.numSection.Size = new System.Drawing.Size(342, 29);
            this.numSection.TabIndex = 64;
            this.numSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtnBack
            // 
            this.rbtnBack.BackColor = System.Drawing.Color.Maroon;
            this.rbtnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBack.FlatAppearance.BorderSize = 0;
            this.rbtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnBack.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBack.ForeColor = System.Drawing.Color.White;
            this.rbtnBack.Location = new System.Drawing.Point(291, 279);
            this.rbtnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnBack.Name = "rbtnBack";
            this.rbtnBack.Size = new System.Drawing.Size(149, 37);
            this.rbtnBack.TabIndex = 66;
            this.rbtnBack.Text = "Cancel";
            this.rbtnBack.UseVisualStyleBackColor = false;
            this.rbtnBack.Click += new System.EventHandler(this.rbtnBack_Click);
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAdd.FlatAppearance.BorderSize = 0;
            this.rbtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAdd.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAdd.ForeColor = System.Drawing.Color.White;
            this.rbtnAdd.Location = new System.Drawing.Point(461, 279);
            this.rbtnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(143, 37);
            this.rbtnAdd.TabIndex = 65;
            this.rbtnAdd.Text = "Add";
            this.rbtnAdd.UseVisualStyleBackColor = false;
            this.rbtnAdd.Click += new System.EventHandler(this.rbtnAdd_Click);
            // 
            // picBackButton
            // 
            this.picBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.picBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackButton.Image = global::gradesBookApp.Properties.Resources.k__1_;
            this.picBackButton.Location = new System.Drawing.Point(12, 12);
            this.picBackButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBackButton.Name = "picBackButton";
            this.picBackButton.Size = new System.Drawing.Size(41, 41);
            this.picBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackButton.TabIndex = 67;
            this.picBackButton.TabStop = false;
            this.toolTipHome.SetToolTip(this.picBackButton, "Home");
            this.picBackButton.Click += new System.EventHandler(this.picBackButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 67);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(646, 14);
            this.textBox1.TabIndex = 68;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Add_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(646, 362);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picBackButton);
            this.Controls.Add(this.rbtnBack);
            this.Controls.Add(this.rbtnAdd);
            this.Controls.Add(this.numSection);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.txtProgramName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Add_Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulacan Technological University";
            this.Load += new System.EventHandler(this.Add_Program_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProgramName;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.NumericUpDown numSection;
        private RoundedButton rbtnBack;
        private RoundedButton rbtnAdd;
        private System.Windows.Forms.PictureBox picBackButton;
        private System.Windows.Forms.ToolTip toolTipHome;
        private System.Windows.Forms.TextBox textBox1;
    }
}