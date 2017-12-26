using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class AddDrug : System.Web.UI.Page
    {
        DrugController controller = new DrugController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtIdDrug.Text = controller.AutoGenerateID();
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
                    Response.Redirect("~/ui/Dashboard.aspx");
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool valid()
        {
            string date = DateTime.Now.AddDays(+5).ToString("yyyy-MM-dd");
            if (txtDrugName.Text == "")
            {
                txtDrugName.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert drug name')", true);
                return false;
            } else if (DDdrugType.Text.Equals("-1"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select drug type')", true);
                return false;
            }else if(txtExpDate.Text == "" || Regex.IsMatch(txtExpDate.Text, @"^\d{1,2}\/\d{1,2}\/\d{4}$") == false || DateTime.Parse(txtExpDate.Text) < DateTime.Parse(date))
            {
                txtExpDate.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert expired drug more than 5 day')", true);
                return false;
            }
            else if(txtStock.Text == "" || Regex.IsMatch(txtStock.Text, @"^\d+$") == false)
            {
                txtStock.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert valid drug stock')", true);
                return false;
            }else if(txtPrice.Text == "" || Regex.IsMatch(txtPrice.Text, @"^\d+$") == false || txtPrice.Text.Length < 2)
            {
                txtPrice.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert valid drug price')", true);
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                controller.Save(txtDrugName.Text, DDdrugType.Text, txtStock.Text, txtExpDate.Text, txtPrice.Text);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                Response.Redirect("~/ui/Drug.aspx");
            }
        }
    }
}