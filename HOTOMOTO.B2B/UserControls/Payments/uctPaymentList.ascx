<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctPaymentList.ascx.cs" Inherits="UserControls_Payments_uctPaymentList" %>
<%@ Register Src="~/UserControls/Common/uctPaging.ascx" TagName="uctPaging" TagPrefix="uc1" %>

<asp:Label CssClass="Title" runat="server" ID="ltlRptTitle" meta:resourcekey="ltlRptTitleResource1" />

<br /><br />

<asp:Label CssClass="clRed" runat="server" ID="ltlError" Font-Bold="true" Visible="False" meta:resourcekey="ltlErrorResource1" />

<asp:Repeater runat="server" ID="rptPayments" OnItemDataBound="rptPayments_ItemDataBound" OnItemCommand="rptPayments_ItemCommand">
    <HeaderTemplate>
    <table border="1" bordercolor="#e5e0e0" width="100%" align="center" cellpadding="5" cellspacing="0">
    
        <tr class="rptItem6 clWhite" height="40">
            <td width="90">
                <asp:Label ID="lblResType" runat="server" Text="Res. Type" meta:resourcekey="lblResTypeResource1"></asp:Label>
            </td>                                                         
            <td width="28%">
                <asp:Label ID="lblDescription" runat="server" Text="Res. Kodu" meta:resourcekey="lblDescriptionResource1"></asp:Label>
            </td>
            <td width="90">
                <asp:Label ID="lblUserName" runat="server" Text="Kullanýcý" meta:resourcekey="lblUserNameResource1"></asp:Label>
            </td>                                                        
            <td width="60">
                <asp:Label ID="lblPrice" runat="server" Text="Price" meta:resourcekey="lblPriceResource1"></asp:Label>
            </td>
            <td width="80">
                <asp:Label ID="lblPaymentTypeTitle" runat="server" Text="Payment Status" meta:resourcekey="lblPaymentTypeTitleResource1"></asp:Label>
            </td>
        </tr>
        
    </HeaderTemplate>
    <ItemTemplate>
    
        <tr>
        <td>
            <asp:Literal runat="server" ID="ltlReservationCode" Text='<%# DataBinder.Eval(Container.DataItem, "ReservationCode") %>' Visible="False" />
            <asp:Literal runat="server" ID="ltlReservationType" Text='<%# DataBinder.Eval(Container.DataItem, "ReservationType") %>' Visible="False" />
            
            <table width="87" align="center">
                <tr>
                    <td width="29" align="center"> <asp:Image ID="imgHotel" runat="server" ToolTip="Hotel" ImageUrl="~/Images/Icons/ReservationTypes/Hotel.gif" Visible="False" meta:resourcekey="imgHotelResource1"/> </td>
                    <td width="29" align="center"> <asp:Image ID="imgTour" runat="server" ToolTip="Tour" ImageUrl="~/Images/Icons/ReservationTypes/Tour.gif" Visible="False" meta:resourcekey="imgTourResource1"/> </td>
                    <td width="29" align="center"> <asp:Image ID="imgTransfer" runat="server" ToolTip="Transfer" ImageUrl="~/Images/Icons/ReservationTypes/Transfer.gif" Visible="False" meta:resourcekey="imgTransferResource1"/> </td>
                </tr>
            </table>
            
        </td>
        <td>            
            <asp:LinkButton CommandName='<%# DataBinder.Eval(Container.DataItem, "ReservationCode") %>' CssClass="RptItem" runat="server" ID="lnkDesc" Text='<%# DataBinder.Eval(Container.DataItem, "ReservationCode") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReservationID") %>' meta:resourcekey="lnkDescResource1" ></asp:LinkButton>
        </td>
        <td>
            <%# CARETTA.COM.Encryption.Decrypt(DataBinder.Eval(Container.DataItem, "UserName").ToString(), ConfigurationManager.AppSettings["EncryptionKey"].ToString()).ToString() %>
        </td>                                                        
        <td>
            <asp:Literal ID="ltlCurrLeft" runat="server" meta:resourcekey="ltlCurrLeftResource1"></asp:Literal>
            <asp:Label ID="ltlPriceUSD" runat="server" CssClass="clRed" Visible="False"><%# DataBinder.Eval(Container.DataItem, "TotalPriceUSD") %></asp:Label>
            <asp:Label ID="ltlPriceEUR" runat="server" CssClass="clRed" Visible="False"><%# DataBinder.Eval(Container.DataItem, "TotalPriceEUR") %></asp:Label>
            <asp:Literal ID="ltlCurrRight" runat="server" meta:resourcekey="ltlCurrRightResource1"></asp:Literal>
        </td>
        <td>
            <asp:Label ID="lblBookingState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "State") %>'></asp:Label>
        </td>
    </tr>
    
    </ItemTemplate>
    <FooterTemplate>
    
        </table>
        
    </FooterTemplate>
</asp:Repeater>

<uc1:uctPaging ID="UctPaging1" runat="server" Visible="false" />
