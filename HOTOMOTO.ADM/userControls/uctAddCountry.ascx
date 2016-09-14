<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctAddCountry.ascx.cs" Inherits="userControls_uctAddCountry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="uctMessage.ascx" TagName="uctMessage" TagPrefix="uc1" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<uc1:uctMessage ID="UctMessage1" runat="server" Visible="false" />
		<div class="b710">
			<div class="title">
				ÜLKE EKLE</div>
			<div class="main">
				<div class="info">Ülke ekle</div>
				<div style="margin:10px;">
					<cc1:TabContainer ID="TabContainer1" runat="server">
					</cc1:TabContainer>
				</div>
				<div class="option">
					<input id="chkContinue" name="chkContinue" type="checkbox" value="1" />
					<label for="chkContinue">Ülke eklemeye devam et</label>
				</div>
				<div class="action">
					<asp:ImageButton ID="btnPublish" runat="server" ImageUrl="~/img/btnYayinla.gif" ToolTip="Ülkeyi kaydet" AlternateText="Yayýnla" OnClick="btnPublish_Click" />
				</div>
				<div class="c">
				</div>
			</div>
			<div class="bottom">
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
<cc1:Accordion ID="Accordion1" runat="server">
</cc1:Accordion>
