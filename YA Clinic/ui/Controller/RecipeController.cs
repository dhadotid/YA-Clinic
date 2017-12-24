using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.ui.Controller
{
    public class RecipeController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataSet ds = new DataSet();
        Connection con = new Connection();

        public DataSet recipeData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select b.Id_RecipeDetail, a.Id_Recipe, e.Patient_Name, c.DrugName, c.DrugType, b.Qty, d.Diagnose from Recipe.Recipe a join Recipe.RecipeDetail b on b.Id_Recipe = a.Id_Recipe join Recipe.Drug c on b.Id_Drug = c.Id_Drug join Patient.Treatment d on d.Id_Recipe = a.Id_Recipe join Patient.Patient e on e.Id_Patient = d.Id_Patient";
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
    }
}