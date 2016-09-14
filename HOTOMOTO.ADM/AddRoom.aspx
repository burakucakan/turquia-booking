<%@ Page Language="C#" MasterPageFile="~/2_block.master" AutoEventWireup="true" CodeFile="AddRoom.aspx.cs" Inherits="AddRoom" Title="Oda Ekle @ Turquia Y�net - Guarmo" %>

<%@ Register Src="userControls/uctUserInfo.ascx" TagName="uctUserInfo" TagPrefix="uc2" %>
<%@ Register Src="userControls/uctAdministratorNavigator.ascx" TagName="uctAdministratorNavigator"
    TagPrefix="uc3" %>
<%@ Register Src="userControls/uctFooter.ascx" TagName="uctFooter" TagPrefix="uc4" %>
<%@ Register Src="userControls/uctAddRoom.ascx" TagName="uctAddRoom" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserInfo" Runat="Server">
    <uc2:uctUserInfo ID="UctUserInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" Runat="Server">
    Oda Giri�i
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph710" Runat="Server">
    <uc5:uctAddRoom id="UctAddRoom1" runat="server">
    </uc5:uctAddRoom>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphRightBlock" Runat="Server">
    <uc3:uctAdministratorNavigator ID="UctAdministratorNavigator1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphFooter" Runat="Server">
    <uc4:uctFooter ID="UctFooter1" runat="server" />
</asp:Content>

