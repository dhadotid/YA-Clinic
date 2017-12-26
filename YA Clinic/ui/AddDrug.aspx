<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddDrug.aspx.cs" Inherits="YA_Clinic.ui.AddDrug" %>

<asp:Content ID="ContentAddDrug" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-3">
            <div class="custom">
                <br>
                <br>

                <center>
                <h2 id="tulisanatas">Add New Data Drug</h2>
                </center>
                <hr>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdSpecialist">Id Drug</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtIdDrug" runat="server" placeholder="Id Drug" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                    </fieldset>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDrugName">Drug Name</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDrugName" runat="server" placeholder="Drug Name" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="DDdrugType">Drug Type</label>
                  <div class="col-md-9">
                    <asp:DropDownList ID="DDdrugType" runat="server" CssClass="form-control">
                        <asp:ListItem Enabled="true" Text="Select Drug Type" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Capsule" Value="Capsule"></asp:ListItem>
                        <asp:ListItem Text="Tablet" Value="Tablet"></asp:ListItem>
                        <asp:ListItem Text="Syrup" Value="Syrup"></asp:ListItem>
                        <asp:ListItem Text="Cream" Value="Cream"></asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtStock">Stock</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtStock" runat="server" placeholder="Stock" CssClass="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtExpDate">ExpDate</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtExpDate" runat="server" placeholder="Please insert with format yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtPrice">Price</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtPrice" runat="server" placeholder="Price" CssClass="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
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