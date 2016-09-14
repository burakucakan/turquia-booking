<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctCustomer.ascx.cs" Inherits="userControls_Customers_uctCustomer" %>
<%@ Register Src="uctCustomerAccessOptions.ascx" TagName="uctCustomerAccessOptions"
    TagPrefix="uc5" %>
<%@ Register Src="uctCustomerAddresses.ascx" TagName="uctCustomerAddresses" TagPrefix="uc4" %>
<%@ Register Src="../uctAddress.ascx" TagName="uctAddress" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctMLTabs.ascx" TagName="uctMLTabs" TagPrefix="uc1" %>
<%@ Register Src="../uctMessage.ascx" TagName="uctMessage" TagPrefix="uc2" %>
<uc2:uctMessage ID="UctMessage1" runat="server" />
<div class="b710">
    <div class="title">
        MÜÞTERÝ YÖNETÝMÝ</div>
    <div class="main">
        <div class="info">
            Müþteri Genel Bilgileri</div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblCC" runat="server" Text="Müþteri Kodu" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtCC" runat="server" CssClass="s25"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblFN" runat="server" Text="Firma Adý" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtFN" runat="server" CssClass="s25" Width="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblCN" runat="server" Text="Müþteri Adý" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtCN" runat="server" CssClass="s25" Width="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblCT" runat="server" Text="Müþteri Tipi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:DropDownList ID="ddlCT" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblCurT" runat="server" Text="Döviz Tipi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:DropDownList ID="ddlCurT" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblEmA" runat="server" Text="E-Posta Adresi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtEmA" runat="server" CssClass="s25"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblWS" runat="server" Text="Ýnternet Sitesi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtWS" runat="server" CssClass="s25"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblIsActive" runat="server" Text="Aktif mi?" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:CheckBox ID="cbIsActive" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblCL" runat="server" Text="Kredi Limiti" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="txtCL" runat="server" CssClass="s25"></asp:TextBox>
                        <asp:Label runat="server" ID="lblCCID" Visible="false"></asp:Label>
                        </td>
                </tr>
            </table>
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
        <asp:Panel ID="pnlAddress" runat="server" Width="100%">
        <div class="info">
            Adres Bilgileri
        </div>
        <div style="margin: 10px;">
            <uc4:uctCustomerAddresses ID="UctCustomerAddresses1" runat="server" />
        </div>
        <div class="info">
            Eriþim Bilgileri
        </div>
        <div style="margin: 10px;">
           <uc5:uctCustomerAccessOptions ID="UctCustomerAccessOptions1" runat="server" />
        </div>
        </asp:Panel>
    </div>
</div>
