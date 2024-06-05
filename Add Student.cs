using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

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
                        int maxYear = reader.GetInt32("max_year");
                        int maxSection = reader.GetInt32("max_section");

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
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                db.Disconnect();
            }
        }


        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            //Retrieve data from input
            studentID = txtStudentNum.Text.Trim();
            firstName = txtFName.Text.Trim();
            lastName = txtLName.Text.Trim();
            middleName = txtMName.Text.Trim();
            programName = cboProgram.SelectedItem.ToString().Trim();
            year = Convert.ToInt32(numYear.Value);
            section = Convert.ToInt32(numSection.Value);

            //!Add Validation

            //Add Info to student_info table
            try
            {
                //! Add duplicate check
                db.Connect();
                db.cmd.Connection = db.conn;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }

            //Get program id
            try
            {
                //Get program_id
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @year AND section = @section";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programName", programName);
                db.cmd.Parameters.AddWithValue("@year", year);
                db.cmd.Parameters.AddWithValue("@section", section);

                //SelectCommand property select the sql command
                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            { 
                db.Disconnect(); 
            }
                //Add info to section table
            try
            {
                //!Add duplicate check
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "INSERT INTO modern_gradesbook.section(student_id, program_id) VALUES(@studentNumber, @programID)";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentNumber", studentID);
                db.cmd.Parameters.AddWithValue("@programID", programID);

                db.cmd.ExecuteNonQuery();

                //DEbug tool
                //MessageBox.Show("Added");
                if (MessageBox.Show("Student Added!", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    txtFName.Text = "";
                    txtLName.Text = "";
                    txtMName.Text = "";
                    txtStudentNum.Text = "";
                    cboProgram.Text = "Bachelor of Science in Information Technology";
                    numSection.Value = 1;
                    numYear.Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }
        }


        private void LoadDataIntoDropdown()
        {
            try
            {
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
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                db.Disconnect();
            }
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage l = new LandingPage();
            l.ShowDialog();
            this.Close();
        }

        private void Add_Student_Load(object sender, EventArgs e)
        {
            LoadDataIntoDropdown();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
