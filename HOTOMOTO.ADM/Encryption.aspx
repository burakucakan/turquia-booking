<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Encryption.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" width="500">
				<tr>
					<td style="height: 22px" width="100">
						<asp:Label ID="lblHotelNameTitle" runat="server" CssClass="label" Text="Otel Adý"></asp:Label></td>
					<td style="height: 22px" width="300">
						<asp:DropDownList ID="ddlHotels" runat="server" Width="280">
						</asp:DropDownList></td>
					<td style="height: 22px" width="100">
						<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
				</tr>
				<tr>
					<td width="100">
						<asp:Label ID="lblCityTitle" runat="server" CssClass="label" Text="Þehir"></asp:Label></td>
					<td width="300">
						<asp:DropDownList ID="ddlCities" runat="server" Width="280" AutoPostBack="True" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
						</asp:DropDownList></td>
					<td width="100">
						<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
				</tr>
				<tr>
					<td width="100">
						<asp:Label ID="lblClassTitle" runat="server" CssClass="label" Text="Sýnýf"></asp:Label></td>
					<td width="300">
						<asp:DropDownList ID="ddlClasses" runat="server" Width="280">
						</asp:DropDownList></td>
					<td width="100">
						<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
				</tr>
				<tr>
					<td width="100">
					</td>
					<td width="300">
					</td>
					<td width="100">
						<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Ara" /></td>
				</tr>
				<tr>
					<td colspan="3">
						&nbsp;</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="lblPriceListTitle" runat="server" CssClass="label" Text="Fiyat Listesi">
						</asp:Label></td>
					<td colspan="2">
						<asp:DropDownList ID="ddlPriceLists" runat="server" Width="400">
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td colspan="3">
						&nbsp;</td>
				</tr>
			</table>
			<asp:Repeater ID="rptRooms" runat="server" OnItemDataBound="rptRooms_ItemDataBound">
				<HeaderTemplate>
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<th>
								<asp:Literal ID="ltlHotelNameTitle" runat="server" Text="Otel Adý"></asp:Literal></th>
							<th>
								<asp:Literal ID="ltlRoomNameTitle" runat="server" Text="Oda Adý"></asp:Literal></th>
							<th>
								<asp:Literal ID="ltlSNGEURPriceTitle" runat="server" Text="SNG (EUR)"></asp:Literal></th>
							<th>
								<asp:Literal ID="ltlSNGUSDPriceTitle" runat="server" Text="SNG (USD)"></asp:Literal></th>
							<th>
								<asp:Literal ID="ltlDBLEURPriceTitle" runat="server" Text="DBL (EUR)"></asp:Literal></th>
							<th>
								<asp:Literal ID="ltlDBLUSDPriceTitle" runat="server" Text="DBL (USD)"></asp:Literal></th>
							<th>
								<asp:Literal ID="ltlTRPEURPriceTitle" runat="server" Text="TRP (EUR)"></asp:Literal></th>
							<th>
								<asp:Literal ID="ltlTRPUSDPriceTitle" runat="server" Text="TRP (USD)"></asp:Literal></th>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td>
							<%# DataBinder.Eval(Container.DataItem, "HotelName") %>
						</td>
						<td>
							<%# DataBinder.Eval(Container.DataItem, "RoomName") %>
						</td>
						<td align="center">
							<asp:TextBox ID="txtSNGEURPrice" runat="server" Width="80"></asp:TextBox></td>
						<td align="center">
							<asp:TextBox ID="txtSNGUSDPrice" runat="server" Width="80"></asp:TextBox></td>
						<td align="center">
							<asp:TextBox ID="txtDBLEURPrice" runat="server" Width="80"></asp:TextBox></td>
						<td align="center">
							<asp:TextBox ID="txtDBLUSDPrice" runat="server" Width="80"></asp:TextBox></td>
						<td align="center">
							<asp:TextBox ID="txtTRPEURPrice" runat="server" Width="80"></asp:TextBox></td>
						<td align="center">
							<asp:TextBox ID="txtTRPUSDPrice" runat="server" Width="80"></asp:TextBox></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>
			</asp:Repeater>
	</form>
</body>
</html>
