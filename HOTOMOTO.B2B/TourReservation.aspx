<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="TourReservation.aspx.cs" Inherits="TourReservation" %>
<%@ Register Src="~/UserControls/Tour/uctTourReservation.ascx" TagName="uctTourReservation" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctTourReservation ID="uctTourReservation1" runat="server" />
</asp:Content>
