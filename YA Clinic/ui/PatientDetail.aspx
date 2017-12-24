<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PatientDetail.aspx.cs" Inherits="YA_Clinic.PatientDetail" %>

<asp:Content ID="ContentPatientDetail" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-3">
            <div class="custom">
                <br>
                <br>

                <center>
                <h2 id="tulisanatas">Add New Patient</h2>
                </center>
                <hr>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="idpatient">Id Patient</label>
                  <div class="col-md-9">
                    <input id="idpatient" name="idpatient" runat="server" type="text" placeholder="Id Patient" class="form-control">
                  </div>
                </div>
                    </fieldset>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtname">Patient Name</label>
                  <div class="col-md-9">
                    <input id="txtname" name="txtname" runat="server" type="text" placeholder="Patient Name" class="form-control">
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtdob">Date Of Birth</label>
                  <div class="col-md-9">
                    <input id="txtdob" name="txtdob" runat="server" type="text" placeholder="Please insert with format dd/MM/yyyy" class="form-control">
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtaddress">Address</label>
                  <div class="col-md-9">
                    <textarea class="form-control" runat="server" id="txtaddress" name="txtaddress" placeholder="Address" rows="5"></textarea>
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
                    
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-lg" Text="Save" OnClick="btnSave_Click" />
                    
                  </div>
                </div>
            </div>
          </div>
    	</div>
        </div>
</asp:Content>