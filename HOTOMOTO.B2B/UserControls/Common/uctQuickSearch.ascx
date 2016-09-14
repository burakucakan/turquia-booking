<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctQuickSearch.ascx.cs" Inherits="UserControls_Common_uctQuickSearch" %>
<%@ Register Src="../ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc4" %>
<%@ Register Src="uctTxtDate.ascx" TagName="uctTxtDate" TagPrefix="uc3" %>
<%@ Register Src="DDL/uctDDLCountries.ascx" TagName="uctDDLCountries" TagPrefix="uc1" %>
<%@ Register Src="DDL/uctDDLCities.ascx" TagName="uctDDLCities" TagPrefix="uc2" %>
<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<asp:Panel ID="pnlBack" runat="server" CssClass="MainTopBackRpt" meta:resourcekey="pnlBackResource1">

<asp:Panel ID="pnlHeader" runat="server" meta:resourcekey="pnlHeaderResource1">

<table width="100%"> 
<tr>
    <td class="MainTop">
    
        <table width="580" id="Table3">

                <tr>
                    <td class="MainTopHeader">
                        <asp:Literal runat="server" id="ltlMainTopText" meta:resourcekey="ltlMainTopTextResource1" Text="
                            &lt;b&gt;Turquia.com&lt;/b&gt;&lt;br /&gt;
                            Junio en el Kurucesme Arena de Estambul. La estrella colombiano 
                        "></asp:Literal>
                    </td>
                </tr>
                
                <tr>
                    <td class="VSpace"></td>
                </tr>
                
                <tr class="CursorHand">
                    <td class="Treb clBlue">
                        <asp:Image id="imgArrowClue" runat="server" ImageUrl="~/Images/Icons/ArrowUp.gif" meta:resourcekey="imgArrowClueResource1" />&nbsp;
                        <b><asp:Literal runat="server" id="ltlQuickSearchTitle" Text="HIZLI HOTEL ARAMA" meta:resourcekey="ltlQuickSearchTitleResource1" /></b>
                    </td>
                </tr>                            
                
            </table>
            
    </td>
</tr>
</table> 

</asp:Panel>
    
<asp:Panel ID="pnlContent" runat="server" meta:resourcekey="pnlContentResource1">

<table width="100%">
<tr>
    <td class="MainSearch">

