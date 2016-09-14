<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctPrivacy.ascx.cs" Inherits="UserControls_Common_uctPrivacy" %>
<%@ Register Src="~/UserControls/Common/uctPopupBottom.ascx" TagName="uctPopupBottom" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/uctPopupTop.ascx" TagName="uctPopupTop" TagPrefix="uc1" %>

<uc1:uctPopupTop ID="UctPopupTop1" runat="server" />

<br />
<div style="padding: 20px;">

    <asp:Label runat="server" ID="lblPrivacyTitle" CssClass="Title" Text="G�ZL�L�K S�ZLE�MES�" meta:resourcekey="lblPrivacyTitleResource1"></asp:Label>
    <br /><br />
    <asp:Literal runat="server" ID="ltlPrivacyText" meta:resourcekey="ltlPrivacyTextResource1" Text="&#13;&#10;    Websitemize kay�t olurken kulland���n�z �yelik bilgileri ve ki�isel bilgiler gizli tutulmakta olup , sizin onay�n�z d���nda di�er �yelere a��lmaz. &#13;&#10;    <br /><br />&#13;&#10;    Esse Grup, D�nyan�n en geli�mi� g�venlik teknolojisi ile kredi kart� ve ki�isel bilgilerinizi d�nyada 75.000 den fazla e-ticaret sitesi g�venligi saglayan d�nyan�n en b�y�k denetim sistemi HACKER SAFE ile herg�n d�zenli olarak denetlenmektedir. &#13;&#10;    <br /><br />&#13;&#10;    Esse Grup ile �deme sistemlerini kulland��� Bankalar�n �deme sistemleri aras�nda Half Set sistemi kullan�lmaktad�r. Bu sistemde m��teri ile Sanal-POS (Internet �zerinden kredi kart�yla �deme i�leminin ger�ekle�mesini sa�layan yaz�l�m) aras�ndaki bilgi ak��� SSL, Sanal-POS ile banka aras�ndaki bilgi ak��� ise SET ile korunmaktad�r. &#13;&#10;    <br /><br />&#13;&#10;    SET ve SSL yaz�l�mlar�, m��teri - i�letme - banka aras�ndaki bilgi ak���n�n, ��z�lme ihtimali matematiksel olarak �ok d���k ve teknik a��dan �ok zor olan (128)64 bit teknolojileriyle �ifreli olarak yap�lmas�n� sa�lamaktad�r. &#13;&#10;    "></asp:Literal>

</div>

<br />

<uc2:uctPopupBottom ID="uctPopupBottom1" runat="server" />