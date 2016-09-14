<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctLogin.ascx.cs" Inherits="UserControls_Login_uctLogin" %>
<%@ Register Src="~/UserControls/ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/DDL/uctDDLLanguages.ascx" TagName="uctDDLLanguages" TagPrefix="uc1" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
	<tr>
		<td class="LoginTop">
		    <asp:Image runat="server" ID="imgTopBack" Height="256px" ImageUrl="~/Images/Login/TopBack.jpg" meta:resourcekey="imgTopBackResource1" /></td>
	</tr>
	<tr>
		<td class="Caretta">
		    <asp:Image runat="server" ID="imgCaretta" ImageUrl="~/Images/Login/Caretta.jpg" meta:resourcekey="imgCarettaResource1" /></td>
    </tr>
</table>

<div class="divLoginTableTitle">
    <asp:Label runat="server" ID="lblLoginTableTitle" CssClass="LoginTableTitle clWhite" Text="MÜÞTERÝ GÝRÝÞÝ" meta:resourcekey="lblLoginTableTitleResource1" />
</div>
   
<asp:UpdatePanel ID="UpLoginForm" runat="server">
<ContentTemplate>
    
    <div class="divLogin">
        <table class="LoginTable LoginText">
            <tr>
                <td>
                    <br />
                    <asp:Literal runat="server" ID="ltlCustomerNo" Text="M&#252;þteri No" meta:resourcekey="ltlCustomerNoResource1"></asp:Literal>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="Error" ID="RequiredFieldValidator1" runat="server" ErrorMessage="&#160;! L&#252;tfen M&#252;þteri Numaranýzý Giriniz !" SetFocusOnError="True" ControlToValidate="txtCustomerNo" ValidationGroup="vgLogin" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
               <td>
                    <asp:TextBox runat="server" ID="txtCustomerNo" CssClass="TextBox" Width="96%" MaxLength="10" meta:resourcekey="txtCustomerNoResource1" /></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Literal runat="server" ID="ltlUserCode" Text="Kullanýcý Adý" meta:resourcekey="ltlUserCodeResource1"></asp:Literal>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="Error" ID="RequiredFieldValidator2" runat="server" ErrorMessage="&#160;! L&#252;tfen Kullanýcý Adýný Giriniz !" SetFocusOnError="True" ControlToValidate="txtUserName" ValidationGroup="vgLogin" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
               <td>
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="TextBox" Width="96%" meta:resourcekey="txtUserNameResource1" /></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Literal runat="server" ID="ltlPass" Text="Þifre" meta:resourcekey="ltlPassResource1"></asp:Literal>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="Error" ID="RequiredFieldValidator3" runat="server" ErrorMessage="&#160;! L&#252;tfen Þifrenizi Giriniz !" SetFocusOnError="True" ControlToValidate="txtPass" ValidationGroup="vgLogin" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
               <td>
                    <asp:TextBox MaxLength="15" runat="server" ID="txtPass" CssClass="TextBox" Width="96%" TextMode="Password" meta:resourcekey="txtPassResource1" /></td>
            </tr>
            <tr id="trLanguagesTitle" runat="server" visible="false">
                <td>
                    <br />
                    <asp:Literal runat="server" ID="ltlLanguage" Text="Dil Se&#231;imi" meta:resourcekey="ltlLanguageResource1"></asp:Literal></td>
            </tr>
            <tr id="trLanguages" runat="server" visible="false">
               <td>
                   <uc1:uctDDLLanguages id="UctDDLLanguages1" runat="server">
                   </uc1:uctDDLLanguages></td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:Button runat="server" CssClass="Button" id="btnLogin" Text="G&#220;VENLÝ GÝRÝÞ" OnClick="btnLogin_Click" ValidationGroup="vgLogin" meta:resourcekey="btnLoginResource1" />
                    <br /></td>
            </tr>
            <tr>
                <td>
                    <br />
                    » <asp:LinkButton id="lbForgotPass" CssClass="Verd clRed" runat="server" Text="Þifremi Unuttum" OnClick="lbForgotPass_Click" CausesValidation="False" meta:resourcekey="lbForgotPassResource1"/>
                    <br />
                </td>
            </tr>    
        </table>
    </div>
    
    <uc2:ModalPopup ID="ModalPopup1" runat="server" />
    
</ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <asp:Panel runat="server" id="pnlForgotPassword" CssClass="divForgotPassword" Visible="False" meta:resourcekey="pnlForgotPasswordResource1">
        <table class="ForgotPassTable LoginText">
            <tr>
                <td>
                    <asp:Literal runat="server" ID="ltlMail" Text="Email: " meta:resourcekey="ltlMailResource1" /></td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtForgotMail" CssClass="TextBox" Width="200px" meta:resourcekey="txtForgotMailResource1" /></td>
                <td>
                    <asp:Button runat="server" CssClass="Button" id="btnForgotPass" Text="G&#214;NDER" CausesValidation="False" meta:resourcekey="btnForgotPassResource1"/></td>
            </tr>
        </table>
    </asp:Panel>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="lbForgotPass" EventName="Click" />
</Triggers>
</asp:UpdatePanel>

<div class="divCopyright">
    <table width="100%">
    <tr>
        <td align="right">
            <asp:Label runat="server" ID="lblCopyright" CssClass="Verd clWhite" Text="Copyright © Retur Turizm ve Yayincilik A.S. - Estambul - Turquía" meta:resourcekey="lblCopyrightResource1" /></td>
    </tr>
    </table>    
</div>