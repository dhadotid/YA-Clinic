<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddTreatment.aspx.cs" Inherits="YA_Clinic.ui.AddTreatment" %>

<asp:Content ID="ContentAddTreatment" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-0">
            <div class="custom">
                <br>
                
                <center>
                <h2 id="tulisanatas">Add New Data Treatment</h2>
                </center>
                <hr>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdTreatment">Id Treatment</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtIdTreatment" runat="server" placeholder="Id Treatment" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                    </fieldset>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdPatient">Id Patient</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtIdPatient" runat="server" placeholder="Please select Id Patient from table" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>
                
               
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdDoctor">Id Doctor</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtIdDoctor" runat="server" placeholder="Please select Id Doctor from table" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdRecipe">Id Recipe</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtIdRecipe" runat="server" placeholder="Id Recipe" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                </fieldset>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDiagnose">Diagnose</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDiagnose" runat="server" placeholder="Diagnose" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDateTreatment">DateTreatment</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDateTreatment" runat="server" placeholder="Date Treatment" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                </fieldset>

                <div class="form-group">
                  <div class="col-md-12 text-right">
                    
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-lg" Text="Save" OnClick="btnSave_Click" />
                    
                  </div>
                </div>

                <hr>

         <div class="col-sm-12 col-md-12 col-lg-12">
            <div class="col-sm-6 col-md-6 col-lg-6 col-xs-6">
                <br />
                <asp:Label ID="lblPatientData" runat="server" Text="Data Patient" style="font-weight: 700"></asp:Label>
                <br />
                <asp:TextBox ID="txtSearchPatient" runat="server" CssClass="form-control my-narrow-input" placeholder="Search Data Patient" Width="472px"></asp:TextBox>
                <br />
                <!--<asp:Button ID="btnSearchPatient" runat="server" Text="Search" CssClass="btn btn-info"/>!-->
            <asp:GridView ID="dgv_Patient" DataKeyNames="Id_Patient" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgv_Patient_PageIndexChanging" OnRowCommand="dgv_Patient_RowCommand">
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
                    <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button ID="btnSelectPatient" CssClass="btn btn-info" runat="server" CommandName="YudhaGanteng" Text="Select"  />
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
            </asp:GridView>

            </div>
            <div class="col-sm-5 col-md-5 col-lg-5 col-xs-5 col-sm-offset-1">
                <br />
                <asp:Label ID="lblDoctorData" runat="server" Text="Data Doctor" style="font-weight: 700"></asp:Label>
                <br />
                <asp:TextBox ID="txtSearchDoctor" runat="server" CssClass="form-control my-narrow-input" placeholder="Search Data Doctor" Width="472px"></asp:TextBox>
                <br />
            <asp:GridView ID="dgv_Doctor" DataKeyNames="Id_Doctor" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgv_Doctor_PageIndexChanging" OnSelectedIndexChanged="dgv_Doctor_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Id Doctor">
                    <ItemTemplate>
                        <asp:Label ID="lblIdDoctor" runat="server" Text='<%#Eval("Id_Doctor") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Doctor Name">
                    <ItemTemplate>
                        <asp:Label ID="lblDoctorName" runat="server" Text='<%#Eval("DoctorName") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Specialist">
                    <ItemTemplate>
                        <asp:Label ID="lblSpecialist" runat="server" Text='<%#Eval("Specialist") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fare">
                    <ItemTemplate>
                        <asp:Label ID="lblFare" runat="server" Text='<%#Eval("Fare") %>'/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:Button ID="btnSelectDoctor" CssClass="btn btn-info" runat="server" CommandName="Select" Text="Select"  />
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>

            </div>
          </div>
    	</div>
        </div>
</asp:Content>