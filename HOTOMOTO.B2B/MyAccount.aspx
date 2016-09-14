<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>
<%@ Register Src="~/UserControls/UserManagement/uctMyAccount.ascx" TagName="uctMyAccount" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctMyAccount ID="uctMyAccount1" runat="server" />
</asp:Content>