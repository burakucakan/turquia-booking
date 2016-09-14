<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctAddHotel.ascx.cs" Inherits="userControls_ucAddHotel" %>
<%@ Register Src="uctSubMenu.ascx" TagName="uctSubMenu" TagPrefix="uc6" %>
<%@ Register Src="uctAddress.ascx" TagName="uctAddress" TagPrefix="uc5" %>
<%@ Register Src="uctHotelPlaceDistances.ascx" TagName="uctHotelPlaceDistances" TagPrefix="uc2" %>
<%@ Register Src="uctHotelProperties.ascx" TagName="uctHotelProperties" TagPrefix="uc3" %>
<%@ Register Src="uctHotelImages.ascx" TagName="uctHotelImages" TagPrefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="uctMessage.ascx" TagName="uctMessage" TagPrefix="uc1" %>

		<uc6:uctSubMenu ID="UctSubMenu1" runat="server" />
		<uc1:uctMessage ID="UctMessage1" runat="server" Visible="false" />
		<div class="b710">
			<div class="title">
                OTEL EKLE</div>
			<div class="main">
				<div class="info">
                    Otel ekle</div>
				<div style="margin:10px;">
					<cc1:TabContainer ID="tabLanguages" runat="server" Width="100%" ActiveTabIndex="0">
					</cc1:TabContainer>
				</div>
				<div style="margin:10px;">
				    <table width="100%">
                        <tr>
                            <td style="width: 46px" valign="top">
                                <asp:Label ID="lblHotelChain" runat="server" Text="Otel Zinciri :" CssClass="label"></asp:Label></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlHotelChain" runat="server" CssClass="s50" DataTextField="Name" DataValueField="HotelChainID">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblHotelClass" runat="server" Text="Sýnýfý :" CssClass="label"></asp:Label></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlHotelClass" runat="server" CssClass="s50" Width="100px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
							<td></td>
							<td colspan="2">&nbsp;</td>
						</tr>
                        <tr>
                            <td valign="top" style="height: 26px">
                                <asp:Label ID="lblCheckin" runat="server" Text="Check-in saati :" CssClass="label"></asp:Label></td>
                            <td colspan="2" style="height: 26px">
                                <asp:TextBox ID="txtCheckin" runat="server" CssClass="s25" Text="13:00" Width="45px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblCheckout" runat="server" Text="Check-out saati :" CssClass="label"></asp:Label></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCheckout" runat="server" CssClass="s25" Text="11:00" Width="45px"></asp:TextBox></td>
                        </tr>
                        <tr>
							<td></td>
							<td colspan="2">&nbsp;</td>
						</tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Oda isteði yapýlabilir mi?" CssClass="label"></asp:Label></td>
                            <td colspan="2">
                                <asp:CheckBox ID="chkRoomRequestable" runat="server"></asp:CheckBox></td>
                        </tr>
						<tr>
							<td>
							</td>
							<td colspan="2">
								&nbsp;</td>
						</tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Çocuk Ýndirimi 1:"></asp:Label></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlFirstChildAge" runat="server" Width="45px">
									<asp:ListItem Value="0">0</asp:ListItem>
									<asp:ListItem Value="1">1</asp:ListItem>
									<asp:ListItem Value="2">2</asp:ListItem>
									<asp:ListItem Value="3">3</asp:ListItem>
									<asp:ListItem Value="4">4</asp:ListItem>
									<asp:ListItem Value="5">5</asp:ListItem>
									<asp:ListItem Value="6">6</asp:ListItem>
									<asp:ListItem Value="7">7</asp:ListItem>
									<asp:ListItem Value="8">8</asp:ListItem>
									<asp:ListItem Value="9">9</asp:ListItem>
									<asp:ListItem Value="10">10</asp:ListItem>
									<asp:ListItem Value="11">11</asp:ListItem>
									<asp:ListItem Value="12">12</asp:ListItem>
									<asp:ListItem Value="13">13</asp:ListItem>
									<asp:ListItem Value="14">14</asp:ListItem>
									<asp:ListItem Value="15">15</asp:ListItem>
									<asp:ListItem Value="16">16</asp:ListItem>
									<asp:ListItem Value="17">17</asp:ListItem>
									<asp:ListItem Value="18">18</asp:ListItem>
								</asp:DropDownList>
								yaþýna kadar %
                                <asp:TextBox ID="txtFirstAgeDiscount" runat="server" CssClass="s25" Text="0" Width="35px"></asp:TextBox> indirim.
							</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Çocuk Ýndirimi 2:"></asp:Label></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlSecondChildAge" runat="server" Width="45px">
									<asp:ListItem Value="0">0</asp:ListItem>
									<asp:ListItem Value="1">1</asp:ListItem>
									<asp:ListItem Value="2">2</asp:ListItem>
									<asp:ListItem Value="3">3</asp:ListItem>
									<asp:ListItem Value="4">4</asp:ListItem>
									<asp:ListItem Value="5">5</asp:ListItem>
									<asp:ListItem Value="6">6</asp:ListItem>
									<asp:ListItem Value="7">7</asp:ListItem>
									<asp:ListItem Value="8">8</asp:ListItem>
									<asp:ListItem Value="9">9</asp:ListItem>
									<asp:ListItem Value="10">10</asp:ListItem>
									<asp:ListItem Value="11">11</asp:ListItem>
									<asp:ListItem Value="12">12</asp:ListItem>
									<asp:ListItem Value="13">13</asp:ListItem>
									<asp:ListItem Value="14">14</asp:ListItem>
									<asp:ListItem Value="15">15</asp:ListItem>
									<asp:ListItem Value="16">16</asp:ListItem>
									<asp:ListItem Value="17">17</asp:ListItem>
									<asp:ListItem Value="18">18</asp:ListItem>
                                </asp:DropDownList>
								yaþýna kadar %
                                <asp:TextBox ID="txtSecondAgeDiscount" runat="server" CssClass="s25" Text="0" Width="35px"></asp:TextBox> indirim.</td>
                        </tr>
                        <tr>
							<td></td>
							<td colspan="2">&nbsp;</td>
						</tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblHotelDistance" runat="server" Text="Mesafeler" CssClass="label"></asp:Label></td>
                            <td colspan="2">
                                <uc2:uctHotelPlaceDistances ID="UctHotelPlaceDistances1" runat="server" />
                            </td>
                        </tr>
                        <tr>
							<td></td>
							<td colspan="2">&nbsp;</td>
						</tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblHotelProperties" runat="server" CssClass="label" Text="Özellikler"></asp:Label></td>
                            <td colspan="2" valign="top">
                                <uc3:uctHotelProperties id="UctHotelProperties1" runat="server"></uc3:uctHotelProperties></td>
                        </tr>
                        <tr>
							<td></td>
							<td colspan="2">&nbsp;</td>
						</tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblHotelImages" runat="server" CssClass="label" Text="Resimler"></asp:Label></td>
                            <td colspan="2">
                                <uc4:uctHotelImages id="UctHotelImages1" runat="server"></uc4:uctHotelImages></td>
                        </tr>
                        <tr>
							<td></td>
							<td colspan="2">&nbsp;</td>
						</tr>
                        <tr>
                            <td colspan="3" valign="top">
                                <uc5:uctAddress ID="UctAddress1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px">
                            <asp:CheckBox ID="chkContinue" runat="server" Text="Otel Eklemeye Devam Et" Width="182px" />
                                </td>
                            <td align="right" style="height: 26px">
                                <asp:ImageButton ID="btnPublish" runat="server" ImageUrl="~/img/btnYayinla.gif" ToolTip="Kaydet" AlternateText="Yayýnla" OnClick="btnPublish_Click" /></td>
                        </tr>
                    </table>
				</div>
			</div>
		</div>