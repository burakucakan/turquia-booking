<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="ReservationFinish.aspx.cs" Inherits="ReservationFinish" %>

<%@ Register Src="UserControls/Common/uctReservationFinish.ascx" TagName="uctReservationFinish"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctReservationFinish ID="UctReservationFinish1" runat="server" />
</asp:Content>

