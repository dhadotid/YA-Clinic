using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.ui.Controller
{
    public class LoginController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataTable dt = new DataTable();
        Connection con = new Connection();

        public DataTable loginCallback(string username, string password)
        {
            sqlCon = con.openConnection();
            sqlCom = new SqlCommand("select * from AccessLogin where Username = @username and UPassword = @password", sqlCon);
            sqlCom.Parameters.AddWithValue("@username", username);
            sqlCom.Parameters.AddWithValue("@password", password);
            sqlDa = new SqlDataAdapter(sqlCom);
            sqlDa.Fill(dt);
            sqlCon.Open();
            int i = sqlCom.ExecuteNonQuery();
            sqlCon.Close();
            return dt;
        }
    }
}