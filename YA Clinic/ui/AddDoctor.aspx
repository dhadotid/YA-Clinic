<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddDoctor.aspx.cs" Inherits="YA_Clinic.ui.AddDoctor" %>

<asp:Content ID="contentadddoctor" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-3">
            <div class="custom">
                <br>
                <br>

                <center>
                <h2 id="tulisanatas" runat="server">Add New Data Doctor</h2>
                </center>
                <hr>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdDoctor">Id Doctor</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtIdDoctor" runat="server" placeholder="Id Doctor" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                    </fieldset>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="DDIdSpecialist">ID Specialist</label>
                  <div class="col-md-9">
                    <asp:DropDownList ID="DDIdSpecialist" runat="server" CssClass="form-control">
                        <asp:ListItem Enabled="true" Text="Select Specialist" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDoctorname">Doctor Name</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDoctorname" runat="server" placeholder="Doctorname" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="gender">Gender</label>
                  <div class="col-md-9">
                    <div class="form-check">
                      <label class="form-check-label" id="gender" name="gender">
                        <input class="form-check-input" type="radio" runat="server" name="GenderRadio" id="RadioMale" value="Male">
                        Male
                      </label>
                    </div>
                    <div class="form-check">
                      <label class="form-check-label">
                        <input class="form-check-input" type="radio" runat="server" name="GenderRadio" id="RadioFemale" value="Female">
                        Female
                      </label>
                    </div>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDateofbirth">Date of Birth</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDateofbirth" runat="server" placeholder="Please insert Date of birth format dd/MM/yyyy" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtPhonenumber">Phone Number</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtPhonenumber" runat="server" placeholder="Please insert phone number format like 6282929887262" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <div class="col-md-12 text-right">
                    
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-lg" Text="Save" OnClick="btnSave_Click"/>
                    
                  </div>
                </div>
            </div>
          </div>
    	</div>
        </div>
</asp:Content>
