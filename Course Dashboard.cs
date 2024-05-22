using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gradesBookApp
{
    public partial class Course_Dashboard : Form
    {
        databaseConnection db = new databaseConnection();
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
                    label.Text = Teacher_s_Dashboard.subjectTile + Environment.NewLine + subjectName;
                    label.Location = new Point(35, 35);
                    label.AutoSize = true;
                    panel1.Controls.Add(label);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                db.cmd.CommandText = "SELECT program.program_name, program.year_level, program.section FROM program WHERE program.program_id IN(SELECT program_id FROM modern_gradesbook.course WHERE class_id = @classID)";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID); //use classID from Teacher's Dashboard when the tile is click

                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                string[] programName = new string[dataTable.Rows.Count];
                int[] yearLevel = new int[dataTable.Rows.Count];
                int[] section = new int[dataTable.Rows.Count];

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    programName[i] = dataTable.Rows[i]["program_name"].ToString();
                    yearLevel[i] = Convert.ToInt32(dataTable.Rows[i]["year_level"]);
                    section[i] = Convert.ToInt32(dataTable.Rows[i]["section"]);
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
                        label.Text = programName[i] + Environment.NewLine + yearLevel[i].ToString() + " - " + section[i].ToString();
                        labelLocationY += 86;


                        //Add Event Handler
                        label.Click += lblSection_Click;

                        //Add to panel
                        panel1.Controls.Add(label);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Disconnect();
            }
        }

        private void lblSection_Click(object sender, EventArgs e)
        {
            //Open the Gradebook of specific section
        }

        private void rbtnSection_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Section addSection = new Add_Section();
            addSection.ShowDialog();
            this.Close();
        }
    }
}
