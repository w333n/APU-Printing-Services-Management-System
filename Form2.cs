using Custoemr.Manager;
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
    
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userID = textBoxuserID.Text;
            string userpassword = textBoxpassword.Text;
            string loginname = textBox1.Text;

            if (userID.Equals(""))
            {
                MessageBox.Show("Please enter your user ID.");
            }
            else if (userpassword.Equals(""))
            {
                MessageBox.Show("Please enter your password.");
            }
            else if (loginname.Equals(""))
            {
                MessageBox.Show("Please enter your login name.");
            }
            else
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30"; // 替换为你的数据库连接字符串
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM UserProfile WHERE UserID = @UserID AND UserPassword = @UserPassword AND LoginName = @LoginName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@UserPassword", userpassword);
                    command.Parameters.AddWithValue("@LoginName", loginname);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);

                    if (resultTable.Rows.Count == 1)
                    {
                        MessageBox.Show("Congratulations, you are logged in successfully.");
                        // Clear input fields after successful login
                        textBoxuserID.Clear();
                        textBoxpassword.Clear();
                        textBox1.Clear();
                        // Open the appropriate form based on user role
                        string userRole = resultTable.Rows[0]["UserRole"].ToString();
                        switch (userRole)
                        {
                            case "Admin":
                                Admin admin = new Admin();
                                new Admin().Show();
                                break;
                            case "Customer":
                                Form3 Form3 = new Form3(userID);
                                Form3.ID = userID;
                                new Form3(userID).Show();

                                break;
                            case "Manager":
                                sample sample = new sample(userID);
                                sample.ID = userID;
                                new sample(userID).Show();
                                
                                break;
                            case "Worker":
                                Worker Worker = new Worker(userID);
                                Worker.ID = userID;
                                new Worker(userID).Show();

                                break;
                            default:
                                MessageBox.Show("Unknown user role.");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials. Please provide correct userID and password.");
                    }
                }
            }
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxuserID.Clear();
            textBoxpassword.Clear();
            textBox1.Clear();
        }

        private void buttonExitLoginPage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxuserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxpassword_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
