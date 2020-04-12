using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        int voterID = -1;
        taskToPerform task;
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        public enum taskToPerform
        {
            add = 0,
            update = 1
        }

        public AddRecordForm(DashboardForm dashboardForm, taskToPerform task, int voterID)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;
            this.Show();
            dashboardForm.Hide();
            db = new VoterRecordsEntities();
            db.Logins.FirstOrDefault();
            this.task = task;
            this.voterID = voterID;
            if (voterID != -1)
            {
                FillFormFromDatabase();
            }

            using (VoterRecordsEntities db = new VoterRecordsEntities())
            {
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();

                var listNames = db.Voters.Select(x => x.address).ToList();

                foreach (string name in listNames)
                {
                    source.Add(name);
                }
                txtAddress.AutoCompleteCustomSource = source;
            }
        }

        private void GoBack()
        {
            this.dashboardForm.Show();
            this.Dispose();
        }

        private void AddRecordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                GoBack();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void AddRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GoBack();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void TxtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtCNIC2.TextLength == 5 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
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
            Save();
        }

        private void Save()
        {
            if (voterID != -1)
            {
                UpdateOldRecord();
            }
            else
            {
                AddNewRecord();
            }
        }

        private void UpdateOldRecord()
        {
            if (ValidateFormInputs())
            {
                try
                {
                    var voter = db.Voters.Where(x => x.id == voterID).FirstOrDefault();

                    if (voter != null)
                    {
                        voter.name = txtName.Text;

                        //if (!String.IsNullOrEmpty(txtFather.Text))
                            voter.father_name = txtFather.Text;

                        string cnic = txtCNIC1.Text + txtCNIC2.Text + txtCNIC3.Text;
                        voter.CNIC = cnic;

                        //if (!String.IsNullOrEmpty(txtVoteNo.Text))
                            voter.voter_no = txtVoteNo.Text;
                        //if (!String.IsNullOrEmpty(txtFamily.Text))
                            voter.family = txtFamily.Text;
                        //if (!String.IsNullOrEmpty(txtPhoneNo.Text))
                            voter.phone = txtPhoneNo.Text;
                        //if (!String.IsNullOrEmpty(txtAddress.Text))
                            voter.address = txtAddress.Text;
                        //if (!String.IsNullOrEmpty(txtPollingStation.Text))
                            voter.polling_station = txtPollingStation.Text;
                        //if (!String.IsNullOrEmpty(txtCaste.Text))
                            voter.Caste = txtCaste.Text;

                        db.SaveChanges();

                        ResetFormFields();

                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Record not found");
                        GoBack();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddNewRecord()
        {
            if (ValidateFormInputs())
            {
                string cnicNo = txtCNIC1.Text + txtCNIC2.Text + txtCNIC3.Text;
                try
                {
                    var cnicCount = db.Voters.Where(x => x.CNIC == cnicNo).ToList().Count;
                    //var voterNoCount = db.Voters.Where(x => x.voter_no == txtVoteNo.Text).ToList().Count();
                    var voterID = (db.Voters.Max(x => x.id)) + 1;
                    if (cnicCount < 1)
                    {
                        //if (voterNoCount < 1)
                        //{
                        Voter voter = new Voter();

                        voter.id = voterID;
                        voter.name = txtName.Text;

                       // if (!String.IsNullOrEmpty(txtFather.Text))
                            voter.father_name = txtFather.Text;

                        string cnic = txtCNIC1.Text + txtCNIC2.Text + txtCNIC3.Text;
                        voter.CNIC = cnic;

                        //if (!String.IsNullOrEmpty(txtVoteNo.Text))
                            voter.voter_no = txtVoteNo.Text;
                        //if (!String.IsNullOrEmpty(txtFamily.Text))
                            voter.family = txtFamily.Text;
                        //if (!String.IsNullOrEmpty(txtPhoneNo.Text))
                            voter.phone = txtPhoneNo.Text;
                        //if (!String.IsNullOrEmpty(txtAddress.Text))
                            voter.address = txtAddress.Text;
                        //if (!String.IsNullOrEmpty(txtPollingStation.Text))
                            voter.polling_station = txtPollingStation.Text;
                        //if (!String.IsNullOrEmpty(txtCaste.Text))
                            voter.Caste = txtCaste.Text;

                        db.Voters.Add(voter);
                        db.SaveChanges();

                        ResetFormFields();

                        MessageBox.Show("Success");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Voter Number: " + txtVoteNo.Text + " already exist");
                        //}
                    }
                    else
                    {
                        MessageBox.Show("CNIC: " + cnicNo + " already exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private bool ValidateFormInputs()
        {
            bool res = false;

            string cnic = txtCNIC1.Text + txtCNIC2.Text + txtCNIC3.Text;

            if (!String.IsNullOrEmpty(txtName.Text))
            {
                if ((!String.IsNullOrEmpty(cnic)) && (cnic.Length == 13))
                {
                    if ((!String.IsNullOrEmpty(txtPhoneNo.Text)) && (txtPhoneNo.TextLength == 11 || txtPhoneNo.TextLength == 0))
                    {
                        res = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Phone");
                        txtPhoneNo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid CNIC");
                    txtCNIC1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid Name");
                txtName.Focus();
            }

            return res;
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            //if (txtName.Text.Equals(""))
            //{
            //    SetDefaultText(sender, "Enter Name Here");
            //}
        }

        private void FillFormFromDatabase()
        {
            try
            {
                var voter = db.Voters.Where(x => x.id == voterID).FirstOrDefault();

                string cnic = voter.CNIC;

                txtName.Text = voter.name;
                txtFather.Text = voter.father_name;
                txtCNIC1.Text = voter.CNIC.Substring(0, 5);
                txtCNIC2.Text = cnic.Substring(5, 7);
                txtCNIC3.Text = cnic.Substring(12, 1);
                txtVoteNo.Text = voter.voter_no;
                txtFamily.Text = voter.family;
                txtPhoneNo.Text = voter.phone;
                txtAddress.Text = voter.address;
                txtPollingStation.Text = voter.polling_station;
                txtCaste.Text = voter.Caste;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! voter record could not be fetched from the recoerds.\n Please try again later.");
            }
        }

        private void ResetFormFields()
        {
            txtName.Clear();
            txtFather.Clear();
            txtCNIC1.Text = "34402";
            txtCNIC2.Clear();
            txtCNIC3.Clear();
            txtVoteNo.Clear();
            txtCaste.Clear();
            txtFamily.Clear();
            txtPhoneNo.Clear();
            txtAddress.Text = "Challianwala";
            txtPollingStation.Clear();

            txtName.Focus();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.Text = ti.ToTitleCase(txtName.Text);
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            if (txtCNIC1.TextLength == 5)
            {
                txtCNIC2.Focus();
            }
        }

        private void txtCNIC2_TextChanged(object sender, EventArgs e)
        {
            if (txtCNIC2.TextLength == 7)
            {
                txtCNIC3.Focus();
            }
        }

        private void txtCNIC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtCNIC2.TextLength == 7 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtCNIC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtCNIC3.TextLength == 1 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtCNIC3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && (txtCNIC3.TextLength == 1 || txtCNIC3.TextLength == 0))
            {
                txtCNIC3.Clear();
                txtCNIC2.Focus();
            }
        }

        private void txtCNIC2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && (txtCNIC2.TextLength == 1 || txtCNIC2.TextLength == 0))
            {
                txtCNIC2.Clear();
                txtCNIC1.Focus();
            }
        }

        private void txtFather_Leave(object sender, EventArgs e)
        {
            txtFather.Text = ti.ToTitleCase(txtFather.Text);
        }

        private void txtCaste_Leave(object sender, EventArgs e)
        {
            txtCaste.Text = ti.ToTitleCase(txtCaste.Text);
        }

        private void txtFamily_Leave(object sender, EventArgs e)
        {
            txtFamily.Text = ti.ToTitleCase(txtFamily.Text);
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.Text = ti.ToTitleCase(txtAddress.Text);
        }

        private void txtPollingStation_Leave(object sender, EventArgs e)
        {
            txtPollingStation.Text = ti.ToTitleCase(txtPollingStation.Text);
        }

        //private void SetDefaultText(object sender, string text)
        //{
        //    TextBox sndr = (TextBox)sender;
        //    sndr.Text = text;
        //}

        //private void SetEmptyText(object sender)
        //{
        //    TextBox sndr = (TextBox)sender;
        //    sndr.Text = "";
        //}
    }
}
