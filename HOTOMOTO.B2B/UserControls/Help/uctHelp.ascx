<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHelp.ascx.cs" Inherits="UserControls_Help_uctHelp" %>

<table class="PagesTable">
    <tr>
        <td valign="top" style="width: 190px;">



            <table id="Table21" width="190" class="Box">
        <tr>
            <td>
                                                
                <table id="Table22" width="100%">
                
                    <%-- BEGIN HELP TOPIC BOX HEADER --%>
                    <tr>
                        <td class="BoxHeader BoxTitle">
                            <asp:Literal runat="server" id="ltlHelpTopicBoxTitle" Text="Yardým Konularý" meta:resourcekey="ltlHelpTopicBoxTitleResource1" />
                        </td>                                            
                    </tr>
                    <%-- END HELP TOPIC BOX HEADER --%>
                    
                    <%-- BEGIN HELP TOPICS --%>
                    <tr>
                        <td class="Padding">
                        <asp:Repeater runat="server" ID="rptHelpTopics" OnItemCommand="rptHelpTopics_ItemCommand">
                        <HeaderTemplate>
                            <table cellpadding="2" cellspacing="2">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    »&nbsp;&nbsp;<asp:LinkButton CssClass="clBlue" runat="server" ID="lbTopic" Text=<%# DataBinder.Eval(Container.DataItem, "Title") %> CommandArgument=<%# DataBinder.Eval(Container.DataItem, "HelpID") %> meta:resourcekey="lbTopicResource1"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <tr>
                                <td height="4"></td>
                            </tr>
                        </SeparatorTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                        </asp:Repeater>
                        
                        <br />
                        </td>
                    </tr>
                    <%-- END HELP TOPICS --%>
                    
                </table>
            
            </td>
        </tr>                            
        </table>


        
        </td>
        <td valign="top" style="padding-left: 10px;">
            
            
            
            <table id="Table1" width="100%" class="Box">
            <tr>
                <td>
                                                    
                    <table id="Table2" width="100%">
                        
                        <%-- BEGIN HELP CONTENT --%>
                        <tr>
                            <td class="Padding">
                            <br />

                            <b><asp:Literal runat="server" ID="ltlActiveHelpTopic" meta:resourcekey="ltlActiveHelpTopicResource1" /></b><br /><br />
                            <asp:Literal runat="server" ID="ltlActiveHelpContent" meta:resourcekey="ltlActiveHelpContentResource1" />
                            

                            <br /><br />
                            </td>
                        </tr>
                        <%-- END HELP CONTENT --%>
                        
                    </table>
                
                </td>
            </tr>                            
            </table>
            
            
            
        </td>
    </tr>
</table>