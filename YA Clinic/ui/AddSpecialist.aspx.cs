using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.Controller;

namespace YA_Clinic.form
{
    public partial class AddSpecialist : System.Web.UI.Page
    {
        string idnya;
        DataTable dt = new DataTable();
        SpecialistController controller = new SpecialistController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                cekAdd();
            }
        }

        private void cekAdd()
        {
            idnya = Request.QueryString["ID"];
            double fare;
            if (Request.QueryString["Status"] == "Update")
            {
                if (Session["access"].ToString().Equals("0"))
                {
                    Response.Redirect("~/ui/Dashboard.aspx");
                }
                if (idnya != "")
                {
                    dt = controller.getDetailSpecilaist(idnya);
                    txtIdSpecialist.Text = dt.Rows[0][0].ToString();
                    txtSpecialist.Text = dt.Rows[0][1].ToString();
                    fare = Convert.ToDouble(dt.Rows[0][2].ToString());
                    txtFare.Text = Convert.ToInt32(fare).ToString();
                    tulisanatas.InnerText = "Update Data Specialist";
                    btnSave.Text = "Update";
                    btnSave.CommandName = "Update";
                }
            }
            else if (Request.QueryString["Status"] == "Add")
            {
                txtIdSpecialist.Text = controller.AutoGenerateID();
                btnSave.Text = "Save";
                btnSave.CommandName = "Save";
                txtSpecialist.Focus();
            }
            else
            {
                Response.Redirect("~/ui/Specialist.aspx");
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string specialist = txtSpecialist.Text;
            int fare = Convert.ToInt32(txtFare.Text.Trim());
            
            if (valid())
            {
                if(btnSave.CommandName == "Save")
                {
                    if (!controller.specialistAvailable(specialist))
                    {
                        controller.Save(specialist, fare);

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                        Response.Redirect("~/ui/Specialist.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Failed. Specialist name already available')", true);
                    }
                }
                else if (btnSave.CommandName == "Update")
                {
                    if (controller.Update(Request.QueryString["ID"].ToString(), specialist, fare))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully')", true);

                        Response.Redirect("~/ui/Specialist.aspx");
                    }
                }
            }
        }

        private bool valid()
        {
            if (txtSpecialist.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill in specialist name')", true);
                txtSpecialist.Focus();
                return false;
            }
            else if (txtFare.Text == "" || Regex.IsMatch(txtFare.Text, @"^\d+$") == false || txtFare.Text.Length < 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill in specialist fare correctly')", true);
                txtFare.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}