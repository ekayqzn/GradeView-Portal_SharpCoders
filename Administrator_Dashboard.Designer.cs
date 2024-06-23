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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrator_Dashboard));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.picLogOut = new System.Windows.Forms.PictureBox();
            this.rbtnAddTeacher = new gradesBookApp.RoundedButton();
            this.rbtnAddProgram = new gradesBookApp.RoundedButton();
            this.rbtnAddStudent = new gradesBookApp.RoundedButton();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTipHome = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(-1, -6);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(865, 91);
            this.textBox2.TabIndex = 59;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picLogOut
            // 
            this.picLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.picLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogOut.Image = global::gradesBookApp.Properties.Resources.k__2_;
            this.picLogOut.Location = new System.Drawing.Point(779, 21);
            this.picLogOut.Name = "picLogOut";
            this.picLogOut.Size = new System.Drawing.Size(55, 50);
            this.picLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogOut.TabIndex = 66;
            this.picLogOut.TabStop = false;
            this.toolTipHome.SetToolTip(this.picLogOut, "Log Out");
            this.picLogOut.Click += new System.EventHandler(this.picLogOut_Click);
            // 
            // rbtnAddTeacher
            // 
            this.rbtnAddTeacher.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbtnAddTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddTeacher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAddTeacher.FlatAppearance.BorderSize = 0;
            this.rbtnAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAddTeacher.ForeColor = System.Drawing.Color.White;
            this.rbtnAddTeacher.Location = new System.Drawing.Point(271, 374);
            this.rbtnAddTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAddTeacher.Name = "rbtnAddTeacher";
            this.rbtnAddTeacher.Size = new System.Drawing.Size(305, 74);
            this.rbtnAddTeacher.TabIndex = 2;
            this.rbtnAddTeacher.Text = "Add Teacher";
            this.rbtnAddTeacher.UseVisualStyleBackColor = false;
            this.rbtnAddTeacher.Click += new System.EventHandler(this.rbtnAddTeacher_Click);
            // 
            // rbtnAddProgram
            // 
            this.rbtnAddProgram.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbtnAddProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddProgram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAddProgram.FlatAppearance.BorderSize = 0;
            this.rbtnAddProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAddProgram.ForeColor = System.Drawing.Color.White;
            this.rbtnAddProgram.Location = new System.Drawing.Point(271, 255);
            this.rbtnAddProgram.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAddProgram.Name = "rbtnAddProgram";
            this.rbtnAddProgram.Size = new System.Drawing.Size(305, 74);
            this.rbtnAddProgram.TabIndex = 1;
            this.rbtnAddProgram.Text = "Add Program";
            this.rbtnAddProgram.UseVisualStyleBackColor = false;
            this.rbtnAddProgram.Click += new System.EventHandler(this.rbtnAddProgram_Click);
            // 
            // rbtnAddStudent
            // 
            this.rbtnAddStudent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbtnAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAddStudent.FlatAppearance.BorderSize = 0;
            this.rbtnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAddStudent.ForeColor = System.Drawing.Color.White;
            this.rbtnAddStudent.Location = new System.Drawing.Point(271, 142);
            this.rbtnAddStudent.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAddStudent.Name = "rbtnAddStudent";
            this.rbtnAddStudent.Size = new System.Drawing.Size(305, 74);
            this.rbtnAddStudent.TabIndex = 0;
            this.rbtnAddStudent.Text = "Add Student";
            this.rbtnAddStudent.UseVisualStyleBackColor = false;
            this.rbtnAddStudent.Click += new System.EventHandler(this.rbtnAddStudent_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.label4.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(155, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(536, 38);
            this.label4.TabIndex = 67;
            this.label4.Text = "ADMINISTRATOR DASHBOARD";
            // 
            // Administrator_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(861, 497);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picLogOut);
            this.Controls.Add(this.rbtnAddTeacher);
            this.Controls.Add(this.rbtnAddProgram);
            this.Controls.Add(this.rbtnAddStudent);
            this.Controls.Add(this.textBox2);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Administrator_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulacan Technological University";
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton rbtnAddStudent;
        private RoundedButton rbtnAddProgram;
        private RoundedButton rbtnAddTeacher;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox picLogOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTipHome;
    }
}