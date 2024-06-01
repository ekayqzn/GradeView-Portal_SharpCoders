using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class GradebookQuery
    {
        databaseConnection db = new databaseConnection();

        //midterm attendance
        public void mAttendance(string tableName, int count, int percentage)
        {
            int[] attendanceColumns = new int[9];
            for (int i = 0; i < attendanceColumns.Length; i++)
            {
                if(i < count)
                {
                    attendanceColumns[i] = -1;
                }
                else
                {
                    attendanceColumns[i] = 0;
                }
            }
            string columns = string.Join(", ", attendanceColumns);

            string commandText = $"INSERT INTO modern_gradesbook.m_{tableName} (m_{tableName}1, m_{tableName}2, m_{tableName}3, m_{tableName}4, m_{tableName}5, m_{tableName}6, m_{tableName}7, m_{tableName}8, m_{tableName}9, m_{tableName}_percentage, class_id, count) VALUES ({columns}, @percentage, @class_id, @count)";

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

        //Other midterm tasks
        public void mOthers(string tableName, int count, int percentage)
        {
            int[] column = new int[18];
            for (int i = 0; i < column.Length; i+=2)
            {
                if (i < count*2) //included -1
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

        //midterm radiobutton options
        public void mRdo(string tableName)
        {
            string commandText = $"INSERT INTO modern_gradesbook.m_{tableName} (m_{tableName}, m_{tableName}_score, class_id, count) VALUES (-1, -1, @class_id, 1)";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
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

        //final Attendance
        public void fAttendance(string tableName, int count, int percentage)
        {
            int[] attendanceColumns = new int[9];
            for (int i = 0; i < attendanceColumns.Length; i++)
            {
                if (i < count)
                {
                    attendanceColumns[i] = -1;
                }
                else
                {
                    attendanceColumns[i] = 0;
                }
            }
            string columns = string.Join(", ", attendanceColumns);

            string commandText = $"INSERT INTO modern_gradesbook.f_{tableName} (f_{tableName}1, f_{tableName}2, f_{tableName}3, f_{tableName}4, f_{tableName}5, f_{tableName}6, f_{tableName}7, f_{tableName}8, f_{tableName}9, f_{tableName}_percentage, class_id, count) VALUES ({columns}, @percentage, @class_id, @count)";

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

        //final radiobutton options
        public void fRdo(string tableName)
        {
            string commandText = $"INSERT INTO modern_gradesbook.f_{tableName} (f_{tableName}, f_{tableName}_score, class_id, count) VALUES (-1, -1, @class_id, 1)";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@class_id", Add_Subject.classID);
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
