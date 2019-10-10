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
            db = new VoterRecordsEntities();
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
    }
}