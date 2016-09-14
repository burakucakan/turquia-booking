<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="QuickLink_Contact" %>
<%@ Register Src="~/UserControls/QuickLink/uctContact.ascx" TagName="uctContact" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctContact ID="uctContact1" runat="server" />
</asp:Content>

