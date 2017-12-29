using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.Controller;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class AddDoctor : System.Web.UI.Page
    {
        string idnya;
        string jeniskelamin;
        DataTable dt = new DataTable();
        string date = DateTime.Now.AddYears(-20).ToString("dd/MM/yyyy");
        DoctorController controller = new DoctorController();
        SpecialistController sc = new SpecialistController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtIdDoctor.Text = controller.AutoGenerateID();
                cekAdd();
                generateDDL();
            }
            if (!isLogin())
            {
                Response.Redirect("~/ui/Login.aspx");
            }
        }

        private void generateDDL()
        {
            DataSet ds = sc.SpecialistData();

            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DDIdSpecialist.Items.Add(ds.Tables[0].Rows[i]["Id_Specialist"].ToString() + " - " + ds.Tables[0].Rows[i]["Specialist"].ToString());
            }
            DDIdSpecialist.DataBind();
        }

        private void cekAdd()
        {
            generateDDL();
            idnya = Request.QueryString["ID"];
            if (Request.QueryString["Status"] == "Update")
            {
                if (Session["access"].ToString().Equals("0"))
                {
                    Response.Redirect("~/ui/Dashboard.aspx");
                }
                if (idnya != "")
                {
                    dt = controller.getDetailDoctor(idnya);
                    txtIdDoctor.Text = idnya;
                    string specialist = dt.Rows[0][1].ToString().Trim() + " - " + dt.Rows[0][2].ToString().Trim();
                    DDIdSpecialist.Items.FindByText(specialist).Selected = true;
                    txtDoctorname.Text = dt.Rows[0][3].ToString();
                    string gender = dt.Rows[0][4].ToString();
                    if(gender == "Male")
                    {
                        RadioMale.Checked = true;
                    }
                    else
                    {
                        RadioMale.Checked = true;
                    }

                    txtDateofbirth.Text = Convert.ToDateTime(dt.Rows[0][5]).ToString("dd/MM/yyyy");
                    txtPhonenumber.Text = dt.Rows[0][6].ToString();
                    tulisanatas.InnerText = "Update Data Doctor";
                    btnSave.Text = "Update";
                    btnSave.CommandName = "Update";
                }
            }
            else if (Request.QueryString["Status"] == "Add")
            {
                txtIdDoctor.Text = controller.AutoGenerateID();
                btnSave.Text = "Save";
                btnSave.CommandName = "Save";
                txtDoctorname.Focus();
            }
            else
            {
                Response.Redirect("~/ui/Doctor.aspx");
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
            string specialist = DDIdSpecialist.Text.Split('-')[0].ToString().Trim();
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
                    if (Request.QueryString["Status"] == "Add")
                    {
                        controller.Save(specialist, txtDoctorname.Text, jeniskelamin, txtDateofbirth.Text, txtPhonenumber.Text);

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                        Response.Redirect("~/ui/Doctor.aspx");
                    }
                    else if (Request.QueryString["Status"] == "Update")
                    {
                        if (controller.Update(Request.QueryString["ID"].ToString(), specialist, txtDoctorname.Text, jeniskelamin, txtDateofbirth.Text, txtPhonenumber.Text))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully')", true);

                            Response.Redirect("~/ui/Doctor.aspx");
                        }
                    }
                }
            }
        }

        private bool validate()
        {
            if (txtDoctorname.Text == "")
            {
                txtDoctorname.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert name doctor')", true);
                return false;
            }
            else if (DDIdSpecialist.Text.Equals("-1"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Specialist')", true);
                return false;
            }
            else if (txtDateofbirth.Text == "" || Regex.IsMatch(txtDateofbirth.Text, @"^\d{1,2}\/\d{1,2}\/\d{4}$") == false || DateTime.Parse(txtDateofbirth.Text) > DateTime.Parse(date))
            {
                txtDateofbirth.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert  doctor more than 20 years')", true);
                return false;
            }
            else if(txtPhonenumber.Text == "" || Regex.IsMatch(txtPhonenumber.Text, @"^62[0-9]{9,11}$") == false)
            {
                txtPhonenumber.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert valid phone number format like 62829908726')", true);
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}