using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.form
{
    public partial class Doctor : System.Web.UI.Page
    {
        DoctorController dc = new DoctorController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                doctorData();
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
                    btnAddnNew.Visible = false;
                    dgv_Doctor.Columns[6].Visible = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void doctorData()
        {
            dgv_Doctor.DataSource = dc.doctorData();
            dgv_Doctor.DataBind();
        }

        protected void dgv_Doctor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            doctorData();
            dgv_Doctor.PageIndex = e.NewPageIndex;
            dgv_Doctor.DataBind();
        }

        protected void dgv_Doctor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string iddoctor = dgv_Doctor.DataKeys[e.RowIndex].Values["Id_Doctor"].ToString();
            if (dc.deleteData(iddoctor))
            {
                doctorData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Failed')", true);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                dgv_Doctor.DataSource = dc.searchDoctorData(txtSearch.Text);
                dgv_Doctor.DataBind();
            }
            else
            {
                doctorData();
            }
        }

        protected void btnAddnNew_Click(object sender, EventArgs e)
        {
            string status = "Add";
            Response.Redirect("~/ui/AddDoctor.aspx?Status=" + status);
        }

        protected void dgv_Doctor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string status = "Update";
            if (e.CommandName == "Update")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string idDoctor = dgv_Doctor.DataKeys[row.RowIndex].Value.ToString();
                Response.Redirect("~/ui/AddDoctor.aspx?Status=" + status + "&ID=" + idDoctor);
            }
        }
    }
}