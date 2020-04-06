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
            if (e.KeyCode == Keys.Escape)
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
            refreshVoterList();
        }

        private void refreshVoterList()
        {
            try
            {
                using (VoterRecordsEntities db = new VoterRecordsEntities())
                {
                    dgvVoters.DataSource = null;
                    dgvVoters.DataSource = db.Voters.ToList();
                    SetDgvColumnNames();
                }
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
                using (VoterRecordsEntities db = new VoterRecordsEntities())
                {
                    if (rbName.Checked)
                    {
                        var dgvDataSource = db.Voters.Where(x => x.name.Contains(keyword)).ToList();
                        dgvVoters.DataSource = dgvDataSource;
                    }
                    else if (rbCNIC.Checked)
                    {
                        var dgvDataSource = db.Voters.Where(x => x.CNIC.Contains(keyword)).ToList();
                        dgvVoters.DataSource = dgvDataSource;
                    }

                    SetDgvColumnNames();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DgvVoters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditVoter();
        }

        private void DgvVoters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditVoter();
            }
        }

        private void EditVoter()
        {
            int id = (int)dgvVoters.CurrentRow.Cells[0].Value;
            new AddRecordForm(this, AddRecordForm.taskToPerform.update, id);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void RefreshDGV()
        {
            try
            {
                using (VoterRecordsEntities db = new VoterRecordsEntities())
                {
                    dgvVoters.DataSource = null;
                    dgvVoters.DataSource = db.Voters.ToList();
                    SetDgvColumnNames();
                    txtSearch.Clear();
                }

                //dgvVoters.DataSource = null;
                //db.Entry(db.Voters).Reload();
                //dgvVoters.DataSource = db.Voters.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void SetDgvColumnNames()
        {
            dgvVoters.Columns[0].HeaderText = "Sr #";
            dgvVoters.Columns[1].HeaderText = "Full Name";
            dgvVoters.Columns[2].HeaderText = "S/O D/O W/O";
            dgvVoters.Columns[3].HeaderText = "CNIC #";
            dgvVoters.Columns[4].HeaderText = "Family";
            dgvVoters.Columns[5].HeaderText = "Phone";
            dgvVoters.Columns[6].HeaderText = "Voter #";
            dgvVoters.Columns[7].HeaderText = "Address";
            dgvVoters.Columns[8].HeaderText = "Polling Station";
            dgvVoters.Columns[9].HeaderText = "Caste";

            dgvVoters.AutoResizeColumns();
        }
    }
}
