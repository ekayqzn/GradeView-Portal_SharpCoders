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

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                //db.cmd.CommandText = commandText;
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

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                //db.cmd.CommandText = commandText;
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

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                //db.cmd.CommandText = commandText;
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


            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                //db.cmd.CommandText = commandText;
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

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                //db.cmd.CommandText = commandText;
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

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                //db.cmd.CommandText = commandText;
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
