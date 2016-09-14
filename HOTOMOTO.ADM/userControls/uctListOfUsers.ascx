<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctListOfUsers.ascx.cs" Inherits="userControls_uctLastAddedMain" %>
<%@ Register Src="uctSubMenu.ascx" TagName="uctSubMenu" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upUsers" runat="server">
	<ContentTemplate>
<uc1:uctSubMenu id="UctSubMenu1" runat="server"></uc1:uctSubMenu>
<div class="b710">
    <div class="title">
        KULLANICILAR</div>
    <div class="main">
        <div id="itemlist">
        
			<asp:Repeater ID="rptUsers" runat="server">
				<HeaderTemplate>
					<table>
						<tr>
							<th class="c1">
								<input type="checkbox" value="all" /></th>
							<th width="150">
								KULLANICI ADI</th>
							<th width="250">
								ÝSMÝ</th>
							<th width="150">
								ROL</th>
							<th width="130">
								ÝÞLEMLER</th>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr class="item">
						<td class="c1">
							<input type="checkbox" /></td>
						<td width="150">
							<%# CARETTA.COM.Encryption.Decrypt(DataBinder.Eval(Container.DataItem, "UserName").ToString()) %>
						</td>
						<td width="250">
							<%# DataBinder.Eval(Container.DataItem, "Fullname") %>
						</td>
						<td width="150">
							<%# DataBinder.Eval(Container.DataItem, "RoleName") %>
						</td>
						<td width="130">
							<div>
								<a href="User.aspx?userid=<%# DataBinder.Eval(Container.DataItem, "UserID") %>">düzenle</a>, 
								<a href="#sil.php?tip=ulke&id=<%# DataBinder.Eval(Container.DataItem, "UserID") %>">kaldýr</a></div>
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
            <a href="#">Ýzinler</a>, <a href="#">Tüm kategoriler</a></div>
    </div>
    <div class="bottom">
    </div>
</div>
	</ContentTemplate>
</asp:UpdatePanel>
