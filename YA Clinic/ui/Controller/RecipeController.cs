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
        string drugName;
        DataRow dr;
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
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
        
        public DataSet searchRecipeData(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select b.Id_RecipeDetail, a.Id_Recipe, e.Patient_Name, c.DrugName, c.DrugType, b.Qty, d.Diagnose from Recipe.Recipe a join Recipe.RecipeDetail b on b.Id_Recipe = a.Id_Recipe join Recipe.Drug c on b.Id_Drug = c.Id_Drug join Patient.Treatment d on d.Id_Recipe = a.Id_Recipe join Patient.Patient e on e.Id_Patient = d.Id_Patient where b.Id_RecipeDetail like '%" + search + "%' or a.Id_Recipe like '%" + search + "%' or e.Patient_Name like '%" + search + "%' or c.DrugName like '%" + search + "%' or c.DrugType like '%" + search + "%' or b.Qty like '%" + search + "%' or d.Diagnose like '%" + search + "%'";
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

        public DataSet onRequestRecipe()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_Recipe, b.Patient_Name, c.Diagnose from Patient.Treatment c join Patient.Patient b on c.Id_Patient = b.Id_Patient join Recipe.Recipe a on c.Id_Recipe = a.Id_Recipe join Patient.Payment x on c.Id_Treatment = x.Id_Treatment where x.isPay = 0";
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

        public DataSet searchonRequestRecipe(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_Recipe, b.Patient_Name, c.Diagnose from Patient.Treatment c join Patient.Patient b on c.Id_Patient = b.Id_Patient join Recipe.Recipe a on c.Id_Recipe = a.Id_Recipe join Patient.Payment x on c.Id_Treatment = x.Id_Treatment where x.isPay = 0 and a.Id_Recipe like '%" + search + "%' or b.Patient_Name like '%" + search + "%' or c.Diagnose like '%" + search + "%'";
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

        public string AutoGenerateID()
        {
            Connection con = new Connection();
            SqlConnection sqlcon = con.openConnection();
            string id = null;

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select top 1 Id_RecipeDetail from Recipe.RecipeDetail order by Id_RecipeDetail desc";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr.GetString(0);
                        string sub = id.Substring(2);
                        int a = Convert.ToInt32(sub) + 1;
                        if (a < 10)
                        {
                            id = "RD0000" + a;
                        }
                        else if (a >= 10 && a < 100)
                        {
                            id = "RD000" + a;
                        }
                        else if (a >= 100 && a < 1000)
                        {
                            id = "RD00" + a;
                        }
                        else if (a >= 1000 && a < 10000)
                        {
                            id = "RD0" + a;
                        }
                        else if (a >= 10000 && a < 100000)
                        {
                            id = "RD" + a;
                        }
                        else
                        {
                            id = "full";
                        }
                    }
                    else
                    {
                        id = "RD00001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

        public DataSet dataRecipeDrug(string idrecipe)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_RecipeDetail, a.Id_Recipe, b.DrugName, a.Qty, a.Dose, a.Subtotal from Recipe.RecipeDetail a join Recipe.Drug b on a.Id_Drug = b.Id_Drug where a.Id_Recipe = '" + idrecipe +"' and a.isDraft = '0'";
                //string query = "select * from Recipe.RecipeDetail where Id_Recipe = '" + idrecipe + "' and isDraft = '0'";
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

        public DataSet searchDataRecipeDrug(string idrecipe, string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_RecipeDetail, a.Id_Recipe, b.DrugName, a.Qty, a.Dose, a.Subtotal from Recipe.RecipeDetail a join Recipe.Drug b on a.Id_Drug = b.Id_Drug where a.Id_Recipe = '" + idrecipe + "' and a.isDraft = '0' and a.Id_RecipeDetail like '%" + search + "%' or a.Id_Recipe like '%" + search + "%' or b.DrugName like '%" + search + "%' or a.Qty like '%" + search + "%' or a.Dose like '%" + search + "%' or a.Subtotal like '%" + search + "%'";
                //string query = "select * from Recipe.RecipeDetail where Id_Recipe = '" + idrecipe + "' and isDraft = '0'";
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

        public void draftData(string idrecipe, string iddrug, string qty, string dose)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string sql = "exec pcdRecipeDetail @idrecipe,@iddrug,@qty,@dose";
                sqlCom = new SqlCommand(sql, sqlCon);
                using (sqlCom)
                {
                    sqlCom.Parameters.Add(new SqlParameter("@idrecipe", idrecipe));
                    sqlCom.Parameters.Add(new SqlParameter("@iddrug", iddrug));
                    sqlCom.Parameters.Add(new SqlParameter("@qty", qty));
                    sqlCom.Parameters.Add(new SqlParameter("@dose", dose));

                    sqlCom.ExecuteNonQuery();


                }
                sqlCom.Clone();
            }
        }

        public bool deleteRecipe(string idrecipedetail)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                sqlCom = new SqlCommand("delete from Recipe.RecipeDetail where Id_RecipeDetail = '" + idrecipedetail + "'", sqlCon);
                int result = sqlCom.ExecuteNonQuery();
                sqlCon.Close();
                if (result > 0)
                {
                    return true;
                    //lblmsg.BackColor = Color.Red;
                    //lblmsg.ForeColor = Color.White;
                    //lblmsg.Text = stor_id + "      Deleted successfully.......    ";
                }
            }
            return false;
        }

        public DataTable getSpesificValueDrug(string idDrug)
        {
            sqlCon = con.openConnection();
            sqlCom = new SqlCommand("select * from Recipe.Drug where Id_Drug = @iddrug", sqlCon);
            sqlCom.Parameters.AddWithValue("@iddrug", idDrug);
            sqlDa = new SqlDataAdapter(sqlCom);
            sqlDa.Fill(dt);
            sqlCon.Open();
            int i = sqlCom.ExecuteNonQuery();
            sqlCon.Close();
            return dt;
        }
    }
}