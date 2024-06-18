using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public partial class TheCourseDashboard : Form
    {
        databaseConnection db = new databaseConnection();
        public static string programName;
        public static int yearLevel;
        public static int section;
        public static string courseCode;

        public TheCourseDashboard()
        {
            InitializeComponent();
        }


        private void rbtnAddClass_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Add_Section addSection = new Add_Section();
            addSection.ShowDialog();
            this.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log out?", "Log out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                TheFacultyLogIn s = new TheFacultyLogIn();
                s.ShowDialog();
                this.Close();
            }
        }

        private void LoadDashboard()
        {
            // Clear existing controls
            panel2.Controls.Clear(); 

            string subjectCode = TheFacultyDashboard.subjectTile.Trim(); // Trim any extra spaces

            //Get Section Information(program name, year level, section) will also be displayed as tile
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = @"SELECT si.subject_name, p.program_name, p.year_level, p.section, co.course_code 
            FROM 
                modern_gradesbook.subject_info si
            INNER JOIN 
                modern_gradesbook.class cl ON si.subject_code = cl.subject_code
            INNER JOIN 
                modern_gradesbook.course co ON cl.class_id = co.class_id
            INNER JOIN 
                modern_gradesbook.program p ON co.program_id = p.program_id
            WHERE 
                cl.class_id = @classID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", TheFacultyDashboard.classID); //use classID from Teacher's Dashboard when the tile is click

                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                string[] subjectName = new string[dataTable.Rows.Count];
                string[] programName = new string[dataTable.Rows.Count];
                int[] yearLevel = new int[dataTable.Rows.Count];
                int[] section = new int[dataTable.Rows.Count];
                string[] courseCode = new string[dataTable.Rows.Count];

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    subjectName[i] = dataTable.Rows[i]["subject_name"].ToString();
                    programName[i] = dataTable.Rows[i]["program_name"].ToString();
                    yearLevel[i] = Convert.ToInt32(dataTable.Rows[i]["year_level"]);
                    section[i] = Convert.ToInt32(dataTable.Rows[i]["section"]);
                    courseCode[i] = dataTable.Rows[i]["course_code"].ToString();
                }

                if (dataTable.Rows.Count >= 0)
                {
                    int labelSizeX = 500;
                    int labelSizeY = 85;
                    int labelLocationX = 60; //constant
                    int labelLocationY = 60; //increment by 86
                    // Generates a random integer between 128 and 255 for light colors
                    Random random = new Random();

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Label label = new Label();
                        label.Name = "lblSection" + (i + 1).ToString();
                        label.TextAlign = ContentAlignment.MiddleLeft;
                        label.AutoSize = false;
                        label.Size = new Size(labelSizeX, labelSizeY);
                        label.BackColor = Color.FromArgb(random.Next(0, 100), random.Next(100, 200), random.Next(200, 256));
                        label.Location = new Point(labelLocationX, labelLocationY);
                        label.Text = subjectName[i] + Environment.NewLine + programName[i] + Environment.NewLine + yearLevel[i].ToString() + " - " + section[i].ToString() + Environment.NewLine + "Code: " + courseCode[i];
                        label.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        label.ForeColor = Color.White;
                        labelLocationY += 120;
                        label.Cursor = Cursors.Hand;
                        label.ContextMenuStrip = cMenuDeleteProgram;

                        // Store related data in the Tag property
                        //Tag - user defined data associated with the object
                        label.Tag = new { ProgramName = programName[i], YearLevel = yearLevel[i], Section = section[i], CourseCode = courseCode[i] };

                        //Add Event Handler
                        label.Click += lblSection_Click;

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

        private void TheCourseDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();

        }

        private void lblSection_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null && label.Tag != null)
            {
                // Retrieve the data from the Tag property
                var data = (dynamic)label.Tag;
                programName = data.ProgramName.Trim();
                yearLevel = data.YearLevel;
                section = data.Section;
                courseCode = data.CourseCode;

                // Debug Tool
                //MessageBox.Show($"Program Name: {programName}\nYear Level: {yearLevel}\nSection: {section}");
            }

            //Open the Gradebook of specific section
            this.Hide();
            GradeBook gradeBook = new GradeBook();
            gradeBook.ShowDialog();
            this.Close();

        }

        private void deleteProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Context Menu Strip
            //Right-click label

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip menuStrip = (ContextMenuStrip)menuItem.Owner;
            Label label = (Label)menuStrip.SourceControl;
            
            var data = (dynamic)label.Tag;
            string courseCode = data.CourseCode.Trim();

            //Debug
            //MessageBox.Show("Course Code" + courseCode);

            if(MessageBox.Show("Deleting this program-section will delete all records of students in this class. Are you sure you want to continue?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "DELETE FROM course WHERE course_code = @courseCode";

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@courseCode", courseCode);

                    if(db.cmd.ExecuteNonQuery() > 0)
                    {
                        if(MessageBox.Show("Successfully deleted the program", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            LoadDashboard();
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occur:" + ex.Message + "\n" + ex.StackTrace);
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

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TheFacultyDashboard f = new TheFacultyDashboard(); 
            f.ShowDialog();
            this.Close();
        }

        private void menuLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log out?", "Log out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                TheFacultyLogIn s = new TheFacultyLogIn();
                s.ShowDialog();
                this.Close();
            }
        }

        private void menuPassword_Click(object sender, EventArgs e)
        {
            Manage_Password m = new Manage_Password();
            TheFacultyDashboard.type = "teacher";
            m.ShowDialog();
        }
    }
}
