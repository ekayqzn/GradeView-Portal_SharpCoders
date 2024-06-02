using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gradesBookApp
{
    public partial class CustomizeGrade : Form
    {
        //Declare variable
        public static int mAttendanceCount;
        public static int mAttendancePercent;

        public static int mQuizCount;
        public static int mQuizPercent;

        public static int mActivityCount;
        public static int mActivityPercent;

        public static int mLongQuizCount;
        public static int mLongQuizPercent;

        public static int mAssignmentCount;
        public static int mAssignmentPercent;

        public static int mRecitationCount;
        public static int mRecitationPercent;

        public static int fAttendanceCount;
        public static int fAttendancePercent;

        public static int fQuizCount;
        public static int fQuizPercent;

        public static int fActivityCount;
        public static int fActivityPercent;

        public static int fLongQuizCount;
        public static int fLongQuizPercent;

        public static int fAssignmentCount;
        public static int fAssignmentPercent;

        public static int fRecitationCount;
        public static int fRecitationPercent;

        GradebookQuery g = new GradebookQuery();
        public CustomizeGrade()
        {
            InitializeComponent();
        }

        private void rbtnOK_Click(object sender, EventArgs e)
        {
            Validation validate = new Validation();
            bool isValid = false;
            databaseConnection db = new databaseConnection();

            //!Validation -- must be total of 70

            //Midterm

            //Midterm Attendance
            if(chkMAttendance.Checked)
            {
                mAttendancePercent = validate.isNumber(txtMAttendance.Text);
                if(mAttendancePercent == 0)
                {
                    txtMAttendance.Focus();
                    txtMAttendance.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    mAttendanceCount = Convert.ToInt32(numMAttendance.Value);
                    mAttendancePercent = Convert.ToInt32(txtMAttendance.Text.Trim());

                    g.mAttendance("attendance", mAttendanceCount, mAttendancePercent);
                }
            }
            
            //Midterm Activity
            if (chkMActivity.Checked)
            {
                mActivityPercent = validate.isNumber(txtMActivity.Text);
                if (mActivityPercent == 0)
                {
                    txtMActivity.Focus();
                    txtMActivity.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    mActivityCount = Convert.ToInt32(numMActivity.Value);
                    mActivityPercent = Convert.ToInt32(txtMActivity.Text.Trim());

                    g.mOthers("activity", mActivityCount, mActivityPercent);
                }
            }

            //Midterm Assignment
            if (chkMAssignment.Checked)
            {
                mAssignmentPercent = validate.isNumber(txtMAssignment.Text);
                if (mAssignmentPercent == 0)
                {
                    txtMAssignment.Focus();
                    txtMAssignment.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    mAssignmentCount = Convert.ToInt32(numMAssignment.Value);
                    mAssignmentPercent = Convert.ToInt32(txtMAssignment.Text.Trim());
                    
                    g.mOthers("assignment", mAssignmentCount, mAssignmentPercent);
                }
            }

            //Midterm LongQuiz
            if (chkMLongQuiz.Checked)
            {
                mLongQuizPercent = validate.isNumber(txtMLongQuiz.Text);
                if (mLongQuizPercent == 0)
                {
                    txtMLongQuiz.Focus();
                    txtMLongQuiz.SelectAll(); //Select invalid input
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    mLongQuizCount = Convert.ToInt32(numMLongQuiz.Value);
                    mLongQuizPercent = Convert.ToInt32(txtMLongQuiz.Text.Trim());

                    g.mOthers("longquiz", mLongQuizCount, mLongQuizPercent);
                }
            }

            //Midterm Quiz
            if (chkMQuiz.Checked)
            { 
                mQuizPercent = validate.isNumber(txtMQuiz.Text);
                if (mQuizPercent == 0)
                {
                    txtMQuiz.Focus();
                    txtMQuiz.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    mQuizCount = Convert.ToInt32(numMQuiz.Value);
                    mQuizPercent = Convert.ToInt32(txtMQuiz.Text.Trim());
                    
                    g.mOthers("quiz", mQuizCount, mQuizPercent);
                }
            }

            //Midterm Recitation
            if (chkMRecitation.Checked) 
            {
                mRecitationPercent = validate.isNumber(txtMRecitation.Text);
                if (mRecitationPercent == 0)
                {
                    txtMRecitation.Focus();
                    txtMRecitation.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    mRecitationCount = Convert.ToInt32(numMRecitation.Value);
                    mRecitationPercent = Convert.ToInt32(txtMRecitation.Text.Trim());
                    
                    g.mOthers("recitation", mRecitationCount, mRecitationPercent);
                }
            }

            //Midterm Exam
            if(rdoMExam.Checked)
            {
                isValid = true;
                g.mRdo("exam");
            }

            //Midterm Project
            if(rdoMProject.Checked)
            {
                isValid = true;
                g.mRdo("project");
            }

            //Final
            //Final Attendance
            if (chkFAttendance.Checked)
            {
                fAttendancePercent = validate.isNumber(txtFAttendance.Text);
                if (fAttendancePercent == 0)
                {
                    txtFAttendance.Focus();
                    txtFAttendance.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    fAttendanceCount = Convert.ToInt32(numFAttendance.Value);
                    fAttendancePercent = Convert.ToInt32(txtFAttendance.Text.Trim());

                    g.fAttendance("attendance", fAttendanceCount, fAttendancePercent);
                }
            }

            //Final Activity
            if (chkFActivity.Checked)
            {
                fActivityPercent = validate.isNumber(txtFActivity.Text);
                if (fActivityPercent == 0)
                {
                    txtFActivity.Focus();
                    txtFActivity.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    fActivityCount = Convert.ToInt32(numFActivity.Value);
                    fActivityPercent = Convert.ToInt32(txtFActivity.Text.Trim());
                    
                    g.fOthers("activity", fActivityCount, fActivityPercent);
                }
            }

            //Final Assignment
            if (chkFAssignment.Checked)
            {
                fAssignmentPercent = validate.isNumber(txtFAssignment.Text);
                if (fAssignmentPercent == 0)
                {
                    txtFAssignment.Focus();
                    txtFAssignment.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    fAssignmentCount = Convert.ToInt32(numFAssignment.Value);
                    fAssignmentPercent = Convert.ToInt32(txtFAssignment.Text.Trim());
                    
                    g.fOthers("assignment", fAssignmentCount, fAssignmentPercent);
                }
            }

            //Final Long Quiz
            if (chkFLongQuiz.Checked)
            {
                fLongQuizPercent = validate.isNumber(txtFLongQuiz.Text);
                if (fLongQuizPercent == 0)
                {
                    txtFLongQuiz.Focus();
                    txtFLongQuiz.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    fLongQuizCount = Convert.ToInt32(numFLongQuiz.Value);
                    fLongQuizPercent = Convert.ToInt32(txtFLongQuiz.Text.Trim());
                    
                    g.fOthers("longquiz", fLongQuizCount, fLongQuizPercent);
                }
            }

            //Final Quiz
            if (chkFQuiz.Checked)
            {
                fQuizPercent = validate.isNumber(txtFQuiz.Text);
                if (fQuizPercent == 0)
                {
                    txtFQuiz.Focus();
                    txtFQuiz.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    fQuizCount = Convert.ToInt32(numFQuiz.Value);
                    fQuizPercent = Convert.ToInt32(txtFQuiz.Text.Trim());
                    
                    g.fOthers("quiz", fQuizCount, fQuizPercent);
                }
            }

            //Final Recitation
            if (chkFRecitation.Checked)
            {
                fRecitationPercent = validate.isNumber(txtFRecitation.Text);
                if (fRecitationPercent == 0)
                {
                    txtFRecitation.Focus();
                    txtFRecitation.SelectAll();
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    fRecitationCount = Convert.ToInt32(numFRecitation.Value);
                    fRecitationPercent = Convert.ToInt32(txtFRecitation.Text.Trim());
                    
                    g.fOthers("recitation", fRecitationCount, fRecitationPercent);
                }
            }
            
            //Final exam
            if(rdoFExam.Checked)
            {
                isValid = true;
                g.fRdo("exam");
            }

            //Final Project
            if (rdoFProject.Checked)
            {
                isValid = true;
                g.fRdo("project");
            }

            //!Validate 30% must have check

            if (isValid)
            {
                this.Hide();
                Teacher_s_Dashboard teachersDashboard = new Teacher_s_Dashboard();
                teachersDashboard.ShowDialog();
                this.Close();
            }

        }

        private void chkMActivity_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMActivity.Checked)
            {
                panel_mActivity.Enabled = true;
            }
            else
            {
                panel_mActivity.Enabled = false;
            }
        }

        private void chkMAttendance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMAttendance.Checked)
            {
                panel_mAttendance.Enabled = true;
            }
            else
            {
                panel_mAttendance.Enabled = false;
            }
        }

        private void chkMAssignment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMAssignment.Checked)
            {
                panel_mAssignment.Enabled = true;
            }
            else
            {
                panel_mAssignment.Enabled = false;
            }
        }

        private void chkMLongQuiz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMLongQuiz.Checked)
            {
                panel_mLongQuiz.Enabled = true;
            }
            else
            {
                panel_mLongQuiz.Enabled = false;
            }
        }

        private void chkMQuiz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMQuiz.Checked)
            {
                panel_mQuiz.Enabled = true;
            }
            else
            {
                panel_mQuiz.Enabled = false;
            }
        }

        private void chkMRecitation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMRecitation.Checked)
            {
                panel_mRecitation.Enabled = true;
            }
            else
            {
                panel_mRecitation.Enabled = false;
            }
        }

        private void chkFActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFActivity.Checked)
            {
                panel_fActivity.Enabled = true;
            }
            else
            {
                panel_fActivity.Enabled = false;
            }
        }

        private void chkFAttendance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFAttendance.Checked)
            {
                panel_fAttendance.Enabled = true;
            }
            else
            {
                panel_fAttendance.Enabled = false;
            }
        }

        private void chkFAssignment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFAssignment.Checked)
            {
                panel_fAssignment.Enabled = true;
            }
            else
            {
                panel_fAssignment.Enabled = false;
            }
        }

        private void chkFLongQuiz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFLongQuiz.Checked)
            {
                panel_fLongQuiz.Enabled = true;
            }
            else
            {
                panel_fLongQuiz.Enabled = false;
            }
        }

        private void chkFQuiz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFQuiz.Checked)
            {
                panel_fQuiz.Enabled = true;
            }
            else
            {
                panel_fQuiz.Enabled = false;
            }
        }

        private void chkFRecitation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFRecitation.Checked)
            {
                panel_fRecitation.Enabled = true;
            }
            else
            {
                panel_fRecitation.Enabled = false;
            }
        }
    }
}
