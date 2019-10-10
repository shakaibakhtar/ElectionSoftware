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
    public partial class ChangePasswordForm : Template
    {
        DashboardForm dashboardForm;
        VoterRecordsEntities db;

        public ChangePasswordForm(DashboardForm dashboardForm)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;
            this.Show();
            dashboardForm.Hide();
            db = new VoterRecordsEntities();
        }

        private void goBack()
        {
            dashboardForm.Show();
            this.Dispose();
        }

        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            goBack();
        }

        private void ChangePasswordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                goBack();
            }
        }

        private bool StringsAreEqual(string str1, string str2)
        {
            if (str1.Equals(str2))
                return true;

            return false;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (StringsAreEqual(txtNewPassword.Text, txtConfirmPassword.Text))
            {
                if (!StringsAreEqual(txtOldPassword.Text, txtNewPassword.Text))
                {
                    try
                    {
                        var dbPassword = db.Logins.FirstOrDefault();
                        if (StringsAreEqual(dbPassword.password, txtOldPassword.Text))
                        {
                            dbPassword.password = txtNewPassword.Text;
                            db.SaveChanges();
                            MessageBox.Show("Password changed successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: "+ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Old password and new password should not be same!");
                }
            }
            else
            {
                MessageBox.Show("New password and confirm password does not match!");
            }
        }
    }
}
