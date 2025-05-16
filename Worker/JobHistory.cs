using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custoemr
{
    public partial class JobHistory : Form
    {
        public string ID { get; set; }
        private string selectedColumn;
        private string searchText;
        public JobHistory(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void JobHistory_Load(object sender, EventArgs e)
        {
            LoadJ();
            
        }
        // LoadJ() method loads the job history data into the DataGridView
        private void LoadJ()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30"; // 替换为你的数据库连接字符串
            string query = "SELECT * FROM CustomerRequest WHERE WorkerID = @WorkerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@WorkerID", ID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable customerRequestTable = new DataTable();
                adapter.Fill(customerRequestTable);
                dataGridView1.DataSource = customerRequestTable;
            }
        }
        // FilterDataGridView() method filters the DataGridView based on selected column and search text
        private void FilterDataGridView(string selectedColumn, string searchText)
        {
            // Check if search text is not empty
            if (!string.IsNullOrEmpty(searchText))
            {

                if (string.IsNullOrEmpty(selectedColumn))
                {
                    MessageBox.Show("Please select a column before searching.", "Column Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30"; // 替换为你的数据库连接字符串

                string query = $"SELECT * FROM [CustomerRequest] WHERE WorkerID = @WorkerID AND {selectedColumn} LIKE @searchText";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@WorkerID", ID);
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
                // If search text is empty, restore the original data source
                LoadJ();
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJ();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // comboBox1_SelectedIndexChanged() method handles the selection change event of the combo box
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedColumn = comboBox1.SelectedItem?.ToString();
            FilterDataGridView(selectedColumn, searchText);
        }
        // textBox1_TextChanged() method handles the text change event of the text box
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchText = textBox1.Text;
            FilterDataGridView(selectedColumn, searchText);
        }
    }
}
