// JScript File

/* ---- :: Sayfanın Tam Ortasında Çıkarma :: ------------------------------------------------------------------------ */

/* 
id = Sayfanın ortasında çıkacak element
*/
function PageCenter(id)
{
	var el=document.getElementById(id)
	var pX, pY;
	var browser=navigator.appName;
 
    pX = document.documentElement && document.documentElement.clientWidth ? 
    document.documentElement.clientWidth/2 : document.body.clientWidth/2;

	pY = (document.documentElement && document.documentElement.scrollTop ? 
		document.documentElement.scrollTop : document.body.scrollTop) + ((document.documentElement && document.documentElement.clientHeight ? 
		document.documentElement.clientHeight : document.body.clientHeight)/2)
	
	el.style.top = pY + "px";
	el.style.left = pX + "px";
	
	$get(id).style.display = 'block';
}


/* ---- :: Select Elementlerini Göster / Gizle :: ------------------------------------------------------------------------ */

/* 
Action = 'Hide' ise gizle, 'Display' ise göster
*/
function HideDisplaySelectBoxes(Action) {
	for(var i = 0; i < document.forms.length; i++) {
		for(var e = 0; e < document.forms[i].length; e++){
			if(document.forms[i].elements[e].tagName == "SELECT") {
			    if (Action=='Hide') { document.forms[i].elements[e].className ='DropDownList Opacity'; }
			    else if (Action=='Display') { document.forms[i].elements[e].className ='DropDownList'; }
			}
		}
	}
}


/* ---- :: Ajax Request İşlem Yapılıyor :: ------------------------------------------------------------------------ */

function beginRequest()
{
    window.status='Loading...';
    HideDisplaySelectBoxes('Hide');
    PageCenter('dvProcessing');
}


function endRequest()
{
    window.status='Ready';
    HideDisplaySelectBoxes('Display');
    $get('dvProcessing').style.display = 'none';
}

function pageLoaded() 
{
    endRequest();
}