<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctPaging.ascx.cs" Inherits="UserControls_Common_uctPaging" %>

<script type="text/javascript">
	function ChangePage(PageValue, ValueType) {
		var chr = "&";
	    var path = String(location.href);        
	    if (path.indexOf(ValueType + "=") != "-1") { path = path.substring(0, eval(path.indexOf(ValueType + "=") - 1)) ; }
        if (path.indexOf("?") == "-1") { chr = "?"; } 
	    path = path + chr + ValueType + "=" + PageValue;
		location.href = path;
	}
</script>

<table class="SearchFooter">
    <tr>
        <td class="RecordCountCell">
            <asp:Literal runat="server" ID="ltlRecordCountTitle" Text="Toplam Kayýt" meta:resourcekey="ltlRecordCountTitleResource1" />:
            <asp:Label CssClass="RecordCountText" runat="server" ID="lblRecordCount" meta:resourcekey="lblRecordCountResource1" />
        </td>
        <td class="PageSizeCell">
            <asp:Literal runat="server" ID="ltlPageSize" Text="Gösterim Adedi" meta:resourcekey="ltlPageSizeResource1" />: 
            <asp:DropDownList runat="server" ID="ddlPageSize" CssClass="DropDownList" meta:resourcekey="ddlPageSizeResource1" />
        </td>
        <td class="PageNumberCell">
            <asp:HyperLink runat="server" CssClass="NextPrevLink" ID="hlPrevious" Enabled="False" meta:resourcekey="hlPreviousResource1">«« &nbsp;Önceki</asp:HyperLink> &nbsp;&nbsp;
            <asp:DropDownList runat="server" CssClass="DropDownList" ID="ddlPageNumber" meta:resourcekey="ddlPageNumberResource1" /> &nbsp;&nbsp;
            <asp:HyperLink runat="server" CssClass="NextPrevLink" ID="hlNext" Enabled="False" meta:resourcekey="hlNextResource1">Sonraki&nbsp; »»</asp:HyperLink>
        </td>
    </tr>
</table>