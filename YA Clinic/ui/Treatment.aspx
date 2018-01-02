<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Treatment.aspx.cs" Inherits="YA_Clinic.ui.Treatment" %>

<asp:Content ID="ContentTreatment" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
          <div class="col-md-12">
            <h2 class="text-center" id="tulisanatas">Data Treatment</h2>
            <hr style="margin-right: 10px; width: 1382px;">
            <!-- <div class="row">
              <div class="col-sm-4 col-sm-offset-4">
                </div> -->
              <fieldset>
                  <div class="col-sm-2">
                      <asp:TextBox ID="txtSearch" runat="server" placeholder="Search .." CssClass="form-control" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                  </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" Text="Search" />
                  <br />
                  <br />
                  <asp:Button CssClass="btn btn-info" style="float: right; margin-right: 20px; margin-bottom: 10px;" ID="btnAddnNew" runat="server" Text="Add New Data Treatment" OnClick="btnAddnNew_Click" />
                    <!--<a href="AddTreatment.aspx" class="btn btn-info" role="button" style="float: right; margin-right: 20px; margin-bottom: 10px;" runat="server" id="btnAddNew">Add New Data Treatment</a>-->
              </fieldset>
            <div id="page-content-wrapper">
              <div class="container-fluid">
                <div class="row" style="margin-right:5px;">
                  
                    <asp:GridView ID="dgv_Treatment" DataKeyNames="Id_Treatment" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgv_Treatment_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="Id Treatment">
                <ItemTemplate>
                    <asp:Label ID="lblIdTreatment" runat="server" Text='<%#Eval("Id_Treatment") %>'/>
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
            <asp:TemplateField HeaderText="Id Recipe">
                <ItemTemplate>
                    <asp:Label ID="lblIdRecipe" runat="server" Text='<%#Eval("Id_Recipe") %>'/>
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
        </Columns>

        <HeaderStyle HorizontalAlign="Center"/>
        <RowStyle HorizontalAlign="Center" />
        <PagerStyle HorizontalAlign="Center" CssClass="pagination-dha"/>

    </asp:GridView>



                </div>
              </div>
            </div>
          </div>
            </div>

</asp:Content>