<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTourReservation.ascx.cs" Inherits="UserControls_Tour_uctTourReservation" %>
<%@ Register Src="~/UserControls/ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc3" %>

<table class="PagesTable Box">
    <tr>
        <td>
        
            <table width="100%">			
                <tr>
                    <td class="TourReservationHeaderBack MainTopHeader">
                        TOUR RESERVATION PAGE</td>
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
                                                <asp:Label ID="ltlTourName" runat="server" meta:resourcekey="ltlTourNameResource1"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp; (
                                                <asp:Label ID="ltlArrivalDate" runat="server" meta:resourcekey="ltlArrivalDateResource1"></asp:Label>
                                                &nbsp;-&nbsp;
                                                <asp:Label ID="ltlDepartureDate" runat="server" meta:resourcekey="ltlDepartureDateResource1"></asp:Label>
                                                )
                                            </div>
                                            <br />
                                            <div style="text-align: left;">
                                            
                                                <asp:Literal runat="server" ID="ltlTourID" Visible="False" meta:resourcekey="ltlTourIDResource1"></asp:Literal>

                                                <asp:Literal runat="server" ID="ltlDesc" meta:resourcekey="ltlDescResource1"></asp:Literal>
                                                <br /><br />
                                                <b> <asp:Literal ID="lblTitleMinCapacity" runat="server" Text="Minimum Capacity" meta:resourcekey="lblTitleMinCapacityResource1" />: </b>
                                                <asp:Literal runat="server" ID="ltlMinCapacity" meta:resourcekey="ltlMinCapacityResource1"></asp:Literal>
                                                <br /><br />
                                                
                                                <asp:Label ForeColor="Red" ID="ltlDateInfoTitle" runat="server" Text="TUR TARÝH BÝLGÝLERÝ" meta:resourcekey="ltlDateInfoTitleResource1" /><br />
                                                <table width="464" class="Box" cellpadding="3" cellspacing="3">
                                                    <tr>
                                                        <td width="113">
                                                            <asp:Literal ID="ltlChooseDateTitle" runat="server" Text="Tur Tarihleri" meta:resourcekey="ltlChooseDateTitleResource1" />: 
                                                        </td>
                                                        <td width="351" align="left">
                                                            <asp:DropDownList Width="200px" ID="ddlDates" runat="server" CssClass="DropDownList" meta:resourcekey="ddlDatesResource1"></asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                                
                                                <br /><br />
                                            <asp:Label ForeColor="Red" id="ltlGuestInfoTitle" runat="server" Text="KÝÞÝ BÝLGÝLERÝ" meta:resourcekey="ltlGuestInfoTitleResource1" /><br />
                                            <table width="464" class="Box" cellpadding="3" cellspacing="3">
                                                <tr>
                                                    <td width="145">
                                                        <asp:Literal ID="ltlAdultCount" runat="server" Text="Adult Count" meta:resourcekey="ltlAdultCountResource1" />:</td>
                                                    <td width="48">
                                                        <asp:TextBox ID="txtAdultCount" runat="server" CssClass="TextBox" Text="2" Width="45px" OnUnload="txtAdultCount_Unload" AutoPostBack="True" meta:resourcekey="txtAdultCountResource1" />
                                                    </td>
                                                    <td width="20" align="left">
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAdultCount" Display="Dynamic" ErrorMessage="*" MaximumValue="1000" MinimumValue="0" SetFocusOnError="True" Type="Integer" meta:resourcekey="RangeValidator1Resource1"></asp:RangeValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdultCount" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="50">
                                                        <asp:Literal ID="ltlTitleAdultPP" runat="server" Text="PerPerson" meta:resourcekey="ltlTitleAdultPPResource1"></asp:Literal>: </td>
                                                    <td width="70">
                                                        <asp:Label CssClass="CurrPrefix" ID="lblAdultPPCurrencyLeft" runat="server" meta:resourcekey="lblAdultPPCurrencyLeftResource1" />
                                                        <asp:Label CssClass="Price" ID="lblAdultPP" runat="server" Text="0" meta:resourcekey="lblAdultPPResource1" />
                                                        <asp:Label CssClass="CurrPrefix" ID="lblAdultPPCurrencyRight" runat="server" meta:resourcekey="lblAdultPPCurrencyRightResource1" />
                                                    </td>
                                                    <td width="50">
                                                        <asp:Literal ID="ltlTitleAdultTotalPrice" runat="server" Text="TotalPrice" meta:resourcekey="ltlTitleAdultTotalPriceResource1"></asp:Literal>: </td>
                                                    <td width="70">
                                                        <asp:Label CssClass="CurrPrefix" ID="lblAdultTotalPriceCurrencyLeft" runat="server" meta:resourcekey="lblAdultTotalPriceCurrencyLeftResource1" />
                                                        <asp:Label CssClass="Price" ID="lblAdultTotalPrice" runat="server" Text="0" meta:resourcekey="lblAdultTotalPriceResource1" />
                                                        <asp:Label CssClass="CurrPrefix" ID="lblAdultTotalPriceCurrencyRight" runat="server" meta:resourcekey="lblAdultTotalPriceCurrencyRightResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                   <td>
                                                        <asp:Literal ID="ltlChildCount" runat="server" Text="Child Count" meta:resourcekey="ltlChildCountResource1" />&nbsp;
                                                        (<asp:Literal ID="ltlChildCountMinAge" runat="server" meta:resourcekey="ltlChildCountMinAgeResource1" />-
                                                        <asp:Literal ID="ltlChildCountMaxAge" runat="server" meta:resourcekey="ltlChildCountMaxAgeResource1" />):
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChildCount" runat="server" CssClass="TextBox" Text="0" Width="45px" OnUnload="txtChildCount_Unload" AutoPostBack="True" meta:resourcekey="txtChildCountResource1" />
                                                    <td width="20" align="left">
                                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtChildCount" Display="Dynamic" ErrorMessage="*" MaximumValue="1000" MinimumValue="0" SetFocusOnError="True" Type="Integer" meta:resourcekey="RangeValidator2Resource1"></asp:RangeValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtChildCount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator></td>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltlTitleChildPP" runat="server" Text="PerPerson" meta:resourcekey="ltlTitleChildPPResource1"></asp:Literal>: </td>
                                                    <td>
                                                        <asp:Label CssClass="CurrPrefix" ID="lblChildPPCurrencyLeft" runat="server" meta:resourcekey="lblChildPPCurrencyLeftResource1" />
                                                        <asp:Label CssClass="Price" ID="lblChildPP" runat="server" Text="0" meta:resourcekey="lblChildPPResource1" />
                                                        <asp:Label CssClass="CurrPrefix" ID="lblChildPPCurrencyRight" runat="server" meta:resourcekey="lblChildPPCurrencyRightResource1" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltlTitleChildTotalPrice" runat="server" Text="TotalPrice" meta:resourcekey="ltlTitleChildTotalPriceResource1"></asp:Literal>: </td>
                                                    <td>
                                                        <asp:Label CssClass="CurrPrefix" ID="lblChildTotalPriceCurrencyLeft" runat="server" meta:resourcekey="lblChildTotalPriceCurrencyLeftResource1" />
                                                        <asp:Label CssClass="Price" ID="lblChildTotalPrice" runat="server" Text="0" meta:resourcekey="lblChildTotalPriceResource1" />
                                                        <asp:Label CssClass="CurrPrefix" ID="lblChildTotalPriceCurrencyRight" runat="server" meta:resourcekey="lblChildTotalPriceCurrencyRightResource1" />
                                                    </td>
                                                </tr>                                                
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="clNavy">
                                                        <asp:Literal ID="ltlTotalTitle" runat="server" Text="Toplam Tutar: " meta:resourcekey="ltlTotalTitleResource1" />
                                                        <asp:Label CssClass="CurrPrefix" ID="lblTotalPriceCurrencyLeft" runat="server" meta:resourcekey="lblTotalPriceCurrencyLeftResource1" />
                                                        <asp:Label CssClass="Price" ID="lblTotalPrice" runat="server" Text="0" meta:resourcekey="lblTotalPriceResource1" />
                                                        <asp:Label CssClass="CurrPrefix" ID="lblTotalPriceCurrencyRight" runat="server" meta:resourcekey="lblTotalPriceCurrencyRightResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br /><br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <uc3:modalpopup id="ModalPopup1" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="DetailFormat">
                    
                        <asp:UpdatePanel id="upBtnCheckOut" runat="server">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnCheckOut" CssClass="Button" Text="REZERVASYONU YAP" OnClick="btnCheckOut_Click" meta:resourcekey="btnCheckOutResource1" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        <br /><br />
                        
                    </td>
                </tr>
            </table>
        
		</td>
    </tr>
</table>