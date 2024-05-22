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
            //! Implement in Class-method

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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch(mAttendanceCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_attendance (m_attendance1, m_attendance2, m_attendance3, m_attendance4, m_attendance5, m_attendance6, m_attendance7, m_attendance8, m_attendance9, m_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (mActivityCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_activity (m_activity1, m_activity2, m_activity3, m_activity4, m_activity5, m_activity6, m_activity7, m_activity8, m_activity9, m_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (mAssignmentCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_assignment (m_assignment1, m_assignment2, m_assignment3, m_assignment4, m_assignment5, m_assignment6, m_assignment7, m_assignment8, m_assignment9, m_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (mLongQuizCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_longquiz (m_longquiz1, m_longquiz2, m_longquiz3, m_longquiz4, m_longquiz5, m_longquiz6, m_longquiz7, m_longquiz8, m_longquiz9, m_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (mQuizCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_quiz (m_quiz1, m_quiz2, m_quiz3, m_quiz4, m_quiz5, m_quiz6, m_quiz7, m_quiz8, m_quiz9, m_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (mRecitationCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.m_recitation (m_recitation1, m_recitation2, m_recitation3, m_recitation4, m_recitation5, m_recitation6, m_recitation7, m_recitation8, m_recitation9, m_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", mRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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

            //!Add for midterm exam and midterm project

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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (fAttendanceCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_attendance (f_attendance1, f_attendance2, f_attendance3, f_attendance4, f_attendance5, f_attendance6, f_attendance7, f_attendance8, f_attendance9, f_attendance_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAttendancePercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (fActivityCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_activity (f_activity1, f_activity2, f_activity3, f_activity4, f_activity5, f_activity6, f_activity7, f_activity8, f_activity9, f_activity_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fActivityPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (fAssignmentCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_assignment (f_assignment1, f_assignment2, f_assignment3, f_assignment4, f_assignment5, f_assignment6, f_assignment7, f_assignment8, f_assignment9, f_assignment_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fAssignmentPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (fLongQuizCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_longquiz (f_longquiz1, f_longquiz2, f_longquiz3, f_longquiz4, f_longquiz5, f_longquiz6, f_longquiz7, f_longquiz8, f_longquiz9, f_longquiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fLongQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (fQuizCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_quiz (f_quiz1, f_quiz2, f_quiz3, f_quiz4, f_quiz5, f_quiz6, f_quiz7, f_quiz8, f_quiz9, f_quiz_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fQuizPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;

                        switch (fRecitationCount)
                        {
                            case 1:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, 0, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, 0, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, -1, 0, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, 0, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, 0, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 6:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, 0, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 7:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, 0, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 8:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, 0, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
                            case 9:
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.f_recitation (f_recitation1, f_recitation2, f_recitation3, f_recitation4, f_recitation5, f_recitation6, f_recitation7, f_recitation8, f_recitation9, f_recitation_percentage, class_id) VALUES (-1, -1, -1, -1, -1, -1, -1, -1, -1, @percentage, @class_id)";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                                db.cmd.Parameters.AddWithValue("@percentage", fRecitationPercent);
                                db.cmd.ExecuteNonQuery();
                                break;
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

            //!Add for final project and final exam
            //!Validate 30%

            if(isValid)
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
