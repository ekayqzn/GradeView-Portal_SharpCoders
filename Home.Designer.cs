namespace gradesBookApp
{
    partial class Home
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
            this.rbtnFaculty = new gradesBookApp.RoundedButton();
            this.rbtnStudent = new gradesBookApp.RoundedButton();
            this.SuspendLayout();
            // 
            // rbtnFaculty
            // 
            this.rbtnFaculty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnFaculty.FlatAppearance.BorderSize = 0;
            this.rbtnFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnFaculty.ForeColor = System.Drawing.Color.White;
            this.rbtnFaculty.Location = new System.Drawing.Point(232, 241);
            this.rbtnFaculty.Name = "rbtnFaculty";
            this.rbtnFaculty.Size = new System.Drawing.Size(289, 75);
            this.rbtnFaculty.TabIndex = 0;
            this.rbtnFaculty.Text = "Faculty";
            this.rbtnFaculty.UseVisualStyleBackColor = false;
            this.rbtnFaculty.Click += new System.EventHandler(this.rbtnFaculty_Click);
            // 
            // rbtnStudent
            // 
            this.rbtnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnStudent.FlatAppearance.BorderSize = 0;
            this.rbtnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnStudent.ForeColor = System.Drawing.Color.White;
            this.rbtnStudent.Location = new System.Drawing.Point(232, 332);
            this.rbtnStudent.Name = "rbtnStudent";
            this.rbtnStudent.Size = new System.Drawing.Size(289, 75);
            this.rbtnStudent.TabIndex = 1;
            this.rbtnStudent.Text = "Student";
            this.rbtnStudent.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 587);
            this.Controls.Add(this.rbtnStudent);
            this.Controls.Add(this.rbtnFaculty);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home - Polytechnic University of the Philippines";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton rbtnFaculty;
        private RoundedButton rbtnStudent;
    }
}

