<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctListOfCountries.ascx.cs" Inherits="userControls_uctLastAddedMain" %>
<%@ Register Src="uctSubMenu.ascx" TagName="uctSubMenu" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
<uc1:uctSubMenu id="UctSubMenu1" runat="server"></uc1:uctSubMenu>
<div class="b710">
    <div class="title">
        ÜLKELER</div>
    <div class="main">
        <div id="itemlist">
        
			<asp:Repeater ID="rptCountries" runat="server">
				<HeaderTemplate>
					<table>
						<tr>
							<th class="c1">
								<input type="checkbox" value="all" /></th>
							<th class="550">
								ÜLKE</th>
							<th width="130">
								ÝÞLEMLER</th>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr class="item">
						<td class="c1">
							<input type="checkbox" /></td>
						<td class="550">
							<%# DataBinder.Eval(Container.DataItem, "CountryName") %>
						</td>
						<td width="130">
							<div>
								<a href="#duzenle.php?tip=ulke&id=<%# DataBinder.Eval(Container.DataItem, "CountryID") %>">düzenle</a>, 
								<a href="#sil.php?tip=ulke&id=<%# DataBinder.Eval(Container.DataItem, "CountryID") %>">kaldýr</a></div>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>
			</asp:Repeater>
			<table>
				<tr>
					<td width="10">
					</td>
					<td>
						Sayfada
						<asp:DropDownList ID="ddlPageLimit" runat="server" AutoPostBack="True" CssClass="paging"
							Width="50px" OnSelectedIndexChanged="ddlPageLimit_SelectedIndexChanged">
							<asp:ListItem>10</asp:ListItem>
							<asp:ListItem>25</asp:ListItem>
							<asp:ListItem>50</asp:ListItem>
							<asp:ListItem>100</asp:ListItem>
						</asp:DropDownList>
						adet göster
					</td>
					<td style="text-align: right; padding-right: 10px;">
						<asp:LinkButton ID="lbtPrevious" runat="server" OnClick="lbtPrevious_Click">&lt; Önceki</asp:LinkButton>
						<asp:DropDownList ID="ddlPageNumber" runat="server" AutoPostBack="True" CssClass="paging"
							Width="42px" OnSelectedIndexChanged="ddlPageNumber_SelectedIndexChanged">
						</asp:DropDownList>
						<b>/ 
							<asp:Label ID="lblPageCount" runat="server" Text="Label"></asp:Label></b> <asp:LinkButton ID="lbtNext" runat="server" OnClick="lbtNext_Click">Sonraki &gt;</asp:LinkButton></td>
				</tr>
			</table>
			</div>
        <div class="group-actions">
            GRUP ÝÞLEMÝ: <a href="#">Yayýndan kaldýr</a></div>
        <div class="main-actions">
            <a href="#">Tüm haberler</a>, <a href="#">Tüm kategoriler</a></div>
    </div>
    <div class="bottom">
    </div>
</div>
	</ContentTemplate>
</asp:UpdatePanel>
