<%@ Page Language="C#" MasterPageFile="~/2_block.master" AutoEventWireup="true" CodeFile="AddHotel.aspx.cs" Inherits="AddHotel" Title="Otel Ekle @ Turquia Yönet - Guarmo" %>

<%@ Register Src="userControls/uctAddress.ascx" TagName="uctAddress" TagPrefix="uc6" %>

<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc2" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
    TagPrefix="uc4" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc5" %>

<%@ Register Src="userControls/uctAddHotel.ascx" TagName="uctAddHotel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
    <uc2:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" Runat="Server">
    Otel Giriþi
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph710" Runat="Server">
    <uc1:uctAddHotel ID="UctAddHotel1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphRightBlock" Runat="Server">
    <uc4:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphFooter" Runat="Server">
    <uc5:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

