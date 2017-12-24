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
        }

        private void doctorData()
        {
            dgv_Doctor.DataSource = dc.doctorData(); ;
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
        }
    }
}