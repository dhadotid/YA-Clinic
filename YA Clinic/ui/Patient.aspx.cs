using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YA_Clinic
{
    public partial class Patient : System.Web.UI.Page
    {
        PatientController cp = new PatientController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                patientData();
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
                    
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public void patientData()
        {
            dgv_Patient.DataSource = cp.patientData();
            dgv_Patient.DataBind();
        }

        protected void dgv_Patient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            patientData();
            dgv_Patient.PageIndex = e.NewPageIndex;
            dgv_Patient.DataBind();
        }

        protected void dgv_Patient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idpatient = dgv_Patient.DataKeys[e.RowIndex].Values["Id_Patient"].ToString();
            if (cp.deleteData(idpatient))
            {
                patientData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
            }
        }
    }
}