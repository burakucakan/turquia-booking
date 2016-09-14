<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Excursion.aspx.cs" Inherits="Excursion" %>
<%@ Register Src="~/UserControls/Tour/uctTour.ascx" TagName="uctTour" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <uc1:uctTour TourType="Excursion" ID="uctTour1" runat="server" />
</asp:Content>

