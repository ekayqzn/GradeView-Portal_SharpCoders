using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gradesBookApp
{
    public partial class Add_Student : Form
    {
        databaseConnection db = new databaseConnection();
        string studentID;
        string firstName;
        string lastName;
        string middleName;
        string programName;
        int year;
        int section;
        string status;

        AddQuery a = new AddQuery();

        public Add_Student()
        {
            InitializeComponent();
        }

        private void cboProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the event was triggered by user interaction
            if (!cboProgram.Focused)
                return; // Exit early if not user interaction

            if (cboProgram.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedProgram = cboProgram.SelectedItem.ToString();

            try
            {
                // Open the database connection
                db.Connect();

                // Query to get the year and section limits for the selected program
                string query = "SELECT MAX(year_level) AS max_year, MAX(section) AS max_section FROM modern_gradesbook.program WHERE program_name = @programName";

                MySqlCommand command = new MySqlCommand(query, db.conn);
                command.Parameters.AddWithValue("@programName", selectedProgram);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int maxYear = reader.IsDBNull(reader.GetOrdinal("max_year")) ? 1 : reader.GetInt32("max_year");
                        int maxSection = reader.IsDBNull(reader.GetOrdinal("max_section")) ? 1 : reader.GetInt32("max_section");

                        // Set the year numeric up-down control
                        numYear.Maximum = maxYear;
                        numYear.Minimum = 1;

                        // Set the section numeric up-down control
                        numSection.Maximum = maxSection;
                        numSection.Minimum = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                // Close the database connection
                db.Disconnect();
            }
        }

        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            // Retrieve data from input
            studentID = "SBTU-" + txtStudentNum.Text.Trim();
            firstName = txtFName.Text.Trim();
            lastName = txtLName.Text.Trim();
            middleName = txtMName.Text.Trim();
            programName = cboProgram.SelectedItem?.ToString().Trim(); // Use null-conditional operator
            year = Convert.ToInt32(numYear.Value);
            section = Convert.ToInt32(numSection.Value);

            if(rdoIrreg.Checked)
            {
                status = "Irregular";
            }
            else if(rdoRegular.Checked)
            {
                status = "Regular";
            }
            else
            {
                status = "";
            }

            // Add Validation
            if (string.IsNullOrEmpty(txtStudentNum.Text) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || status == "")
            {
                MessageBox.Show("Please fill in all required fields." + status , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(txtStudentNum.Text))
                {
                    txtStudentNum.Focus();
                    return;
                }
                if(string.IsNullOrEmpty(firstName))
                {
                    txtFName.Focus();
                    return;
                }
                if(rdoIrreg.Checked == false && rdoRegular.Checked == false)
                {
                    groupStatus.Focus();
                    return;
                }
                if(string.IsNullOrEmpty(lastName))
                {
                    txtLName.Focus();
                    return;
                }
                
            }
            else
            {
                if (!(int.TryParse(txtStudentNum.Text, out int ignore)))
                {
                    txtStudentNum.Focus();
                    txtStudentNum.SelectAll();
                    MessageBox.Show("String value is not accepted");
                    return;
                }
                // Check if a program is selected
                if (cboProgram.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a program.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboProgram.Focus();
                    return;
                }

                //Add Query Method
                if(a.AddStudent(studentID, firstName, middleName, lastName, status, programName, year, section))
                {
                    if (MessageBox.Show("Student Added Successfully!", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtMName.Text = "";
                        txtStudentNum.Text = "";
                        cboProgram.SelectedIndex = -1;
                        numSection.Value = 1;
                        numYear.Value = 1;
                        rdoIrreg.Checked = false;
                        rdoRegular.Checked = false;
                    }
                }
            }
        }

        private void LoadDataIntoDropdown()
        {
            try
            {
                // Temporarily remove the event handler
                cboProgram.SelectedIndexChanged -= cboProgram_SelectedIndexChanged;

                // Open the database connection
                db.Connect();

                // Query to retrieve distinct program names
                string query = "SELECT DISTINCT program_name FROM modern_gradesbook.program";

                // Command to execute the query
                MySqlCommand command = new MySqlCommand(query, db.conn);

                // Execute the query and get the data reader
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Clear existing items in dropdown
                    cboProgram.Items.Clear();

                    // Iterate through the data reader
                    while (reader.Read())
                    {
                        // Assuming the program name is in the first column (index 0)
                        string program = reader.GetString(0);

                        // Add program to dropdown
                        cboProgram.Items.Add(program);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                // Reassign the event handler
                cboProgram.SelectedIndexChanged += cboProgram_SelectedIndexChanged;

                // Close the database connection
                db.Disconnect();
            }
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_Dashboard ADB = new Administrator_Dashboard();
            ADB.ShowDialog();
            this.Close();
        }

        private void Add_Student_Load(object sender, EventArgs e)
        {
            LoadDataIntoDropdown();
            txtStudentNum.Focus();

            txtStudentNum.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtMName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtLName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtFName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            numYear.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            numSection.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            rdoIrreg.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            rdoRegular.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Retrieve data from input
                studentID = "SBTU-" + txtStudentNum.Text.Trim();
                firstName = txtFName.Text.Trim();
                lastName = txtLName.Text.Trim();
                middleName = txtMName.Text.Trim();
                programName = cboProgram.SelectedItem?.ToString().Trim(); // Use null-conditional operator
                year = Convert.ToInt32(numYear.Value);
                section = Convert.ToInt32(numSection.Value);

                if (rdoIrreg.Checked)
                {
                    status = "Irregular";
                    return;
                }
                else if (rdoRegular.Checked)
                {
                    status = "Regular";
                    return;
                }
                else
                {
                    status = "";
                }

                // Add Validation
                if (string.IsNullOrEmpty(txtStudentNum.Text) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || status == "")
                {
                    MessageBox.Show("Please fill in all required fields." + status, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (string.IsNullOrEmpty(txtStudentNum.Text))
                    {
                        txtStudentNum.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(firstName))
                    {
                        txtFName.Focus();
                        return;
                    }
                    if (rdoIrreg.Checked == false && rdoRegular.Checked == false)
                    {
                        groupStatus.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(lastName))
                    {
                        txtLName.Focus();
                        return;
                    }

                }
                else
                {
                    if (!(int.TryParse(txtStudentNum.Text, out int ignore)))
                    {
                        txtStudentNum.Focus();
                        txtStudentNum.SelectAll();
                        MessageBox.Show("String value is not accepted");
                        return;
                    }
                    // Check if a program is selected
                    if (cboProgram.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a program.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboProgram.Focus();
                        return;
                    }

                    //Add Query Method
                    if (a.AddStudent(studentID, firstName, middleName, lastName, status, programName, year, section))
                    {
                        if (MessageBox.Show("Student Added Successfully!", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtFName.Text = "";
                            txtLName.Text = "";
                            txtMName.Text = "";
                            txtStudentNum.Text = "";
                            cboProgram.SelectedIndex = -1;
                            numSection.Value = 1;
                            numYear.Value = 1;
                            rdoIrreg.Checked = false;
                            rdoRegular.Checked = false;
                        }
                    }
                }
            }
        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator_Dashboard ADB = new Administrator_Dashboard();
            ADB.ShowDialog();
            this.Close();
        }

        private void txtStudentNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like backspace
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Check if the length is already 5 or more
            if (txtStudentNum.Text.Length >= 5)
            {
                e.Handled = true; // Ignore the input if the length is 5 or more
            }
        }
    }
}
