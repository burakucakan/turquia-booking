<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctAddCity.ascx.cs" Inherits="userControls_uctAddCity" %>
<div class="b710">
	<div class="title">
		ÞEHÝR EKLE</div>
	<div class="main">
		<div class="info">
			Þehir ekle</div>
		<div class="label">
			<label for="txtKategori">
				Þehir adý:</label></div>
		<div class="txtarea">
			<input id="txtKategori" class="textBox p50" name="txtKategori" type="text" value="" /></div>
		<div class="label">
			<label for="txtKategori">
				Ülke:</label></div>
		<div class="combobox">
			<select class="s50" name="parentid">
				<option selected="selected">Lütfen Seçiniz</option>
			</select>
		</div>
		<div class="option">
			<input id="chkKategoriDevam" name="chkKategoriDevam" type="checkbox" value="1" /><label
				for="chkKategoriDevam">Þehir eklemeye devam et</label></div>
		<div class="action">
			<input alt="Yayýnla" src="../img/btnYayinla.gif" title="Yayýnla" type="image" /></div>
		<div class="c">
		</div>
	</div>
	<div class="bottom">
	</div>
</div>
