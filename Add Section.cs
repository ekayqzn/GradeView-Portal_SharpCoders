using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace gradesBookApp
{
    public partial class Add_Section : Form
    {
        public static string programName;
        public static int section;
        public static int year;
        public static int programID;
        public static string courseCode;

        databaseConnection db = new databaseConnection();
        Randomize r = new Randomize();
        public Add_Section()
        {
            InitializeComponent();
        }

        private void cboProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            //!Retrieve programs in database
            if (cboProgram.SelectedItem.ToString() == "Bachelor of Science in Information Technology" || cboProgram.SelectedItem.ToString() == "Bachelor of Science in Hospitality Management" || cboProgram.SelectedItem.ToString() == "Bachelor of Secondary Education major in English" || cboProgram.SelectedItem.ToString() == "Bachelor of Secondary Education major in Mathematics") 
            {
                numSection.Maximum = 2;
                numSection.Minimum = 1;
            }
            else if (cboProgram.SelectedItem.ToString() == "Bachelor of Science in Accountancy" || cboProgram.SelectedItem.ToString() == "Bachelor of Science in Computer Engineering")
            {
                numSection.Maximum = 1;
                numSection.Minimum = 1;
            }
            else if (cboProgram.SelectedItem.ToString() == "Bachelor of Science in Entrepreneurship")
            {
                numSection.Maximum = 3;
                numSection.Minimum = 1;
            }
        }

        private void rbtnOK_Click(object sender, EventArgs e)
        {
            programName = cboProgram.SelectedItem.ToString().Trim();
            year = Convert.ToInt32(numYear.Value);
            section = Convert.ToInt32(numSection.Value);
            courseCode = r.GenerateRandomCode();

            //! Check for duplicates in database and course dashboard

            //Add program_id, class_id, and code to course table
            try
            {
                //Get program_id
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @year AND section = @section";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programName", programName);
                db.cmd.Parameters.AddWithValue("@year", year);
                db.cmd.Parameters.AddWithValue("@section", section);

                //SelectCommand property select the sql command
                db.dta.SelectCommand = db.cmd;

                //DataTable
                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable); //populate dataTable

                programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);

                //RANDOMLY GENERATED CODE
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "INSERT INTO course (class_id, program_id, course_code) VALUES(@class_id, @program_id, @code)";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@class_id", Teacher_s_Dashboard.classID);
                db.cmd.Parameters.AddWithValue("@program_id", programID);
                db.cmd.Parameters.AddWithValue("@code", courseCode);

                db.cmd.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
                Course_Dashboard courseDB = new Course_Dashboard();
                this.Hide();
                courseDB.ShowDialog();
                this.Close();
            }
        }
    }
}
