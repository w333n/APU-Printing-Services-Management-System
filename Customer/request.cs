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
    public partial class request : UserControl
    {
        
        public string ID { get; set; }
        public request(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void request_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                LoadCustomerRequests(ID);
            }
            dataGridView2.ReadOnly = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void LoadCustomerRequests(string ID)
        {
            
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30"; // 替换为你的数据库连接字符串
            string query = "SELECT * FROM CustomerRequest WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable customerRequestTable = new DataTable();
                adapter.Fill(customerRequestTable);
                dataGridView2.DataSource = customerRequestTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadCustomerRequests(ID);
        }
    }
}
