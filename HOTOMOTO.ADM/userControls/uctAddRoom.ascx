<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctAddRoom.ascx.cs" Inherits="userControls_uctAddRoom" %>
<%@ Register Src="Common/uctMLTabs.ascx" TagName="uctMLTabs" TagPrefix="uc4" %>
<%@ Register Src="uctRoomProperties.ascx" TagName="uctRoomProperties" TagPrefix="uc2" %>
<%@ Register Src="uctRoomImages.ascx" TagName="uctRoomImages" TagPrefix="uc3" %>
<%@ Register Src="uctMessage.ascx" TagName="uctMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<uc1:uctMessage ID="UctMessage1" runat="server" Visible="false" />
<div class="b710">
    <div class="title">
        ODA EKLE</div>
    <div class="main">
        <div class="info">
            Oda ekle</div>
        <div style="margin: 10px;">
            &nbsp;<uc4:uctMLTabs ID="UctMLTabs1" runat="server" />
        </div>
        <div style="margin: 10px;">
            <table>
                <tr>
                    <td style="width: 100px" valign="top">
                        <asp:Label ID="lblRoomClass" runat="server" Text="Maksimum Kapasite" CssClass="label"></asp:Label></td>
                    <td style="width: 100px" colspan="4" nowrap="nowrap">
                        <asp:TextBox ID="txtCapacity" runat="server" CssClass="textBox" Width="51px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvCapacity" runat="server" ErrorMessage="*"
                            SetFocusOnError="True" ControlToValidate="txtCapacity"></asp:RequiredFieldValidator><asp:RangeValidator
                                ID="rvCapacity" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ControlToValidate="txtCapacity" MaximumValue="99" MinimumValue="0"
                                Type="Double"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                        <asp:Label ID="lblRoomProperties" runat="server" Text="Özellikler" CssClass="label"></asp:Label></td>
                    <td colspan="4" style="width: 100px">
                        <uc2:uctRoomProperties ID="UctRoomProperties1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                        <asp:Label ID="lblRoomImages" runat="server" Text="Resimler" CssClass="label"></asp:Label></td>
                    <td colspan="4" style="width: 100px">
                        <uc3:uctRoomImages id="UctRoomImages1" runat="server"></uc3:uctRoomImages></td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                    </td>
                    <td colspan="4" style="width: 100px" align="right">
                        <asp:CheckBox ID="chkContinue" runat="server" Text="Oda Eklemeye Devam Et" Width="182px" />
                        <asp:ImageButton ID="btnPublish" runat="server" ImageUrl="~/img/btnYayinla.gif" ToolTip="Kaydet"
                            AlternateText="Yayýnla" OnClick="btnPublish_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
