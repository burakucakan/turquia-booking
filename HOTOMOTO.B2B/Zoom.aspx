<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zoom.aspx.cs" Inherits="Zoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
    <head>
    <title>Loading...</title>

<script type="text/javascript">

var isNN,isIE;

if (parseInt(navigator.appVersion.charAt(0))>=4){
	isNN=(navigator.appName=="Netscape")?1:0;
	isIE=(navigator.appName.indexOf("Microsoft")!=-1)?1:0;
}

function reSizeToImage(){
	if (isIE!=""){

		//window.resizeTo(250,250);
		
        width=document.images[0].width;
        height=document.images[0].height;
        
		//SW=250-(document.body.clientWidth-width);
		//SH=250-(document.body.clientHeight-document.images[0].height);
		
	    //if (SW>800) {SW=800;}
    	//if (SH>600) {SH=600;}

	    window.resizeTo(width,height);
	}
	
	if (isNN){
		width=document.images["imgId"].width;
		height=document.images["imgId"].height;
		
	//if (width>800) {width=800}
	//if (height>600) {height=600}
	
	window.innerWidth=width;
	window.innerHeight=height;
	}
}

function SayfaBaslik(){
	document.title="TURQUIA";
}

</script>

<style>
body {
	margin: 0px;
}
</style>

</head>

<body onload="reSizeToImage();SayfaBaslik();self.focus()">

    <% string FileName = Request.QueryString["Image"].ToString(); %>

    <img name="imgId" src="Images/<%=FileName%>" style="display:block; cursor: pointer;" onclick="self.close()">

</body>

</html>
