<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctUserForm.ascx.cs" Inherits="UserControls_UserManagement_uctUserForm" %>
<%@ Register Src="../ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc1" %>

<%-- BEGIN USER INFO --%>

<table class="rptTable" width="100%">
    <tr>
        <td colspan="2" height="25" style="padding-left: 14px; padding-top: 3px;">
            <asp:Label ID="ltlTitleUserInfo" runat="server" CssClass="clRed" Text="KULLANICI BÝLGÝLERÝ" meta:resourcekey="ltlTitleUserInfoResource1" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:HiddenField ID="hdUserCreateDate" runat="server" />
            <table width="100%" cellpadding="3" cellspacing="3">
                <tr class="rptItem">
                    <td width="25%">
                        <asp:Label runat="server" ID="lblUserName" Text="Kullanýcý Adý" meta:resourcekey="lblUserNameResource1" />:
                    </td>
                    <td width="75%">
                        <asp:RequiredFieldValidator ErrorMessage="Lütfen Kullanýcý Adýný Giriniz !" ID="ErrUserName"
                            ControlToValidate="txtUserName" runat="server" Display="None" SetFocusOnError="True" meta:resourcekey="ErrUserNameResource1"></asp:RequiredFieldValidator>
                        <asp:TextBox CssClass="TextBox" runat="server" ID="txtUserName" Width="85%" meta:resourcekey="txtUserNameResource1"></asp:TextBox>
                    </td>
                </tr>
                <tr class="rptItem">
                    <td>
                        <asp:Label runat="server" ID="lblPassword" Text="Þifre" meta:resourcekey="lblPasswordResource1" />:
                    </td>
                    <td>
                        <asp:HiddenField ID="hdPassword" runat="server" />
                        <asp:RequiredFieldValidator ErrorMessage="Lütfen Þifrenizi Giriniz !" ID="ErrPassword" ControlToValidate="txtPassword" runat="server" Display="None" SetFocusOnError="True" meta:resourcekey="ErrPasswordResource1"></asp:RequiredFieldValidator>
                        <asp:TextBox TextMode="Password" CssClass="TextBox" runat="server" MaxLength="20" ID="txtPassword" Width="85%" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                    </td>
                </tr>
                <tr class="rptItem">
                    <td>
                        <asp:Label runat="server" ID="lblPassword2" Text="Re-Þifre" meta:resourcekey="lblPassword2Resource1" />:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Lütfen Þifrenizin Tekrarýný Giriniz !"
                            ID="ErrPassword2" ControlToValidate="txtPassword2" runat="server" Display="None"
                            SetFocusOnError="True" meta:resourcekey="ErrPassword2Resource1"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword2"
                            Display="None" ControlToValidate="txtPassword" CssClass="Error" ErrorMessage="Ýki Þifre Ayný Olmalý"
                            SetFocusOnError="True" meta:resourcekey="CompareValidator1Resource1"></asp:CompareValidator>
                        <asp:TextBox TextMode="Password" CssClass="TextBox" runat="server" ID="txtPassword2"
                            Width="85%" meta:resourcekey="txtPassword2Resource1"></asp:TextBox>
                    </td>
                </tr>
                <tr class="rptItem">
                    <td>
                        <asp:Label runat="server" ID="lblPerm" Text="Yetkisi" meta:resourcekey="lblPermResource1" />:
                    </td>
                    <td>
                        <asp:DropDownList CssClass="DropDownList" runat="server" Width="88%" ID="ddlPerm" meta:resourcekey="ddlPermResource1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="rptItem">
                    <td>
                        <asp:Label runat="server" ID="lblName" Text="Ýsim" meta:resourcekey="lblNameResource1" />:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Lütfen Ýsminizi Giriniz !" ID="errName"
                            ControlToValidate="txtLastName" runat="server" Display="None" SetFocusOnError="True" meta:resourcekey="errNameResource1"></asp:RequiredFieldValidator>
                        <asp:TextBox CssClass="TextBox" runat="server" ID="txtName" Width="85%" meta:resourcekey="txtNameResource1"></asp:TextBox>
                    </td>
                </tr>
                <tr class="rptItem">
                    <td>
                        <asp:Label runat="server" ID="lblLastName" Text="Soy Ýsim" meta:resourcekey="lblLastNameResource1" />:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Lütfen Soy Adýnýzý Giriniz !" ID="errLastName"
                            ControlToValidate="txtLastName" runat="server" Display="None" SetFocusOnError="True" meta:resourcekey="errLastNameResource1"></asp:RequiredFieldValidator>
                        <asp:TextBox CssClass="TextBox" runat="server" ID="txtLastName" Width="85%" meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                    </td>
                </tr>
                <tr class="rptItem">
                    <td>
                        <asp:Label runat="server" ID="lblEmail" Text="Email" meta:resourcekey="lblEmailResource1" />:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Lütfen Email Adresinizi Giriniz !" ID="errEmail"
                            ControlToValidate="txtEmail" runat="server" Display="None" SetFocusOnError="True" meta:resourcekey="errEmailResource1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            CssClass="Error" Display="None" ErrorMessage="Email Adresinizi Doðru Giriniz"
                            SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                        <asp:TextBox CssClass="TextBox" runat="server" ID="txtEmail" Width="85%" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    </td>
                </tr>                                                    
            </table>
        </td>
    </tr>
    
    <tr>
        <td colspan="2" style="padding-left: 6px;">
            <asp:ValidationSummary ShowSummary="False" CssClass="Error" ShowMessageBox="True" ID="ValidationSummary1" runat="server" meta:resourcekey="ValidationSummary1Resource1" />
        </td>
    </tr>
</table>

<%-- END USER INFO --%>

<br />

<asp:UpdatePanel ID="UserInfo" runat="server">
<ContentTemplate>                                    

<table class="rptTable" width="100%">
    <tr>
        <td colspan="2" height="25" style="padding-left: 14px; padding-top: 3px;">
            <asp:Label ID="ltlTitleAddressInfo" runat="server" CssClass="clRed" Text="ADRES BÝLGÝLERÝ" meta:resourcekey="ltlTitleAddressInfoResource1" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="pnlAddress" runat="server" Width="100%" meta:resourcekey="pnlAddressResource1">
            </asp:Panel>
        </td>
    </tr>
</table>

<br />

<table class="rptTable" width="100%">
    <tr>
        <td colspan="2" height="25" style="padding-left: 14px; padding-top: 3px;">
            <asp:Label ID="ltlTitleAccessInfo" runat="server" CssClass="clRed" Text="ERÝÞÝM BÝLGÝLERÝ" meta:resourcekey="ltlTitleAccessInfoResource1" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="pnlAccess" runat="server" Width="100%" meta:resourcekey="pnlAccessResource1">
            </asp:Panel>
        </td>
    </tr>
</table>

<br />

<uc1:ModalPopup ID="ModalPopup1" runat="server" />

</ContentTemplate>
</asp:UpdatePanel>

<asp:Button CssClass="Button" ID="btnSave" runat="server" Text="KULLANICIYI KAYDET" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
<br /><br />