namespace gradesBookApp
{
    partial class Student_Login
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
            this.rbtnLogIn = new gradesBookApp.RoundedButton();
            this.txtStudentPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbtnLogIn
            // 
            this.rbtnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnLogIn.FlatAppearance.BorderSize = 0;
            this.rbtnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnLogIn.ForeColor = System.Drawing.Color.White;
            this.rbtnLogIn.Location = new System.Drawing.Point(132, 199);
            this.rbtnLogIn.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnLogIn.Name = "rbtnLogIn";
            this.rbtnLogIn.Size = new System.Drawing.Size(112, 32);
            this.rbtnLogIn.TabIndex = 9;
            this.rbtnLogIn.Text = "Log In";
            this.rbtnLogIn.UseVisualStyleBackColor = false;
            this.rbtnLogIn.Click += new System.EventHandler(this.rbtnLogIn_Click);
            // 
            // txtStudentPass
            // 
            this.txtStudentPass.Location = new System.Drawing.Point(58, 150);
            this.txtStudentPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentPass.Name = "txtStudentPass";
            this.txtStudentPass.Size = new System.Drawing.Size(188, 20);
            this.txtStudentPass.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(58, 103);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(188, 20);
            this.txtStudentID.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Student ID";
            // 
            // Student_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 447);
            this.Controls.Add(this.rbtnLogIn);
            this.Controls.Add(this.txtStudentPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label1);
            this.Name = "Student_Login";
            this.Text = "Student_Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton rbtnLogIn;
        private System.Windows.Forms.TextBox txtStudentPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label1;
    }
}