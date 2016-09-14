<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctLoginInfo.ascx.cs" Inherits="UserControls_Common_uctLoginInfo" %>
<table id="Table7" class="LoginInfo">
<tr>
    <td class="Padding">
    
        <table id="Table8" cellspacing="3" cellpadding="3">
        
            <tr>
                <td>
                    <b><asp:Literal runat="server" id="ltlUserName" Text="Sn: " meta:resourcekey="ltlUserNameResource1" /></b>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Literal ID="ltlDate" runat="server" meta:resourcekey="ltlDateResource1" /> <br />
                    <asp:Literal runat="server" id="ltlEntry" Text="Siteye Giriþ: " meta:resourcekey="ltlEntryResource1" />
                    <asp:Literal ID="ltlEntryDate" runat="server" meta:resourcekey="ltlEntryDateResource1" /> <br /><br />»&nbsp;
                    <asp:HyperLink Enabled="False" runat="server" ID="hlReservation" Text="Rezervasyon Sayfasý" NavigateUrl="~/" meta:resourcekey="hlReservationResource1"></asp:HyperLink>
                </td>
            </tr>                                                    

            <tr style="display: none;">
                <td>
                
                    <asp:Panel Visible="False" runat="server" id="pnlMessageBox" CssClass="MessageBox" meta:resourcekey="pnlMessageBoxResource1">
                        <asp:Literal runat="server" id="ltlMessages" Text="Mesaj Kutunuz" meta:resourcekey="ltlMessagesResource1" />
                    </asp:Panel>
        
                </td>
            </tr>  
            
        </table>
                                                    
    </td>
</tr>
</table>