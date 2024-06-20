using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class AddQuery
    {
        databaseConnection db = new databaseConnection();

        public bool AddStudent (string studentNum, string fName, string mName, string lName, string status, string program, int year, int section)
        {
            int programID = 0;
            bool isSuccessful = false;
            try
            {
                // Check for duplicate student ID
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT COUNT(*) FROM modern_gradesbook.student_info WHERE student_id = @studentID";
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@studentID", studentNum);

                int studentCount = Convert.ToInt32(db.cmd.ExecuteScalar());

                if (studentCount > 0)
                {
                    MessageBox.Show("A Student with the provided Student Number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Add Info to student_info table
                    db.cmd.CommandText = "INSERT INTO modern_gradesbook.student_info (student_id, first_name, last_name, middle_name) VALUES(@studentID, @firstName, @lastName, @middleName)";
                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@studentID", studentNum);
                    db.cmd.Parameters.AddWithValue("@firstName", fName);
                    db.cmd.Parameters.AddWithValue("@lastName", lName);
                    db.cmd.Parameters.AddWithValue("@middleName", mName);

                    db.cmd.ExecuteNonQuery();

                    // Get program id
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE program_name = @programName AND year_level = @year AND section = @section";
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@programName", program);
                        db.cmd.Parameters.AddWithValue("@year", year);
                        db.cmd.Parameters.AddWithValue("@section", section);

                        // SelectCommand property select the sql command
                        db.dta.SelectCommand = db.cmd;

                        // DataTable
                        DataTable dataTable = new DataTable();
                        db.dta.Fill(dataTable); // populate dataTable

                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            programID = Convert.ToInt32(dataTable.Rows[0]["program_id"]);
                        }
                        else
                        {
                            MessageBox.Show("Program not found. Please check the program details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }

                    // Add info to section table
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = "INSERT INTO modern_gradesbook.section(student_id, program_id, enrollment_status) VALUES(@studentNumber, @programID, @status)";
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@studentNumber", studentNum);
                        db.cmd.Parameters.AddWithValue("@programID", programID);
                        db.cmd.Parameters.AddWithValue("@status", status);

                        db.cmd.ExecuteNonQuery();

                        isSuccessful = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return isSuccessful;
            
        }
        public bool AddTeacher(string teacherNum, string fName, string mName, string lName)
        {
            bool isAdded = true;
            bool isDuplicateNum = false;

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT teacher_id FROM modern_gradesbook.teacher_info WHERE teacher_id = @teacherID";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@teacherID", teacherNum);

                db.dta.SelectCommand = db.cmd;
                DataTable dt = new DataTable();
                db.dta.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    isDuplicateNum = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occur: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            if(isDuplicateNum)
            {
                MessageBox.Show("The Teacher Number you provided already exists. Please enter a different number.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isAdded = false;
            }
            else
            {
                try
                {
                    db.Connect();
                    db.cmd.Connection = db.conn;
                    db.cmd.CommandText = "INSERT INTO modern_gradesbook.teacher_info (teacher_id, teacher_fname, teacher_mname, teacher_lname) VALUES (@ID, @fname, @mname, @lname)";

                    db.cmd.Parameters.Clear();
                    db.cmd.Parameters.AddWithValue("@ID", teacherNum);
                    db.cmd.Parameters.AddWithValue("@fname", fName);
                    db.cmd.Parameters.AddWithValue("@mname", mName);
                    db.cmd.Parameters.AddWithValue("@lname", lName);

                    db.cmd.ExecuteNonQuery();

                    MessageBox.Show("Teacher has been successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occur: " + ex.Message + "\n" + ex.StackTrace);
                    isAdded = false;
                }
                finally
                {
                    db.Disconnect();
                }
            }
            return isAdded;
        }
        public bool AddProgram(string programName, int year, int section)
        {
            bool isAdded = true;
            bool isDuplicate = false;

            try //get programID to check if program name already exists
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = "SELECT program_id FROM modern_gradesbook.program WHERE LOWER(program_name) = LOWER(@programName)";

                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@programName", programName.ToLower());
                
                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                if(dataTable1.Rows.Count > 0 )
                {
                    isDuplicate = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occur: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            if (!isDuplicate) //if program name not exists yet
            {
                for (int i = 1; i <= year; i++)
                {
                    for (int j = 1; j <= section; j++) //use nested loop to insert year and section per program
                    {
                        try
                        {
                            db.Connect();
                            db.cmd.Connection = db.conn;
                            db.cmd.CommandText = "INSERT INTO modern_gradesbook.program (program_name, year_level, section) VALUES (@programName, @year, @section)";

                            db.cmd.Parameters.Clear();
                            db.cmd.Parameters.AddWithValue("@programName", programName);
                            db.cmd.Parameters.AddWithValue("@year", i);
                            db.cmd.Parameters.AddWithValue("@section", j);

                            db.cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occur: " + ex.Message + "\n" + ex.StackTrace);
                        }
                        finally
                        {
                            db.Disconnect();
                        }
                    }
                }
                MessageBox.Show("Program has been successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("The program already exists. Please enter a different program.", "Duplicate Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Otherwise, program already exists
                isAdded = false;
            }

            return isAdded;
            
        }
    }
}
