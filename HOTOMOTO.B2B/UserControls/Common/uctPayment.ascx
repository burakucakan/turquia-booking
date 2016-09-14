<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctPayment.ascx.cs" Inherits="UserControls_Common_uctPayment" %>
<%@ Register TagPrefix="CCValidate" Namespace="Etier" Assembly="CreditCardValidator" %>
<table class="PagesTable Box">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td class="PaymentHeaderBack MainTopHeader">
                        �DEME SAYFASI</td>
                </tr>
                <tr>
                    <td class="Padding">
                        <table width="100%" align="center" cellpadding="2" cellspacing="2">
                            <tr>
                                <td valign="top">
                                    <br />
                                    
                                    <table id="tblPaymentTypes" runat="server" width="100%" height="40" align="center" class="Box2">
                                        <tr>
                                            <td style="padding-left: 20px;">
                                                <asp:Literal runat="server" ID="ltlTitlePaymentType">
                                                    �DEME T�R�
                                                </asp:Literal>&nbsp;&nbsp;&nbsp;                                                   
                                                <asp:DropDownList Width="250" AutoPostBack="true" CssClass="DropDownList" ID="ddlPaymentTypes"
                                                    runat="server" OnSelectedIndexChanged="ddlPaymentTypes_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                        
                                    <br />                                    
                                    <asp:Panel ID="pnlCredibilities" runat="server" Visible="false">
                                        <table width="100%" align="center" class="Box2">
                                            <tr>
                                                <td style="padding-left: 20px;">
                                                    <br />
                                                    <br />
                                                    <asp:Literal runat="server" ID="ltlCredibilityDescription">
                                                    Rezervasyon Tutar� Kredinizden D��ecektir. <br /><br /> Rezervasyonunuz Aktif Hale Gelecektir.
                                                    </asp:Literal>
                                                    <br />
                                                    <br />
                                                    <asp:Literal ID="TitleReservationTotal" runat="server" Text="Rezervasyon Tutar�" />:
                                                    <asp:Label CssClass="CurrPrefix" ID="ltlResCurrLeft" runat="server" />
                                                    &nbsp;
                                                    <asp:Label CssClass="Price" ID="lblReservationPrice" runat="server" />&nbsp;
                                                    <asp:Label CssClass="CurrPrefix" ID="ltlResCurrRight" runat="server" />
                                                    <br />
                                                    <br />
                                                    <asp:Literal ID="TitleCreditLimit" runat="server" Text="Kredi Sonras� Limitiniz" />:
                                                    <asp:Literal ID="ltlCreditLeft" runat="server" />
                                                    &nbsp;
                                                    <asp:Label CssClass="Price" ID="lblCreditLimit" runat="server" />&nbsp;
                                                    <asp:Literal ID="ltlCreditRight" runat="server" />
                                                    <br /><br />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </asp:Panel>
                                    
                                    <asp:Panel ID="pnlPayment" runat="server" Visible="true">
                                        <asp:Panel runat="server" ID="pnlNoApprovedCard" Visible="false">
                                            <table bgcolor="#829bbc" width="100%" align="center" style="border: 1px solid #D5D6CC;">
                                                <tr>
                                                    <td style="padding-left: 20px;" class="clWhite">
                                                        <br /><b>
                                                        <asp:Literal runat="server" ID="ltlErrorCard">
                                                            ! ��LEM BA�ARISIZ <br />
                                                            L�tfen Bilgilerinizi Kontrol Ediniz.
                                                        </asp:Literal>
                                                        </b><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlNoConn" Visible="false">
                                            <table bgcolor="#829bbc" width="100%" align="center" style="border: 1px solid #D5D6CC;">
                                                <tr>
                                                    <td style="padding-left: 20px;" class="clWhite">
                                                        <br /><b>
                                                        <asp:Literal runat="server" ID="ltlErrorConn">
                                                            ! BA�LANTI KURULAMADI <br />
                                                            L�tfen m��teri temsilciniz ile irtibata ge�iniz.
                                                        </asp:Literal>
                                                        </b><br /><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>                                        
                                        <asp:Panel runat="server" ID="pnlMoneyOrder" Visible="false">
                                            <table width="100%" align="center" class="Box2">
                                                <tr>
                                                    <td style="padding-left: 20px;">
                                                        <br />
                                                        <br />
                                                        <asp:Literal ID="ltlMoneyOrderDesc" runat="server">
                                                    A�a��daki banka hesap numaralar�na havale yapt���n�z takdirde i�leminiz aktifle�ecektir.
                                                        </asp:Literal>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:Literal ID="MoneyOrderTitleReservationTotal" runat="server" Text="Rezervasyon Tutar�" />:
                                                        <asp:Label ID="MoneyOrderltlResCurrLeft" runat="server" CssClass="CurrPrefix" />
                                                        <asp:Label CssClass="Price" ID="MoneyOrderlblReservationPrice" runat="server" />&nbsp;
                                                        <asp:Label ID="MoneyOrderltlResCurrRight" runat="server" CssClass="CurrPrefix" />
                                                        <br />
                                                        <br />
                                                        <asp:Literal ID="ltlBankAccountTitle" runat="server">
                                                        BANKA HESAP NUMARALARIMIZ
                                                        </asp:Literal>
                                                        <br />
                                                        <br />
                                                        <asp:Literal ID="ltlBankAccount1" runat="server">
                                                        Garanti Bankas�<br />
                                                        87879879<br />
                                                        RETUR TOURISM<br />
                                                        </asp:Literal>
                                                        <br />
                                                        <asp:Literal ID="ltlBankAccount2" runat="server">
                                                        Garanti Bankas�<br />
                                                        87879879<br />
                                                        RETUR TOURISM<br />
                                                        <br /><br />
                                                        </asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlCreditCard" Visible="false">
                                            <table width="100%" align="center" class="Box2">
                                                <tr>
                                                    <td style="padding-left: 20px;">
                                                        <br /><br />
                                                        <asp:Literal runat="server" ID="ltlNoSavedCreditCard" Text="Kay�tl� Kredi Kart� Bulunmamaktad�r" Visible="false"></asp:Literal>
                                                        <hr style="width: 200px;"/>
                                                        <table width="100%" cellpadding="3" cellspacing="3" style="text-align: left;">
                                                            <tr>
                                                                <td width="120">
                                                                    <asp:Literal runat="server" ID="ltlSavedCreditCards"></asp:Literal></td>
                                                                <td style="text-align: left;">
                                                                    <asp:DropDownList runat="server" ID="ddlSavedCreditCards" CssClass="DropDownList"
                                                                        OnSelectedIndexChanged="ddlSavedCreditCards_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="CreditCardTitleReservationTotal" runat="server" Text="Rezervasyon Tutar�" />:</td>
                                                                <td>
                                                                    <asp:Label CssClass="CurrPrefix" ID="CreditCardltlResCurrLeft" runat="server" />
                                                                    &nbsp;
                                                                    <asp:Label CssClass="Price" ID="CreditCardlblReservationPrice" runat="server" />&nbsp;
                                                                    <asp:Label CssClass="CurrPrefix" ID="CreditCardltlResCurrRight" runat="server" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    *
                                                                    <asp:Literal ID="ltlCreditCardNo" runat="server">Credit Card NO</asp:Literal>:
                                                                </td>
                                                                <td>
                                                                
                                                                    <asp:TextBox MaxLength="25" Width="200" CssClass="TextBox" ID="txtCreditCardNo" runat="server" />                                                                
                                                                
                                                                    <asp:RequiredFieldValidator ID="errReqCreditCard" ControlToValidate="txtCreditCardNo" ErrorMessage="L�tfen Kredi Kart� Numaran�z� Giriniz" CssClass="Error" Display="Dynamic" runat="server" EnableClientScript="true" />
                                                                    <asp:RegularExpressionValidator ID="errRegExCreditCard" ControlToValidate="txtCreditCardNo" ValidationExpression="^\d+$" ErrorMessage="L�tfen Kredi Kart� Numaran�z� Do�ru Giriniz" Display="dynamic" runat="server" EnableClientScript="true" />
                                                                    <CCValidate:CreditCardValidator ID="ErrCreditCardValidator" ControlToValidate="txtCreditCardNo" ErrorMessage="L�tfen Kredi Kart� Numaran�z� Do�ru Giriniz" Display="dynamic" runat="server" EnableClientScript="true" ValidateCardType="false" />                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    *
                                                                    <asp:Literal ID="ltlExpireDate" runat="server">Son Kullanma Tarihi</asp:Literal>:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList CssClass="DropDownList" ID="ddlExpireDateMonth" runat="server">
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:DropDownList CssClass="DropDownList" ID="ddlExpireDateYear" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    *
                                                                    <asp:Literal ID="ltlCVV" runat="server">CVV</asp:Literal>:
                                                                </td>
                                                                <td>                                                                    
                                                                    <asp:TextBox Width="100" CssClass="TextBox" ID="txtCVV" MaxLength="4" runat="server" />
                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCVV"
                                                                        CssClass="Error" Display="Dynamic" ErrorMessage="L�tfen CVV numaras�n� do�ru giriniz"
                                                                        MaximumValue="9999" MinimumValue="100" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" ControlToValidate="txtCVV" ErrorMessage="L�tfen Kredi Kart�n�z�n CVV Numaras�n� Giriniz" CssClass="Error" Display="Dynamic" runat="server" EnableClientScript="true" />
                                                                </td>                                                                    
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        
                                                        <table border="1" width="60%" bordercolor="white" cellpadding="2" cellspacing="2">
                                                            <tr>
                                                                <td style="padding: 10px;" bgcolor="#E2E2E2">
                                                                    <asp:CheckBox ID="chAcceptSaveCardNO" runat="server" />
                                                                    <asp:Literal runat="server" ID="ltlAcceptSaveCardNO"> 
                                                                    Kredi Kart� Bilgilerim Kaydedilsin </asp:Literal>
                                                                    <br /><br />
                                                                    <asp:Literal runat="server" ID="ltlCardDescription"> 
                                                                    Kart Tan�m� </asp:Literal>:
                                                                    <asp:TextBox Width="150" CssClass="TextBox" runat="server" ID="txtCardDescription" MaxLength="50"></asp:TextBox>                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </asp:Panel>
                                    <br />
                                    <asp:Button CssClass="Button" Text="REZERVASYONU TAMAMLA" runat="server" ID="btnCheckOut" OnClick="btnCheckOut_Click" Visible="false" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
