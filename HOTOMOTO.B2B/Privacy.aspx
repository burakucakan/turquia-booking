<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Privacy.aspx.cs" Inherits="Privacy" %>

<%@ Register Src="UserControls/Common/uctPrivacy.ascx" TagName="uctPrivacy" TagPrefix="uc1" %>

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
        <uc1:uctPrivacy id="uctPrivacy1" runat="server">
        </uc1:uctPrivacy></div>
    </form>
</body>
</html>
