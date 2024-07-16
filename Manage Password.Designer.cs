namespace gradesBookApp
{
    partial class Manage_Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage_Password));
            this.picBackButton = new System.Windows.Forms.PictureBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbtnBack = new gradesBookApp.RoundedButton();
            this.rbtnAdd = new gradesBookApp.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.toolTipBack = new System.Windows.Forms.ToolTip(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).BeginInit();
            this.panelPassword.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBackButton
            // 
            this.picBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.picBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackButton.Image = global::gradesBookApp.Properties.Resources.k__1_;
            this.picBackButton.Location = new System.Drawing.Point(21, 16);
            this.picBackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBackButton.Name = "picBackButton";
            this.picBackButton.Size = new System.Drawing.Size(55, 50);
            this.picBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackButton.TabIndex = 103;
            this.picBackButton.TabStop = false;
            this.toolTipBack.SetToolTip(this.picBackButton, "Back");
            this.picBackButton.Click += new System.EventHandler(this.picBackButton_Click);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.Location = new System.Drawing.Point(67, 182);
            this.txtConfirmPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(729, 30);
            this.txtConfirmPass.TabIndex = 106;
            this.txtConfirmPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPass_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(272, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(325, 35);
            this.label7.TabIndex = 101;
            this.label7.Text = "MANAGE PASSWORD";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(861, 82);
            this.textBox2.TabIndex = 100;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnBack
            // 
            this.rbtnBack.BackColor = System.Drawing.Color.Maroon;
            this.rbtnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBack.FlatAppearance.BorderSize = 0;
            this.rbtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBack.ForeColor = System.Drawing.Color.White;
            this.rbtnBack.Location = new System.Drawing.Point(372, 14);
            this.rbtnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnBack.Name = "rbtnBack";
            this.rbtnBack.Size = new System.Drawing.Size(199, 46);
            this.rbtnBack.TabIndex = 99;
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
            this.rbtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAdd.ForeColor = System.Drawing.Color.White;
            this.rbtnAdd.Location = new System.Drawing.Point(607, 14);
            this.rbtnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(191, 46);
            this.rbtnAdd.TabIndex = 107;
            this.rbtnAdd.Text = "Apply Changes";
            this.rbtnAdd.UseVisualStyleBackColor = false;
            this.rbtnAdd.Click += new System.EventHandler(this.rbtnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(67, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 29);
            this.label1.TabIndex = 90;
            this.label1.Text = "Confirm New Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(68, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 29);
            this.label2.TabIndex = 104;
            this.label2.Text = "Enter New Password:";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(67, 86);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(729, 30);
            this.txtNewPass.TabIndex = 105;
            this.txtNewPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPass_KeyDown);
            // 
            // panelPassword
            // 
            this.panelPassword.Controls.Add(this.textBox3);
            this.panelPassword.Controls.Add(this.label2);
            this.panelPassword.Controls.Add(this.txtNewPass);
            this.panelPassword.Controls.Add(this.txtConfirmPass);
            this.panelPassword.Controls.Add(this.label1);
            this.panelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPassword.Location = new System.Drawing.Point(0, 82);
            this.panelPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(861, 387);
            this.panelPassword.TabIndex = 106;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.rbtnBack);
            this.panelButton.Controls.Add(this.rbtnAdd);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 353);
            this.panelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(861, 116);
            this.panelButton.TabIndex = 107;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(-458, 0);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(1797, 18);
            this.textBox3.TabIndex = 108;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Manage_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(861, 469);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelPassword);
            this.Controls.Add(this.picBackButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manage_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulacan Technological University";
            this.Load += new System.EventHandler(this.Manage_Password_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).EndInit();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBackButton;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private RoundedButton rbtnBack;
        private RoundedButton rbtnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.ToolTip toolTipBack;
        private System.Windows.Forms.TextBox textBox3;
    }
}