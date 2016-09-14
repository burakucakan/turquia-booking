<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctSubMenu.ascx.cs" Inherits="userControls_uctMessage" %>
<asp:Panel ID="pnlMessage" runat="server">
<div>
	<div class="top"></div>
	<div class="main" style="padding:5px 0;">
		<table width="710" cellpadding="0" cellspacing="0" border="0">
			<tr>
				<td width="10">
				</td>
				<td width="250">
					<asp:Panel ID="pnlSearch" runat="server">
						<table border="0" cellpadding="0" cellspacing="0" width="250">
							<tr>
								<td width="60">
									<asp:Label ID="lblSearch" runat="server" Text="Arama"></asp:Label></td>
								<td style="text-align: center;" width="120">
									<asp:TextBox ID="txtSearch" runat="server" CssClass="textBox"></asp:TextBox></td>
								<td style="text-align: center;" width="60">
									<asp:ImageButton ImageUrl="~/img/btnAra.gif" ID="btnSearch" runat="server" OnClick="btnSearch_Click" /></td>
							</tr>
						</table>
					</asp:Panel>
				</td>
				<td width="450" style="text-align:right;">
					<asp:Literal ID="ltrLinks" runat="server"></asp:Literal>
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			</tr>
		</table>
	</div>
	<div class="bottom"></div>
</div>
</asp:Panel>
