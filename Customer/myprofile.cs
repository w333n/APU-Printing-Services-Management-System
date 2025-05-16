using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Custoemr
{
    public partial class myprofile : UserControl
    {
        public string ID { get; set; }
        public myprofile(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            textBox2.TextChanged += TextBox_TextChanged;
            textBox1.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;

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
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                return false; 
            }
            return true; 
        }

        private bool IsInputValid()
        {
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Invalid Input！");
                return false;
            }
            return true;

        }


        private void myprofile_Load(object sender, EventArgs e)
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




        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
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
                                // Check if user made changes
                                string originalName = reader["UserName"].ToString();
                                string originalPassword = reader["UserPassword"].ToString();
                                string originalPhoneNo = reader["PhoneNumber"].ToString();
                                string originalLoginName = reader["LoginName"].ToString();

                                if (name == originalName && password == originalPassword && phoneno == originalPhoneNo &&  loginname== originalLoginName)
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

                    // If user made changes, update data
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}