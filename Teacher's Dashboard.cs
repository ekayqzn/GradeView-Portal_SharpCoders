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
    public partial class Teacher_s_Dashboard : Form
    {
        //Instantiate DatabaseConnection Class
        databaseConnection db = new databaseConnection();

        //Clicked Subject Tile
        public static string subjectTile;
        public static int classID;
        public Teacher_s_Dashboard()
        {
            InitializeComponent();
        }

        private void rbtnAddSubject_Click(object sender, EventArgs e)
        {
            //Form to add subject will show
            this.Hide();
            Add_Subject addSubject = new Add_Subject();
            addSubject.ShowDialog();
            this.Close();
            
        }

        private void Teacher_s_Dashboard_Load(object sender, EventArgs e)
        {
            //This form will load when the user correctly input the login details

            try
            {
                // Get class_id and subject code that the teacher teaches
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT class_id, subject_code FROM modern_gradesbook.class WHERE teacher_id = @teacherId";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@teacherId", FacultyLogIn.userID);
                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); // Populate dataTable

                string[] classId = new string[dataTable.Rows.Count];
                string[] subjectCode = new string[dataTable.Rows.Count];

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    classId[i] = dataTable.Rows[i]["class_id"].ToString();
                    subjectCode[i] = dataTable.Rows[i]["subject_code"].ToString();
                }

                if (dataTable.Rows.Count > 0)
                {
                    int labelSizeX = 241;
                    int labelSizeY = 178;
                    int labelLocationX = 25; // Increment by 286
                    int labelLocationY = 141; // Increment by 224
                    int tileCount = 0;

                    Random random = new Random();

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Label label = new Label
                        {
                            Name = "lblSub" + (i + 1).ToString(),
                            TextAlign = ContentAlignment.BottomLeft,
                            Text = subjectCode[i] + Environment.NewLine,
                            AutoSize = false,
                            Size = new Size(labelSizeX, labelSizeY),
                            BackColor = Color.FromArgb(random.Next(0, 100), random.Next(100, 200), random.Next(200, 256))
                        };

                        if (tileCount < 3)
                        {
                            label.Location = new Point(labelLocationX, labelLocationY);
                            labelLocationX += 286;
                            tileCount++;
                        }
                        if (tileCount == 3)
                        {
                            tileCount = 0;
                            labelLocationX = 25;
                            labelLocationY += 224;
                        }

                        // Add Event Handler
                        label.Click += lblSubject_Click;

                        // Add to panel
                        panel2.Controls.Add(label);

                        // Debugging log
                        //MessageBox.Show($"Label {label.Name} created at location {label.Location} with color {label.BackColor}.");
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

        private void lblSubject_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            subjectTile = label.Text.Trim();
            string teacherId = FacultyLogIn.userID.Trim();

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subjectCode AND teacher_id = @teacherId";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@subjectCode", subjectTile);
                db.cmd.Parameters.AddWithValue("@teacherId", teacherId);

                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    classID = Convert.ToInt32(dataTable.Rows[0]["class_id"]);
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

            //MessageBox.Show($"Clicked on: {subjectTile}, Teacher ID: {teacherId}, Class ID: {classID}");

            this.Hide();
            Course_Dashboard courseDB = new Course_Dashboard();
            courseDB.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LinkLBLHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LandingPage l = new LandingPage();
            l.ShowDialog();
            this.Close();
        }
    }
}
