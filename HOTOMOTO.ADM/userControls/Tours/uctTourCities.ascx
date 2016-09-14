<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTourCities.ascx.cs"
    Inherits="userControls_Tours_uctTourCities" %>
<asp:UpdatePanel ID="upCities" runat="server">
    <ContentTemplate>
        <table width="500" style="border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid">
            <tr>
                <td width="40%" style="height: 88px">
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCities" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="10%" align="center" valign="middle" style="height: 88px">
                    <asp:Button ID="btnAdd" runat="server" Text="Ekle" OnClick="btnAdd_Click" /><br />
                    <asp:Button ID="btnRem" runat="server" Text="Çýkar" OnClick="btnRem_Click" />
                </td>
                <td width="40%" style="height: 88px">
                    <asp:ListBox ID="lbCountCity" runat="server" Width="100%" Rows="5"></asp:ListBox>
                </td>
                <td width="10%" align="center" valign="middle" style="height: 88px">
                    <asp:Button ID="btnUp" runat="server" Text="Yukarý" OnClick="btnUp_Click" /><br />
                    <asp:Button ID="btnDown" runat="server" Text="Aþaðý" OnClick="btnDown_Click" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
