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

        protected void btnAddnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ui/AddDrug.aspx");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                dgv_Drug.DataSource = controller.searchDrugData(txtSearch.Text);
                dgv_Drug.DataBind();
            }
            else
            {
                onRequestData();
            }
        }
    }
}