using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoterRecords.Model;

namespace VoterRecords.Screens
{
    public partial class LoginForm : Template
    {
        VoterRecordsEntities db = new VoterRecordsEntities();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            progressBar.Show();

            if (isAuthenticated(txtPassword.Text))
            {
                progressBar.Hide();
                btnLogin.Enabled = true;
                // go to dashboard
            }
            else
            {
                MessageBox.Show("Invalid password");
            }
        }

        bool isAuthenticated(string password = "")
        {
            bool res = false;

            try
            {
                List<Login> dbPass = db.Logins.Where(x => x.password == password).ToList();
                if (dbPass.Count > 0)
                {
                    progressBar.Hide();
                    res = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return res;
        }
    }
}
