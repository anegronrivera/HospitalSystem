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
    public partial class Patients : Form
    {
        Functions Con;
        public Patients()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPatients();
        }

        private void ShowPatients()
        {
            string Query = "Select * from PatientTable";
            PatientsList.DataSource = Con.GetData(Query);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PatientNameTB.Text == "" || PatientPhoneTB.Text == "" || PatientAddressTB.Text == "" || GenderCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                string patient = PatientNameTB.Text;
                string gender = GenderCB.SelectedItem.ToString();
                string birthdate = DOBTB.Value.Date.ToString();
                string phone = PatientPhoneTB.Text;
                string address = PatientAddressTB.Text;
                string Query = "Insert into PatientTable values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, patient, gender, birthdate, phone, address);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Added!");
            }
        }

        int key = 0;

        private void PatientsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientNameTB.Text = PatientsList.SelectedRows[0].Cells[1].Value.ToString();
            GenderCB.SelectedItem = PatientsList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTB.Text = PatientsList.SelectedRows[0].Cells[3].Value.ToString();
            PatientPhoneTB.Text = PatientsList.SelectedRows[0].Cells[4].Value.ToString();
            PatientAddressTB.Text = PatientsList.SelectedRows[0].Cells[5].Value.ToString();

            if (PatientNameTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PatientNameTB.Text == "" || PatientPhoneTB.Text == "" || PatientAddressTB.Text == "" || GenderCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                string patient = PatientNameTB.Text;
                string gender = GenderCB.SelectedItem.ToString();
                string birthdate = DOBTB.Value.Date.ToString();
                string phone = PatientPhoneTB.Text;
                string address = PatientAddressTB.Text;
                string Query = "Update PatientTable set PatientName = '{0}',PatientGen = '{1}',PatientDOB = '{2}',PatientPhone = '{3}',PatientAddress = '{4}' where PatientID = {5}";
                Query = string.Format(Query, patient, gender, birthdate, phone, address, key);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Updated!");
            }
        }

        private void Clear()
        {
            PatientNameTB.Text = "";
            GenderCB.SelectedIndex = -1;
            PatientPhoneTB.Text = "";
            PatientAddressTB.Text = "";
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Patient!");
            }
            else
            {
                string Query = "Delete from PatientTable where PatientID = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Deleted!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
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
    }
}
