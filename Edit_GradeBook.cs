using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gradesBookApp
{
    public partial class Edit_GradeBook : Form
    {
        public static string editStudentID = "";
        Validation v = new Validation();
        UpdateScores u = new UpdateScores();
        public Edit_GradeBook(DataGridViewRow row)
        {
            InitializeComponent();
            DisplayRowData(row);

        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            GradeBook g = new GradeBook();
            g.ShowDialog();
            this.Close();
        }

        private void DisplayRowData(DataGridViewRow row)
        {
            int y = 10; // Starting Y position for controls
            int x = 20;
            int columnCount = row.Cells.Count - 2; // Exclude the last column
            for (int i = 0; i < columnCount; i++)
            {
                DataGridViewCell cell = row.Cells[i];

                if ((i % 2 == 0) && (i != 0))
                {
                    y += 30;
                    x = 20;
                    // Create and configure label
                    Label label = new Label();
                    label.Name = "label" + (i + 1);
                    label.Text = cell.OwningColumn.HeaderText;
                    label.Location = new System.Drawing.Point(x, y);
                    label.AutoSize = true;
                    label.Font = new Font("Arial", 11, FontStyle.Italic);
                    panel1.Controls.Add(label);

                    x += 155;
                    // Create and configure textbox
                    System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                    textBox.Name = "textBox" + (i + 1);
                    textBox.Text = cell.Value?.ToString();
                    if (i == 0)
                    {
                        editStudentID = textBox.Text.Trim();
                    }
                    textBox.Location = new System.Drawing.Point(x, y);
                    textBox.AutoSize = true;
                    textBox.Font = new Font("Arial", 12, FontStyle.Regular);
                    textBox.Enabled = (i > 1); // Disable editing for the first two cells
                    panel1.Controls.Add(textBox);

                    // Calculate the maximum width needed for the TextBox
                    int maxWidth = CalculateMaximumWidth(row.DataGridView.Columns[i]);
                    textBox.Width = maxWidth;
                    x += 155;
                }
                else
                {
                    // Create and configure label
                    Label label = new Label();
                    label.Name = "label" + (i + 1);
                    label.Text = cell.OwningColumn.HeaderText;
                    label.Location = new System.Drawing.Point(x, y);
                    label.AutoSize = true;
                    label.Font = new Font("Arial", 11, FontStyle.Italic);
                    panel1.Controls.Add(label);

                    x += 155;
                    // Create and configure textbox
                    System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                    textBox.Name = "textBox" + (i + 1);
                    textBox.Text = cell.Value?.ToString();
                    if (i == 0)
                    {
                        editStudentID = textBox.Text.Trim();
                    }
                    textBox.Location = new System.Drawing.Point(x, y);
                    textBox.AutoSize = true;
                    textBox.Font = new Font("Arial", 12, FontStyle.Regular);
                    textBox.Enabled = (i > 1); // Disable editing for the first two cells
                    panel1.Controls.Add(textBox);

                    x += 155;


                    // Calculate the maximum width needed for the TextBox
                    int maxWidth = CalculateMaximumWidth(row.DataGridView.Columns[i]);
                    textBox.Width = maxWidth;
                }
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
            string tableName = "";
            string columnName = "";
            int newValue = -1;

            try
            {
                // Loop through all controls in the panel
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    // Check if the current control is a TextBox
                    if (panel1.Controls[i] is System.Windows.Forms.TextBox txt)
                    {
                        // Skip validation for specific textboxes
                        if (txt.Name == "textBox1" || txt.Name == "textBox2")
                        {
                            continue;
                        }

                        // Check if the text is a valid number
                        if (!v.isNumberforDB(txt.Text))
                        {
                            isValid = false; // Set isValid to false if validation fails
                            txt.Focus();
                            txt.SelectAll();
                            //MessageBox.Show("Invalid number in the textbox.");
                            break; // Exit the loop as validation failed
                        }
                        else
                        {
                            int j = i + 2;
                            // Check if j is within the valid range of panel1.Controls
                            if (j < panel1.Controls.Count && panel1.Controls[j] is System.Windows.Forms.TextBox nextTxt && !string.IsNullOrEmpty(nextTxt.Text))
                            {
                                // Compare the values of the current and next textboxes
                                if (Convert.ToInt32(txt.Text) > Convert.ToInt32(nextTxt.Text))
                                {
                                    isValid = false; // Set isValid to false if the current score is greater than the total score
                                    txt.Focus();
                                    txt.SelectAll();
                                    MessageBox.Show("The score entered exceeds the total possible score.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    break;
                                }
                            }
                        }
                        i += 2;
                    }
                }

                if (isValid)
                {
                    foreach (Control control in panel1.Controls)
                    {
                        if (control is System.Windows.Forms.TextBox textBox)
                        {
                            if ((textBox.Name == "textBox1") || (textBox.Name == "textBox2"))
                            {
                                continue;
                            }
                            else
                            {
                                newValue = Convert.ToInt32(textBox.Text.Trim());
                            }
                        }

                        if (control is Label label)
                        {
                            if ((label.Name == "label1") || (label.Name == "label2"))
                            {
                                continue;
                            }
                            else
                            {
                                columnName = label.Text;
                                tableName = u.GetTableName(label.Text);
                            }
                        }

                        u.UpdateGradebook(tableName, columnName, newValue);
                    }
                    //Add update to database
                    if (MessageBox.Show("All fields are valid. Scores have been updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //GradeBook gradeBookForm = Application.OpenForms["GradeBook"] as GradeBook;
                        //if (gradeBookForm != null)
                        //{
                        //    gradeBookForm.GradeBook_Load(this, EventArgs.Empty);
                        //}
                        //this.Close(); OPT 1: Gradebook is behind

                        //OPT 2 Gradebook close
                        this.Hide();
                        GradeBook g = new GradeBook();
                        g.ShowDialog();
                        this.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }

        }
    }
}
