<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTransferPage.ascx.cs" Inherits="UserControls_Transfer_uctTransferPage" %>
<%@ Register Src="~/UserControls/Transfer/uctTransfer.ascx" TagName="uctTransfer" TagPrefix="uc1" %>

<table class="PagesTable Box">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td class="TransferHeaderBack MainTopHeader">
                        TRANSFER PAGE</td>
                </tr>
                <tr>
                    <td class="Padding">
                        <br />
                        
                        <asp:UpdatePanel ID="upTransfer" runat="server">
                        <ContentTemplate>
                            <uc1:uctTransfer ID="UctTransfer1" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        <br /><br />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
