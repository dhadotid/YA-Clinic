<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddSpecialist.aspx.cs" Inherits="YA_Clinic.form.AddSpecialist" %>

<asp:Content ID="ContentAddSpecialist" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-3">
            <div class="custom">
                <br>
                <br>

                <center>
                <h2 id="tulisanatas" runat="server">Add New Data Specialist</h2>
                </center>
                <hr>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdSpecialist">Id Specialist</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtIdSpecialist" runat="server" placeholder="Id Specialist" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                    </fieldset>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtSpecialist">Specialist</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtSpecialist" runat="server" placeholder="Specialist" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtFare">Fare</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtFare" runat="server" placeholder="Fare" CssClass="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
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