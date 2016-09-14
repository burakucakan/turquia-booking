<%@ Page Language="C#" MasterPageFile="~/2_block.master" AutoEventWireup="true" CodeFile="B2BUsers.aspx.cs" Inherits="B2BUsers" Title="Untitled Page" %>

<%@ Register Src="UserControls/uctListOfB2BUsers.ascx" TagName="uctListOfUsers" TagPrefix="uc2" %>

<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc1" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
	TagPrefix="uc4" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
	<uc1:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" Runat="Server">
	B2B Kullanýcýlarý
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph710" Runat="Server">
	<uc2:uctListOfUsers ID="UctListOfUsers1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphRightBlock" Runat="Server">
	<uc4:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphFooter" Runat="Server">
	<uc5:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>



