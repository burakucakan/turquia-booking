<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctBulletinQuickAdd.ascx.cs" Inherits="userControls_uctBulletinQuickAdd" %>

<div class="b230" style="display: none;">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
	<div class="title">
		BÜLTEN YAYINLA</div>
	<div class="main">
		<div class="info">
			Üyelere bülten gönder</div>
		<div class="label">
			<label for="txtBulten">
				Mesajýný gir:</label></div>
		<div class="txtarea">
			<asp:TextBox ID="txtBulten" runat="server" TextMode="MultiLine"></asp:TextBox></div>
		<div class="option">
			<asp:CheckBox ID="chkSitedeYayinla" runat="server" Text="Sitede Yayýnla" ToolTip="Seçiliyken bülten hem yönetim panelinde hem de sitede yayýnlanýr" /></div>
		<div class="action">
			<asp:ImageButton ID="btnYayinla" runat="server" ImageUrl="~/img/btnYayinla.gif" OnClick="btnYayinla_Click"
				ToolTip="Yazýlan metni yayýnlar" /></div>
		<div class="c">
		</div>
	</div>
	<div class="info-panel">
		<div class="info-title">
			MEVCUT BÜLTENLER</div>
				<asp:Repeater ID="rptBulten" runat="server">
					<ItemTemplate>
						<div class="info-message">
							<%# DataBinder.Eval(Container.DataItem, "Text") %>
						</div>
						<div class="info-options">
							<div>
								<%# DataBinder.Eval(Container.DataItem, "CreateDate", "{0:d}") %>
							</div>
							<div>
								<a href="#duzenle.php?tip=bulten?id=<%# DataBinder.Eval(Container.DataItem, "MessageID") %>">
									düzenle</a></div>
							<div>
								<a href="#sil.php?tip=bulten?id=<%# DataBinder.Eval(Container.DataItem, "MessageID") %>">
									sil</a></div>
						</div>
						<div class="c">
						</div>
					</ItemTemplate>
				</asp:Repeater>
	</div>
	<div class="infobottom">
	</div>
			</ContentTemplate>
		</asp:UpdatePanel>
</div>