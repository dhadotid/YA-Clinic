using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.model;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class AddPayment : System.Web.UI.Page
    {
        string idpayment;
        double totalPayment;
        double paymentDrug;
        double paymentDoctor;
        DataTable dt = new DataTable();
        PaymentController controller = new PaymentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdRecipe.Visible = false;
            if (!Page.IsPostBack)
            {
                loadTablePayment();
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
                    
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                if(txtChange.Text != "")
                {
                    controller.updatePayment(txtIdPayment.Text, txtIdRecipe.Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record saved Successfully')", true);
                }
            }
            loadTablePayment();
        }

        protected void dgv_Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rows = dgv_Payment.SelectedRow;
            if (rows != null)
            {
                idpayment = (rows.FindControl("lblIdPayment") as Label).Text;
            }
            dt = controller.getSpesificValuePayment(idpayment);
            txtIdPayment.Text = dt.Rows[0][0].ToString();
            txtPatientName.Text = dt.Rows[0][1].ToString();
            txtDoctorName.Text = dt.Rows[0][2].ToString();
            txtDiagnose.Text = dt.Rows[0][3].ToString();
            txtPaymentDoctor.Text = dt.Rows[0][4].ToString();
            txtPaymentDrug.Text = dt.Rows[0][5].ToString();
            txtTotalPayment.Text = dt.Rows[0][6].ToString();
            txtIdRecipe.Text = dt.Rows[0][7].ToString();

            lblTotalPayment.Text = txtTotalPayment.Text;
            //helperModel = new PaymentHelperModel(Convert.ToDouble(dt.Rows[0][6].ToString()));

            paymentDoctor = Convert.ToDouble(txtPaymentDoctor.Text);
            paymentDrug = Convert.ToDouble(txtPaymentDrug.Text);
            totalPayment = Convert.ToDouble(txtTotalPayment.Text);
            
            txtPaymentDoctor.Text = string.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", paymentDoctor);
            txtPaymentDrug.Text = string.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", paymentDrug);
            txtTotalPayment.Text = string.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", totalPayment);
        }

        private bool valid()
        {
            if(txtIdPayment.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Id Payment from below table')", true);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void loadTablePayment()
        {
            dgv_Payment.DataSource = controller.paymentIsNotyetPay();
            dgv_Payment.DataBind();
        }

        protected void dgv_Payment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadTablePayment();
            dgv_Payment.PageIndex = e.NewPageIndex;
            dgv_Payment.DataBind();
        }

        protected void txtSearchPayment_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchPayment.Text != "")
            {
                dgv_Payment.DataSource = controller.searchPaymentIsNotyetPay(txtSearchPayment.Text);
                dgv_Payment.DataBind();
            }
            else
            {
                loadTablePayment();
            }
        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if(txtMoney.Text != "")
            {
                double money = Convert.ToDouble(txtMoney.Text);
                if(money < Convert.ToDouble(lblTotalPayment.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Money less')", true);
                }
                else
                {
                    double change = money - Convert.ToDouble(lblTotalPayment.Text);
                    txtMoney.Text = string.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", money);
                    txtChange.Text = string.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", change);
                }
                //txtChange.Text = change.ToString();
            }
        }
    }
}