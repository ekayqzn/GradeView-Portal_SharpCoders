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
            string subjectName = "";
            string subjectCode = Teacher_s_Dashboard.subjectTile.Trim(); // Trim any extra spaces

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
                    label.Text = subjectCode + Environment.NewLine + subjectName;
                    label.Location = new Point(35, 35);
                    label.AutoSize = true;
                    panel1.Controls.Add(label);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }

            //Get Section Information(program name, year level, section) will also be displayed as tile
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT course.course_code, program.program_name, program.year_level, program.section FROM program JOIN course WHERE program.program_id IN(SELECT program_id FROM modern_gradesbook.course WHERE class_id = @classID)";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID); //use classID from Teacher's Dashboard when the tile is click

                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                string[] programName = new string[dataTable.Rows.Count];
                int[] yearLevel = new int[dataTable.Rows.Count];
                int[] section = new int[dataTable.Rows.Count];
                string[] courseCode = new string[dataTable.Rows.Count];

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    programName[i] = dataTable.Rows[i]["program_name"].ToString();
                    yearLevel[i] = Convert.ToInt32(dataTable.Rows[i]["year_level"]);
                    section[i] = Convert.ToInt32(dataTable.Rows[i]["section"]);
                    courseCode[i] = dataTable.Rows[i]["course_code"].ToString();
                }

                if (dataTable.Rows.Count >= 0)
                {
                    int labelSizeX = 450;
                    int labelSizeY = 65;
                    int labelLocationX = 49; //constant
                    int labelLocationY = 169; //increment by 86
                    // Generates a random integer between 128 and 255 for light colors
                    Random random = new Random();
                    int red = random.Next(200, 256);
                    int green = random.Next(150, 200);
                    int blue = random.Next(150, 200);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Label label = new Label();
                        label.Name = "lblSection" + (i + 1).ToString();
                        label.TextAlign = ContentAlignment.MiddleLeft;
                        label.AutoSize = false;
                        label.Size = new Size(labelSizeX, labelSizeY);
                        label.BackColor = Color.FromArgb(red, green, blue);
                        red = random.Next(200, 256);
                        green = random.Next(150, 200);
                        blue = random.Next(150, 200);
                        label.Location = new Point(labelLocationX, labelLocationY);
                        label.Text = programName[i] + Environment.NewLine + yearLevel[i].ToString() + " - " + section[i].ToString() + Environment.NewLine + "Code: " + courseCode[i];
                        labelLocationY += 86;

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
