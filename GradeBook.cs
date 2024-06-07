using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public partial class GradeBook : Form
    {
        databaseConnection db = new databaseConnection();
        public static int programID;
        public static int courseID;
        DataTable dt = new DataTable();
        public GradeBook()
        {
            InitializeComponent();
        }

        private void GradeBook_Load(object sender, EventArgs e)
        {
            string subjectName = "";
            string subjectCode = Teacher_s_Dashboard.subjectTile.Trim(); // Trim any extra spaces

            // Get the clicked subject name from the database. Display above
            try
            {
                db.Connect();

                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT subject_name FROM modern_gradesbook.subject_info WHERE subject_code = @subjectCode";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@subjectCode", subjectCode);

                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    subjectName = dataTable.Rows[0]["subject_name"].ToString();
                    Label label = new Label();
                    label.Text = Teacher_s_Dashboard.subjectTile + Environment.NewLine + subjectName + Environment.NewLine + Course_Dashboard.programName + Environment.NewLine + Course_Dashboard.yearLevel + " - " + Course_Dashboard.section + Environment.NewLine + "Code: " + Course_Dashboard.courseCode;
                    label.Location = new Point(35, 35);
                    label.AutoSize = true;
                    this.Controls.Add(label);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.Disconnect();
            }

            ////Get program ID of the clicked section tile
            //try
            //{
            //    db.Connect();
            //    db.cmd.Connection = db.conn;
            //    db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @yearLevel AND section = @section";

            //    db.cmd.Parameters.Clear();
            //    db.cmd.Parameters.AddWithValue("@programName", Course_Dashboard.programName);
            //    db.cmd.Parameters.AddWithValue("@yearLevel", Course_Dashboard.yearLevel);
            //    db.cmd.Parameters.AddWithValue("@section", Course_Dashboard.section);

            //    db.dta.SelectCommand = db.cmd;

            //    DataTable dataTable = new DataTable();
            //    db.dta.Fill(dataTable);

            //    if(dataTable.Rows.Count > 0)
            //    {
            //        programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    db.Disconnect();
            //}

            ////Get course_id
            //try
            //{
            //    db.Connect();
            //    db.cmd.Connection = db.conn;
            //    db.cmd.CommandText = "SELECT course_id FROM modern_gradesbook.course WHERE program_id = @programID AND class_id = @classID";

            //    db.cmd.Parameters.Clear();
            //    db.cmd.Parameters.AddWithValue("@programID", programID);
            //    db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID);

            //    db.dta.SelectCommand = db.cmd;

            //    DataTable dataTable = new DataTable();
            //    db.dta.Fill(dataTable);

            //    if (dataTable.Rows.Count > 0)
            //    {
            //        courseID = Convert.ToInt32(dataTable.Rows[0]["course_id"]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    db.Disconnect();
            //}

            //Insert to Enroll Table info . THE FF CODE SHOULD BE WHEN THE STUDENT ADDED THE CODE TO HER DASHBOARD
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                /* 
                 * The LEFT JOIN ensures that you are joining the section table with the enroll table on student_id, class_id, and program_id.
The condition e.student_id IS NULL ensures that only those student_ids from the section table that do not already exist in the enroll table (with the specified class_id and program_id) are selected for insertion.
This way, if the student_id, class_id, and program_id combination already exists in the enroll table, the student_id will not be included in the insert.
                */
                db.cmd.CommandText = "INSERT INTO modern_gradesbook.enroll (student_id, class_id, program_id) " +
                         "SELECT s.student_id, @classID, @programID " +
                         "FROM modern_gradesbook.section s " +
                         "LEFT JOIN modern_gradesbook.enroll e ON s.student_id = e.student_id AND e.class_id = @classID AND e.program_id = @programID " +
                         "WHERE s.program_id = @programID AND e.student_id IS NULL";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programID", programID);
                db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID);
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

            //Add to Datagridview student
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT CONCAT(student_info.last_name, ', ', student_info.first_name, ' ', student_info.middle_name) AS Name FROM student_info JOIN enroll e ON student_info.student_id = e.student_id WHERE e.program_id = @programID AND e.class_id = @classID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programID", programID);
                db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID);

                db.dta.SelectCommand = db.cmd;

                db.dta.Fill(dt);
                dataGridView1.DataSource = dt;


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

        private void LinkLBLback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Course_Dashboard CDB = new Course_Dashboard();
            CDB.ShowDialog();
            this.Close();
        }

        private void rbtnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_GradeBook EGB = new Edit_GradeBook();
            EGB.ShowDialog();
            this.Close();
        }
    }
}
