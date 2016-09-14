<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="UserControls/Error/uctError.ascx" TagName="uctError" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    
    <title>Turquia.Com | Error</title>
    
    <!-- Import css/ -->
    <link href="Styles/Tag.css" rel="stylesheet" type="text/css" />
	<link href="Styles/Form.css" rel="stylesheet" type="text/css" />
	<link href="Styles/Text.css" rel="stylesheet" type="text/css" />
	<link href="~/Styles/Error.css" rel="stylesheet" type="text/css" />
    <!--// Import css/ -->
    
</head>
<body>
    <form id="form1" runat="server">

        <uc1:uctError ID="UctError1" runat="server" />

    </form>
</body>
</html>
