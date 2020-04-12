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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //new PrintPreviewForm(this);
           // MessageBox.Show("This feature is under development.");

            DataTable table = new DataTable();
            table.Columns.Add("Sr #", typeof(int));
            table.Columns.Add("Full Name", typeof(string));
            table.Columns.Add("S/O D/O W/O", typeof(string));
            table.Columns.Add("CNIC #", typeof(string));
            table.Columns.Add("Family", typeof(string));
            table.Columns.Add("Phone", typeof(string));
            table.Columns.Add("Voter #", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("Polling Station", typeof(string));
            table.Columns.Add("Caste", typeof(string));


            using (VoterRecordsEntities db = new VoterRecordsEntities())
            {
                var votersList = db.Voters.ToList();
                foreach(var x in votersList)
                {
                    table.Rows.Add(x.id, x.name, x.father_name, x.CNIC, x.family, x.phone, x.voter_no, x.address, x.polling_station, x.Caste);
                }
            }

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            excel = new Microsoft.Office.Interop.Excel.Application();
            // for making Excel visible  
            excel.Visible = true;
            excel.DisplayAlerts = true;
            // Creation a new Workbook  
            excelworkBook = excel.Workbooks.Add(Type.Missing);
            // Workk sheet  
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Test work sheet";

            excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();

            excelSheet.Cells[2, 1] = "Sr #";
            excelSheet.Cells[2, 2] = "Full Name";
            excelSheet.Cells[2, 3] = "S/O D/O W/O";
            excelSheet.Cells[2, 4] = "CNIC #";
            excelSheet.Cells[2, 5] = "Family";
            excelSheet.Cells[2, 6] = "Phone";
            excelSheet.Cells[2, 7] = "Voter #";
            excelSheet.Cells[2, 8] = "Address";
            excelSheet.Cells[2, 9] = "Polling Station";
            excelSheet.Cells[2, 10] = "Caste";

            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int column = 0; column < table.Columns.Count; column++)
                {
                    excelSheet.Cells[row + 3, column + 1] = table.Rows[row][column];
                }
            }

            // now we resize the columns  
            excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[table.Rows.Count + 2, table.Columns.Count]];
            excelCellrange.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            MessageBox.Show("Done exporting");
        }
    }
}
