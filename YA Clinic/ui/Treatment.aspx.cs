using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class Treatment : System.Web.UI.Page
    {
        TreatmentController tc = new TreatmentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                treatmentData();
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
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void treatmentData()
        {
            dgv_Treatment.DataSource = tc.treatmentData();
            dgv_Treatment.DataBind();
        }

        protected void dgv_Treatment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            treatmentData();
            dgv_Treatment.PageIndex = e.NewPageIndex;
            dgv_Treatment.DataBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                dgv_Treatment.DataSource = tc.searchTreatmentData(txtSearch.Text);
                dgv_Treatment.DataBind();
            }
            else
            {
                treatmentData();
            }
        }

        protected void btnAddnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/AddTreatment.aspx");
        }
    }
}