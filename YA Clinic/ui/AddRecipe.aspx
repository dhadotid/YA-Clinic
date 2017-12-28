<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="YA_Clinic.ui.AddRecipe" %>

<asp:Content ID="ContentAddRecipe" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form-horizontal">
    	<div class="row">
          <div class="col-md-7 col-md-offset-0">
            <div class="custom">
                <br>
                
                <center>
                <h2 id="tulisanatas">Add New Data Recipe</h2>
                </center>
                <hr>
                <table class="nav-justified">
                    <tr>
                        <td style="width: 649px">
                            <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdRecipeDetail">Id RecipeDetail</label>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtIdRecipeDetail" runat="server" placeholder="Id RecipeDetail" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
                    </fieldset>
                
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdRecipe">Id Recipe</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtIdRecipe" runat="server" placeholder="Please select Id Recipe from table below" CssClass="form-control" Enabled="False" style="margin-right: 72"></asp:TextBox>
                  </div>
                </div>
                
               
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtIdDrug">Id Drug</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtIdDrug" runat="server" placeholder="Please select Id Drug from table below" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtQty">Qty</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtQty" runat="server" placeholder="Please insert qty" CssClass="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                  </div>
                </div>

                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtDose">Dose</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtDose" runat="server" placeholder="Please insert dose format like 3X1" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>

                <fieldset disabled>
                <div class="form-group">
                  <label class="col-md-3 control-label" for="txtSubtotal">Subtotal</label>
                  <div class="col-md-9">
                    <asp:TextBox ID="txtSubtotal" runat="server" placeholder="Subtotal" CssClass="form-control" Enabled="False"></asp:TextBox>
                  </div>
                </div>
                </fieldset>

                <div class="form-group">
                  <div class="col-md-12 text-right">
                    
                      <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-lg" Text="Add" OnClick="btnAdd_Click" />
                    
                  </div>
                </div>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblDataRecipe" runat="server" Text="Data Recipe Drug" style="font-weight: 700"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSearchDrugRecipe" runat="server" CssClass="form-control my-narrow-input" placeholder="Search Data Recipe Drug" Width="472px" AutoPostBack="True" OnTextChanged="txtSearchDrugRecipe_TextChanged"></asp:TextBox>
                                    <br />
                                <asp:GridView ID="gv_RecipeDrug" DataKeyNames="Id_RecipeDetail" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid max-grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnRowDeleting="gv_RecipeDrug_RowDeleting" OnPageIndexChanging="gv_RecipeDrug_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id RecipeDetail">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblIdRecipeDetail" runat="server" Text='<%#Eval("Id_RecipeDetail") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Id Recipe">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdRecipe" runat="server" Text='<%#Eval("Id_Recipe") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Drug Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDrugName" runat="server" Text='<%#Eval("DrugName") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dose">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDose" runat="server" Text='<%#Eval("Dose") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subtotal">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubtotal" runat="server" Text='<%#Eval("Subtotal", "{0:C2}") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSelectPatient" CssClass="btn btn-info" runat="server" CommandName="Delete" Text="Remove"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" CssClass="pagination-dha"/>
                                </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr>
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <div class="col-sm-6 col-md-6 col-lg-6 col-xs-6">
                                    <br />
                                    <asp:Label ID="lblRecipe" runat="server" Text="Data Recipe" style="font-weight: 700"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSearchRecipe" runat="server" CssClass="form-control my-narrow-input" placeholder="Search Data Recipe" Width="472px" AutoPostBack="True" OnTextChanged="txtSearchRecipe_TextChanged"></asp:TextBox>
                                    <br />
                                <asp:GridView ID="gv_Recipe" DataKeyNames="Id_Recipe" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_Recipe_PageIndexChanging" OnRowCommand="gv_Recipe_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id Recipe">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblIdRecipe" runat="server" Text='<%#Eval("Id_Recipe") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Patient Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpatientName" runat="server" Text='<%#Eval("Patient_Name") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Diagnose">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiagnose" runat="server" Text='<%#Eval("Diagnose") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSelectRecipe" CssClass="btn btn-info" runat="server" CommandName="YudhaGanteng" Text="Select"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" CssClass="pagination-dha"/>
                                </asp:GridView>

                                </div>
                                <div class="col-sm-5 col-md-5 col-lg-5 col-xs-5 col-sm-offset-1">
                                    <br />
                                    <asp:Label ID="lblDrugData" runat="server" Text="Data Drug" style="font-weight: 700"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSearchDrug" runat="server" CssClass="form-control my-narrow-input" placeholder="Search Data Drug" Width="472px" AutoPostBack="True" OnTextChanged="txtSearchDrug_TextChanged"></asp:TextBox>
                                    <br />
                                <asp:GridView ID="gv_Drug" DataKeyNames="Id_Drug" runat="server" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true" CssClass="table table-hover table-striped grid" UseAccessibleHeader="true" GridLines="None" CellSpacing="-1" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_Drug_PageIndexChanging" OnSelectedIndexChanged="gv_Drug_SelectedIndexChanged">
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
                                            <asp:Label ID="lblStockDrug" runat="server" Text='<%#Eval("Stock") %>'/>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ExpDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpDate" runat="server" Text='<%#Eval("ExpDate", "{0:dd/MM/yyyy}") %>'/>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price", "{0:C2}") %>'/>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelectDrug" CssClass="btn btn-info" runat="server" CommandName="Select" Text="Select"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" CssClass="pagination-dha"/>
                                </asp:GridView>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
          </div>
    	</div>
        </div>
</asp:Content>