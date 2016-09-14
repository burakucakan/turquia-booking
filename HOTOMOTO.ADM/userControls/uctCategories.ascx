<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctCategories.ascx.cs" Inherits="userControls_uctCategories" %>
<div class="b230">
	<form action="#kategoriSil.php" method="post" name="DeleteCategories">
		<div class="title">
			KATEGORÝLER</div>
		<div class="main">
			<div class="info">
				Son eklenen kategoriler</div>
			<div class="links">
				<input id="ktsel[]" name="ktsel[]" type="checkbox" />
				<a href="#" title="x">Kategori 1</a></div>
			<div class="links">
				<input id="Checkbox1" name="ktsel[]" type="checkbox" />
				<a href="#" title="x">Kategori 2</a></div>
			<div class="group-actions">
				GRUP ÝÞLEMÝ: <a href="javascript:document.DeleteCategories.submit();">Yayýndan kaldýr</a></div>
			<div class="main-actions">
				<a href="#kategoriler.php">Tüm kategoriler</a></div>
		</div>
		<div class="bottom">
		</div>
	</form>
</div>
