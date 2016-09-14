<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotelSearch.ascx.cs" Inherits="userControls_HotelSearch" %>
<asp:UpdatePanel ID="upHotelSearch" runat="server">
    <ContentTemplate>
        <table>
                    <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" CssClass="label" Text="Otel Adý"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="label"></asp:Label></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
