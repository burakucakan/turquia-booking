<%@ Page Language="C#" MasterPageFile="~/2_block.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Customer" Title="Untitled Page" %>

<%@ Register Src="userControls/Customers/uctCustomer.ascx" TagName="uctCustomer"
    TagPrefix="uc4" %>




<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc1" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc2" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
    <uc1:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
Müþteri Yönetimi
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph710" Runat="Server">
    <uc4:uctCustomer ID="UctCustomer1" runat="server" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRightBlock" Runat="Server">
    <uc3:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
    <uc2:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

