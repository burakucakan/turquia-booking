<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="UserControls/uctMessage.ascx" TagName="uctMessage" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Turquia Yönet Kullanıcı Girişi</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
	<link href="inc/galileo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
		<div style="margin:100px 0 0 100px; width:230px;">
			<div class="b230">
				<asp:UpdatePanel ID="upLoginPanel" runat="server">
					<ContentTemplate>
						<div class="title">
							<asp:Literal ID="ltrLoginBlockTitle" runat="server">TURQUIA YÖNETİCİ GİRİŞİ</asp:Literal></div>
						<div class="main" style="width:230px;">
							<div class="info">
								Yönetim paneli kullanıcı kontrolü.</div>
							<div class="label">
								<label for="txtUsername">
									Kullanıcı adı:</label></div>
							<div class="txtarea">
								<asp:TextBox ID="txtUsername" CssClass="textBox" runat="server"></asp:TextBox></div>
							<div class="label">
								<label for="txtPassword">
									Parola:</label></div>
							<div class="txtarea">
								<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textBox"></asp:TextBox></div>
							<div>&nbsp;</div>
							<div class="option">
								<asp:CheckBox ID="chkRememberMe" runat="server" Text="Beni Hatırla" /></div>
							<div class="action">
								<asp:ImageButton ID="btnLogin" ImageUrl="~/img/btnGiris.gif" runat="server" OnClick="btnLogin_Click" /></div>
							<div class="c">
							</div>
						</div>
						<div class="bottom">
						</div>
						<uc1:uctMessage ID="uctErrorMessage" runat="server" Visible="false" />
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=EST\SQL2005;Initial Catalog=TURQUIA;User ID=sa;Password=12345sS"
            ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
    </form>
</body>
</html>
