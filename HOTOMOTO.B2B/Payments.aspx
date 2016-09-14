<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="Payments" %>
<%@ Register Src="UserControls/Payments/uctPayments.ascx" TagName="uctPayments" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctPayments ID="UctPayments1" runat="server" />
</asp:Content>

