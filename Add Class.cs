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

        bool mQuiz = false;
        bool mRecitation = false;
        bool mActivity = false;
        bool mAssignment = false;
        bool mLongQuiz = false;
        bool mExam = false;
        bool mProject = false;

        bool fQuiz = false;
        bool fRecitation = false;
        bool fActivity = false;
        bool fAssignment = false;
        bool fLongQuiz = false;
        bool fExam = false;
        bool fProject = false;
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

                                        //!add enroll column

                                        //Add student to class tasks table
                                        //Get ID of customized gradebook
                                        //Will be used to copy
                                        mActivity = g.mGetID("activity", classId);
                                        mAssignment = g.mGetID("assignment", classId);
                                        mLongQuiz = g.mGetID("longquiz", classId);
                                        mQuiz = g.mGetID("quiz", classId);
                                        mRecitation = g.mGetID("recitation", classId);
                                        mExam = g.mGetID("exam", classId);
                                        mProject = g.mGetID("project", classId);

                                        fActivity = g.fGetID("activity", classId);
                                        fAssignment = g.fGetID("assignment", classId);
                                        fLongQuiz = g.fGetID("longquiz", classId);
                                        fQuiz = g.fGetID("quiz", classId);
                                        fRecitation = g.fGetID("recitation", classId);
                                        fExam = g.fGetID("exam", classId);
                                        fProject = g.fGetID("project", classId);

                                        //Add copy for student if task is checked in customize gradebook
                                        //variable has value if it is checked in customize gradebook
                                        if(mRecitation)
                                        {
                                            g.mOthersCopy("recitation", classId, studentId);
                                            g.insertToEnroll("m", "recitation", classId, studentId);
                                            //get ID of enroll insert to task table
                                            g.InsertEnrollId("m", "recitation", classId, studentId);
                                        }
                                        if(mActivity)
                                        {
                                            g.mOthersCopy("activity", classId, studentId);
                                            g.insertToEnroll("m", "activity", classId, studentId);
                                            //get ID of enroll insert to task table
                                            g.InsertEnrollId("m", "activity", classId, studentId);
                                        }
                                        if(mAssignment)
                                        {
                                            g.mOthersCopy("assignment", classId, studentId);
                                            g.insertToEnroll("m", "assignment", classId, studentId);
                                            //get ID of enroll insert to task table
                                            g.InsertEnrollId("m", "assignment", classId, studentId);
                                        }
                                        if(mLongQuiz)
                                        {
                                            g.mOthersCopy("longquiz", classId, studentId);
                                            g.insertToEnroll("m", "longquiz", classId, studentId);
                                            //get ID of enroll insert to task table
                                            g.InsertEnrollId("m", "longquiz", classId, studentId);
                                        }
                                        if(mQuiz)
                                        {
                                            g.mOthersCopy("quiz", classId, studentId);
                                            g.insertToEnroll("m", "quiz", classId, studentId);
                                            //get ID of enroll insert to task table
                                            g.InsertEnrollId("m", "quiz", classId, studentId);
                                        }
                                        if(mExam)
                                        {
                                            g.mRdoCopy("exam", classId, studentId);
                                            g.insertToEnroll("m", "exam", classId, studentId);
                                            //get ID of enroll insert to task table
                                            g.InsertEnrollId("m", "exam", classId, studentId);
                                        }
                                        if (mProject)
                                        {
                                            g.mRdoCopy("project", classId, studentId);
                                            g.insertToEnroll("m", "project", classId, studentId);
                                            //get ID of enroll insert to task table
                                            g.InsertEnrollId("m", "project", classId, studentId);
                                        }

                                        if (fRecitation)
                                        {
                                            g.fOthersCopy("recitation", classId, studentId);
                                            g.insertToEnroll("f", "recitation", classId, studentId);
                                            g.InsertEnrollId("f", "recitation", classId, studentId);
                                        }
                                        if (fActivity)
                                        {
                                            g.fOthersCopy("activity", classId, studentId);
                                            g.insertToEnroll("f", "activity", classId, studentId);
                                            g.InsertEnrollId("f", "activity", classId, studentId);
                                        }
                                        if (fAssignment)
                                        {
                                            g.fOthersCopy("assignment", classId, studentId);
                                            g.insertToEnroll("f", "assignment", classId, studentId);
                                            g.InsertEnrollId("f", "assignment", classId, studentId);
                                        }
                                        if (fLongQuiz)
                                        {
                                            g.fOthersCopy("longquiz", classId, studentId);
                                            g.insertToEnroll("f", "longquiz", classId, studentId);
                                            g.InsertEnrollId("f", "longquiz", classId, studentId);
                                        }
                                        if (fQuiz)
                                        {
                                            g.fOthersCopy("quiz", classId, studentId);
                                            g.insertToEnroll("f", "quiz", classId, studentId);
                                            g.InsertEnrollId("f", "quiz", classId, studentId);
                                        }
                                        if (fExam)
                                        {
                                            g.fRdoCopy("exam", classId, studentId);
                                            g.insertToEnroll("f", "exam", classId, studentId);
                                            g.InsertEnrollId("f", "exam", classId, studentId);
                                        }
                                        if (fProject)
                                        {
                                            g.fRdoCopy("project", classId, studentId);
                                            g.insertToEnroll("f", "project", classId, studentId);
                                            g.InsertEnrollId("f", "project", classId, studentId);
                                        }

                                        if (isValid)
                                        {
                                            if (MessageBox.Show("Subject Added to Dashboard", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                            {
                                                this.Hide();
                                                TheStudentDashboard studentDB = new TheStudentDashboard();
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
           TheStudentDashboard SDB = new TheStudentDashboard();
            SDB.ShowDialog();
            this.Close();
        }
    }
}
