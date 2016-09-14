<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="ReservationSummary.aspx.cs" Inherits="ReservationSummary" %>
<%@ Register Src="UserControls/Common/uctReservationSummary.ascx" TagName="uctReservationSummary" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="CPH1">
	<uc1:uctReservationSummary ID="UctReservationSummary1" runat="server" />
</asp:Content>

