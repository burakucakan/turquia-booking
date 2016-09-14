<%@ Page Language="C#" MasterPageFile="~/2_block.master" AutoEventWireup="true" CodeFile="Hotels.aspx.cs" Inherits="Hotels" Title="Oteller @ Turquia Yönet - Guarmo" %>
<%@ Register Src="UserControls/uctListOfHotels.ascx" TagName="uctListOfHotels" TagPrefix="uc4" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator" TagPrefix="uc3" %>
<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc1" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
    <uc1:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphRightBlock" Runat="Server">
    <uc3:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
    <uc2:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cphTitle">
    Oteller</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="cph710">
	<uc4:uctListOfHotels ID="UctListOfHotels1" runat="server" />
</asp:Content>

