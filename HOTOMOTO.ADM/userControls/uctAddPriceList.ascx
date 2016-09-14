<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctAddPriceList.ascx.cs"
    Inherits="userControls_uctAddPriceList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div class="b710">
    <div class="title">
        FÝYAT LÝSTESÝ EKLE</div>
    <div class="main">
        <div class="info">
            Fiyat Listesi ekle</div>
        <div style="margin: 10px;">
            <cc1:TabContainer ID="tabLanguages" runat="server" Height="100px" Width="600px" ActiveTabIndex="0">
            </cc1:TabContainer>
        </div>
    </div>
    <div style="margin: 10px;">
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblReservationStartDate" runat="server" Text="Rezervasyon Baþlangýç T."
                        Width="168px" CssClass="label"></asp:Label></td>
                <td style="width: 100px" align="right">
                    <asp:TextBox ID="txtReservationStartDate" runat="server" CssClass="textBox"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="reqfvReservationStartDate" runat="server" ControlToValidate="txtReservationStartDate"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblReservationEndDate" runat="server" Text="Rezervasyons Bitiþ T."
                        Width="168px" CssClass="label"></asp:Label></td>
                <td style="width: 100px" align="right">
                    <asp:TextBox ID="txtReservationEndDate" runat="server" CssClass="textBox"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="reqfvReservationEndDate" runat="server" ControlToValidate="txtReservationEndDate"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblBookingStartDate" runat="server" Text="Ön Kayýt Baþlangýç T." Width="168px"
                        CssClass="label"></asp:Label></td>
                <td style="width: 100px" align="right">
                    <asp:TextBox ID="txtBookingStartDate" runat="server" CssClass="textBox"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="reqfvBookingStartDate" runat="server" ControlToValidate="txtBookingStartDate"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lblBookingEndDate" runat="server" Text="Ön Kayýt Bitiþ T." Width="168px"
                        CssClass="label"></asp:Label></td>
                <td style="width: 100px" align="right">
                    <asp:TextBox ID="txtBookingEndDate" runat="server" CssClass="textBox"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="reqfvBookingEndDate" runat="server" ControlToValidate="txtBookingEndDate"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    <div align="right">
        <asp:CheckBox ID="chkContinue" runat="server" Text="Fiyat Listesi Eklemeye Devam Et" Width="182px" />
        <asp:ImageButton ID="btnPublish" runat="server" ImageUrl="~/img/btnYayinla.gif" ToolTip="Kaydet"
            AlternateText="Yayýnla" OnClick="btnPublish_Click" />
    </div>
</div>
<cc1:CalendarExtender ID="calReservationStartDate" runat="server" TargetControlID="txtReservationStartDate">
</cc1:CalendarExtender>
<cc1:CalendarExtender ID="calReservationEndDate" runat="server" TargetControlID="txtReservationEndDate">
</cc1:CalendarExtender>
<cc1:CalendarExtender ID="calBookingnStartDate" runat="server" TargetControlID="txtBookingStartDate">
</cc1:CalendarExtender>
<cc1:CalendarExtender ID="calBookingEndDate" runat="server" TargetControlID="txtBookingEndDate">
</cc1:CalendarExtender>
