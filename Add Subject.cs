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
    public partial class Add_Subject : Form
    {
        databaseConnection db = new databaseConnection();
        public string subCode = "";
        public string subName = "";
        public static int classID;
        Randomize r = new Randomize();
        public string code = "";

        public static string classCode;
        public Add_Subject()
        {
            InitializeComponent();
        }

        private void rbtnBack_Click(object sender, EventArgs e)
        {
            //Back Button 
            //Go back to the Teacher Dashboard
            this.Hide();
            Teacher_s_Dashboard teacherDashboard = new Teacher_s_Dashboard();
            teacherDashboard.ShowDialog();
            this.Close();
        }

        private void rbtnNext_Click(object sender, EventArgs e)
        {
            //Get subject code and subject name from user input
            subCode = txtSubCode.Text.Trim();
            subName = txtSubName.Text.Trim();

            //Generate Random code for this class
            code = r.GenerateRandomCode().Trim();
            try
            {
                //Check if the subject and the teacher already saved in the database
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@subCode", subCode);
                db.cmd.Parameters.AddWithValue("@teacherId", Faculty_LogIn.userID.Trim());
                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable);

                if(dataTable.Rows.Count == 0 ) //Teacher doesn't added the subject yet in her dashboard or have no record that she's teaching this subject in the database
                {
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "SELECT subject_code FROM modern_gradesbook.subject_info WHERE subject_code = @subCode"; // check if the subject exist in subject_info table

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@subCode", subCode);
                    db.dta.SelectCommand = db.cmd;

                    DataTable dataTable1 = new DataTable();
                    db.dta.Fill(dataTable1);

                    if (dataTable1.Rows.Count == 0) //subject not exist in subject_info table
                    {
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "INSERT INTO modern_gradesbook.subject_info VALUES(@subCode, @subName)"; //add the subject

                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@subCode", subCode);
                        db.cmd.Parameters.AddWithValue("@subName", subName);
                        db.cmd.ExecuteNonQuery();

                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "INSERT INTO modern_gradesbook.class (subject_code, teacher_id, class_code) VALUES(@subCode, @teacherId, @code)"; //add the teacher, subject, code to the class table

                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@subCode", subCode);
                        db.cmd.Parameters.AddWithValue("@teacherId", Faculty_LogIn.userID.Trim());
                        db.cmd.Parameters.AddWithValue("@code", code);
                        db.cmd.ExecuteNonQuery();

                        try
                        { //get the class_id of newly added pair of subject and teacher
                            db.Connect();
                            db.cmd.Connection = db.conn;
                            db.cmd.CommandText = "SELECT class_id, class_code FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@subCode", subCode);
                            db.cmd.Parameters.AddWithValue("@teacherId", Faculty_LogIn.userID.Trim());

                            db.dta.SelectCommand = db.cmd;

                            DataTable dataTable2 = new DataTable();
                            db.dta.Fill(dataTable2);

                            if (dataTable2.Rows.Count > 0)
                            {
                                //store class_id and code to a public static variable
                                classID = Convert.ToInt32(dataTable2.Rows[0]["class_id"]);
                                classCode = dataTable2.Rows[0]["class_code"].ToString();
                            }

                            //Debug Tool Confirming the classID value
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

                        //Once performed all operation, Message Box will show to notify the user. When clicked the OK button, this form will close and appears the CustomizeGrade form
                        if (MessageBox.Show("Subject Created. Successfully Added the Subject", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            this.Hide();
                            CustomizeGrade customizeGrade = new CustomizeGrade();
                            customizeGrade.ShowDialog();
                            this.Close();
                        }
                    }
                    else if (dataTable1.Rows.Count > 0) //subject already exist in subject_info table
                    {

                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "INSERT INTO modern_gradesbook.class (subject_code, teacher_id, class_code) VALUES(@subCode, @teacherId, @code)"; //add the teacher, subject, code to the class table

                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@subCode", subCode);
                        db.cmd.Parameters.AddWithValue("@teacherId", Faculty_LogIn.userID.Trim());
                        db.cmd.Parameters.AddWithValue("@code", code);
                        db.cmd.ExecuteNonQuery();
                        
                        try
                        {
                            //get newly added class_id
                            db.Connect();
                            db.cmd.Connection = db.conn;
                            db.cmd.CommandText = "SELECT class_id, class_code FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@subCode", subCode);
                            db.cmd.Parameters.AddWithValue("@teacherId", Faculty_LogIn.userID.Trim());

                            db.dta.SelectCommand = db.cmd;

                            DataTable dataTable2 = new DataTable();
                            db.dta.Fill(dataTable2);

                            if (dataTable2.Rows.Count > 0)
                            {
                                //store class_id and code to a public static variable
                                classID = Convert.ToInt32(dataTable2.Rows[0]["class_id"]);
                                classCode = dataTable2.Rows[0]["class_code"].ToString();
                            }

                            //Debug Tool
                            MessageBox.Show(classCode);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            db.Disconnect();
                        }

                        if (MessageBox.Show("Successfully Added the Subject", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            //!ADD TO MESSAGE BOX THE CODE

                            //Once performed all operation, Message Box will show to notify the user. When clicked the OK button, this form will close and appears the CustomizeGrade form
                            this.Hide();
                            CustomizeGrade customizeGrade = new CustomizeGrade();
                            customizeGrade.ShowDialog();
                            this.Close();
                        }
                    }
                }
                else //If the subject the user want to add is already in the database and in her dashboard
                {
                    if(MessageBox.Show("Subject is already Added to your Dashboard. Duplicate Subject is not allowed", "Duplicate Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK) {
                        this.Hide();
                        Teacher_s_Dashboard teacherDashboard = new Teacher_s_Dashboard();
                        teacherDashboard.ShowDialog();
                        this.Close();
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
    }
}
