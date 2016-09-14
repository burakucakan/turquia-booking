<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotel.ascx.cs" Inherits="UserControls_Hotel_uctHotel" %>
<%@ Register Src="~/UserControls/Common/uctGrayBoxBottom.ascx" TagName="uctGrayBoxBottom" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Common/uctPaging.ascx" TagName="uctPaging" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/uctHotelSearch.ascx" TagName="uctHotelSearch" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ModalPopup/ModalPopup.ascx" TagName="ModalPopup" TagPrefix="uc6" %>

<table class="PagesTable">

    <tr>
        <td>
        
<asp:UpdatePanel runat="server" ID="upHotelSearch">
<ContentTemplate>
        
            <uc1:uctHotelSearch ID="UctHotelSearch1" runat="server" />

</ContentTemplate>
</asp:UpdatePanel>         
            
        </td>
    </tr>
    
    <tr><td class="VSpace">
    
    
    
    </td></tr>
    
    <tr>
        <td>

            <asp:panel runat="server" ID="pnlHotelList" Visible="False" meta:resourcekey="pnlHotelListResource1">
            
                <asp:Repeater ID="rptHotelList" runat="server" OnItemCommand="rptHotelList_ItemCommand" OnItemDataBound="rptHotelList_ItemDataBound">
                    <HeaderTemplate>
                    <table class="rptTable" border="1" cellpadding="5">
                        <tr class="rptHeader clRed">
                            <td>                                                                            
                                <asp:Literal ID="ltlTitleHotel" runat="server" meta:resourcekey="ltlTitleHotelResource1" Text="HOTEL"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlTitleCity" runat="server" meta:resourcekey="ltlTitleCityResource1" Text="CITY"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlTitleHotelClass" runat="server" meta:resourcekey="ltlTitleHotelClassResource1" Text="CLASS"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlTitlePrice" runat="server" meta:resourcekey="ltlTitlePriceResource1" Text="PRICE"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlTitleAvailability" runat="server" meta:resourcekey="ltlTitleAvailabilityResource1" Text="AVAILABILITY"></asp:Literal>
                            </td>
                            <td align="center">
                                <asp:Literal ID="ltlTitleBook" runat="server" meta:resourcekey="ltlTitleBookResource1" Text="BOOK"></asp:Literal>
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        
                        <tr class="rptItem2">
                            <td>
                                <asp:Literal ID="ltlHotelID" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "HotelID") %>'></asp:Literal>
                                <asp:Literal ID="ltlCityID" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "CityID") %>'></asp:Literal>
                                <asp:Literal ID="ltlItemQuantity" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "RoomQuantity") %>'></asp:Literal>
                                <asp:HyperLink CssClass="RptItem" ID="hlHotelDetail" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "HotelName") %>'
                                NavigateUrl="<%# DataBinder.Eval(Container.DataItem, &quot;HotelID&quot;, &quot;javascript:HotelDetail('{0}')&quot;) %>" meta:resourcekey="hlHotelDetailResource1"
                                ></asp:HyperLink>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "City") %>
                            </td>
                            <td>
                                <%# HOTOMOTO.COM.ReturnClasses.GetHotelClassFormat(DataBinder.Eval(Container.DataItem, "Star").ToString()) %>
                            </td>
                            <td>
                                <asp:Literal ID="ltlCurrLeft" runat="server" meta:resourcekey="ltlCurrLeftResource1"></asp:Literal>
                                <asp:Literal ID="ltlPrice" runat="server" meta:resourcekey="ltlPriceResource1"></asp:Literal>
                                <asp:Literal ID="ltlCurrRight" runat="server" meta:resourcekey="ltlCurrRightResource1"></asp:Literal>
                            </td>                            
                            <td>
                               <%# CtrlNewRoomStatus(DataBinder.Eval(Container.DataItem, "NewRoomRequestable").ToString()) %>
                            </td>
                            <td align="center">
                               <asp:Button ID="btnBook" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NewRoomRequestable") %>' CssClass="Button" runat="server" Text="Book" Width="70px" meta:resourcekey="btnBookResource1" />
                            </td>                             
                        </tr>                        
                        
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                
                <!-- -------BEGIN PAGING -------->

                <uc2:uctPaging ID="uctPaging1" runat="server" />
                
                <!-- -------END PAGING -------->
            
            </asp:panel>

        </td>
    </tr>
    
</table>