using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public partial class TheStudentDashboard : Form
    {
        databaseConnection db = new databaseConnection();
        public int classId = 0;

        public static int? mActivityID = null;
        public static int? mAssignmentID = null;
        public static int? mLongQuizID = null;
        public static int? mQuizID = null;
        public static int? mRecitationID = null;
        public static int? mExamID = null;
        public static int? mProjectID = null;

        public static int? fActivityID = null;
        public static int? fAssignmentID = null;
        public static int? fLongQuizID = null;
        public static int? fQuizID = null;
        public static int? fRecitationID = null;
        public static int? fExamID = null;
        public static int? fProjectID = null;

        public TheStudentDashboard()
        {
            InitializeComponent();
        }

        private void rbtnAddClass_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Class addClass = new Add_Class();
            addClass.ShowDialog();
            this.Close();
        }

        private void LoadDashboard()
        {
            panel2.Controls.Clear();
            try
            {
                //get class_id and subject code that the teacher teaches
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT c.class_id, s.subject_code, s.subject_name, CONCAT(t.teacher_fname, ' ', t.teacher_lname) AS teacher_name " +
                    "FROM modern_gradesbook.enroll e JOIN modern_gradesbook.class c ON e.class_id = c.class_id " +
                    "JOIN modern_gradesbook.subject_info s ON s.subject_code = c.subject_code " +
                    "JOIN modern_gradesbook.teacher_info t ON t.teacher_id = c.teacher_id " +
                    "WHERE e.student_id = @studentID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", LogInOperation.userID.Trim());
                //SelectCommand property select the sql command
                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                //get class id and subject code. store to a string array
                string[] subjectCode = new string[dataTable.Rows.Count];
                string[] subjectName = new string[dataTable.Rows.Count];
                string[] teacherName = new string[dataTable.Rows.Count];
                int[] classID = new int[dataTable.Rows.Count];


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    subjectCode[i] = dataTable.Rows[i]["subject_code"].ToString();
                    subjectName[i] = dataTable.Rows[i]["subject_name"].ToString();
                    teacherName[i] = dataTable.Rows[i]["teacher_name"].ToString();
                    classID[i] = Convert.ToInt32(dataTable.Rows[i]["class_id"]);
                }

                //if the database return the details, will dynamically create a tile/button for that specific subject
                if (dataTable.Rows.Count > 0)
                {
                    int labelSizeX = 210;
                    int labelSizeY = 178;
                    int labelLocationX = 131; // Increment by 200
                    int labelLocationY = 40; // Increment by 212

                    // Generates a random integer between 128 and 255 for light colors
                    int tileCount = 0;
                    Random random = new Random();
                    int red = random.Next(200, 256);
                    int green = random.Next(150, 200);
                    int blue = random.Next(150, 200);
                    for (int i = 0; i < dataTable.Rows.Count; i++) //will iterate as to the number of subject the teacher holds
                    {
                        Label label = new Label();
                        label.Name = "lblSub" + (i + 1).ToString();
                        label.TextAlign = ContentAlignment.BottomLeft;
                        label.Text = subjectName[i] + Environment.NewLine + subjectCode[i] + Environment.NewLine + teacherName[i];
                        label.AutoSize = false;
                        label.Size = new Size(labelSizeX, labelSizeY);
                        label.BackColor = Color.FromArgb(random.Next(0, 100), random.Next(100, 200), random.Next(200, 256));
                        label.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        label.ForeColor = Color.White;
                        label.Cursor = Cursors.Hand;
                        label.ContextMenuStrip = contextUnenroll;


                        //tile is 3 per row
                        if (tileCount < 3)
                        {
                            label.Location = new Point(labelLocationX, labelLocationY);
                            labelLocationX += 250;
                            tileCount++;
                        }
                        if (tileCount == 3) //New Line when reaches 3
                        {
                            tileCount = 0;
                            labelLocationX = 48;
                            labelLocationY += 212;
                        }

                        // Store class_id in the Tag property
                        label.Tag = classID[i];

                        //Add Event Handler
                        label.Click += lblSubject_Click;

                        //Add to panel
                        panel2.Controls.Add(label);
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
        private void TheStudentDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void lblSubject_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                classId = (int)clickedLabel.Tag;
                //MessageBox.Show("Class ID: " + classId, "Class ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Will show student scores for that specific subject (GRADEBOOK)
            try
            {

                db.Connect();
                db.cmd.Connection = db.conn;

                // Retrieve IDs
                db.cmd.CommandText = "SELECT m_activity_id, m_assignment_id, m_longquiz_id, m_quiz_id, m_project_id, m_exam_id, m_recitation_id, f_activity_id, f_assignment_id, f_longquiz_id, f_quiz_id, f_project_id, f_exam_id, f_recitation_id FROM enroll WHERE student_id = @studentID AND class_id = @classID";

                DataTable dtIDs = new DataTable();

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", LogInOperation.userID);
                db.cmd.Parameters.AddWithValue("@classID", classId);

                // Log the parameters FOR DEBUG
                //MessageBox.Show($"Query: {db.cmd.CommandText}\nParameters:\nprogramID: {programID}\nclassID: {Teacher_s_Dashboard.classID}");

                db.dta.SelectCommand = db.cmd;
                db.dta.Fill(dtIDs);

                // Debugging: Check if data is retrieved
                if (dtIDs.Rows.Count == 0)
                {
                    MessageBox.Show("No student records found for this class.");
                    return;
                }
                else
                {
                    for (int i = 0; i < dtIDs.Rows.Count; i++)
                    {
                        mActivityID = dtIDs.Rows[i]["m_activity_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_activity_id"]) : (int?)null;
                        mAssignmentID = dtIDs.Rows[i]["m_assignment_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_assignment_id"]) : (int?)null;
                        mLongQuizID = dtIDs.Rows[i]["m_longquiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_longquiz_id"]) : (int?)null;
                        mQuizID = dtIDs.Rows[i]["m_quiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_quiz_id"]) : (int?)null;
                        mRecitationID = dtIDs.Rows[i]["m_recitation_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_recitation_id"]) : (int?)null;
                        mExamID = dtIDs.Rows[i]["m_exam_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_exam_id"]) : (int?)null;
                        mProjectID = dtIDs.Rows[i]["m_project_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_project_id"]) : (int?)null;

                        fActivityID = dtIDs.Rows[i]["f_activity_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_activity_id"]) : (int?)null;
                        fAssignmentID = dtIDs.Rows[i]["f_assignment_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_assignment_id"]) : (int?)null;
                        fLongQuizID = dtIDs.Rows[i]["f_longquiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_longquiz_id"]) : (int?)null;
                        fQuizID = dtIDs.Rows[i]["f_quiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_quiz_id"]) : (int?)null;
                        fRecitationID = dtIDs.Rows[i]["f_recitation_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_recitation_id"]) : (int?)null;
                        fExamID = dtIDs.Rows[i]["f_exam_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_exam_id"]) : (int?)null;
                        fProjectID = dtIDs.Rows[i]["f_project_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_project_id"]) : (int?)null;
                    }

                    this.Hide();
                    Student_Module studentModule = new Student_Module();
                    studentModule.ShowDialog();
                    this.Close();

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


        private void rbtnAddClass_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Add_Class addClass = new Add_Class();
            addClass.ShowDialog();
            this.Close();
        }

        private void menuLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log out?", "Log out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                TheStudent_Login s = new TheStudent_Login();
                s.ShowDialog();
                this.Close();
            }
        }

        private void rbtnAddClass_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Add_Class addClass = new Add_Class();
            addClass.ShowDialog();
            this.Close();
        }

        private void toolUnenroll_Click(object sender, EventArgs e)
        {

            try
            {
                ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                ContextMenuStrip menuStrip = menuItem.Owner as ContextMenuStrip;
                Label label = menuStrip.SourceControl as Label;

                classId = (int)label.Tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (MessageBox.Show("Removing this class will also remove you from the class record. Are you sure you want to continue?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "DELETE FROM enroll WHERE student_id = @ID AND class_id = @classID";

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@ID", LogInStudent.userID);
                    db.cmd.Parameters.AddWithValue("@classID", classId);

                    if (db.cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Successfully unenrolled from this class");
                        LoadDashboard();
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
        }

        private void toolView_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                ContextMenuStrip menuStrip = menuItem.Owner as ContextMenuStrip;
                Label label = menuStrip.SourceControl as Label;

                classId = (int)label.Tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Will show student scores for that specific subject (GRADEBOOK)
            try
            {

                db.Connect();
                db.cmd.Connection = db.conn;

                // Retrieve IDs
                db.cmd.CommandText = "SELECT m_activity_id, m_assignment_id, m_longquiz_id, m_quiz_id, m_project_id, m_exam_id, m_recitation_id, f_activity_id, f_assignment_id, f_longquiz_id, f_quiz_id, f_project_id, f_exam_id, f_recitation_id FROM enroll WHERE student_id = @studentID AND class_id = @classID";

                DataTable dtIDs = new DataTable();

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", LogInOperation.userID);
                db.cmd.Parameters.AddWithValue("@classID", classId);

                // Log the parameters FOR DEBUG
                //MessageBox.Show($"Query: {db.cmd.CommandText}\nParameters:\nprogramID: {programID}\nclassID: {Teacher_s_Dashboard.classID}");

                db.dta.SelectCommand = db.cmd;
                db.dta.Fill(dtIDs);

                // Debugging: Check if data is retrieved
                if (dtIDs.Rows.Count == 0)
                {
                    MessageBox.Show("No student records found for this class.");
                    return;
                }
                else
                {
                    for (int i = 0; i < dtIDs.Rows.Count; i++)
                    {
                        mActivityID = dtIDs.Rows[i]["m_activity_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_activity_id"]) : (int?)null;
                        mAssignmentID = dtIDs.Rows[i]["m_assignment_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_assignment_id"]) : (int?)null;
                        mLongQuizID = dtIDs.Rows[i]["m_longquiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_longquiz_id"]) : (int?)null;
                        mQuizID = dtIDs.Rows[i]["m_quiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_quiz_id"]) : (int?)null;
                        mRecitationID = dtIDs.Rows[i]["m_recitation_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_recitation_id"]) : (int?)null;
                        mExamID = dtIDs.Rows[i]["m_exam_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_exam_id"]) : (int?)null;
                        mProjectID = dtIDs.Rows[i]["m_project_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["m_project_id"]) : (int?)null;

                        fActivityID = dtIDs.Rows[i]["f_activity_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_activity_id"]) : (int?)null;
                        fAssignmentID = dtIDs.Rows[i]["f_assignment_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_assignment_id"]) : (int?)null;
                        fLongQuizID = dtIDs.Rows[i]["f_longquiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_longquiz_id"]) : (int?)null;
                        fQuizID = dtIDs.Rows[i]["f_quiz_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_quiz_id"]) : (int?)null;
                        fRecitationID = dtIDs.Rows[i]["f_recitation_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_recitation_id"]) : (int?)null;
                        fExamID = dtIDs.Rows[i]["f_exam_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_exam_id"]) : (int?)null;
                        fProjectID = dtIDs.Rows[i]["f_project_id"] != DBNull.Value ? Convert.ToInt32(dtIDs.Rows[i]["f_project_id"]) : (int?)null;
                    }

                    this.Hide();
                    Student_Module studentModule = new Student_Module();
                    studentModule.ShowDialog();
                    this.Close();

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
            
        private void menuPassword_Click(object sender, EventArgs e)
        {
            TheFacultyDashboard.type = "student";
            Manage_Password m = new Manage_Password();
            m.ShowDialog();

        }
    }
}
