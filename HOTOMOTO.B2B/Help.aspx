<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Help" %>

<%@ Register Src="~/UserControls/Help/uctHelp.ascx" TagName="uctHelp" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<uc1:uctHelp ID="uctHelp1" runat="server" />
</asp:Content>

