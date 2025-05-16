using Custoemr.Customer;
using System;
using System.Collections;
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

namespace Custoemr
{
    public partial class Worker : Form
    {
        public string ID { get; set; }
        public Worker(string ID)
        {
            InitializeComponent();
            this.ID = ID; 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Worker_Load(object sender, EventArgs e)
        {
            
            LoadJob();
            txtWorkerID.Text = ID;
            txtWorkerID.ReadOnly = true;
        }

        // Check if any ListBox has a selected item and enable/disable the update button accordingly
        private void CheckButtonEnabledStatus()
        {
            bool anyListBoxItemSelected = listBox1.SelectedItem != null || listBox2.SelectedItem != null ;
            btnUpdate.Enabled = anyListBoxItemSelected;
        }

        // Load job data into ListBoxes
        private void LoadJob()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\song wen\\OneDrive\\文件\\oop.mdf\";Integrated Security=True";

            string queryPending = "Select RequestID From [CustomerRequest] WHERE RequestDateTime < @Today AND DueDate > @Today AND WorkStatus != 'Completed Overdue' AND WorkStatus != 'Completed' AND WorkerID = @WorkerID";
            string queryOverdue = "Select RequestID From [CustomerRequest] WHERE DueDate < @Today AND WorkStatus != 'Completed Overdue' AND WorkStatus != 'Completed' AND WorkerID = @WorkerID";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSetPending = new DataSet();
                DataSet dataSetOverdue = new DataSet();

                DateTime today = DateTime.Now;

                Console.WriteLine(today);
                try
                {
                    // Load pending jobs
                    connection.Open();
                    using (SqlDataAdapter adapterPending = new SqlDataAdapter(queryPending, connection))
                    {
                        adapterPending.SelectCommand.Parameters.AddWithValue("@Today", today);
                        adapterPending.SelectCommand.Parameters.AddWithValue("@WorkerID", ID);
                        adapterPending.Fill(dataSetPending);
                        listBox1.DisplayMember = "RequestID";
                        listBox1.DataSource = dataSetPending.Tables[0];
                        Console.WriteLine("Pending Rows Count: " + dataSetPending.Tables[0].Rows.Count);
                    }
                    // Load overdue jobs
                    using (SqlDataAdapter adapterOverdue = new SqlDataAdapter(queryOverdue, connection))
                    {
                        adapterOverdue.SelectCommand.Parameters.AddWithValue("@Today", today);
                        adapterOverdue.SelectCommand.Parameters.AddWithValue("@WorkerID", ID);
                        adapterOverdue.Fill(dataSetOverdue);
                        listBox2.DisplayMember = "RequestID";
                        listBox2.DataSource = dataSetOverdue.Tables[0];
                        Console.WriteLine("Pending Rows Count: " + dataSetOverdue.Tables[0].Rows.Count);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }


        private void txtWorkerID_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string requestID = "";
            // Get the selected request ID from either listBox1 or listBox2
            if (listBox1.SelectedItem != null)
            {
                DataRowView row = (DataRowView)listBox1.SelectedItem;
                requestID = row["RequestID"].ToString();
            }
            else if (listBox2.SelectedItem != null)
            {
                DataRowView row = (DataRowView)listBox2.SelectedItem;
                requestID = row["RequestID"].ToString();
            }
            // Open the UpdateJob form with the selected request ID
            UpdateJob updateForm = new UpdateJob(requestID);
            updateForm.Show();
        }




        private void btnCheckJobHistory_Click(object sender, EventArgs e)
        {
            JobHistory job = new JobHistory(ID);
            job.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to EXIT？", "Exit Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            OurProfile ourprofile = new OurProfile(ID);
            ourprofile.ID = ID;
            ourprofile.Show();
        }

        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.ClearSelected();// Clear selection in listBox2
            CheckButtonEnabledStatus();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();// Clear selection in listBox1
            CheckButtonEnabledStatus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Event handler for reload jobs button click
        private void button1_Click(object sender, EventArgs e)
        {
            LoadJob();
        }
    }
}
