<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="YA_Clinic.ui.Recipe" %>

<asp:Content ID="ContentRecipe" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
          <div class="col-md-12">
            <h2 class="text-center" id="tulisanatas">Data Recipe</h2>
            <hr style="margin-right: 10px; width: 1382px;">
            <!-- <div class="row">
              <div class="col-sm-4 col-sm-offset-4">
                </div> -->
              <fieldset>
                  <div class="col-sm-2">
                      <asp:TextBox ID="txtSearch" runat="server" placeholder="Search .." CssClass="form-control"></asp:TextBox>
                  </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" Text="Search" />
                    <a href="AddRecipe.aspx" class="btn btn-info" role="button" style="float: right; margin-right: 20px; margin-bottom: 10px;">Add New Data Recipe</a>
              </fieldset>
            <div id="page-content-wrapper">
              <div class="container-fluid">
                <div class="row" style="margin-right:5px;">
                  
                    <asp:GridView ID="dgv_Recipe" DataKeyNames="Id_RecipeDetail" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgv_Recipe_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Id Recipe Detail">
                <ItemTemplate>
                    <asp:Label ID="lblIdRecipeDetail" runat="server" Text='<%#Eval("Id_RecipeDetail") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id Recipe">
                <ItemTemplate>
                    <asp:Label ID="lblIdRecipe" runat="server" Text='<%#Eval("Id_Recipe") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Patient Name">
                <ItemTemplate>
                    <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Patient_Name") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Drug Name">
                <ItemTemplate>
                    <asp:Label ID="lblDrugName" runat="server" Text='<%#Eval("DrugName") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Drug Type">
                <ItemTemplate>
                    <asp:Label ID="lblDrugType" runat="server" Text='<%#Eval("DrugType") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty">
                <ItemTemplate>
                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diagnose">
                <ItemTemplate>
                    <asp:Label ID="lblDiagnose" runat="server" Text='<%#Eval("Diagnose") %>'/>
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
