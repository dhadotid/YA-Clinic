using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic
{
    public partial class Login : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        LoginController controller = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            if(Session["nama"] != null && Session["access"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
            if (valid())
            {
                dt = controller.loginCallback(txtUsername.Text, txtPassword.Text);
                if (dt.Rows.Count > 0)
                {
                    Session["nama"] = txtUsername.Text;
                    Session["access"] = dt.Rows[0][3];
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblWrong.Visible = true;
                }
            }
        }

        private bool valid()
        {
            if(txtUsername.Text == "")
            {
                txtUsername.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert username')", true);
                return false;
            }else if(txtPassword.Text == "")
            {
                txtPassword.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert password')", true);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}