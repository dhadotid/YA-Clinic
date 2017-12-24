<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="YA_Clinic.form.Doctor" %>

<asp:Content ID="ContentDoctor" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
          <div class="col-md-12">
            <h2 class="text-center" id="tulisanatas">Doctor</h2>
            <hr style="margin-right: 10px; width: 1382px;">
            <!-- <div class="row">
              <div class="col-sm-4 col-sm-offset-4">
                </div> -->
              <fieldset>
                  <div class="col-sm-2">
                      <asp:TextBox ID="txtSearch" runat="server" placeholder="Search .." CssClass="form-control"></asp:TextBox>
                  </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" Text="Search" />
                    <a href="#" class="btn btn-info" role="button" style="float: right; margin-right: 20px; margin-bottom: 10px;">Add New Doctor</a>
              </fieldset>
            <div id="page-content-wrapper">
              <div class="container-fluid">
                <div class="row" style="margin-right:5px;">
                  
                    <asp:GridView ID="dgv_Doctor" DataKeyNames="Id_Doctor" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgv_Doctor_PageIndexChanging" OnRowDeleting="dgv_Doctor_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Id Doctor">
                <ItemTemplate>
                    <asp:Label ID="lblIdDoctor" runat="server" Text='<%#Eval("Id_Doctor") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id Specialist">
                <ItemTemplate>
                    <asp:Label ID="lblIdSpecialist" runat="server" Text='<%#Eval("Id_Specialist") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctor Name">
                <ItemTemplate>
                    <asp:Label ID="lblDoctorName" runat="server" Text='<%#Eval("DoctorName") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctor Gender">
                <ItemTemplate>
                    <asp:Label ID="lblGender" runat="server" Text='<%#Eval("DoctorGender") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Of Birth">
                <ItemTemplate>
                    <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DateOfBirth", "{0:dd/MM/yyyy}") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone Number">
                <ItemTemplate>
                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" CssClass="btn btn-info" runat="server" CommandName="Update"  Text="Update"  />
                    <asp:Button ID="btnDelete" CssClass="btn btn-info" runat="server" CommandName="Delete"  Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Doctor data?');" />
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