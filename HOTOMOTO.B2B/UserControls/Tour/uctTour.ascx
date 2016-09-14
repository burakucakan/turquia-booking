<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTour.ascx.cs" Inherits="UserControls_Tour_uctTour" %>
<%@ Register Src="~/UserControls/ModalPopup/ModalPopup.ascx" TagName="uctGrayBoxBottom" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Common/uctGrayBoxBottom.ascx" TagName="uctGrayBoxBottom" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Common/uctPaging.ascx" TagName="uctPaging" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Tour/UctTourSearch.ascx" TagName="UctTourSearch" TagPrefix="uc1" %>

<table class="PagesTable">
    <tr>
        <td>
            <asp:UpdatePanel runat="server" ID="upTourSearch">
                <ContentTemplate>
                    <uc1:UctTourSearch ID="UctTourSearch1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="VSpace">
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel runat="server" ID="pnlTourList" Visible="False" meta:resourcekey="pnlTourListResource1">
                <asp:Repeater ID="rptTourList" runat="server" OnItemCommand="rptTourList_ItemCommand" OnItemDataBound="rptTourList_ItemDataBound">
                    <HeaderTemplate>
                        <table class="rptTable" border="1" cellpadding="5">
                            <tr class="rptHeader clRed">
                                <td>
                                    <asp:Literal ID="ltlTitleTour" runat="server" meta:resourcekey="ltlTitleTourResource1" Text="TOUR NAME"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlTitleStartCity" runat="server" meta:resourcekey="ltlTitleStartCityResource1" Text="START CITY"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlTitleMinCapacity" runat="server" meta:resourcekey="ltlTitleMinCapacityResource1" Text="MIN G."></asp:Literal>
                                </td>                                
                                <td>
                                    <asp:Literal ID="ltlTitlePrice" runat="server" meta:resourcekey="ltlTitlePriceResource1" Text="PRICE"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltlTitleBook" runat="server" meta:resourcekey="ltlTitleBookResource1" Text="BOOK"></asp:Literal>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="rptItem2">
                            <td>
                                <asp:Literal ID="ltlTourID" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "TourID") %>'></asp:Literal>
                                <asp:Literal ID="ltlCityID" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "CityID") %>'></asp:Literal>
                                <asp:HyperLink CssClass="RptItem" ID="hlTourDetail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' meta:resourcekey="hlTourDetailResource1"></asp:HyperLink>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "CityName") %>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "MinCapacity") %>
                                &nbsp;<asp:Literal runat="server" ID="ltlMinPerson" Text="Guest" meta:resourcekey="ltlMinPersonResource1"></asp:Literal>
                            </td>                            
                            <td>
                                <asp:Literal ID="ltlCurrLeft" runat="server" meta:resourcekey="ltlCurrLeftResource1"></asp:Literal>
                                <asp:Literal ID="ltlUSDPrice" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "USDPrice") %>'></asp:Literal>
                                <asp:Literal ID="ltlEURPrice" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "EURPrice") %>'></asp:Literal>
                                <asp:Literal ID="ltlCurrRight" runat="server" meta:resourcekey="ltlCurrRightResource1"></asp:Literal>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnBook" CssClass="Button" runat="server" Text="Book" Width="70px" meta:resourcekey="btnBookResource1" />
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
                
            </asp:Panel>
        </td>
    </tr>
</table>