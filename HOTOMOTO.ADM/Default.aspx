<%@ Page Language="C#" MasterPageFile="~/3_block.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Turquia Yönet - Guarmo" %>

<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc7" %>

<%@ Register Src="userControls/uctSupportRequest.ascx" TagName="uctSupportRequest"
	TagPrefix="uc6" %>

<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc1" %>
<%@ Register Src="userControls/uctBulletinQuickAdd.ascx" TagName="uctBulletinQuickAdd"
	TagPrefix="uc3" %>
<%@ Register Src="userControls/uctLastAddedMain.ascx" TagName="uctLastAddedMain"
	TagPrefix="uc4" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
	TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
	<uc1:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" Runat="Server">
	Yönetim Merkezi
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphLeftBlock" Runat="Server">
	<uc3:uctBulletinQuickAdd ID="UctBulletinQuickAdd1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMiddleBlock" Runat="Server">
	<uc4:uctLastAddedMain ID="UctLastAddedMain1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRightBlock" Runat="Server">
	<uc5:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
	<uc6:uctSupportRequest ID="UctSupportRequest1" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphFooter" Runat="Server">
	<uc7:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

