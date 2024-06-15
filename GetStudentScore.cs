using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradesBookApp
{
    public class GetStudentScore
    {
        databaseConnection db = new databaseConnection();
        //Project and Exam
        public void GetRecordRdo(string prefix, string tableName, int ID, Form current)
        {
            string commandText = $"SELECT {prefix}_{tableName}_score, {prefix}_{tableName} FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

            try
            {
                db.Connect();
                db.cmd.Connection = db.conn;
                db.cmd.CommandText = commandText;
                db.cmd.Parameters.Clear();
                db.cmd.Parameters.AddWithValue("@ID", ID);
                db.dta.SelectCommand = db.cmd;

                db.dta.Fill(Student_Module.dtScores);

                CreateLabelsFromDataTable(Student_Module.dtScores, current);

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

        public void CreateLabelsFromDataTable(DataTable table, Form current)
        {
            if (table.Rows.Count == 0)
            {
                return; // No data to display
            }

            DataRow row = table.Rows[0]; // Get the single row

            foreach (DataColumn column in table.Columns)
            {
                if(Student_Module.countLabel < 5)
                {
                    // Create a label for the column name
                    Label columnNameLabel = new Label();
                    columnNameLabel.Text = $"{column.ColumnName}";
                    columnNameLabel.Location = new Point(Student_Module.xLocation, Student_Module.yLocation);
                    columnNameLabel.AutoSize = true; // Adjust label size based on text
                    columnNameLabel.Font = new Font("Arial", 11, FontStyle.Italic);
                    columnNameLabel.ForeColor = Color.Black;
                    Student_Module.countLabel++;

                    // Create a label for the column value
                    Label columnValueLabel = new Label();
                    if (row[column] != DBNull.Value && Convert.ToInt32(row[column]) == -1)
                    {
                        columnValueLabel.Text = "-";
                        columnValueLabel.BackColor = Color.White;
                        columnValueLabel.ForeColor = Color.Red;
                        Student_Module.isComplete = false;
                    }
                    else
                    {
                        columnValueLabel.Text = $"{row[column]}";
                        columnValueLabel.BackColor = Color.White;
                        columnValueLabel.ForeColor = Color.Black;
                    }
                    columnValueLabel.Location = new Point(Student_Module.xLocation + 200, Student_Module.yLocation);
                    columnValueLabel.AutoSize = true; // Adjust label size based on text
                    columnValueLabel.Font = new Font("Arial", 11, FontStyle.Regular);

                    // Add the labels to the panel
                    current.Controls.Add(columnNameLabel);
                    current.Controls.Add(columnValueLabel);
                    Student_Module.xLocation += 250;
                    Student_Module.countLabel++;
                }
                else
                {
                    // Update yOffset for the next pair of labels
                    Student_Module.yLocation += 30; // Adjust space between label pairs
                    Student_Module.xLocation = 20;
                    Student_Module.countLabel = 1;
                    // Create a label for the column name
                    Label columnNameLabel = new Label();
                    columnNameLabel.Text = $"{column.ColumnName}";
                    columnNameLabel.Location = new Point(Student_Module.xLocation, Student_Module.yLocation);
                    columnNameLabel.AutoSize = true; // Adjust label size based on text
                    columnNameLabel.Font = new Font("Arial", 11, FontStyle.Italic);
                    columnNameLabel.ForeColor = Color.Black;
                    Student_Module.countLabel++;

                    // Create a label for the column value
                    Label columnValueLabel = new Label();
                    if (row[column] != DBNull.Value && Convert.ToInt32(row[column]) == -1)
                    {
                        columnValueLabel.Text = "-";
                        columnValueLabel.BackColor = Color.White;
                        columnValueLabel.ForeColor = Color.Red;
                        Student_Module.isComplete = false;
                    }
                    else
                    {
                        columnValueLabel.Text = $"{row[column]}";
                        columnValueLabel.BackColor = Color.White;
                        columnValueLabel.ForeColor = Color.Black;
                    }
                    columnValueLabel.Location = new Point(Student_Module.xLocation + 200, Student_Module.yLocation);
                    columnValueLabel.AutoSize = true; // Adjust label size based on text
                    columnValueLabel.Font = new Font("Arial", 11, FontStyle.Italic);

                    // Add the labels to the panel
                    current.Controls.Add(columnNameLabel);
                    current.Controls.Add(columnValueLabel);
                    Student_Module.xLocation += 250;
                    Student_Module.countLabel++;
                }
            }
        }

        //Other
        public void GetRecordsOther(string prefix, string tableName, int ID, int count, Form current)
        {
            string commandText = "";
            switch (count)
            {
                case 1:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 2:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current); ;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 3:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2, {prefix}_{tableName}3_score, {prefix}_{tableName}3 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 4:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2, {prefix}_{tableName}3_score, {prefix}_{tableName}3, {prefix}_{tableName}4_score, {prefix}_{tableName}4 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 5:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2, {prefix}_{tableName}3_score, {prefix}_{tableName}3, {prefix}_{tableName}4_score, {prefix}_{tableName}4, {prefix}_{tableName}5_score, {prefix}_{tableName}5 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 6:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2, {prefix}_{tableName}3_score, {prefix}_{tableName}3, {prefix}_{tableName}4_score, {prefix}_{tableName}4, {prefix}_{tableName}5_score, {prefix}_{tableName}5, {prefix}_{tableName}6_score, {prefix}_{tableName}6 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 7:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2, {prefix}_{tableName}3_score, {prefix}_{tableName}3, {prefix}_{tableName}4_score, {prefix}_{tableName}4, {prefix}_{tableName}5_score, {prefix}_{tableName}5, {prefix}_{tableName}6_score, {prefix}_{tableName}6, {prefix}_{tableName}7_score, {prefix}_{tableName}7 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
 
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 8:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2, {prefix}_{tableName}3_score, {prefix}_{tableName}3, {prefix}_{tableName}4_score, {prefix}_{tableName}4, {prefix}_{tableName}5_score, {prefix}_{tableName}5, {prefix}_{tableName}6_score, {prefix}_{tableName}6, {prefix}_{tableName}7_score, {prefix}_{tableName}7, {prefix}_{tableName}8_score, {prefix}_{tableName}8 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";
      
                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
                case 9:
                    commandText = $"SELECT {prefix}_{tableName}1_score, {prefix}_{tableName}1, {prefix}_{tableName}2_score, {prefix}_{tableName}2, {prefix}_{tableName}3_score, {prefix}_{tableName}3, {prefix}_{tableName}4_score, {prefix}_{tableName}4, {prefix}_{tableName}5_score, {prefix}_{tableName}5, {prefix}_{tableName}6_score, {prefix}_{tableName}6, {prefix}_{tableName}7_score, {prefix}_{tableName}7, {prefix}_{tableName}8_score, {prefix}_{tableName}8, {prefix}_{tableName}9_score, {prefix}_{tableName}9 FROM modern_gradesbook.{prefix}_{tableName} WHERE {prefix}_{tableName}_id = @ID";

                    try
                    {
                        db.Connect();
                        db.cmd.Connection = db.conn;
                        db.cmd.CommandText = commandText;
                        db.cmd.Parameters.Clear();
                        db.cmd.Parameters.AddWithValue("@ID", ID);
                        db.dta.SelectCommand = db.cmd;

                        db.dta.Fill(Student_Module.dtScores);

                        CreateLabelsFromDataTable(Student_Module.dtScores, current);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        db.Disconnect();
                    }
                    break;
            }
        }
    }
}
