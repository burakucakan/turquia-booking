<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctCustomerAccessOptions.ascx.cs" Inherits="userControls_Customers_uctCustomerAccessOptions" %>
<asp:UpdatePanel ID="upAccessTypes" runat="server">
<ContentTemplate>
		<table width="100%">
		    <tr>
				<td>
					<asp:Label ID="lblAMT" runat="server" CssClass="label" Text="Ýletiþim Ana Tipi"></asp:Label></td>
				<td>
					<asp:DropDownList ID="ddlAMT" runat="server" AutoPostBack="True" CssClass="s50" OnSelectedIndexChanged="ddlAMT_SelectedIndexChanged">
					</asp:DropDownList></td>
				<td>
					&nbsp;</td>
			</tr>
			 <tr>
				<td>
					<asp:Label ID="lblAT" runat="server" CssClass="label" Text="Ýletiþim Tipi"></asp:Label></td>
				<td>
					<asp:DropDownList ID="ddlAT" runat="server" AutoPostBack="True" CssClass="s50">
					</asp:DropDownList></td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblV" runat="server" CssClass="label" Text="Numara"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtV" runat="server" CssClass="textBox s50"></asp:TextBox></td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td valign="top">
					<asp:Label ID="lblIsDef" runat="server" CssClass="label" Text="Varsayýlan"></asp:Label></td>
				<td class="txtarea">
                    <asp:CheckBox ID="chkIsDef" runat="server" /></td>
				<td>
					</td>
			</tr>
			<tr>
			<td colspan="3" align="right">
                <asp:Button ID="btnAdd" runat="server" Text="Ekle" OnClick="btnAdd_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Kaydet" OnClick="btnSave_Click" />
			</td>
			</tr>
		</table>
		
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            CellPadding="2" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Numara">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "RowID") %>'></asp:Label>
                        <asp:Label ID="txtAV" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AccessValue") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tip">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblT" Text='<%# DataBinder.Eval(Container.DataItem, "Type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Varsayýlan">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblisD" Text='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "isDefault")) == true ? "Evet" : "Hayýr"  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ýþlemler">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" CommandName='updateAO' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "AccessOptionID") %>' />
                        <asp:Button ID="btnDelete" runat="server" Text="Sil" CommandName='deleteAO' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RowID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="DimGray" ForeColor="White" />
            <AlternatingRowStyle BackColor="LightGray" />
        </asp:GridView>
	</ContentTemplate>
	</asp:UpdatePanel> 