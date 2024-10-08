﻿using Mysqlx.Crud;
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
        public int programId;
        public string subjectCode;
        public string[] subjectCodeE;
        public string studentId = LogInOperation.userID.Trim();
        bool isValid = false;

        //For task table IDs
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

        string status = TheStudentDashboard.status;

        AddQuery a = new AddQuery();
        public Add_Class()
        {
            InitializeComponent();
        }

        private void rbtnAddClass_Click(object sender, EventArgs e)
        {
            courseCode = txtClassCode.Text.Trim();
            //MessageBox.Show(status);

            if (!String.IsNullOrEmpty(courseCode))
            {
                //check if the code exist by retrieving course_id
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "SELECT course_id, class_id, program_id FROM modern_gradesbook.course WHERE course_code = @courseCode";

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@courseCode", courseCode);
                    db.dta.SelectCommand = db.cmd;

                    DataTable dataTable = new DataTable();
                    db.dta.Fill(dataTable);

                    if (dataTable.Rows.Count == 0) //code not exist
                    {
                        MessageBox.Show("Try Again! The provided subject code is invalid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtClassCode.Focus();
                        txtClassCode.SelectAll();
                    }
                    else //code exist
                    {

                        courseId = Convert.ToInt32(dataTable.Rows[0]["course_id"]);
                        classId = Convert.ToInt32(dataTable.Rows[0]["class_id"]);
                        programId = Convert.ToInt32(dataTable.Rows[0]["program_id"]);

                        //MessageBox.Show(courseId.ToString() + Environment.NewLine + classId.ToString());

                        try //check if the student is already enrolled in the class associated with the code
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

                                for (int i = 0; i < subjectCodeE.Length; i++)
                                {
                                    if (subjectCode == subjectCodeE[i])
                                    {
                                        isEnrolled = true;
                                        break;
                                    }
                                    else
                                    {
                                        isEnrolled = false;
                                    }
                                }

                                if (isEnrolled)
                                {
                                    MessageBox.Show("You are already enrolled in this subject with a different instructor.", "Enrollment Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    //All previous validations are valid
                                    //If the student is irregular, she can enroll to any subjects and in any section
                                    if (status == "Irregular")
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
                                            if (mRecitation)
                                            {
                                                g.mOthersCopy("recitation", classId, studentId);
                                                g.insertToEnroll("m", "recitation", classId, studentId);
                                                //get ID of enroll insert to task table
                                                g.InsertEnrollId("m", "recitation", classId, studentId);
                                            }
                                            if (mActivity)
                                            {
                                                g.mOthersCopy("activity", classId, studentId);
                                                g.insertToEnroll("m", "activity", classId, studentId);
                                                //get ID of enroll insert to task table
                                                g.InsertEnrollId("m", "activity", classId, studentId);
                                            }
                                            if (mAssignment)
                                            {
                                                g.mOthersCopy("assignment", classId, studentId);
                                                g.insertToEnroll("m", "assignment", classId, studentId);
                                                //get ID of enroll insert to task table
                                                g.InsertEnrollId("m", "assignment", classId, studentId);
                                            }
                                            if (mLongQuiz)
                                            {
                                                g.mOthersCopy("longquiz", classId, studentId);
                                                g.insertToEnroll("m", "longquiz", classId, studentId);
                                                //get ID of enroll insert to task table
                                                g.InsertEnrollId("m", "longquiz", classId, studentId);
                                            }
                                            if (mQuiz)
                                            {
                                                g.mOthersCopy("quiz", classId, studentId);
                                                g.insertToEnroll("m", "quiz", classId, studentId);
                                                //get ID of enroll insert to task table
                                                g.InsertEnrollId("m", "quiz", classId, studentId);
                                            }
                                            if (mExam)
                                            {
                                                g.rdoCopy("m", "exam", classId, studentId);
                                                g.insertToEnroll("m", "exam", classId, studentId);
                                                //get ID of enroll insert to task table
                                                g.InsertEnrollId("m", "exam", classId, studentId);
                                            }
                                            if (mProject)
                                            {
                                                g.rdoCopy("m", "project", classId, studentId);
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
                                                g.rdoCopy("f", "exam", classId, studentId);
                                                g.insertToEnroll("f", "exam", classId, studentId);
                                                g.InsertEnrollId("f", "exam", classId, studentId);
                                            }
                                            if (fProject)
                                            {
                                                g.rdoCopy("f", "project", classId, studentId);
                                                g.insertToEnroll("f", "project", classId, studentId);
                                                g.InsertEnrollId("f", "project", classId, studentId);
                                            }

                                            if (isValid)
                                            {
                                                if (MessageBox.Show("Subject successfully added to your Dashboard", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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
                                    else if (status == "Regular")
                                    {
                                        try
                                        {
                                            db.Connect();
                                            db.cmd.Connection = db.conn;
                                            db.cmd.CommandText = "SELECT section_id FROM section WHERE program_id = @programID AND student_id = @studentID";

                                            db.cmd.Parameters.Clear();
                                            db.cmd.Parameters.AddWithValue("@programID", programId);
                                            db.cmd.Parameters.AddWithValue("@studentID", studentId);

                                            db.dta.SelectCommand = db.cmd;
                                            DataTable dt = new DataTable();
                                            db.dta.Fill(dt);

                                            if (dt.Rows.Count > 0)
                                            {
                                                // Meaning student can enroll since the programID of the course that she wants to enroll matched with her recorded program_id
                                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.enroll(student_id, program_id, class_id) SELECT @studentID, program_id, class_id FROM modern_gradesbook.course WHERE course_id = @courseID";

                                                db.cmd.Parameters.Clear();
                                                db.cmd.Parameters.AddWithValue("@studentID", studentId);
                                                db.cmd.Parameters.AddWithValue("@courseID", courseId);

                                                if (db.cmd.ExecuteNonQuery() > 0)
                                                {
                                                    isValid = true;
                                                }

                                                // Add student to class tasks table
                                                // Get ID of customized gradebook
                                                // Will be used to copy
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

                                                // Add copy for student if task is checked in customize gradebook
                                                // Variable has value if it is checked in customize gradebook
                                                if (mRecitation)
                                                {
                                                    g.mOthersCopy("recitation", classId, studentId);
                                                    g.insertToEnroll("m", "recitation", classId, studentId);
                                                    g.InsertEnrollId("m", "recitation", classId, studentId);
                                                }
                                                if (mActivity)
                                                {
                                                    g.mOthersCopy("activity", classId, studentId);
                                                    g.insertToEnroll("m", "activity", classId, studentId);
                                                    g.InsertEnrollId("m", "activity", classId, studentId);
                                                }
                                                if (mAssignment)
                                                {
                                                    g.mOthersCopy("assignment", classId, studentId);
                                                    g.insertToEnroll("m", "assignment", classId, studentId);
                                                    g.InsertEnrollId("m", "assignment", classId, studentId);
                                                }
                                                if (mLongQuiz)
                                                {
                                                    g.mOthersCopy("longquiz", classId, studentId);
                                                    g.insertToEnroll("m", "longquiz", classId, studentId);
                                                    g.InsertEnrollId("m", "longquiz", classId, studentId);
                                                }
                                                if (mQuiz)
                                                {
                                                    g.mOthersCopy("quiz", classId, studentId);
                                                    g.insertToEnroll("m", "quiz", classId, studentId);
                                                    g.InsertEnrollId("m", "quiz", classId, studentId);
                                                }
                                                if (mExam)
                                                {
                                                    g.rdoCopy("m", "exam", classId, studentId);
                                                    g.insertToEnroll("m", "exam", classId, studentId);
                                                    g.InsertEnrollId("m", "exam", classId, studentId);
                                                }
                                                if (mProject)
                                                {
                                                    g.rdoCopy("m", "project", classId, studentId);
                                                    g.insertToEnroll("m", "project", classId, studentId);
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
                                                    g.rdoCopy("f", "exam", classId, studentId);
                                                    g.insertToEnroll("f", "exam", classId, studentId);
                                                    g.InsertEnrollId("f", "exam", classId, studentId);
                                                }
                                                if (fProject)
                                                {
                                                    g.rdoCopy("f", "project", classId, studentId);
                                                    g.insertToEnroll("f", "project", classId, studentId);
                                                    g.InsertEnrollId("f", "project", classId, studentId);
                                                }

                                                if (isValid)
                                                {
                                                    if (MessageBox.Show("Subject successfully added to your Dashboard", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                                    {
                                                        this.Hide();
                                                        TheStudentDashboard studentDB = new TheStudentDashboard();
                                                        studentDB.ShowDialog();
                                                        this.Close();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Enrollment not permitted. Regular students cannot enroll in subjects outside their program curriculum.", "Enrollment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            db.Disconnect();
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //Student is already enrolled in specific subject in the same teacher
                                MessageBox.Show("You are already enrolled in the subject.", "Enrolment Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Try Again! No fields should be empty.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Add_Class_Load(object sender, EventArgs e)
        {
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT enrollment_status FROM section WHERE student_id = @studentID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", studentId);

                DataTable dt = new DataTable();

                db.dta.SelectCommand = db.cmd;
                db.dta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    status = dt.Rows[0]["enrollment_status"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occur: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

        }

        private void txtClassCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnAddClass_Click(sender, e); //call click event for add class
            }
        }
    }
}
