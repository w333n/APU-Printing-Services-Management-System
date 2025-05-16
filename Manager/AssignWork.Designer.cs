namespace Custoemr.Manager
{
    partial class AssignWork
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
            this.textBoxWokerName = new System.Windows.Forms.TextBox();
            this.textRequestID = new System.Windows.Forms.TextBox();
            this.RequestID = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxDateAssignwork = new System.Windows.Forms.TextBox();
            this.comboBoxWorkerID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WokerName = new System.Windows.Forms.Label();
            this.Choose_a_woker_to_assign_work = new System.Windows.Forms.Label();
            this.textBoxDuedate = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxWokerName
            // 
            this.textBoxWokerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWokerName.Location = new System.Drawing.Point(398, 270);
            this.textBoxWokerName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWokerName.Name = "textBoxWokerName";
            this.textBoxWokerName.Size = new System.Drawing.Size(415, 45);
            this.textBoxWokerName.TabIndex = 39;
            // 
            // textRequestID
            // 
            this.textRequestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRequestID.Location = new System.Drawing.Point(398, 100);
            this.textRequestID.Margin = new System.Windows.Forms.Padding(4);
            this.textRequestID.Name = "textRequestID";
            this.textRequestID.Size = new System.Drawing.Size(415, 45);
            this.textRequestID.TabIndex = 38;
            // 
            // RequestID
            // 
            this.RequestID.AutoSize = true;
            this.RequestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestID.Location = new System.Drawing.Point(161, 100);
            this.RequestID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RequestID.Name = "RequestID";
            this.RequestID.Size = new System.Drawing.Size(198, 39);
            this.RequestID.TabIndex = 37;
            this.RequestID.Text = "Request ID";
            // 
            // btnAssign
            // 
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(217, 615);
            this.btnAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(182, 80);
            this.btnAssign.TabIndex = 36;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(501, 615);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(190, 80);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBoxDateAssignwork
            // 
            this.textBoxDateAssignwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDateAssignwork.Location = new System.Drawing.Point(398, 353);
            this.textBoxDateAssignwork.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDateAssignwork.Name = "textBoxDateAssignwork";
            this.textBoxDateAssignwork.Size = new System.Drawing.Size(415, 45);
            this.textBoxDateAssignwork.TabIndex = 34;
            this.textBoxDateAssignwork.TextChanged += new System.EventHandler(this.textBoxDateAssignwork_TextChanged);
            // 
            // comboBoxWorkerID
            // 
            this.comboBoxWorkerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWorkerID.FormattingEnabled = true;
            this.comboBoxWorkerID.Location = new System.Drawing.Point(398, 184);
            this.comboBoxWorkerID.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxWorkerID.Name = "comboBoxWorkerID";
            this.comboBoxWorkerID.Size = new System.Drawing.Size(415, 46);
            this.comboBoxWorkerID.TabIndex = 32;
            this.comboBoxWorkerID.SelectedIndexChanged += new System.EventHandler(this.comboBoxWorkerID_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 184);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 39);
            this.label5.TabIndex = 31;
            this.label5.Text = "Worker ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 353);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 39);
            this.label4.TabIndex = 30;
            this.label4.Text = "Date Assign Work ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(178, 519);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 39);
            this.label3.TabIndex = 29;
            this.label3.Text = "Due Date ";
            // 
            // WokerName
            // 
            this.WokerName.AutoSize = true;
            this.WokerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WokerName.Location = new System.Drawing.Point(121, 270);
            this.WokerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WokerName.Name = "WokerName";
            this.WokerName.Size = new System.Drawing.Size(237, 39);
            this.WokerName.TabIndex = 28;
            this.WokerName.Text = "Worker Name";
            // 
            // Choose_a_woker_to_assign_work
            // 
            this.Choose_a_woker_to_assign_work.AutoSize = true;
            this.Choose_a_woker_to_assign_work.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choose_a_woker_to_assign_work.Location = new System.Drawing.Point(138, 9);
            this.Choose_a_woker_to_assign_work.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Choose_a_woker_to_assign_work.Name = "Choose_a_woker_to_assign_work";
            this.Choose_a_woker_to_assign_work.Size = new System.Drawing.Size(625, 48);
            this.Choose_a_woker_to_assign_work.TabIndex = 27;
            this.Choose_a_woker_to_assign_work.Text = "Choose a woker to assign work";
            // 
            // textBoxDuedate
            // 
            this.textBoxDuedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDuedate.Location = new System.Drawing.Point(398, 519);
            this.textBoxDuedate.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDuedate.Name = "textBoxDuedate";
            this.textBoxDuedate.Size = new System.Drawing.Size(415, 45);
            this.textBoxDuedate.TabIndex = 33;
            this.textBoxDuedate.TextChanged += new System.EventHandler(this.textBoxDuedate_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(99, 432);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(286, 42);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.Text = "Urgent Request";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AssignWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 732);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxWokerName);
            this.Controls.Add(this.textRequestID);
            this.Controls.Add(this.RequestID);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxDateAssignwork);
            this.Controls.Add(this.textBoxDuedate);
            this.Controls.Add(this.comboBoxWorkerID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WokerName);
            this.Controls.Add(this.Choose_a_woker_to_assign_work);
            this.Name = "AssignWork";
            this.Text = "AssignWork";
            this.Load += new System.EventHandler(this.AssignWork_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWokerName;
        private System.Windows.Forms.TextBox textRequestID;
        private System.Windows.Forms.Label RequestID;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBoxDateAssignwork;
        private System.Windows.Forms.ComboBox comboBoxWorkerID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label WokerName;
        private System.Windows.Forms.Label Choose_a_woker_to_assign_work;
        private System.Windows.Forms.TextBox textBoxDuedate;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}