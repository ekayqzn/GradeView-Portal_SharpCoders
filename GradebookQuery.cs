using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Math.Field;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class GradebookQuery
    {
        databaseConnection db = new databaseConnection();

        public void RemoveStudentToCourse (int classID, string studentID)
        {
            string commandText = "DELETE FROM enroll WHERE student_id = @studentID AND class_id = @classID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.cmd.ExecuteNonQuery();

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
        public void InsertEnrollId (string prefix, string tableName, int classID, string studentID)
        {
            int id = GetID("enroll", classID, studentID);
            string commandText = $"UPDATE {prefix}_{tableName} SET enroll_id = @id WHERE class_id = @classID AND student_id = @studentID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.cmd.Parameters.AddWithValue("@id", id);
                db.cmd.ExecuteNonQuery();

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
        public int GetID(string tableName, int classID, string studentID)
        {
            int result = 0;
            string commandText = $"SELECT {tableName}_id FROM modern_gradesbook.{tableName} WHERE class_id = @classID AND student_id = @studentID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.dta.SelectCommand = db.cmd;

                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                result = Convert.ToInt32(dataTable1.Rows[0][$"{tableName}_id"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                db.Disconnect();
            }

            return result;
        }

        public int GetID(string prefix, string tableName, int classID, string studentID)
        {
            int result = 0;
            string commandText = $"SELECT {prefix}_{tableName}_id FROM modern_gradesbook.{prefix}_{tableName} WHERE class_id = @classID AND student_id = @studentID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.dta.SelectCommand = db.cmd;

                db.dta.SelectCommand = db.cmd;
                DataTable dataTable1 = new DataTable();
                db.dta.Fill(dataTable1);

                result = Convert.ToInt32(dataTable1.Rows[0][$"{prefix}_{tableName}_id"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(1 + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }

                return result;
        }

        //Insert into enroll table the id per task
        public void insertToEnroll (string prefix, string tableName, int classID, string studentID)
        {
            int id = GetID(prefix, tableName, classID, studentID);

            string commandText = $"UPDATE enroll SET {prefix}_{tableName}_id = @id WHERE class_id = @classID AND student_id = @studentID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.cmd.Parameters.AddWithValue("@id", id);
                db.cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(1 + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }
        }

        //Copy Customize Gradebook to student records
        public bool mGetID (string tableName, int classID)
        {
            object result = false;
            string commandText = $"SELECT m_{tableName}_id FROM modern_gradesbook.m_{tableName} WHERE class_id = @classID AND student_id IS NULL";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                result = db.cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(1 + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool fGetID(string tableName, int classID)
        {
            object result = false;
            string commandText = $"SELECT f_{tableName}_id FROM f_{tableName} WHERE class_id = @classID AND student_id IS NULL";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                result = db.cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(2  + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Midterm Other Tasks
        public void mOthersCopy(string tableName, int classID, string studentID)
        {
            string commandText = $"INSERT INTO modern_gradesbook.m_{tableName} (m_{tableName}1, m_{tableName}1_score, m_{tableName}2, m_{tableName}2_score, m_{tableName}3, m_{tableName}3_score, m_{tableName}4, m_{tableName}4_score, m_{tableName}5, m_{tableName}5_score, m_{tableName}6, m_{tableName}6_score, m_{tableName}7, m_{tableName}7_score, m_{tableName}8, m_{tableName}8_score, m_{tableName}9, m_{tableName}9_score, m_{tableName}_percentage, class_id, count, student_id) SELECT m_{tableName}1, m_{tableName}1_score, m_{tableName}2, m_{tableName}2_score, m_{tableName}3,  m_{tableName}3_score, m_{tableName}4, m_{tableName}4_score, m_{tableName}5, m_{tableName}5_score, m_{tableName}6, m_{tableName}6_score, m_{tableName}7, m_{tableName}7_score, m_{tableName}8, m_{tableName}8_score, m_{tableName}9, m_{tableName}9_score, m_{tableName}_percentage, class_id, count, COALESCE(student_id, @studentID) FROM m_{tableName} WHERE class_id = @classID AND student_id IS NULL";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(4 + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }
        }


        //Midterm Other Tasks
        public void fOthersCopy(string tableName, int classID, string studentID)
        {
            string commandText = $"INSERT INTO modern_gradesbook.f_{tableName} (f_{tableName}1, f_{tableName}1_score, f_{tableName}2, f_{tableName}2_score, f_{tableName}3, f_{tableName}3_score, f_{tableName}4, f_{tableName}4_score, f_{tableName}5, f_{tableName}5_score, f_{tableName}6, f_{tableName}6_score, f_{tableName}7, f_{tableName}7_score, f_{tableName}8, f_{tableName}8_score, f_{tableName}9, f_{tableName}9_score, f_{tableName}_percentage, class_id, count, student_id) SELECT f_{tableName}1, f_{tableName}1_score, f_{tableName}2, f_{tableName}2_score, f_{tableName}3,  f_{tableName}3_score, f_{tableName}4, f_{tableName}4_score, f_{tableName}5, f_{tableName}5_score, f_{tableName}6, f_{tableName}6_score, f_{tableName}7, f_{tableName}7_score, f_{tableName}8, f_{tableName}8_score, f_{tableName}9, f_{tableName}9_score, f_{tableName}_percentage, class_id, count, COALESCE(student_id, @studentID) FROM f_{tableName} WHERE class_id = @classID AND student_id IS NULL";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show( 6 + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }
        }

        //rdos
        public void rdoCopy(string prefix, string tableName, int classID, string studentID)
        {
            string commandText = $"INSERT INTO modern_gradesbook.{prefix}_{tableName} ({prefix}_{tableName}, {prefix}_{tableName}_score, class_id, student_id, percentage) SELECT {prefix}_{tableName}, {prefix}_{tableName}_score, class_id, COALESCE(student_id, @studentID), percentage FROM {prefix}_{tableName} WHERE class_id = @classID AND student_id IS NULL";
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@classID", classID);
                db.cmd.Parameters.AddWithValue("@studentID", studentID);
                db.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(5 + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Disconnect();
            }
        }

        //Other midterm tasks
        public void mOthers(string tableName, int count, int percentage)
        {
            int[] column = new int[18];
            for (int i = 0; i < column.Length; i += 2)
            {
                if (i < count * 2) //included -1
                {
                    column[i] = -1;
                    column[i + 1] = -1;
                }
                else //not included is 0
                {
                    column[i] = 0;
                    column[i + 1] = 0;
                }
            }
            string columns = string.Join(", ", column);
            string commandText = $"INSERT INTO modern_gradesbook.m_{tableName} (m_{tableName}1, m_{tableName}1_score, m_{tableName}2, m_{tableName}2_score, m_{tableName}3,  m_{tableName}3_score, m_{tableName}4, m_{tableName}4_score, m_{tableName}5, m_{tableName}5_score, m_{tableName}6, m_{tableName}6_score, m_{tableName}7, m_{tableName}7_score, m_{tableName}8, m_{tableName}8_score, m_{tableName}9, m_{tableName}9_score, m_{tableName}_percentage, class_id, count) VALUES ({columns}, @percentage, @class_id, @count)";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                db.cmd.Parameters.AddWithValue("@percentage", percentage);
                db.cmd.Parameters.AddWithValue("@count", count);
                db.cmd.ExecuteNonQuery();
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

        //for exam and project
        public void rdos(string prefix, string tableName, int percentage)
        {
            string commandText = $"INSERT INTO modern_gradesbook.{prefix}_{tableName} ({prefix}_{tableName}, {prefix}_{tableName}_score, class_id, percentage) VALUES (-1, -1, @class_id, @percentage)";
            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                db.cmd.Parameters.AddWithValue("@percentage", percentage);
                db.cmd.ExecuteNonQuery();
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

        //Final Other task
        public void fOthers(string tableName, int count, int percentage)
        {
            int[] column = new int[18];
            for (int i = 0; i < column.Length; i += 2)
            {
                if (i < count * 2) //included -1
                {
                    column[i] = -1;
                    column[i + 1] = -1;
                }
                else //not included is 0
                {
                    column[i] = 0;
                    column[i + 1] = 0;
                }
            }
            string columns = string.Join(", ", column);
            string commandText = $"INSERT INTO modern_gradesbook.f_{tableName} (f_{tableName}1, f_{tableName}1_score, f_{tableName}2, f_{tableName}2_score, f_{tableName}3,  f_{tableName}3_score, f_{tableName}4, f_{tableName}4_score, f_{tableName}5, f_{tableName}5_score, f_{tableName}6, f_{tableName}6_score, f_{tableName}7, f_{tableName}7_score, f_{tableName}8, f_{tableName}8_score, f_{tableName}9, f_{tableName}9_score, f_{tableName}_percentage, class_id, count) VALUES ({columns}, @percentage, @class_id, @count)";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
                db.cmd.Parameters.AddWithValue("@percentage", percentage);
                db.cmd.Parameters.AddWithValue("@count", count);
                db.cmd.ExecuteNonQuery();
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
    }

}
