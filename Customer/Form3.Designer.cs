namespace Custoemr
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelcontainer = new System.Windows.Forms.Panel();
            this.buttonPreviousRequest = new System.Windows.Forms.Button();
            this.buttonOrderUser = new System.Windows.Forms.Button();
            this.panelside = new System.Windows.Forms.Panel();
            this.btnOrderCheckOut = new System.Windows.Forms.Button();
            this.buttonMyProfile = new System.Windows.Forms.Button();
            this.panelside.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelcontainer
            // 
            this.panelcontainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcontainer.Location = new System.Drawing.Point(215, 0);
            this.panelcontainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelcontainer.Name = "panelcontainer";
            this.panelcontainer.Size = new System.Drawing.Size(1245, 793);
            this.panelcontainer.TabIndex = 82;
            this.panelcontainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelcontainer_Paint);
            // 
            // buttonPreviousRequest
            // 
            this.buttonPreviousRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreviousRequest.Location = new System.Drawing.Point(11, 217);
            this.buttonPreviousRequest.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPreviousRequest.Name = "buttonPreviousRequest";
            this.buttonPreviousRequest.Size = new System.Drawing.Size(186, 91);
            this.buttonPreviousRequest.TabIndex = 76;
            this.buttonPreviousRequest.Text = "Previous Request ";
            this.buttonPreviousRequest.UseVisualStyleBackColor = true;
            this.buttonPreviousRequest.Click += new System.EventHandler(this.buttonPreviousRequest_Click_1);
            // 
            // buttonOrderUser
            // 
            this.buttonOrderUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOrderUser.Location = new System.Drawing.Point(11, 369);
            this.buttonOrderUser.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOrderUser.Name = "buttonOrderUser";
            this.buttonOrderUser.Size = new System.Drawing.Size(186, 91);
            this.buttonOrderUser.TabIndex = 77;
            this.buttonOrderUser.Text = "Order ";
            this.buttonOrderUser.UseVisualStyleBackColor = true;
            this.buttonOrderUser.Click += new System.EventHandler(this.buttonOrderUser_Click_1);
            // 
            // panelside
            // 
            this.panelside.BackColor = System.Drawing.SystemColors.Control;
            this.panelside.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelside.Controls.Add(this.btnOrderCheckOut);
            this.panelside.Controls.Add(this.buttonMyProfile);
            this.panelside.Controls.Add(this.buttonPreviousRequest);
            this.panelside.Controls.Add(this.buttonOrderUser);
            this.panelside.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelside.Location = new System.Drawing.Point(0, 0);
            this.panelside.Margin = new System.Windows.Forms.Padding(4);
            this.panelside.Name = "panelside";
            this.panelside.Size = new System.Drawing.Size(215, 793);
            this.panelside.TabIndex = 83;
            this.panelside.Paint += new System.Windows.Forms.PaintEventHandler(this.panelside_Paint);
            // 
            // btnOrderCheckOut
            // 
            this.btnOrderCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderCheckOut.Location = new System.Drawing.Point(11, 512);
            this.btnOrderCheckOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrderCheckOut.Name = "btnOrderCheckOut";
            this.btnOrderCheckOut.Size = new System.Drawing.Size(186, 91);
            this.btnOrderCheckOut.TabIndex = 0;
            this.btnOrderCheckOut.Text = "Exit";
            this.btnOrderCheckOut.UseVisualStyleBackColor = true;
            this.btnOrderCheckOut.Click += new System.EventHandler(this.btnOrderCheckOut_Click_1);
            // 
            // buttonMyProfile
            // 
            this.buttonMyProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMyProfile.Location = new System.Drawing.Point(11, 62);
            this.buttonMyProfile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMyProfile.Name = "buttonMyProfile";
            this.buttonMyProfile.Size = new System.Drawing.Size(186, 91);
            this.buttonMyProfile.TabIndex = 75;
            this.buttonMyProfile.Text = "My Profile";
            this.buttonMyProfile.UseVisualStyleBackColor = true;
            this.buttonMyProfile.Click += new System.EventHandler(this.buttonMyProfile_Click_1);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 793);
            this.Controls.Add(this.panelcontainer);
            this.Controls.Add(this.panelside);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panelside.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelcontainer;
        private System.Windows.Forms.Button buttonPreviousRequest;
        private System.Windows.Forms.Button buttonOrderUser;
        private System.Windows.Forms.Panel panelside;
        private System.Windows.Forms.Button btnOrderCheckOut;
        private System.Windows.Forms.Button buttonMyProfile;
    }
}