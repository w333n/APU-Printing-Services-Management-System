namespace Custoemr
{
    partial class Form2
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
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonExitLoginPage = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelAPUPrinting = new System.Windows.Forms.Label();
            this.textBoxpassword = new System.Windows.Forms.TextBox();
            this.textBoxuserID = new System.Windows.Forms.TextBox();
            this.labelpassword = new System.Windows.Forms.Label();
            this.labeluserID = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(405, 448);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(162, 69);
            this.buttonReset.TabIndex = 22;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonExitLoginPage
            // 
            this.buttonExitLoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitLoginPage.Location = new System.Drawing.Point(651, 448);
            this.buttonExitLoginPage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExitLoginPage.Name = "buttonExitLoginPage";
            this.buttonExitLoginPage.Size = new System.Drawing.Size(162, 69);
            this.buttonExitLoginPage.TabIndex = 21;
            this.buttonExitLoginPage.Text = "Exit";
            this.buttonExitLoginPage.UseVisualStyleBackColor = true;
            this.buttonExitLoginPage.Click += new System.EventHandler(this.buttonExitLoginPage_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(159, 448);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(162, 69);
            this.buttonLogin.TabIndex = 20;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelAPUPrinting
            // 
            this.labelAPUPrinting.AutoSize = true;
            this.labelAPUPrinting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAPUPrinting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPUPrinting.Location = new System.Drawing.Point(89, 59);
            this.labelAPUPrinting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAPUPrinting.Name = "labelAPUPrinting";
            this.labelAPUPrinting.Size = new System.Drawing.Size(788, 44);
            this.labelAPUPrinting.TabIndex = 19;
            this.labelAPUPrinting.Text = "APU Printing Services Management System";
            // 
            // textBoxpassword
            // 
            this.textBoxpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxpassword.Location = new System.Drawing.Point(446, 337);
            this.textBoxpassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxpassword.Name = "textBoxpassword";
            this.textBoxpassword.Size = new System.Drawing.Size(318, 44);
            this.textBoxpassword.TabIndex = 18;
            this.textBoxpassword.TextChanged += new System.EventHandler(this.textBoxpassword_TextChanged);
            this.textBoxpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxpassword_KeyDown);
            // 
            // textBoxuserID
            // 
            this.textBoxuserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxuserID.Location = new System.Drawing.Point(446, 181);
            this.textBoxuserID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxuserID.Name = "textBoxuserID";
            this.textBoxuserID.Size = new System.Drawing.Size(318, 44);
            this.textBoxuserID.TabIndex = 17;
            this.textBoxuserID.TextChanged += new System.EventHandler(this.textBoxuserID_TextChanged);
            // 
            // labelpassword
            // 
            this.labelpassword.AutoSize = true;
            this.labelpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpassword.Location = new System.Drawing.Point(139, 261);
            this.labelpassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelpassword.Name = "labelpassword";
            this.labelpassword.Size = new System.Drawing.Size(240, 42);
            this.labelpassword.TabIndex = 16;
            this.labelpassword.Text = "Login Name:";
            // 
            // labeluserID
            // 
            this.labeluserID.AutoSize = true;
            this.labeluserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeluserID.Location = new System.Drawing.Point(229, 183);
            this.labeluserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeluserID.Name = "labeluserID";
            this.labeluserID.Size = new System.Drawing.Size(150, 42);
            this.labeluserID.TabIndex = 15;
            this.labeluserID.Text = "UserID:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(446, 261);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(318, 44);
            this.textBox1.TabIndex = 24;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 337);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 42);
            this.label1.TabIndex = 23;
            this.label1.Text = "Password:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 698);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonExitLoginPage);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelAPUPrinting);
            this.Controls.Add(this.textBoxpassword);
            this.Controls.Add(this.textBoxuserID);
            this.Controls.Add(this.labelpassword);
            this.Controls.Add(this.labeluserID);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonExitLoginPage;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelAPUPrinting;
        private System.Windows.Forms.TextBox textBoxpassword;
        private System.Windows.Forms.TextBox textBoxuserID;
        private System.Windows.Forms.Label labelpassword;
        private System.Windows.Forms.Label labeluserID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}