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

        public int mQuizCount;
        public int mQuizPercent;

        public int mActivityCount;
        public int mActivityPercent;

        public int mLongQuizCount;
        public int mLongQuizPercent;

        public int mAssignmentCount;
        public int mAssignmentPercent;

        public int mRecitationCount;
        public int mRecitationPercent;

        public int fQuizCount;
        public int fQuizPercent;

        public int fActivityCount;
        public int fActivityPercent;

        public int fLongQuizCount;
        public int fLongQuizPercent;

        public int fAssignmentCount;
        public int fAssignmentPercent;

        public int fRecitationCount;
        public int fRecitationPercent;

        bool mQuiz = false;
        bool mRecitation = false;
        bool mActivity = false;
        bool mAssignment = false;
        bool mLongQuiz = false;
        bool isMChecked = false;

        bool fQuiz = false;
        bool fRecitation = false;
        bool fActivity = false;
        bool fAssignment = false;
        bool fLongQuiz = false;
        bool isFChecked = false;

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

            int midtermTotalPercent = 0;
            int finalTotalPercent = 0;


            //Midterm
            
            //Midterm Activity
            if (chkMActivity.Checked)
            {
                mActivityPercent = validate.isNumber(txtMActivity.Text);
                if (mActivityPercent == 0)
                {
                    txtMActivity.Focus();
                    txtMActivity.SelectAll();
                    return;
                }
                else
                {
                    mActivityCount = Convert.ToInt32(numMActivity.Value);
                    mActivityPercent = Convert.ToInt32(txtMActivity.Text.Trim());
                    midtermTotalPercent += mActivityPercent;

                    mActivity = true;
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
                    return;
                }
                else
                {
                    mAssignmentCount = Convert.ToInt32(numMAssignment.Value);
                    mAssignmentPercent = Convert.ToInt32(txtMAssignment.Text.Trim());
                    midtermTotalPercent += mAssignmentPercent;

                    mAssignment = true;
                   
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
                    return;
                }
                else
                {
                    mLongQuizCount = Convert.ToInt32(numMLongQuiz.Value);
                    mLongQuizPercent = Convert.ToInt32(txtMLongQuiz.Text.Trim());
                    midtermTotalPercent += mLongQuizPercent;

                    mLongQuiz = true;
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
                    return;
                }
                else
                {
                    mQuizCount = Convert.ToInt32(numMQuiz.Value);
                    mQuizPercent = Convert.ToInt32(txtMQuiz.Text.Trim());
                    midtermTotalPercent += mQuizPercent;

                    mQuiz = true;
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
                    return;
                }
                else
                {
                    mRecitationCount = Convert.ToInt32(numMRecitation.Value);
                    mRecitationPercent = Convert.ToInt32(txtMRecitation.Text.Trim());
                    midtermTotalPercent += mRecitationPercent;

                    mRecitation = true;
                }
            }

            //Midterm Exam
            if(rdoMExam.Checked)
            {
                isMChecked = true;
            }

            //Midterm Project
            if(rdoMProject.Checked)
            {
                isMChecked = true;
            }

            //Final

            //Final Activity
            if (chkFActivity.Checked)
            {
                fActivityPercent = validate.isNumber(txtFActivity.Text);
                if (fActivityPercent == 0)
                {
                    txtFActivity.Focus();
                    txtFActivity.SelectAll();
                    return;
                }
                else
                {
                    fActivityCount = Convert.ToInt32(numFActivity.Value);
                    fActivityPercent = Convert.ToInt32(txtFActivity.Text.Trim());
                    finalTotalPercent += fActivityPercent;

                    fActivity = true;
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
                    return;
                }
                else
                {
                    fAssignmentCount = Convert.ToInt32(numFAssignment.Value);
                    fAssignmentPercent = Convert.ToInt32(txtFAssignment.Text.Trim());
                    finalTotalPercent += fAssignmentPercent;

                    fAssignment = true;
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
                    return;
                }
                else
                {
                    fLongQuizCount = Convert.ToInt32(numFLongQuiz.Value);
                    fLongQuizPercent = Convert.ToInt32(txtFLongQuiz.Text.Trim());
                    finalTotalPercent += fLongQuizPercent;
                    fLongQuiz = true;
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
                    return;
                }
                else
                {
                    fQuizCount = Convert.ToInt32(numFQuiz.Value);
                    fQuizPercent = Convert.ToInt32(txtFQuiz.Text.Trim());
                    finalTotalPercent += fQuizPercent;
                    fQuiz = true;
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
                    return;
                }
                else
                {
                    fRecitationCount = Convert.ToInt32(numFRecitation.Value);
                    fRecitationPercent = Convert.ToInt32(txtFRecitation.Text.Trim());
                    finalTotalPercent += fRecitationPercent;

                    fRecitation = true;
                }
            }
            
            //Final exam
            if(rdoFExam.Checked)
            {
                isFChecked = true;
            }

            //Final Project
            if (rdoFProject.Checked)
            {           
                isFChecked = true;
            }

            // Validation to ensure the total percentage is 70%
            if (midtermTotalPercent != 70 || finalTotalPercent != 70)
            {
                MessageBox.Show("The total percentage for both midterm and final must be exactly 70%.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
                return;
            }
            else
            {    
                if (mActivity)
                {
                    g.mOthers("activity", mActivityCount, mActivityPercent);
                    isValid = true;
                }
                if (mAssignment)
                {
                    g.mOthers("assignment", mAssignmentCount, mAssignmentPercent);
                    isValid = true;
                }
                if (mLongQuiz)
                {
                    g.mOthers("longquiz", mLongQuizCount, mLongQuizPercent);
                    isValid = true;
                }
                if (mQuiz)
                {
                    g.mOthers("quiz", mQuizCount, mQuizPercent);
                    isValid = true;
                }
                if (mRecitation)
                {
                    g.mOthers("recitation", mRecitationCount, mRecitationPercent);
                    isValid = true;
                }                     

                if (fActivity)
                {
                    g.fOthers("activity", fActivityCount, fActivityPercent);
                    isValid = true;
                }
                if (fAssignment)
                {
                    g.fOthers("assignment", fAssignmentCount, fAssignmentPercent);
                    isValid = true;
                }
                if (fLongQuiz)
                {
                    g.fOthers("longquiz", fLongQuizCount, fLongQuizPercent);
                    isValid = true;
                }
                if (fQuiz)
                {
                    g.fOthers("quiz", fQuizCount, fQuizPercent);
                    isValid = true;
                }
                if (fRecitation)
                {
                    g.fOthers("recitation", fRecitationCount, fRecitationPercent);
                    isValid = true;
                }
            }

            if (isMChecked == false)
            {
                MessageBox.Show("Please select for the 30% for Midterm", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
                return;
            }
            else
            {
                if (rdoMExam.Checked)
                {
                    g.mRdo("exam");
                    isValid = true;
                }
                else
                {
                    g.mRdo("project");
                    isValid = true;
                }
            }
            if (isFChecked == false)
            {
                MessageBox.Show("Please select for the 30% for Final", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
                return;
            }
            else
            {
                if (rdoFExam.Checked)
                {
                    g.fRdo("exam");
                }
                else
                {
                    g.fRdo("project");
                }
            }
            
            // Proceed if valid
            if (isValid)
            {
                MessageBox.Show("SUCCESS");
                this.Hide();
                TheFacultyDashboard teachersDashboard = new TheFacultyDashboard();
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
