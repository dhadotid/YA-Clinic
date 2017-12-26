using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class AddTreatment : System.Web.UI.Page
    {
        string idPatient;
        string idDoctor;
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        TreatmentController controller = new TreatmentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdTreatment.Text = controller.AutoGenerateID();
            txtIdRecipe.Text = controller.AutoGenerateIDRecipe();
            txtDateTreatment.Text = date;
            
            if (!Page.IsPostBack)
            {
                doctorData();
                patientData();
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
                    //Response.Redirect("~/ui/Dashboard.aspx");
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void patientData()
        {
            dgv_Patient.DataSource = controller.patientData();
            dgv_Patient.DataBind();
        }

        private void doctorData()
        {
            dgv_Doctor.DataSource = controller.doctorData();
            dgv_Doctor.DataBind();
        }

        protected void dgv_Patient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            patientData();
            dgv_Patient.PageIndex = e.NewPageIndex;
            dgv_Patient.DataBind();
        }

        protected void dgv_Doctor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            doctorData();
            dgv_Doctor.PageIndex = e.NewPageIndex;
            dgv_Doctor.DataBind();
        }

        protected void dgv_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rows = dgv_Doctor.SelectedRow;
            if (rows != null)
            {
                idDoctor = (rows.FindControl("lblIdDoctor") as Label).Text;
            }
            setUp(1);
        }
        protected void dgv_Patient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "YudhaGanteng")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                idPatient = dgv_Patient.DataKeys[row.RowIndex].Value.ToString();
            }
            setUp(2);
        }

        private void setUp(int code)
        {
            if(code == 1)
            {
                txtIdDoctor.Text = idDoctor;
            }else if(code == 2)
            {
                txtIdPatient.Text = idPatient;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                controller.Save(txtIdPatient.Text, txtIdDoctor.Text, txtDiagnose.Text);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                Response.Redirect("~/ui/Treatment.aspx");
            }
        }

        private bool valid()
        {
            if(txtIdPatient.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select patient id from the table')", true);
                return false;
            }else if(txtIdDoctor.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select doctor id from the table')", true);
                return false;
            }else if(txtDiagnose.Text == "")
            {
                txtDiagnose.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert diagnose')", true);
                return false;
            }
            return true;
        }
    }
}