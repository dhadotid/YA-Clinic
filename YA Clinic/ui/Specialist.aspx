﻿<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Specialist.aspx.cs" Inherits="YA_Clinic.Schedule" %>

<asp:Content ID="ContentSpecialist" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
          <div class="col-md-12">
            <h2 class="text-center" id="tulisanatas">Data Specialist</h2>
            <hr style="margin-right: 10px; width: 1382px;">
            <!-- <div class="row">
              <div class="col-sm-4 col-sm-offset-4">
                </div> -->
              <fieldset>
                  <div class="col-sm-2">
                      <asp:TextBox ID="txtSearch" runat="server" placeholder="Search .." CssClass="form-control" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                  </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" Text="Search" />
                  <asp:Button CssClass="btn btn-info" style="float: right; margin-right: 20px; margin-bottom: 10px;" ID="btnAddnNew" runat="server" Text="Add New Data Specialist" OnClick="btnAddnNew_Click" />
              </fieldset>
              <br />
            <div id="page-content-wrapper">
              <div class="container-fluid">
                <div class="row" style="margin-right:5px;">

    <asp:GridView ID="gv_Specialist" DataKeyNames="Id_Specialist" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" OnRowDeleting="gv_Specialist_RowDeleting" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_Specialist_PageIndexChanging" OnRowCommand="gv_Specialist_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="ID Specialist">
                <ItemTemplate>
                    <asp:Label ID="lblIdSpecialist" runat="server" Text='<%#Eval("Id_Specialist") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Specialist">
                <ItemTemplate>
                    <asp:Label ID="lblSpecialist" runat="server" Text='<%#Eval("Specialist") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fare">
                <ItemTemplate>
                    <asp:Label ID="lblFare" runat="server"  Text='<%# Eval("Fare", "{0:C2}") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" CssClass="btn btn-info" runat="server" CommandName="Update"  Text="Update" />
                    <asp:Button ID="btnDelete" CssClass="btn btn-info" runat="server" CommandName="Delete"  Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Specialist data?');" />
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