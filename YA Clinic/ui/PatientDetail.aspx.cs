using System;
using System.Collections.Generic;
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
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        PatientController controller = new PatientController();

        protected void Page_Load(object sender, EventArgs e)
        {
            idpatient.Value = controller.AutoGenerateID();
            txtname.Focus();

            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
        }

        private bool isLogin()
        {
            if (Session["nama"] != null)
            {
                if (Session["access"].ToString().Equals("0"))
                {
                    
                }
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
                    controller.Save(name, dob, address, jeniskelamin);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                    Response.Redirect("~/ui/Patient.aspx");
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