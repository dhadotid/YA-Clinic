using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YA_Clinic
{
    public partial class PatientDetail : System.Web.UI.Page
    {
        string jeniskelamin = "";
        string idnya;
        DataTable dt = new DataTable();
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        PatientController controller = new PatientController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
            cekAdd();
        }

        private void cekAdd()
        {
            idnya = Request.QueryString["ID"];
            if (Request.QueryString["Status"] == "Update")
            {
                if (Session["access"].ToString().Equals("0"))
                {
                    Response.Redirect("~/ui/Dashboard.aspx");
                }
                if (idnya != "")
                {
                    dt = controller.getDetailPatient(idnya);
                    idpatient.Value = idnya;
                    txtname.Value = dt.Rows[0][1].ToString();
                    txtdob.Value = Convert.ToDateTime(dt.Rows[0][2]).ToString("dd/MM/yyyy");
                    txtaddress.Value = dt.Rows[0][3].ToString();
                    if (dt.Rows[0][4].ToString() == "Male")
                    {
                        RadioMale.Checked = true;
                    }
                    else if (dt.Rows[0][4].ToString() == "Female")
                    {
                        RadioFemale.Checked = true;
                    }
                    tulisanatas.InnerText = "Update Data Patient";
                    btnSave.Text = "Update";
                    btnSave.CommandName = "Update";
                }
            }
            else if (Request.QueryString["Status"] == "Add")
            {
                idpatient.Value = controller.AutoGenerateID();
                txtname.Focus();
            }
        }
        
        private bool isLogin()
        {
            if (Session["nama"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                string ID = idpatient.Value;
                string name = txtname.Value;
                string dob = txtdob.Value;
                string address = txtaddress.Value;
                if (RadioMale.Checked)
                {
                    jeniskelamin = "Male";
                }
                else if (RadioFemale.Checked)
                {
                    jeniskelamin = "Female";
                }
                if(jeniskelamin == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select gender')", true);
                }
                else
                {
                    if(btnSave.CommandName == "Save")
                    {
                        controller.Save(name, dob, address, jeniskelamin);

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                        Response.Redirect("~/ui/Patient.aspx");
                    }
                    else if(btnSave.CommandName == "Update")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updatenya belum dicoding')", true);
                    }
                }
            }
        }

        private bool validate()
        {
            if(txtname.Value == "")
            {
                txtname.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert name')", true);
                return false;
            }else if(txtaddress.Value == "")
            {
                txtaddress.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert address')", true);
                return false;
            }else if(txtdob.Value == "" || Regex.IsMatch(txtdob.Value, @"^\d{1,2}\/\d{1,2}\/\d{4}$") == false || DateTime.Parse(txtdob.Value) > DateTime.Parse(date))
            {
                txtdob.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert valid date of birth ex: 01/01/1998')", true);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}