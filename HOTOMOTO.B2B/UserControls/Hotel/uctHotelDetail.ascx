<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotelDetail.ascx.cs" Inherits="UserControls_Hotel_uctHotelDetail" %>
<%@ Register Src="~/UserControls/Common/uctPopupBottom.ascx" TagName="uctPopupBottom" TagPrefix="uc2" %>

            <table width="100%">
                <tr>
                    <td class="ListHeader" style="padding-left: 14px; padding-top: 4px;" valign="top">
                    
                        <table>
                        <tr>
                            <td class="ListTitle">
                                <asp:Literal runat="server" ID="ltlChainName" meta:resourcekey="ltlChainNameResource1" />&nbsp;
                                <asp:Literal runat="server" ID="ltlCityName" meta:resourcekey="ltlCityNameResource1" />&nbsp;
                                (<asp:Literal runat="server" ID="ltlCountryName" meta:resourcekey="ltlCountryNameResource1" />)                           
                            </td>
                            <td>
                                <div id="dvStars" runat="server">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="ListTitle" style="height: 21px">
                                <asp:Literal runat="server" ID="ltlHotelName" meta:resourcekey="ltlHotelNameResource1"></asp:Literal>
                            </td>
                        </tr>
                        </table>
                        
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    
                                    <table width="92%">
                                    <tr>
                                        <td width="20%">
                                            
                                            <asp:Image runat="server" ID="imgHotelBig" Width="236px" Height="178px" ImageUrl="~/Images/HotelImages/Big/HotelDefault.jpg" meta:resourcekey="imgHotelBigResource1"/>
                                            
                                        </td>
                                        <td valign="top" style="padding-left: 10px; text-align: left;" width="80%">
                                            
                                            <table>
                                                <tr>                                                    
                                                    <asp:Repeater ID="rptHotelImages" runat="server">
                                                    <ItemTemplate>
                                                        <td>
                                                            <img border="0" width="85" height="62" style="cursor: pointer;"
                                                            onclick="<%# DataBinder.Eval(Container.DataItem, "FileName", "Zoom('HotelImages/Big/{0}')") %>" 
                                                            src='<%# DataBinder.Eval(Container.DataItem, "FileName", "Images/HotelImages/Small/{0}") %>' />
                                                        </td>
                                                        <td width="3"></td>
                                                    </ItemTemplate>
                                                    </asp:Repeater>
                                                </tr>
                                            </table>
                                                                                            
                                            <br />
                                            <b><asp:Literal ID="ltlDescTitle" runat="server" meta:resourcekey="ltlDescTitleResource1" Text="HOTEL AÇIKLAMASI"></asp:Literal></b>
                                            <br /><br />
                                            <asp:Literal ID="ltlDescription" runat="server" meta:resourcekey="ltlDescriptionResource1"></asp:Literal>
                                           
                                            <br />
                                            
                                        </td>
                                    </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="HotelDetailPropertiesBack">
                                
                                    <div id="dvHotelProperties" runat="server"></div>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                   <br /><br />
                                   <!-- BEGIN YAKIN YERLER -->
                                   
                                   <asp:panel ID="pnlPlaces" runat="server" meta:resourcekey="pnlPlacesResource1">
                                   
                                   <table width="96%">
                                    <tr>
                                        <td align="left">
                                            <b><asp:Label ID="ltlTitlePlaces" runat="server" Text="YAKIN YERLER" CssClass="T clNavy" meta:resourcekey="ltlTitlePlacesResource1"></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#e9f7fa" align="center">
                                            <br />
                                            
                                            <asp:Repeater ID="rptPlaces" runat="server" OnItemDataBound="rptPlaces_ItemDataBound">
                                            <HeaderTemplate>
                                                <table cellpadding="4" cellspacing="4" width="96%">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                    
                                                        <table bgcolor="#f8fcfd" width="100%" cellpadding="4" cellspacing="4">
                                                            <tr>
                                                                <td width="8%">
                                                                    <asp:Image runat="server" ID="imgPlaces1" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageFileName", "~/Images/Places/Small/{0}") %>' meta:resourcekey="imgPlaces1Resource1" /></td>
                                                                <td width="5%"></td>
                                                                <td width="82%" align="left" style="padding: 4px;">
                                                                    <B>
                                                                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                                                    </B>
                                                                    &nbsp;&nbsp;|&nbsp;&nbsp;
                                                                    <b><asp:Literal runat="server" ID="ltlDistance" Text="Uzaklýk (km):" meta:resourcekey="ltlDistanceResource1"></asp:Literal></b>&nbsp;
                                                                    <%# DataBinder.Eval(Container.DataItem, "Distance") %>
                                                                    &nbsp;- 
                                                                    <%# DataBinder.Eval(Container.DataItem, "Time") %>
                                                                    &nbsp;
                                                                    <asp:Literal runat="server" ID="ltlTime" Text="Dakika" meta:resourcekey="ltlTimeResource1"></asp:Literal>
                                                                    &nbsp;&nbsp;|&nbsp;&nbsp;
                                                                    » <a class="ULink" href='<%# DataBinder.Eval(Container.DataItem, "Link") %>' target="_blank">Detay</a>
                                                                    <br /><br />
                                                                    <asp:Panel runat="server" ID="pnlToolTip" CssClass="ToolTip" meta:resourcekey="pnlToolTipResource1"></asp:Panel>
                                                                    <asp:Label ID="lblPlacesDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' Visible="False" meta:resourcekey="lblPlacesDescriptionResource1"></asp:Label>                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    
                                                    </td>                                 
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                            </asp:Repeater>

                                            <br />
                                            
                                        </td>
                                    </tr>
                                   </table>
                                   
                                   </asp:panel>
                                   
                                   <!-- //END YAKIN YERLER -->
                                   
                                   <br /><br />
                                   
                                </td>
                            </tr>
                        </table>
                        
                    </td>
                </tr>
            </table>
<br />

<uc2:uctPopupBottom ID="uctPopupBottom1" runat="server" />
