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
            this.btnAdminstrator = new gradesBookApp.RoundedButton();
            this.rbtnStudent = new gradesBookApp.RoundedButton();
            this.rbtnFaculty = new gradesBookApp.RoundedButton();
            this.SuspendLayout();
            // 
            // btnAdminstrator
            // 
            this.btnAdminstrator.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdminstrator.FlatAppearance.BorderSize = 0;
            this.btnAdminstrator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminstrator.ForeColor = System.Drawing.Color.White;
            this.btnAdminstrator.Location = new System.Drawing.Point(174, 383);
            this.btnAdminstrator.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdminstrator.Name = "btnAdminstrator";
            this.btnAdminstrator.Size = new System.Drawing.Size(216, 50);
            this.btnAdminstrator.TabIndex = 2;
            this.btnAdminstrator.Text = "Adminstrator";
            this.btnAdminstrator.UseVisualStyleBackColor = false;
            this.btnAdminstrator.Click += new System.EventHandler(this.btnAdminstrator_Click);
            // 
            // rbtnStudent
            // 
            this.rbtnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnStudent.FlatAppearance.BorderSize = 0;
            this.rbtnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnStudent.ForeColor = System.Drawing.Color.White;
            this.rbtnStudent.Location = new System.Drawing.Point(174, 270);
            this.rbtnStudent.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnStudent.Name = "rbtnStudent";
            this.rbtnStudent.Size = new System.Drawing.Size(217, 61);
            this.rbtnStudent.TabIndex = 1;
            this.rbtnStudent.Text = "Student";
            this.rbtnStudent.UseVisualStyleBackColor = false;
            this.rbtnStudent.Click += new System.EventHandler(this.rbtnStudent_Click);
            // 
            // rbtnFaculty
            // 
            this.rbtnFaculty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnFaculty.FlatAppearance.BorderSize = 0;
            this.rbtnFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnFaculty.ForeColor = System.Drawing.Color.White;
            this.rbtnFaculty.Location = new System.Drawing.Point(173, 205);
            this.rbtnFaculty.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFaculty.Name = "rbtnFaculty";
            this.rbtnFaculty.Size = new System.Drawing.Size(217, 61);
            this.rbtnFaculty.TabIndex = 0;
            this.rbtnFaculty.Text = "Faculty";
            this.rbtnFaculty.UseVisualStyleBackColor = false;
            this.rbtnFaculty.Click += new System.EventHandler(this.rbtnFaculty_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 477);
            this.Controls.Add(this.btnAdminstrator);
            this.Controls.Add(this.rbtnStudent);
            this.Controls.Add(this.rbtnFaculty);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home - Polytechnic University of the Philippines";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton rbtnFaculty;
        private RoundedButton rbtnStudent;
        private RoundedButton btnAdminstrator;
    }
}

