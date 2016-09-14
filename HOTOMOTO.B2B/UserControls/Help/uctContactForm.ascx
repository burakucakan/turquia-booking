<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctContactForm.ascx.cs" Inherits="UserControls_Help_uctContactForm" %>

<table id="Table21" class="PagesTable Box">
        <tr>
            <td>
                                                
                <table id="Table22" width="100%">
                    
                    <%-- BEGIN CONTACT FORM BOX HEADER --%>
                    <tr>
                        <td class="BoxHeader BoxTitle">
                            <asp:Literal runat="server" id="ltlHelpTopicBoxTitle" Text="Destek Talebi" meta:resourcekey="ltlHelpTopicBoxTitleResource1" />
                        </td>                                            
                    </tr>
                    <%-- END CONTACT FORM BOX HEADER --%>
                    
                    <%-- BEGIN CONTACT FORM --%>
                    <tr>
                        <td class="Padding">
                        
                        <asp:Panel runat="server" ID="pnlMailForm" meta:resourcekey="pnlMailFormResource1">
                        
                        <br />
                        <asp:Literal runat="server" id="ltlUserName" meta:resourcekey="ltlUserNameResource1" />
                        <br /><br />
                        <asp:Literal runat="server" id="ltlMessageTitle" Text="Mesajýnýz" meta:resourcekey="ltlMessageTitleResource1" />
                        <br />                        
                        <asp:TextBox runat="server" ID="txtMessage" CssClass="TextBox" TextMode="MultiLine" Height="150px" Width="90%" meta:resourcekey="txtMessageResource1"></asp:TextBox>
                        <br /><br />
                        <asp:Button runat="server" CssClass="Button" id="btnSend" Text="MESAJI G&#214;NDER" OnClick="btnSend_Click" meta:resourcekey="btnSendResource1" /> 
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="Error" ID="RequiredFieldValidator1" runat="server" ErrorMessage="&#160;! L&#252;tfen Mesajýnýzý Giriniz !" SetFocusOnError="True" ControlToValidate="txtMessage" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                        <br /><br /> 
                        
                        </asp:Panel>
                        
                        
                        <asp:Panel runat="server" ID="pnlMailFormSendSucc" Visible="False" meta:resourcekey="pnlMailFormSendSuccResource1">
                        
                            <asp:Literal runat="server" ID="ltlMailFormSendSucc" meta:resourcekey="ltlMailFormSendSuccResource1" Text="
                            &lt;br /&gt;&lt;br /&gt;Baþvurunuz elimize ulaþmýþtýr. &lt;br /&gt;&lt;br /&gt;
                            En kýsa s&#252;rede deðerlendirilecektir. &lt;br /&gt;&lt;br /&gt;
                            Ýlginiz i&#231;in teþekk&#252;r ederiz.
                             &lt;br /&gt;&lt;br /&gt; 
                            "></asp:Literal>
                            
                        </asp:Panel>
                        
                        <asp:Panel runat="server" ID="pnlMailFormSendErr" Visible="False" meta:resourcekey="pnlMailFormSendErrResource1">
                        <asp:Literal runat="server" ID="ltlMailFormSendErr" meta:resourcekey="ltlMailFormSendErrResource1" Text="
                            &lt;br /&gt;&lt;br /&gt;Baþvurunuz elimize ulaþmadý. &lt;br /&gt;&lt;br /&gt;
                            L&#252;tfen daha sonra tekrar deneyiniz. &lt;br /&gt;&lt;br /&gt;
                        "></asp:Literal>
                        </asp:Panel>
        
                        </td>
                    </tr>
                    <%-- END CONTACT FORM --%>
                    
                </table>
            
            </td>
        </tr>                            
        </table>