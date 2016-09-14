<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctLastAddedMain.ascx.cs" Inherits="userControls_uctLastAddedMain" %>
<div class="b470" style="display: none;">
    <div class="title">
        SON EKLENENLER</div>
    <div class="main">
        <div id="itemlist">
            <table>
                <tr>
                    <th class="c1">
                        <input type="checkbox" value="all" /></th>
                    <th class="c2">
                        TÜR</th>
                    <th class="c3">
                        EKLENEN</th>
                    <th>
                        ÝÞLEMLER</th>
                </tr>
                <tr class="item">
                    <td class="c1">
                        <input type="checkbox" /></td>
                    <td class="c2">
                        Otel</td>
                    <td class="c3">
                        <div>
                            <a href="#video.php?id=XX">Lorem ipsum dolor sit amet</a></div>
                        <div>
                            Serkan tarafýndan</div>
                        <div>
                            20.02.2007 tarihinde eklendi</div>
                    </td>
                    <td class="c4">
                        <div>
                            <a href="#duzenle.php?tip=video?id=XX">düzenle</a></div>
                        <div>
                            <a href="#sil.php?tip=video?id=XX">kaldýr</a></div>
                    </td>
                </tr>
                <tr class="item">
                    <td class="c1">
                        <input type="checkbox" /></td>
                    <td class="c2">
                        Tur</td>
                    <td class="c3">
                        <div>
                            <a href="#video.php?id=XX">Excepteur sint occaecat cupidatat</a></div>
                        <div>
                            Serkan tarafýndan</div>
                        <div>
                            19.02.2007 tarihinde eklendi</div>
                    </td>
                    <td>
                        <div>
                            <a href="#duzenle.php?tip=video?id=XX">düzenle</a></div>
                        <div>
                            <a href="#sil.php?tip=video?id=XX">kaldýr</a></div>
                    </td>
                </tr>
                <tr class="item">
                    <td class="c1">
                        <input type="checkbox" /></td>
                    <td class="c2">
                        Oda</td>
                    <td class="c3">
                        <div>
                            <a href="#kategori.php?id=XX">Finibus Bonorum</a></div>
                        <div>
                            Serkan tarafýndan</div>
                        <div>
                            19.02.2007 tarihinde eklendi</div>
                    </td>
                    <td>
                        <div>
                            <a href="#duzenle.php?tip=kategori?id=XX">düzenle</a></div>
                        <div>
                            <a href="#sil.php?tip=kategori?id=XX">kaldýr</a></div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="group-actions">
            GRUP ÝÞLEMÝ: <a href="#sil.php?tip=toplu">Yayýndan kaldýr</a></div>
        <div class="main-actions">
            <a href="#videolar.php">Tüm haberler</a>, <a href="#kategoriler.php">Tüm kategoriler</a></div>
    </div>
    <div class="bottom">
    </div>
</div>
