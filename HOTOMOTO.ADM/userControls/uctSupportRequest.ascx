<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctSupportRequest.ascx.cs" Inherits="userControls_uctSupportRequest" %>
<div class="b230" style="display: none;">
    <form action="#yardimTalebi.php" method="post">
        <div class="title">
            YARDIM TALEB�</div>
        <div class="main">
            <div class="info">
                Destek yetkilisiyle temas kur</div>
            <div class="mail">
                Kimden: <strong>serkan@caretta.net</strong> (<a href="#duzenle.php?tip=destek">d�zenle</a>)</div>
            <div class="mail">
                Kime: <strong>destek@turquia.com</strong> (<a href="#duzenle.php?tip=profil">d�zenle</a>)</div>
            <div class="combobox">
                <select name="cbDestekTipi">
                    <option selected="selected" value="0">Bir konu se�iniz</option>
                    <option value="1">�al��ma hatas�</option>
                    <option value="2">Eklenti ihtiyac�</option>
                </select>
            </div>
            <div class="label">
                <label for="txtMesaj">
                    Yorumunuzu ekleyin:</label></div>
            <div class="txtarea">
                <textarea id="txtMesaj" name="txtMesaj"></textarea></div>
            <div class="option">
                <input id="chkKaydet" name="chkKaydet" type="checkbox" value="1" /><label for="chkKaydet">G�nderilenlere
                    kaydet</label></div>
            <div class="action">
                <input alt="G�nder" src="img/btnGonder.gif" title="G�nder" type="image" /></div>
            <div class="c">
            </div>
            <div class="actions">
                <a href="#yardimPaneli.php">Yard�m paneline git &raquo;</a></div>
        </div>
        <div class="bottom">
        </div>
    </form>
</div>
