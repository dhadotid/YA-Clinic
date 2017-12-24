using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.Controller
{
    public class SpecialistController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataSet ds = new DataSet();
        Connection con = new Connection();
        public bool specialistAvailable(string specialist)
        {
            SqlDataReader sqlDr;
            SqlConnection sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select count(Specialist) as Specialist from Doctor.Specialist where Specialist = '" + specialist + "'";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDr = sqlCom.ExecuteReader();
                while (sqlDr.Read())
                {
                    string specialistName = sqlDr["Specialist"].ToString();
                    if(specialistName == "0")
                    {
                        return false;
                    }
                }
            }
            sqlCon.Close();
            return true;
        }
        public void Save(string Specialist, int Fare)
        {
            SqlConnection sqlcon = con.openConnection();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "exec pcdSpecialist @specialist,@fare";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.Add(new SqlParameter("@specialist", Specialist));
                    sqlcom.Parameters.Add(new SqlParameter("@fare", Fare));
                    sqlcom.ExecuteNonQuery();
                }
                sqlcom.Clone();
            }
        }

        public string AutoGenerateID()
        {
            SqlConnection sqlcon = con.openConnection();
            string id = null;

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select top 1 Id_Specialist from Doctor.Specialist order by Id_Specialist desc";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr.GetString(0);
                        string sub = id.Substring(3);
                        int a = Convert.ToInt32(sub) + 1;
                        if (a < 10)
                        {
                            id = "SPC00" + a;
                        }
                        else if (a >= 10 && a < 100)
                        {
                            id = "SPC0" + a;
                        }
                        else if (a >= 100 && a < 1000)
                        {
                            id = "SPC" + a;
                        }
                        else
                        {
                            id = "full";
                        }
                    }
                    else
                    {
                        id = "SPC001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

        public DataSet SpecialistData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select * from Doctor.Specialist";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                sqlCon.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
        }

        public bool deleteData(string idSpecialist)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                sqlCom = new SqlCommand("delete from Doctor.Specialist where Id_Specialist = '" + idSpecialist + "'", sqlCon);
                int result = sqlCom.ExecuteNonQuery();
                sqlCon.Close();
                if (result == 1)
                {
                    return true;
                    //lblmsg.BackColor = Color.Red;
                    //lblmsg.ForeColor = Color.White;
                    //lblmsg.Text = stor_id + "      Deleted successfully.......    ";
                }
            }
            return false;
        }
    }
}