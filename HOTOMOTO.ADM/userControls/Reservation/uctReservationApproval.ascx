<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctReservationApproval.ascx.cs" Inherits="userControls_Reservation_uctReservationApproval" %>
<%@ Register Src="../Common/uctCalendar.ascx" TagName="uctCalendar" TagPrefix="uc2" %>
<%@ Register Src="../Common/uctSuggest.ascx" TagName="uctSuggest" TagPrefix="uc1" %>
<div class="b710">
    <div class="title">
        ONAYLANACAK REZERVASYONLAR</div>
    <div class="main">
        <div style="margin: 10px;">
            <asp:UpdatePanel runat="server" ID="upAva">
            <ContentTemplate>
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblPL" runat="server">Müþteri</asp:Label>
                        </td>
                    <td>
                        <uc1:uctSuggest id="UctSuggest1" runat="server">
                        </uc1:uctSuggest></td>
                    <td>
                        </td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="lblH" runat="server">Otel</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlH" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlH_SelectedIndexChanged1">
                            </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="lblR" runat="server">Odalar</asp:Label></td>
                    <td>
                    <asp:DropDownList ID="ddlR" runat="server">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td >
                         <asp:Label ID="lblT" runat="server">Tur</asp:Label></td>
                    <td ><asp:DropDownList ID="ddlT" runat="server">
                    </asp:DropDownList></td>
                     <td >
                        <asp:Label ID="lblTr" runat="server">Liman</asp:Label></td>
                    <td >
                        <asp:DropDownList ID="ddlTr" runat="server">
                        </asp:DropDownList></td>
                </tr>
               <tr>
                    <td >
                        <asp:Label ID="lblBD" runat="server">Ýþlem Tarihi</asp:Label></td>
                    <td >
                        <uc2:uctCalendar ID="calBSDate" runat="server" />
                            </td>
                        <td >
                            </td>
                    <td >
                        <uc2:uctCalendar ID="calBEDate" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRD" runat="server">Rezervasyon Tarihi</asp:Label></td>
                    <td>
                        <uc2:uctCalendar ID="calRSDate" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <uc2:uctCalendar ID="calREDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="btnSearch" runat="server" Text="Ara" OnClick="btnSearch_Click"/></td>
                </tr>
                 <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                 <tr>
                    <td colspan="4" align="right">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" AllowPaging="True"  PageSize="5" OnRowCommand="GridView1_RowCommand">
                            <HeaderStyle BackColor="DimGray" ForeColor="White" />
                            <AlternatingRowStyle BackColor="LightGray" />
                            <Columns>
                                <asp:BoundField DataField="ReservationCode" HeaderText="Kod" />
                                <asp:BoundField DataField="Description" HeaderText="A&#231;ýklama" />
                                <asp:BoundField DataField="BookingDate" HeaderText="Ýþlem Zamaný" />
                                <asp:BoundField DataField="TotalPriceUSD" HeaderText="USD" />
                                <asp:BoundField DataField="TotalPriceEUR" HeaderText="EUR" />
                                <asp:BoundField DataField="PaymentType" HeaderText="&#214;deme" />
                                <asp:BoundField DataField="State" HeaderText="Durum" />
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblS" runat="server"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ýþlem">
                                 <ItemTemplate>
                                     <asp:Button ID="btnA" runat="server" Text="O" CommandName="Approve" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReservationID") %>' /><asp:Button ID="btnR"
                                         runat="server" Text="R"  CommandName="Reject" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReservationID") %>'/>
                                </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
              
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <asp:DropDownList ID="ddlPages" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        </td>
                </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>