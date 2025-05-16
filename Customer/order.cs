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
    public partial class order : UserControl
    {
        public string ID { get; set; }
        public order(string ID)
        {
            InitializeComponent();
            this.ID = ID;

        }

        
        private bool ListBoxItemsChanged()
        {
            // Check if any item is present in the list box and update button state
            return listBox1.Items.Count > 1;
        }

        private Dictionary<string, Services> services = new Dictionary<string, Services>()
        {
            { "Printing A4 - Black and White - A4", new Services("Printing A4 - Black and White", "A4", 0.80, 0.10, 100) },
            { "Printing A4 - Color - A4", new Services("Printing A4 - Color", "A4", 2.50, 0.10, 100) },
            { "Binding - Comb Binding - ", new Services("Binding - Comb Binding", null, 5.50, 0, 0) },
            { "Binding - Thick Cover - ", new Services("Binding - Thick Cover", null, 9.30, 0, 0) },
            { "Printing - Poster - A0", new Services("Printing - Poster", "A0", 6.00, 0.10, 100) },
            { "Printing - Poster - A1", new Services("Printing - Poster", "A1", 6.00, 0.10, 100) },
            { "Printing - Poster - A2", new Services("Printing - Poster", "A2", 3.00, 0.10, 100) },
            { "Printing - Poster - A3", new Services("Printing - Poster", "A3", 3.00, 0.10, 100) }
        };

        private void order_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                LoadCustomerRequests(ID);
            }
            
            LoadServiceType();
            LoadSize();
            LoadListBoxData();
            CalculateTotalCost();

            dataGridView1.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            // Update button status based on list box items
            button2.Enabled = ListBoxItemsChanged();

        }
        // Method to update button status based on list box selection
        private void UpdateButtonStatus()
        {
            if (listBox1.SelectedIndex == 0)
            {
                buttonComfirmUserRequest.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                buttonComfirmUserRequest.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }
        // Method to load customer requests from the database
        private void LoadCustomerRequests(string ID)
        {

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30"; // 替换为你的数据库连接字符串
            string query = "SELECT * FROM CustomerRequest WHERE UserID = @UserID AND PaymentStatus = 'Pending'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable customerRequestTable = new DataTable();
                adapter.Fill(customerRequestTable);
                dataGridView1.DataSource = customerRequestTable;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelServiceNumber_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void __Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void comboBoxServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSize();
        }

        private void LoadSize()
        {
            DataRowView selectedRow = (DataRowView)comboBoxServiceType.SelectedItem;
            string selectedServiceType = selectedRow["ServiceType"].ToString();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT Size FROM ServiceProvided WHERE ServiceType = @ServiceType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceType", selectedServiceType);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable sizeTable = new DataTable();
                adapter.Fill(sizeTable);

                if (sizeTable.Rows.Count > 0)
                {
                    comboBoxSize.DataSource = sizeTable;
                    comboBoxSize.DisplayMember = "Size";
                    comboBoxSize.ValueMember = "Size"; // Set ValueMember to ensure DBNull.Value is properly handled
                }
                else
                {
                    // No sizes found for the selected service type
                    // Set the ComboBox to display an empty string
                    comboBoxSize.DataSource = null;
                    comboBoxSize.Text = ""; // Set the ComboBox text to an empty string
                }
            }
        }



        private void LoadServiceType()
        {

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT DISTINCT ServiceType FROM ServiceProvided";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable serviceTable = new DataTable();
                adapter.Fill(serviceTable);

                if (serviceTable.Rows.Count > 0)
                {
                    comboBoxServiceType.DataSource = serviceTable;
                    comboBoxServiceType.DisplayMember = "ServiceType";
                }
                else
                {
                    comboBoxServiceType.DataSource = null; // No service types found
                }
            }
        }      

        private void buttonComfirmUserRequest_Click(object sender, EventArgs e)
        {    
            string selectedServiceKey = $"{comboBoxServiceType.Text} - {comboBoxSize.Text}";
            Console.WriteLine($"Selected Service Key: {selectedServiceKey}");
            Console.WriteLine($"Service Type: {comboBoxServiceType.Text}");
            Console.WriteLine($"Size: {comboBoxSize.Text}");

            int quantity;
            bool isUrgent = checkBox2.Checked;
                    
            // Validate quantity
            if (!int.TryParse(textBox3.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please input a valid quantity.");
                return;
            }
                       

            // Output all keys in services dictionary
            Console.WriteLine("All keys in services dictionary:");
            foreach (var key in services.Keys)
            {
                Console.WriteLine(key);
            }

            // Get the service from dictionary
            if (services.TryGetValue(selectedServiceKey, out Services selectedService))
            {
                // Calculate total cost
                double Cost = selectedService.CalculatePrice(quantity, isUrgent);
                // Check if there is a discount
                if (quantity >= selectedService.MinQuantity && selectedService.Discount > 0)
                {
                    // Update label text
                    label5.Text = "Satisfied";
                }
                else
                {
                    // Update label text
                    label5.Text = "Not Satisfied";
                }

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO CustomerRequest (RequestID,UserID, ServiceType, Size, Quantity, UrgentRequest, Cost, PaymentStatus, WorkStatus, RequestDateTime) VALUES (@RequestID, @UserID, @ServiceType, @Size, @Quantity, @UrgentRequest, @Cost, @PaymentStatus, @WorkStatus, @RequestDateTime)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        int nextRequestID = GetNextRequestID(connection);
                        command.Parameters.AddWithValue("@RequestID", nextRequestID);
                        command.Parameters.AddWithValue("@UserID", ID);
                        command.Parameters.AddWithValue("@ServiceType", comboBoxServiceType.Text);
                        command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@UrgentRequest", checkBox2.Checked);
                        command.Parameters.AddWithValue("@Cost", Cost);
                        command.Parameters.AddWithValue("@WorkStatus", "New");
                        command.Parameters.AddWithValue("@PaymentStatus", "Pending");
                        command.Parameters.AddWithValue("@RequestDateTime", DateTime.Now);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add order.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid service type and size.");
            }
            LoadCustomerRequests(ID);
            LoadListBoxData();
            CalculateTotalCost();
        }
        // Method to get the next available request ID from the database
        private int GetNextRequestID(SqlConnection connection)
        {
            string query = "SELECT MAX(RequestID) FROM CustomerRequest";
            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();

            if (result != DBNull.Value && result != null)
            {
                // Convert the result to an integer and increment by 1 to get the next available ID
                return Convert.ToInt32(result) + 1;
            }
            else
            {
                // If no records are found in the table, start the ID sequence from 1
                return 1; 
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }  

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadCustomerRequests(ID);
            LoadListBoxData();
            CalculateTotalCost();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Are you sure you want to proceed with the payment?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Payment successful!", "Payment Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdatePaymentStatus("Paid");
                LoadCustomerRequests(ID);
                LoadListBoxData();
                CalculateTotalCost();
            }
        }

        private void UpdatePaymentStatus(string status)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string updateQuery = "UPDATE CustomerRequest SET PaymentStatus = @Status WHERE PaymentStatus = 'Pending' AND UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@UserID", ID); 
                command.ExecuteNonQuery();
            }
        }

        private int previousSelectedIndex = -1;

        private void LoadListBoxData()
        {
            DataTable customerRequestTable = new DataTable();
            customerRequestTable.Columns.Add("RequestID", typeof(string));
            customerRequestTable.Rows.Add("Default as not edit");

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT RequestID FROM CustomerRequest WHERE UserID = @UserID AND PaymentStatus = 'Pending'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(customerRequestTable);
            }

            listBox1.DataSource = customerRequestTable;
            listBox1.DisplayMember = "RequestID";
            // Set the selected index of the ListBox based on the previous selected index
            if (previousSelectedIndex >= 0 && previousSelectedIndex < listBox1.Items.Count)
            {
                listBox1.SelectedIndex = previousSelectedIndex;
            }
            else
            {
                listBox1.SelectedIndex = 0;
            }

            button2.Enabled = ListBoxItemsChanged();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            previousSelectedIndex = listBox1.SelectedIndex;

            UpdateButtonStatus();

            if (listBox1.SelectedIndex == 0)
            {
                ClearTextBoxes();
                return;
            }

            DataRowView selectedRow = (DataRowView)listBox1.SelectedItem;
            string selectedRequestID = selectedRow["RequestID"].ToString();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT * FROM CustomerRequest WHERE RequestID = @RequestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (selectedRequestID == "Default as not edit")
                {
                    ClearTextBoxes();
                    return;
                }

                command.Parameters.AddWithValue("@RequestID", selectedRequestID);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int quantity = Convert.ToInt32(reader["Quantity"]);
                    Services selectedService = GetSelectedService(reader["ServiceType"].ToString(), reader["Size"].ToString());

                    UpdateStatusLabel(quantity, selectedService);

                    comboBoxServiceType.Text = reader["ServiceType"].ToString();
                    comboBoxSize.Text = reader["Size"].ToString();
                    textBox3.Text = reader["Quantity"].ToString();

                    if (reader["UrgentRequest"] != DBNull.Value)
                    {
                        bool isUrgent = (bool)reader["UrgentRequest"];
                        checkBox2.Checked = isUrgent;
                    }

                }
            }
        }

        private Services GetSelectedService(string serviceType, string size)
        {
            string key = $"{serviceType} - {size}";
            if (services.ContainsKey(key))
            {
                return services[key];
            }
            else
            {
                return null;
            }
        }

        private void UpdateStatusLabel(int quantity, Services selectedService)
        {
            if (quantity >= selectedService.MinQuantity && selectedService.Discount > 0)
            {
                label5.Text = "Satisfied";
            }
            else
            {
                label5.Text = "Not Satisfied";
            }
        }

        private void ClearTextBoxes()
        {
            comboBoxServiceType.Text = "Binding - Comb Binding";
            comboBoxSize.Text = "";
            textBox3.Text = "";
            checkBox2.Checked=false;
            label5.Text = "Not Satisfied";


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)listBox1.SelectedItem;
            string selectedRequestID = selectedRow["RequestID"].ToString();

            string serviceType = comboBoxServiceType.Text;
            string size = comboBoxSize.Text;
            int quantity;
            bool isUrgent = checkBox2.Checked;

            if (!int.TryParse(textBox3.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please input a valid quantity.");
                return;
            }

            Services selectedService = GetSelectedService(serviceType, size);

            double cost = selectedService.CalculatePrice(quantity, isUrgent);

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30;";
            string query = "UPDATE CustomerRequest SET ServiceType = @ServiceType, Size = @Size, Quantity = @Quantity, UrgentRequest = @UrgentRequest, Cost = @Cost WHERE RequestID = @RequestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceType", serviceType);
                command.Parameters.AddWithValue("@Size", size);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@UrgentRequest", isUrgent);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@RequestID", selectedRequestID);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Order updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update order.");
                }
            }
            LoadCustomerRequests(ID);
            LoadListBoxData();
            CalculateTotalCost();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)listBox1.SelectedItem;
            string selectedRequestID = selectedRow["RequestID"].ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30;";
                string query = "DELETE FROM CustomerRequest WHERE RequestID = @RequestID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RequestID", selectedRequestID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete order.");
                    }
                }

            }
            LoadCustomerRequests(ID);
            LoadListBoxData();
            CalculateTotalCost();
        }

        // Method to calculate the total cost of pending customer requests
        private void CalculateTotalCost()
        {
            // Initialize variables to store total costs
            double totalCost = 0;
            double totalDiscountCost = 0; 
            double totalUrgentCost = 0; 

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT * FROM CustomerRequest WHERE UserID = @UserID AND PaymentStatus = 'Pending'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);
                SqlDataReader reader = command.ExecuteReader();
                // Loop through each row in the result set
                while (reader.Read())
                {
                    // Retrieve values from the current row
                    string serviceType = reader["ServiceType"].ToString();
                    string size = reader["Size"].ToString();
                    int quantity = Convert.ToInt32(reader["Quantity"]);
                    bool isUrgent = Convert.ToBoolean(reader["UrgentRequest"]);
                    // Check if the selected service exists in the services dictionary
                    if (services.TryGetValue($"{serviceType} - {size}", out Services selectedService))
                    {
                        // Calculate the cost for the current request
                        double cost = selectedService.FeesPerUnit * quantity;
                        totalCost += cost;

                        // Calculate discount cost if applicable
                        double discountCost = 0;
                        if (selectedService.Discount.HasValue && quantity >= selectedService.MinQuantity)
                        {
                            discountCost = cost * selectedService.Discount.Value;
                        }

                        // Calculate urgent cost if the request is urgent
                        double urgentCost = 0;
                        if (isUrgent)
                        {
                            urgentCost = (cost-discountCost) * 0.3;
                        }
                        // Update total discount and urgent costs
                        totalUrgentCost += urgentCost;
                        totalDiscountCost += discountCost;
                        
                    }
                }
            }
            // Update TextBox controls with calculated costs
            textBox1.Text = totalCost.ToString("0.00");
            textBox2.Text = totalDiscountCost.ToString("0.00");
            textBox4.Text = totalUrgentCost.ToString("0.00");
            textBox5.Text = (totalCost + totalUrgentCost-totalDiscountCost).ToString("0.00"); 
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
