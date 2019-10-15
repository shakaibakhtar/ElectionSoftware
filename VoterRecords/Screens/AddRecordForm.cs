﻿using System;
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
        int voterID = -1;
        taskToPerform task;

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

                        db.SaveChanges();
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
                try
                {
                    var cnicCount = db.Voters.Where(x => x.CNIC == txtCNIC.Text).ToList().Count;
                    var voterNoCount = db.Voters.Where(x => x.voter_no == txtVoteNo.Text).ToList().Count();

                    if (cnicCount < 1)
                    {
                        if (voterNoCount < 1)
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
                        else
                        {
                            MessageBox.Show("Voter Number: " + txtVoteNo.Text + " already exist");
                        }
                    }
                    else
                    {
                        MessageBox.Show("CNIC: " + txtCNIC.Text + " already exist");
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

            if (!String.IsNullOrEmpty(txtName.Text))
            {
                if ((!String.IsNullOrEmpty(txtCNIC.Text)) && (txtCNIC.TextLength == 13))
                {
                    if ((!String.IsNullOrEmpty(txtPhoneNo.Text)) && (txtPhoneNo.TextLength == 11 || txtPhoneNo.TextLength == 0))
                    {
                        res = true;
                    }
                    MessageBox.Show("Invalid Phone");
                    txtPhoneNo.Focus();
                }
                else
                {
                    MessageBox.Show("Invalid CNIC");
                    txtCNIC.Focus();
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

                txtName.Text = voter.name;
                txtFather.Text = voter.father_name;
                txtCNIC.Text = voter.CNIC;
                txtVoteNo.Text = voter.voter_no;
                txtFamily.Text = voter.family;
                txtPhoneNo.Text = voter.phone;
                txtAddress.Text = voter.address;
                txtPollingStation.Text = voter.polling_station;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorry! voter record could not be fetched.\n Please try again later.");
            }
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
