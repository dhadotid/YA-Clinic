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
        DataTable dt = new DataTable();

        public void Save(string idspecialist, string doctorname, string gender, string dob, string phone)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string sql = "exec pcdDoctor @Id_Specialist,@DoctorName,@DoctorGender,@DateOfBirth,@Phone";
                sqlCom = new SqlCommand(sql, sqlCon);
                using (sqlCom)
                {
                    sqlCom.Parameters.Add(new SqlParameter("@Id_Specialist", idspecialist));
                    sqlCom.Parameters.Add(new SqlParameter("@DoctorName", doctorname));
                    sqlCom.Parameters.Add(new SqlParameter("@DoctorGender", gender));
                    sqlCom.Parameters.Add(new SqlParameter("@DateOfBirth", dob));
                    sqlCom.Parameters.Add(new SqlParameter("@Phone", phone));

                    sqlCom.ExecuteNonQuery();


                }
                sqlCom.Clone();
            }
        }

        public DataTable getDetailDoctor(string iddoctor)
        {
            sqlCon = con.openConnection();
            sqlCom = new SqlCommand("select a.Id_Doctor, s.Id_Specialist, s.Specialist, a.DoctorName, a.DoctorGender, a.DateOfBirth, a.Phone from Doctor.Doctor a join Doctor.Specialist s on a.Id_Specialist = s.Id_Specialist where a.Id_Doctor ='" + iddoctor + "'", sqlCon);
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
                string sql = "select top 1 Id_Doctor from Doctor.Doctor order by Id_Doctor desc";
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
                            id = "D0000" + a;
                        }
                        else if (a >= 10 && a < 100)
                        {
                            id = "D000" + a;
                        }
                        else if (a >= 100 && a < 1000)
                        {
                            id = "D00" + a;
                        }
                        else if (a >= 1000 && a < 10000)
                        {
                            id = "D0" + a;
                        }
                        else if (a >= 10000 && a < 100000)
                        {
                            id = "D" + a;
                        }
                        else
                        {
                            id = "full";
                        }
                    }
                    else
                    {
                        id = "D00001";
                    }
                }
                sqlcon.Close();
            }
            return id;
        }

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

        public DataSet searchDoctorData(string search)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "select * from Doctor.Doctor where Id_Doctor like '%" + search + "%' or Id_Specialist like '%" + search + "%' or DoctorName like '%" + search + "%' or DoctorGender like '%" + search + "%' or DateOfBirth like '%" + search + "%' or Phone like '%" + search + "%'";
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

        public bool Update(string iddoctor, string idspecialist, string doctorname, string gender, string dob, string phone)
        {
            sqlCon = con.openConnection();
            using (sqlCon)
            {
                sqlCon.Open();
                string query = "exec pcduptDoctor @iddoctor, @idspecialist, @doctorname, @gender, @dob, @phone";
                //string query = "update Patient.Patient set Patient_Name = @name, DateOfBirth = @dob, Address = @address, GenderPatient = @gender where Id_Patient = @idpatient";
                sqlCom = new SqlCommand(query, sqlCon);
                sqlCom.Parameters.AddWithValue("@iddoctor", iddoctor);
                sqlCom.Parameters.AddWithValue("@idspecialist", idspecialist);
                sqlCom.Parameters.AddWithValue("@doctorname", doctorname);
                sqlCom.Parameters.AddWithValue("@gender", gender);
                sqlCom.Parameters.AddWithValue("@dob", Convert.ToDateTime(dob).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@phone", phone);
                if (sqlCom.ExecuteNonQuery() > 0)
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