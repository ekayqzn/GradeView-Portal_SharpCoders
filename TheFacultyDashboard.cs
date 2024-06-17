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
    public partial class TheFacultyDashboard : Form
    {
        //Instantiate DatabaseConnection Class
        databaseConnection db = new databaseConnection();

        //Clicked Subject Tile
        public static string subjectTile;
        public static int classID;
        public TheFacultyDashboard()
        {
            InitializeComponent();
        }
        private void rbtnAddClass_Click(object sender, EventArgs e)
        {
            //Form to add subject will show
            this.Hide();
            Add_Subject addSubject = new Add_Subject();
            addSubject.ShowDialog();
            this.Close();
        }

        private void TheFacultyDashboard_Load(object sender, EventArgs e)
        {
            //This form will load when the user correctly input the login details
            //MessageBox.Show(LogInOperation.userID);

            try
            {
                // Get class_id and subject code that the teacher teaches
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT class.class_id, class.subject_code, subject_info.subject_name FROM modern_gradesbook.class JOIN subject_info ON class.subject_code = subject_info.subject_code WHERE teacher_id = @teacherId";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());
                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); // Populate dataTable

                string[] classId = new string[dataTable.Rows.Count];
                string[] subjectCode = new string[dataTable.Rows.Count];
                string[] subjectName = new string[dataTable.Rows.Count];

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    classId[i] = dataTable.Rows[i]["class_id"].ToString();
                    subjectCode[i] = dataTable.Rows[i]["subject_code"].ToString();
                    subjectName[i] = dataTable.Rows[i]["subject_name"].ToString();
                }

                if (dataTable.Rows.Count > 0)
                {
                    int labelSizeX = 210;
                    int labelSizeY = 178;
                    int labelLocationX = 131; // Increment by 200
                    int labelLocationY = 40; // Increment by 212
                    int tileCount = 0;

                    Random random = new Random();

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Label label = new Label
                        {
                            Name = "lblSub" + (i + 1).ToString(),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Text = subjectCode[i] + Environment.NewLine + subjectName[i],
                            AutoSize = false,
                            Size = new Size(labelSizeX, labelSizeY),
                            BackColor = Color.FromArgb(random.Next(0, 100), random.Next(100, 200), random.Next(200, 256)),
                            Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                            ForeColor = Color.White,
                            Cursor = Cursors.Hand
                        };

                        if (tileCount < 5)
                        {
                            label.Location = new Point(labelLocationX, labelLocationY);
                            labelLocationX += 250;
                            tileCount++;
                        }
                        if (tileCount == 5)
                        {
                            tileCount = 0;
                            labelLocationX = 131;
                            labelLocationY += 212;
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
            string[] labelParts = label.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            subjectTile = labelParts[0].Trim(); // Only get the subject code part
            string teacherId = LogInOperation.userID.Trim();

            //For Debug
            //MessageBox.Show(subjectTile);
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
            TheCourseDashboard courseDB = new TheCourseDashboard();
            courseDB.ShowDialog();
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
