﻿using MySql.Data.MySqlClient;
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
        GradebookQuery g = new GradebookQuery();
        GetRecordQuery q = new GetRecordQuery();

        public static DataTable dtDisplay = new DataTable();
        public static DataRow newRow = dtDisplay.NewRow();
        public static decimal mWritten = 0;
        public static decimal mFinalReq = 0;
        public static decimal fWritten = 0;
        public static decimal fFinalReq = 0;

        public static decimal midtermGrade = 0;
        public static decimal finalGrade = 0;
        public static decimal gwa = 0;
        public GradeBook()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell value is -1
            if (e.Value != null && e.Value is int && (int)e.Value == -1)
            {
                // Set the display value to empty string
                e.Value = string.Empty;
                e.FormattingApplied = true; // Indicate that the formatting was applied
            }
            else if (e.Value != null && e.Value is string && int.TryParse((string)e.Value, out int result) && result == -1)
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
            }
        }

        private void GradeBook_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            dtDisplay.Rows.Clear();
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
                    label.Location = new Point(20, 80);
                    label.AutoSize = true;
                    label.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                    label.ForeColor = Color.FromArgb(0, 4, 93);
                    this.Controls.Add(label);
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

            //Get program ID of the clicked section tile
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @yearLevel AND section = @section";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programName", Course_Dashboard.programName);
                db.cmd.Parameters.AddWithValue("@yearLevel", Course_Dashboard.yearLevel);
                db.cmd.Parameters.AddWithValue("@section", Course_Dashboard.section);

                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);
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

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;

                // Retrieve IDs
                db.cmd.CommandText = "SELECT student_id, m_activity_id, m_assignment_id, m_attendance_id, m_longquiz_id, m_quiz_id, m_project_id, m_exam_id, m_recitation_id, f_activity_id, f_assignment_id, f_attendance_id, f_longquiz_id, f_quiz_id, f_project_id, f_exam_id, f_recitation_id FROM enroll WHERE program_id = @programID AND class_id = @classID";

                DataTable dtIDs = new DataTable();

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programID", programID);
                db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID);

                // Log the parameters FOR DEBUG
                //MessageBox.Show($"Query: {db.cmd.CommandText}\nParameters:\nprogramID: {programID}\nclassID: {Teacher_s_Dashboard.classID}");

                db.dta.SelectCommand = db.cmd;
                db.dta.Fill(dtIDs);


                List <string> studentIDs = new List<string>(); //List of StudentID

                List<int?> mActivityID = new List<int?>();
                List<int?> mAssignmentID = new List<int?>();
                List<int?> mAttendanceID = new List<int?>();
                List<int?> mLongQuizID = new List<int?>();
                List<int?> mQuizID = new List<int?>();
                List<int?> mRecitationID = new List<int?>();
                List<int?> mExamID = new List<int?>();
                List<int?> mProjectID = new List<int?>();

                List<int?> fActivityID = new List<int?>();
                List<int?> fAssignmentID = new List<int?>();
                List<int?> fAttendanceID = new List<int?>();
                List<int?> fLongQuizID = new List<int?>();
                List<int?> fQuizID = new List<int?>();
                List<int?> fRecitationID = new List<int?>();
                List<int?> fExamID = new List<int?>();
                List<int?> fProjectID = new List<int?>();

                // Debugging: Check if data is retrieved
                if (dtIDs.Rows.Count == 0)
                {
                    MessageBox.Show("No data retrieved from the database.");
                    return;
                }
                else
                {
                    foreach(DataRow row in dtIDs.Rows)
                    {
                        studentIDs.Add((row["student_id"] == DBNull.Value) ? null : row["student_id"].ToString());

                        mActivityID.Add((row["m_activity_id"] == DBNull.Value) ? null : (int?)row["m_activity_id"]);
                        mAssignmentID.Add((row["m_assignment_id"] == DBNull.Value) ? null : (int?)row["m_assignment_id"]);
                        mAttendanceID.Add((row["m_attendance_id"] == DBNull.Value) ? null : (int?)row["m_attendance_id"]);
                        mLongQuizID.Add((row["m_longquiz_id"] == DBNull.Value) ? null : (int?)row["m_longquiz_id"]);
                        mQuizID.Add((row["m_quiz_id"] == DBNull.Value) ? null : (int?)row["m_quiz_id"]);
                        mRecitationID.Add((row["m_recitation_id"] == DBNull.Value) ? null : (int?)row["m_recitation_id"]);
                        mExamID.Add((row["m_exam_id"] == DBNull.Value) ? null : (int?)row["m_exam_id"]);
                        mProjectID.Add((row["m_project_id"] == DBNull.Value) ? null : (int?)row["m_project_id"]);

                        fActivityID.Add((row["f_activity_id"] == DBNull.Value) ? null : (int?)row["f_activity_id"]);
                        fAssignmentID.Add((row["f_assignment_id"] == DBNull.Value) ? null : (int?)row["f_assignment_id"]);
                        fAttendanceID.Add((row["f_attendance_id"] == DBNull.Value) ? null : (int?)row["f_attendance_id"]);
                        fLongQuizID.Add((row["f_longquiz_id"] == DBNull.Value) ? null : (int?)row["f_longquiz_id"]);
                        fQuizID.Add((row["f_quiz_id"] == DBNull.Value) ? null : (int?)row["f_quiz_id"]);
                        fRecitationID.Add((row["f_recitation_id"] == DBNull.Value) ? null : (int?)row["f_recitation_id"]);
                        fExamID.Add((row["f_exam_id"] == DBNull.Value) ? null : (int?)row["f_exam_id"]);
                        fProjectID.Add((row["f_project_id"] == DBNull.Value) ? null : (int?)row["f_project_id"]);
                    }
                }

                dtDisplay.Columns.Clear();
                dtDisplay.Columns.Add("student_id");
                dtDisplay.Columns.Add("student_name");

                for (int i = 0; i < studentIDs.Count; i++)
                {
                    newRow = dtDisplay.NewRow();
                    newRow["student_id"] = studentIDs[i];
                    newRow["student_name"] = q.GetStudentName(studentIDs[i]);

                    if (mActivityID[i] != null)
                    {
                        int count = q.GetCount("m", "activity", (int)mActivityID[i]);
                        mWritten += q.GetRecordsOther("m", "activity", (int)mActivityID[i], count);
                    }
                    if(mAssignmentID[i] != null)
                    {
                        int count = q.GetCount("m", "assignment", (int)mAssignmentID[i]);
                        mWritten += q.GetRecordsOther("m", "assignment", (int)mAssignmentID[i], count);
                    }
                    if (mAttendanceID[i] != null)
                    {
                        int count = q.GetCount("m", "attendance", (int)mAttendanceID[i]);
                        mWritten += q.GetRecordAttRecit("m", "attendance", (int)mAttendanceID[i], count);
                    }
                    if (mLongQuizID[i] != null)
                    {
                        int count = q.GetCount("m", "longquiz", (int)mLongQuizID[i]);
                        mWritten += q.GetRecordsOther("m", "longquiz", (int)mLongQuizID[i], count);
                    }
                    if (mQuizID[i] != null)
                    {
                        int count = q.GetCount("m", "quiz", (int)mQuizID[i]);
                        mWritten += q.GetRecordsOther("m", "quiz", (int)mQuizID[i], count);
                    }
                    if (mRecitationID[i] != null)
                    {
                        int count = q.GetCount("m", "recitation", (int)mRecitationID[i]);
                        mWritten += q.GetRecordAttRecit("m", "recitation", (int)mRecitationID[i], count);
                    }
                    if (mExamID[i] != null)
                    {
                        mFinalReq = q.GetRecordRdo("m", "exam", (int)mExamID[i]);
                    }
                    if (mProjectID[i] != null)
                    {
                        q.GetRecordRdo("m", "project", (int)mProjectID[i]);
                        mFinalReq = q.GetRecordRdo("m", "exam", (int)mExamID[i]);
                    }

                    midtermGrade = mWritten + mFinalReq;

                    if (fActivityID[i] != null)
                    {
                        int count = q.GetCount("f", "activity", (int)fActivityID[i]);
                        fWritten += q.GetRecordsOther("f", "activity", (int)fActivityID[i], count);
                    }
                    if (fAssignmentID[i] != null)
                    {
                        int count = q.GetCount("f", "assignment", (int)fAssignmentID[i]);
                        fWritten += q.GetRecordsOther("f", "assignment", (int)fAssignmentID[i], count);
                    }
                    if (fAttendanceID[i] != null)
                    {
                        int count = q.GetCount("f", "attendance", (int)fAttendanceID[i]);
                        fWritten += q.GetRecordAttRecit("f", "attendance", (int)fAttendanceID[i], count);
                    }
                    if (fLongQuizID[i] != null)
                    {
                        int count = q.GetCount("f", "longquiz", (int)fLongQuizID[i]);
                        fWritten += q.GetRecordsOther("f", "longquiz", (int)fLongQuizID[i], count);
                    }
                    if (fQuizID[i] != null)
                    {
                        int count = q.GetCount("f", "quiz", (int)fQuizID[i]);
                        fWritten += q.GetRecordsOther("f", "quiz", (int)fQuizID[i], count);
                    }
                    if (fRecitationID[i] != null)
                    {
                        int count = q.GetCount("f", "recitation", (int)fRecitationID[i]);
                        fWritten += q.GetRecordAttRecit("f", "recitation", (int)fRecitationID[i], count);
                    }
                    if (fExamID[i] != null)
                    {
                        fFinalReq = q.GetRecordRdo("f", "exam", (int)fExamID[i]);
                        
                    }
                    if (fProjectID[i] != null)
                    {
                        fFinalReq = q.GetRecordRdo("f", "project", (int)fProjectID[i]);
                    }

                    finalGrade = fWritten + fFinalReq;

                    if ((!GradeBook.dtDisplay.Columns.Contains("Final Grade")))
                    {
                        dtDisplay.Columns.Add("Final Grade");
                    }



                    gwa = (midtermGrade + finalGrade) / 2;
                    newRow["Final Grade"] = gwa.ToString("0.00");

                    dtDisplay.Rows.Add(newRow);
                    dataGridView1.DataSource = dtDisplay;

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

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Course_Dashboard CDB = new Course_Dashboard();
            CDB.ShowDialog();
            this.Close();
        }
    }
}
