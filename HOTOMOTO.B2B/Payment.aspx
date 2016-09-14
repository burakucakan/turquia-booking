<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment"  %>
<%@ Register Src="UserControls/Common/uctPayment.ascx" TagName="uctPayment" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctPayment ID="UctPayment1" runat="server" />
</asp:Content>

