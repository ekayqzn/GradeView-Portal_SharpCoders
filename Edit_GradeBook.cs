using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public partial class Edit_GradeBook : Form
    {
        Validation v = new Validation();
        public Edit_GradeBook(DataGridViewRow row)
        {
            InitializeComponent();
            DisplayRowData(row);

        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_GradeBook_Load(object sender, EventArgs e)
        {

        }

        private void DisplayRowData(DataGridViewRow row)
        {
            int y = 100; // Starting Y position for controls
            int columnCount = row.Cells.Count - 1; // Exclude the last column
            for (int i = 0; i < columnCount; i++)
            {
                DataGridViewCell cell = row.Cells[i];

                // Create and configure label
                Label label = new Label();
                label.Text = cell.OwningColumn.HeaderText;
                label.Location = new System.Drawing.Point(20, y);
                label.AutoSize = true;
                label.Font = new Font("Arial", 11, FontStyle.Italic);
                this.Controls.Add(label);

                // Create and configure textbox
                TextBox textBox = new TextBox();
                textBox.Name = "textBox" + (i + 1);
                textBox.Text = cell.Value?.ToString();
                textBox.Location = new System.Drawing.Point(188, y);
                textBox.AutoSize = true;
                textBox.Font = new Font("Arial", 12, FontStyle.Regular);
                textBox.Enabled = (i > 1); // Disable editing for the first two cells
                this.Controls.Add(textBox);

                // Calculate the maximum width needed for the TextBox
                int maxWidth = CalculateMaximumWidth(row.DataGridView.Columns[i]);
                textBox.Width = maxWidth;

                y += 30; // Move to the next line for the next pair of controls
            }
        }

        private int CalculateMaximumWidth(DataGridViewColumn column)
        {
            int maxWidth = 0;

            // Iterate through each cell in the column to find the maximum width needed
            foreach (DataGridViewRow row in column.DataGridView.Rows)
            {
                object cellValue = row.Cells[column.Index].Value;
                if (cellValue != null)
                {
                    Size textSize = TextRenderer.MeasureText(cellValue.ToString(), column.DataGridView.Font);
                    maxWidth = Math.Max(maxWidth, textSize.Width);
                }
            }

            // Add padding to the maximum width
            maxWidth += 70; // Adjust as needed

            return maxWidth;
        }

        private void rbtnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true; // Initialize isValid to true

            try
            {
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (textBox.Name == "textBox1" || textBox.Name == "textBox2")
                        {
                            isValid = true;
                        }
                        else
                        {
                            if (!v.isNumberforDB(textBox.Text))
                            {
                                isValid = false; // Set isValid to false if any textbox fails validation
                                textBox.Focus();
                                textBox.SelectAll();
                                break; // Exit the loop as validation failed
                            }

                        }
                    }
                }

                if (isValid)
                {
                    if(MessageBox.Show("All fields are valid") == DialogResult.OK)
                    {
                        (Application.OpenForms["GradeBook"] as GradeBook)?.GradeBook_Load(this, EventArgs.Empty);
                        this.Close();
                    }
                    //Add update to database
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }

        }
    }
}
