<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="YA_Clinic.Patient" %>

<asp:Content ID="ContentPatient" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row">
          <div class="col-md-12">
            <h2 class="text-center" id="tulisanatas">Data Patient</h2>
            <hr style="margin-right: 10px; width: 1382px;">
            <!--<div class="row">
              <div class="col-sm-3 col-sm-offset-0">
                  
                </div>
                <div class="col-sm-3">
                    
                </div>
                <div class="col-sm-3">
                    
                </div>
            </div>  !--->
              <fieldset>
                  <div class="col-sm-2">
                      <asp:TextBox ID="txtSearch" runat="server" placeholder="Search .." CssClass="form-control"></asp:TextBox>
                  </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" Text="Search" />
                    <a href="PatientDetail.aspx" class="btn btn-info" role="button" style="float: right; margin-right: 20px; margin-bottom: 10px;">Add New Data Patient</a>
              </fieldset>
              

            <div id="page-content-wrapper">
              <div class="container-fluid">
                <div class="row" style="margin-right:5px;">
                  
                    <asp:GridView ID="dgv_Patient" DataKeyNames="Id_Patient" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" OnPageIndexChanging="dgv_Patient_PageIndexChanging" PageSize="5" OnRowDeleting="dgv_Patient_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Id Patient">
                <ItemTemplate>
                    <asp:Label ID="lblidPatient" runat="server" Text='<%#Eval("Id_Patient") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Patient Name">
                <ItemTemplate>
                    <asp:Label ID="lblpatientName" runat="server" Text='<%#Eval("Patient_Name") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Of Birth">
                <ItemTemplate>
                    <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DateOfBirth", "{0:dd/MM/yyyy}") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Patient Gender">
                <ItemTemplate>
                    <asp:Label ID="lblGender" runat="server" Text='<%#Eval("GenderPatient") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" CssClass="btn btn-info" runat="server" CommandName="Update"  Text="Update"  />
                    <asp:Button ID="btnDelete" CssClass="btn btn-info" runat="server" CommandName="Delete"  Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Patient data?');" />
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