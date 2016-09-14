<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctRoomAvailability.ascx.cs" Inherits="userControls_Room_uctRoomAvailability" %>
<%@ Register Src="../Common/uctCalendar.ascx" TagName="uctCalendar" TagPrefix="uc6" %>
<%@ Register Src="../uctSubMenu.ascx" TagName="uctSubMenu" TagPrefix="uc5" %>
<%@ Register Src="../Common/uctMLTabs.ascx" TagName="uctMLTabs" TagPrefix="uc4" %>
<%@ Register Src="../uctRoomProperties.ascx" TagName="uctRoomProperties" TagPrefix="uc2" %>
<%@ Register Src="../uctRoomImages.ascx" TagName="uctRoomImages" TagPrefix="uc3" %>
<%@ Register Src="../uctMessage.ascx" TagName="uctMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div class="b710">
    <div class="title">
        ODA UYGUNLUKLARI / FÝYATLARI</div>
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
                        <asp:Label ID="lblPL" runat="server">Fiyat Listesi</asp:Label>
                        </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlPL" runat="server">
                            </asp:DropDownList>
                        </td>
                    
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblSD" runat="server">Baþlangýç Tarihi</asp:Label>
                        </td>
                    <td >
                        <uc6:uctCalendar ID="calStartDate" runat="server" />
                        </td>
                     <td >
                        <asp:Label ID="lblED" runat="server">Bitiþ Tarihi</asp:Label>
                        </td>
                    <td >
                        <uc6:uctCalendar ID="calEndDate" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td ><asp:Label ID="lblHC" runat="server">Otel Zinciri</asp:Label>
                        </td>
                    <td ><asp:DropDownList ID="ddlHC" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHC_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td ><asp:Label ID="lblH" runat="server">Otel</asp:Label>
                        </td>
                    <td ><asp:DropDownList ID="ddlH" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlH_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                </tr>
               <tr>
                    <td ><asp:Label ID="lblR" runat="server">Odalar</asp:Label>
                        </td>
                    <td ><asp:DropDownList ID="ddlR" runat="server">
                            </asp:DropDownList>
                            </td>
                        <td ><asp:Label ID="lblG" runat="server">&nbsp;&nbsp;&nbsp;Grup Tipi</asp:Label>
                        </td>
                    <td >
                        <asp:DropDownList ID="ddlG" runat="server">
                        <asp:ListItem Value="day">G&#252;nl&#252;k</asp:ListItem>
                        <asp:ListItem Value="week">Haftalýk</asp:ListItem>
                        <asp:ListItem Value="month">Aylýk</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="btnPrepare" runat="server" Text="Hazýrla" OnClick="btnPrepare_Click1" /></td>
                </tr>
                 <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                 <tr>
                    <td colspan="4" align="right">
                         <asp:Button ID="btnChkAll" runat="server" Text="Tümünü Seç" OnClick="btnChkAll_Click" /><asp:Button ID="btnUnChkAll" runat="server" Text="Seçilileri Kaldýr" OnClick="btnUnChkAll_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2">
                            <Columns>
                                <asp:TemplateField HeaderText="Baþlangý&#231; Tarihi">
                                    <ItemTemplate>
                                        <asp:label ID="lblSD" runat="server"></asp:label>.
                                        <asp:label ID="lblSM" runat="server"></asp:label>.
                                        <asp:label ID="lblSY" runat="server"></asp:label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bitiþ Tarihi">
                                    <ItemTemplate>
                                        <asp:label ID="lblED" runat="server"></asp:label>.
                                        <asp:label ID="lblEM" runat="server"></asp:label>.
                                        <asp:label ID="lblEY" runat="server"></asp:label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adet">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQ" runat="server" Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fiyatlar">
                                    <ItemTemplate>
                                        <asp:GridView ID="gvPrices" runat="server" AutoGenerateColumns="False" >
                                         <Columns>
                                        <asp:TemplateField HeaderText="M.Sayýsý">
                                            <ItemTemplate>
                                                <asp:label ID="lblCap" runat="server"></asp:label>
                                                <asp:label ID="lblRPLP" visible="false"  runat="server"></asp:label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="USD">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUSD" runat="server" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EUR">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEUR" runat="server" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                         </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Se&#231;">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkD" runat="server" Checked="true" />        
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="DimGray" ForeColor="White" />
                            <AlternatingRowStyle BackColor="LightGray" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="btnSaveAvaOnly" runat="server" Text="Sadece Uygunluklarý Kaydet" OnClick="btnSaveAvaOnly_Click" />
                        <asp:Button ID="btnSaveAva" runat="server" OnClick="btnSaveAva_Click" Text="Uygunluklarý ve Fiyatlarý Kaydet" /></td>
                </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>