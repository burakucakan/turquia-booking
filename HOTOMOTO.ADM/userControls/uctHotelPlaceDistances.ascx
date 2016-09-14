<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctHotelPlaceDistances.ascx.cs" Inherits="userControls_uctHotelPlaceDistances" %>
<asp:UpdatePanel ID="upHotelPlaceDistances" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvHotelPlaceDistances" runat="server" AutoGenerateColumns="False" OnDataBound="gvHotelPlaceDistances_DataBound" AllowPaging="True" OnPageIndexChanging="gvHotelPlaceDistances_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Mekan Adý" />
                <asp:BoundField DataField="PlaceID" HeaderText="Mekan ID" />
                <asp:TemplateField HeaderText="Mesafesi (km)">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtHotelPlaceDistance" CssClass="textBox"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RangeValidator runat="server" ID="ravHotelPlaceDistance" Type="Integer" ControlToValidate="txtHotelPlaceDistance" SetFocusOnError="true" ErrorMessage="*" MinimumValue=0 MaximumValue=100000 ></asp:RangeValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="S&#252;resi (dk)">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtHotelPlaceTime" CssClass="textBox"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RangeValidator runat="server" ID="ravHotelPlaceTime" Type="Integer" ControlToValidate="txtHotelPlaceTime" SetFocusOnError="true" ErrorMessage="*" MinimumValue=0 MaximumValue=100000 ></asp:RangeValidator>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
