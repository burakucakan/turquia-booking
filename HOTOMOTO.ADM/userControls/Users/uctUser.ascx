<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctUser.ascx.cs" Inherits="userControls_Users_uctUser" %>
<%@ Register Src="../Common/ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc2" %>
<%-- BEGIN USER INFO --%>
<div class="b710">
    <div class="title">
        KULLANICI Y�NET�M�</div>
    <div class="main">
        <div class="info">
            Kullan�c� Genel Bilgileri</div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td>
                        <asp:HiddenField ID="hdUserCreateDate" runat="server" />
                        <table width="100%" cellpadding="3" cellspacing="3">
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblCC" Text="M��teri" />:
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" Width="88%" ID="ddlCusts">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%">
                                    <asp:Label runat="server" ID="lblUserName" Text="Kullan�c� Ad�" meta:resourcekey="lblUserNameResource1" />:
                                </td>
                                <td width="75%">
                                    <asp:RequiredFieldValidator ErrorMessage="L�tfen Kullan�c� Ad�n� Giriniz !" ID="ErrUserName"
                                        ControlToValidate="txtUserName" runat="server" Display="None" SetFocusOnError="True"
                                        meta:resourcekey="ErrUserNameResource1"></asp:RequiredFieldValidator>
                                    <asp:TextBox CssClass="TextBox" runat="server" ID="txtUserName" Width="85%" meta:resourcekey="txtUserNameResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPassword" Text="�ifre" meta:resourcekey="lblPasswordResource1" />:
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdPassword" runat="server" />
                                    <asp:RequiredFieldValidator ErrorMessage="L�tfen �ifrenizi Giriniz !" ID="ErrPassword"
                                        ControlToValidate="txtPassword" runat="server" Display="None" SetFocusOnError="True"
                                        meta:resourcekey="ErrPasswordResource1"></asp:RequiredFieldValidator>
                                    <asp:TextBox TextMode="Password" CssClass="TextBox" runat="server" MaxLength="20"
                                        ID="txtPassword" Width="85%" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPassword2" Text="Re-�ifre" meta:resourcekey="lblPassword2Resource1" />:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ErrorMessage="L�tfen �ifrenizin Tekrar�n� Giriniz !"
                                        ID="ErrPassword2" ControlToValidate="txtPassword2" runat="server" Display="None"
                                        SetFocusOnError="True" meta:resourcekey="ErrPassword2Resource1"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword2"
                                        Display="None" ControlToValidate="txtPassword" CssClass="Error" ErrorMessage="�ki �ifre Ayn� Olmal�"
                                        SetFocusOnError="True" meta:resourcekey="CompareValidator1Resource1"></asp:CompareValidator>
                                    <asp:TextBox TextMode="Password" CssClass="TextBox" runat="server" ID="txtPassword2"
                                        Width="85%" meta:resourcekey="txtPassword2Resource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPerm" Text="Yetkisi" meta:resourcekey="lblPermResource1" />:
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="DropDownList" runat="server" Width="88%" ID="ddlPerm"
                                        meta:resourcekey="ddlPermResource1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblName" Text="�sim" meta:resourcekey="lblNameResource1" />:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ErrorMessage="L�tfen �sminizi Giriniz !" ID="errName"
                                        ControlToValidate="txtLastName" runat="server" Display="None" SetFocusOnError="True"
                                        meta:resourcekey="errNameResource1"></asp:RequiredFieldValidator>
                                    <asp:TextBox CssClass="TextBox" runat="server" ID="txtName" Width="85%" meta:resourcekey="txtNameResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblLastName" Text="Soy �sim" meta:resourcekey="lblLastNameResource1" />:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ErrorMessage="L�tfen Soy Ad�n�z� Giriniz !" ID="errLastName"
                                        ControlToValidate="txtLastName" runat="server" Display="None" SetFocusOnError="True"
                                        meta:resourcekey="errLastNameResource1"></asp:RequiredFieldValidator>
                                    <asp:TextBox CssClass="TextBox" runat="server" ID="txtLastName" Width="85%" meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblEmail" Text="Email" meta:resourcekey="lblEmailResource1" />:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ErrorMessage="L�tfen Email Adresinizi Giriniz !" ID="errEmail"
                                        ControlToValidate="txtEmail" runat="server" Display="None" SetFocusOnError="True"
                                        meta:resourcekey="errEmailResource1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                        CssClass="Error" Display="None" ErrorMessage="Email Adresinizi Do�ru Giriniz"
                                        SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                                    <asp:TextBox CssClass="TextBox" runat="server" ID="txtEmail" Width="85%" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 6px;">
                        <asp:ValidationSummary ShowSummary="False" CssClass="Error" ShowMessageBox="True"
                            ID="ValidationSummary1" runat="server" meta:resourcekey="ValidationSummary1Resource1" />
                    </td>
                </tr>
            </table>
        </div>
    
    <br />
    <asp:UpdatePanel ID="UserInfo" runat="server">
        <ContentTemplate>
            <div class="info">
                Adres Bilgileri</div>
            <div style="margin: 10px;">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlAddress" runat="server" Width="100%" meta:resourcekey="pnlAddressResource1">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="info">
                Eri�im Bilgileri</div>
            <div style="margin: 10px;">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlAccess" runat="server" Width="100%" meta:resourcekey="pnlAccessResource1">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
            <uc2:ModalPopup ID="ModalPopup1" runat="server" />
            <br />
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button CssClass="Button" ID="btnSave" runat="server" Text="KULLANICIYI KAYDET"
        OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
    <br />
    <br />
    </div>
</div>
