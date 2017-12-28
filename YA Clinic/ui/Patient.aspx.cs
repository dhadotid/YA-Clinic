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
                    dgv_Patient.Columns[5].Visible = false;
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

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                dgv_Patient.DataSource = cp.searchPatientData(txtSearch.Text);
                dgv_Patient.DataBind();
            }
            else
            {
                patientData();
            }
        }

        protected void dgv_Patient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string status = "Update";
            if(e.CommandName == "Update")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string idPatient = dgv_Patient.DataKeys[row.RowIndex].Value.ToString();
                Response.Redirect("~/ui/PatientDetail.aspx?Status="+ status + "&ID=" + idPatient);
            }
        }

        protected void btnAddnNew_Click(object sender, EventArgs e)
        {
            string status = "Add";
            Response.Redirect("~/ui/PatientDetail.aspx?Status=" + status);
        }
    }
}