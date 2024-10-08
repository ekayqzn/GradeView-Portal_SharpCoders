﻿using System;
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
        public static string subCode = "";
        public static string subName = "";
        public static int classID; //For customize grade query
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
           TheFacultyDashboard teacherDashboard = new TheFacultyDashboard();
            teacherDashboard.ShowDialog();
            this.Close();
        }

        private void rbtnNext_Click(object sender, EventArgs e)
        {
            //Get subject code and subject name from user input
            subCode = txtSubCode.Text.ToUpper().Trim();
            subName = txtSubName.Text.Trim();
            if((!String.IsNullOrEmpty(subCode)) && (!String.IsNullOrEmpty(subName)))
            {
                try
                {
                    //Check if the subject and the teacher already saved in the database
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@subCode", subCode);
                    db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());
                    db.dta.SelectCommand = db.cmd;

                    DataTable dataTable = new DataTable();
                    db.dta.Fill(dataTable);

                    if (dataTable.Rows.Count == 0) //Teacher doesn't added the subject yet in her dashboard or have no record that she's teaching this subject in the database
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
                            db.cmd.CommandText = "INSERT INTO modern_gradesbook.class (subject_code, teacher_id) VALUES(@subCode, @teacherId)"; //add the teacher, subject to the class table

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@subCode", subCode);
                            db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());
                            db.cmd.ExecuteNonQuery();

                            try
                            { //get the class_id of newly added pair of subject and teacher
                                db.Connect();
                                db.cmd.Connection = db.conn;
                                db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@subCode", subCode);
                                db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());

                                db.dta.SelectCommand = db.cmd;

                                DataTable dataTable2 = new DataTable();
                                db.dta.Fill(dataTable2);


                                if (dataTable2.Rows.Count > 0)
                                {
                                    //store class_id and code to a public static variable
                                    classID = Convert.ToInt32(dataTable2.Rows[0]["class_id"]);
                                }

                                //Debug Tool Confirming the classID value
                                //MessageBox.Show(classID.ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                db.Disconnect();
                            }

                            //Once performed all operation, Message Box will show to notify the user. When clicked the OK button, this form will close and appears the CustomizeGrade form
                            if (MessageBox.Show("The subject is successfully added to your dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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
                            db.cmd.CommandText = "INSERT INTO modern_gradesbook.class (subject_code, teacher_id) VALUES(@subCode, @teacherId)"; //add the teacher, subject, code to the class table

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@subCode", subCode);
                            db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());
                            db.cmd.ExecuteNonQuery();

                            try
                            {
                                //get newly added class_id
                                db.Connect();
                                db.cmd.Connection = db.conn;
                                db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@subCode", subCode);
                                db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());

                                db.dta.SelectCommand = db.cmd;

                                DataTable dataTable2 = new DataTable();
                                db.dta.Fill(dataTable2);

                                if (dataTable2.Rows.Count > 0)
                                {
                                    //store class_id and code to a public static variable
                                    classID = Convert.ToInt32(dataTable2.Rows[0]["class_id"]);
                                }

                                //Debug Tool
                                //MessageBox.Show(classID.ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                db.Disconnect();
                            }

                            if (MessageBox.Show("The subject is successfully added to your dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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
                        if (MessageBox.Show("The subject is already added to your Dashboard. Duplicated subject is not allowed.", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            this.Hide();
                            TheFacultyDashboard teacherDashboard = new TheFacultyDashboard();
                            teacherDashboard.ShowDialog();
                            this.Close();
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
            else
            {
                if(String.IsNullOrEmpty(subCode) && String.IsNullOrEmpty(subName))
                {
                    MessageBox.Show("Try Again! No fields should be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubCode.Focus();
                    return;
                }
                else if(String.IsNullOrEmpty(subCode))
                {
                    MessageBox.Show("Try Again! No fields should be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubCode.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Try Again! No fields should be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubName.Focus();
                    return;
                }
            }
            
        }

        private void Add_Subject_Load(object sender, EventArgs e)
        {
            txtSubCode.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtSubName.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Get subject code and subject name from user input
                subCode = txtSubCode.Text.ToUpper().Trim();
                subName = txtSubName.Text.Trim();
                if ((!String.IsNullOrEmpty(subCode)) && (!String.IsNullOrEmpty(subName)))
                {
                    try
                    {
                        //Check if the subject and the teacher already saved in the database
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@subCode", subCode);
                        db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());
                        db.dta.SelectCommand = db.cmd;

                        DataTable dataTable = new DataTable();
                        db.dta.Fill(dataTable);

                        if (dataTable.Rows.Count == 0) //Teacher doesn't added the subject yet in her dashboard or have no record that she's teaching this subject in the database
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
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.class (subject_code, teacher_id) VALUES(@subCode, @teacherId)"; //add the teacher, subject to the class table

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@subCode", subCode);
                                db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());
                                db.cmd.ExecuteNonQuery();

                                try
                                { //get the class_id of newly added pair of subject and teacher
                                    db.Connect();
                                    db.cmd.Connection = db.conn;
                                    db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                                    db.cmd.Parameters.Clear();
                                    db.cmd.Parameters.AddWithValue("@subCode", subCode);
                                    db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());

                                    db.dta.SelectCommand = db.cmd;

                                    DataTable dataTable2 = new DataTable();
                                    db.dta.Fill(dataTable2);


                                    if (dataTable2.Rows.Count > 0)
                                    {
                                        //store class_id and code to a public static variable
                                        classID = Convert.ToInt32(dataTable2.Rows[0]["class_id"]);
                                    }

                                    //Debug Tool Confirming the classID value
                                    //MessageBox.Show(classID.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    db.Disconnect();
                                }

                                //Once performed all operation, Message Box will show to notify the user. When clicked the OK button, this form will close and appears the CustomizeGrade form
                                if (MessageBox.Show("The subject is successfully added to your dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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
                                db.cmd.CommandText = "INSERT INTO modern_gradesbook.class (subject_code, teacher_id) VALUES(@subCode, @teacherId)"; //add the teacher, subject, code to the class table

                                db.cmd.Parameters.Clear();
                                db.cmd.Parameters.AddWithValue("@subCode", subCode);
                                db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());
                                db.cmd.ExecuteNonQuery();

                                try
                                {
                                    //get newly added class_id
                                    db.Connect();
                                    db.cmd.Connection = db.conn;
                                    db.cmd.CommandText = "SELECT class_id FROM modern_gradesbook.class WHERE subject_code = @subCode AND teacher_id = @teacherId";

                                    db.cmd.Parameters.Clear();
                                    db.cmd.Parameters.AddWithValue("@subCode", subCode);
                                    db.cmd.Parameters.AddWithValue("@teacherId", LogInOperation.userID.Trim());

                                    db.dta.SelectCommand = db.cmd;

                                    DataTable dataTable2 = new DataTable();
                                    db.dta.Fill(dataTable2);

                                    if (dataTable2.Rows.Count > 0)
                                    {
                                        //store class_id and code to a public static variable
                                        classID = Convert.ToInt32(dataTable2.Rows[0]["class_id"]);
                                    }

                                    //Debug Tool
                                    //MessageBox.Show(classID.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    db.Disconnect();
                                }

                                if (MessageBox.Show("Subject successfully added to your dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
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
                            if (MessageBox.Show("Subject is already added to your Dashboard. Duplicated subject is not allowed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                this.Hide();
                                TheFacultyDashboard teacherDashboard = new TheFacultyDashboard();
                                teacherDashboard.ShowDialog();
                                this.Close();
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
                else
                {
                    if (String.IsNullOrEmpty(subCode) && String.IsNullOrEmpty(subName))
                    {
                        MessageBox.Show("Try Again! Field cannot be empty", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSubCode.Focus();
                        return;
                    }
                    else if (String.IsNullOrEmpty(subCode))
                    {
                        MessageBox.Show("Try Again! No fields should be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSubCode.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Try Again! No fields should be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSubName.Focus();
                        return;
                    }
                }
            }
        }
    }
}
