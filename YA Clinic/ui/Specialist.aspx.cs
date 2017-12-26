using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.Controller;

namespace YA_Clinic
{
    public partial class Schedule : System.Web.UI.Page
    {
        SpecialistController sc = new SpecialistController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SpecialistData();
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

        protected void SpecialistData()
        {
            gv_Specialist.DataSource = sc.SpecialistData();
            gv_Specialist.DataBind();
        }

        protected void gv_Specialist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idSpecialist = gv_Specialist.DataKeys[e.RowIndex].Values["Id_Specialist"].ToString();
            if (sc.deleteData(idSpecialist))
            {
                SpecialistData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
            }
        }

        protected void gv_Specialist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SpecialistData();
            gv_Specialist.PageIndex = e.NewPageIndex;
            gv_Specialist.DataBind();
        }

        protected void btnAddnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/AddSpecialist.aspx");
        }
    }
}