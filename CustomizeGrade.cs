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

        public int mExamCount;
        public int mExamPercent;

        public int mProjectCount;
        public int mProjectPercent;

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

        public int fExamCount;
        public int fExamPercent;

        public int fProjectCount;
        public int fProjectPercent;

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
            if (chkMExam.Checked)
            {
                mExamPercent = validate.isNumber(txtMExam.Text);
                if (mExamPercent == 0)
                {
                    txtMExam.Focus();
                    txtMExam.SelectAll();
                    return;
                }
                else
                {
                    mExamPercent = Convert.ToInt32(txtMExam.Text.Trim());
                    midtermTotalPercent += mExamPercent;

                    mExam = true;
                }
            }

            //Midterm Project
            if (chkMProject.Checked)
            {
                mProjectPercent = validate.isNumber(txtMProject.Text);
                if (mProjectPercent == 0)
                {
                    txtMProject.Focus();
                    txtMProject.SelectAll();
                    return;
                }
                else
                {
                    mProjectPercent = Convert.ToInt32(txtMProject.Text.Trim());
                    midtermTotalPercent += mProjectPercent;

                    mProject = true;
                }
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

            //Final Exam
            if (chkFExam.Checked)
            {
                fExamPercent = validate.isNumber(txtFExam.Text);
                if (fExamPercent == 0)
                {
                    txtFExam.Focus();
                    txtFExam.SelectAll();
                    return;
                }
                else
                {
                    fExamPercent = Convert.ToInt32(txtFExam.Text.Trim());
                    finalTotalPercent += fExamPercent;

                    fExam = true;
                }
            }

            //Final Project
            if (chkFProject.Checked)
            {
                fProjectPercent = validate.isNumber(txtFProject.Text);
                if (fProjectPercent == 0)
                {
                    txtFProject.Focus();
                    txtFProject.SelectAll();
                    return;
                }
                else
                {
                    fProjectPercent = Convert.ToInt32(txtFProject.Text.Trim());
                    finalTotalPercent += fProjectPercent;

                    fProject = true;
                }
            }

            // Validation to ensure the total percentage is 70%
            if (midtermTotalPercent != 100 || finalTotalPercent != 100)
            {
                if(midtermTotalPercent != 100)
                {
                    MessageBox.Show("The total percentage for midterm must be exactly 100%.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMActivity.Focus();
                    isValid = false;
                    return;
                }
                else if (finalTotalPercent != 100)
                {
                    MessageBox.Show("The total percentage for final must be exactly 100%.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFActivity.Focus();
                    isValid = false;
                    return;
                }
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
                if (mExam)
                {
                    g.rdos("m", "exam", mExamPercent);
                    isValid = true;
                }
                if (mProject)
                {
                    g.rdos("m", "project", mProjectPercent);
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
                if (fExam)
                {
                    g.rdos("f", "exam", fExamPercent);
                    isValid = true;
                }
                if (fProject)
                {
                    g.rdos("f", "project", fProjectPercent);
                    isValid = true;
                }
            }

            // Proceed if valid
            if (isValid)
            {
                MessageBox.Show("Grade components have been customized.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CustomizeGrade_Load(object sender, EventArgs e)
        {

            chkMActivity.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkMAssignment.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkMLongQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkMQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkMRecitation.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkMExam.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkMProject.KeyDown += new KeyEventHandler(Common_KeyDown);

            chkFActivity.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkFAssignment.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkFLongQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkFQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkFRecitation.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkFExam.KeyDown += new KeyEventHandler(Common_KeyDown);
            chkFProject.KeyDown += new KeyEventHandler(Common_KeyDown);

            txtFActivity.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtFAssignment.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtFLongQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtFQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtFRecitation.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtFExam.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtFProject.KeyDown += new KeyEventHandler(Common_KeyDown);

            txtMActivity.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtMAssignment.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtMLongQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtMQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtMRecitation.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtMExam.KeyDown += new KeyEventHandler(Common_KeyDown);
            txtMProject.KeyDown += new KeyEventHandler(Common_KeyDown);

            numFActivity.KeyDown += new KeyEventHandler(Common_KeyDown);
            numFAssignment.KeyDown += new KeyEventHandler(Common_KeyDown);
            numFLongQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            numFQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            numFRecitation.KeyDown += new KeyEventHandler(Common_KeyDown);

            numMActivity.KeyDown += new KeyEventHandler(Common_KeyDown);
            numMAssignment.KeyDown += new KeyEventHandler(Common_KeyDown);
            numMLongQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            numMQuiz.KeyDown += new KeyEventHandler(Common_KeyDown);
            numMRecitation.KeyDown += new KeyEventHandler(Common_KeyDown);

        }

        private void Common_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnOK_Click(sender, e); //call the click event for ok button
            }
        }

        private void chkMExam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMExam.Checked)
            {
                panel_mExam.Enabled = true;
            }
            else
            {
                panel_mExam.Enabled = false;
            }
        }

        private void chkMProject_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMProject.Checked)
            {
                panel_mProject.Enabled = true;
            }
            else
            {
                panel_mProject.Enabled = false;
            }
        }

        private void chkFExam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFExam.Checked)
            {
                panel_fExam.Enabled = true;
            }
            else
            {
                panel_fExam.Enabled = false;
            }
        }

        private void chkFProject_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFProject.Checked)
            {
                panel_fProject.Enabled = true;
            }
            else
            {
                panel_fProject.Enabled = false;
            }
        }

        //REFERENCE: https://stackoverflow.com/questions/9588540/how-can-i-stop-a-double-click-of-the-window-title-bar-from-maximizing-a-window-o
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;
            const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:             //preventing the form from being moved by the mouse.
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            if (m.Msg == WM_NCLBUTTONDBLCLK)       //preventing the form being resized by the mouse double click on the title bar.
            {
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }
    }
}
