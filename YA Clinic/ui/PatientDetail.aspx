<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PatientDetail.aspx.cs" Inherits="YA_Clinic.PatientDetail" %>

<asp:Content ID="ContentPatientDetail" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-3">
            <div class="custom">
                <br>
                <br>

                <center>
                <h2 id="tulisanatas" runat="server">Add New Data Patient</h2>
                </center>
                <hr>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="idpatient">Id Patient</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="idpatient" runat="server" placeholder="Id Patient" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                    </fieldset>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtname">Patient Name</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtname" runat="server" placeholder="Patient Name" CssClass="form-control"></asp:TextBox>                    
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtdob">Date Of Birth</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtdob" runat="server" placeholder="Please insert with format dd/MM/yyyy" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtaddress">Address</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtaddress" runat="server" placeholder="Address" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
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
                  <div class="col-md-12 text-right">
                    
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-lg" Text="Save" OnClick="btnSave_Click" value="Save"/>
                    
                  </div>
                </div>
            </div>
          </div>
    	</div>
        </div>
</asp:Content>