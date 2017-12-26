<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="YA_Clinic.ui.Payment" %>

<asp:Content ID="ContentPayment" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
          <div class="col-md-12">
            <h2 class="text-center" id="tulisanatas">Data Payment</h2>
            <hr style="margin-right: 10px; width: 1382px;">
            <!-- <div class="row">
              <div class="col-sm-4 col-sm-offset-4">
                </div> -->
              <fieldset>
                  <div class="col-sm-2">
                      <asp:TextBox ID="txtSearch" runat="server" placeholder="Search .." CssClass="form-control"></asp:TextBox>
                  </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" Text="Search" />
                    <a href="#" class="btn btn-info" role="button" style="float: right; margin-right: 20px; margin-bottom: 10px;">Add New Data Payment</a>
              </fieldset>
            <div id="page-content-wrapper">
              <div class="container-fluid">
                <div class="row" style="margin-right:5px;">
                  
                    <asp:GridView ID="dgv_Payment" DataKeyNames="Id_Payment" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgv_Payment_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Id Payment">
                <ItemTemplate>
                    <asp:Label ID="lblPayment" runat="server" Text='<%#Eval("Id_Payment") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Patient Name">
                <ItemTemplate>
                    <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Patient_Name") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctor Name">
                <ItemTemplate>
                    <asp:Label ID="lblDoctorName" runat="server" Text='<%#Eval("DoctorName") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diagnose">
                <ItemTemplate>
                    <asp:Label ID="lblDiagnose" runat="server" Text='<%#Eval("Diagnose") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Treatment">
                <ItemTemplate>
                    <asp:Label ID="lblDateTreatment" runat="server" Text='<%#Eval("DateTreatment", "{0:dd/MM/yyyy}") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Payment Doctor">
                <ItemTemplate>
                    <asp:Label ID="lblPaymentDoctor" runat="server" Text='<%#Eval("PaymentDoctor") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Payment Drug">
                <ItemTemplate>
                    <asp:Label ID="lblPaymentDrug" runat="server" Text='<%#Eval("PaymentDrug") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Payment">
                <ItemTemplate>
                    <asp:Label ID="lblTotalPayment" runat="server" Text='<%#Eval("TotalPayment") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <HeaderStyle HorizontalAlign="Center"/>
        <RowStyle HorizontalAlign="Center" />
        <PagerStyle HorizontalAlign="Center"/>

    </asp:GridView>
                </div>
              </div>
            </div>
          </div>
            </div>
</asp:Content>