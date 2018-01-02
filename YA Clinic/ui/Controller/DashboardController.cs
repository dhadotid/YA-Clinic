using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.ui.Controller
{
    public class DashboardController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        Connection con = new Connection();

        public int jumlahPatient()
        {
            int jumlah = 0;
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select count(*) as Jumlah from Patient.Patient";
                sqlCom = new SqlCommand(query, sqlCon);
                using (sqlCom)
                {
                    SqlDataReader sdr = sqlCom.ExecuteReader();
                    if (sdr.Read())
                    {
                        jumlah = sdr.GetInt32(0);
                    }
                }
                sqlCon.Close();
            }
            return jumlah;
        }

        public int jumlahDoctor()
        {
            int jumlah = 0;
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select count(*) as Jumlah from Doctor.Doctor";
                sqlCom = new SqlCommand(query, sqlCon);
                using (sqlCom)
                {
                    SqlDataReader sdr = sqlCom.ExecuteReader();
                    if (sdr.Read())
                    {
                        jumlah = sdr.GetInt32(0);
                    }
                }
                sqlCon.Close();
            }
            return jumlah;
        }

        public int jumlahDrug()
        {
            int jumlah = 0;
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select count(*) as Jumlah from Recipe.Drug";
                sqlCom = new SqlCommand(query, sqlCon);
                using (sqlCom)
                {
                    SqlDataReader sdr = sqlCom.ExecuteReader();
                    if (sdr.Read())
                    {
                        jumlah = sdr.GetInt32(0);
                    }
                }
                sqlCon.Close();
            }
            return jumlah;
        }

        public int jumlahPayment()
        {
            int jumlah = 0;
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select count(*) as Jumlah from Patient.Payment where isPay = '1'";
                sqlCom = new SqlCommand(query, sqlCon);
                using (sqlCom)
                {
                    SqlDataReader sdr = sqlCom.ExecuteReader();
                    if (sdr.Read())
                    {
                        jumlah = sdr.GetInt32(0);
                    }
                }
                sqlCon.Close();
            }
            return jumlah;
        }
    }
}