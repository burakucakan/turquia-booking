<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctPort.ascx.cs" Inherits="userControls_Ports_uctPort" %>
<%@ Register Src="../uctAddress.ascx" TagName="uctAddress" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctMLTabs.ascx" TagName="uctMLTabs" TagPrefix="uc1" %>
<%@ Register Src="../uctMessage.ascx" TagName="uctMessage" TagPrefix="uc2" %>
<uc2:uctMessage ID="UctMessage1" runat="server" />
<div class="b710">
    <div class="title">
        LÝMAN VE HAVAALANI EKLE</div>
    <div class="main">
        <div class="info">
            Liman Genel Bilgileri</div>
        <div style="margin: 10px;">
            <uc1:uctMLTabs ID="UctMLTabs1" runat="server" />
        </div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblIsActive" runat="server" Text="Aktif mi?" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:CheckBox ID="cbIsActive" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblMultip" runat="server" CssClass="label" Text="Transfer Katsayýsý"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtMultiplier" runat="server" Width="54px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <div class="info">
            Adres Bilgileri
        </div>
        <div style="margin: 10px;">
            <uc3:uctAddress ID="UctAddress1" runat="server" isPortAddress="true" />
        </div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                <td colspan="2" align="right">
                <asp:ImageButton ID="btnPublish" runat="server" ImageUrl="~/img/btnYayinla.gif" ToolTip="Kaydet"
                            AlternateText="Yayýnla" OnClick="btnPublish_Click"/>
                </td>
                </tr>
                
            </table>
        </div>
    </div>
</div>
