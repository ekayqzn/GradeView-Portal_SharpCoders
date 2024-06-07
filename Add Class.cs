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

namespace gradesBookApp
{
    public partial class Add_Class : Form
    {
        public static string classCode;
        databaseConnection db = new databaseConnection();
        public int courseId;
        public string studentId = Student_Login.userID.Trim();
        public Add_Class()
        {
            InitializeComponent();
        }

        private void rbtnAddClass_Click(object sender, EventArgs e)
        {
            classCode = txtClassCode.Text.Trim();

            //!ADD VALIDATION
            //check if the code exist by retrieving course_id
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT course_id FROM modern_gradesbook.course WHERE course_code = @courseCode";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@courseCode", classCode);
                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable);

                if(dataTable.Rows.Count == 0 ) //code not exist
                {
                    MessageBox.Show("Invalid Code");
                    txtClassCode.Focus();
                    txtClassCode.SelectAll();
                    
                }
                else
                {
                    courseId = Convert.ToInt32(dataTable.Rows[0]["course_id"]);
                    MessageBox.Show(courseId.ToString());
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

            //add student info to enroll
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "INSERT INTO modern_gradesbook.enroll(student_id, program_id, class_id) SELECT @studentID, program_id, class_id FROM modern_gradesbook.course WHERE course_id = @courseID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", studentId);
                db.cmd.Parameters.AddWithValue("@courseID", courseId);

                if (db.cmd.ExecuteNonQuery() > 0)
                {
                    if(MessageBox.Show("Subject Added to Dashboard", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Hide();
                        Student_s_Dashboard studentDB = new Student_s_Dashboard(); 
                        studentDB.ShowDialog();
                        this.Close();
                    }
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

        private void rbtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_s_Dashboard SDB = new Student_s_Dashboard();
            SDB.ShowDialog();
            this.Close();
        }
    }
}
