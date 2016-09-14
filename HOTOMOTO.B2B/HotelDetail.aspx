<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HotelDetail.aspx.cs" Inherits="HotelDetail" %>

<%@ Register Src="UserControls/Hotel/uctHotelDetail.ascx" TagName="uctHotelDetail" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <!-- #INCLUDE FILE="Incs/Head.inc" -->
		
<!-- Import css/ -->
	<link href="Styles/PopupDetail.css" rel="stylesheet" type="text/css" />
<!--// Import css/ -->

    <script src="Scripts/Custom.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uctHotelDetail ID="UctHotelDetail1" runat="server" />
    </div>
    </form>
</body>
</html>    

