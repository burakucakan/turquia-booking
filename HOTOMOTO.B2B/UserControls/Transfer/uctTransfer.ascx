<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTransfer.ascx.cs" Inherits="UserControls_Transfer_uctTransfer" %>
<%@ Register Src="../ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc3" %>
<%@ Register Src="../Common/DDL/uctDDLTime.ascx" TagName="uctDDLTime" TagPrefix="uc2" %>
<%@ Register Src="../Common/uctTxtDate.ascx" TagName="uctTxtDate" TagPrefix="uc1" %>
<table width="100%" cellpadding="3" cellspacing="3" style="text-align: left;">
    <%-- ARRIVAL --%>
    <tr class="rptHeader">
        <td class="T clNavy">
            <asp:CheckBox ID="chArrival" AutoPostBack="True" runat="server" Checked="True" Text="Arrival"
                OnCheckedChanged="chArrival_CheckedChanged" meta:resourcekey="chArrivalResource1" />
        </td>
    </tr>
    <tr>
        <td class="ReservationInfoCell" align="center">
            <asp:Panel ID="pnlArrival" runat="server" meta:resourcekey="pnlArrivalResource1">
                <table width="94%" cellpadding="1" cellspacing="1" align="center">
                    <tr>
                        <td width="15%">
                            <asp:Literal ID="ltlArrivalPort" runat="server" Text="Geliþ Yeri (Port)" meta:resourcekey="ltlArrivalPortResource1" />
                        </td>
                        <td style="width: 34%">
                            <asp:DropDownList ID="ddlArrivalPorts" AutoPostBack="True" runat="server" CssClass="DropDownList"
                                Width="96%" OnSelectedIndexChanged="ddlArrivalPorts_SelectedIndexChanged" meta:resourcekey="ddlArrivalPortsResource1">
                            </asp:DropDownList></td>
                        <td>
                            <table cellpadding="2" cellspacing="2">
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltlTitleArrivalDate" runat="server" Text="Geliþ Tarihi" meta:resourcekey="ltlTitleArrivalDateResource1" /></td>
                                    <td>
                                        <asp:TextBox CssClass="TextBox" Width="120px" runat="server" ID="txtArrivalDate" meta:resourcekey="txtArrivalDateResource1"></asp:TextBox>
                                    </td>
                                    <td>
                                        <uc2:uctDDLTime ID="UctDDLTimeArrival" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" valign="top">
                            <asp:Literal ID="ltlArrivalDetail" runat="server" Text="U&#231;uþ Detaylarý" meta:resourcekey="ltlArrivalDetailResource1" />
                        </td>
                        <td style="width: 34%" valign="top">
                            <asp:TextBox runat="server" ID="txtArrivalDetail" CssClass="TextBox" TextMode="MultiLine"
                                Height="50px" Width="91%" meta:resourcekey="txtArrivalDetailResource1"></asp:TextBox></td>
                        <td valign="top">
                            <table cellpadding="2" cellspacing="2">
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltlTransferArrivalGuestCountTitle" runat="server" Text="Kiþi Sayýsý" meta:resourcekey="ltlTransferArrivalGuestCountTitleResource1"></asp:Literal></td>
                                    <td style="padding-left: 9px;">
                                        <asp:DropDownList AutoPostBack="True" ID="ddlTransferArrivalGuestCount" Width="120px" runat="server" CssClass="DropDownList" OnSelectedIndexChanged="ddlTransferArrivalGuestCount_SelectedIndexChanged" meta:resourcekey="ddlTransferArrivalGuestCountResource1"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="chGuide" AutoPostBack="True" runat="server" Text="Rehber Ýstiyorum" OnCheckedChanged="chGuide_CheckedChanged" meta:resourcekey="chGuideResource1" />
                                        &nbsp;»&nbsp;<b>
                                            <asp:Literal ID="ltlGuideCurrencyLeft" runat="server" meta:resourcekey="ltlGuideCurrencyLeftResource1"></asp:Literal>
                                            <asp:Literal ID="ltlGuidePrice" runat="server" meta:resourcekey="ltlGuidePriceResource1"></asp:Literal>
                                            <asp:Literal ID="ltlGuideCurrencyRight" runat="server" meta:resourcekey="ltlGuideCurrencyRightResource1"></asp:Literal> </b>
                                    </td>
                                </tr>
                            </table>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="8">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#A8E2FF" colspan="3" style="padding: 10px;">
                            <asp:Literal ID="ltlArrivalRegularOriginalPrice" runat="server" Visible="False" meta:resourcekey="ltlArrivalRegularOriginalPriceResource1"></asp:Literal>
                            <asp:Literal ID="ltlArrivalPrivateOriginalPrice" runat="server" Visible="False" meta:resourcekey="ltlArrivalPrivateOriginalPriceResource1"></asp:Literal>
                            <asp:RadioButton GroupName="chGroupArrival" ID="rdArrivalRegular" runat="server"
                                Checked="True" Text="REGULAR" meta:resourcekey="rdArrivalRegularResource1" />&nbsp; &nbsp;&nbsp;»&nbsp;&nbsp;
                            <asp:Literal ID="ltlArrivalRegularCurrencyLeft" runat="server" meta:resourcekey="ltlArrivalRegularCurrencyLeftResource1"></asp:Literal>
                            <asp:Label CssClass="Price" ID="lblArrivalRegularPrice" runat="server" meta:resourcekey="lblArrivalRegularPriceResource1"></asp:Label>
                            <asp:Literal ID="ltlArrivalRegularCurrencyRight" runat="server" meta:resourcekey="ltlArrivalRegularCurrencyRightResource1"></asp:Literal>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton GroupName="chGroupArrival" ID="rdArrivalPrivate" runat="server" Text="PRIVATE" meta:resourcekey="rdArrivalPrivateResource1" />&nbsp;&nbsp;&nbsp;»&nbsp;&nbsp;
                            <asp:Literal ID="ltlArrivalPrivateCurrencyLeft" runat="server" meta:resourcekey="ltlArrivalPrivateCurrencyLeftResource1"></asp:Literal>
                            <asp:Label CssClass="Price" ID="lblArrivalPrivatePrice" runat="server" meta:resourcekey="lblArrivalPrivatePriceResource1"></asp:Label>
                            <asp:Literal ID="ltlArrivalPrivateCurrencyRight" runat="server" meta:resourcekey="ltlArrivalPrivateCurrencyRightResource1"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="VSpace">
            &nbsp;</td>
    </tr>
    <%-- DEPARTURE --%>
    <tr class="rptHeader">
        <td class="T clNavy">
            <asp:CheckBox ID="chDeparture" AutoPostBack="True" runat="server"
                Text="Departure" OnCheckedChanged="chDeparture_CheckedChanged" meta:resourcekey="chDepartureResource1" />
        </td>
    </tr>
    <tr>
        <td class="ReservationInfoCell" align="center">
            <asp:Panel ID="pnlDeparture" runat="server" Enabled="False" meta:resourcekey="pnlDepartureResource1">
                <table width="94%" align="center">
                    <tr>
                        <td width="15%">
                            <asp:Literal ID="ltlDeparturePort" runat="server" meta:resourcekey="ltlDeparturePortResource1" Text="Gidiþ Yeri (Port)"></asp:Literal>
                        </td>
                        <td width="34%">
                            <asp:DropDownList ID="ddlDeparturePorts" AutoPostBack="True" runat="server" CssClass="DropDownList"
                                Width="96%" OnSelectedIndexChanged="ddlDeparturePorts_SelectedIndexChanged" meta:resourcekey="ddlDeparturePortsResource1">
                            </asp:DropDownList></td>
                        <td>
                            <table cellpadding="2" cellspacing="2">
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltlDepartureDateTime" runat="server" Text="Gidiþ Tarihi" meta:resourcekey="ltlDepartureDateTimeResource1" /></td>
                                    <td>
                                        <asp:TextBox CssClass="TextBox" Width="120px" runat="server" ID="txtDepartureDate" meta:resourcekey="txtDepartureDateResource1"></asp:TextBox>
                                    </td>
                                    <td>
                                        <uc2:uctDDLTime ID="UctDDLTimeDeparture" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" valign="top">
                            <asp:Literal ID="ltlDepartureDetail" runat="server" meta:resourcekey="ltlDepartureDetailResource1" Text="Detaylarý"></asp:Literal>
                        </td>
                        <td width="34%" valign="top">
                            <asp:TextBox runat="server" ID="txtDepartureDetail" CssClass="TextBox" TextMode="MultiLine"
                                Height="50px" Width="91%" meta:resourcekey="txtDepartureDetailResource1"></asp:TextBox></td>
                        <td>
                            <table cellpadding="2" cellspacing="2">
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltlTransferDepartureGuestCountTitle" runat="server" Text="Kiþi Sayýsý" meta:resourcekey="ltlTransferDepartureGuestCountTitleResource1"></asp:Literal></td>
                                    <td style="padding-left: 9px">
                                        <asp:DropDownList AutoPostBack="True" ID="ddlTransferDepartureGuestCount" Width="120px" runat="server" CssClass="DropDownList" OnSelectedIndexChanged="ddlTransferDepartureGuestCount_SelectedIndexChanged" meta:resourcekey="ddlTransferDepartureGuestCountResource1"></asp:DropDownList></td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="8">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#A8E2FF" colspan="5" style="padding: 10px;">
                            <asp:RadioButton GroupName="chGroupDeparture" ID="rdDepartureRegular" runat="server"
                                Checked="True" Text="REGULAR" meta:resourcekey="rdDepartureRegularResource1" />&nbsp; &nbsp;&nbsp;»&nbsp;&nbsp;
                            <asp:Literal ID="ltlDepartureRegularCurrencyLeft" runat="server" meta:resourcekey="ltlDepartureRegularCurrencyLeftResource1"></asp:Literal>
                            <asp:Label CssClass="Price" ID="lblDepartureRegularPrice" runat="server" meta:resourcekey="lblDepartureRegularPriceResource1"></asp:Label>
                            <asp:Literal ID="ltlDepartureRegularCurrencyRight" runat="server" meta:resourcekey="ltlDepartureRegularCurrencyRightResource1"></asp:Literal>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton GroupName="chGroupDeparture" ID="rdDeparturePrivate" runat="server" Text="PRIVATE" meta:resourcekey="rdDeparturePrivateResource1" />&nbsp;&nbsp;&nbsp;»&nbsp;&nbsp;
                            <asp:Literal ID="ltlDeparturePrivateCurrencyLeft" runat="server" meta:resourcekey="ltlDeparturePrivateCurrencyLeftResource1"></asp:Literal>
                            <asp:Label CssClass="Price" ID="lblDeparturePrivatePrice" runat="server" meta:resourcekey="lblDeparturePrivatePriceResource1"></asp:Label>
                            <asp:Literal ID="ltlDeparturePrivateCurrencyRight" runat="server" meta:resourcekey="ltlDeparturePrivateCurrencyRightResource1"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>

<uc3:ModalPopup ID="ModalPopupTransfer" runat="server" />

<br />
<div style="text-align: center">
    <asp:Button ID="btnTransfer" runat="server" CssClass="Button" Text="TRANSFERÝ GÖNDER" Visible="False" OnClick="btnTransfer_Click" meta:resourcekey="btnTransferResource1"/>
</div>
