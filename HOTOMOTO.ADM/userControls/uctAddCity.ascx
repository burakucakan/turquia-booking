<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctAddCity.ascx.cs" Inherits="userControls_uctAddCity" %>
<div class="b710">
	<div class="title">
		�EH�R EKLE</div>
	<div class="main">
		<div class="info">
			�ehir ekle</div>
		<div class="label">
			<label for="txtKategori">
				�ehir ad�:</label></div>
		<div class="txtarea">
			<input id="txtKategori" class="textBox p50" name="txtKategori" type="text" value="" /></div>
		<div class="label">
			<label for="txtKategori">
				�lke:</label></div>
		<div class="combobox">
			<select class="s50" name="parentid">
				<option selected="selected">L�tfen Se�iniz</option>
			</select>
		</div>
		<div class="option">
			<input id="chkKategoriDevam" name="chkKategoriDevam" type="checkbox" value="1" /><label
				for="chkKategoriDevam">�ehir eklemeye devam et</label></div>
		<div class="action">
			<input alt="Yay�nla" src="../img/btnYayinla.gif" title="Yay�nla" type="image" /></div>
		<div class="c">
		</div>
	</div>
	<div class="bottom">
	</div>
</div>
