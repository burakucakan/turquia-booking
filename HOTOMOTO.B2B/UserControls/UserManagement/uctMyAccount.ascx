<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctMyAccount.ascx.cs" Inherits="UserControls_UserManagement_uctMyAccount" %>
<%@ Register Src="~/UserControls/UserManagement/uctUserForm.ascx" TagName="uctUserForm" TagPrefix="uc2" %>

<table class="PagesTable Box">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td class="UserManagementHeaderBack MainTopHeader">
                        <asp:Literal ID="ltrMyAccountTitle" runat="server" Text="MY ACCOUNT" meta:resourcekey="ltrMyAccountTitleResource1"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="Padding">

                        <table width="100%" align="center" cellpadding="2" cellspacing="2">
                            <tr>                              
                                <td valign="top">
                                    <br />
                                    
                                    <uc2:uctUserForm ID="uctUserForm1" runat="server" />
                                    
                                </td>
                                
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>