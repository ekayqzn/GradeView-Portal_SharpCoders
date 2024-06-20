using MySql.Data.MySqlClient;
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
        public DataGridViewRow selectedRow;

        databaseConnection db = new databaseConnection();
        public static int programID;
        public static int courseID;
        DataTable dt = new DataTable();
        GradebookQuery g = new GradebookQuery();
        private GetRecordQuery q;

        public DataTable dtDisplay { get; private set; }
        public DataRow newRow { get; private set; }

        public static decimal mWritten = 0;
        public static decimal mFinalReq = 0;
        public static decimal fWritten = 0;
        public static decimal fFinalReq = 0;

        public static decimal midtermGrade = 0;
        public static decimal finalGrade = 0;
        public static decimal gwa = 0;

        GradebookComputation c = new GradebookComputation();
        public GradeBook()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Initialize dtDisplay and newRow here
            dtDisplay = new DataTable();
            newRow = dtDisplay.NewRow();

            q = new GetRecordQuery(this);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell value is -1
            //if (e.Value != null && e.Value is int && (int)e.Value == -1)
            //{
            //    // Set the display value to empty string
            //    e.Value = "-";
            //    e.FormattingApplied = true; // Indicate that the formatting was applied
            //}
            //else if (e.Value != null && e.Value is string && int.TryParse((string)e.Value, out int result) && result == -1)
            //{
            //    e.Value = "-";
            //    e.FormattingApplied = true;
            //}

            if (e.Value != null && (e.Value is int || e.Value is string))
            {
                if (int.TryParse(e.Value.ToString(), out int result) && result == -1)
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }
        }
        public void GradeBook_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting; //format cell as blank when the value is -1

            //Refresh value
            finalGrade = 0;
            mWritten = 0;
            mFinalReq = 0;
            fFinalReq = 0;
            fWritten = 0;

            picDeleteSearch.Parent = txtSearch;
            picDeleteSearch.Location = new Point(txtSearch.ClientSize.Width - ((picDeleteSearch.Image.Width) + 5), 5);


            dtDisplay.Rows.Clear();
            string subjectName = "";
            string subjectCode = TheFacultyDashboard.subjectTile.Trim(); // Trim any extra spaces

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
                    label.Text = TheFacultyDashboard.subjectTile + Environment.NewLine + subjectName + Environment.NewLine + "Code: " + TheCourseDashboard.courseCode;
                    label.Location = new Point(20, 20);
                    label.AutoSize = true;
                    label.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                    label.ForeColor = Color.FromArgb(0, 4, 93);
                    panel1.Controls.Add(label);

                    Label label1 = new Label();
                    label1.Text = TheCourseDashboard.programName + Environment.NewLine + TheCourseDashboard.yearLevel + " - " + TheCourseDashboard.section;
                    label1.Location = new Point(190, 30);
                    label1.AutoSize = true;
                    label1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                    label1.ForeColor = Color.FromArgb(0, 4, 93);
                    panel1.Controls.Add(label1);
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
                db.cmd.Parameters.AddWithValue("@programName", TheCourseDashboard.programName);
                db.cmd.Parameters.AddWithValue("@yearLevel", TheCourseDashboard.yearLevel);
                db.cmd.Parameters.AddWithValue("@section", TheCourseDashboard.section);

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
                db.cmd.CommandText = "SELECT student_id, m_activity_id, m_assignment_id, m_longquiz_id, m_quiz_id, m_project_id, m_exam_id, m_recitation_id, f_activity_id, f_assignment_id, f_longquiz_id, f_quiz_id, f_project_id, f_exam_id, f_recitation_id FROM enroll WHERE program_id = @programID AND class_id = @classID";

                DataTable dtIDs = new DataTable();

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programID", programID);
                db.cmd.Parameters.AddWithValue("@classID", TheFacultyDashboard.classID);

                // Log the parameters FOR DEBUG
                //MessageBox.Show($"Query: {db.cmd.CommandText}\nParameters:\nprogramID: {programID}\nclassID: {Teacher_s_Dashboard.classID}");

                db.dta.SelectCommand = db.cmd;
                db.dta.Fill(dtIDs);


                List <string> studentIDs = new List<string>(); //List of StudentID

                List<int?> mActivityID = new List<int?>();
                List<int?> mAssignmentID = new List<int?>();
                List<int?> mLongQuizID = new List<int?>();
                List<int?> mQuizID = new List<int?>();
                List<int?> mRecitationID = new List<int?>();
                List<int?> mExamID = new List<int?>();
                List<int?> mProjectID = new List<int?>();

                List<int?> fActivityID = new List<int?>();
                List<int?> fAssignmentID = new List<int?>();
                List<int?> fLongQuizID = new List<int?>();
                List<int?> fQuizID = new List<int?>();
                List<int?> fRecitationID = new List<int?>();
                List<int?> fExamID = new List<int?>();
                List<int?> fProjectID = new List<int?>();

                // Debugging: Check if data is retrieved
                if (dtIDs.Rows.Count == 0)
                {
                    MessageBox.Show("No student records found for this class.");
                    return;
                }
                else
                {
                    foreach(DataRow row in dtIDs.Rows)
                    {
                        studentIDs.Add((row["student_id"] == DBNull.Value) ? null : row["student_id"].ToString());

                        mActivityID.Add((row["m_activity_id"] == DBNull.Value) ? null : (int?)row["m_activity_id"]);
                        mAssignmentID.Add((row["m_assignment_id"] == DBNull.Value) ? null : (int?)row["m_assignment_id"]);
                        mLongQuizID.Add((row["m_longquiz_id"] == DBNull.Value) ? null : (int?)row["m_longquiz_id"]);
                        mQuizID.Add((row["m_quiz_id"] == DBNull.Value) ? null : (int?)row["m_quiz_id"]);
                        mRecitationID.Add((row["m_recitation_id"] == DBNull.Value) ? null : (int?)row["m_recitation_id"]);
                        mExamID.Add((row["m_exam_id"] == DBNull.Value) ? null : (int?)row["m_exam_id"]);
                        mProjectID.Add((row["m_project_id"] == DBNull.Value) ? null : (int?)row["m_project_id"]);

                        fActivityID.Add((row["f_activity_id"] == DBNull.Value) ? null : (int?)row["f_activity_id"]);
                        fAssignmentID.Add((row["f_assignment_id"] == DBNull.Value) ? null : (int?)row["f_assignment_id"]);
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
                    finalGrade = 0;
                    mWritten = 0;
                    mFinalReq = 0;
                    fWritten = 0;
                    fFinalReq = 0;

                    DataRow newRow = dtDisplay.NewRow();
                    newRow["student_id"] = studentIDs[i];
                    newRow["student_name"] = q.GetStudentName(studentIDs[i]);

                    if (mActivityID[i] != null)
                    {
                        int count = q.GetCount("m", "activity", (int)mActivityID[i]);
                        mWritten += q.GetRecordsOther("m", "activity", (int)mActivityID[i], count, newRow);
                    }
                    if(mAssignmentID[i] != null)
                    {
                        int count = q.GetCount("m", "assignment", (int)mAssignmentID[i]);
                        mWritten += q.GetRecordsOther("m", "assignment", (int)mAssignmentID[i], count, newRow);
                    }
                    if (mLongQuizID[i] != null)
                    {
                        int count = q.GetCount("m", "longquiz", (int)mLongQuizID[i]);
                        mWritten += q.GetRecordsOther("m", "longquiz", (int)mLongQuizID[i], count, newRow);
                    }
                    if (mQuizID[i] != null)
                    {
                        int count = q.GetCount("m", "quiz", (int)mQuizID[i]);
                        mWritten += q.GetRecordsOther("m", "quiz", (int)mQuizID[i], count, newRow);
                    }
                    if (mRecitationID[i] != null)
                    {
                        int count = q.GetCount("m", "recitation", (int)mRecitationID[i]);
                        mWritten += q.GetRecordsOther("m", "recitation", (int)mRecitationID[i], count, newRow);
                    }
                    if (mExamID[i] != null)
                    {
                        mFinalReq = q.GetRecordRdo("m", "exam", (int)mExamID[i], newRow);
                    }
                    if (mProjectID[i] != null)
                    {
                       
                        mFinalReq = q.GetRecordRdo("m", "project", (int)mProjectID[i], newRow);
                    }

                    midtermGrade = mWritten + mFinalReq;
                    //MessageBox.Show(midtermGrade.ToString());

                    if (fActivityID[i] != null)
                    {
                        int count = q.GetCount("f", "activity", (int)fActivityID[i]);
                        fWritten += q.GetRecordsOther("f", "activity", (int)fActivityID[i], count, newRow);
                    }
                    if (fAssignmentID[i] != null)
                    {
                        int count = q.GetCount("f", "assignment", (int)fAssignmentID[i]);
                        fWritten += q.GetRecordsOther("f", "assignment", (int)fAssignmentID[i], count, newRow);
                    }
                    if (fLongQuizID[i] != null)
                    {
                        int count = q.GetCount("f", "longquiz", (int)fLongQuizID[i]);
                        fWritten += q.GetRecordsOther("f", "longquiz", (int)fLongQuizID[i], count, newRow);
                    }
                    if (fQuizID[i] != null)
                    {
                        int count = q.GetCount("f", "quiz", (int)fQuizID[i]);
                        fWritten += q.GetRecordsOther("f", "quiz", (int)fQuizID[i], count, newRow);
                    }
                    if (fRecitationID[i] != null)
                    {
                        int count = q.GetCount("f", "recitation", (int)fRecitationID[i]);
                        fWritten += q.GetRecordsOther("f", "recitation", (int)fRecitationID[i], count, newRow);
                    }
                    if (fExamID[i] != null)
                    {
                        fFinalReq = q.GetRecordRdo("f", "exam", (int)fExamID[i], newRow);
                        
                    }
                    if (fProjectID[i] != null)
                    {
                        fFinalReq = q.GetRecordRdo("f", "project", (int)fProjectID[i], newRow);
                    }

                    finalGrade = fWritten + fFinalReq;

                    if ((!dtDisplay.Columns.Contains("Final Grade")))
                    {
                        dtDisplay.Columns.Add("Final Grade");
                    }



                    gwa = (midtermGrade + finalGrade) / 2;
                    newRow["Final Grade"] = gwa.ToString("0.00");

                    if ((!dtDisplay.Columns.Contains("Equivalent Grade")))
                    {
                        dtDisplay.Columns.Add("Equivalent Grade");
                    }
                    
                    newRow["Equivalent Grade"] = c.GradePoints(gwa).ToString("0.00");

                    dtDisplay.Rows.Add(newRow);
                    dataGridView1.DataSource = dtDisplay;

                }
              
                dataGridView1.CellClick += DataGridView1_CellClick; //when specific row is clicked
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                    selectedRow = dataGridView1.Rows[0];
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

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count) //ensure click is not on the header or greater than row
            {
                selectedRow = dataGridView1.Rows[e.RowIndex];
            }
        }

        private void LinkLBLback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TheCourseDashboard c = new TheCourseDashboard();
            c.ShowDialog();
            this.Close();
        }

        private void rbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRow != null && selectedRow.Index >= 0)
                {
                    this.Hide();
                    Edit_GradeBook editForm = new Edit_GradeBook(selectedRow);
                    editForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select a valid row, not a column header.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }

        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheCourseDashboard c = new TheCourseDashboard();
            c.ShowDialog();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                picDeleteSearch.Visible = true;
            }
            else
            {
                picDeleteSearch.Visible = false;
            }
            string filterText = txtSearch.Text;
            FilterDataGridView(filterText);
        }

        private void FilterDataGridView(string filterText)
        {
            DataView dv = dtDisplay.DefaultView;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                dv.RowFilter = string.Empty;
            }
            else
            {
                StringBuilder filterExpression = new StringBuilder();
                foreach (DataColumn column in dtDisplay.Columns)
                {
                    if (filterExpression.Length > 0)
                    {
                        filterExpression.Append(" OR ");
                    }
                    filterExpression.AppendFormat("[{0}] LIKE '%{1}%'", column.ColumnName, filterText);
                }
                dv.RowFilter = filterExpression.ToString();
            }
            dataGridView1.DataSource = dv;
        }

        private void rbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                // Check if a column is selected
                if (dataGridView1.SelectedColumns.Count > 0)
                {
                    MessageBox.Show("You cannot delete a column. Please select a row to delete.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure selectedRow is set before proceeding
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    selectedRow = dataGridView1.SelectedRows[0];
                }
                else if (dataGridView1.CurrentRow != null)
                {
                    selectedRow = dataGridView1.CurrentRow;
                }
                else
                {
                    MessageBox.Show("Please select a row first.");
                    return;
                }

                string studentID = selectedRow.Cells["student_id"].Value.ToString().Trim();
                g.RemoveStudentToCourse(TheFacultyDashboard.classID, studentID);
                dataGridView1.Rows.Remove(selectedRow);
                selectedRow = null;

                MessageBox.Show($"Student with {studentID} student number has been removed from this course", "Student Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void picDeleteSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
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
