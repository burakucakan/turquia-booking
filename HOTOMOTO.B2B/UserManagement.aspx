<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>
<%@ Register Src="~/UserControls/UserManagement/uctUserManagement.ascx" TagName="uctUserManagement" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctUserManagement ID="uctUserManagement1" runat="server" />
</asp:Content>

