// JScript File
	
/* ---- :: Left Fonksiyonu :: ------------------------------------------------------------------------- */

/* 
str = Kelime
n = Soldan Kaç Karakter ?
*/
function Left(str, n){
	if (n <= 0)
	    return "";
	else if (n > String(str).length)
	    return str;
	else
	    return String(str).substring(0,n);
}



/* ---- :: Right Fonksiyonu :: ------------------------------------------------------------------------ */

/* 
str = Kelime
n = Sağdan Kaç Karakter ?
*/
function Right(str, n){
    if (n <= 0)
       return "";
    else if (n > String(str).length)
       return str;
    else {
       var iLen = String(str).length;
       return String(str).substring(iLen, iLen - n);
    }
}


/* ---- :: Giriş Sayfası Yap Fonksiyonu :: ------------------------------------------------------------------------ */
/* 
this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.link.com')
*/

/* ---- :: Favorilere Ekle Fonksiyonu :: ------------------------------------------------------------------------ */

/* 
Link = Link
Title = Görüntülenen Başlık
*/
function AddFavorites(Link, Title) {
	window.external.AddFavorite(Link, Title)
}


/* ---- :: Randum Numara Üretme :: ------------------------------------------------------------------------ */

/* 
MaxNumber = Kaça kadar bir sayı tutsun 
*/
function RandomNumber(MaxNumber) {
	return Math.floor(Math.random() * MaxNumber +1);
}