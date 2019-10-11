namespace VoterRecords.Screens
{
    partial class DashboardForm
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
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvVoters = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoters)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.addRecordToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1228, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menu";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.changePasswordToolStripMenuItem.Text = "&Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordToolStripMenuItem_Click);
            // 
            // addRecordToolStripMenuItem
            // 
            this.addRecordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRecordToolStripMenuItem1,
            this.modifyRecordToolStripMenuItem});
            this.addRecordToolStripMenuItem.Name = "addRecordToolStripMenuItem";
            this.addRecordToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.addRecordToolStripMenuItem.Text = "&Records";
            // 
            // addRecordToolStripMenuItem1
            // 
            this.addRecordToolStripMenuItem1.Name = "addRecordToolStripMenuItem1";
            this.addRecordToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.addRecordToolStripMenuItem1.Text = "&Add Record";
            this.addRecordToolStripMenuItem1.Click += new System.EventHandler(this.AddRecordToolStripMenuItem1_Click);
            // 
            // modifyRecordToolStripMenuItem
            // 
            this.modifyRecordToolStripMenuItem.Name = "modifyRecordToolStripMenuItem";
            this.modifyRecordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modifyRecordToolStripMenuItem.Text = "&Modify Record";
            // 
            // dgvVoters
            // 
            this.dgvVoters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVoters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoters.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVoters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoters.Location = new System.Drawing.Point(0, 129);
            this.dgvVoters.Name = "dgvVoters";
            this.dgvVoters.Size = new System.Drawing.Size(1228, 323);
            this.dgvVoters.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(525, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Voters List";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvVoters);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardForm_FormClosing);
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyDown);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRecordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modifyRecordToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvVoters;
        private System.Windows.Forms.Label label1;
    }
}