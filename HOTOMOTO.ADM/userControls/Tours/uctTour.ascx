<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTour.ascx.cs" Inherits="userControls_Tours_uctTour" %>
<%@ Register Src="uctTourProperties.ascx" TagName="uctTourProperties" TagPrefix="uc6" %>
<%@ Register Src="uctTourImages.ascx" TagName="uctTourImages" TagPrefix="uc5" %>
<%@ Register Src="uctTourCities.ascx" TagName="uctTourCities" TagPrefix="uc4" %>
<%@ Register Src="../Common/uctCalendar.ascx" TagName="uctCalendar" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctMLTabs.ascx" TagName="uctMLTabs" TagPrefix="uc1" %>
<%@ Register Src="../uctMessage.ascx" TagName="uctMessage" TagPrefix="uc2" %>
<uc2:uctMessage ID="UctMessage1" runat="server" />
<div class="b710">
    <div class="title">
        TUR EKLE</div>
    <div class="main">
        <div class="info">
            Tur Genel Bilgileri</div>
        <div style="margin: 10px;">
            <uc1:uctMLTabs ID="UctMLTabs1" runat="server" />
        </div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblIsActive" runat="server" Text="Aktif mi?" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:CheckBox ID="cbIsActive" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblTourType" runat="server" Text="Tur Tipi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:DropDownList ID="ddlisDaily" runat="server">
                            <asp:ListItem Selected="True" Value="day">G&#252;nl&#252;k Tur</asp:ListItem>
                            <asp:ListItem Value="notday">Gezi Turu</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblMinCap" runat="server" Text="Minimum Katýlým" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtMinCap" runat="server" Width="54px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblAcc" runat="server" CssClass="label" Text="Konaklamalý mý?"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:CheckBox ID="cbAcc" runat="server" /></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblTra" runat="server" CssClass="label" Text="Ulaþým var mý?"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:CheckBox ID="cbTra" runat="server" /></td>
                </tr>
            </table>
        </div>
        <div class="info">
            Tarihler</div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblStartDate" runat="server" Text="Baþlangýç Tarihi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <uc3:uctCalendar ID="calStartDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblEndDate" runat="server" Text="Bitiþ Tarihi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <uc3:uctCalendar ID="calEndDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblDays" runat="server" CssClass="label" Text="Hangi Günler Olacak"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:CheckBoxList ID="cblDays" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="monday">Pazartesi</asp:ListItem>
                            <asp:ListItem Value="tuesday">Salý</asp:ListItem>
                            <asp:ListItem Value="wednesday">&#199;arþamba</asp:ListItem>
                            <asp:ListItem Value="thursday">Perþembe</asp:ListItem>
                            <asp:ListItem Value="friday">Cuma</asp:ListItem>
                            <asp:ListItem Value="saturday">Cumartesi</asp:ListItem>
                            <asp:ListItem Value="sunday">Pazar</asp:ListItem>
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="Label1" runat="server" CssClass="label" Text="Baþlangýç Günü"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:DropDownList ID="ddlStartDay" runat="server">
                            <asp:ListItem Selected="True" Value="1">Pazartesi</asp:ListItem>
                            <asp:ListItem Value="2">Salý</asp:ListItem>
                            <asp:ListItem Value="3">&#199;arþamba</asp:ListItem>
                            <asp:ListItem Value="4">Perþembe</asp:ListItem>
                            <asp:ListItem Value="5">Cuma</asp:ListItem>
                            <asp:ListItem Value="6">Cumartesi</asp:ListItem>
                            <asp:ListItem Value="7">Pazar</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
        </div>
        <div class="info">
            Özellikler</div>
        <div style="margin: 10px;">
            <table>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblProps" runat="server" CssClass="label" Text="Özellikler"></asp:Label></td>
                    <td nowrap="nowrap">
                        <uc6:uctTourProperties ID="UctTourProperties1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="info">
            Þehirler</div>
        <div style="margin: 10px;">
            <table>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblCity" runat="server" Text="Þehirler" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <uc4:uctTourCities ID="UctTourCities1" runat="server"></uc4:uctTourCities>
                    </td>
                </tr>
            </table>
        </div>
        <div class="info">
            Resimler</div>
        <div style="margin: 10px;">
            <table>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblPhotos" runat="server" Text="Resimler" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <uc5:uctTourImages ID="UctTourImages1" runat="server"></uc5:uctTourImages>
                    </td>
                </tr>
            </table>
        </div>
        <div class="info">
            Fiyat Bilgileri</div>
        <div style="margin: 10px;">
            <table>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblPr" runat="server" Text="Tur Fiyatý" CssClass="label"></asp:Label>
                    </td>
                    <td nowrap="nowrap">
                        <table>
                            <tr>
                                <td><asp:Label ID="lblPrEUR" runat="server" Text="EUR" CssClass="label"></asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrEUR" runat="server" Width="60px"></asp:TextBox>
                                </td>
                                <td><asp:Label ID="lblPrUSD" runat="server" Text="USD" CssClass="label"></asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrUSD" runat="server" Width="60px"></asp:TextBox>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblPRA" runat="server" Text="Konaklama Fiyatý" CssClass="label"></asp:Label>
                    </td>
                    <td nowrap="nowrap">
                        <table>
                            <tr>
                                <td><asp:Label ID="lblPrAEUR" runat="server" Text="EUR" CssClass="label"></asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrAEUR" runat="server" Width="60px"></asp:TextBox>
                                </td>
                                <td><asp:Label ID="lblPrAUSD" runat="server" Text="USD" CssClass="label"></asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrAUSD" runat="server" Width="60px"></asp:TextBox>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
                 <tr>
                    <td valign="top">
                        <asp:Label ID="lblPRT" runat="server" Text="Ulaþým Fiyatý" CssClass="label"></asp:Label>
                    </td>
                    <td nowrap="nowrap">
                        <table>
                            <tr>
                                <td><asp:Label ID="lblPRTEUR" runat="server" Text="EUR" CssClass="label"></asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPRTEUR" runat="server" Width="60px"></asp:TextBox>
                                </td>
                                <td><asp:Label ID="lblPRTUSD" runat="server" Text="USD" CssClass="label"></asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPRTUSD" runat="server" Width="60px"></asp:TextBox>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </table>
        </div>
        <div class="info">
           </div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                <td colspan="2" align="right">
                <asp:ImageButton ID="btnPublish" runat="server" ImageUrl="~/img/btnYayinla.gif" ToolTip="Kaydet"
                            AlternateText="Yayýnla" OnClick="btnPublish_Click"/>
                </td>
                </tr>
                
            </table>
        </div>
    </div>
</div>
