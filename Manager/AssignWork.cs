using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Custoemr.Manager
{
    public partial class AssignWork : Form
    {
        public string requestID;
        public AssignWork(string requestID)
        {
            InitializeComponent();
            this.requestID = requestID;
            textBoxDateAssignwork.TextChanged += TextBox_TextChanged;
            comboBoxWorkerID.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // Disable the assign button initially
            btnAssign.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Check if all text boxes have content and update button state
            btnAssign.Enabled = IsAllFieldsFilled() && comboBoxWorkerID.SelectedItem != null;
        }

        // Check if all required fields are filled
        private bool IsAllFieldsFilled()
        {

            if (string.IsNullOrWhiteSpace(textBoxDateAssignwork.Text))
            {
                return false; // If any text box is empty
            }
            return true; // All text boxes have input
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if all text boxes and ComboBox have content and update button state
            btnAssign.Enabled = IsAllFieldsFilled() && comboBoxWorkerID.SelectedItem != null;
        }

        private void AssignWork_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadUrgent();
            // Set certain text boxes to read-only
            textRequestID.ReadOnly = true;
            textBoxWokerName.ReadOnly = true;
            textBoxDuedate.ReadOnly = true;
            checkBox1.Enabled = false;
            // Set the request ID text box
            textRequestID.Text = requestID;
        }

        // Load urgent status for the current request
        private void LoadUrgent()
        {            
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT UrgentRequest FROM CustomerRequest WHERE RequestID = @RequestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@RequestID", requestID);
                    connection.Open();
                    bool isUrgent = Convert.ToBoolean(command.ExecuteScalar());
                    checkBox1.Checked = isUrgent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        // Load worker IDs into ComboBox
        private void LoadComboBox()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT UserID FROM UserProfile WHERE UserRole = 'Worker' ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        comboBoxWorkerID.Items.Clear();
                        while (reader.Read())
                        {
                            string userid = reader["UserID"].ToString();
                            comboBoxWorkerID.Items.Add(userid);
                        }
                    }
                }
            }
        }

        private void comboBoxWorkerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUserID = comboBoxWorkerID.SelectedItem.ToString();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT UserName FROM UserProfile WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", selectedUserID);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        textBoxWokerName.Text = result.ToString();
                    }
                    else
                    {
                        textBoxWokerName.Clear();// Clear the text box if no username is found
                    }
                }
            }
        }

        // Validate the date format
        private bool IsValidDateFormat(string date)
        {
            DateTime tempDate;
            return DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out tempDate);
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            string assigneddate = textBoxDateAssignwork.Text;
            string duedate = textBoxDuedate.Text;
            string workerid = comboBoxWorkerID.SelectedItem.ToString();

            if (!IsValidDateFormat(assigneddate) || !IsValidDateFormat(duedate))
            {
                MessageBox.Show("Please enter valid dates in the format YYYY-MM-DD.");
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "UPDATE CustomerRequest SET WorkStatus = 'Assigned', DateAssignWork = @assigneddate, DueDate = @duedate, WorkerID = @WorkerID WHERE RequestID = @RequestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@assigneddate", assigneddate);
                    command.Parameters.AddWithValue("@DueDate", duedate);
                    command.Parameters.AddWithValue("@WorkerID", workerid);
                    command.Parameters.AddWithValue("@RequestID", requestID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Work assigned successfully and updated in the database.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the database.");
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

                
        private void textBoxDuedate_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDueDate();
        }

        private void textBoxDateAssignwork_TextChanged(object sender, EventArgs e)
        {
            UpdateDueDate();
        }

        // Update the due date based on assigned date and urgency
        private void UpdateDueDate()
        {
            string assignedDate = textBoxDateAssignwork.Text;
            if (!string.IsNullOrEmpty(assignedDate))
            {
                if (IsValidDateFormat(assignedDate))
                {
                    DateTime assignDate = DateTime.ParseExact(assignedDate, "yyyy-MM-dd", null);
                    DateTime dueDate;
                    if (checkBox1.Checked) 
                    {
                        dueDate = assignDate.AddDays(3);
                    }
                    else 
                    {
                        dueDate = assignDate.AddDays(7);
                    }
                    textBoxDuedate.Text = dueDate.ToString("yyyy-MM-dd");
                }
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
