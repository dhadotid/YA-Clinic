using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.Controller;

namespace YA_Clinic.form
{
    public partial class AddSpecialist : System.Web.UI.Page
    {
        SpecialistController controller = new SpecialistController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtIdSpecialist.Text = controller.AutoGenerateID();
            }
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
                    Response.Redirect("~/ui/Dashboard.aspx");
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
            string specialist = txtSpecialist.Text;
            int fare = Convert.ToInt32(txtFare.Text.Trim());

            if (valid())
            {
                if (!controller.specialistAvailable(specialist))
                {
                    controller.Save(specialist, fare);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                    Response.Redirect("~/ui/Specialist.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Failed. Specialist name already available')", true);
                }
            }
        }

        private bool valid()
        {
            if (txtSpecialist.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill in specialist name')", true);
                txtSpecialist.Focus();
                return false;
            }
            else if (txtFare.Text == "" || Regex.IsMatch(txtFare.Text, @"^\d+$") == false || txtFare.Text.Length < 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill in specialist fare correctly')", true);
                txtFare.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}