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
    public partial class AddRecordForm : Template
    {
        DashboardForm dashboardForm;
        VoterRecordsEntities db;

        public AddRecordForm(DashboardForm dashboardForm)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;
            this.Show();
            dashboardForm.Hide();
            db = new VoterRecordsEntities();
            db.Logins.FirstOrDefault();
        }

        private void goBack()
        {
            this.dashboardForm.Show();
            this.Dispose();
        }

        private void AddRecordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                goBack();
            }
        }

        private void AddRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            goBack();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void TxtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //if(txtCNIC.TextLength < 13)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("CNIC cannot contain more than 13 digits!");
            //}
        }

        private void TxtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //if (txtPhoneNo.TextLength < 11)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Phone number cannot contain more than 11 digits!");
            //}
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void TxtFather_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFormInputs())
            {
                try
                {
                    Voter voter = new Voter();

                    voter.name = txtName.Text;

                    if (!String.IsNullOrEmpty(txtFather.Text))
                        voter.father_name = txtFather.Text;

                    voter.CNIC = txtCNIC.Text;

                    if (!String.IsNullOrEmpty(txtVoteNo.Text))
                        voter.voter_no = txtVoteNo.Text;
                    if (!String.IsNullOrEmpty(txtFamily.Text))
                        voter.family = txtFamily.Text;
                    if (!String.IsNullOrEmpty(txtPhoneNo.Text))
                        voter.phone = txtPhoneNo.Text;
                    if (!String.IsNullOrEmpty(txtAddress.Text))
                        voter.address = txtAddress.Text;
                    if (!String.IsNullOrEmpty(txtPollingStation.Text))
                        voter.polling_station = txtPollingStation.Text;

                    db.Voters.Add(voter);
                    db.SaveChanges();
                    MessageBox.Show("Success");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: "+ex.Message);
                }
            }
        }

        private bool ValidateFormInputs()
        {
            bool res = false;

            if (!String.IsNullOrEmpty(txtName.Text))
            {
                if ((!String.IsNullOrEmpty(txtCNIC.Text)) && (txtCNIC.TextLength == 13))
                {
                    if ((!String.IsNullOrEmpty(txtPhoneNo.Text)) && (txtPhoneNo.TextLength == 11 || txtPhoneNo.TextLength == 0))
                    {
                        res = true;
                    }
                }
            }

            return res;
        }
    }
}
