using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.ui.Controller
{
    public class PaymentController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Connection con = new Connection();

        public DataSet paymentData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select c.Id_Payment,a.Patient_Name, x.DoctorName ,b.Diagnose,b.DateTreatment,c.PaymentDoctor,c.PaymentDrug,c.TotalPayment from Patient.Patient a join Patient.Treatment b on a.Id_Patient = b.Id_Patient join Patient.Payment c on c.Id_Treatment = b.Id_Treatment join Doctor.Doctor x on b.Id_Doctor = x.Id_Doctor where c.isPay like '1'";
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

        public DataSet searchPaymentData(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select c.Id_Payment,a.Patient_Name, x.DoctorName ,b.Diagnose,b.DateTreatment,c.PaymentDoctor,c.PaymentDrug,c.TotalPayment from Patient.Patient a join Patient.Treatment b on a.Id_Patient = b.Id_Patient join Patient.Payment c on c.Id_Treatment = b.Id_Treatment join Doctor.Doctor x on b.Id_Doctor = x.Id_Doctor where c.isPay like '1' and (c.Id_Payment like '%" + search + "%' or a.Patient_Name like '%" + search + "%' or x.DoctorName like '%" + search + "%' or b.Diagnose like '%" + search + "%' or b.DateTreatment like '%" + search + "%' or c.PaymentDoctor like '%" + search + "%' or c.PaymentDrug like '%" + search + "%' or c.TotalPayment like '%" + search + "%')";
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

        public DataSet paymentIsNotyetPay()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select x.Id_Payment, b.Patient_Name, a.Diagnose, x.PaymentDoctor, x.PaymentDrug, x.TotalPayment from Patient.Treatment a join Patient.Patient b on a.Id_Patient = b.Id_Patient join Patient.Payment x on a.Id_Treatment = x.Id_Treatment where x.isPay = '0'";
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


        public DataSet searchPaymentIsNotyetPay(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select x.Id_Payment, b.Patient_Name, a.Diagnose, x.PaymentDoctor, x.PaymentDrug, x.TotalPayment from Patient.Treatment a join Patient.Patient b on a.Id_Patient = b.Id_Patient join Patient.Payment x on a.Id_Treatment = x.Id_Treatment where x.isPay = '0' and (x.Id_Payment like '%" + search + "%' or b.Patient_Name like '%" + search + "%' or a.Diagnose like '%" + search + "%' or x.PaymentDoctor like '%" + search + "%' or x.PaymentDrug like '%" + search + "%' or x.TotalPayment like '%" + search + "%')";
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

        public DataTable getSpesificValuePayment(string idpayment)
        {
            sqlCon = con.openConnection();
            sqlCom = new SqlCommand("select x.Id_Payment, b.Patient_Name, z.DoctorName, a.Diagnose, x.PaymentDoctor, x.PaymentDrug, x.TotalPayment, rec.Id_Recipe from Patient.Treatment a join Patient.Patient b on a.Id_Patient = b.Id_Patient join Patient.Payment x on a.Id_Treatment = x.Id_Treatment join Doctor.Doctor z on z.Id_Doctor = a.Id_Doctor join Recipe.RecipeDetail rec on rec.Id_Recipe = a.Id_Recipe where x.isPay = '0' and x.Id_Payment = '" + idpayment + "'", sqlCon);
            sqlCom.Parameters.AddWithValue("@iddrug", idpayment);
            sqlDa = new SqlDataAdapter(sqlCom);
            sqlDa.Fill(dt);
            sqlCon.Open();
            int i = sqlCom.ExecuteNonQuery();
            sqlCon.Close();
            return dt;
        }

        public void updatePayment(string idpayment, string idrecipe)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "update Patient.Payment set isPay = '1' where Id_Payment = @idpayment";
                sqlCom = new SqlCommand(query, sqlCon);
                using (sqlCom)
                {
                    sqlCom.Parameters.Add(new SqlParameter("@idpayment", idpayment));
                    sqlCom.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "update Recipe.RecipeDetail set isDraft = '1' where Id_Recipe = @idrecipe";
                sqlCom = new SqlCommand(query, sqlCon);
                using (sqlCom)
                {
                    sqlCom.Parameters.Add(new SqlParameter("@idrecipe", idrecipe));
                    sqlCom.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }

        public DataSet getPaymentDetail(string idrecipe)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.DrugName, b.Qty, b.Subtotal from Recipe.RecipeDetail b join Recipe.Drug a on b.Id_Drug = a.Id_Drug where b.Id_Recipe = '" + idrecipe + "'";
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
    }
}