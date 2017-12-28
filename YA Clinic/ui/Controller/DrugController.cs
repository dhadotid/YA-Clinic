using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.ui.Controller
{
    public class DrugController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataSet ds = new DataSet();
        Connection con = new Connection();

        public string AutoGenerateID()
        {
            SqlConnection sqlcon = con.openConnection();
            string id = null;

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select top 1 Id_Drug from Recipe.Drug order by Id_Drug desc";
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
                            id = "DRG0000" + a;
                        }
                        else if (a >= 10 && a < 100)
                        {
                            id = "DRG000" + a;
                        }
                        else if (a >= 100 && a < 1000)
                        {
                            id = "DRG00" + a;
                        }
                        else if (a >= 1000 && a < 10000)
                        {
                            id = "DRG0" + a;
                        }
                        else if (a >= 10000 && a < 100000)
                        {
                            id = "DRG" + a;
                        }
                        else
                        {
                            id = "full";
                        }
                    }
                    else
                    {
                        id = "DRG00001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

        public DataSet drugData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select * from Recipe.Drug";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                sqlCon.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            return ds;
        }

        public DataSet searchDrugData(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select * from Recipe.Drug where Id_Drug like '%" + search + "%' or DrugName like '%" + search + "%' or DrugType like '%" + search + "%' or Stock like '%" + search + "%' or ExpDate like '%" + search + "%' or Price like '%" + search + "%'";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                sqlCon.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            return ds;
        }

        public void Save(string drugName, string drugType, string drugStock, string expDate, string price)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string sql = "exec pcdDrug @drugName,@drugType,@drugStock,@expDate,@price";
                sqlCom = new SqlCommand(sql, sqlCon);
                using (sqlCom)
                {
                    sqlCom.Parameters.Add(new SqlParameter("@drugName", drugName));
                    sqlCom.Parameters.Add(new SqlParameter("@drugType", drugType));
                    sqlCom.Parameters.Add(new SqlParameter("@drugStock", drugStock));
                    sqlCom.Parameters.Add(new SqlParameter("@expDate", expDate));
                    sqlCom.Parameters.Add(new SqlParameter("@price", price));

                    sqlCom.ExecuteNonQuery();


                }
                sqlCom.Clone();
            }
        }
    }
}