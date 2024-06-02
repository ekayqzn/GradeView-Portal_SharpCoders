namespace gradesBookApp
{
    partial class Add_Class
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
            this.txtClassCode = new System.Windows.Forms.TextBox();
            this.rbtnAddClass = new gradesBookApp.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Code";
            // 
            // txtClassCode
            // 
            this.txtClassCode.Location = new System.Drawing.Point(246, 158);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new System.Drawing.Size(183, 22);
            this.txtClassCode.TabIndex = 1;
            // 
            // rbtnAddClass
            // 
            this.rbtnAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddClass.FlatAppearance.BorderSize = 0;
            this.rbtnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddClass.ForeColor = System.Drawing.Color.White;
            this.rbtnAddClass.Location = new System.Drawing.Point(279, 225);
            this.rbtnAddClass.Name = "rbtnAddClass";
            this.rbtnAddClass.Size = new System.Drawing.Size(150, 40);
            this.rbtnAddClass.TabIndex = 2;
            this.rbtnAddClass.Text = "Add";
            this.rbtnAddClass.UseVisualStyleBackColor = false;
            this.rbtnAddClass.Click += new System.EventHandler(this.rbtnAddClass_Click);
            // 
            // Add_Class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbtnAddClass);
            this.Controls.Add(this.txtClassCode);
            this.Controls.Add(this.label1);
            this.Name = "Add_Class";
            this.Text = "Add_Class";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassCode;
        private RoundedButton rbtnAddClass;
    }
}