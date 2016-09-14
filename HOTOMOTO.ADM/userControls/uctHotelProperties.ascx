<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotelProperties.ascx.cs" Inherits="userControls_uctHotelProperties" %>
        <asp:CheckBoxList ID="cblHotelProperties" runat="server" DataTextField="Property"
            DataValueField="HotelPropertyID" RepeatColumns="4" Width="100%">
        </asp:CheckBoxList>