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
    public partial class Student_s_Dashboard : Form
    {
        databaseConnection db = new databaseConnection();
        public Student_s_Dashboard()
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

        private void Student_s_Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                //get class_id and subject code that the teacher teaches
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT s.subject_code, s.subject_name, CONCAT(t.teacher_fname, ' ', t.teacher_lname) AS teacher_name " +
                    "FROM modern_gradesbook.enroll e JOIN modern_gradesbook.class c ON e.class_id = c.class_id " +
                    "JOIN modern_gradesbook.subject_info s ON s.subject_code = c.subject_code " +
                    "JOIN modern_gradesbook.teacher_info t ON t.teacher_id = c.teacher_id " +
                    "WHERE e.student_id = @studentID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", Student_Login.userID.Trim());
                //SelectCommand property select the sql command
                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                //get class id and subject code. store to a string array
                string[] subjectCode = new string[dataTable.Rows.Count];
                string[] subjectName = new string[dataTable.Rows.Count];
                string[] teacherName = new string[dataTable.Rows.Count];


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    subjectCode[i] = dataTable.Rows[i]["subject_code"].ToString();
                    subjectName[i] = dataTable.Rows[i]["subject_name"].ToString();
                    teacherName[i] = dataTable.Rows[i]["teacher_name"].ToString();
                }

                //if the database return the details, will dynamically create a tile/button for that specific subject
                if (dataTable.Rows.Count > 0)
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
                    for (int i = 0; i < dataTable.Rows.Count; i++) //will iterate as to the number of subject the teacher holds
                    {
                        Label label = new Label();
                        label.Name = "lblSub" + (i + 1).ToString();
                        label.TextAlign = ContentAlignment.BottomLeft;
                        label.Text = subjectName[i] + Environment.NewLine + subjectCode[i] + Environment.NewLine + teacherName[i];
                        label.AutoSize = false;
                        label.Size = new Size(labelSizeX, labelSizeY);
                        label.BackColor = Color.FromArgb(red, green, blue);
                        red = random.Next(200, 256);
                        green = random.Next(150, 200);
                        blue = random.Next(150, 200);
                        int tileCount = 0;

                        //tile is 3 per row
                        if (tileCount + 1 <= 3)
                        {
                            label.Location = new Point(labelLocationX, labelLocationY);
                            labelLocationX += 286;
                        }
                        if (tileCount + 1 == 3) //New Line when reaches 3
                        {
                            tileCount = 0;
                            labelLocationX = 25;
                            labelLocationY += 224;
                        }

                        //Add Event Handler
                        label.Click += lblSubject_Click;

                        //Add to panel
                        this.Controls.Add(label);
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

        private void lblSubject_Click (object sender, EventArgs e)
        {
            //Will show student scores for that specific subject (GRADEBOOK)
        }
    }
}
