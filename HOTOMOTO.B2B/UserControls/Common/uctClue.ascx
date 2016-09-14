<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctClue.ascx.cs" Inherits="UserControls_Common_uctClue" %>
<%@ Register Src="~/UserControls/Common/uctGrayBoxBottom.ascx" TagName="uctGrayBoxBottom" TagPrefix="uc1" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<asp:Panel ID="pnlHeader" runat="server" meta:resourcekey="pnlHeaderResource1">

<table class="MenuBox">
<tr>
    <td class="MenuHeader CursorHand">
    <table id="Table14" class="Treb clNavy"  style="width: 100%">
        <tr>
            <td align="Left">
                <asp:Literal runat="server" id="ltlClueHeader" Text="ÝPUCU" meta:resourcekey="ltlClueHeaderResource1" /></td>
            <td align="Right">
                <asp:Image runat="server" id="imgArrowClue" ImageUrl="~/Images/Icons/ArrowUp.gif" meta:resourcekey="imgArrowClueResource1" /></td>
        </tr>
    </table>
    </td>
</tr>
</table>
    
</asp:Panel>

<asp:Panel ID="pnlContent" runat="server" meta:resourcekey="pnlContentResource1">

    <table class="MenuBox">
    <tr>
        <td class="Padding">
        
        <br />
            <asp:Panel id="Panel1" runat="server" CssClass="clRed" meta:resourcekey="Panel1Resource1">
                <asp:Literal runat="server" id="ltlClueTitle" meta:resourcekey="ltlClueTitleResource1" /> 
            </asp:Panel>
            <br />
            
            <asp:Literal runat="server" id="ltlDescription" meta:resourcekey="ltlDescriptionResource1" />  ...

        <br /><br />
        
            <asp:Panel id="pnlDetail" runat="server" meta:resourcekey="pnlDetailResource1">
                » &nbsp;<asp:HyperLink runat="server" id="hlDetail" CssClass="clBlue" Text="Detay" meta:resourcekey="hlDetailResource1" />
            </asp:Panel>
        <br /><br />
        
        </td>
    </tr>
    </table>
    
</asp:Panel>

<uc1:uctGrayBoxBottom ID="UctGrayBoxBottom1" runat="server" />

<ajaxToolkit:CollapsiblePanelExtender ID="ajCpClues" runat="server"
    TargetControlID="pnlContent"
    ExpandControlID="pnlHeader"
    CollapseControlID="pnlHeader"
    ImageControlID="imgArrowClue"    
    ExpandedImage="~/Images/Icons/ArrowUp.gif"
    CollapsedImage="~/Images/Icons/ArrowDown.gif"
    SuppressPostBack="True" Enabled="True" />