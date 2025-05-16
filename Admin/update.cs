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
using System.Xml.Linq;

namespace Custoemr
{
    public partial class update : Form
    {
        private string selectedUserID;
        public update(string selectedUserID)
        {
            InitializeComponent();
            this.selectedUserID = selectedUserID;
            textBox2.TextChanged += TextBox_TextChanged;
            textBox1.TextChanged += TextBox_TextChanged;
            textBox5.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;
            textBox7.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;

            // Disable the button initially
            button1.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Check if all text boxes have content and update button state
            button1.Enabled = IsAllFieldsFilled();
        }

        private bool IsAllFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                return false; /// One or more text boxes are empty
            }
            return true; // All text boxes have input
        }

        private void update_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            LoadSelectedItemData(selectedUserID);
        }

        // Load data of the selected user
        private void LoadSelectedItemData(string id)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT * FROM UserProfile WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@UserID", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox2.Text = reader["UserID"].ToString();
                        textBox1.Text = reader["UserPassword"].ToString();
                        textBox5.Text = reader["UserRole"].ToString();
                        textBox3.Text = reader["LoginName"].ToString();
                        textBox7.Text = reader["UserName"].ToString();
                        textBox4.Text = reader["PhoneNumber"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Validate phone number format using regular expression
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}|\d{3}-\d{4}-\d{4}$");
            return regex.IsMatch(phoneNumber);
        }

        // Event handler for save button click (button1_1)
        private void button1_Click_1(object sender, EventArgs e)
        {
            string userpassword = textBox1.Text;
            string userrole = textBox5.Text;
            string loginname = textBox3.Text;
            string phonenumber = textBox4.Text;
            string username = textBox7.Text;

            // Validate phone number format
            if (!IsValidPhoneNumber(phonenumber))
            {
                MessageBox.Show("Please enter a valid phone number in the format '000-000-0000' or '000-0000-0000'.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM UserProfile WHERE UserID = @UserID";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@UserID", selectedUserID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if user has made any changes
                            string originalName = reader["UserName"].ToString();
                            string originalPassword = reader["UserPassword"].ToString();
                            string originalPhoneNo = reader["PhoneNumber"].ToString();
                            string originalLoginName = reader["LoginName"].ToString();
                            string originalUserRole = reader["UserRole"].ToString();

                            if (username == originalName && userpassword == originalPassword && phonenumber == originalPhoneNo && loginname == originalLoginName && userrole == originalUserRole)
                            {
                                MessageBox.Show("No changes made. Invalid input.");
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }

                // If user has made changes, update the profile
                string updateQuery = "UPDATE UserProfile SET LoginName = @LoginName, UserName = @UserName, UserPassword = @UserPassword, PhoneNumber= @PhoneNumber WHERE UserID = @UserID";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@LoginName", loginname);
                updateCommand.Parameters.AddWithValue("@UserName", username);
                updateCommand.Parameters.AddWithValue("@UserPassword", userpassword);
                updateCommand.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                updateCommand.Parameters.AddWithValue("@UserID", selectedUserID);



                try
                {
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Updated Success！");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
            
    }
}
