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
            if (cboProgram.SelectedItem.ToString() == "Bachelor of Science in Information Technology" || cboProgram.SelectedItem.ToString() == "Bachelor of Science in Hospitality Management" || cboProgram.SelectedItem.ToString() == "Bachelor of Secondary Education major in English" || cboProgram.SelectedItem.ToString() == "Bachelor of Secondary Education major in Mathematics")
            {
                numSection.Maximum = 2;
                numSection.Minimum = 1;
            }
            else if (cboProgram.SelectedItem.ToString() == "Bachelor of Science in Accountancy" || cboProgram.SelectedItem.ToString() == "Bachelor of Science in Computer Engineering")
            {
                numSection.Maximum = 1;
                numSection.Minimum = 1;
            }
            else if (cboProgram.SelectedItem.ToString() == "Bachelor of Science in Entrepreneurship")
            {
                numSection.Maximum = 3;
                numSection.Minimum = 1;
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Disconnect();
            }
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
            this.Close();
        }
    }
}
