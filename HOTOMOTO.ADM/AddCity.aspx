<%@ Page AutoEventWireup="true" CodeFile="AddCity.aspx.cs" Inherits="AddCountry"
	Language="C#" MasterPageFile="~/2_block.master" Title="Þehir Ekle @ Turquia Yönet - Guarmo" %>

<%@ Register Src="userControls/uctAddCity.ascx" TagName="uctAddCity" TagPrefix="uc3" %>

<%@ Register Src="userControls/uctMessage.ascx" TagName="uctMessage" TagPrefix="uc5" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
	TagPrefix="uc6" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc7" %>

<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
	<uc1:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" Runat="Server">
	Ýçerik Yönetimi
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph710" Runat="Server">
	<uc3:uctAddCity ID="UctAddCity1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRightBlock" Runat="Server">
	<uc6:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphFooter" Runat="Server">
	<uc7:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

