﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace gradesBookApp
{
    public partial class Add_Section : Form
    {
        public static string programName;
        public static int section;
        public static int year;
        public static int programID;
        public static string courseCode;

        databaseConnection db = new databaseConnection();
        Randomize r = new Randomize();

        public Add_Section()
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
                string query = "SELECT MAX(year_level) AS max_year, MAX(section) AS max_section FROM program WHERE program_name = @programName";

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

        private void rbtnOK_Click(object sender, EventArgs e)
        {
            programName = cboProgram.SelectedItem.ToString().Trim();
            year = Convert.ToInt32(numYear.Value);
            section = Convert.ToInt32(numSection.Value);
            courseCode = r.GenerateRandomCode();

            //! Check for duplicates in database and course dashboard

            // Add program_id, class_id, and code to course table
            try
            {
                // Get program_id
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

                programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);

                // RANDOMLY GENERATED CODE
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "INSERT INTO course (class_id, program_id, course_code) VALUES(@class_id, @program_id, @code)";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@class_id", Teacher_s_Dashboard.classID);
                db.cmd.Parameters.AddWithValue("@program_id", programID);
                db.cmd.Parameters.AddWithValue("@code", courseCode);

                db.cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Disconnect();
                Course_Dashboard courseDB = new Course_Dashboard();
                this.Hide();
                courseDB.ShowDialog();
                this.Close();
            }
        }

        private void LoadDataIntoDropdown()
        {
            try
            {
                // Open the database connection
                db.Connect();

                // Query to retrieve distinct program names
                string query = "SELECT DISTINCT program_name FROM program";

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

        private void Add_Section_Load(object sender, EventArgs e)
        {
            LoadDataIntoDropdown();
        }
    }
}
