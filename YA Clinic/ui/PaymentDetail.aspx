<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentDetail.aspx.cs" Inherits="YA_Clinic.ui.PaymentDetail" %>
    
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>YA Clinic</title>
    <link rel="stylesheet" href="../Content/StyleKwitansi.css" />
</head>
<body>
    
    <form id="form1" runat="server">
    
  <div id="invoice-POS">
    
    <center id="top">
      <div class="logo"></div>
      <div class="info"> 
        <h2>YA Clinic</h2>
      </div>
    </center>
    
    <div id="mid">
      <div class="info">
        <h2>Payment Detail</h2>
        <p> 
            <asp:Literal ID="LitelarHeader" runat="server"></asp:Literal>
        </p>
      </div>
    </div>
    
    <div id="bot">

					<div id="table">
						<table>
							<tr class="tabletitle">
								<td class="item"><h2>Drug</h2></td>
								<td class="Hours"><h2>Qty</h2></td>
								<td class="Rate"><h2>Sub Total</h2></td>
							</tr>

                            <asp:Literal ID="LiteralDetailTransaction" runat="server"></asp:Literal>

							<tr class="tabletitle">
								<td></td>
								<td class="Rate"><h2>Payment Drug</h2></td>
								<td class="payment"><h2 id="lblPaymentDrug" runat="server"></h2></td>
							</tr>

                            <tr class="tabletitle">
								<td></td>
								<td class="Rate"><h2>Payment Doctor</h2></td>
								<td class="payment"><h2 id="lblPaymentDoctor" runat="server"></h2></td>
							</tr>

                            <tr class="tabletitle">
								<td></td>
								<td class="Rate"><h2>Total Payment</h2></td>
								<td class="payment"><h2 id="lblTotalPayment" runat="server"></h2></td>
							</tr>

							<tr class="tabletitle">
								<td></td>
								<td class="Rate"><h2>Money</h2></td>
								<td class="payment"><h2 id="lblMoney" runat="server"></h2></td>
							</tr>

                            <tr class="tabletitle">
								<td></td>
								<td class="Rate"><h2>Change</h2></td>
								<td class="payment"><h2 id="lblChange" runat="server"></h2></td>
							</tr>

						</table>
					</div>

					<div id="legalcopy">
						<p class="legal"><strong>Thank you for visiting!</strong>  Get well soon. 
						</p>
					</div>

				</div>
  </div>

    </form>

</body>
</html>
