using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YA_Clinic
{
    public partial class PatientDetail : System.Web.UI.Page
    {
        string jeniskelamin = "";
        string idnya;
        DataTable dt = new DataTable();
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        PatientController controller = new PatientController();

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
            if (Request.QueryString["Status"] == "Update")
            {
                if (Session["access"].ToString().Equals("0"))
                {
                    Response.Redirect("~/ui/Dashboard.aspx");
                }
                if (idnya != "")
                {
                    dt = controller.getDetailPatient(idnya);
                    idpatient.Text = idnya;
                    txtname.Text = dt.Rows[0][1].ToString();
                    txtdob.Text = Convert.ToDateTime(dt.Rows[0][2]).ToString("dd/MM/yyyy");
                    txtaddress.Text = dt.Rows[0][3].ToString();
                    if (dt.Rows[0][4].ToString().Trim() == "Male")
                    {
                        RadioMale.Checked = true;
                    }
                    else if (dt.Rows[0][4].ToString().Trim() == "Female")
                    {
                        RadioFemale.Checked = true;
                    }
                    tulisanatas.InnerText = "Update Data Patient";
                    btnSave.Text = "Update";
                    btnSave.CommandName = "Update";                    
                }
            }
            else if (Request.QueryString["Status"] == "Add")
            {
                idpatient.Text = controller.AutoGenerateID();
                btnSave.Text = "Save";
                btnSave.CommandName = "Save";
                txtname.Focus();
            }
            else
            {
                Response.Redirect("~/ui/Patient.aspx");
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (RadioMale.Checked)
                {
                    jeniskelamin = "Male";
                }
                else if (RadioFemale.Checked)
                {
                    jeniskelamin = "Female";
                }

                if (jeniskelamin == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select gender')", true);
                }
                else
                {
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' '" + idpatient.Text + txtname.Text + txtdob.Text + txtaddress.Text + "')", true);
                    if (Request.QueryString["Status"] == "Add")
                    {
                        controller.Save(txtname.Text, txtdob.Text, txtaddress.Text, jeniskelamin);
                        // controller.Save("ABC", txtdob.Text, txtaddress.Text, jeniskelamin);

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                        Response.Redirect("~/ui/Patient.aspx");
                    }
                    else if (Request.QueryString["Status"] == "Update")
                    {
                        if(controller.Update(Request.QueryString["ID"].ToString(), txtname.Text, txtdob.Text, txtaddress.Text, jeniskelamin))
                        {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully')", true);

                        Response.Redirect("~/ui/Patient.aspx");
                        }
                    }
                }
            }
        }

        private bool validate()
        {
            if(txtname.Text == "")
            {
                txtname.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert name')", true);
                return false;
            }else if(txtaddress.Text == "")
            {
                txtaddress.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert address')", true);
                return false;
            }else if(txtdob.Text == "" || Regex.IsMatch(txtdob.Text, @"^\d{1,2}\/\d{1,2}\/\d{4}$") == false || DateTime.Parse(txtdob.Text) > DateTime.Parse(date))
            {
                txtdob.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert valid date of birth ex: 01/01/1998')", true);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}