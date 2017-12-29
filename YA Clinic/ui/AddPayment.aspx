<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddPayment.aspx.cs" Inherits="YA_Clinic.ui.AddPayment" %>

<asp:Content ID="ContentAddPayment" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-0">
            <div class="custom">
                <br>
                
                <center>
                <h2 id="tulisanatas">Add New Data Payment</h2>
                </center>
                <hr>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdPayment">Id Payment</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtIdPayment" runat="server" placeholder="Please select Id Payment from table below" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtPatientName">Patient Name</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtPatientName" runat="server" placeholder="Patient Name" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>
                
               
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDoctorName">Doctor Name</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDoctorName" runat="server" placeholder="Doctor Name" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDiagnose">Diagnose</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDiagnose" runat="server" placeholder="Diagnose" CssClass="form-control" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtPaymentDoctor">Payment Doctor</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtPaymentDoctor" runat="server" placeholder="Payment Doctor" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtPaymentDrug">Payment Drug</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtPaymentDrug" runat="server" placeholder="Payment Drug" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtTotalPayment">Total Payment</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtTotalPayment" runat="server" placeholder="Total Payment" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtMoney">Money</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtMoney" runat="server" placeholder="Money" CssClass="form-control" OnTextChanged="txtMoney_TextChanged" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtChange">Change</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtChange" runat="server" placeholder="Change" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <div class="col-md-12 text-right">
                    
                      <asp:TextBox ID="txtIdRecipe" runat="server" placeholder="" CssClass="form-control" Enabled="False"></asp:TextBox>
                      <asp:Label ID="lblTotalPayment" runat="server" Text="Label" Visible="False"></asp:Label>
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-lg" Text="Save" OnClick="btnSave_Click" UseSubmitBehavior="False" />
                    
                  </div>
                </div>

                <hr>

         <div class="col-sm-12 col-md-12 col-lg-12">
            <asp:Label ID="lblDataPayment" runat="server" Text="Data Payment" style="font-weight: 700"></asp:Label>
                <br />
                <asp:TextBox ID="txtSearchPayment" runat="server" CssClass="form-control my-narrow-input" placeholder="Search Data Payment" Width="472px" OnTextChanged="txtSearchPayment_TextChanged" AutoPostBack="true"></asp:TextBox>
                <br />
            <asp:GridView ID="dgv_Payment" DataKeyNames="Id_Payment" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnSelectedIndexChanged="dgv_Payment_SelectedIndexChanged" OnPageIndexChanging="dgv_Payment_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Id Payment">
                    <ItemTemplate>
                        <asp:Label ID="lblIdPayment" runat="server" Text='<%#Eval("Id_Payment") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Patient Name">
                    <ItemTemplate>
                        <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Patient_Name") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Diagnose">
                    <ItemTemplate>
                        <asp:Label ID="lblDiagnose" runat="server" Text='<%#Eval("Diagnose") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payment Doctor">
                    <ItemTemplate>
                        <asp:Label ID="lblPaymentDoctor" runat="server" Text='<%#Eval("PaymentDoctor", "{0:C2}") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payment Drug">
                    <ItemTemplate>
                        <asp:Label ID="lblPaymentDrug" runat="server" Text='<%#Eval("PaymentDrug", "{0:C2}") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Payment">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalPayment" runat="server" Text='<%#Eval("TotalPayment", "{0:C2}") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:Button ID="btnSelectPayment" CssClass="btn btn-info" runat="server" CommandName="Select" Text="Select"  />
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>

                <PagerStyle HorizontalAlign="Center" CssClass="pagination-dha"/>
            </asp:GridView>
        </div>

            </div>
          </div>
    	</div>
        </div>
</asp:Content>