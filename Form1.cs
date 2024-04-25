using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Org.BouncyCastle.Tls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MySqlX.XDevAPI.Common;
using System.Data;
namespace Calculator


{
    public partial class Form1 : Form
    {
        private string currentNumber = "";
        private double result = 0;
        private string operation = "";
        private string connectionString = "Data Source=DESKTOP-NC61DCE\\SQLEXPRESS;Initial Catalog=Pslhub;Integrated Security=True;Encrypt=False;";

        public Form1()
        {
            InitializeComponent();
        }
        private void SaveOperation(double firstNumber, double secondNumber, double result, string table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO {table} (first_num, second_num, result) VALUES (@firstNum, @secondNum, @results)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstNum", firstNumber);
                command.Parameters.AddWithValue("@secondNum", secondNumber);
                command.Parameters.AddWithValue("@results", result);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving operation: " + ex.Message);
                }
            }
        }
        private void SaveOperation2(double firstNumber, double result, string table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO {table} (first_num, result) VALUES (@firstNum, @results)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstNum", firstNumber);
                command.Parameters.AddWithValue("@results", result);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving operation: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateDisplay()
        {
            textBox1.Text = currentNumber;
        }

        private void AppendNumber(string number)
        {
            currentNumber += number;
            UpdateDisplay();
        }

        private void ClearLastDigit()
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
            }
            else
            {
                result = 0;
                operation = "";
            }
            UpdateDisplay();
        }

        private void Clear()
        {
            currentNumber = "";
            result = 0;
            operation = "";
            UpdateDisplay();
        }

        private void PerformOperation(string op)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                double number = 0;
                string tableName = "";
                if (op != "x^2" || op != "Squareroot")
                {
                    number = double.Parse(currentNumber);
                }
                double firstNumber = result;
                double secondNumber = number;

                switch (operation)
                {
                    case "+":
                        tableName = "Addition";
                        result = firstNumber + secondNumber;
                        SaveOperation(firstNumber, secondNumber, result, tableName);
                        break;
                    case "-":
                        tableName = "Subtraction";
                        result = firstNumber - secondNumber;
                        SaveOperation(firstNumber, secondNumber, result, tableName);
                        break;
                    case "*":
                        tableName = "Multiplication";
                        result = firstNumber * secondNumber;
                        SaveOperation(firstNumber, secondNumber, result, tableName);
                        break;
                    case "/":
                        tableName = "Division";
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero.");
                            return;
                        }
                        SaveOperation(firstNumber, secondNumber, result, tableName);
                        break;
                    case "x^2":
                        tableName = "Square";
                        result = firstNumber * firstNumber;
                        SaveOperation2(firstNumber, result, tableName);
                        break;
                    case "Squareroot":
                        tableName = "Squareroot";
                        if (firstNumber >= 0)
                        {
                            result = Math.Sqrt(firstNumber);
                            SaveOperation2(firstNumber, result, tableName);
                        }
                        else
                        {
                            MessageBox.Show("Cannot calculate square root of a negative number.");
                            return;
                        }
                        break;
                    default:
                        result = number;
                        break;
                }

                currentNumber = "";
                operation = op;
            }
        }


        private void btnequal_Click(object sender, EventArgs e)
        {
            PerformOperation(operation); // Perform the current operation
            string resultStr = result.ToString();
            currentNumber = resultStr; // Set the current number to the result
            UpdateDisplay(); // Update the display with the result
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            AppendNumber("0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppendNumber("7");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AppendNumber("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AppendNumber("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AppendNumber("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AppendNumber("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AppendNumber("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AppendNumber("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AppendNumber("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AppendNumber("9");
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            PerformOperation("+");
        }

        private void btnminus_Click(object sender, EventArgs e)
        {

            PerformOperation("-");
        }

        private void btnmultiply_Click(object sender, EventArgs e)
        {

            PerformOperation("*");
        }

        private void btndivide_Click(object sender, EventArgs e)
        {
            PerformOperation("/");
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            AppendNumber(".");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AppendNumber("0");
        }

        private void btn9_Click_1(object sender, EventArgs e)
        {
            AppendNumber("9");
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            AppendNumber("4");
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            AppendNumber("5");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AppendNumber("1");
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            PerformOperation("/");
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearLastDigit();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            PerformOperation("-");
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            PerformOperation("*");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformOperation("x^2");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PerformOperation("Squareroot");
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
        string tableName = Microsoft.VisualBasic.Interaction.InputBox("Enter the table name:", "View Operation History", "");

            if (!string.IsNullOrEmpty(tableName))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"SELECT * FROM {tableName}";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        // Display the data in a new form or a message box
                        string history = "";
                        if (tableName == "Square" || tableName == "Squareroot")
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                history += $"ID: {row["id"]}, First Number: {row["first_num"]},  Result: {row["result"]}\n";
                            }
                        }
                        else
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                history += $"ID: {row["id"]}, First Number: {row["first_num"]}, Second Number: {row["second_num"]}, Result: {row["result"]}\n";
                            }
                        }
                        MessageBox.Show(history, $"Operation History for {tableName}");
                    }
                    else
                    {
                        MessageBox.Show($"No operations found in the '{tableName}' table.", "Operation History");
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string tableName = Microsoft.VisualBasic.Interaction.InputBox("Enter the table name from which you want to delete the entry:", "Delete Operation History", "");
            int id = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the ID of the entry you want to delete:", "Delete Operation History", ""));

            if (!string.IsNullOrEmpty(tableName) && id > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Entry with ID {id} in the '{tableName}' table has been deleted.", "Operation History");
                        }
                        else
                        {
                            MessageBox.Show($"No entry with ID {id} found in the '{tableName}' table.", "Operation History");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting entry from '{tableName}' table: {ex.Message}", "Error");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tableName = Microsoft.VisualBasic.Interaction.InputBox("Enter the table name where you want to update the entry:", "Update Operation History", "");
            int id = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the ID of the entry you want to update:", "Update Operation History", ""));

            if (!string.IsNullOrEmpty(tableName) && id > 0)
            {
                double newFirstNum = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the new first number:", "Update Operation History", ""));
                double newSecondNum = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the new second number:", "Update Operation History", ""));
                double newResult = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the new result:", "Update Operation History", ""));

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command;
                    if (tableName == "Square" || tableName == "Squareroot")
                    {
                        string query = $"UPDATE {tableName} SET first_num = @firstNum, result = @result WHERE id = @id";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@firstNum", newFirstNum);
                        command.Parameters.AddWithValue("@result", newResult);
                        command.Parameters.AddWithValue("@id", id);
                    }
                    else
                    {
                        string query = $"UPDATE {tableName} SET first_num = @firstNum, second_num = @secondNum, result = @result WHERE id = @id";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@firstNum", newFirstNum);
                        command.Parameters.AddWithValue("@secondNum", newSecondNum);
                        command.Parameters.AddWithValue("@result", newResult);
                        command.Parameters.AddWithValue("@id", id);
                    }

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Entry with ID {id} in the '{tableName}' table has been updated.", "Operation History");
                        }
                        else
                        {
                            MessageBox.Show($"No entry with ID {id} found in the '{tableName}' table.", "Operation History");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error updating entry in '{tableName}' table: {ex.Message}", "Error");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Error");
                    }
                }
            }
        }
    }
}