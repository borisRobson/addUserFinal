namespace Test
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.imgboxCam = new Emgu.CV.UI.ImageBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtRecognised = new System.Windows.Forms.TextBox();
            this.btnSaveRec = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPanelSN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnSendRec = new System.Windows.Forms.Button();
            this.btnUpdateRec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxCam)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgboxCam
            // 
            this.imgboxCam.Location = new System.Drawing.Point(13, 13);
            this.imgboxCam.Name = "imgboxCam";
            this.imgboxCam.Size = new System.Drawing.Size(320, 240);
            this.imgboxCam.TabIndex = 2;
            this.imgboxCam.TabStop = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(13, 51);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(123, 23);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(54, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(82, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(78, 61);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(0, 13);
            this.lblValue.TabIndex = 7;
            // 
            // txtRecognised
            // 
            this.txtRecognised.Location = new System.Drawing.Point(54, 22);
            this.txtRecognised.Name = "txtRecognised";
            this.txtRecognised.ReadOnly = true;
            this.txtRecognised.Size = new System.Drawing.Size(90, 20);
            this.txtRecognised.TabIndex = 8;
            // 
            // btnSaveRec
            // 
            this.btnSaveRec.Location = new System.Drawing.Point(6, 19);
            this.btnSaveRec.Name = "btnSaveRec";
            this.btnSaveRec.Size = new System.Drawing.Size(112, 23);
            this.btnSaveRec.TabIndex = 9;
            this.btnSaveRec.Text = "Save Recogniser";
            this.btnSaveRec.UseVisualStyleBackColor = true;
            this.btnSaveRec.Click += new System.EventHandler(this.btnSaveRec_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddUser);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 87);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New User";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRecognised);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblValue);
            this.groupBox2.Location = new System.Drawing.Point(183, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 87);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detecetd User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confidence:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdateRec);
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtPanelSN);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.chkDefault);
            this.groupBox3.Controls.Add(this.btnSendRec);
            this.groupBox3.Controls.Add(this.btnSaveRec);
            this.groupBox3.Location = new System.Drawing.Point(374, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 345);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recogniser Mangement";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 119);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(251, 213);
            this.txtLog.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Event Log:";
            // 
            // txtPanelSN
            // 
            this.txtPanelSN.Location = new System.Drawing.Point(67, 70);
            this.txtPanelSN.Name = "txtPanelSN";
            this.txtPanelSN.Size = new System.Drawing.Size(61, 20);
            this.txtPanelSN.TabIndex = 13;
            this.txtPanelSN.Text = "4085241";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Panel S.N";
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Checked = true;
            this.chkDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefault.Location = new System.Drawing.Point(7, 49);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(90, 17);
            this.chkDefault.TabIndex = 11;
            this.chkDefault.Text = "Default Panel";
            this.chkDefault.UseVisualStyleBackColor = true;
            this.chkDefault.CheckedChanged += new System.EventHandler(this.chkDefault_CheckedChanged);
            // 
            // btnSendRec
            // 
            this.btnSendRec.Location = new System.Drawing.Point(165, 18);
            this.btnSendRec.Name = "btnSendRec";
            this.btnSendRec.Size = new System.Drawing.Size(98, 23);
            this.btnSendRec.TabIndex = 10;
            this.btnSendRec.Text = "Send Recogniser";
            this.btnSendRec.UseVisualStyleBackColor = true;
            this.btnSendRec.Click += new System.EventHandler(this.btnSendRec_Click);
            // 
            // btnUpdateRec
            // 
            this.btnUpdateRec.Location = new System.Drawing.Point(155, 49);
            this.btnUpdateRec.Name = "btnUpdateRec";
            this.btnUpdateRec.Size = new System.Drawing.Size(108, 23);
            this.btnUpdateRec.TabIndex = 16;
            this.btnUpdateRec.Text = "Update Recogniser";
            this.btnUpdateRec.UseVisualStyleBackColor = true;
            this.btnUpdateRec.Click += new System.EventHandler(this.btnUpdateRec_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 376);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imgboxCam);
            this.MaximumSize = new System.Drawing.Size(697, 414);
            this.MinimumSize = new System.Drawing.Size(697, 414);
            this.Name = "Form1";
            this.Text = "Facial Recognition : Add User";
            ((System.ComponentModel.ISupportInitialize)(this.imgboxCam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgboxCam;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtRecognised;
        private System.Windows.Forms.Button btnSaveRec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.Button btnSendRec;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPanelSN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateRec;
    }
}

