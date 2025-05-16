using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Custoemr
{
    public partial class UpdateJob : Form
    {
        public string requestID {  get; set; }
        public UpdateJob(string requestID)
        {
            InitializeComponent();
            this.requestID = requestID;
            comboBoxRequestStatus.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            // Disable the button initially
            btnSave.Enabled = false;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if all text boxes and ComboBox have content and update button state
            btnSave.Enabled = comboBoxRequestStatus.SelectedItem != null;
        }
        // UpdateJob_Load() method handles the form load event
        private void UpdateJob_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox1.ReadOnly = true;
            txtDateTime.ReadOnly = true;
            checkBox1.Enabled = false;
            txtQuantityOrdered.ReadOnly = true;
            txtServiceNo.ReadOnly = true;
            txtCustomerID.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox3.Text = requestID;
            LoadData();
            Console.WriteLine("RequestID from parameter: " + requestID);

        }

        // LoadData() method loads data from the database into the form controls
        private void LoadData()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT * FROM CustomerRequest WHERE RequestID = @RequestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@RequestID", requestID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtCustomerID.Text = reader.GetString(reader.GetOrdinal("UserID"));
                        txtServiceNo.Text = reader.GetString(reader.GetOrdinal("ServiceType"));
                        txtQuantityOrdered.Text = reader.GetInt32(reader.GetOrdinal("Quantity")).ToString();
                        checkBox1.Checked = reader.GetBoolean(reader.GetOrdinal("UrgentRequest"));
                        txtDateTime.Text = reader.GetDateTime(reader.GetOrdinal("RequestDateTime")).ToString();
                        textBox1.Text = reader.GetDateTime(reader.GetOrdinal("DateAssignWork")).ToString();
                        textBox2.Text = reader.GetDateTime(reader.GetOrdinal("DueDate")).ToString();
                        textBox4.Text = reader.GetString(reader.GetOrdinal("WorkStatus"));

                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void txtRequestID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtServiceNo_TextChanged(object sender, EventArgs e)
        {

        }
        // IsOverDue() method checks if the current date is past the due date
        private bool IsOverDue()
        {
            string dueDateString = textBox2.Text;
            Console.WriteLine(dueDateString);
            DateTime dueDate;
            if (!DateTime.TryParse(dueDateString, out dueDate))
            {
                MessageBox.Show("Due date is not in a valid format.");
                return false; // Return false if unable to parse the date
            }

            // Check if the current date is past the due date
            return DateTime.Today > dueDate.Date; // Use .Date to ensure only date part is compared
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxRequestStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a work status.");
                return; // Show message and return if work status is not selected
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "UPDATE CustomerRequest SET WorkStatus = @WorkStatus WHERE RequestID = @RequestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    string workStatus = comboBoxRequestStatus.SelectedItem.ToString();
                    // Check if overdue
                    if (IsOverDue())
                    {
                        workStatus += " Overdue"; // Append "Overdue" string if overdue
                        Console.WriteLine(workStatus);
                    }

                    command.Parameters.AddWithValue("@WorkStatus", workStatus);
                    command.Parameters.AddWithValue("@RequestID", requestID);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Work status updated successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update work status.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating work status: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
