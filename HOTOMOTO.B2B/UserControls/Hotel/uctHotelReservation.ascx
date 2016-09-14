<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotelReservation.ascx.cs" Inherits="UserControls_Hotel_uctHotelReservation" %>
<%@ Register Src="../Transfer/uctTransfer.ascx" TagName="uctTransfer" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc3" %>

<table class="PagesTable Box">
    <tr>
        <td>
        
            <table width="100%">
                <tr>
                    <td class="ReservationHeaderBack MainTopHeader">
                        HOTEL RESERVATION PAGE</td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upDetail" runat="server">
                                <ContentTemplate>
                            
                                <table width="100%">
                            <tr>
                                <td class="DetailFormat">
                                    <br />
                                    <div class="Title" style="text-align: left;">
                                        <asp:Label ID="ltlHotelName" runat="server" meta:resourcekey="ltlHotelNameResource1"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp; (<asp:Label ID="ltlArrivalDate" runat="server" meta:resourcekey="ltlArrivalDateResource1"></asp:Label>
                                        &nbsp;-&nbsp;
                                        <asp:Label ID="ltlDeparture" runat="server" meta:resourcekey="ltlDepartureResource1"></asp:Label>)
                                    </div>                                    
                                    
                                    <br />

<asp:Panel runat="server" ID="pnlRoomList" meta:resourcekey="pnlRoomListResource1"></asp:Panel>
                                    
                                    <br />
                                    <br />
                                    
                                    <table width="100%">
                                        <tr>
                                            <td align="left" class="clNavy">
                                                <asp:Literal ID="ltlTotalTitle" runat="server" Text="Toplam Tutar: " meta:resourcekey="ltlTotalTitleResource1" />
                                                <asp:Label CssClass="CurrPrefix" ID="lblTotalPriceCurrencyLeft" runat="server" meta:resourcekey="lblTotalPriceCurrencyLeftResource1" />
                                                <asp:Label CssClass="Price" ID="lblTotalPrice" runat="server" meta:resourcekey="lblTotalPriceResource1" />
                                                <asp:Label CssClass="CurrPrefix" ID="lblTotalPriceCurrencyRight" runat="server" meta:resourcekey="lblTotalPriceCurrencyRightResource1" />
                                            </td>
                                            <td align="right">
                                                <asp:HyperLink CssClass="RptItem" ID="hlRoomsDetail" runat="server" NavigateUrl="javascript:RoomsDetail()"
                                                    Text="Odalar ve Fiyat Detaylarý Ý&#231;in Týklayýnýz..." meta:resourcekey="hlRoomsDetailResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <br />
                                    
                                    <br /><br />

    <asp:Panel ID="pnlGuestsAndTours" runat="server" meta:resourcekey="pnlGuestsAndToursResource1"> </asp:Panel>

    <input type="hidden" id="hdTours" name="hdTours" />

                                    <br />
                                    <br />
                                </td>
                                <td width="170" valign="top" style="padding-right: 14px;">
                                    <br />
                                    <asp:Panel ID="pnlExcTours" runat="server" meta:resourcekey="pnlExcToursResource1">
                                            <table class="rptTable">
                                                <tr>
                                                    <td class="clWhite" height="30" bgcolor="#B7BFD5" style="padding-left: 8px;">
                                                        <b>
                                                            <asp:Literal runat="server" ID="ltlExcursionTitle" Text="G&#220;NL&#220;K TURLAR" meta:resourcekey="ltlExcursionTitleResource1"></asp:Literal></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="6"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:Literal ID="ltlExcTourDDLTitle" runat="server" Text="G&#252;nl&#252;k Turlarýn Listesi" meta:resourcekey="ltlExcTourDDLTitleResource1"></asp:Literal>
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:DropDownList CssClass="DropDownList" ID="ddlExcTours" Width="150px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExcTours_SelectedIndexChanged" meta:resourcekey="ddlExcToursResource1"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="6"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:Literal ID="ltlExcTourDatesDDLTitle" runat="server" Text="D&#252;zenlendiði Tarihler" meta:resourcekey="ltlExcTourDatesDDLTitleResource1"></asp:Literal>
                                                    </td>
                                                </tr>                                                  
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:DropDownList CssClass="DropDownList" ID="ddlExcTourDates" Width="150px" runat="server" meta:resourcekey="ddlExcTourDatesResource1"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="padding-top: 7px; padding-bottom: 7px;">
                                                        <table width="90%">
                                                            <tr>
                                                                <td class="Title" style="text-align: left;">
                                                                    <asp:Literal ID="ltlExcMinCapacity" runat="server" Visible="False" meta:resourcekey="ltlExcMinCapacityResource1"></asp:Literal>
                                                                    <asp:Literal ID="ltlExcCurrLeft" runat="server" meta:resourcekey="ltlExcCurrLeftResource1"></asp:Literal>
                                                                    <asp:Literal ID="ltlExcPrice" runat="server" meta:resourcekey="ltlExcPriceResource1"></asp:Literal>
                                                                    <asp:Literal ID="ltlExcCurrRight" runat="server" meta:resourcekey="ltlExcCurrRightResource1"></asp:Literal></td>
                                                                <td style="text-align: right;">
                                                                    <asp:Button CssClass="Button" ID="btnAddExcTour" runat="server" Text="Add Tour" CausesValidation="False" OnClick="btnAddExcTour_Click" meta:resourcekey="btnAddExcTourResource1" />
                                                                </td>
                                                            </tr>
                                                        </table>                                                    
                                                    </td>
                                                </tr>
                                            </table>
                                    </asp:Panel>
                                            <br /><br />
                                    <asp:Panel ID="pnlCircTours" runat="server" meta:resourcekey="pnlCircToursResource1">
                                            <table class="rptTable">
                                                <tr>
                                                    <td class="clWhite" height="30" bgcolor="#B7BFD5" style="padding-left: 8px;" >
                                                        <b>
                                                            <asp:Literal runat="server" ID="ltlCircTitle" Text="GEZÝLER" meta:resourcekey="ltlCircTitleResource1"></asp:Literal></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="6"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:Literal ID="ltlCircTourDDLTitle" runat="server" Text="Gezilerin Listesi" meta:resourcekey="ltlCircTourDDLTitleResource1"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:DropDownList CssClass="DropDownList"  ID="ddlCircTours" Width="150px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCircTours_SelectedIndexChanged" meta:resourcekey="ddlCircToursResource1"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="6"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:Literal ID="ltlCircTourDatesDDLTitle" runat="server" Text="D&#252;zenlendiði Tarihler" meta:resourcekey="ltlCircTourDatesDDLTitleResource1"></asp:Literal>
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td style="padding-left: 8px;">
                                                        <asp:DropDownList CssClass="DropDownList" ID="ddlCircTourDates" Width="150px" runat="server" meta:resourcekey="ddlCircTourDatesResource1"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="padding-top: 7px; padding-bottom: 7px;">
                                                        <table width="90%">
                                                            <tr>
                                                                <td class="Title" style="text-align: left;">
                                                                    <asp:Literal ID="ltlCircMinCapacity" runat="server" Visible="False" meta:resourcekey="ltlCircMinCapacityResource1"></asp:Literal>
                                                                    <asp:Literal ID="ltlCircCurrLeft" runat="server" meta:resourcekey="ltlCircCurrLeftResource1"></asp:Literal>
                                                                    <asp:Literal ID="ltlCircPrice" runat="server" meta:resourcekey="ltlCircPriceResource1"></asp:Literal>
                                                                    <asp:Literal ID="ltlCircCurrRight" runat="server" meta:resourcekey="ltlCircCurrRightResource1"></asp:Literal></td>
                                                                <td style="text-align: right;">
                                                                    <asp:Button CssClass="Button" ID="btnAddCircTour" runat="server" Text="Add Tour" CausesValidation="False" OnClick="btnAddCircTour_Click" meta:resourcekey="btnAddCircTourResource1" />
                                                                </td>
                                                            </tr>
                                                        </table>                                                    
                                                    </td>
                                                </tr>
                                            </table>
                                    </asp:Panel>

                                    <br />
                                </td>
                            </tr>
                        </table>
                        
                                <uc3:ModalPopup ID="ModalPopup1" runat="server" />
                                                       
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="DetailFormat">
                    
