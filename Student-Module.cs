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
            TheStudentDashboard SDB = new TheStudentDashboard();
            SDB.ShowDialog();
            this.Close();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheStudentDashboard SDB = new TheStudentDashboard();
            SDB.ShowDialog();
            this.Close();
        }

        private void picBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TheStudentDashboard SDB = new TheStudentDashboard();
            SDB.ShowDialog();
            this.Close();
        }

        private void Student_Module_Load(object sender, EventArgs e)
        {
            yLocation = 130;
            xLocation = 20;
            try
            {
                if (TheStudentDashboard.mActivityID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "activity", (int)TheStudentDashboard.mActivityID);
                    s.GetRecordsOther("m", "activity", (int)TheStudentDashboard.mActivityID, count, this);
                }
                if (TheStudentDashboard.mAssignmentID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "assignment", (int)TheStudentDashboard.mAssignmentID);
                    s.GetRecordsOther("m", "assignment", (int)TheStudentDashboard.mAssignmentID, count, this);
                }
                if (TheStudentDashboard.mLongQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "longquiz", (int)TheStudentDashboard.mLongQuizID);
                    s.GetRecordsOther("m", "longquiz", (int)TheStudentDashboard.mLongQuizID, count, this);
                }
                if (TheStudentDashboard.mQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "quiz", (int)TheStudentDashboard.mQuizID);
                    s.GetRecordsOther("m", "quiz", (int)TheStudentDashboard.mQuizID, count, this);
                }
                if (TheStudentDashboard.mRecitationID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("m", "recitation", (int)TheStudentDashboard.mRecitationID);
                    s.GetRecordsOther("m", "recitation", (int)TheStudentDashboard.mRecitationID, count, this);
                }
                if (TheStudentDashboard.mExamID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("m", "exam", (int)TheStudentDashboard.mExamID, this);
                }
                if (TheStudentDashboard.mProjectID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("m", "project", (int)TheStudentDashboard.mProjectID, this);
                }

                if (TheStudentDashboard.fActivityID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "activity", (int)TheStudentDashboard.fActivityID);
                    s.GetRecordsOther("f", "activity", (int)TheStudentDashboard.fActivityID, count, this);
                }
                if (TheStudentDashboard.fAssignmentID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "assignment", (int)TheStudentDashboard.fAssignmentID);
                    s.GetRecordsOther("f", "assignment", (int)TheStudentDashboard.fAssignmentID, count, this);
                }
                if (TheStudentDashboard.fLongQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "longquiz", (int)TheStudentDashboard.fLongQuizID);
                    s.GetRecordsOther("f", "longquiz", (int)TheStudentDashboard.fLongQuizID, count, this);
                }
                if (TheStudentDashboard.fQuizID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "quiz", (int)TheStudentDashboard.fQuizID);
                    s.GetRecordsOther("f", "quiz", (int)TheStudentDashboard.fQuizID, count, this);
                }
                if (TheStudentDashboard.fRecitationID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    int count = q.GetCount("f", "recitation", (int)TheStudentDashboard.fRecitationID);
                    s.GetRecordsOther("f", "recitation", (int)TheStudentDashboard.fRecitationID, count, this);
                }
                if (TheStudentDashboard.fExamID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("f", "exam", (int)TheStudentDashboard.fExamID, this);

                }
                if (TheStudentDashboard.fProjectID != null)
                {
                    dtScores.Columns.Clear();
                    dtScores.Rows.Clear();
                    s.GetRecordRdo("f", "project", (int)TheStudentDashboard.fProjectID, this);
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
