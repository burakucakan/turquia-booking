<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctTopMenu.ascx.cs" Inherits="UserControls_Common_uctTopMenu" %>

<div id="dvTopMenu" class="divTopMenu">

    <asp:Repeater runat="server" ID="rptTopMenu">
    <HeaderTemplate>
    
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
    
    </HeaderTemplate>
    
    <ItemTemplate>
            <td 
            onmouseover="TopMenuOver('<%# DataBinder.Eval(Container.DataItem, "UserCommandID") %>', 1)"
            onmouseout="TopMenuOver('<%# DataBinder.Eval(Container.DataItem, "UserCommandID") %>', 0)"
            onclick="location.href='<%# DataBinder.Eval(Container.DataItem, "Link") %>'" >
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td rowspan='3' class='TabLeft'></td>
                        <td id='TabTop<%# DataBinder.Eval(Container.DataItem, "UserCommandID") %>' class='TabTop'></td>
                        <td rowspan='3' class='TabRight'></td>
                    </tr>
                    <tr>
                        <td class='Tab clBlack'>
                            <%# DataBinder.Eval(Container.DataItem, "Title") %>
                        </td>
                    </tr>
                </table>
            </td>
    </ItemTemplate>
    
    <FooterTemplate>
    
        </tr>
    </table>
    
    </FooterTemplate>
    </asp:Repeater>
    
</div>

