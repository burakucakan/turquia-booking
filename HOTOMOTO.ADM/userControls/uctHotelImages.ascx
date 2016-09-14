<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotelImages.ascx.cs" Inherits="userControls_uctHotelImages" %>
<table>
    <tr>
        <td valign="top">
            <asp:UpdatePanel ID="upRadioButtons" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table id="tblRadioButtons" runat="server">
                        <tr height="46px">
                            <td style="width: 100px;" valign="top">
                                <asp:RadioButton ID="rbHotelImage1" runat="server" OnCheckedChanged="rbHotelImage1_CheckedChanged"
                                    AutoPostBack="True" /></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td valign="top">
            <asp:UpdatePanel ID="upImages" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table id="tblImages" runat="server">
                        <tr height="70px">
                            <td style="width: 100px" valign="top">
                                <asp:Image ID="imgHotelImage1" runat="server" Height="60px" Width="90px" BorderStyle="Solid" BorderWidth="2px" ImageUrl="~/HotelImages/NoPicture.jpg" /></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td valign="top">
            <asp:UpdatePanel ID="upFileUploads" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table id="tblFileUploads" runat="server">
                        <tr height="60">
                            <td style="width: 100px" valign="top">
                                <asp:FileUpload ID="fuHotelImage1" runat="server" />
                                <br />
                                <asp:Button ID="btnRemoveImage1" runat="server" Text="Kaldýr" Width="90px" OnClick="btnRemoveImage_Click" />    
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