<%-- ::::::::::::::::::::::: BEGIN TRANSFER ::::::::::::::::::::::::::::::: --%>
                    
                        <asp:UpdatePanel ID="upTransfer" runat="server">
                            <ContentTemplate>

                                <table cellpadding="4" cellspacing="4" class="rptTable">
                                    <tr>
                                        <td align="left">
                                            <asp:Literal ID="ltlNoTransfer" runat="server" Text="Uygun Transfer Bulunamadý" Visible="False" meta:resourcekey="ltlNoTransferResource1"></asp:Literal>
                                            <asp:CheckBox ID="chTransfer" runat="server" Text="Transfer Ýstiyorum" AutoPostBack="True"
                                                OnCheckedChanged="chTransfer_CheckedChanged" meta:resourcekey="chTransferResource1" /></td>
                                    </tr>
                                </table>
                                <br />
                                <uc1:uctTransfer ID="UctTransfer1" runat="server" Visible="False" />
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
<%-- :::::::::::::::::::::::/// END TRANSFER ::::::::::::::::::::::::::::::: --%>
                        
                        <br />
                        
                        <asp:UpdatePanel id="upBtnChecOut" runat="server">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnCheckOut" CssClass="Button" Text="REZERVASYONU YAP" CausesValidation="False" OnClick="btnCheckOut_Click" meta:resourcekey="btnCheckOutResource1" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        <br />
                        <br />
                        
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>