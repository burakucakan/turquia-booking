<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctExtraInfo.ascx.cs" Inherits="UserControls_Common_uctExtraInfo" %>

<table id="Table16" cellspacing="2">

    <tr>
        <td>
            <asp:Literal runat="server" id="ltlIP" Text="IP: " meta:resourcekey="ltlIPResource1" />
        </td>
    </tr>
    
    <tr>
        <td class="HrTd" />
    </tr>
    
    <tr><td class="VSpace" /></tr>
                                            
    <tr>
        <td>
            <asp:HyperLink CssClass="TBlue" id="hlMail" runat="server" NavigateUrl="mailto:info@turquia.com" Target="_blank" Text="info@turquia.com" meta:resourcekey="hlMailResource1" />
            <asp:ImageButton ID="ImgNoEnter" runat="server" Width="0px" Height="0px" ImageUrl="~/Images/Util/Spacer.gif" CausesValidation="False" meta:resourcekey="ImgNoEnterResource1" />

        </td>
    </tr>
    
</table>