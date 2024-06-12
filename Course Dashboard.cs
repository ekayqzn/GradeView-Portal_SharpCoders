using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gradesBookApp
{
    public partial class Course_Dashboard : Form
    {
        databaseConnection db = new databaseConnection();
        public static string programName;
        public static int yearLevel;
        public static int section;
        public static string courseCode;
        public Course_Dashboard()
        {
            InitializeComponent();
        }

        private void Course_Dashboard_Load(object sender, EventArgs e)
        {
            string subjectCode = Teacher_s_Dashboard.subjectTile.Trim(); // Trim any extra spaces

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
                db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID); //use classID from Teacher's Dashboard when the tile is click

                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                string[] subjectName = new string [dataTable.Rows.Count];
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

        private void rbtnSection_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Section addSection = new Add_Section();
            addSection.ShowDialog();
            this.Close();
        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher_s_Dashboard TDB = new Teacher_s_Dashboard();
            TDB.ShowDialog();
            this.Close();
        }

        private void LinkLBLBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Teacher_s_Dashboard TDB = new Teacher_s_Dashboard();
            TDB.ShowDialog();
            this.Close();
        }
    }
}
