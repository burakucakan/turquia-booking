<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="HotelReservation.aspx.cs" Inherits="HotelReservation" %>

<%@ Register Src="UserControls/Hotel/uctHotelReservation.ascx" TagName="uctHotelReservation" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">

    <uc1:uctHotelReservation ID="UctHotelReservation1" runat="server" />

</asp:Content>

