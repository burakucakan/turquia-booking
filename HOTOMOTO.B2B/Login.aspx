<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" Title="TURQUIA B2B Login" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/UserControls/Login/uctLogin.ascx" TagName="uctLogin" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <!-- #INCLUDE FILE="Incs/Head.inc" -->
		
<!-- Import css/ -->
	<link href="Styles/Tag.css" rel="stylesheet" type="text/css" />
	<link href="Styles/Form.css" rel="stylesheet" type="text/css" />
	<link href="Styles/Text.css" rel="stylesheet" type="text/css" />
	<link href="Styles/Login.css" rel="stylesheet" type="text/css" />
	
    <link href="Styles/Processing.css" rel="stylesheet" type="text/css" />
	<link href="Styles/ModalPopup.css" rel="stylesheet" type="text/css" />
<!--// Import css/ -->

</head>
<body> 
    <!-- #INCLUDE FILE="Incs/JSControl.inc" -->

    <!-- #INCLUDE FILE="UserControls/Processing/Processing.html" -->

    <form id="form1" runat="server">
    
        <asp:ScriptManager id="ScrMng1" runat="server" 
        AsyncPostBackTimeout="3600"
        OnAsyncPostBackError="HandleError">
        
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Util.js" />
            <asp:ScriptReference Path="~/Scripts/AjaxUtil.js" />
        </Scripts>
        
        </asp:ScriptManager>

        <script>
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(endRequest);
        </script>

        <uc1:uctLogin ID="UctLogin1" runat="server" />

    </form>
    
</body>
</html>
