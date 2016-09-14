<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctPayments.ascx.cs" Inherits="UserControls_Payments_uctPayments" %>
<%@ Register Src="~/UserControls/Payments/uctPaymentList.ascx" TagName="uctPaymentList" TagPrefix="uc1" %>

<table class="PagesTable Box">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td class="PaymentsHeaderBack MainTopHeader">
                        RESERVATIONS & PAYMENT</td>
                </tr>
                <tr>
                    <td class="Padding">

                        <table width="100%" align="center" cellpadding="2" cellspacing="2">
                            <tr>                              
                                <td valign="top">
                                
                                    <br />

                                    <table width="100%" class="Box" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td class="rptItem5 clRed" align="center" width="90"> »&nbsp; FILTER </td>
                                            <td width="10"></td>
                                            <td>Rezervasyon Tipi</td>
                                            <td>
                                                <asp:DropDownList CssClass="DropDownList" runat="server" ID="ddlReservationTypes" meta:resourcekey="ddlReservationTypesResource1">
                                                    <asp:ListItem Text="T&#252;m Kayýtlar" Value="%" Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                    <asp:ListItem Text="Sadece Hoteller" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                    <asp:ListItem Text="Sadece Turlar" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                    <asp:ListItem Text="Sadece Transferler" Value="4" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                                    <asp:ListItem Text="Hotel + Tur" Value="3" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                                    <asp:ListItem Text="Hotel + Transfer" Value="5" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                    <asp:ListItem Text="Tur + Transfer" Value="6" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                                    <asp:ListItem Text="Hotel + Tur + Transfer" Value="7" meta:resourcekey="ListItemResource8"></asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10"></td>
                                            <td> Users: </td>
                                            <td> <asp:DropDownList runat="server" ID="ddlUsers" CssClass="DropDownList" meta:resourcekey="ddlUsersResource1" /> </td>
                                            <td width="5"></td>
                                            <td align="center"> <asp:Button CssClass="Button" runat="server" ID="btnFilter" Text="Filtrele" OnClick="btnFilter_Click" meta:resourcekey="btnFilterResource1" /> </td>
                                        </tr>
                                    </table>
                                    
                                    <br />
                                    
                                    <uc1:uctPaymentList ID="UctPaymentList1" runat="server" />
                                    
                                    <br /><br />

                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td>
                                                <asp:Image ID="imgPendingHotel" runat="server" ToolTip="Hotel" ImageUrl="~/Images/Icons/ReservationTypes/Hotel.gif" meta:resourcekey="imgPendingHotelResource1" />
                                                <asp:Literal runat="server" ID="ltlHotelIcon" Text="Hotel" meta:resourcekey="ltlHotelIconResource1" />                                                
                                            </td>
                                            <td width="25"></td>
                                            <td>
                                                <asp:Image ID="imgPendingTour" runat="server" ToolTip="Tour" ImageUrl="~/Images/Icons/ReservationTypes/Tour.gif" meta:resourcekey="imgPendingTourResource1" />
                                                <asp:Literal runat="server" ID="ltlTourIcon" Text="Tour" meta:resourcekey="ltlTourIconResource1" />                                                
                                            </td>
                                            <td width="25"></td>
                                            <td>                                                
                                                <asp:Image ID="imgPendingTransfer" runat="server" ToolTip="Transfer" ImageUrl="~/Images/Icons/ReservationTypes/Transfer.gif" meta:resourcekey="imgPendingTransferResource1" />
                                                <asp:Literal runat="server" ID="ltlTransferIcon" Text="Transfer" meta:resourcekey="ltlTransferIconResource1" />
                                            </td>                                                                                        
                                        </tr>
                                    </table>
                                    
                                    <br /><br />
                                    
                                </td>
                                
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>