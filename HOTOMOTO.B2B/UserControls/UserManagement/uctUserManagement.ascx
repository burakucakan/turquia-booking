<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctUserManagement.ascx.cs" Inherits="UserControls_UserManagement_uctUserManagement" %>
<%@ Register Src="../ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/UserManagement/uctUserForm.ascx" TagName="uctUserForm" TagPrefix="uc2" %>

<table class="PagesTable Box">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td class="UserManagementHeaderBack MainTopHeader">
                        USER MANAGEMENT</td>
                </tr>
                <tr>
                    <td class="Padding">

                        <table width="100%" align="center" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="40%" valign="top">
                                
                                    <br />
                                    
                                    <asp:Repeater runat="server" ID="rptUsers" OnItemDataBound="rptUsers_ItemDataBound" OnItemCommand="rptUsers_ItemCommand">
                                    <HeaderTemplate>                                        
                                        <table class="rptTable" width="90%" cellpadding="5" cellspacing="2">
                                        <tr>
                                            <td height="20" colspan="3">
                                                <asp:Label CssClass="clRed" ID="lblTitleUsers" runat="server" Text="KAYITLI KULLANICILAR" meta:resourcekey="lblTitleUsersResource1"></asp:Label></td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="rptItem">
                                            <td>
                                                <b><asp:Literal runat="server" ID="ltlUser" Text=<%# DataBinder.Eval(Container.DataItem, "UserName") %> ></asp:Literal></b>
                                                <br />
                                                <asp:Literal runat="server" ID="ltlName" Text=<%# DataBinder.Eval(Container.DataItem, "Name") %> ></asp:Literal>
                                            </td>
                                            <td class="rptItem5" align="center">
                                                <asp:LinkButton runat="server" CausesValidation="False" ID="lbEdit" Text="G&#252;ncelle" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID") %>' meta:resourcekey="lbEditResource1"/>
                                            </td>
                                            <td class="rptItem5" align="center">
                                                <asp:LinkButton OnClientClick="javascript:return confirm('Silmek istediðinizden emin misiniz?')" runat="server" CausesValidation="False" ID="lbDelete" Text="SÝL" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID") %>' meta:resourcekey="lbDeleteResource1"/>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                    </asp:Repeater>
                                    
                                    <br /><br />
                                    <asp:Button CausesValidation="False" ID="btnNew" runat="server" CssClass="Button" Text="YENÝ KAYIT" OnClick="btnNew_Click" meta:resourcekey="btnNewResource1"/>
                                    <br /><br />
                                </td>                                                                
                                
                                <td width="60%" valign="top">
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

<uc1:ModalPopup ID="ModalPopup1" runat="server" />