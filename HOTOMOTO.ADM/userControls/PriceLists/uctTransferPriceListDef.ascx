<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTransferPriceListDef.ascx.cs" Inherits="userControls_PriceLists_uctTransferPriceListDef" %>
<asp:UpdatePanel runat="server" ID="upPL">
<ContentTemplate>
<div class="b710">
    <div class="title">
        TRANSFER FÝYAT LÝSTELERÝ</div>
    <div class="main">
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td colspan="2">
                    
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="2" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Fiyat Listesi Adý">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblRPLID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TransferPriceListID") %>'></asp:Label>
                                        <asp:TextBox ID="txtPLN" runat="server" Width="200px"  Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'></asp:TextBox>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" CommandName='updateName' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TransferPriceListID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="55%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ýþlemler">
                                    <ItemTemplate>
                                        <asp:Button ID="btnCustomers" runat="server" Text="Müþteriler" CommandName='listCustomers' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TransferPriceListID") %>' />
                                        <asp:Button ID="btnAddList" runat="server" Text="Listeyi Ekle" CommandName='addList' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TransferPriceListID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="DimGray" ForeColor="White" />
                            <AlternatingRowStyle BackColor="LightGray" />
                        </asp:GridView>
                    
                    
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlCustomers">
    <div class="title">
        <asp:Label runat="server" ID="lblPriceListName"></asp:Label> FÝYAT LÝSTESÝ MÜÞTERÝLERÝ</div>
    <div class="main">
        <div style="margin: 10px;">
            <table width="100%">
                <tr>
                    <td width="45%">
                        <asp:TextBox ID="txtLCustName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnLCustSearch" runat="server" Text="Ara" OnClick="btnLCustSearch_Click" />
                    </td>
                    <td width="10%">
                        
                    </td>
                    <td width="45%">
                        <asp:TextBox ID="txtRCustName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnRCustSearch" runat="server" Text="Ara" OnClick="btnRCustSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ListBox ID="lbLCusts" runat="server" Rows="8" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                    </td>
                    <td align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Ekle" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnRem" runat="server" Text="Çýkar" OnClick="btnRem_Click" />
                    </td>
                    <td>
                        <asp:ListBox ID="lbRCusts" runat="server" Rows="8" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </asp:Panel>
</div>
</ContentTemplate>
</asp:UpdatePanel>
