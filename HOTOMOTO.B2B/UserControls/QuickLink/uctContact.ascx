<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctContact.ascx.cs" Inherits="QuickLink_uctContact" %>

<table id="Table21" class="PagesTable Box">
<tr>
    <td>
                                        
        <table id="Table22" width="100%">
        
            <%-- BEGIN CONTACT BOX HEADER --%>
            <tr>
                <td class="BoxHeader BoxTitle">
                    <asp:Literal runat="server" id="ltlContactBoxTitle" Text="Ýletiþim Bilgileri" meta:resourcekey="ltlContactBoxTitleResource1" />
                </td>                                            
            </tr>
            <%-- END CONTACT BOX HEADER --%>
            
            <%-- BEGIN CONTACT INFO --%>
            <tr>
                <td class="Padding">
                <br />
                <asp:Literal runat="server" id="ltlContactInformation" meta:resourcekey="ltlContactInformationResource1" Text="              &#13;&#10;&#13;&#10;                Retur Group <br />&#13;&#10;                Valikonagi Caddesi 73/3 <br />&#13;&#10;                Nisantasi - Estambul, Turquía  <br /><br />   &#13;&#10;                Teléfono 24Hs: +90 212 225 0012  <br />&#13;&#10;                Fax : +90 212 225 0743 <br /><br />&#13;&#10;&#13;&#10;                "></asp:Literal>
                
                <br />
                <asp:HyperLink runat="server" ID="Mail" Text="info@turquia.com" NavigateUrl="mailto:info@turquia.com" meta:resourcekey="MailResource1"></asp:HyperLink>
                
                <br /><br /><br />
                »&nbsp;&nbsp;<asp:HyperLink runat="server" CssClass="clNavy" ID="HyperLink1" Text="Ýletiþim Formu Ýçin Týklayýnýz." NavigateUrl="~/ContactForm.aspx" meta:resourcekey="HyperLink1Resource1"></asp:HyperLink>
                <br /><br /><br />                
                </td>
            </tr>
            <%-- END CONTACT INFO --%>
            
        </table>
    
    </td>
</tr>                            
</table>