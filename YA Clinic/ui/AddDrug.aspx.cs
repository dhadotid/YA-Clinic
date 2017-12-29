using System;
using System.Collections.Generic;
using System.Data;
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
        string idnya;
        DataTable dt = new DataTable();
        DrugController controller = new DrugController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtIdDrug.Text = controller.AutoGenerateID();
                cekAdd();
            }
            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
        }

        private void cekAdd()
        {
            idnya = Request.QueryString["ID"];
            if (Request.QueryString["Status"] == "Update")
            {
                if (Session["access"].ToString().Equals("0"))
                {
                    Response.Redirect("~/ui/Dashboard.aspx");
                }
                if (idnya != "")
                {
                    dt = controller.getDetailDrug(idnya);
                    txtIdDrug.Text = idnya;
                    txtDrugName.Text = dt.Rows[0][1].ToString();
                    string drugType = dt.Rows[0][2].ToString().Trim();
                    DDdrugType.Items.FindByText(drugType).Selected = true;
                    txtStock.Text = dt.Rows[0][3].ToString();
                    txtExpDate.Text = Convert.ToDateTime(dt.Rows[0][4]).ToString("dd/MM/yyyy");
                    double price = Convert.ToDouble(dt.Rows[0][5].ToString());
                    txtPrice.Text = Convert.ToInt32(price).ToString();
                    tulisanatas.InnerText = "Update Data Patient";
                    btnSave.Text = "Update";
                    btnSave.CommandName = "Update";
                }
            }
            else if (Request.QueryString["Status"] == "Add")
            {
                txtIdDrug.Text = controller.AutoGenerateID();
                btnSave.Text = "Save";
                btnSave.CommandName = "Save";
                txtDrugName.Focus();
            }
            else
            {
                Response.Redirect("~/ui/AddDrug.aspx");
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
            string date = DateTime.Now.AddDays(+5).ToString("dd/MM/yyyy");
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
                if(btnSave.CommandName == "Save")
                {
                    controller.Save(txtDrugName.Text, DDdrugType.Text, txtStock.Text, txtExpDate.Text, txtPrice.Text);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                    Response.Redirect("~/ui/Drug.aspx");
                }else if(btnSave.CommandName == "Update")

                    if (controller.Update(Request.QueryString["ID"].ToString(), txtDrugName.Text, DDdrugType.Text, txtStock.Text, txtExpDate.Text, txtPrice.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully')", true);

                        Response.Redirect("~/ui/Drug.aspx");
                    }
            }
        }
    }
}