<asp:UpdatePanel ID="upQuickSearch" runat="server">
<ContentTemplate>

        <table class="Treb clBlue" width="580">
            <tr>
		        <td width="80">
		            <asp:Literal runat="server" ID="ltlArrivalDate" Text="Gidiþ Tarihi" meta:resourcekey="ltlArrivalDateResource1" /></td>
		        <td align="left" width="160">
                    <uc3:uctTxtDate ID="UctArrivalDate" runat="server" /></td>
		        <td width="34"></td>
		        <td width="80" align="left">
		            <asp:Literal runat="server" ID="ltlDepartureDate" Text="Geliþ Tarihi" meta:resourcekey="ltlDepartureDateResource1" /></td>
		        <td width="160">
                    <uc3:uctTxtDate ID="UctDepartureDate" runat="server" /></td>
	        </tr>
	        <tr>
		        <td colspan="5" height="3"></td>
	        </tr>	                
	        <tr>
		        <td width="80">
		            <asp:Literal runat="server" ID="ltlChooseCity" Text="Þehir Se&#231;imi" meta:resourcekey="ltlChooseCityResource1" /></td>
		        <td align="left" width="160">
                    <uc2:uctDDLCities ID="UctDDLCities1" runat="server" /></td>
		        <td></td>                     
		        <td width="80">
		            <asp:Literal runat="server" ID="ltlGuestCount" Text="Oda Sayýsý" meta:resourcekey="ltlGuestCountResource1" /></td>
		        <td align="left" width="160">
		            <asp:DropDownList ID="ddlRoomQuantity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoomQuantity_SelectedIndexChanged" meta:resourcekey="ddlRoomQuantityResource1">
                    </asp:DropDownList>

                </td>
	        </tr>

            <tr>
                <td colspan="5">
                
                    <asp:Panel runat="server" ID="pnlRoom1" Visible="False" meta:resourcekey="pnlRoom1Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount1" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount1Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount1" runat="server" meta:resourcekey="ddlAdultCount1Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount1" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount1Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount1" runat="server" meta:resourcekey="ddlChildCount1Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge1" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge1Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge1" runat="server" meta:resourcekey="ddlFirstChildAge1Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge1" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge1Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge1" runat="server" meta:resourcekey="ddlSecondChildAge1Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                    
                    <asp:Panel runat="server" ID="pnlRoom2" Visible="False" meta:resourcekey="pnlRoom2Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount2" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount2Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount2" runat="server" meta:resourcekey="ddlAdultCount2Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount2" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount2Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount2" runat="server" meta:resourcekey="ddlChildCount2Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge2" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge2Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge2" runat="server" meta:resourcekey="ddlFirstChildAge2Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge2" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge2Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge2" runat="server" meta:resourcekey="ddlSecondChildAge2Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                    
                    <asp:Panel runat="server" ID="pnlRoom3" Visible="False" meta:resourcekey="pnlRoom3Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount3" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount3Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount3" runat="server" meta:resourcekey="ddlAdultCount3Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount3" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount3Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount3" runat="server" meta:resourcekey="ddlChildCount3Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge3" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge3Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge3" runat="server" meta:resourcekey="ddlFirstChildAge3Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge3" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge3Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge3" runat="server" meta:resourcekey="ddlSecondChildAge3Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                    
                    <asp:Panel runat="server" ID="pnlRoom4" Visible="False" meta:resourcekey="pnlRoom4Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount4" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount4Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount4" runat="server" meta:resourcekey="ddlAdultCount4Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount4" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount4Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount4" runat="server" meta:resourcekey="ddlChildCount4Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge4" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge4Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge4" runat="server" meta:resourcekey="ddlFirstChildAge4Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge4" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge4Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge4" runat="server" meta:resourcekey="ddlSecondChildAge4Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                    
                    <asp:Panel runat="server" ID="pnlRoom5" Visible="False" meta:resourcekey="pnlRoom5Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount5" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount5Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount5" runat="server" meta:resourcekey="ddlAdultCount5Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount5" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount5Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount5" runat="server" meta:resourcekey="ddlChildCount5Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge5" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge5Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge5" runat="server" meta:resourcekey="ddlFirstChildAge5Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge5" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge5Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge5" runat="server" meta:resourcekey="ddlSecondChildAge5Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                    
                    <asp:Panel runat="server" ID="pnlRoom6" Visible="False" meta:resourcekey="pnlRoom6Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount6" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount6Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount6" runat="server" meta:resourcekey="ddlAdultCount6Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount6" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount6Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount6" runat="server" meta:resourcekey="ddlChildCount6Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge6" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge6Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge6" runat="server" meta:resourcekey="ddlFirstChildAge6Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge6" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge6Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge6" runat="server" meta:resourcekey="ddlSecondChildAge6Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                    
                    <asp:Panel runat="server" ID="pnlRoom7" Visible="False" meta:resourcekey="pnlRoom7Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount7" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount7Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount7" runat="server" meta:resourcekey="ddlAdultCount7Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount7" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount7Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount7" runat="server" meta:resourcekey="ddlChildCount7Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge7" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge7Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge7" runat="server" meta:resourcekey="ddlFirstChildAge7Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge7" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge7Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge7" runat="server" meta:resourcekey="ddlSecondChildAge7Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                    
                    <asp:Panel runat="server" ID="pnlRoom8" Visible="False" meta:resourcekey="pnlRoom8Resource1">
                        <hr color="Lavender" size="1" noshade="noshade" />
                        
                        <table width="100%" class="Treb clBlue">
                            <tr>
                            
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleAdultCount8" Text="Adult Count:" meta:resourcekey="ltlTitleAdultCount8Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAdultCount8" runat="server" meta:resourcekey="ddlAdultCount8Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleChildCount8" Text="Child  Count:" meta:resourcekey="ltlTitleChildCount8Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlChildCount8" runat="server" meta:resourcekey="ddlChildCount8Resource1"></asp:DropDownList></td>
                                    
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleFirstChildAge8" Text="First Child Age:" meta:resourcekey="ltlTitleFirstChildAge8Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFirstChildAge8" runat="server" meta:resourcekey="ddlFirstChildAge8Resource1"></asp:DropDownList></td>
                                
                                <td width="3%"></td>
                                
                                <td>
                                    <asp:Literal runat="server" ID="ltlTitleSecondChildAge8" Text="Second Child Age:" meta:resourcekey="ltlTitleSecondChildAge8Resource1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSecondChildAge8" runat="server" meta:resourcekey="ddlSecondChildAge8Resource1"></asp:DropDownList></td>
                                    
                                    
                            </tr>
                        </table>
                        
                        <hr color="Lavender" size="1" noshade="noshade" />                        
                    </asp:Panel>
                                                                 
                </td>
            </tr>
            
	        <tr>
		        <td colspan="5" height="3">&nbsp;</td>
	        </tr>

	        <tr>
		        <td colspan="5">
			        <asp:Button runat="server" CssClass="Button" id="btnOtelSearch" Text="ARAMAYI BAÞLAT" OnClick="btnOtelSearch_Click" CausesValidation="False" meta:resourcekey="btnOtelSearchResource1" />
			        &nbsp;&nbsp;
			        » &nbsp;<asp:HyperLink runat="server" id="hlDetailSearch" CssClass="clBlue" NavigateUrl="~/Hotel.aspx" Text="Detaylý Arama" meta:resourcekey="hlDetailSearchResource1" />
		        </td>
	        </tr>
	        <tr>
		        <td colspan="5" height="3">&nbsp;</td>
	        </tr>	        
        </table>

        <uc4:ModalPopup ID="ModalPopup1" runat="server" Visible="False" />

</ContentTemplate>
</asp:UpdatePanel>
              
    </td>
</tr>
</table>

</asp:Panel>

</asp:Panel>

<ajaxToolkit:CollapsiblePanelExtender ID="ajCpQuickSearch" runat="server"
    TargetControlID="pnlContent"
    ExpandControlID="pnlHeader"
    CollapseControlID="pnlHeader"
    ImageControlID="imgArrowClue"    
    ExpandedImage="~/Images/Icons/ArrowUp.gif"
    CollapsedImage="~/Images/Icons/ArrowDown.gif"
    SuppressPostBack="True" Enabled="True" />