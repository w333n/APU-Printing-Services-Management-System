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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        // This method is called when the Admin form is loaded.
        private void Admin_Load(object sender, EventArgs e)
        {
            // Load data into the ListBoxes.
            LoadListBoxData(listBox1, "Admin");
            LoadListBoxData(Customer, "Customer");
            LoadListBoxData(Manager, "Manager");
            LoadListBoxData(Worker, "Worker");
        }

        // This method is called when the selected index of the Customer ListBox changes.
        private void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager.ClearSelected();
            Worker.ClearSelected();
            listBox1.ClearSelected();
            CheckButtonEnabledStatus();
        }

        // Loads data into a given ListBox based on the user role.
        private void LoadListBoxData(ListBox listBox, string userRole)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True";
            string query = $"SELECT UserName FROM UserProfile WHERE UserRole = '{userRole}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                // Create a DataSet object.
                DataSet dataSet = new DataSet();

                try
                {
                    // Open the database connection.
                    connection.Open();

                    // Use the data adapter to fill the DataSet.
                    adapter.Fill(dataSet);

                    // Set the ListBox's data source to the DataSet's table.
                    listBox.DisplayMember = "UserName";
                    listBox.DataSource = dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    // Handle exceptions.
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void CheckButtonEnabledStatus()
        {
            // Checks if any item in any ListBox is selected and enables the button accordingly.
            bool anyListBoxItemSelected = listBox1.SelectedItem != null || Customer.SelectedItem != null || Manager.SelectedItem != null || Worker.SelectedItem != null;
            button5.Enabled = anyListBoxItemSelected;
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        // Gets the user ID from the selected item in the ListBox.
        string GetUserIDFromListBox(ListBox listBox)
        {
            string userID = "";
            if (listBox.SelectedItem != null)
            {

                DataRowView row = (DataRowView)listBox.SelectedItem;
                string userName = row["UserName"].ToString();
                Console.WriteLine(userName);
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True;Connect Timeout=30";
                string query = "SELECT UserID FROM UserProfile WHERE UserName = @UserName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);

                    try
                    {
                        connection.Open();
                        userID = command.ExecuteScalar()?.ToString();
                        Console.WriteLine(userID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving user ID: " + ex.Message);
                    }
                }
            }

            return userID;
        }


        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        // This method is called when the selected index of the ListBox1 changes.
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Manager.ClearSelected();
            Worker.ClearSelected();
            Customer.ClearSelected();
            CheckButtonEnabledStatus();
        }

        // Opens the register form.
        private void button1_Click_1(object sender, EventArgs e)
        {
            register register = new register();
            register.Show();
        }

        // Opens the update form with the selected user ID.
        private void button5_Click_1(object sender, EventArgs e)
        {
            string selectedUserID = "";

            if (listBox1.SelectedItem != null)
            {
                selectedUserID = GetUserIDFromListBox(listBox1);
            }
            else if (Customer.SelectedItem != null)
            {
                selectedUserID = GetUserIDFromListBox(Customer);
            }
            else if (Manager.SelectedItem != null)
            {
                selectedUserID = GetUserIDFromListBox(Manager);
            }
            else if (Worker.SelectedItem != null)
            {
                selectedUserID = GetUserIDFromListBox(Worker);
            }

            // Same GetUserIDFromListBox method as defined earlier.


            if (!string.IsNullOrEmpty(selectedUserID))
            {
                update updateForm = new update(selectedUserID);
                updateForm.Show();
            }
            else
            {
                MessageBox.Show("No user selected.");
            }
        }

        // Opens the report form.
        private void button4_Click_1(object sender, EventArgs e)
        {
            report fourthform = new report();
            fourthform.ShowDialog();
        }

        // Confirms exit and closes the form if confirmed.
        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to EXIT？", "Exit Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 如果用户点击了 Yes，关闭窗口
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Reloads data into all ListBoxes.
        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadListBoxData(listBox1, "Admin");
            LoadListBoxData(Customer, "Customer");
            LoadListBoxData(Manager, "Manager");
            LoadListBoxData(Worker, "Worker");
        }
        // This method is called when the selected index of the Manager ListBox changes.
        private void Manager_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            Worker.ClearSelected();
            Customer.ClearSelected();
            CheckButtonEnabledStatus();
        }

        // This method is called when the selected index of the Worker ListBox changes.
        private void Worker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager.ClearSelected();
            listBox1.ClearSelected();
            Customer.ClearSelected();
            CheckButtonEnabledStatus();
        }
    }
}

