namespace gradesBookApp
{
    partial class Administrator_Dashboard
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
            this.rbtnAddStudent = new gradesBookApp.RoundedButton();
            this.rbtnAddProgram = new gradesBookApp.RoundedButton();
            this.rbtnAddTeacher = new gradesBookApp.RoundedButton();
            this.SuspendLayout();
            // 
            // rbtnAddStudent
            // 
            this.rbtnAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddStudent.FlatAppearance.BorderSize = 0;
            this.rbtnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddStudent.ForeColor = System.Drawing.Color.White;
            this.rbtnAddStudent.Location = new System.Drawing.Point(311, 118);
            this.rbtnAddStudent.Name = "rbtnAddStudent";
            this.rbtnAddStudent.Size = new System.Drawing.Size(150, 40);
            this.rbtnAddStudent.TabIndex = 0;
            this.rbtnAddStudent.Text = "Add Student";
            this.rbtnAddStudent.UseVisualStyleBackColor = false;
            this.rbtnAddStudent.Click += new System.EventHandler(this.rbtnAddStudent_Click);
            // 
            // rbtnAddProgram
            // 
            this.rbtnAddProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddProgram.FlatAppearance.BorderSize = 0;
            this.rbtnAddProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddProgram.ForeColor = System.Drawing.Color.White;
            this.rbtnAddProgram.Location = new System.Drawing.Point(311, 176);
            this.rbtnAddProgram.Name = "rbtnAddProgram";
            this.rbtnAddProgram.Size = new System.Drawing.Size(150, 40);
            this.rbtnAddProgram.TabIndex = 1;
            this.rbtnAddProgram.Text = "Add Program";
            this.rbtnAddProgram.UseVisualStyleBackColor = false;
            // 
            // rbtnAddTeacher
            // 
            this.rbtnAddTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddTeacher.FlatAppearance.BorderSize = 0;
            this.rbtnAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddTeacher.ForeColor = System.Drawing.Color.White;
            this.rbtnAddTeacher.Location = new System.Drawing.Point(311, 233);
            this.rbtnAddTeacher.Name = "rbtnAddTeacher";
            this.rbtnAddTeacher.Size = new System.Drawing.Size(150, 40);
            this.rbtnAddTeacher.TabIndex = 2;
            this.rbtnAddTeacher.Text = "Add Teacher";
            this.rbtnAddTeacher.UseVisualStyleBackColor = false;
            // 
            // Administrator_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbtnAddTeacher);
            this.Controls.Add(this.rbtnAddProgram);
            this.Controls.Add(this.rbtnAddStudent);
            this.Name = "Administrator_Dashboard";
            this.Text = "Administrator_Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton rbtnAddStudent;
        private RoundedButton rbtnAddProgram;
        private RoundedButton rbtnAddTeacher;
    }
}