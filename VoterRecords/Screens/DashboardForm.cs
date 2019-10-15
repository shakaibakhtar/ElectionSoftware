using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoterRecords.Model;

namespace VoterRecords.Screens
{
    public partial class DashboardForm : Template
    {
        LoginForm loginForm;
        VoterRecordsEntities db;

        public DashboardForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            loginForm.Hide();
            this.Show();
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            goBack();
        }

        private void goBack()
        {
            loginForm.Show();
            this.Dispose();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePasswordForm(this);
        }

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                goBack();
            }
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void AddRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddRecordForm(this, AddRecordForm.taskToPerform.add, -1);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            db = new VoterRecordsEntities();
            refreshVoterList();
        }

        private void refreshVoterList()
        {
            try
            {
                dgvVoters.DataSource = db.Voters.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearchOn(txtSearch.Text);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PerformSearchOn(txtSearch.Text);
        }

        private void PerformSearchOn(string keyword)
        {
            try
            {
                if (rbName.Checked)
                {
                    var dgvDataSource = db.Voters.Where(x=>x.name.Contains(keyword)).ToList();
                    dgvVoters.DataSource = dgvDataSource;
                }
                else if (rbCNIC.Checked)
                {
                    var dgvDataSource = db.Voters.Where(x => x.CNIC.Contains(keyword)).ToList();
                    dgvVoters.DataSource = dgvDataSource;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        private void DgvVoters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditVoter();
        }

        private void DgvVoters_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EditVoter();
            }
        }

        private void EditVoter()
        {
            int id = (int)dgvVoters.CurrentRow.Cells[0].Value;
            new AddRecordForm(this, AddRecordForm.taskToPerform.update, id);
        }
    }
}
