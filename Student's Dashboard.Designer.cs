namespace gradesBookApp
{
    partial class Student_s_Dashboard
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
            this.rbtnAddSubject = new gradesBookApp.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbtnAddSubject
            // 
            this.rbtnAddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddSubject.FlatAppearance.BorderSize = 0;
            this.rbtnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddSubject.ForeColor = System.Drawing.Color.White;
            this.rbtnAddSubject.Location = new System.Drawing.Point(591, 60);
            this.rbtnAddSubject.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnAddSubject.Name = "rbtnAddSubject";
            this.rbtnAddSubject.Size = new System.Drawing.Size(112, 32);
            this.rbtnAddSubject.TabIndex = 5;
            this.rbtnAddSubject.Text = "Add Subject";
            this.rbtnAddSubject.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dashboard";
            // 
            // Student_s_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 460);
            this.Controls.Add(this.rbtnAddSubject);
            this.Controls.Add(this.label1);
            this.Name = "Student_s_Dashboard";
            this.Text = "Students_Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton rbtnAddSubject;
        private System.Windows.Forms.Label label1;
    }
}