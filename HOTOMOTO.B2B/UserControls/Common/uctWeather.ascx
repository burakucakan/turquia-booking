<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctWeather.ascx.cs" Inherits="UserControls_Common_uctWeather" %>

<table id="Table21" class="PagesTable Box">
<tr>
    <td>
                                        
        <table id="Table22" width="100%">
        
            <%-- BEGIN WEATHER CAST BOX HEADER --%>
            <tr>
                <td class="BoxHeader BoxTitle">
                    <asp:Literal runat="server" id="ltlWeatherCastTitle" Text="Tatil Yörelerinde Hava Durumu" meta:resourcekey="ltlWeatherCastTitleResource1" />
                </td>                                            
            </tr>
            <%-- END WEATHER CAST BOX HEADER --%>
            
            <%-- BEGIN WEATHER CAST BOX CONTENT --%>
            <tr>
                <td class="Padding" style="height: 88px;">
                
                    <table id="Table23" width="96%" cellpadding="2" cellspacing="2">
                    
                        <tr>
                            <td>
                                <asp:Image runat="server" id="imgWeather1" ImageUrl="~/Images/ContentImages/WeatherCast/1.jpg" meta:resourcekey="imgWeather1Resource1" /></td>
                            <td>
                                <asp:Image runat="server" id="imgWeather2" ImageUrl="~/Images/ContentImages/WeatherCast/2.jpg" meta:resourcekey="imgWeather2Resource1" /></td>
                            <td>
                                <asp:Image runat="server" id="imgWeather3" ImageUrl="~/Images/ContentImages/WeatherCast/3.jpg" meta:resourcekey="imgWeather3Resource1" /></td>                                                                                                              
                        </tr>
                        
                    </table>
                
                </td>
            </tr>
            <%-- END WEATHER CAST BOX CONTENT --%>
            
        </table>
    
    </td>
</tr>                            
</table>