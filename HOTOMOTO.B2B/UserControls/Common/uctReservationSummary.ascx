<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctReservationSummary.ascx.cs" Inherits="UserControls_Common_uctReservationSummary" %>
<table class="PagesTable Box">
	<tr>
		<td>
			<table width="100%">
				<tr>
					<td class="ReservationHeaderBack MainTopHeader">
						RESERVATION SUMMARY</td>
				</tr>
				<tr>
					<td align="center" bgcolor="#FFFFFF">
					    <br />
                        <div style="text-align: left; padding-left: 17px;">
                            <asp:Literal ID="ltlReservationDefiniton" runat="server" Text="Reservasyon Kodu" meta:resourcekey="ltlReservationDefinitonResource1"></asp:Literal>: 
                            <asp:TextBox Width="300px" CssClass="TextBox" ValidationGroup="NewReservation" runat="server" ID="txtReservationDefiniton" meta:resourcekey="txtReservationDefinitonResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="errNewReservation" ValidationGroup="NewReservation" CssClass="Error" ControlToValidate="txtReservationDefiniton" Display="Dynamic" ErrorMessage="! Lütfen Rezervasyon Tanýmýný Giriniz !" SetFocusOnError="True" meta:resourcekey="errNewReservationResource1"></asp:RequiredFieldValidator>
                        </div>					
					    <br />
						<asp:Panel ID="pnlHotelInfo" runat="server" meta:resourcekey="pnlHotelInfoResource1">
											
									<table cellpadding="3" cellspacing="3" style="text-align: left;" width="96%">
										<tr>
											<td class="T clNavy">
												<b>
													<asp:Literal ID="ltlTitleHotelReservation" runat="server" Text="HOTEL RESERVATION INFO" meta:resourcekey="ltlTitleHotelReservationResource1"></asp:Literal></b>
											</td>
										</tr>
										<tr>
											<td class="ReservationInfoCell" style="padding:10px;">												
												
												<asp:Repeater ID="rptRooms" runat="server" OnItemCommand="rptRooms_ItemCommand" OnItemDataBound="rptRooms_ItemDataBound">
													<HeaderTemplate>
														<table cellpadding="4" cellspacing="3" border="0" width="100%">
															<tr class="rptItem2">
																<th><asp:Literal ID="ltlRoomTblHotelNameTitle" runat="server" Text="Otel, Oda" meta:resourcekey="ltlRoomTblHotelNameTitleResource1"></asp:Literal></th>
																<th><asp:Literal ID="ltlRoomTblGuestTitle" runat="server" Text="Ziyaret&#231;i" meta:resourcekey="ltlRoomTblGuestTitleResource1"></asp:Literal></th>
																<th><asp:Literal ID="ltlRoomTblArrivalTitle" runat="server" Text="Geliþ - Gidiþ" meta:resourcekey="ltlRoomTblArrivalTitleResource1"></asp:Literal></th>
																<th><asp:Literal ID="ltlRoomTblAdultTitle" runat="server" Text="Yetiþkin" meta:resourcekey="ltlRoomTblAdultTitleResource1"></asp:Literal></th>
																<th><asp:Literal ID="ltlRoomTblChildTitle" runat="server" Text="&#199;ocuk" meta:resourcekey="ltlRoomTblChildTitleResource1"></asp:Literal></th>
																<th><asp:Literal ID="ltlRoomTblPPTitle" runat="server" Text="Kiþi baþý" meta:resourcekey="ltlRoomTblPPTitleResource1"></asp:Literal></th>
																<th><asp:Literal ID="ltlRoomTblTotalTitle" runat="server" Text="Toplam" meta:resourcekey="ltlRoomTblTotalTitleResource1"></asp:Literal></th>
																<th><asp:Literal ID="ltlRoomTblSelectTitle" runat="server" Text="Se&#231;im" meta:resourcekey="ltlRoomTblSelectTitleResource1"></asp:Literal></th>
															</tr>
													</HeaderTemplate>
													<ItemTemplate>
														<tr class="rptItem7">
															<td>
																<%# DataBinder.Eval(Container.DataItem, "HotelName") %>, 
																<%# DataBinder.Eval(Container.DataItem, "RoomName") %>
																(<%# DataBinder.Eval(Container.DataItem, "BedType") %>)
															</td>
															<td>
																<%# DataBinder.Eval(Container.DataItem, "GuestName") %>
															</td>
															<td>
																<%# CARETTA.COM.Util.Left(DataBinder.Eval(Container.DataItem, "ArrivalDate").ToString(), 10) %> - 
                                                                <%# CARETTA.COM.Util.Left(DataBinder.Eval(Container.DataItem, "DepartureDate").ToString(), 10) %>
															</td>
															<td>
																<%# DataBinder.Eval(Container.DataItem, "Adults") %>
															</td>
															<td>
																<%# DataBinder.Eval(Container.DataItem, "Children") %>
															</td>
															<td>
															    <%# this.SessRoot.CurrencySymbolLeft.ToString() %>
															    <%# CARETTA.COM.Util.FormatPriceToString(DataBinder.Eval(Container.DataItem, "PricePP")) %>
															    <%# this.SessRoot.CurrencySymbolRight.ToString() %>
															</td>
															<td>
															    <%# this.SessRoot.CurrencySymbolLeft.ToString() %>
																<%# CARETTA.COM.Util.FormatPriceToString(DataBinder.Eval(Container.DataItem, "RoomTotalPrice")) %>
																<%# this.SessRoot.CurrencySymbolRight.ToString() %>
															</td>
												            <td>
												                <asp:LinkButton OnClientClick="return confirm('Bu rezervasyou silmek istediðinizden emin misiniz')" CommandName="lnkHotelDelete" runat="server" ID="lnkDeleteHotel" Text="Remove"
												                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReservationIndex") %>' meta:resourcekey="lnkDeleteHotelResource1"
												                 />
												            </td>																
														</tr>
													</ItemTemplate>
													<FooterTemplate>
														</table>
													</FooterTemplate>
												</asp:Repeater>
												
												<br />
												
                                                <table border="0" cellpadding="4" cellspacing="3">
													<tr>
														<td class="rptItem2">
															<asp:Literal ID="ltlReservationStatusTitle" runat="server" Text="Reservation Status :" meta:resourcekey="ltlReservationStatusTitleResource1"></asp:Literal></td>
														<td>
															<b>
																<asp:Literal ID="ltlBookingStatus" runat="server" meta:resourcekey="ltlBookingStatusResource1"></asp:Literal></b></td>
													</tr>
													<tr>
														<td class="rptItem2">
															<asp:Literal ID="ltlTotalPriceTitle" runat="server" Text="Total :" meta:resourcekey="ltlTotalPriceTitleResource1"></asp:Literal></td>
														<td class="CurrPrefix">
															<b><asp:Label CssClass="Price" ID="ltlHotelTotalPrice" runat="server" meta:resourcekey="ltlHotelTotalPriceResource1"></asp:Label></b>
														</td>
													</tr>
												</table>												
												
											</td>
										</tr>
									</table>
									<br />
									
						</asp:Panel>
						<asp:Panel ID="pnlTour" runat="server" meta:resourcekey="pnlTourResource1">
							<table cellpadding="3" cellspacing="3" style="text-align: left;" width="96%">
								<tr>
									<td class="T clNavy">
										<b>
											<asp:Literal ID="ltlTitleRecommend" runat="server" meta:resourcekey="ltlTitleRecommendResource1" Text="TUR BÝLGÝLERÝ"></asp:Literal></b>
									</td>
								</tr>
								<tr>
									<td class="ReservationInfoCell" style="padding: 10px;">
									<asp:Repeater ID="rptTours" runat="server" OnItemCommand="rptTours_ItemCommand" OnItemDataBound="rptTours_ItemDataBound">
										<HeaderTemplate>
											<table border="0" cellpadding="4" cellspacing="3" width="100%">
												<tr class="rptItem2">
													<th>
													    <asp:Label runat="server" ID="lblTourName" Text="Tur Adý" meta:resourcekey="lblTourNameResource1" /></th>
													<th>
													    <asp:Label runat="server" ID="lblGuestCount" Text="Kiþi Sayýsý" meta:resourcekey="lblGuestCountResource1" /></th>
													<th>
														<asp:Label runat="server" ID="lblTourDate" Text="Tarih" meta:resourcekey="lblTourDateResource1" /></th>
													<th>
														<asp:Label runat="server" ID="lblPPerson" Text="Kiþi Baþý" meta:resourcekey="lblPPersonResource1" /></th>
													<th>
														<asp:Label runat="server" ID="lblTourLineTotal" Text="Total" meta:resourcekey="lblTourLineTotalResource1" /></th>
													<th>
														<asp:Label runat="server" ID="lblTourSelect" Text="Se&#231;im" meta:resourcekey="lblTourSelectResource1" /></th>														
												</tr>
										</HeaderTemplate>
										<ItemTemplate>
											<tr class="rptItem7">
												<td>
													<%# DataBinder.Eval(Container.DataItem, "TourName") %>
												</td>
												<td><%# DataBinder.Eval(Container.DataItem, "GuestCount") %> kiþi</td>
												<td>
													<%# DataBinder.Eval(Container.DataItem, "TourDate") %></td>
												<td>
                                                    <%# this.SessRoot.CurrencySymbolLeft.ToString() %>&nbsp;
                                                    <%# CARETTA.COM.Util.FormatPriceToString(DataBinder.Eval(Container.DataItem, "TourPrice")) %>
												    <%# this.SessRoot.CurrencySymbolRight.ToString() %>
												</td>
												<td>
                                                    <%# this.SessRoot.CurrencySymbolLeft.ToString() %>&nbsp;
                                                    <%# CARETTA.COM.Util.FormatPriceToString(DataBinder.Eval(Container.DataItem, "TourTotalPrice")) %>&nbsp;
												    <%# this.SessRoot.CurrencySymbolRight.ToString() %>
												</td>
												<td>
												    <asp:LinkButton OnClientClick="return confirm('Bu rezervasyou silmek istediðinizden emin misiniz')" CommandName="lnkTourDelete" runat="server" ID="lnkDeleteTour" Text="Remove"
												    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReservationAndTourIndex") %>' meta:resourcekey="lnkDeleteTourResource1"
												     />
												</td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
											</table>
										</FooterTemplate>
									</asp:Repeater>
									</td>
								</tr>
							</table>
							<br />
						</asp:Panel>
						<asp:Panel ID="pnlTransfer" runat="server" meta:resourcekey="pnlTransferResource1">
							<table cellpadding="3" cellspacing="3" style="text-align: left;" width="96%">
								<tr>
									<td class="T clNavy">
										<b>
											<asp:Literal ID="ltlTitleTransfer" runat="server" meta:resourcekey="ltlTitleTransferResource1" Text="TRANSFER BÝLGÝLERÝ"></asp:Literal></b>
									</td>
								</tr>
								<tr>
									<td class="ReservationInfoCell" style="padding: 10px;">
										<asp:Repeater ID="rptTransfers" runat="server" OnItemCommand="rptTransfers_ItemCommand" OnItemDataBound="rptTransfers_ItemDataBound">
											<HeaderTemplate>
												<table border="0" cellpadding="4" cellspacing="3" width="100%">
													<tr class="rptItem2">
														<th>
														    <asp:Literal runat="server" ID="ltlTransferTitleTransferDirection" Text="Transfer" meta:resourcekey="ltlTransferTitleTransferDirectionResource1" /></th>
														<th>
															<asp:Literal runat="server" ID="ltlTransferTitleTransferPort" Text="Havaalaný / Liman" meta:resourcekey="ltlTransferTitleTransferPortResource1" /></th>
														<th>
															<asp:Literal runat="server" ID="ltlTransferTitleTransferType" Text="Tipi" meta:resourcekey="ltlTransferTitleTransferTypeResource1" /></th>
														<th>
															<asp:Literal runat="server" ID="ltlTransferTitleTransferDate" Text="Tarih" meta:resourcekey="ltlTransferTitleTransferDateResource1" /></th>
														<th>
															<asp:Literal runat="server" ID="ltlTransferTitleTransferGuestCount" Text="Kiþi Sayýsý" meta:resourcekey="ltlTransferTitleTransferGuestCountResource1" /></th>
														<th>
															<asp:Literal runat="server" ID="ltlTransferTitleTransferTotal" Text="Toplam" meta:resourcekey="ltlTransferTitleTransferTotalResource1" /></th>
													    <th>
														    <asp:Label runat="server" ID="lblTransferSelect" Text="Se&#231;im" meta:resourcekey="lblTransferSelectResource1" /></th>															
													</tr>
											</HeaderTemplate>
											<ItemTemplate>
												<tr class="rptItem7">
													<td>
                                                        <%# ((HOTOMOTO.BUS.Enumerations.TransferDirections)Convert.ToInt16(DataBinder.Eval(Container.DataItem, "TransferDirection"))).ToString() %>
													</td>
													<td>
														<%# DataBinder.Eval(Container.DataItem, "PortName") %>
													</td>
													<td>
                                                        <%# ((HOTOMOTO.BUS.Enumerations.TransferTypes)Convert.ToInt16(DataBinder.Eval(Container.DataItem, "TransferType"))).ToString() %>
													</td>
													<td>
														<%# CARETTA.COM.Util.Left(DataBinder.Eval(Container.DataItem, "Date").ToString(), 16) %>
													</td>
													<td>
														<%# DataBinder.Eval(Container.DataItem, "GuestCount") %>
													</td>
													<td>
													
                                                    <%# this.SessRoot.CurrencySymbolLeft.ToString() %>&nbsp;
                                                    <%# CARETTA.COM.Util.FormatPriceToString(DataBinder.Eval(Container.DataItem, "Price")) %>&nbsp;
												    <%# this.SessRoot.CurrencySymbolRight.ToString() %>
													</td>
												    <td>
												        <asp:LinkButton OnClientClick="return confirm('Bu rezervasyou silmek istediðinizden emin misiniz')" CommandName="lnkTransferDelete" runat="server" ID="lnkDeleteTransfer" Text="Remove"
												        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReservationAndTransferIndex") %>' meta:resourcekey="lnkDeleteTransferResource1"
												         />
												    </td>													
												</tr>
											</ItemTemplate>
											<FooterTemplate>
												</table>
											</FooterTemplate>
										</asp:Repeater>
									</td>
								</tr>
							</table>
							<br />
						</asp:Panel>
						
						<br />
						
						<div style="text-align: right; padding-right: 20px;">
						    <asp:Label CssClass="Treb clRed" ID="ltlReservationTotalPriceTitle" runat="server" Text="Reservation Total :" meta:resourcekey="ltlReservationTotalPriceTitleResource1"></asp:Label>
					        <font class="CurrPrefix"> <% Response.Write(this.SessRoot.CurrencySymbolLeft.ToString()); %> </font>
						    <b><asp:Label CssClass="Price" ID="ltlReservationTotalPrice" runat="server" meta:resourcekey="ltlReservationTotalPriceResource1"></asp:Label></b>
						    <font class="CurrPrefix"> <% Response.Write(this.SessRoot.CurrencySymbolRight.ToString()); %> </font>
						</div>					
						
						<br /><br />
						
					</td>
				</tr>
				<tr>
					<td style="padding-left: 17px; padding-right: 20px;">
					    <asp:Panel runat="server" ID="pnlActiveReservationLinks" meta:resourcekey="pnlActiveReservationLinksResource1">
					        <table width="100%">
					        <tr>
					            <td>
					                »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddHotel" Text="Otel Ekle" NavigateUrl="~/Hotel.aspx" meta:resourcekey="hlAddHotelResource1"></asp:HyperLink>
					                &nbsp;&nbsp;|&nbsp;&nbsp;
					                »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddExcTour" Text="G&#252;nl&#252;k Tur Ekle" NavigateUrl="~/Excursion.aspx" meta:resourcekey="hlAddExcTourResource1"></asp:HyperLink>
					                &nbsp;&nbsp;|&nbsp;&nbsp;
					                »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddCircTour" Text="Gezi Ekle" NavigateUrl="~/Circuits.aspx" meta:resourcekey="hlAddCircTourResource1"></asp:HyperLink>
					                &nbsp;&nbsp;|&nbsp;&nbsp;
					                »&nbsp;<asp:HyperLink CssClass="clRed" runat="server" ID="hlAddTransfer" Text="Transfer Ekle" NavigateUrl="~/Transfer.aspx" meta:resourcekey="hlAddTransferResource1"></asp:HyperLink>
					            </td>
					            <td style="text-align: right;">
					                <asp:Button ID="btnCheckOut" runat="server" ValidationGroup="NewReservation" CssClass="Button" Text="REZERVASYONU TAMAMLA" OnClick="btnCheckOut_Click" meta:resourcekey="btnCheckOutResource1" />
					            </td>
					        </tr>
					        </table>
						</asp:Panel>
					</td>
				</tr>
				<tr> <td class="HSpace">
				    <br /><br />
				</td> </tr>
			</table>
		</td>
	</tr>
</table>
