using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DashboardController controller = new DashboardController();
        protected void Page_Load(object sender, EventArgs e)
        {
            setGrid();
            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
        }

        private bool isLogin()
        {
            if (Session["nama"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void setGrid()
        {
            registeredPatient.InnerText = controller.jumlahPatient().ToString();
            theDoctor.InnerText = controller.jumlahDoctor().ToString();
            drugAvaible.InnerText = controller.jumlahDrug().ToString();
            patientAlreadyPayment.InnerText = controller.jumlahPayment().ToString();
        }
    }
}