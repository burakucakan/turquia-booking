<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctFavorites.ascx.cs" Inherits="UserControls_Common_uctFavorites" %>

<table id="Table24" class="PagesTable Box">
<tr>
    <td>
                                        
        <table id="Table25" width="100%">
        
            <%-- BEGIN TRANSFER BOX HEADER --%>
            <tr>
                <td class="BoxHeader BoxTitle">
                    <asp:Literal runat="server" id="ltlFavoritesTitle" Text="Favori ��lemlerim" meta:resourcekey="ltlFavoritesTitleResource1" />
                </td>                                            
            </tr>
            <%-- END TRANSFER BOX HEADER --%>
            
            <%-- BEGIN TRANSFER BOX CONTENT --%>
            <tr>
                <td class="Padding" style="height: 88px;">
                
                    <table id="Table26" class="clNavy" cellspacing="3">
                        <tr>
                            <td align="Left">
                                <asp:Literal runat="server" id="ltlFavoriteContentText" Text=". S�k s�k ya�t���n�z rezervasyonlar� favori i�lemlerinize kaydederek. daha sonra kolayca ula�abilirsiniz" meta:resourcekey="ltlFavoriteContentTextResource1" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 37px;">
                                � &nbsp;<asp:HyperLink runat="server" id="hlFavorites" CssClass="clBlue" NavigateUrl="~/Default.aspx" Text="Favori ��lemlerinize Ula�mak ��in T�klay�n�z." meta:resourcekey="hlFavoritesResource1" />
                            </td>
                        </tr>
                    </table>
                
                </td>
            </tr>
            <%-- END TRANSFER BOX CONTENT --%>
            
        </table>
    
    </td>
</tr>                            
</table>