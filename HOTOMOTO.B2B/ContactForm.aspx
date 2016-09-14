<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="ContactForm.aspx.cs" Inherits="Help_ContactForm" ValidateRequest="false" %>
<%@ Register Src="~/UserControls/Help/uctContactForm.ascx" TagName="uctContactForm" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctContactForm ID="uctContactForm1" runat="server" />
</asp:Content>

