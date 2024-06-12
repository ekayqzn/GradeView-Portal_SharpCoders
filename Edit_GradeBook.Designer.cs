namespace gradesBookApp
{
    partial class Edit_GradeBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_GradeBook));
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbtnBack = new gradesBookApp.RoundedButton();
            this.rbtnSave = new gradesBookApp.RoundedButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(271, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 35);
            this.label4.TabIndex = 56;
            this.label4.Text = "GRADEBOOK";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(-450, -1);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1797, 83);
            this.textBox2.TabIndex = 55;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnBack
            // 
            this.rbtnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnBack.FlatAppearance.BorderSize = 0;
            this.rbtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnBack.ForeColor = System.Drawing.Color.White;
            this.rbtnBack.Location = new System.Drawing.Point(647, 3);
            this.rbtnBack.Name = "rbtnBack";
            this.rbtnBack.Size = new System.Drawing.Size(150, 40);
            this.rbtnBack.TabIndex = 9;
            this.rbtnBack.Text = "Cancel";
            this.rbtnBack.UseVisualStyleBackColor = false;
            this.rbtnBack.Click += new System.EventHandler(this.rbtnBack_Click);
            // 
            // rbtnSave
            // 
            this.rbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnSave.FlatAppearance.BorderSize = 0;
            this.rbtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnSave.ForeColor = System.Drawing.Color.White;
            this.rbtnSave.Location = new System.Drawing.Point(476, 3);
            this.rbtnSave.Name = "rbtnSave";
            this.rbtnSave.Size = new System.Drawing.Size(150, 40);
            this.rbtnSave.TabIndex = 59;
            this.rbtnSave.Text = "Save";
            this.rbtnSave.UseVisualStyleBackColor = false;
            this.rbtnSave.Click += new System.EventHandler(this.rbtnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.32217F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.67783F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.Controls.Add(this.rbtnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtnBack, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 395);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 55);
            this.tableLayoutPanel1.TabIndex = 60;
            // 
            // Edit_GradeBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Edit_GradeBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulacan Technological University";
            this.Load += new System.EventHandler(this.Edit_GradeBook_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private RoundedButton rbtnBack;
        private RoundedButton rbtnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}