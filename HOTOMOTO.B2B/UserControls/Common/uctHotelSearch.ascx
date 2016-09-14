<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotelSearch.ascx.cs" Inherits="UserControls_Common_uctHotelSearch" %>
<%@ Register Src="~/UserControls/ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Common/DDL/uctDDLHotelClasses.ascx" TagName="uctDDLHotelClasses" TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/Common/uctTxtDate.ascx" TagName="uctTxtDate" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/Common/DDL/uctDDLCities.ascx" TagName="uctDDLCities" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Common/DDL/uctDDLCountries.ascx" TagName="uctDDLCountries" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/uctGrayBoxBottom.ascx" TagName="uctGrayBoxBottom" TagPrefix="uc1" %>

<%@ Register 
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

    <asp:Panel ID="pnlHeader" runat="server" meta:resourcekey="pnlHeaderResource1">
        <table class="Box Padding" width="100%">
        <tr>
            <td class="MenuHeader CursorHand">
            
                <table id="Table14" class="Treb clNavy"  style="width: 100%">
                    <tr>
                        <td align="Left">
                            <asp:Literal runat="server" id="ltlDetailSearchHeader" Text="DETAYLI ARAMA" meta:resourcekey="ltlDetailSearchHeaderResource1" /></td>
                        <td align="Right">
                            <asp:Image runat="server" id="imgArrowClue" ImageUrl="~/Images/Icons/ArrowUp.gif" meta:resourcekey="imgArrowClueResource1" /></td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr><td class="HrTd"/></tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlContent" runat="server" meta:resourcekey="pnlContentResource1">
    
        <table class="Box Padding" width="100%">
            <tr>
                <td>
                <br />
                
                    <table align="center" width="96%">
                        <tr>
                            <td width="49%">
                                <table width="100%">
                                    <tr>
                                        <td class="clRed">
                                            <asp:Literal ID="ltlSearchTitleDate" runat="server" Text="REZERVASYON BÝLGÝLERÝ" meta:resourcekey="ltlSearchTitleDateResource1"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="Box" width="100%" height="110">
                                                <tr>
                                                    <td class="Padding">
                                                        <table cellpadding="2" width="96%" align="center">
                                                            <tr>
                                                                <td width="30%">
                                                                    <asp:Literal ID="ltlSearchTitleArrival" runat="server" Text="Arrival" meta:resourcekey="ltlSearchTitleArrivalResource1" /></td>
                                                                <td width="70%">
                                                                    <uc4:uctTxtDate ID="uctArrivalDate" runat="server"></uc4:uctTxtDate>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="ltlSearchTitleDeparture" runat="server" Text="Departure" meta:resourcekey="ltlSearchTitleDepartureResource1" /></td>
                                                                <td>
                                                                    <uc4:uctTxtDate ID="uctDepartureDate" runat="server"></uc4:uctTxtDate>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="ltlSearchTitleRoomQuantity" runat="server" Text="Room Quantity" meta:resourcekey="ltlSearchTitleRoomQuantityResource1" /></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlRoomQuantity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoomQuantity_SelectedIndexChanged" meta:resourcekey="ddlRoomQuantityResource1">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            
                            <td width="2%">&nbsp;</td>
                            
                            <td width="49%">
                                <table width="100%">
                                    <tr>
                                        <td class="clRed">
                                            <asp:Literal ID="ltlSearchTitleHotelInfo" runat="server" Text="OTEL BÝLGÝLERÝ" meta:resourcekey="ltlSearchTitleHotelInfoResource1"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="Box" width="100%" height="110">
                                                <tr>
                                                    <td class="Padding">
                                                        <table cellpadding="2" width="96%" align="center">
                                                            <tr>
                                                               <td width="30%">
                                                                    <asp:Literal ID="lttSearchTitleCity" runat="server" Text="City" meta:resourcekey="lttSearchTitleCityResource1" /></td>
                                                                <td width="70%">
                                                                    <uc3:uctDDLCities ID="uctDDLCities" runat="server"></uc3:uctDDLCities>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lttSearchTitleHotelName" runat="server" Text="Hotel Name" meta:resourcekey="lttSearchTitleHotelNameResource1" /></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtHotelName" CssClass="TextBox" Width="93%" meta:resourcekey="txtHotelNameResource1" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lttSearchTitleHotelClasses" runat="server" Text="Hotel Class" meta:resourcekey="lttSearchTitleHotelClassesResource1" /></td>
                                                                <td>
                                                                    <uc5:uctDDLHotelClasses ID="UctDDLHotelClasses1" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    
                    <asp:Panel ID="pnlRooms" runat="server" Width="100%" meta:resourcekey="pnlRoomsResource1">
                    <br />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" height="34" valign="top">
                    <table width="96%">
                        <tr>
                            <td align="left" class="clRed">* 
                                <asp:Literal ID="ltlSearchNote" runat="server" meta:resourcekey="ltlSearchNoteResource1" Text="
                                    Arama Sýrasýnda yazýlacak &#246;nemli not buraya yazýlabilir..
                                "></asp:Literal></td>
                            <td align="right">
                                <asp:Button runat="server" CssClass="Button" ID="btnOtelSearch" Text="ARAMAYI BAÞLAT" OnClick="btnOtelSearch_Click" meta:resourcekey="btnOtelSearchResource1" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <uc1:uctGrayBoxBottom ID="UctGrayBoxBottom1" runat="server" />    

    </asp:Panel>

    <uc6:ModalPopup ID="ModalPopup1" runat="server" />

<ajaxToolkit:CollapsiblePanelExtender ID="ajCpSearch" runat="server"
    TargetControlID="pnlContent"
    ExpandControlID="pnlHeader"
    CollapseControlID="pnlHeader"
    ImageControlID="imgArrowClue"   
    ExpandedImage="~/Images/Icons/ArrowUp.gif"
    CollapsedImage="~/Images/Icons/ArrowDown.gif"
    SuppressPostBack="True" BehaviorID="ctl00_ajCpSearch" Enabled="True" />