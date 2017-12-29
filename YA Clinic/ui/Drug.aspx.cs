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
            string status = "Add";
            Response.Redirect("~/ui/AddDrug.aspx?Status=" + status);
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

        protected void dgv_Drug_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idDrug = dgv_Drug.DataKeys[e.RowIndex].Values["Id_Drug"].ToString();
            if (controller.deleteData(idDrug))
            {
                onRequestData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
            }
        }

        protected void dgv_Drug_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string status = "Update";
            if (e.CommandName == "Update")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string idDrug = dgv_Drug.DataKeys[row.RowIndex].Value.ToString();
                Response.Redirect("~/ui/AddDrug.aspx?Status=" + status + "&ID=" + idDrug);
            }
        }
    }
}