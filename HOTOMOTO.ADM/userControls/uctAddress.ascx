<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctAddress.ascx.cs" Inherits="userControls_uctAddress" %>
<asp:UpdatePanel ID="upAddress" runat="server">
	<ContentTemplate>
		<table width="100%">
			<tr>
				<td>
					<asp:Label ID="lblCountry" runat="server" CssClass="label" Text="Ülke : "></asp:Label></td>
				<td>
					<asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" CssClass="s50"
						OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
					</asp:DropDownList></td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblCity" runat="server" CssClass="label" Text="Þehir : "></asp:Label></td>
				<td>
					<asp:DropDownList ID="ddlCity" runat="server" CssClass="s50" DataTextField="Name"
						DataValueField="CityID">
					</asp:DropDownList></td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td valign="top">
					<asp:Label ID="lblTown" runat="server" CssClass="label" Text="Semt : "></asp:Label></td>
				<td>
					<asp:TextBox ID="txtHotelTown" runat="server" CssClass="textBox s50"></asp:TextBox></td>
				<td>
					<asp:RequiredFieldValidator ID="reqfvHotelTown" runat="server" ControlToValidate="txtHotelTown"
						ErrorMessage="*" ValidationGroup="vgHotelInsertion"></asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblPostalCode" runat="server" CssClass="label" Text="Posta Kodu : "></asp:Label></td>
				<td>
					<asp:TextBox ID="txtPostalCode" runat="server" CssClass="textBox p25"></asp:TextBox></td>
				<td>
					<asp:RequiredFieldValidator ID="reqfvPostalCode" runat="server" ControlToValidate="txtPostalCode"
						ErrorMessage="*" ValidationGroup="vgHotelInsertion"></asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td valign="top">
					<asp:Label ID="lblStreetAddress" runat="server" CssClass="label" Text="Adres : "></asp:Label></td>
				<td class="txtarea">
					<asp:TextBox ID="txtStreetAddress" runat="server" CssClass="textBox p50" TextMode="MultiLine"></asp:TextBox></td>
				<td>
					<asp:RequiredFieldValidator ID="reqfvStreetAddress" runat="server" ControlToValidate="txtStreetAddress"
						ErrorMessage="*" ValidationGroup="vgHotelInsertion"></asp:RequiredFieldValidator></td>
			</tr>
		</table>
	</ContentTemplate>
</asp:UpdatePanel>
