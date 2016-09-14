<%@ Page AutoEventWireup="true" CodeFile="Tours.aspx.cs" Inherits="Tours" Language="C#"
	MasterPageFile="~/2_block.master" Title="Turlar @ Turquia Yönet - Guarmo" %>

<%@ Register Src="UserControls/uctListOfTours.ascx" TagName="uctListOfTours" TagPrefix="uc4" %>

<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc1" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc2" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
	TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="cphUserInfo">
	<uc1:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="cphTitle">
	Turlar
</asp:Content>
<asp:Content ID="Content3" runat="Server" ContentPlaceHolderID="cph710">
	<uc4:uctListOfTours ID="UctListOfTours1" runat="server" />
	
</asp:Content>
<asp:Content ID="Content4" runat="Server" ContentPlaceHolderID="cphRightBlock">
	<uc3:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" runat="Server" ContentPlaceHolderID="cphFooter">
	<uc2:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>
