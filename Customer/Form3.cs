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
    public partial class Form3 : Form
    {

        public string ID { get; set; }
        public Form3(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        

        private void panelcontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelcontainer_Paint_1(object sender, PaintEventArgs e)
        {

        }

        // Method to add a user control to the panel
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelcontainer.Controls.Clear();
            panelcontainer.Controls.Add(userControl);
            userControl.BringToFront();


        }

        private void buttonMyProfile_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonPreviousRequest_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonOrderUser_Click(object sender, EventArgs e)
        {
            
        }

        private void panelside_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOrderCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            myprofile myprofile = new myprofile(ID);
            myprofile.ID = ID;
            addUserControl(myprofile);
        }

        private void buttonMyProfile_Click_1(object sender, EventArgs e)
        {
            
            myprofile myprofile = new myprofile(ID);
            myprofile.ID = ID;
            addUserControl(myprofile);
        }

        private void buttonPreviousRequest_Click_1(object sender, EventArgs e)
        {
            request request = new request(ID);
            request.ID=ID;
            addUserControl(request);
        }

        private void buttonOrderUser_Click_1(object sender, EventArgs e)
        {
            order order = new order(ID);
            order.ID = ID;
            addUserControl(order);
        }

        private void btnOrderCheckOut_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to EXIT？", "Exit Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
