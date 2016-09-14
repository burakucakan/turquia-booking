<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomDetail.aspx.cs" Inherits="RoomDetail" %>

<%@ Register Src="UserControls/Hotel/uctRoomDetail.ascx" TagName="uctRoomDetail"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <!-- #INCLUDE FILE="Incs/Head.inc" -->
		
<!-- Import css/ -->
	<link href="Styles/PopupDetail.css" rel="stylesheet" type="text/css" />
<!--// Import css/ -->

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uctRoomDetail id="UctRoomDetail1" runat="server">
        </uc1:uctRoomDetail></div>
    </form>
</body>
</html>
