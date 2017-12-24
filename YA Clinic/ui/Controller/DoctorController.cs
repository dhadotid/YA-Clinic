using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.ui.Controller
{
    public class DoctorController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataSet ds = new DataSet();
        Connection con = new Connection();

        public DataSet doctorData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select * from Doctor.Doctor";
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

        public bool deleteData(string iddoctor)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                sqlCom = new SqlCommand("delete from Doctor.Doctor where Id_Doctor = '" + iddoctor + "'", sqlCon);
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