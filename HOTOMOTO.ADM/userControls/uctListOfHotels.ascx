<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctListOfHotels.ascx.cs" Inherits="UserControls_uctListOfHotels" %>
<%@ Register Src="uctSubMenu.ascx" TagName="uctSubMenu" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upHotels" runat="server">
	<ContentTemplate>
		<uc1:uctSubMenu ID="UctSubMenu1" runat="server" />
		<div class="b710">
			<div class="title">
				OTELLER</div>
			<div class="main">
				<div id="itemlist">
					<asp:Repeater ID="rptHotels" runat="server">
						<HeaderTemplate>
							<table>
								<tr>
									<th class="c1">
										<input type="checkbox" value="all" /></th>
									<th width="350">
										OTEL ADI</th>
									<th width="100">
										�EH�R</th>
									<th width="100">
										SINIF</th>
									<th width="130">
										��LEMLER</th>
								</tr>
						</HeaderTemplate>
						<ItemTemplate>
							<tr class="item">
								<td class="c1">
									<input type="checkbox" /></td>
								<td width="350">
									<a href="rooms.aspx?hotelid=<%# DataBinder.Eval(Container.DataItem, "HotelID") %>">
										<%# DataBinder.Eval(Container.DataItem, "HotelName") %>
									</a>
								</td>
								<td width="100">
									<%# DataBinder.Eval(Container.DataItem, "CityName") %>
								</td>
								<td width="100">
									<%# HOTOMOTO.COM.ReturnClasses.GetHotelClassFormat(DataBinder.Eval(Container.DataItem, "Title").ToString()) %>
								</td>
								<td width="130">
									<div>
										<a href="edithotel.aspx?hotelid=<%# DataBinder.Eval(Container.DataItem, "HotelID") %>">
											d�zenle</a>, <a href="#sil.aspx?tip=ulke&id=<%# DataBinder.Eval(Container.DataItem, "HotelID") %>">
												kald�r</a></div>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:Repeater>
					<table>
						<tr>
							<td width="10">
							</td>
							<td>
								Sayfada
								<asp:DropDownList ID="ddlPageLimit" runat="server" AutoPostBack="True" CssClass="paging"
									OnSelectedIndexChanged="ddlPageLimit_SelectedIndexChanged" Width="50px">
									<asp:ListItem>10</asp:ListItem>
									<asp:ListItem>25</asp:ListItem>
									<asp:ListItem>50</asp:ListItem>
									<asp:ListItem>100</asp:ListItem>
								</asp:DropDownList>
								adet g�ster
							</td>
							<td style="text-align: right; padding-right: 10px;">
								<asp:LinkButton ID="lbtPrevious" runat="server" OnClick="lbtPrevious_Click">&lt; �nceki</asp:LinkButton>
								<asp:DropDownList ID="ddlPageNumber" runat="server" AutoPostBack="True" CssClass="paging"
									OnSelectedIndexChanged="ddlPageNumber_SelectedIndexChanged" Width="42px">
								</asp:DropDownList>
								<b>/
									<asp:Label ID="lblPageCount" runat="server" Text="Label"></asp:Label></b>
								<asp:LinkButton ID="lbtNext" runat="server" OnClick="lbtNext_Click">Sonraki &gt;</asp:LinkButton></td>
						</tr>
					</table>
				</div>
				<div class="group-actions">
					GRUP ��LEM�: <a href="#">Yay�ndan kald�r</a></div>
				<div class="main-actions">
					<a href="#">�zinler</a>, <a href="#">T�m kategoriler</a></div>
			</div>
			<div class="bottom">
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
