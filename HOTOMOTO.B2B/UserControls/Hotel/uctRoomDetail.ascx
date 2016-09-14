<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctRoomDetail.ascx.cs" Inherits="UserControls_Hotel_uctRoomDetail" %>
<%@ Register Src="~/UserControls/Common/uctPopupBottom.ascx" TagName="uctPopupBottom" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/uctPopupTop.ascx" TagName="uctPopupTop" TagPrefix="uc1" %>

<uc1:uctPopupTop ID="UctPopupTop1" runat="server" />

<br />


    <asp:Panel ID="pnlRoomList" runat="server" meta:resourcekey="pnlRoomListResource1">
        <table>
            <tr>
                <td style="padding-left: 25px;">
                    <asp:Repeater ID="rptRoomList" runat="server">
                        <HeaderTemplate>
                            <asp:Label ID="lblRoomList" runat="server" Text="ODALAR" CssClass="RoomName" meta:resourcekey="lblRoomListResource1"></asp:Label><br />
                            <br />
                        </HeaderTemplate>
                        <ItemTemplate>
                            · <a class="ULink" href='RoomDetail.aspx?RoomID=<%# DataBinder.Eval(Container.DataItem, "RoomID") %>'>
                                <%# DataBinder.Eval(Container.DataItem, "RoomName") %>
                            </a>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlRoomDetail" runat="server" Visible="False" meta:resourcekey="pnlRoomDetailResource1">
        <table align="center" width="90%">
            <tr>
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="ltlRoomName" runat="server" CssClass="RoomName" meta:resourcekey="ltlRoomNameResource1"></asp:Label><br />
                            </td>
                        </tr>
                        <tr>
                            <td height="15">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <br />
                                <table width="100%">
                                    <tr>
                                        <td width="25%">
                                            <table>
                                                <tr>
                                                    <td valign="bottom" colspan="3">
                                                        <asp:Image runat="server" ID="imgBigPicture" Width="192px" Height="145px" ImageUrl="~/Images/HotelImages/Big/RoomDefault.jpg" meta:resourcekey="imgBigPictureResource1" /></td>
                                                    <td valign="bottom">
                                                        <asp:Image runat="server" ID="imgSmallPicture" Width="92px" Height="69px" ImageUrl="~/Images/HotelImages/Small/RoomDefault.jpg" meta:resourcekey="imgSmallPictureResource1" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="left" width="67%" style="padding-left: 28px;">
                                            <br />
                                            <div id="dvProperties" runat="server">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="15" align="right">
                                <asp:HyperLink runat="server" ID="hlOtherRooms" CssClass="ULink" NavigateUrl="javascript:history.back()"
                                    Text="Diðer Odalar Ý&#231;in Týklayýnýz" meta:resourcekey="hlOtherRoomsResource1"></asp:HyperLink>
                        </tr>
                        <tr>
                            <td class="RoomDescription">
                                <b>
                                    <asp:Label ID="lblRoomDescription" runat="server" Text="Oda A&#231;ýklamasý" meta:resourcekey="lblRoomDescriptionResource1"></asp:Label></b><br />
                                <asp:Literal ID="ltlDescription" runat="server" meta:resourcekey="ltlDescriptionResource1"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <table width="100%">
                        <tr>
                            <td class="PriceHeader">
                                <asp:Literal runat="server" ID="ltlPriceTitle" meta:resourcekey="ltlPriceTitleResource1" Text="
                            ODA FÝYAT LÝSTESÝ
                                "></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="2">
                            </td>
                        </tr>
                    </table>
                    <asp:Repeater ID="rptPrices" runat="server" OnItemDataBound="rptPrices_ItemDataBound">
                        <HeaderTemplate>
                            <table class="rptTable" border="1" cellpadding="5" width="100%">
                                <tr class="rptHeader">
                                    <td>
                                        <b>
                                            <asp:Literal ID="ltlTitleRoomName" runat="server" Text="Adý" meta:resourcekey="ltlTitleRoomNameResource1"></asp:Literal></b></td>
                                    <td>
                                        <b>
                                            <asp:Literal ID="ltlTitleDay" runat="server" Text="G&#252;n" meta:resourcekey="ltlTitleDayResource1"></asp:Literal></b></td>
                                    <td align="center">
                                        <b>
                                            <asp:Literal ID="ltlTitleRoomQuantity" runat="server" Text="Adedi" meta:resourcekey="ltlTitleRoomQuantityResource1"></asp:Literal></b></td>
                                    <td style="padding-left: 8px;">
                                        <b>
                                            <asp:Literal ID="ltlTitlePrice" runat="server" Text="Oda Fiyatý" meta:resourcekey="ltlTitlePriceResource1"></asp:Literal></b></td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="rptItem">
                                <td>
                                    <%# ltlRoomName.Text %>
                                </td>
                                <td>
                                    <%# ((DateTime)DataBinder.Eval(Container.DataItem, "AvailabilityDate")).Date.ToLongDateString() %>
                                </td>
                                <td align="center">
                                    <%# DataBinder.Eval(Container.DataItem, "Quantity") %>
                                </td>
                                <td style="padding-left: 8px;">
                                    <asp:Literal ID="ltlCurrencyLeft" runat="server" meta:resourcekey="ltlCurrencyLeftResource1"></asp:Literal>
                                    <%# DataBinder.Eval(Container.DataItem, "Price") %>
                                    &nbsp;&nbsp;
                                    <asp:Literal ID="ltlCurrencyRight" runat="server" meta:resourcekey="ltlCurrencyRightResource1"></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td colspan="5" height="2" bgcolor="#768aa5">
                                </td>
                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>

<br />

<uc2:uctPopupBottom ID="uctPopupBottom1" runat="server" />

