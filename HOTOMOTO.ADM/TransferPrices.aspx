<%@ Page Language="C#" MasterPageFile="~/2_block.master" AutoEventWireup="true" CodeFile="TransferPrices.aspx.cs" Inherits="TransferPrices" Title="Untitled Page" %>

<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc1" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
    TagPrefix="uc2" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc3" %>
<%@ Register Src="userControls/Transfer/uctTransferPrices.ascx" TagName="uctTransferPrices"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
    <uc1:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
Transfer Fiyatlar�
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph710" Runat="Server">
    <uc4:uctTransferPrices ID="UctTransferPrices1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRightBlock" Runat="Server">
    <uc2:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
    <uc3:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

