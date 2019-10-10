namespace VoterRecords.Screens
{
    partial class AddRecordForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtFather = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblOld = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVoteNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPollingStation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(257, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(185, 26);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Registration Form";
            // 
            // txtCNIC
            // 
            this.txtCNIC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCNIC.Location = new System.Drawing.Point(144, 150);
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(175, 23);
            this.txtCNIC.TabIndex = 3;
            this.txtCNIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCNIC_KeyPress);
            // 
            // lblConfirm
            // 
            this.lblConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(30, 153);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(39, 17);
            this.lblConfirm.TabIndex = 13;
            this.lblConfirm.Text = "CNIC";
            // 
            // txtFather
            // 
            this.txtFather.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFather.Location = new System.Drawing.Point(144, 112);
            this.txtFather.Name = "txtFather";
            this.txtFather.Size = new System.Drawing.Size(175, 23);
            this.txtFather.TabIndex = 2;
            this.txtFather.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFather_KeyPress);
            // 
            // lblNew
            // 
            this.lblNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(30, 115);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(100, 17);
            this.lblNew.TabIndex = 11;
            this.lblNew.Text = "Father\'s Name";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(588, 232);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Location = new System.Drawing.Point(144, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 23);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtName_KeyPress);
            // 
            // lblOld
            // 
            this.lblOld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOld.AutoSize = true;
            this.lblOld.Location = new System.Drawing.Point(30, 77);
            this.lblOld.Name = "lblOld";
            this.lblOld.Size = new System.Drawing.Size(71, 17);
            this.lblOld.TabIndex = 7;
            this.lblOld.Text = "Full Name";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAddress.Location = new System.Drawing.Point(500, 150);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(175, 23);
            this.txtAddress.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Address";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhoneNo.Location = new System.Drawing.Point(500, 112);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(175, 23);
            this.txtPhoneNo.TabIndex = 6;
            this.txtPhoneNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPhoneNo_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Phone #";
            // 
            // txtFamily
            // 
            this.txtFamily.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFamily.Location = new System.Drawing.Point(500, 74);
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.Size = new System.Drawing.Size(175, 23);
            this.txtFamily.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Family";
            // 
            // txtVoteNo
            // 
            this.txtVoteNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVoteNo.Location = new System.Drawing.Point(144, 188);
            this.txtVoteNo.Name = "txtVoteNo";
            this.txtVoteNo.Size = new System.Drawing.Size(175, 23);
            this.txtVoteNo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Vote #";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(500, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtPollingStation
            // 
            this.txtPollingStation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPollingStation.Location = new System.Drawing.Point(500, 188);
            this.txtPollingStation.Name = "txtPollingStation";
            this.txtPollingStation.Size = new System.Drawing.Size(175, 23);
            this.txtPollingStation.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Polling Station";
            // 
            // AddRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 277);
            this.Controls.Add(this.txtPollingStation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtVoteNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFamily);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCNIC);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtFather);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblOld);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AddRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Record";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRecordForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddRecordForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtFather;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblOld;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVoteNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPollingStation;
        private System.Windows.Forms.Label label5;
    }
}