﻿<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Drug.aspx.cs" Inherits="YA_Clinic.ui.Drug" %>

<asp:Content ID="ContentDrug" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
          <div class="col-md-12">
            <h2 class="text-center" id="tulisanatas">Drug</h2>
            <hr style="margin-right: 10px; width: 1382px;">
            <!-- <div class="row">
              <div class="col-sm-4 col-sm-offset-4">
                </div> -->
              <fieldset>
                  <div class="col-sm-2">
                      <asp:TextBox ID="txtSearch" runat="server" placeholder="Search .." CssClass="form-control"></asp:TextBox>
                  </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" Text="Search" />
                    <a href="#" class="btn btn-info" role="button" style="float: right; margin-right: 20px; margin-bottom: 10px;">Add New Drug</a>
              </fieldset>
            <div id="page-content-wrapper">
              <div class="container-fluid">
                <div class="row" style="margin-right:5px;">
                  
                    <asp:GridView ID="dgv_Drug" DataKeyNames="Id_Drug" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgv_Drug_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Id Drug">
                <ItemTemplate>
                    <asp:Label ID="lblIdDrug" runat="server" Text='<%#Eval("Id_Drug") %>'/>
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
            <asp:TemplateField HeaderText="Stock">
                <ItemTemplate>
                    <asp:Label ID="lblStock" runat="server" Text='<%#Eval("Stock") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ExpDate">
                <ItemTemplate>
                    <asp:Label ID="lblExpDate" runat="server" Text='<%#Eval("ExpDate", "{0:dd/MM/yyyy}") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price") %>'/>
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