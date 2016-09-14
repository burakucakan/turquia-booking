<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTransferPrices.ascx.cs"
    Inherits="userControls_Transfer_uctTransferPrices" %>
    <asp:UpdatePanel runat="server" ID="upGrid">
                    <ContentTemplate>
<div class="b710">
    <div class="title">
        TRANSFER FÝYATLARI</div>
    <div class="main">
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td style="width: 150px" valign="top">
                        <asp:Label ID="lblTPL" runat="server" Text="Transfer Fiyat Listesi" CssClass="label"></asp:Label></td>
                    <td nowrap="nowrap">
                        <asp:DropDownList ID="ddlTPL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTPL_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="2" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Kapasite">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTPLPID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TransferPriceListPriceID") %>'></asp:Label>
                                        <asp:TextBox ID="txtC" runat="server" Width="40px"  Text='<%# DataBinder.Eval(Container.DataItem, "GuestCapacity") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Normal Fiyat">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblRU" runat="server" Text="USD"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRU" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem, "RegularPriceUSD") %>'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRE" runat="server" Text="EUR"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRE" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem, "RegularPriceEUR") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Özel Fiyat">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPU" runat="server" Text="USD"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPU" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem, "PrivatePriceUSD") %>'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPE" runat="server" Text="EUR"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPE" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem, "PrivatePriceEUR") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rehber Fiyatý">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblGU" runat="server" Text="USD"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGU" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem, "GuidancePriceUSD") %>'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblGE" runat="server" Text="EUR"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGE" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem, "GuidancePriceEUR") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Se&#231;">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkD" runat="server" Checked="true" />
                                        <asp:LinkButton ID="lbAdd" runat="server" CommandName="AddPrice">Ekle</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="DimGray" ForeColor="White" />
                            <AlternatingRowStyle BackColor="LightGray" />
                        </asp:GridView>
                    
                    
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td align="right">
                        
                        <asp:Button ID="btnDeleteSelected" runat="server" Text="Seçilileri Sil" OnClick="btnDeleteSelected_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Kaydet" OnClick="btnUpdate_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</div>
</ContentTemplate>
                    </asp:UpdatePanel>
