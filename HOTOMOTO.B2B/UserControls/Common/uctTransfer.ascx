<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTransfer.ascx.cs" Inherits="UserControls_Common_uctTransfer" %>

<table id="Table18" class="PagesTable Box">
<tr>
    <td>
                                        
        <table id="Table19" width="100%">
        
            <%-- BEGIN TRANSFER BOX HEADER --%>
            <tr>
                <td class="BoxHeader BoxTitle">
                    <asp:Literal runat="server" id="ltlTransferTitle" Text="Transfer" meta:resourcekey="ltlTransferTitleResource1" />
                </td>                                            
            </tr>
            <%-- END TRANSFER BOX HEADER --%>
            
            <%-- BEGIN TRANSFER BOX CONTENT --%>
            <tr>
                <td class="Padding" style="height: 114px;">
                
                    <table id="Table20" class="clNavy" cellspacing="3">
                        <tr>
                            <td align="Left" style="width: 110px;">
                                <asp:Image runat="server" id="imgTransfer" ImageUrl="~/Images/ContentImages/TransferImaj.jpg" meta:resourcekey="imgTransferResource1" /></td>
                            <td align="Left" style="width: 100%;">
                                <asp:Literal runat="server" id="ltlTransferBullet1" Text=". This error indicates address  of the" meta:resourcekey="ltlTransferBullet1Resource1" /><br />
                                <asp:Literal runat="server" id="ltlTransferBullet2" Text=". the IP address of the website you " meta:resourcekey="ltlTransferBullet2Resource1" /><br />
                                <asp:Literal runat="server" id="ltlTransferBullet3" Text=". Are trying to access. This is" meta:resourcekey="ltlTransferBullet3Resource1" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 100%;">
                                <asp:Literal runat="server" id="ltlTransferDescription" Text="
                                At the gateway could not find the IP address of the website you are trying to access.
                                " meta:resourcekey="ltlTransferDescriptionResource1" />
                            </td>
                        </tr>
                    </table>
                
                </td>
            </tr>
            <%-- END TRANSFER BOX CONTENT --%>
            
        </table>
    
    </td>
</tr>                            
</table>