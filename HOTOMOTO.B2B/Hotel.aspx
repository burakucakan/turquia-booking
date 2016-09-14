<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Hotel.aspx.cs" Inherits="Hotel" %>
<%@ Register Src="~/UserControls/Hotel/uctHotel.ascx" TagName="uctHotel" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctHotel ID="UctHotel1" runat="server" />
</asp:Content>

