using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class Payment : System.Web.UI.Page
    {
        PaymentController controller = new PaymentController();
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
            dgv_Payment.DataSource = controller.paymentData();
            dgv_Payment.DataBind();
        }

        protected void dgv_Payment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            onRequestData();
            dgv_Payment.PageIndex = e.NewPageIndex;
            dgv_Payment.DataBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                dgv_Payment.DataSource = controller.searchPaymentData(txtSearch.Text);
                dgv_Payment.DataBind();
            }
            else
            {
                onRequestData();
            }
        }
    }
}