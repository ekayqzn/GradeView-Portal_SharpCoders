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
        public int classId;
        public string studentId = LogInOperation.userID.Trim();
        public Add_Class()
        {
            InitializeComponent();
        }

        private void rbtnAddClass_Click(object sender, EventArgs e)
        {
            classCode = txtClassCode.Text.Trim();
            if(!String.IsNullOrEmpty(classCode))
            {
                //check if the code exist by retrieving course_id
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "SELECT course_id, class_id FROM modern_gradesbook.course WHERE course_code = @courseCode";

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@courseCode", classCode);
                    db.dta.SelectCommand = db.cmd;

                    DataTable dataTable = new DataTable();
                    db.dta.Fill(dataTable);

                    if (dataTable.Rows.Count == 0) //code not exist
                    {
                        MessageBox.Show("Invalid Code", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtClassCode.Focus();
                        txtClassCode.SelectAll();
                    }
                    else //code exist
                    {
                        courseId = Convert.ToInt32(dataTable.Rows[0]["course_id"]);
                        classId = Convert.ToInt32(dataTable.Rows[0]["class_id"]);
                        MessageBox.Show(courseId.ToString() + Environment.NewLine + classId.ToString());
                        //Get subject code
                        try
                        {
                            db.Connect();
                            db.cmd.Connection = db.conn;
                            db.cmd.CommandText = "SELECT subject_code FROM modern_gradesbook.class WHERE class_id = @classID";

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@classID", classId);

                            db.dta.SelectCommand = db.cmd;
                            DataTable dataTable1 = new DataTable();
                            db.dta.Fill(dataTable1);

                            //student can't enroll in the same subject at the same time
                            if(dataTable1.Rows.Count == 0)
                            {
                                try //check if the student is already enrolled in the course
                                {
                                    db.Connect();
                                    db.cmd.Connection = db.conn;
                                    db.cmd.CommandText = "SELECT enroll_id FROM modern_gradesbook.enroll WHERE student_id = @studentID AND class_id = @classID";

                                    db.cmd.Parameters.Clear();
                                    db.cmd.Parameters.AddWithValue("@studentID", Student_Login.userID);
                                    db.cmd.Parameters.AddWithValue("@classID", classId);

                                    db.dta.SelectCommand = db.cmd;
                                    DataTable dataTable2 = new DataTable();
                                    db.dta.Fill(dataTable2);

                                    if (dataTable2.Rows.Count == 0) //student not enrolled yet
                                    {
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
                                                if (MessageBox.Show("Subject Added to Dashboard", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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
                                    else
                                    {
                                        //Student is already enrolled in specific subject in the same teacher
                                        MessageBox.Show("You are already enrolled in that subject", "Already Enrolled", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            else
                            {
                                MessageBox.Show("The code you input appears to be the same subject you are currently enrolled. Students can't enroll in the same subject at the same time");
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
            else
            {
                MessageBox.Show("Empty field is not accepted", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClassCode.Focus();
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
