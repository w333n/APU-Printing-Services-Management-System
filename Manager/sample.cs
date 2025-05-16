using Custoemr.Customer;
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

namespace Custoemr.Manager
{
    public partial class sample : Form
    {
        public string ID { get; set; }
        private string selectedColumn;
        private string searchText;
        public sample(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;

        }
                
        private void sample_Load(object sender, EventArgs e)
        {
            LoadNotAssignedWork();
            LoadAssignedWork();
           
        }

        // Filter DataGridView based on selected column and search text
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

                string query = $"SELECT * FROM [CustomerRequest] WHERE {selectedColumn} LIKE @searchText";

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

                        dataGridView2.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {// If search text is empty, reload original data
                LoadAssignedWork();
            }
        }

        // Load not assigned work into DataGridView1
        private void LoadNotAssignedWork()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30"; // 替换为你的数据库连接字符串
            string query = "SELECT RequestID, UrgentRequest, WorkStatus, RequestDateTime FROM CustomerRequest WHERE PaymentStatus = 'Paid' AND WorkStatus = 'New' ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable customerRequestTable = new DataTable();
                adapter.Fill(customerRequestTable);
                dataGridView1.DataSource = customerRequestTable;
            }

        }

        // Load assigned work into DataGridView2
        private void LoadAssignedWork()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30"; // 替换为你的数据库连接字符串
            string query = "SELECT RequestID, WorkerID, UrgentRequest, WorkStatus, RequestDateTime, DateAssignWork, DueDate FROM CustomerRequest WHERE PaymentStatus = 'Paid' AND WorkStatus != 'New' ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable customerRequestTable = new DataTable();
                adapter.Fill(customerRequestTable);
                dataGridView2.DataSource = customerRequestTable;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadNotAssignedWork();
            LoadAssignedWork();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Assign work button click event handler
        private void btnAssignWork_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells["RequestID"].Value != null)
                {
                    string requestID = selectedRow.Cells["RequestID"].Value.ToString();
                    AssignWork assignWork = new AssignWork(requestID);
                    assignWork.Show();
                }
                else
                {
                    MessageBox.Show("The RequestID cell is empty.");
                }
            }
            else
            {
                MessageBox.Show("Please select an entire row.");
            }
        }


        // Update profile button click event handler
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            OurProfile ourprofile = new OurProfile(ID);
            ourprofile.ID = ID;
            ourprofile.Show();
        }

        // Exit button click event handler
        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to EXIT？", "Exit Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 如果用户点击了 Yes，关闭窗口
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void columntxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void columntxt_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedColumn = comboBox1.SelectedItem?.ToString();

            FilterDataGridView(selectedColumn, searchText);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            searchText = textBox1.Text;

            FilterDataGridView(selectedColumn, searchText);
        }
    }
}
