<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctCustomerAddresses.ascx.cs" Inherits="userControls_Customers_uctCustomerAddresses" %>
<asp:UpdatePanel ID="upAddress" runat="server">
	<ContentTemplate>
		<table width="100%">
		    <tr>
				<td>
					<asp:Label ID="lblAT" runat="server" CssClass="label" Text="Adres Tipi"></asp:Label></td>
				<td>
					<asp:DropDownList ID="ddlAT" runat="server" AutoPostBack="True" CssClass="s50">
					</asp:DropDownList></td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblCountry" runat="server" CssClass="label" Text="Ülke"></asp:Label></td>
				<td>
					<asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" CssClass="s50" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
					</asp:DropDownList></td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblCity" runat="server" CssClass="label" Text="Þehir"></asp:Label></td>
				<td>
					<asp:DropDownList ID="ddlCity" runat="server" CssClass="s50" DataTextField="Name"
						DataValueField="CityID">
					</asp:DropDownList></td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td valign="top">
					<asp:Label ID="lblTown" runat="server" CssClass="label" Text="Semt"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtHotelTown" runat="server" CssClass="textBox s50"></asp:TextBox></td>
				<td>
					<asp:RequiredFieldValidator ID="reqfvHotelTown" runat="server" ControlToValidate="txtHotelTown"
						ErrorMessage="*" ValidationGroup="vgHotelInsertion"></asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblPostalCode" runat="server" CssClass="label" Text="Posta Kodu"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtPostalCode" runat="server" CssClass="textBox p25"></asp:TextBox></td>
				<td>
					<asp:RequiredFieldValidator ID="reqfvPostalCode" runat="server" ControlToValidate="txtPostalCode"
						ErrorMessage="*" ValidationGroup="vgHotelInsertion"></asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td valign="top">
					<asp:Label ID="lblStreetAddress" runat="server" CssClass="label" Text="Adres"></asp:Label></td>
				<td class="txtarea">
					<asp:TextBox ID="txtStreetAddress" runat="server" CssClass="textBox p50" TextMode="MultiLine"></asp:TextBox></td>
				<td>
					<asp:RequiredFieldValidator ID="reqfvStreetAddress" runat="server" ControlToValidate="txtStreetAddress"
						ErrorMessage="*" ValidationGroup="vgHotelInsertion"></asp:RequiredFieldValidator></td>
			</tr>
			<tr>
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
                <asp:TemplateField HeaderText="Adres Tipi">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "RowID") %>'></asp:Label>
                        <asp:Label ID="txtPLN" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Þehir">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblC" Text='<%# DataBinder.Eval(Container.DataItem, "CityName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ýþlemler">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" CommandName='updateCust' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "AddressID") %>' />
                        <asp:Button ID="btnDelete" runat="server" Text="Sil" CommandName='deleteCust' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RowID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="DimGray" ForeColor="White" />
            <AlternatingRowStyle BackColor="LightGray" />
        </asp:GridView>
	</ContentTemplate>
</asp:UpdatePanel>
