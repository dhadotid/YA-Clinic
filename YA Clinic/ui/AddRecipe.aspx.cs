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
    public partial class AddRecipe : System.Web.UI.Page
    {
        RecipeController controller = new RecipeController();
        DrugController dc = new DrugController();
        Connection con = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdRecipeDetail.Text = controller.AutoGenerateID();
            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                dataDrug();
                dataRecipe();
            }

            txtSearchDrugRecipe.Visible = false;
            lblDataRecipe.Visible = false;
        }

        private bool isLogin()
        {
            if (Session["nama"] != null)
            {
                if (Session["access"].ToString().Equals("0"))
                {
                    //Response.Redirect("~/ui/Dashboard.aspx");
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dataRecipeDrug()
        {
            txtSearchDrugRecipe.Visible = true;
            lblDataRecipe.Visible = true;
            gv_RecipeDrug.DataSource = controller.dataRecipeDrug(txtIdRecipe.Text);
            gv_RecipeDrug.DataBind();
        }

        private void dataDrug()
        {
            gv_Drug.DataSource = dc.drugData();
            gv_Drug.DataBind();
        }

        private void dataRecipe()
        {
            gv_Recipe.DataSource = controller.onRequestRecipe();
            gv_Recipe.DataBind();
        }

        protected void gv_Recipe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataRecipe();
            gv_Recipe.PageIndex = e.NewPageIndex;
            gv_Recipe.DataBind();
        }

        protected void gv_Drug_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataDrug();
            gv_Drug.PageIndex = e.NewPageIndex;
            gv_Drug.DataBind();
        }

        protected void gv_Recipe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "YudhaGanteng")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                txtIdRecipe.Text = gv_Recipe.DataKeys[row.RowIndex].Value.ToString();
                dataRecipeDrug();
            }
        }

        protected void gv_Drug_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rows = gv_Drug.SelectedRow;
            if (rows != null)
            {
                txtIdDrug.Text = (rows.FindControl("lblIdDrug") as Label).Text;
                dataRecipeDrug();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            controller.draftData(txtIdRecipe.Text, txtIdDrug.Text, txtQty.Text, txtDose.Text);
            dataRecipeDrug();
            txtSearchDrugRecipe.Visible = true;
            lblDataRecipe.Visible = true;
        }

        protected void gv_RecipeDrug_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            /*
            int index = Convert.ToInt32(e.RowIndex);
            controller.deleteDataRecipeDrug(index);
            gv_RecipeDrug.DataSource = controller.dataRecipeDrug();
            */
            //DataTable dt = ViewState["dt"] as DataTable;
            //dt.Rows[index].Delete();
            //ViewState["dt"] = dt;
            //gv_RecipeDrug.DataSource = dt;
            //gv_RecipeDrug.DataBind();
        }
    }
}