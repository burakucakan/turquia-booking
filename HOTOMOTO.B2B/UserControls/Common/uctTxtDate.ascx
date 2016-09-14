<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTxtDate.ascx.cs" Inherits="UserControls_Common_uctTxtDate" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:TextBox runat="server" id="txtDate" CssClass="TextBox" width="93%" />
<ajaxToolkit:CalendarExtender ID="defaultCalendarExtender" runat="server" 
Format="dd.MM.yyyy"
TargetControlID="txtDate" Enabled="True" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen Tarihi Giriniz" ControlToValidate="txtDate" CssClass="Error" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>

