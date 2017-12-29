using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class AddRecipe : System.Web.UI.Page
    {
        string drugQty = "", expdate, harga;
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        DataTable dt = new DataTable();
        RecipeController controller = new RecipeController();
        DrugController dc = new DrugController();
        Connection con = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdRecipeDetail.Text = controller.AutoGenerateID();
            lblDrugPrice.Visible = false;
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
                dt = controller.getSpesificValueDrug(txtIdDrug.Text);
                lblDrugPrice.Text = dt.Rows[0][5].ToString();
                drugQty = (rows.FindControl("lblStockDrug") as Label).Text;
                expdate = (rows.FindControl("lblExpDate") as Label).Text;
                // = (rows.FindControl("lblPrice") as Label).Text;
                if (Convert.ToInt32(drugQty) > 1 && Convert.ToInt32(drugQty) < 20)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The remaining drug '" + drugQty +"')", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The remaining drug " + drugQty +"')", true);
                }
                else if(Convert.ToInt32(drugQty) > 0 && Convert.ToInt32(drugQty) < 2)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('drug stocks have been exhausted')", true);
                    txtIdDrug.Text = "";
                }
                dataDrug();
                dataRecipeDrug();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = controller.getSpesificValueDrug(txtIdDrug.Text);
            drugQty = dt.Rows[0][3].ToString();
            if (valid())
            {
                if(Convert.ToInt32(drugQty) < Convert.ToInt32(txtQty.Text)){
                    txtQty.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('less drug')", true);
                }
                else
                {
                    controller.draftData(txtIdRecipe.Text, txtIdDrug.Text, txtQty.Text, txtDose.Text);
                    dataRecipeDrug();
                    txtSearchDrugRecipe.Visible = true;
                    lblDataRecipe.Visible = true;
                }
            }
        }

        protected void gv_RecipeDrug_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idrecipedetail = gv_RecipeDrug.DataKeys[e.RowIndex].Values["Id_RecipeDetail"].ToString();
            if (controller.deleteRecipe(idrecipedetail))
            {
                dataRecipeDrug();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
            }
            else
            {
                dataRecipeDrug();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Failed')", true);
            }
        }

        protected void txtSearchDrugRecipe_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchDrugRecipe.Text != "")
            {
                gv_RecipeDrug.DataSource = controller.searchDataRecipeDrug(txtIdRecipe.Text, txtSearchDrugRecipe.Text);
                gv_RecipeDrug.DataBind();
            }
            else
            {
                dataRecipeDrug();
            }
        }

        protected void txtSearchRecipe_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchRecipe.Text != "")
            {
                gv_Recipe.DataSource = controller.searchonRequestRecipe(txtSearchRecipe.Text);
                gv_Recipe.DataBind();
            }
            else
            {
                dataRecipe();
            }
        }

        protected void txtSearchDrug_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchDrug.Text != "")
            {
                gv_Drug.DataSource = dc.searchDrugData(txtSearchDrug.Text);
                gv_Drug.DataBind();
            }
            else
            {
                dataDrug();
            }
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(lblDrugPrice.Text);
            if (txtQty.Text != "")
            {
                int subtotal = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(price);
                txtSubtotal.Text = string.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", subtotal);
            }
        }

        protected void gv_RecipeDrug_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataRecipeDrug();
            gv_RecipeDrug.PageIndex = e.NewPageIndex;
            gv_RecipeDrug.DataBind();
        }

        private bool valid()
        {
            if(txtIdDrug.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Id Drug from table Drug below')", true);
                return false;
            }else if(txtQty.Text == "" || Regex.IsMatch(txtQty.Text, @"^\d+$") == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert valid qty')", true);
                return false;
            }else if(expdate == date)
            {
                txtIdDrug.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can not save record because drug has been expired')", true);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}