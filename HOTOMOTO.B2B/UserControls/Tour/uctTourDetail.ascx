<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTourDetail.ascx.cs" Inherits="UserControls_Tour_uctTourDetail" %>
<%@ Register Src="~/UserControls/Common/uctPopupBottom.ascx" TagName="uctPopupBottom" TagPrefix="uc2" %>

            <table width="100%">
                <tr>
                    <td class="TourListHeader ListTitle" style="padding-left: 24px; padding-top: 25px;" valign="top">
                    
                        <asp:Literal runat="server" ID="ltlTourName" meta:resourcekey="ltlTourNameResource1"></asp:Literal>
                        &nbsp;&nbsp;
                        (
                        <asp:Literal runat="server" ID="ltlTourStartDate" meta:resourcekey="ltlTourStartDateResource1"></asp:Literal>
                        -
                        <asp:Literal runat="server" ID="ltlTourEndDate" meta:resourcekey="ltlTourEndDateResource1"></asp:Literal>
                        )
                        
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    
                                    <table width="92%">
                                    <tr>
                                        <td width="20%">
                                            
                                            <asp:Image runat="server" ID="imgTourBig" Width="236px" Height="178px" ImageUrl="~/Images/TourImages/Big/TourDefault.jpg" meta:resourcekey="imgTourBigResource1"/>
                                            
                                        </td>
                                        <td valign="top" style="padding-left: 10px; text-align: left;" width="80%">
                                            
                                            <table>
                                                <tr>                                                    
                                                    <asp:Repeater ID="rptTourImages" runat="server">
                                                    <ItemTemplate>
                                                        <td>
                                                            <img width="85" height="62" style="border-width: 0px; cursor: pointer;"
                                                            onclick=<%# DataBinder.Eval(Container.DataItem, "FileName", "Zoom('TourImages/Big/{0}')") %> 
                                                            src='<%# DataBinder.Eval(Container.DataItem, "FileName", "Images/TourImages/Small/{0}") %>' />
                                                        </td>
                                                        <td width="3"></td>
                                                    </ItemTemplate>
                                                    </asp:Repeater>
                                                </tr>
                                            </table>
                                            
                                            <br />
                                            <b><asp:Literal ID="ltlDescTitle" runat="server" meta:resourcekey="ltlDescTitleResource1" Text="Tour AÇIKLAMASI"></asp:Literal></b>
                                            <br /><br />
                                            <asp:Literal ID="ltlDescription" runat="server" meta:resourcekey="ltlDescriptionResource1"></asp:Literal>
                                           
                                            <br />
                                            
                                        </td>
                                    </tr>
                                    </table>
                                    
                                </td>
                            </tr>

                        </table>
                        
                        <br /><br />
                        <div style="text-align: left; width: 100%; padding-left: 20px;">                            
                            <b> <asp:Literal ID="ltlMinCapacityTitle" runat="server" meta:resourcekey="ltlMinCapacityTitleResource1" Text="Minimum Capacity"></asp:Literal></b>: 
                            <asp:Literal ID="ltlMinCapacity" runat="server" meta:resourcekey="ltlMinCapacityResource1"></asp:Literal>
                            <br /><br />
                            <b> <asp:Literal ID="ltlRecommendTitle" runat="server" meta:resourcekey="ltlRecommendTitleResource1" Text="Tour Tavsiyeleri"></asp:Literal></b>
                            <br /> <br />
                            <asp:Literal ID="ltlRecommend" runat="server" meta:resourcekey="ltlRecommendResource1"></asp:Literal>
                        </div>
                    </td>
                </tr>
            </table>
<br />

<uc2:uctPopupBottom ID="uctPopupBottom1" runat="server" />
