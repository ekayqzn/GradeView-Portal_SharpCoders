using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public partial class Student_Module : Form
    {
        GetRecordQuery q = new GetRecordQuery();
        GetStudentScore s = new GetStudentScore();
        public static DataTable dtScores = new DataTable();
        public static int yLocation = 130;
        public static int xLocation = 20;
        public static int countLabel = 1;
        public static bool isComplete = true;
        public Student_Module()
        {
            InitializeComponent();
        }

        private void LinkLBLback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Student_s_Dashboard SDB = new Student_s_Dashboard();
            SDB.ShowDialog();
            this.Close();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_s_Dashboard SDB = new Student_s_Dashboard();
            SDB.ShowDialog();
            this.Close();
        }

        private void picBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Student_s_Dashboard SDB = new Student_s_Dashboard();
            SDB.ShowDialog();
            this.Close();
        }

        private void Student_Module_Load(object sender, EventArgs e)
        {
            yLocation = 130;
            xLocation = 20;
            try
            {
                if (Student_s_Dashboard.mActivityID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "activity", (int)Student_s_Dashboard.mActivityID);
                    s.GetRecordsOther("m", "activity", (int)Student_s_Dashboard.mActivityID, count, this);
                }
                if (Student_s_Dashboard.mAssignmentID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "assignment", (int)Student_s_Dashboard.mAssignmentID);
                    s.GetRecordsOther("m", "assignment", (int)Student_s_Dashboard.mAssignmentID, count, this);
                }
                if (Student_s_Dashboard.mLongQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "longquiz", (int)Student_s_Dashboard.mLongQuizID);
                    s.GetRecordsOther("m", "longquiz", (int)Student_s_Dashboard.mLongQuizID, count, this);
                }
                if (Student_s_Dashboard.mQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "quiz", (int)Student_s_Dashboard.mQuizID);
                    s.GetRecordsOther("m", "quiz", (int)Student_s_Dashboard.mQuizID, count, this);
                }
                if (Student_s_Dashboard.mRecitationID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "recitation", (int)Student_s_Dashboard.mRecitationID);
                    s.GetRecordsOther("m", "recitation", (int)Student_s_Dashboard.mRecitationID, count, this);
                }
                if (Student_s_Dashboard.mExamID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("m", "exam", (int)Student_s_Dashboard.mExamID, this);
                }
                if (Student_s_Dashboard.mProjectID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("m", "project", (int)Student_s_Dashboard.mProjectID, this);
                }

                if (Student_s_Dashboard.fActivityID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "activity", (int)Student_s_Dashboard.fActivityID);
                    s.GetRecordsOther("f", "activity", (int)Student_s_Dashboard.fActivityID, count, this);
                }
                if (Student_s_Dashboard.fAssignmentID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "assignment", (int)Student_s_Dashboard.fAssignmentID);
                    s.GetRecordsOther("f", "assignment", (int)Student_s_Dashboard.fAssignmentID, count, this);
                }
                if (Student_s_Dashboard.fLongQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "longquiz", (int)Student_s_Dashboard.fLongQuizID);
                    s.GetRecordsOther("f", "longquiz", (int)Student_s_Dashboard.fLongQuizID, count, this);
                }
                if (Student_s_Dashboard.fQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "quiz", (int)Student_s_Dashboard.fQuizID);
                    s.GetRecordsOther("f", "quiz", (int)Student_s_Dashboard.fQuizID, count, this);
                }
                if (Student_s_Dashboard.fRecitationID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "recitation", (int)Student_s_Dashboard.fRecitationID);
                    s.GetRecordsOther("f", "recitation", (int)Student_s_Dashboard.fRecitationID, count, this);
                }
                if (Student_s_Dashboard.fExamID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("f", "exam", (int)Student_s_Dashboard.fExamID, this);

                }
                if (Student_s_Dashboard.fProjectID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("f", "project", (int)Student_s_Dashboard.fProjectID, this);
                }

                if(isComplete)
                {
                    lblStatus.Text = "Complete";
                    lblStatus.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }

        }
    }
}
