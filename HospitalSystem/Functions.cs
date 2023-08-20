using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string connectionStr;

        public Functions() 
        {
            connectionStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Alfredo\\source\\repos\\Git\\HospitalSystem\\HospitalSystemDB.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(connectionStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Con);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }
    }
}
