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
            this.rbtnAddSubject = new gradesBookApp.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnAddSubject);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 614);
            this.panel1.TabIndex = 2;
            // 
            // rbtnAddSubject
            // 
            this.rbtnAddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddSubject.FlatAppearance.BorderSize = 0;
            this.rbtnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddSubject.ForeColor = System.Drawing.Color.White;
            this.rbtnAddSubject.Location = new System.Drawing.Point(795, 77);
            this.rbtnAddSubject.Name = "rbtnAddSubject";
            this.rbtnAddSubject.Size = new System.Drawing.Size(150, 40);
            this.rbtnAddSubject.TabIndex = 3;
            this.rbtnAddSubject.Text = "Add Subject";
            this.rbtnAddSubject.UseVisualStyleBackColor = false;
            this.rbtnAddSubject.Click += new System.EventHandler(this.rbtnAddSubject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dashboard";
            // 
            // Teacher_s_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 614);
            this.Controls.Add(this.panel1);
            this.Name = "Teacher_s_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher\'s Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Teacher_s_Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RoundedButton rbtnAddSubject;
        private System.Windows.Forms.Label label1;
    }
}