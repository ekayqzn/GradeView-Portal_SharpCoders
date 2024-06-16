using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

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
        int programID;

        public Add_Student()
        {
            InitializeComponent();
        }

        private void cboProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            // Add Validation
            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if(cboProgram.SelectedIndex == -1)
                {
                    MessageBox.Show("No Selected Program");
                    cboProgram.Focus();
                    return;
                }

                try
                {
                    // Check for duplicate student ID
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "SELECT COUNT(*) FROM modern_gradesbook.student_info WHERE student_id = @studentID";
                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@studentID", studentID);

                    int studentCount = Convert.ToInt32(db.cmd.ExecuteScalar());

                    if (studentCount > 0)
                    {
                        MessageBox.Show("A Student with the provided Student Number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Add Info to student_info table
                    db.cmd.CommandText = "INSERT INTO modern_gradesbook.student_info (student_id, first_name, last_name, middle_name) VALUES(@studentID, @firstName, @lastName, @middleName)";
                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@studentID", studentID);
                    db.cmd.Parameters.AddWithValue("@firstName", firstName);
                    db.cmd.Parameters.AddWithValue("@lastName", lastName);
                    db.cmd.Parameters.AddWithValue("@middleName", middleName);

                    db.cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    return;
                }
                finally
                {
                    db.Disconnect();
                }

                // Get program id
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @year AND section = @section";
                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@programName", programName);
                    db.cmd.Parameters.AddWithValue("@year", year);
                    db.cmd.Parameters.AddWithValue("@section", section);

                    // SelectCommand property select the sql command
                    db.dta.SelectCommand = db.cmd;

                    // DataTable
                    DataTable dataTable = new DataTable();
                    db.dta.Fill(dataTable); // populate dataTable

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);
                    }
                    else
                    {
                        MessageBox.Show("Program not found. Please check the program details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    return;
                }
                finally
                {
                    db.Disconnect();
                }

                // Add info to section table
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "INSERT INTO modern_gradesbook.section(student_id, program_id) VALUES(@studentNumber, @programID)";
                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@studentNumber", studentID);
                    db.cmd.Parameters.AddWithValue("@programID", programID);

                    db.cmd.ExecuteNonQuery();

                    if (MessageBox.Show("Student Added Successfully!", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtMName.Text = "";
                        txtStudentNum.Text = "";
                        cboProgram.SelectedItem = -1;
                        numSection.Value = 1;
                        numYear.Value = 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    db.Disconnect();
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

                // Add Validation
                if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (cboProgram.SelectedIndex == -1)
                    {
                        MessageBox.Show("No Selected Program");
                        cboProgram.Focus();
                        return;
                    }

                    try
                    {
                        // Check for duplicate student ID
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "SELECT COUNT(*) FROM modern_gradesbook.student_info WHERE student_id = @studentID";
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@studentID", studentID);

                        int studentCount = Convert.ToInt32(db.cmd.ExecuteScalar());

                        if (studentCount > 0)
                        {
                            MessageBox.Show("A Student with the provided Student Number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Add Info to student_info table
                        db.cmd.CommandText = "INSERT INTO modern_gradesbook.student_info (student_id, first_name, last_name, middle_name) VALUES(@studentID, @firstName, @lastName, @middleName)";
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@studentID", studentID);
                        db.cmd.Parameters.AddWithValue("@firstName", firstName);
                        db.cmd.Parameters.AddWithValue("@lastName", lastName);
                        db.cmd.Parameters.AddWithValue("@middleName", middleName);

                        db.cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                        return;
                    }
                    finally
                    {
                        db.Disconnect();
                    }

                    // Get program id
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @year AND section = @section";
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@programName", programName);
                        db.cmd.Parameters.AddWithValue("@year", year);
                        db.cmd.Parameters.AddWithValue("@section", section);

                        // SelectCommand property select the sql command
                        db.dta.SelectCommand = db.cmd;

                        // DataTable
                        DataTable dataTable = new DataTable();
                        db.dta.Fill(dataTable); // populate dataTable

                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);
                        }
                        else
                        {
                            MessageBox.Show("Program not found. Please check the program details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                        return;
                    }
                    finally
                    {
                        db.Disconnect();
                    }

                    // Add info to section table
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "INSERT INTO modern_gradesbook.section(student_id, program_id) VALUES(@studentNumber, @programID)";
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@studentNumber", studentID);
                        db.cmd.Parameters.AddWithValue("@programID", programID);

                        db.cmd.ExecuteNonQuery();

                        if (MessageBox.Show("Student Added Successfully!", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtFName.Text = "";
                            txtLName.Text = "";
                            txtMName.Text = "";
                            txtStudentNum.Text = "";
                            cboProgram.SelectedItem = -1;
                            numSection.Value = 1;
                            numYear.Value = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
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
    }
}
