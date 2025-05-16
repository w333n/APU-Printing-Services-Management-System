using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Custoemr
{
    public partial class report : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\SONG WEN\\ONEDRIVE\\文件\\OOP.MDF\";Integrated Security=True";

        public report()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        private void report_Load(object sender, EventArgs e)
        {
            
        }
        // Load data into DataGridView from the specified view
        private void LoadDataIntoDataGridView(string viewName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query;
                if (ViewContainsMonthColumn(viewName))
                {
                    query = $"SELECT *, (CASE [Month] " +
                        "WHEN 'January' THEN '01' " +
                        "WHEN 'February' THEN '02' " +
                        "WHEN 'March' THEN '03' " +
                        "WHEN 'April' THEN '04' " +
                        "WHEN 'May' THEN '05' " +
                        "WHEN 'June' THEN '06' " +
                        "WHEN 'July' THEN '07' " +
                        "WHEN 'August' THEN '08' " +
                        "WHEN 'September' THEN '09' " +
                        "WHEN 'October' THEN '10' " +
                        "WHEN 'November' THEN '11' " +
                        "WHEN 'December' THEN '12' END) AS MonthNumber " +
                        $"FROM {viewName} ORDER BY [Year], MonthNumber";
                }
                else
                {
                    query = $"SELECT * FROM {viewName} ORDER BY [Year]";
                }

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        // Check if the specified view contains a 'Month' column
        private bool ViewContainsMonthColumn(string viewName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{viewName}' AND COLUMN_NAME = 'Month'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                bool hasMonthColumn = reader.HasRows;
                reader.Close();
                return hasMonthColumn;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();
            switch (selectedOption)
            {
                case "Customer Report":
                    LoadDataIntoDataGridView("CustomerReport");
                    break;
                case "Service Report":
                    LoadDataIntoDataGridView("ServiceReport");
                    break;
                case "Yearly Report":
                    LoadDataIntoDataGridView("YearlyReport");
                    break;
                default:
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        // Filter DataGridView based on search text
        private void FilterDataGridView(string selectedOption, string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                string query;
                if (ViewContainsMonthColumn(selectedOption))
                {
                    query = $"SELECT *, (CASE [Month] " +
                        "WHEN 'January' THEN '01' " +
                        "WHEN 'February' THEN '02' " +
                        "WHEN 'March' THEN '03' " +
                        "WHEN 'April' THEN '04' " +
                        "WHEN 'May' THEN '05' " +
                        "WHEN 'June' THEN '06' " +
                        "WHEN 'July' THEN '07' " +
                        "WHEN 'August' THEN '08' " +
                        "WHEN 'September' THEN '09' " +
                        "WHEN 'October' THEN '10' " +
                        "WHEN 'November' THEN '11' " +
                        "WHEN 'December' THEN '12' END) AS MonthNumber " +
                        $"FROM {selectedOption} WHERE ";
                }
                else
                {
                    query = $"SELECT * FROM {selectedOption} WHERE ";
                }

                string[] columnNames = GetColumnNames(selectedOption);
                List<string> conditions = new List<string>();
                foreach (string columnName in columnNames)
                {
                    conditions.Add($"[{columnName}] LIKE @searchText");
                }
                string whereClause = string.Join(" OR ", conditions);

                query += whereClause;
                if (ViewContainsMonthColumn(selectedOption))
                {
                    query += " ORDER BY [Year], MonthNumber";
                }
                else
                {
                    query += " ORDER BY [Year]";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                LoadDataIntoDataGridView(selectedOption);
            }
        }
        // Get column names for the specified view
        private string[] GetColumnNames(string viewName)
        {
            List<string> columnNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{viewName}'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    columnNames.Add(reader["COLUMN_NAME"].ToString());
                }
                reader.Close();
            }
            return columnNames.ToArray();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        //Generate report
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                    }
                    int rowCount = 2;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int columnCount = 1;
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            worksheet.Cells[rowCount, columnCount].Value = row[column];
                            columnCount++;
                        }
                        rowCount++;
                    }
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string fileName = $"{comboBox1.SelectedItem}_{timestamp}.xlsx";
                    string filePath = Path.Combine("C:\\Users\\song wen\\Downloads", fileName);
                    FileInfo file = new FileInfo(filePath);
                    package.SaveAs(file);
                }
                MessageBox.Show("Generated Successfully!");
            }
            else
            {
                MessageBox.Show("DataGridView does not have a data source.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //Show the content of selected report
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedOption = comboBox1.SelectedItem.ToString();
                string searchText = textBox1.Text.Trim();
                switch (selectedOption)
                {
                    case "Customer Report":
                        FilterDataGridView("CustomerReport", searchText);
                        break;
                    case "Service Report":
                        FilterDataGridView("ServiceReport", searchText);
                        break;
                    case "Yearly Report":
                        FilterDataGridView("YearlyReport", searchText);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
