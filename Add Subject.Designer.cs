namespace gradesBookApp
{
    partial class Add_Subject
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
            this.txtSubCode = new System.Windows.Forms.TextBox();
            this.txtSubName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnNext = new gradesBookApp.RoundedButton();
            this.rbtnBack = new gradesBookApp.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject Code";
            // 
            // txtSubCode
            // 
            this.txtSubCode.Location = new System.Drawing.Point(227, 127);
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(229, 22);
            this.txtSubCode.TabIndex = 1;
            // 
            // txtSubName
            // 
            this.txtSubName.Location = new System.Drawing.Point(227, 186);
            this.txtSubName.Name = "txtSubName";
            this.txtSubName.Size = new System.Drawing.Size(229, 22);
            this.txtSubName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject Name";
            // 
            // rbtnNext
            // 
            this.rbtnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnNext.FlatAppearance.BorderSize = 0;
            this.rbtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnNext.ForeColor = System.Drawing.Color.White;
            this.rbtnNext.Location = new System.Drawing.Point(336, 248);
            this.rbtnNext.Name = "rbtnNext";
            this.rbtnNext.Size = new System.Drawing.Size(150, 40);
            this.rbtnNext.TabIndex = 4;
            this.rbtnNext.Text = "Next";
            this.rbtnNext.UseVisualStyleBackColor = false;
            this.rbtnNext.Click += new System.EventHandler(this.rbtnNext_Click);
            // 
            // rbtnBack
            // 
            this.rbtnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnBack.FlatAppearance.BorderSize = 0;
            this.rbtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnBack.ForeColor = System.Drawing.Color.White;
            this.rbtnBack.Location = new System.Drawing.Point(180, 248);
            this.rbtnBack.Name = "rbtnBack";
            this.rbtnBack.Size = new System.Drawing.Size(150, 40);
            this.rbtnBack.TabIndex = 5;
            this.rbtnBack.Text = "Back";
            this.rbtnBack.UseVisualStyleBackColor = false;
            this.rbtnBack.Click += new System.EventHandler(this.rbtnBack_Click);
            // 
            // Add_Subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbtnBack);
            this.Controls.Add(this.rbtnNext);
            this.Controls.Add(this.txtSubName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubCode);
            this.Controls.Add(this.label1);
            this.Name = "Add_Subject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Subject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubCode;
        private System.Windows.Forms.TextBox txtSubName;
        private System.Windows.Forms.Label label2;
        private RoundedButton rbtnNext;
        private RoundedButton rbtnBack;
    }
}