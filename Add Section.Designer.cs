namespace gradesBookApp
{
    partial class Add_Section
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
            this.cboProgram = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numSection = new System.Windows.Forms.NumericUpDown();
            this.rbtnOK = new gradesBookApp.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSection)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProgram
            // 
            this.cboProgram.FormattingEnabled = true;
            this.cboProgram.Items.AddRange(new object[] {
            "Bachelor of Science in Accountancy",
            "Bachelor of Science in Computer Engineering",
            "Bachelor of Science in Enterepreneurship",
            "Bachelor of Science in Hospitality Management",
            "Bachelor of Science in Information Technology",
            "Bachelor of Secondary Education major in English",
            "Bachelor of Secondary Education major in Mathematics"});
            this.cboProgram.Location = new System.Drawing.Point(83, 44);
            this.cboProgram.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboProgram.Name = "cboProgram";
            this.cboProgram.Size = new System.Drawing.Size(300, 21);
            this.cboProgram.TabIndex = 0;
            this.cboProgram.Text = "Bachelor of Science in Information Technology";
            this.cboProgram.SelectedIndexChanged += new System.EventHandler(this.cboProgram_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Program";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(83, 84);
            this.numYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numYear.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(88, 20);
            this.numYear.TabIndex = 3;
            this.numYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Section";
            // 
            // numSection
            // 
            this.numSection.Location = new System.Drawing.Point(83, 122);
            this.numSection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numSection.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSection.Name = "numSection";
            this.numSection.Size = new System.Drawing.Size(88, 20);
            this.numSection.TabIndex = 5;
            this.numSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtnOK
            // 
            this.rbtnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(93)))));
            this.rbtnOK.FlatAppearance.BorderSize = 0;
            this.rbtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnOK.ForeColor = System.Drawing.Color.White;
            this.rbtnOK.Location = new System.Drawing.Point(426, 266);
            this.rbtnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnOK.Name = "rbtnOK";
            this.rbtnOK.Size = new System.Drawing.Size(112, 32);
            this.rbtnOK.TabIndex = 6;
            this.rbtnOK.Text = "OK";
            this.rbtnOK.UseVisualStyleBackColor = false;
            this.rbtnOK.Click += new System.EventHandler(this.rbtnOK_Click);
            // 
            // Add_Section
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.rbtnOK);
            this.Controls.Add(this.numSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProgram);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Add_Section";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Section";
            //this.Load += new System.EventHandler(this.Add_Section_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSection;
        private RoundedButton rbtnOK;
    }
}