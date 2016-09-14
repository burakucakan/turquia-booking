<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctQuickLinks.ascx.cs" Inherits="UserControls_Common_uctQuickLinks" %>
<%@ Register Src="~/UserControls/Common/uctGrayBoxBottom.ascx" TagName="uctGrayBoxBottom" TagPrefix="uc1" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>


<asp:Panel ID="pnlHeader" runat="server" meta:resourcekey="pnlHeaderResource1">

<table class="MenuBox">
<tr>
    <td class="MenuHeader CursorHand">
    <table id="Table10" class="Treb clNavy" style="width: 100%">
        <tr>
            <td align="Left">
                <asp:Literal runat="server" id="ltlQuickLink" Text="HIZLI ERÝÞÝM" meta:resourcekey="ltlQuickLinkResource1" /></td>
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

        <table id="Table11" cellspacing="3" runat="server">
        
            <tr runat="server">
                <td runat="server">
                    <asp:Image id="Image1" runat="server" ImageUrl="~/Images/Icons/Main.gif" /></td>
                <td runat="server">
                    <asp:HyperLink runat="server" CssClass="clBlack" id="hlMain" NavigateUrl="~/Default.aspx" Text="Ana Sayfa" /> </td>
            </tr>
        
            <tr runat="server">
                <td runat="server">
                    <asp:Image id="Image2" runat="server" ImageUrl="~/Images/Icons/Help.gif" /></td>
                <td runat="server">
                    <asp:HyperLink runat="server" CssClass="clBlack" id="HyperLink3" NavigateUrl="~/Help.aspx" Text="Yardým" /> </td>
            </tr>
        
            <tr runat="server">
                <td runat="server">
                    <asp:Image id="Image3" runat="server" ImageUrl="~/Images/Icons/Support.gif" /></td>
                <td runat="server">
                    <asp:HyperLink runat="server" CssClass="clBlack" id="HyperLink5" NavigateUrl="~/ContactForm.aspx" Text="Destek" /> </td>
            </tr>

        
            <tr runat="server">
                <td runat="server">
                    <asp:Image id="Image4" runat="server" ImageUrl="~/Images/Icons/Favorites.gif" /></td>
                <td runat="server">
                    <asp:HyperLink runat="server" CssClass="clBlack" id="hlAddFavorites" NavigateUrl="~/Default.aspx" Text="Sýk Kullanýlanlara Ekle" /> </td>
            </tr>
        
            <tr runat="server">
                <td runat="server">
                    <asp:Image id="Image5" runat="server" ImageUrl="~/Images/Icons/HomePage.gif" /></td>
                <td runat="server">
                    <asp:HyperLink runat="server" CssClass="clBlack" id="hlStHomePage" NavigateUrl="~/Default.aspx" Text="Giriþ Sayfasý Yap" /> </td>
            </tr>

            <tr runat="server">
                <td runat="server">
                    <asp:Image id="Image7" runat="server" ImageUrl="~/Images/Icons/Contact.gif" /></td>
                <td runat="server">
                    <asp:HyperLink runat="server" CssClass="clBlack" id="HyperLink9" NavigateUrl="~/Contact.aspx" Text="Ýletiþim" /> </td>
            </tr>
        
            <tr runat="server">
                <td runat="server">
                    <asp:Image id="Image8" runat="server" ImageUrl="~/Images/Icons/Logout.gif" /></td>
                <td runat="server">
                    <asp:LinkButton runat="server" CausesValidation="False" CssClass="clBlack" id="lbLogOut" Text="G&#252;venli &#199;ýkýþ" OnClick="lbLogOut_Click" /></td>
            </tr>
            
        </table>

        <br />
        
        </td>
    </tr>
    </table>
    
</asp:Panel>

<uc1:uctGrayBoxBottom ID="UctGrayBoxBottom1" runat="server" />

<ajaxToolkit:CollapsiblePanelExtender ID="ajCpQuickLinks" runat="server"
    TargetControlID="pnlContent"
    ExpandControlID="pnlHeader"
    CollapseControlID="pnlHeader"
    ImageControlID="imgArrowClue"    
    ExpandedImage="~/Images/Icons/ArrowUp.gif"
    CollapsedImage="~/Images/Icons/ArrowDown.gif"
    SuppressPostBack="True" Enabled="True" />