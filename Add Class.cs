using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public partial class Add_Class : Form
    {
        public static string courseCode;
        databaseConnection db = new databaseConnection();
        GradebookQuery g = new GradebookQuery();
        public int courseId;
        public int classId;
        public string subjectCode;
        public string[] subjectCodeE;
        public string studentId = LogInOperation.userID.Trim();
        bool isValid = false;

        bool mAttendance = false;
        bool mQuiz = false;
        bool mRecitation = false;
        bool mActivity = false;
        bool mAssignment = false;
        bool mLongQuiz = false;

        bool fAttendance = false;
        bool fQuiz = false;
        bool fRecitation = false;
        bool fActivity = false;
        bool fAssignment = false;
        bool fLongQuiz = false;
        public Add_Class()
        {
            InitializeComponent();
        }

        private void rbtnAddClass_Click(object sender, EventArgs e)
        {
            courseCode = txtClassCode.Text.Trim();

            if (!String.IsNullOrEmpty(courseCode))
            {
                //check if the code exist by retrieving course_id
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "SELECT course_id, class_id FROM modern_gradesbook.course WHERE course_code = @courseCode";

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@courseCode", courseCode);
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
                        
                        //MessageBox.Show(courseId.ToString() + Environment.NewLine + classId.ToString());

                        try //check if the student is already enrolled in the specific subject
                        {
                            db.Connect();
                            db.cmd.Connection = db.conn;
                            db.cmd.CommandText = "SELECT enroll_id FROM modern_gradesbook.enroll WHERE student_id = @studentID AND class_id = @classID";

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@studentID", LogInOperation.userID);
                            db.cmd.Parameters.AddWithValue("@classID", classId);

                            db.dta.SelectCommand = db.cmd;
                            DataTable dataTable2 = new DataTable();
                            db.dta.Fill(dataTable2);

                            if (dataTable2.Rows.Count == 0) //student not enrolled yet to specific class
                            {

                                //check if the code is not the same subject as the student already enrolled to
     
                                try //get the subject code of the given course_code
                                {
                                    db.Connect();
                                    db.cmd.Connection = db.conn;
                                    db.cmd.CommandText = "SELECT cl.subject_code AS subject_code FROM modern_gradesbook.class cl JOIN course c ON cl.class_id = c.class_id WHERE c.course_code = @courseCode";

                                    db.cmd.Parameters.Clear();
                                    db.cmd.Parameters.AddWithValue("@courseCode", courseCode);

                                    db.dta.SelectCommand = db.cmd;
                                    DataTable subCode = new DataTable();
                                    db.dta.Fill(subCode);
                                    if (subCode.Rows.Count > 0)
                                    {
                                            subjectCode = subCode.Rows[0]["subject_code"].ToString();
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

                                try //get the subject code of the given student_id in enroll
                                {
                                    db.Connect();
                                    db.cmd.Connection = db.conn;
                                    db.cmd.CommandText = "SELECT cl.subject_code AS subject_code FROM class cl JOIN enroll e ON cl.class_id = e.class_id WHERE e.student_id = @studentID";

                                    db.cmd.Parameters.Clear();
                                    db.cmd.Parameters.AddWithValue("@studentID", LogInOperation.userID);

                                    db.dta.SelectCommand = db.cmd;
                                    DataTable subCodeEnroll = new DataTable();
                                    db.dta.Fill(subCodeEnroll);
                                    subjectCodeE = new string[subCodeEnroll.Rows.Count];
                                    for (int i = 0; i < subCodeEnroll.Rows.Count; i++)
                                    {
                                        subjectCodeE[i] = subCodeEnroll.Rows[i]["subject_code"].ToString();
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

                                bool isEnrolled = false;

                                for(int i = 0; i < subjectCodeE.Length; i++)
                                {
                                    if(subjectCode == subjectCodeE[i])
                                    {
                                        isEnrolled = true;
                                        break;
                                    }
                                    else
                                    {
                                        isEnrolled = false;
                                    }
                                }

                                if(isEnrolled)
                                {
                                    MessageBox.Show("You are already enrolled in this subject in different teacher", "Already Enrolled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
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
                                            isValid = true;
                                        }

                                        //Add student to class tasks table
                                        mActivity = g.mGetID("activity", classId);
                                        mAssignment = g.mGetID("assignment", classId);
                                        mAttendance = g.mGetID("attendance", classId);
                                        mLongQuiz = g.mGetID("longquiz", classId);
                                        mQuiz = g.mGetID("quiz", classId);
                                        mRecitation = g.mGetID("recitation", classId);

                                        fActivity = g.fGetID("activity", classId);
                                        fAssignment = g.fGetID("assignment", classId);
                                        fAttendance = g.fGetID("attendance", classId);
                                        fLongQuiz = g.fGetID("longquiz", classId);
                                        fQuiz = g.fGetID("quiz", classId);
                                        fRecitation = g.fGetID("recitation", classId);

                                        if(mAttendance)
                                        {
                                            g.mAttRecitCopy("attendance", classId, studentId);
                                        }
                                        if(mRecitation)
                                        {
                                            g.mAttRecitCopy("recitation", classId, studentId);
                                        }
                                        if(mActivity)
                                        {
                                            g.mOthersCopy("activity", classId, studentId);
                                        }
                                        if(mAssignment)
                                        {
                                            g.mOthersCopy("assignment", classId, studentId);
                                        }
                                        if(mLongQuiz)
                                        {
                                            g.mOthersCopy("longquiz", classId, studentId);
                                        }
                                        if(mQuiz)
                                        {
                                            g.mOthersCopy("quiz", classId, studentId);
                                        }

                                        if (fAttendance)
                                        {
                                            g.fAttRecitCopy("attendance", classId, studentId);
                                        }
                                        if (fRecitation)
                                        {
                                            g.fAttRecitCopy("recitation", classId, studentId);
                                        }
                                        if (fActivity)
                                        {
                                            g.fOthersCopy("activity", classId, studentId);
                                        }
                                        if (fAssignment)
                                        {
                                            g.fOthersCopy("assignment", classId, studentId);
                                        }
                                        if (fLongQuiz)
                                        {
                                            g.fOthersCopy("longquiz", classId, studentId);
                                        }
                                        if (fQuiz)
                                        {
                                            g.fOthersCopy("quiz", classId, studentId);
                                        }

                                        if (isValid)
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
