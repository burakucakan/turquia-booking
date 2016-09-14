<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModalPopup.ascx.cs" Inherits="UserControls_ModalPopup_ModalPopup" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<div id="dvDeActive"></div>

<asp:Panel ID="pnlModal" runat="server">
    <table id="TableBack">
	<tr>
		<td valign="top">

			<table width="100%">
			<tr>
				<td id="Header">
				    <asp:Panel ID="pnlHeader" runat="server">
					    <table align="center" width="92%">
					    <tr>
						    <td align="left">
						        <asp:Label runat="server" id="lblTitle" CssClass="HeaderText" /></td>
						    <td align="right">
							    <asp:image runat="server" id="imgClose" ImageUrl="~/UserControls/ModalPopup/Images/Close.gif"></asp:image></td>
					    </tr>
					    </table>
					</asp:Panel>
				</td>
			</tr>
			<tr>
				<td>
				    <br />	
					<table align="center" width="90%">
					<tr>
						<td align="center" width="60">
							<asp:image runat="server" id="imgIcon"></asp:image></td>
						<td align="left">
						    <div id="dvMessage" runat="server"></div>
						    <asp:Label runat="server" id="lblText" CssClass="MessageText"></asp:Label>
                        </td>
					</tr>
					<tr>
						<td colspan="2" align="right">
							<asp:button CausesValidation="False" runat="server" CssClass="btnOK" id="btnOK" text="OK" ></asp:button></td>
					</tr>
					</table>
					<br />
				</td>
			</tr>
			</table>
		
		</td>
	</tr>
</table>
</asp:Panel>

<asp:Button CausesValidation="False" ID="btnHideForModal" runat="server" style="display: none;" />

<div id="dvScript" runat="server"></div>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server"
    PopupControlID="pnlModal"
    OkControlID="btnOK"
    OnOkScript="ModalOK()"
    OnCancelScript="ModalCancel()"
    TargetControlID="btnHideForModal"
    PopupDragHandleControlID="pnlHeader" DynamicServicePath="" Enabled="True" />