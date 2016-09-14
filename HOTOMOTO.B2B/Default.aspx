<%@ Page Language="C#" MasterPageFile="~/B2B.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/UserControls/Common/uctQuickSearch.ascx" TagName="uctQuickSearch" TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/Banner/uctBottomBanner.ascx" TagName="uctBottomBanner" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/Common/uctFavorites.ascx" TagName="uctFavorites" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Common/uctWeather.ascx" TagName="uctWeather" TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/Common/uctTransfer.ascx" TagName="uctTransfer" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/Common/uctContentSearch.ascx" TagName="uctContentSearch" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Common/uctRecommends.ascx" TagName="uctRecommends" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Banner/uctAdvertorial.ascx" TagName="uctAdvertorial" TagPrefix="uc1" %>

<asp:Content id="Content1" ContentPlaceHolderID="CPH1" Runat="Server">

<table id="Table1" class="PagesTable">

    <%-- BEGIN TOP --%>
    <tr>
        <td>
        
            <uc8:uctQuickSearch ID="UctQuickSearch1" runat="server" />
        
        </td>
    </tr>
    <%-- END TOP --%>

    <tr><td class="VSpace"></td></tr>

    <%-- BEGIN |ADVERTORIAL and RECOMMEND| &  |SEARCH and TRANSFER| & |BEGIN AIR and FAVORITES| --%>   
    <tr>
        <td>
        
            <table id="Table5" class="PagesTable">
            
                <%-- BEGIN ADVERTORIAL and RECOMMEND --%>
                <tr>
                
                    <%-- BEGIN ADVERTORIAL --%>
                    <td class="DefaultLeft" style="height: 298px;">

                        <uc1:uctAdvertorial ID="UctAdvertorial1" runat="server" />
                        
                    </td>
                    <%-- END ADVERTORIAL --%>
                    
                    <td class="HSpace" />
                    
                    <%-- BEGIN RECOMMEND --%>
                    <td class="DefaultRight">
                    
                        <table id="Table7" class="Box" width="100%">
                            <tr>
                                <td style="background-color: #bce1f4;">
                                
                                    <uc2:uctRecommends ID="UctRecommends1" runat="server" />
                                   
                                </td>
                            </tr>
                        </table>
                    
                    </td>
                    <%-- END RECOMMEND --%>
                    
                </tr>
                <%-- END ADVERTORIAL and RECOMMEND --%>
                
            </table>
        
        </td>
    </tr>
    <%-- END |ADVERTORIAL and RECOMMEND| &  |SEARCH and TRANSFER| & |BEGIN AIR and FAVORITES| --%>
    
    <tr><td class="VSpace"></td></tr>

    <%-- BEGIN BANNER --%>
    <tr>
        <td>
        
            <table id="Table27" style="width: 100%; height: 129px;" class="Box">
                <tr>
                    <td>
                    
                        <uc7:uctBottomBanner ID="UctBottomBanner1" runat="server" />
                    
                    </td>
                </tr>
            </table>
        
        </td>
    </tr>
    <%-- END BANNER --%>

    <tr><td class="VSpace"></td></tr>

</table>

</asp:Content>

