<%@ Page Language="C#" MasterPageFile="~/2_block.master" AutoEventWireup="true" CodeFile="Port.aspx.cs" Inherits="Port" Title="Untitled Page" %>

<%@ Register Src="userControls/Ports/uctPort.ascx" TagName="uctPort" TagPrefix="uc5" %>

<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc1" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
    TagPrefix="uc2" %>
<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc3" %>
<%@ Register Src="userControls/uctTopMenu.ascx" TagName="uctTopMenu" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
    <uc3:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    Liman ve Havaalaný Yönetimi
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph710" Runat="Server">
    <uc5:uctPort ID="UctPort1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRightBlock" Runat="Server">
    <uc2:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
    <uc1:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

