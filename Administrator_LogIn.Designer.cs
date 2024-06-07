namespace gradesBookApp
{
    partial class Administrator_LogIn
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
            this.txtAdminID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdminPass = new System.Windows.Forms.TextBox();
            this.rbtnLogIn = new gradesBookApp.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrator";
            // 
            // txtAdminID
            // 
            this.txtAdminID.Location = new System.Drawing.Point(155, 74);
            this.txtAdminID.Name = "txtAdminID";
            this.txtAdminID.Size = new System.Drawing.Size(343, 20);
            this.txtAdminID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtAdminPass
            // 
            this.txtAdminPass.Location = new System.Drawing.Point(155, 111);
            this.txtAdminPass.Name = "txtAdminPass";
            this.txtAdminPass.Size = new System.Drawing.Size(343, 20);
            this.txtAdminPass.TabIndex = 3;
            // 
            // rbtnLogIn
            // 
            this.rbtnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnLogIn.FlatAppearance.BorderSize = 0;
            this.rbtnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnLogIn.ForeColor = System.Drawing.Color.White;
            this.rbtnLogIn.Location = new System.Drawing.Point(399, 189);
            this.rbtnLogIn.Name = "rbtnLogIn";
            this.rbtnLogIn.Size = new System.Drawing.Size(99, 31);
            this.rbtnLogIn.TabIndex = 4;
            this.rbtnLogIn.Text = "Log In";
            this.rbtnLogIn.UseVisualStyleBackColor = false;
            this.rbtnLogIn.Click += new System.EventHandler(this.rbtnLogIn_Click);
            // 
            // Administrator_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbtnLogIn);
            this.Controls.Add(this.txtAdminPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdminID);
            this.Controls.Add(this.label1);
            this.Name = "Administrator_LogIn";
            this.Text = "Administrator_LogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdminID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdminPass;
        private RoundedButton rbtnLogIn;
    }
}