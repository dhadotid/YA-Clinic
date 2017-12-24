using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class Drug : System.Web.UI.Page
    {
        DrugController controller = new DrugController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                onRequestData();
            }
        }

        private void onRequestData()
        {
            dgv_Drug.DataSource = controller.drugData();
            dgv_Drug.DataBind();
        }

        protected void dgv_Drug_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            onRequestData();
            dgv_Drug.PageIndex = e.NewPageIndex;
            dgv_Drug.DataBind();
        }
    }
}