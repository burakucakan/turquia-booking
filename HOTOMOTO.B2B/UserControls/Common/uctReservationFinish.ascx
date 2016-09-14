<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctReservationFinish.ascx.cs" Inherits="UserControls_Common_uctReservationFinish" %>

<table class="PagesTable Box">
    <tr>
        <td valign="top">
        
            <table width="100%">
                <tr>
                    <td style="padding: 30px;">
                    
                    <asp:Label ID="ltlThankYou" runat="server" Text="REZERVASYON TAMAMLANDI! " Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="X-Large" ForeColor="#3B8CA7" meta:resourcekey="ltlThankYouResource1"></asp:Label>
                    <br /><br />
                    <asp:Literal ID="ltlMessage" runat="server" meta:resourcekey="ltlMessageResource1" Text="&#13;&#10;Rezervasyonunuz tamamlanmýþ. <br> Bilgilendirme Maili Gitmiþtir.&#13;&#10;"></asp:Literal><br /><br />
                    
                    <br /><br />
                    
                    <img id="Img1" runat="server" src="~/Images/Icons/PaymentReservation.jpg" /> &nbsp;&nbsp;
                    <asp:HyperLink ID="hlPayment" runat="server" NavigateUrl="~/Payments.aspx" meta:resourcekey="hlPaymentResource1" Text="Ödemelerim Sayfasýna Git"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 20px" valign="top" height="400">
                        
                        <table cellpadding="5" cellspacing="5">
                            <tr>
                                <td colspan="2">
                                
                                    »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddHotel" Text="Otel Rezervasyonu" NavigateUrl="~/Hotel.aspx"></asp:HyperLink>
					                &nbsp;&nbsp;|&nbsp;&nbsp;
					                »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddExcTour" Text="Günlük Tur Rezervasyonu" NavigateUrl="~/Excursion.aspx"></asp:HyperLink>
					                &nbsp;&nbsp;|&nbsp;&nbsp;
					                »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddCircTour" Text="Gezi Rezervasyonu" NavigateUrl="~/Circuits.aspx"></asp:HyperLink>
					                &nbsp;&nbsp;|&nbsp;&nbsp;
					                »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddTransfer" Text="Transfer Rezervasyonu" NavigateUrl="~/Transfer.aspx"></asp:HyperLink>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" bgcolor="#d7eff9"></td>
                            </tr>                        
                        </table>
                        
                    </td>
                </tr>
            </table>
            
        </td>
    </tr>
</table>    