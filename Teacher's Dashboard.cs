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
            this.Hide();
            Add_Subject addSubject = new Add_Subject();
            addSubject.ShowDialog();
            this.Close();
        }

        private void Teacher_s_Dashboard_Load(object sender, EventArgs e)
        {
            //Debugging Tool to show the userID from login details
            //MessageBox.Show(Faculty_LogIn.userID);

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT class_id, subject_code FROM modern_gradesbook.class WHERE teacher_id = @teacherId";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@teacherId", Faculty_LogIn.userID);
                //SelectCommand property select the sql command
                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                //get class id and subject code. store to a string array
                string[] classId = new string[dataTable.Rows.Count];
                string[] subjectCode = new string[dataTable.Rows.Count];

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    classId[i] = dataTable.Rows[i]["class_id"].ToString();
                    subjectCode[i] = dataTable.Rows[i]["subject_code"].ToString();
                }

                if(dataTable.Rows.Count > 0)
                {
                    int labelSizeX = 241;
                    int labelSizeY = 178;
                    int labelLocationX = 25; //increment by 286
                    int labelLocationY = 141; //increment by 224
                    // Generates a random integer between 128 and 255 for light colors
                    Random random = new Random();
                    int red = random.Next(200, 256); 
                    int green = random.Next(150, 200);
                    int blue = random.Next(150, 200);
                    for (int i = 0; i < dataTable.Rows.Count;i++)
                    {
                        Label label = new Label();
                        label.Name = "lblSub" + (i+1).ToString();
                        label.TextAlign = ContentAlignment.BottomLeft;
                        label.Text = subjectCode[i] + Environment.NewLine; //!! Add Subject Name
                        label.AutoSize = false;
                        label.Size = new Size(labelSizeX, labelSizeY);
                        label.BackColor = Color.FromArgb(red, green, blue);
                        red = random.Next(200, 256);
                        green = random.Next(150, 200);
                        blue = random.Next(150, 200);
                        int tileCount = 0;

                        //tile is 3 per row
                        if (tileCount+1 <= 3)
                        {
                            label.Location = new Point(labelLocationX, labelLocationY);
                            labelLocationX += 286;
                        }
                        if(tileCount+1 == 3) //New Line when reaches 3
                        {
                            tileCount = 0;
                            labelLocationX = 25;
                            labelLocationY += 224;
                        }

                        //Add Event Handler
                        label.Click += lblSubject_Click;

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

        private void lblSubject_Click (object sender, EventArgs e)
        {
            Label label = (Label)sender;
            subjectTile = label.Text.Trim();
            string teacherId = Faculty_LogIn.userID.Trim();

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
                //Debug Tool
                //MessageBox.Show(classID.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Disconnect();
            }

            this.Hide();
            Course_Dashboard courseDB = new Course_Dashboard();
            courseDB.ShowDialog();
            this.Close();
        }
    }
}
