<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctRecommends.ascx.cs" Inherits="UserControls_Common_uctRecommends" %>
<%@ Register
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0"
    HeaderCssClass="RecommendHeaderBack" ContentCssClass="RecommendContent clNavy"
    FadeTransitions="true" FramesPerSecond="40" TransitionDuration="150"
    AutoSize="Fill" RequireOpenedPane="true" SuppressHeaderPostbacks="true">
    <Panes>
        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">        
    
            <Header>

                <table id="Table10" class="RecommendHeader">
                    <tr>
                        <td class="RecommendNumber">1</td>
                        <td style="width: 17px"></td>
                        <td class="RecommendTitle">
                        
                        <%=this.dtRecommendation.Rows[0]["Name"].ToString() %>
                        
                        </td>
                    </tr>
                </table>

            
            </Header>
            
            <Content>
                <br />
                
                    <%=CARETTA.COM.Util.Left(CARETTA.COM.Util.ClearHtmlTags(this.dtRecommendation.Rows[0]["Description"].ToString()), 400) %>...

                <br />
            
            </Content>
            
        </ajaxToolkit:AccordionPane>
        <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
        
            <Header>

                <table id="Table1" class="RecommendHeader">
                    <tr>
                        <td class="RecommendNumber">2</td>
                        <td style="width: 17px"></td>
                        <td class="RecommendTitle">
                        
                        <%=this.dtRecommendation.Rows[1]["Name"].ToString() %>
                                                                    
                        
                        </td>
                    </tr>
                </table>

            
            </Header>
            
            <Content>

                <br />

                    <%=this.dtRecommendation.Rows[1]["Description"].ToString() %>

                <br />
                            
            
        </Content>
            
        </ajaxToolkit:AccordionPane>
        <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
        
            <Header>

                <table id="Table2" class="RecommendHeader">
                    <tr>
                        <td class="RecommendNumber">3</td>
                        <td style="width: 17px"></td>
                        <td class="RecommendTitle">
                        
                        <%=this.dtRecommendation.Rows[2]["Name"].ToString() %>

                        </td>
                    </tr>
                </table>
            
            </Header>
            
            <Content>
            
                <br />

                    <%=this.dtRecommendation.Rows[2]["Description"].ToString() %>

                <br />
                
            </Content>
            
        </ajaxToolkit:AccordionPane>
    </Panes>
</ajaxToolkit:Accordion> 