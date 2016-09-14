<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctMessage.ascx.cs" Inherits="userControls_uctMessage" %>
<asp:Panel ID="pnlMessage" runat="server">
<div>
	<div class="infotop"></div>
	<div class="message">
		<div><asp:Label CssClass="information" ID="lblMessage" runat="server" Text=""></asp:Label></div>
		<asp:Literal ID="ltrLinks" runat="server"></asp:Literal>
	</div>
	<div class="infobottom"></div>
</div>
</asp:Panel>
