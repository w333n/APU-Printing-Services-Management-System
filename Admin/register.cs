using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custoemr
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            // Bind text changed events for text boxes
            textBox2.TextChanged += TextBox_TextChanged;
            textBox1.TextChanged += TextBox_TextChanged;
            textBox5.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;
            textBox7.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;

            // Disable the button initially
            button1.Enabled = false;
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Check if all text boxes have content and update button state
            button1.Enabled = IsAllFieldsFilled();
        }

        // Check if all text boxes have input
        private bool IsAllFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                return false; // One or more text boxes are empty
            }
            return true; // All text boxes have input
        }

        // Validate phone number format using regular expression
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}|\d{3}-\d{4}-\d{4}$");
            return regex.IsMatch(phoneNumber);
        }

        // Check if the username already exists in the database
        private bool IsUsernameExists(string userid)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";

            string query = "SELECT COUNT(*) FROM UserProfile WHERE UserID = @UserID";
                       
            int count = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@UserID", userid);

                    connection.Open();

                    count = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Error checking username existence: " + ex.Message);
                }
            }

            return count > 0;// If count is greater than 0, username exists
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string UserID = textBox2.Text;
            string UserPassword = textBox1.Text;
            string UserRole = textBox5.Text;
            string LoginName = textBox3.Text;
            string UserName = textBox7.Text;
            string PhoneNumber = textBox4.Text;

            // Validate phone number format
            if (!IsValidPhoneNumber(PhoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number in the format '000-000-0000' or '000-0000-0000'.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Check if the username already exists
            if (IsUsernameExists(UserID))
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Insert data into the database
            InsertDataToDatabase(UserID, UserPassword, UserRole, LoginName, UserName, PhoneNumber);
            MessageBox.Show("Input Success.");
            
            // Clear text boxes after successful registration
            textBox2.Clear();
            textBox1.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox7.Clear();
            textBox4.Clear();
        }

        // Insert data into the database
        private void InsertDataToDatabase(string data1, string data2, string data3, string data4, string data5, string data6)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";

            string query = $"INSERT INTO UserProfile (UserID, UserPassword,UserRole,LoginName,UserName,PhoneNumber) VALUES (@Data1, @Data2,@Data3,@Data4,@Data5,@Data6)";
                        
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    
                    command.Parameters.AddWithValue("@Data1", data1);
                    command.Parameters.AddWithValue("@Data2", data2);
                    command.Parameters.AddWithValue("@Data3", data3);
                    command.Parameters.AddWithValue("@Data4", data4);
                    command.Parameters.AddWithValue("@Data5", data5);
                    command.Parameters.AddWithValue("@Data6", data6);

                    
                    connection.Open();

                    
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Error inserting data: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
