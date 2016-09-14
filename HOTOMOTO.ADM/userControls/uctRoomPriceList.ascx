<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctRoomPriceList.ascx.cs"
	Inherits="userControls_uctRoomPriceList" %>
<asp:UpdatePanel ID="upHotels" runat="server">
	<ContentTemplate>
		<div class="b710">
			<div class="title">
				OTELLER</div>
			<div class="main">
				<div style="padding: 10px;">
					<table border="0" cellpadding="0" cellspacing="0" width="500">
						<tr>
							<td style="height: 22px" width="100">
								<asp:Label ID="lblHotelNameTitle" runat="server" CssClass="label" Text="Otel Adý"></asp:Label></td>
							<td style="height: 22px" width="300">
								<asp:DropDownList ID="ddlHotels" runat="server" Width="280">
								</asp:DropDownList></td>
							<td style="height: 22px" width="100">
								</td>
						</tr>
						<tr>
							<td width="100">
								<asp:Label ID="lblCityTitle" runat="server" CssClass="label" Text="Þehir"></asp:Label></td>
							<td width="300">
								<asp:DropDownList ID="ddlCities" runat="server" Width="280" AutoPostBack="True" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
								</asp:DropDownList></td>
							<td width="100">
								</td>
						</tr>
						<tr>
							<td width="100">
								<asp:Label ID="lblClassTitle" runat="server" CssClass="label" Text="Sýnýf"></asp:Label></td>
							<td width="300">
								<asp:DropDownList ID="ddlClasses" runat="server" Width="280">
								</asp:DropDownList></td>
							<td width="100">
								<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/img/btnAra.gif" OnClick="btnSearch_Click" /></td>
						</tr>
						<tr>
							<td width="100">
							</td>
							<td width="300">
							</td>
							<td width="100">
								</td>
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
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td colspan="3">
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
												<asp:TextBox ID="txtSNGEURPrice" CssClass="textBox" runat="server" Width="50"></asp:TextBox></td>
											<td align="center">
												<asp:TextBox ID="txtSNGUSDPrice" CssClass="textBox" runat="server" Width="50"></asp:TextBox></td>
											<td align="center">
												<asp:TextBox ID="txtDBLEURPrice" CssClass="textBox" runat="server" Width="50"></asp:TextBox></td>
											<td align="center">
												<asp:TextBox ID="txtDBLUSDPrice" CssClass="textBox" runat="server" Width="50"></asp:TextBox></td>
											<td align="center">
												<asp:TextBox ID="txtTRPEURPrice" CssClass="textBox" runat="server" Width="50"></asp:TextBox></td>
											<td align="center">
												<asp:TextBox ID="txtTRPUSDPrice" CssClass="textBox" runat="server" Width="50"></asp:TextBox></td>
										</tr>
									</ItemTemplate>
									<FooterTemplate>
										</table>
									</FooterTemplate>
								</asp:Repeater>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								&nbsp;
							</td>
						</tr>
						<tr>
							<td colspan="3" align="right">
								<asp:Button ID="btnUpdate" runat="server" Text="Kaydet" OnClick="btnUpdate_Click" /></td>
						</tr>
					</table>
				</div>
				<div class="group-actions">
					GRUP ÝÞLEMÝ: <a href="#">Yayýndan kaldýr</a></div>
				<div class="main-actions">
					<a href="#">Ýzinler</a>, <a href="#">Tüm kategoriler</a></div>
			</div>
			<div class="bottom">
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
