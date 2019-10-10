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
        VoterRecordsEntities db;// = new VoterRecordsEntities();
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
            if (isAuthenticated(txtPassword.Text))
            {
                btnLogin.Enabled = true;
                new DashboardForm(this);
            }
            else
            {
                MessageBox.Show("Invalid password");
                txtPassword.Focus();
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
                    res = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return res;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            db = new VoterRecordsEntities();
            db.Logins.FirstOrDefault();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            if (this.Visible)
            {
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
