using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic.ui.Controller
{
    public class TreatmentController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataSet ds = new DataSet();
        DataSet dsd = new DataSet();
        DataSet dsTreat = new DataSet();
        Connection con = new Connection();

        public void Save(string idpatient, string iddoctor, string diagnose)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string sql = "exec pcdTreatment @idpatient,@iddoctor,@diagnose";
                sqlCom = new SqlCommand(sql, sqlCon);
                using (sqlCom)
                {
                    sqlCom.Parameters.Add(new SqlParameter("@idpatient", idpatient));
                    sqlCom.Parameters.Add(new SqlParameter("@iddoctor", iddoctor));
                    sqlCom.Parameters.Add(new SqlParameter("@diagnose", diagnose));

                    sqlCom.ExecuteNonQuery();


                }
                sqlCom.Clone();
            }
        }

        public DataSet patientData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select Id_Patient, Patient_Name from Patient.Patient";
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

        public DataSet searchPatientData(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select Id_Patient, Patient_Name from Patient.Patient where Id_Patient like '%" + search + "%' or  Patient_Name like '%" + search + "%' order by Patient_Name asc";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                sqlCon.Close();
                if(ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            return ds;
        }

        public DataSet doctorData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_Doctor, a.DoctorName, b.Specialist, b.Fare from Doctor.Doctor a join Doctor.Specialist b on a.Id_Specialist = b.Id_Specialist";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(dsd);
                int count = dsd.Tables[0].Rows.Count;
                sqlCon.Close();
                if (dsd.Tables[0].Rows.Count > 0)
                {
                    return dsd;
                }
            }
            return dsd;
        }

        public DataSet searchDoctorData(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_Doctor, a.DoctorName, b.Specialist, b.Fare from Doctor.Doctor a join Doctor.Specialist b on a.Id_Specialist = b.Id_Specialist where a.Id_Doctor like '%" + search + "%' or a.DoctorName like '%" + search + "%' or b.Specialist like '%" + search + "%' or b.Fare like '%" + search + "' order by a.DoctorName asc";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(dsd);
                int count = dsd.Tables[0].Rows.Count;
                sqlCon.Close();
                if (dsd.Tables[0].Rows.Count > 0)
                {
                    return dsd;
                }
            }
            return dsd;
        }

        public string AutoGenerateID()
        {
            Connection con = new Connection();
            SqlConnection sqlcon = con.openConnection();
            string id = null;

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select top 1 Id_Treatment from Patient.Treatment order by Id_Treatment desc";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr.GetString(0);
                        string sub = id.Substring(1);
                        int a = Convert.ToInt32(sub) + 1;
                        if (a < 10)
                        {
                            id = "T0000" + a;
                        }
                        else if (a >= 10 && a < 100)
                        {
                            id = "T000" + a;
                        }
                        else if (a >= 100 && a < 1000)
                        {
                            id = "T00" + a;
                        }
                        else if (a >= 1000 && a < 10000)
                        {
                            id = "T0" + a;
                        }
                        else if (a >= 10000 && a < 100000)
                        {
                            id = "T" + a;
                        }
                        else
                        {
                            id = "full";
                        }
                    }
                    else
                    {
                        id = "T00001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

        public string AutoGenerateIDRecipe()
        {
            Connection con = new Connection();
            SqlConnection sqlcon = con.openConnection();
            string id = null;

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select top 1 Id_Recipe from Recipe.Recipe order by Id_Recipe desc";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        id = dr.GetString(0);
                        string sub = id.Substring(1);
                        int a = Convert.ToInt32(sub) + 1;
                        if (a < 10)
                        {
                            id = "R0000" + a;
                        }
                        else if (a >= 10 && a < 100)
                        {
                            id = "R000" + a;
                        }
                        else if (a >= 100 && a < 1000)
                        {
                            id = "R00" + a;
                        }
                        else if (a >= 1000 && a < 10000)
                        {
                            id = "R0" + a;
                        }
                        else if (a >= 10000 && a < 100000)
                        {
                            id = "R" + a;
                        }
                        else
                        {
                            id = "full";
                        }
                    }
                    else
                    {
                        id = "R00001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

        public DataSet treatmentData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_Treatment as Id_Treatment, b.Patient_Name as Patient_Name, c.DoctorName as DoctorName, a.Id_Recipe as Id_Recipe, a.Diagnose as Diagnose, a.DateTreatment as DateTreatment from Patient.Treatment a join Patient.Patient b on a.Id_Patient = b.Id_Patient join Doctor.Doctor c on a.Id_Doctor = c.Id_Doctor";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(dsTreat);
                int count = dsTreat.Tables[0].Rows.Count;
                sqlCon.Close();
                if (dsTreat.Tables[0].Rows.Count > 0)
                {
                    return dsTreat;
                }
                return dsTreat;
            }
        }

        public DataSet searchTreatmentData(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select a.Id_Treatment, b.Patient_Name, c.DoctorName, a.Id_Recipe, a.Diagnose, a.DateTreatment from Patient.Treatment a join Patient.Patient b on a.Id_Patient = b.Id_Patient join Doctor.Doctor c on a.Id_Doctor = c.Id_Doctor where a.Id_Treatment like '%" + search + "%' or b.Patient_Name like '%" + search + "%' or c.DoctorName like '%" + search + "%' or a.Id_Recipe like '%" + search + "%' or a.Diagnose like '%" + search + "%' or a.DateTreatment like '%" + search + "%'";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlDa = new SqlDataAdapter(sqlCom);
                sqlDa.Fill(dsTreat);
                int count = dsTreat.Tables[0].Rows.Count;
                sqlCon.Close();
                if (dsTreat.Tables[0].Rows.Count > 0)
                {
                    return dsTreat;
                }
                return dsTreat;
            }
        }
    }
}