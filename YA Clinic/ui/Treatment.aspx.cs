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
    }
}