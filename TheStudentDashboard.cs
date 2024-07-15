using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gradesBookApp
{
    public partial class TheStudentDashboard : Form
    {
        databaseConnection db = new databaseConnection();
        GetRecordQuery getRecord = new GetRecordQuery();
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

        public static string status;


        LogInStudent l = new LogInStudent();
        public TheStudentDashboard()
        {
            InitializeComponent();
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

        private void menuPassword_Click(object sender, EventArgs e)
        {
            Manage_Password m = new Manage_Password();
            TheFacultyDashboard.type = "student";
            m.ShowDialog();
        }

        private void TheStudentDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }



        private void LoadDashboard()
        {
            string name = getRecord.GetName("student", "first_name", LogInOperation.userID);
            lblGreet.Text = "Hi " + name + ", Welcome!";

            // Clear existing controls
            panel2.Controls.Clear();

            try
            {
                // Get class_id and subject code that the teacher teaches
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT c.class_id, s.subject_code, s.subject_name, CONCAT(t.teacher_fname, ' ', t.teacher_lname) AS teacher_name " +
                    "FROM modern_gradesbook.enroll e JOIN modern_gradesbook.class c ON e.class_id = c.class_id " +
                    "JOIN modern_gradesbook.subject_info s ON s.subject_code = c.subject_code " +
                    "JOIN modern_gradesbook.teacher_info t ON t.teacher_id = c.teacher_id " +
                    "WHERE e.student_id = @studentID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", LogInOperation.userID.Trim());
                // SelectCommand property select the sql command
                db.dta.SelectCommand = db.cmd;

                // DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); // Populate dataTable

                // Get class id and subject code. store to a string array
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

                // If the database returns the details, dynamically create a tile/button for that specific subject
                if (dataTable.Rows.Count > 0)
                {
                    int labelSizeX = 210;
                    int labelSizeY = 178;
                    int labelLocationX = 22; // Initial X position
                    int labelLocationY = 40; // Initial Y position
                    int tileCount = 0; // Initialize tileCount

                    Random random = new Random();

                    for (int i = 0; i < dataTable.Rows.Count; i++) // Iterate as to the number of subjects the teacher holds
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
                        label.ContextMenuStrip = contextMenu;

                        // Place the label
                        label.Location = new Point(labelLocationX, labelLocationY);
                        panel2.Controls.Add(label);

                        // Update the position for the next label
                        
                        if (tileCount < 4)
                        {
                            labelLocationX += 250;
                            tileCount++;
                        }
                        else // When tileCount reaches 5, reset for the next row
                        {
                            tileCount = 0;
                            labelLocationX = 22;
                            labelLocationY += 212;
                        }

                        // Store class_id in the Tag property
                        label.Tag = classID[i];

                        // Add Event Handler
                        label.Click += lblSubject_Click;
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

        private void toolUnenroll_Click(object sender, EventArgs e)
        { 

            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            ContextMenuStrip menuStrip = menuItem.Owner as ContextMenuStrip;

            Label label = menuStrip.SourceControl as Label;

            classId = (int)label.Tag;

            if (MessageBox.Show("Removing this class will also remove you from the class record. Are you sure you want to continue?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                        MessageBox.Show("You have successfully unenrolled from the class.", "Unenrollment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("No student records were found for this class.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void rbtnAddClass_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Class addClass = new Add_Class();
            addClass.ShowDialog();
            this.Close();
        }

    }
}
