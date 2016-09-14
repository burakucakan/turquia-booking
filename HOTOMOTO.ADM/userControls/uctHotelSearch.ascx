<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotelSearch.ascx.cs" Inherits="userControls_HotelSearch" %>
<asp:UpdatePanel ID="upHotelSearch" runat="server">
    <ContentTemplate>
        <table>
                    <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblHotelName" runat="server" CssClass="label" Text="Otel Adý"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtHotelName" runat="server" CssClass="textBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblCountry" runat="server" Text="Ülke" CssClass="label"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblCity" runat="server" Text="Þehir" CssClass="label"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="combobox">
                    </asp:DropDownList></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
