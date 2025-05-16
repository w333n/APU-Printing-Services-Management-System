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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Custoemr.Customer
{
    public partial class OurProfile : Form
    {
        public string ID { get; set; }
        public OurProfile(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            // Attach event handlers for text changed events
            textBox2.TextChanged += TextBox_TextChanged;
            textBox1.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;
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
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                return false; // One or more text boxes are empty
            }
            return true; // All text boxes have input
        }

        private void OurProfile_Load(object sender, EventArgs e)
        {
            if (!IsInputValid()) return;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT * FROM UserProfile WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox2.Text = reader["UserName"].ToString();
                        textBox1.Text = reader["UserPassword"].ToString();
                        textBox4.Text = reader["PhoneNumber"].ToString();
                        textBox3.Text = reader["LoginName"].ToString();
                    }
                }
            }
        }

        // IsInputValid() method checks if the input ID is valid
        private bool IsInputValid()
        {
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Invalid Input！");
                return false;
            }
            return true;

        }

        // IsValidPhoneNumber() method validates the phone number format using regular expression
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // 使用正则表达式验证电话号码格式
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}|\d{3}-\d{4}-\d{4}$");
            return regex.IsMatch(phoneNumber);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
            string name = textBox2.Text;
            string password = textBox1.Text;
            string phoneno = textBox4.Text;
            string loginname = textBox3.Text;
            

            if (!IsValidPhoneNumber(phoneno))
            {
                MessageBox.Show("Please enter a valid phone number in the format '000-000-0000' or '000-0000-0000'.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsAllFieldsFilled())
            {
                MessageBox.Show("Please fill in all fields before registering.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (!string.IsNullOrEmpty(ID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM UserProfile WHERE UserID = @UserID";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@UserID", ID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check if the user has made any changes
                                string originalName = reader["UserName"].ToString();
                                string originalPassword = reader["UserPassword"].ToString();
                                string originalPhoneNo = reader["PhoneNumber"].ToString();
                                string originalLoginName = reader["LoginName"].ToString();

                                if (name == originalName && password == originalPassword && phoneno == originalPhoneNo && loginname == originalLoginName)
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

                    // If the user has made changes, update the profile
                    string updateQuery = "UPDATE UserProfile SET LoginName = @LoginName, UserName = @UserName, UserPassword = @UserPassword, PhoneNumber= @PhoneNumber WHERE UserID = @UserID";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@LoginName", loginname);
                    updateCommand.Parameters.AddWithValue("@UserName", name);
                    updateCommand.Parameters.AddWithValue("@UserPassword", password);
                    updateCommand.Parameters.AddWithValue("@PhoneNumber", phoneno);
                    updateCommand.Parameters.AddWithValue("@UserID", ID);



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
            else
            {
                MessageBox.Show("Invalid Input！");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
