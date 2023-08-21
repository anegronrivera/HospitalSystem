using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem
{
    public partial class Diagnosis : Form
    {
        Functions Con;
        public Diagnosis()
        {
            InitializeComponent();
            Con = new Functions();
            GetPatients();
            GetTests();
            ShowDiagnosis();
        }

        private void GetPatients()
        {
            string Query = "Select * from PatientTable";
            PatientCB.DisplayMember = Con.GetData(Query).Columns["PatientName"].ToString();
            PatientCB.ValueMember = Con.GetData(Query).Columns["PatientID"].ToString();
            PatientCB.DataSource = Con.GetData(Query);
        }

        private void GetTests()
        {
            string Query = "Select * from TestTable";
            TestCB.DisplayMember = Con.GetData(Query).Columns["TestName"].ToString();
            TestCB.ValueMember = Con.GetData(Query).Columns["TestID"].ToString();
            TestCB.DataSource = Con.GetData(Query);
        }

        private void GetCost()
        {
            string Query = "Select * from TestTable where TestID = {0}";
            Query = string.Format(Query, TestCB.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                CostTB.Text = dr["TestCost"].ToString();
            }
        }

        private void ShowDiagnosis()
        {
            string Query = "Select * from DiagnosisTable";
            DiagnosisList.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            CostTB.Text = "";
            ResultTB.Text = "";
            TestCB.SelectedIndex = -1;
            PatientCB.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PatientCB.SelectedIndex == -1 || CostTB.Text == "" || ResultTB.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                string date = DiagnosisDateTB.Value.Date.ToString();
                int patient = Convert.ToInt32(PatientCB.SelectedValue.ToString());
                int test = Convert.ToInt32(TestCB.SelectedValue.ToString());
                int cost = Convert.ToInt32(CostTB.Text);
                string result = ResultTB.Text;
                string Query = "Insert into DiagnosisTable values('{0}',{1},{2},{3},'{4}')";
                Query = string.Format(Query, date, patient, test, cost, result);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Added!");
            }
        }

        private void TestCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();
        }

        int key = 0;
        private void DiagnosisList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DiagnosisDateTB.Text = DiagnosisList.SelectedRows[0].Cells[1].Value.ToString();
            PatientCB.SelectedItem = DiagnosisList.SelectedRows[0].Cells[2].Value.ToString();
            TestCB.SelectedItem = DiagnosisList.SelectedRows[0].Cells[3].Value.ToString();
            CostTB.Text = DiagnosisList.SelectedRows[0].Cells[4].Value.ToString();
            ResultTB.Text = DiagnosisList.SelectedRows[0].Cells[5].Value.ToString();

            if (CostTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DiagnosisList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PatientCB.SelectedIndex == -1 || CostTB.Text == "" || ResultTB.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                string date = DiagnosisDateTB.Value.Date.ToString();
                int patient = Convert.ToInt32(PatientCB.SelectedValue.ToString());
                int test = Convert.ToInt32(TestCB.SelectedValue.ToString());
                int cost = Convert.ToInt32(CostTB.Text);
                string result = ResultTB.Text;
                string Query = "Update DiagnosisTable set DiagnosisDate = '{0}',Patient = {1},Test = {2},Cost = {3},Result = '{4}' where DiagnosisID = {5}";
                Query = string.Format(Query, date, patient, test, cost, result, key);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Updated!");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Diagnosis!");
            }
            else
            {
                string Query = "Delete from DiagnosisTable where DiagnosisID = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Deleted!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Patients Obj = new Patients();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tests Obj = new Tests();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Diagnosis Obj = new Diagnosis();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
