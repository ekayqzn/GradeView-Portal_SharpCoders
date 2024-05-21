namespace gradesBookApp
{
    partial class Faculty_LogIn
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTeacherID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTeacherPass = new System.Windows.Forms.TextBox();
            this.rbtnLogIn = new gradesBookApp.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Faculty ID";
            // 
            // txtTeacherID
            // 
            this.txtTeacherID.Location = new System.Drawing.Point(82, 142);
            this.txtTeacherID.Name = "txtTeacherID";
            this.txtTeacherID.Size = new System.Drawing.Size(250, 22);
            this.txtTeacherID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtTeacherPass
            // 
            this.txtTeacherPass.Location = new System.Drawing.Point(82, 199);
            this.txtTeacherPass.Name = "txtTeacherPass";
            this.txtTeacherPass.Size = new System.Drawing.Size(250, 22);
            this.txtTeacherPass.TabIndex = 3;
            // 
            // rbtnLogIn
            // 
            this.rbtnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnLogIn.FlatAppearance.BorderSize = 0;
            this.rbtnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnLogIn.ForeColor = System.Drawing.Color.White;
            this.rbtnLogIn.Location = new System.Drawing.Point(182, 260);
            this.rbtnLogIn.Name = "rbtnLogIn";
            this.rbtnLogIn.Size = new System.Drawing.Size(150, 40);
            this.rbtnLogIn.TabIndex = 4;
            this.rbtnLogIn.Text = "Log In";
            this.rbtnLogIn.UseVisualStyleBackColor = false;
            this.rbtnLogIn.Click += new System.EventHandler(this.rbtnLogIn_Click);
            // 
            // Faculty_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 550);
            this.Controls.Add(this.rbtnLogIn);
            this.Controls.Add(this.txtTeacherPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTeacherID);
            this.Controls.Add(this.label1);
            this.Name = "Faculty_LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faculty_LogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTeacherID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTeacherPass;
        private RoundedButton rbtnLogIn;
    }
}