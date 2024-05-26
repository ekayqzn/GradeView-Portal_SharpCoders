﻿using System;
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
    public partial class GradeBook : Form
    {
        public static int programID;
        public static int courseID;
        public GradeBook()
        {
            InitializeComponent();
        }

        private void GradeBook_Load(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
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
                    label.Text = Teacher_s_Dashboard.subjectTile + Environment.NewLine + subjectName + Environment.NewLine + Course_Dashboard.programName + Environment.NewLine + Course_Dashboard.yearLevel + " - " + Course_Dashboard.section;
                    label.Location = new Point(35, 35);
                    label.AutoSize = true;
                    this.Controls.Add(label);
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

            //Get program ID of the clicked section tile
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @yearLevel AND section = @section";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programName", Course_Dashboard.programName);
                db.cmd.Parameters.AddWithValue("@yearLevel", Course_Dashboard.yearLevel);
                db.cmd.Parameters.AddWithValue("@section", Course_Dashboard.section);

                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable);

                if(dataTable.Rows.Count > 0)
                {
                    programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(programID.ToString());
                db.Disconnect();
            }

            //Get course_id
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT course_id FROM modern_gradesbook.course WHERE program_id = @programID AND class_id = @classID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programID", programID);
                db.cmd.Parameters.AddWithValue("@classID", Teacher_s_Dashboard.classID);

                db.dta.SelectCommand = db.cmd;

                DataTable dataTable = new DataTable();
                db.dta.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    courseID = Convert.ToInt32(dataTable.Rows[0]["course_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(courseID.ToString());
                db.Disconnect();
            }
        }
    }
}
