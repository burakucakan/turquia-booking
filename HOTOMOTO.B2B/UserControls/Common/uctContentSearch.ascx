<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctContentSearch.ascx.cs" Inherits="UserControls_Common_uctContentSearch" %>

<table id="Table15" class="PagesTable Box">
<tr>
<td>
                    
<table id="Table16" width="100%">

<%-- BEGIN SEARCH BOX HEADER --%>
<tr>
    <td class="BoxHeader BoxTitle">
        <asp:Literal runat="server" id="ltlBoxHeaderTitle" Text="Arama" meta:resourcekey="ltlBoxHeaderTitleResource1" />
    </td>                                            
</tr>
<%-- END SEARCH BOX HEADER --%>

<%-- BEGIN SEARCH BOX CONTENT --%>
<tr>
<td class="Padding" style="height: 114px;">

<table id="Table17" width="96%" cellpadding="2" cellspacing="2">

    <tr>
        <td class="clNavy">
            <asp:Literal runat="server" id="ltlSearchContentTitle" Text="Ülkeler hakkýnda bilgi edinebilirsiniz." meta:resourcekey="ltlSearchContentTitleResource1"/>
        </td>
    </tr>

    <tr>
        <td>
            <asp:TextBox runat="server" id="txtSearch" CssClass="TextBox" width="96%" meta:resourcekey="txtSearchResource1"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td align="Right">
            <asp:Button runat="server" CssClass="Button" id="btnSearch" Text="ARAMA YAP" CausesValidation="False" meta:resourcekey="btnSearchResource1"/>
        </td>
    </tr>
    
</table>

</td>
</tr>
<%-- END SEARCH BOX CONTENT --%>

</table>

</td>
</tr>                            
</table>