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
    public partial class Tests : Form
    {
        Functions Con;
        public Tests()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTests();
        }

        private void ShowTests()
        {
            string Query = "Select * from TestTable";
            TestsList.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            TestNameTB.Text = "";
            TestCostTB.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (TestNameTB.Text == "" || TestCostTB.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                string testName = TestNameTB.Text;
                int cost = Convert.ToInt32(TestCostTB.Text);
                string Query = "Insert into TestTable values('{0}',{1})";
                Query = string.Format(Query, testName, cost);
                Con.SetData(Query);
                ShowTests();
                Clear();
                MessageBox.Show("Test Added!");
            }
        }

        int key = 0;

        private void TestsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TestNameTB.Text = TestsList.SelectedRows[0].Cells[1].Value.ToString();
            TestCostTB.Text = TestsList.SelectedRows[0].Cells[2].Value.ToString();

            if (TestNameTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TestsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (TestNameTB.Text == "" || TestCostTB.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                string testName = TestNameTB.Text;
                int cost = Convert.ToInt32(TestCostTB.Text);
                string Query = "Update TestTable set TestName = '{0}',TestCost = {1} where TestID = {2}";
                Query = string.Format(Query, testName, cost, key);
                Con.SetData(Query);
                ShowTests();
                Clear();
                MessageBox.Show("Test Updated!");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Test!");
            }
            else
            {
                string testName = TestNameTB.Text;
                int cost = Convert.ToInt32(TestCostTB.Text);
                string Query = "Delete from TestTable where TestID = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowTests();
                Clear();
                MessageBox.Show("Test Deleted!");
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
