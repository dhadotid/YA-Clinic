<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="YA_Clinic.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="four-grids" style="margin:0px;margin-right: 15px;margin-top: 15px;">
					<div class="col-md-3 four-grid">
						<div class="four-agileits">
							<div class="icon">
								<i class="glyphicon glyphicon-user" aria-hidden="true"></i>
							</div>
							<div class="four-text">
								<h3>Registered Patient</h3>
								<h4 id="registeredPatient" runat="server">24</h4>
								
							</div>
							
						</div>
					</div>
					<div class="col-md-3 four-grid">
						<div class="four-agileinfo">
							<div class="icon">
								<i class="fa fa-user-md" style="font-size:37px;color:white" aria-hidden="true"></i>
							</div>
							<div class="four-text">
								<h3>The Doctor</h3>
								<h4 id="theDoctor" runat="server">15</h4>

							</div>
							
						</div>
					</div>
					<div class="col-md-3 four-grid">
						<div class="four-w3ls">
							<div class="icon">
								<i class="glyphicon glyphicon-plus" aria-hidden="true"></i>
							</div>
							<div class="four-text">
								<h3>Drug Avaible</h3>
								<h4 id="drugAvaible" runat="server">12</h4>
								
							</div>
							
						</div>
					</div>
					<div class="col-md-3 four-grid">
						<div class="four-wthree">
							<div class="icon">
								<i class="glyphicon glyphicon-credit-card" aria-hidden="true"></i>
							</div>
							<div class="four-text">
								<h3>Patient Already Payment</h3>
								<h4 id="patientAlreadyPayment" runat="server">14</h4>
								
							</div>
							
						</div>
					</div>
					<div class="clearfix"></div>
				</div>
</asp:Content>