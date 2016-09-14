<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctError.ascx.cs" Inherits="UserControls_Error_uctError" %>

<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
	<tr>
		<td class="LoginTop">
		    <asp:Image runat="server" ID="imgTopBack" Height="252px" ImageUrl="~/Images/Error/TopBack.jpg" meta:resourcekey="imgTopBackResource1" /></td>
	</tr>
    <tr>
        <td height="2" bgcolor="#FFFFFF"></td>
    </tr>	
	<tr>
		<td class="Caretta">
		    <asp:HyperLink runat="server" ID="hlimgCaretta" ImageUrl="~/Images/Login/Caretta.jpg" NavigateUrl="http://www.caretta.net" Target="_blank" meta:resourcekey="hlimgCarettaResource1" ></asp:HyperLink></td>
    </tr>
</table>

<div class="divError">
    <table width="500" bgcolor="#FFFFFF" align="center">
    <tr>
        <td>
            <br />
            <table width="460" align="center">
                <tr>
                    <td align="center" width="75">
                        <asp:Image runat="server" ID="imgIcon" ImageUrl="~/Images/Error/Icon.jpg" meta:resourcekey="imgIconResource1" /></td>
                    <td align="left" width="385"><b>
                        <asp:Label runat="server" ID="lblTitle" CssClass="Verd clRed" meta:resourcekey="lblTitleResource1" /></b>
                        <br /><br />
                        <asp:Label runat="server" ID="lblMessage" CssClass="Verd clBlack" Text="Bilinmeyen HATA!" meta:resourcekey="lblMessageResource1" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding: 20px;">
                        <asp:HyperLink ID="hlLink" runat="server" NavigateUrl="http://b2b.turquia.com" meta:resourcekey="hlLinkResource1">http://b2b.turquia.com</asp:HyperLink></td>
                </tr>            
            </table>

        </td>
    </tr>
    </table>    
</div>

<div class="divCopyright">
    <table width="100%">
    <tr>
        <td align="right">
            <asp:Label runat="server" ID="lblCopyright" CssClass="Verd clWhite" Text="Copyright © Retur Turizm ve Yayincilik A.S. - Estambul - Turquía" meta:resourcekey="lblCopyrightResource1" /></td>
    </tr>
    </table>    
</div>
