<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctPrivacy.ascx.cs" Inherits="UserControls_Common_uctPrivacy" %>
<%@ Register Src="~/UserControls/Common/uctPopupBottom.ascx" TagName="uctPopupBottom" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/uctPopupTop.ascx" TagName="uctPopupTop" TagPrefix="uc1" %>

<uc1:uctPopupTop ID="UctPopupTop1" runat="server" />

<br />
<div style="padding: 20px;">

    <asp:Label runat="server" ID="lblPrivacyTitle" CssClass="Title" Text="GÝZLÝLÝK SÖZLEÞMESÝ" meta:resourcekey="lblPrivacyTitleResource1"></asp:Label>
    <br /><br />
    <asp:Literal runat="server" ID="ltlPrivacyText" meta:resourcekey="ltlPrivacyTextResource1" Text="&#13;&#10;    Websitemize kayýt olurken kullandýðýnýz üyelik bilgileri ve kiþisel bilgiler gizli tutulmakta olup , sizin onayýnýz dýþýnda diðer üyelere açýlmaz. &#13;&#10;    <br /><br />&#13;&#10;    Esse Grup, Dünyanýn en geliþmiþ güvenlik teknolojisi ile kredi kartý ve kiþisel bilgilerinizi dünyada 75.000 den fazla e-ticaret sitesi güvenligi saglayan dünyanýn en büyük denetim sistemi HACKER SAFE ile hergün düzenli olarak denetlenmektedir. &#13;&#10;    <br /><br />&#13;&#10;    Esse Grup ile ödeme sistemlerini kullandýðý Bankalarýn ödeme sistemleri arasýnda Half Set sistemi kullanýlmaktadýr. Bu sistemde müþteri ile Sanal-POS (Internet üzerinden kredi kartýyla ödeme iþleminin gerçekleþmesini saðlayan yazýlým) arasýndaki bilgi akýþý SSL, Sanal-POS ile banka arasýndaki bilgi akýþý ise SET ile korunmaktadýr. &#13;&#10;    <br /><br />&#13;&#10;    SET ve SSL yazýlýmlarý, müþteri - iþletme - banka arasýndaki bilgi akýþýnýn, çözülme ihtimali matematiksel olarak çok düþük ve teknik açýdan çok zor olan (128)64 bit teknolojileriyle þifreli olarak yapýlmasýný saðlamaktadýr. &#13;&#10;    "></asp:Literal>

</div>

<br />

<uc2:uctPopupBottom ID="uctPopupBottom1" runat="server" />