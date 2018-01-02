using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class PaymentDetail : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        PaymentController controller = new PaymentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                getData();
            }
        }

        private void getData()
        {
            string litelarHeader = "";
            string litelarBody = "";
            string idPayment = Request.QueryString["IdPayment"];
            string patientName = Request.QueryString["PatientName"];
            string doctorName = Request.QueryString["DoctorName"];
            string paymentDoctor = Request.QueryString["PaymentDoctor"];
            string paymentDrug = Request.QueryString["PaymentDrug"];
            string total = Request.QueryString["Total"];
            string money = Request.QueryString["Money"];
            string change = Request.QueryString["Change"];
            string idRecipe = Request.QueryString["IdRecipe"];

            litelarHeader += "Invoice: " + idPayment + "<br/>";
            litelarHeader += "Patient Name: " + patientName + "<br/>";
            litelarHeader += "Doctor Name: " + doctorName + "<br/>";
            LitelarHeader.Text = litelarHeader;

            ds = controller.getPaymentDetail(idRecipe);
            int a = ds.Tables[0].Rows.Count;
            for(int i = 0; i < a; i++)
            {
                string drugName = ds.Tables[0].Rows[i]["DrugName"].ToString();
                string qty = ds.Tables[0].Rows[i]["Qty"].ToString();
                string subTotal = ds.Tables[0].Rows[i]["Subtotal"].ToString();

                double doubleSub = Convert.ToDouble(subTotal);

                subTotal = string.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", doubleSub);

                litelarBody += "<tr class='service'>";
                litelarBody += "<td class='tableitem'><p class='itemtext'>" + drugName + "</p></td>";
                litelarBody += "<td class='tableitem'><p class='itemtext'>" + qty + "</p></td>";
                litelarBody += "<td class='tableitem'><p class='itemtext'>" + subTotal + "</p></td>";
                LiteralDetailTransaction.Text = litelarBody;
            }

            lblPaymentDrug.InnerText = paymentDrug;
            lblPaymentDoctor.InnerText = paymentDoctor;
            lblTotalPayment.InnerText = total;
            lblMoney.InnerText = money;
            lblChange.InnerText = change;
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
    }
}