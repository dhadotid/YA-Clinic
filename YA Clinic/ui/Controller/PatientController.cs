using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic
{
    public class PatientController
    {
        SqlCommand sqlCom;
        SqlConnection sqlCon;
        SqlDataAdapter sqlDa;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Connection con = new Connection();
        public void Save(string Name, string dob, string Address, string JenisKelamin)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string sql = "exec pcdPatient @name,@dob,@address,@gender";
                sqlCom = new SqlCommand(sql, sqlCon);
                using (sqlCom)
                {
                    sqlCom.Parameters.Add(new SqlParameter("@name", Name));
                    sqlCom.Parameters.Add(new SqlParameter("@dob", dob));
                    sqlCom.Parameters.Add(new SqlParameter("@address", Address));
                    sqlCom.Parameters.Add(new SqlParameter("@gender", JenisKelamin));

                    sqlCom.ExecuteNonQuery();


                }
                sqlCom.Clone();
            }
        }

        public DataTable getDetailPatient(string idpatient)
        {
            sqlCon = con.openConnection();
            sqlCom = new SqlCommand("select * from Patient.Patient where Id_Patient like '" + idpatient + "'", sqlCon);
            sqlDa = new SqlDataAdapter(sqlCom);
            sqlDa.Fill(dt);
            sqlCon.Open();
            int i = sqlCom.ExecuteNonQuery();
            sqlCon.Close();
            return dt;
        }
        public string AutoGenerateID()
        {
            SqlConnection sqlcon = con.openConnection();
            string id = null;

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select top 1 Id_Patient from Patient.Patient order by Id_Patient desc";
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
                            id = "P0000" + a;
                        }
                        else if (a >= 10 && a < 100)
                        {
                            id = "P000" + a;
                        }
                        else if (a >= 100 && a < 1000)
                        {
                            id = "P00" + a;
                        }
                        else if (a >= 1000 && a < 10000)
                        {
                            id = "P0" + a;
                        }
                        else if (a >= 10000 && a < 100000)
                        {
                            id = "P" + a;
                        }
                        else
                        {
                            id = "full";
                        }
                    }
                    else
                    {
                        id = "P00001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

        public DataSet patientData()
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select * from Patient.Patient";
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
                string query = "select * from Patient.Patient where Id_Patient like '%" + search + "%' or Patient_Name like '%" + search + "%' or DateOfBirth like '%" + search + "%' or Address like '%" + search + "%' or GenderPatient like '%" + search + "%'";
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

        public bool deleteData(string idpatient)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                sqlCom = new SqlCommand("delete from Patient.Patient where Id_Patient = '" + idpatient + "'", sqlCon);
                int result = sqlCom.ExecuteNonQuery();
                sqlCon.Close();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
        }
        public bool Update(string idpatient, string patientName, string dateofbirth, string address, string genderpatient)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "exec pcduptPatient @idpatient, @name, @dob, @address, @gender";
                //string query = "update Patient.Patient set Patient_Name = @name, DateOfBirth = @dob, Address = @address, GenderPatient = @gender where Id_Patient = @idpatient";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlCom.Parameters.AddWithValue("@idpatient", idpatient);
                sqlCom.Parameters.AddWithValue("@name", patientName);
                sqlCom.Parameters.AddWithValue("@dob", Convert.ToDateTime(dateofbirth).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@address", address);
                sqlCom.Parameters.AddWithValue("@gender", genderpatient);
                if(sqlCom.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}