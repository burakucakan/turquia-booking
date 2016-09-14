<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Transfer.aspx.cs" Inherits="Transfer" %>
<%@ Register Src="~/UserControls/Transfer/uctTransferPage.ascx" TagName="uctTransferPage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">

    <uc1:uctTransferPage ID="UctTransferPage1" runat="server" />

</asp:Content>

