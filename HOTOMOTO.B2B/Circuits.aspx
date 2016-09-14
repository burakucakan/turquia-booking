<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Circuits.aspx.cs" Inherits="Circuits" %>
<%@ Register Src="~/UserControls/Tour/uctTour.ascx" TagName="uctTour1" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctTour1 TourType="Circuits" ID="uctTour1" runat="server" />
</asp:Content>