using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_Common_uctReservationSummary : BaseUserControl {

    #region : Properties :

    private DataTable m_dtGuests;
	private DataTable m_dtRooms;
	private DataTable m_dtRoomDetails;
	private DataTable m_dtTours;
	private DataTable m_dtTransfers;

	private int m_intHotelID;
	private string m_strHotelName;
	private DateTime m_dArrivalDate;
	private DateTime m_dDepartureDate;
	private string m_strReservationStatus;
	private int m_intAdultCount;
	private int m_intChildCount;
    private float m_ReservationTotalPrice = 0;

	private bool hasRoomReservation;
	private bool hasTourReservation;
	private bool hasTransferReservation;
    private bool hasGeneralRoomReservation;
    private bool hasGeneralTourReservation;
    private bool hasGeneralTransferReservation;

    #endregion

    public bool isNewReservation
    {
        get { return (ViewState["isNewReservation"] == null ? false : bool.Parse(ViewState["isNewReservation"].ToString())); }
        set { ViewState["isNewReservation"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack){

            CtrlSummaryType();              // Summary Sayfasýna Nerden Gelmiþ (Yeni Rezervasyon Or Geçmiþ Rezervasyon) 
            
            GetSessionData();               // Geçici Verileri Sessiondan Al         
            
            RemoveTempSession();            // Geçici Session verilerini sil         
            
            BindToSession();                // Genel Session a Al                    
        
            Initialize();                   // Panellerin Ýçeriðini Düzenle          
        
        }
    }

    private void CtrlSummaryType() {

        if (Session["ReservationCode"] != null)
        {
            Response.Redirect("~/" + ConfigurationManager.AppSettings["PaymentPage"].ToString());
        }

        if ((Request.UrlReferrer != null) && (CARETTA.COM.Util.ReturnRefererPageName() == ConfigurationManager.AppSettings["HistoryPayments"].ToString()) && 
            (Request.QueryString["SummaryType"]==null || (Request.QueryString["SummaryType"].ToString() != ((int)HOTOMOTO.BUS.Enumerations.SummaryType.NewReservation).ToString())))
        {
            this.isNewReservation = false;

            //// Eski rezervasyon Proforma Göster ve açýklamayý pasifle 
            if (Session["ReservationCode"] != null)
            {
                txtReservationDefiniton.Text = Session["ReservationCode"].ToString();
            }
            else { Response.Redirect("~/Default.aspx"); }

            txtReservationDefiniton.Enabled = false;

            pnlActiveReservationLinks.Visible = false; // ***** 
        }
        else
        {
            if ((Session["Reservations"] == null) && (((Session["Room"] == null) && (Session["Tour"] == null) && (Session["Transfer"] == null))))
            {
                Response.Redirect("~/Default.aspx");
            }
            //// Yeni rezervasyon proforma gösterme ve açýklamayý aktifleþtir
            this.isNewReservation = true;
            txtReservationDefiniton.Enabled = true;
            pnlActiveReservationLinks.Visible = true;
        }
    }

    #region : ÝÞLEMLER :

    private void GetSessionData() {
        //Hotel bilgilerini al.		
        this.m_intHotelID = this.SessRoot.CurrentHotelID;
        this.m_strHotelName = this.SessRoot.CurrentHotelName;
        this.m_dArrivalDate = this.SessRoot.ArrivalDate;
        this.m_dDepartureDate = this.SessRoot.DepartureDate;
        this.m_strReservationStatus = Enum.GetName(typeof(HOTOMOTO.BUS.Enumerations.NewRequestable), this.SessRoot.NewRequestable);

        this.m_dtGuests = (DataTable)Session["Guest"];

        this.hasRoomReservation = Session["Room"] != null && ((DataTable)Session["Room"]).Rows.Count > 0;
		if(this.hasRoomReservation) {
			this.m_dtRooms = (DataTable)Session["Room"];
			this.m_dtRoomDetails = this.SessRoot.RoomsDetail;
		}

        this.hasTourReservation = Session["Tour"] != null && ((DataTable)Session["Tour"]).Rows.Count > 0;
        if (this.hasTourReservation) this.m_dtTours = (DataTable)Session["Tour"];

        this.hasTransferReservation = Session["Transfer"] != null && ((DataTable)Session["Transfer"]).Rows.Count > 0;
        if (this.hasTransferReservation) this.m_dtTransfers = (DataTable)Session["Transfer"];
    }

    private void RemoveTempSession() {        
        Session.Remove("Room");
        Session.Remove("Tour");
        Session.Remove("Transfer");
        Session.Remove("Guest");
    }
	private void BindToSession() {
		//Genel session verisini oluþtur.
		ArrayList arrReservations;
        if (Session != null && Session["Reservations"] != null) {
            arrReservations = ((ArrayList)Session["Reservations"]);
        }
        else {
            arrReservations = new ArrayList();
        }

		Dictionary<string, object> resDetails = new Dictionary<string, object>();
		resDetails.Add("HotelID", this.m_intHotelID);
		resDetails.Add("HotelName", this.m_strHotelName);
		resDetails.Add("ArrivalDate", this.m_dArrivalDate);
		resDetails.Add("DepartureDate", this.m_dDepartureDate);
		resDetails.Add("BookingStatus", this.m_strReservationStatus);

        if (this.m_dtGuests != null) { resDetails.Add("Guests", this.m_dtGuests.Copy()); } 
        else { resDetails.Add("Guests", null); }

        if (this.m_dtRooms != null) { resDetails.Add("Room", this.m_dtRooms.Copy()); } 
        else { resDetails.Add("Room", null); }

		if(this.m_dtRoomDetails != null) { resDetails.Add("RoomDetail", this.m_dtRoomDetails.Copy()); } 
		else { resDetails.Add("RoomDetail", null); }

        if (this.m_dtTours != null) { resDetails.Add("Tour", this.m_dtTours.Copy()); } 
        else { resDetails.Add("Tour", null); }

        if (this.m_dtTransfers != null) { resDetails.Add("Transfer", this.m_dtTransfers.Copy()); } 
        else { resDetails.Add("Transfer", null); }

		arrReservations.Add(resDetails);

        Session["Reservations"] = arrReservations;

        int i = 0, j = 0, k = 0;
        
        foreach (Dictionary<string, object> dc in arrReservations) {
            if (dc["Room"] != null) {
                foreach (DataRow dr in ((DataTable)dc["Room"]).Rows) {
                    i++;
                }
            }

            if (dc["Tour"] != null) {
                foreach (DataRow dr in ((DataTable)dc["Tour"]).Rows) {
                    j++;
                }
            }

            if (dc["Transfer"] != null) {
                foreach (DataRow dr in ((DataTable)dc["Transfer"]).Rows) {
                    k++;
                }
            }
        }

        hasGeneralRoomReservation = i > 0;
        hasGeneralTourReservation = j > 0;
        hasGeneralTransferReservation = k > 0;

        if ((!this.isNewReservation) && (Session["Hotel"] != null)) {
            DataTable dtHotel = (DataTable)Session["Hotel"];
            int SessDtIndex = 0;
            foreach (Dictionary<string, object> dc in ((ArrayList)Session["Reservations"])) {
                dc["HotelID"] = dtHotel.Rows[SessDtIndex]["HotelID"].ToString();
                dc["HotelName"] = dtHotel.Rows[SessDtIndex]["HotelName"].ToString();
                dc["ArrivalDate"] = dtHotel.Rows[SessDtIndex]["ArrivalDate"].ToString();
                dc["DepartureDate"] = dtHotel.Rows[SessDtIndex]["DepartureDate"].ToString();
                dc["BookingStatus"] = dtHotel.Rows[SessDtIndex]["BookingStatus"].ToString();
                SessDtIndex++;
            }
        }
	}

    #endregion

    private void Initialize() {
        pnlHotelInfo.Visible = hasGeneralRoomReservation;
		if(hasGeneralRoomReservation) {  //hasGeneralRoomReservation
            GenerateRoomDataSource();
		}

		pnlTour.Visible = hasGeneralTourReservation;
		if(hasGeneralTourReservation) {
            GenerateTourDataSource();
		}

        pnlTransfer.Visible = hasGeneralTransferReservation;
		if(hasGeneralTransferReservation) {
            GenerateTransferDataSource();
		}
	}

	private void GenerateRoomDataSource() {
		float totalPrice = 0.0F;
        HOTOMOTO.BUS.Enumerations.NewRequestable ReservationStatus = HOTOMOTO.BUS.Enumerations.NewRequestable.Available;
		DataTable dtReservedRooms = new DataTable("ReservedRooms");

		dtReservedRooms.Columns.AddRange(new DataColumn[] { 
				new DataColumn("HotelID"), new DataColumn("HotelName"), new DataColumn("ArrivalDate"), new DataColumn("DepartureDate"),
				new DataColumn("BookingStatus"), new DataColumn("RowID"), new DataColumn("RoomID"), new DataColumn("RoomName"), new DataColumn("Capacity"), 
				new DataColumn("BedType"), new DataColumn("Adults"), new DataColumn("Children"), new DataColumn("GuestName"), 
				new DataColumn("PricePP"), new DataColumn("RoomTotalPrice"), new DataColumn("ReservationIndex")
		});

        int ReservationIndex = 0;
		foreach(Dictionary<string, object> dc in ((ArrayList)Session["Reservations"])) {
			if(dc["Room"] != null) {
				int hotelID = Convert.ToInt32(dc["HotelID"]);
				string hotelName = dc["HotelName"].ToString();
				DateTime arrival = Convert.ToDateTime(dc["ArrivalDate"]);
				DateTime departure = Convert.ToDateTime(dc["DepartureDate"]);

				foreach(DataRow dr in ((DataTable)dc["Room"]).Rows) {
					string roomOwner = string.Empty;
					int adultCount = 0;
					int childCount = 0;

					//Get guest name from guests datatable
					string roomRowID = string.Empty;
					foreach(DataRow drGuest in ((DataTable)dc["Guests"]).Rows) {
						if(roomRowID == drGuest["RoomRowID"].ToString())
							continue;
						roomRowID = drGuest["RoomRowID"].ToString();

						if(dr["RowID"].ToString() == drGuest["RoomRowID"].ToString()) {
							roomOwner = drGuest["GuestName"].ToString();
						}
					}

					foreach(DataRow drDetail in ((DataTable)dc["RoomDetail"]).Rows) {
						if(Convert.ToInt32(dr["RowID"]) == Convert.ToInt32(drDetail["RoomIndex"])) {
							adultCount = Convert.ToInt32(drDetail["AdultCount"]);
							childCount = Convert.ToInt32(drDetail["ChildCount"]);
						}
					}

					HOTOMOTO.BUS.Rooms room = new HOTOMOTO.BUS.Rooms();
					room.Load(this.SessRoot.LanguageID, Convert.ToInt32(dr["RoomID"]));

					dtReservedRooms.Rows.Add(hotelID, hotelName, arrival, departure, (int)this.SessRoot.NewRequestable, Convert.ToInt32(dr["RowID"]),
						Convert.ToInt32(dr["RoomID"]), room.RoomName, Convert.ToInt32(dr["Capacity"]), dr["BedTypeName"].ToString(), adultCount,
                        childCount, roomOwner, float.Parse(dr["PricePerson"].ToString()), float.Parse(dr["RoomTotalPrice"].ToString()), ReservationIndex);

					totalPrice += float.Parse(dr["RoomTotalPrice"].ToString());
				}
			}
            ReservationIndex++;
		}


        foreach (DataRow dr in dtReservedRooms.Rows)
        {
            if (Convert.ToInt32(dr["BookingStatus"]) == (int)HOTOMOTO.BUS.Enumerations.NewRequestable.OnRequest) {
                ReservationStatus = HOTOMOTO.BUS.Enumerations.NewRequestable.OnRequest;
                break;
            }
        }

		ltlHotelTotalPrice.Text = CARETTA.COM.Util.FormatPriceToString(totalPrice);
        ltlBookingStatus.Text = ReservationStatus.ToString();
		dtReservedRooms.DefaultView.Sort = "ArrivalDate";
		rptRooms.DataSource = dtReservedRooms;
		rptRooms.DataBind();
        this.m_ReservationTotalPrice += totalPrice;
	}
	private void GenerateTourDataSource() {
		DataTable dtTourReservations = new DataTable("ReservedTours");
		dtTourReservations.Columns.AddRange(new DataColumn[] { 
	        new DataColumn("TourNumber"), new DataColumn("TourID"), new DataColumn("TourType"), new DataColumn("GuestCount"), 
	        new DataColumn("TourName"), new DataColumn("TourDate"), new DataColumn("TourPrice"), new DataColumn("TourTotalPrice"),
            new DataColumn("ReservationAndTourIndex")
	    });

        int ReservationIndex = 0;
        int TourIndex = 0;
        foreach (Dictionary<string, object> dc in ((ArrayList)Session["Reservations"])) {
            TourIndex = 0;
            if (dc["Tour"] != null) {
                foreach (DataRow dr in ((DataTable)dc["Tour"]).Rows) {
                    int AdultCount = 0;
                    int ChildCount = 0;

                    AdultCount = Convert.ToInt32(dr["AdultCount"]);
                    ChildCount = Convert.ToInt32(dr["ChildCount"]);

                    float tourPricePP = float.Parse(dr["TourPrice"].ToString());

                    int ExcDiscountProportion = Convert.ToInt32(ConfigurationManager.AppSettings["ExcDiscountProportion"]);
                    float tourPriceAll = tourPricePP * AdultCount;

                    tourPriceAll += (((tourPricePP * ChildCount) * ExcDiscountProportion) / 100);

                    dtTourReservations.Rows.Add(dr["RowID"], dr["TourID"], dr["TourType"], AdultCount + ChildCount, dr["TourName"], dr["TourDate"], (tourPriceAll / (float)(AdultCount + ChildCount)), tourPriceAll, ReservationIndex.ToString() + "|" + TourIndex.ToString());

                    this.m_ReservationTotalPrice += tourPriceAll;
                    TourIndex++;
                }
            }
            ReservationIndex++;
        }

        rptTours.DataSource = dtTourReservations;
        rptTours.DataBind();
	}
    private void GenerateTransferDataSource() {
        DataTable dtTransfers = new DataTable("ReservedTransfers");
        dtTransfers.Columns.AddRange(new DataColumn[] {
	        new DataColumn("TransferDirection"), new DataColumn("TransferType"), new DataColumn("GuestCount"), 
            new DataColumn("GuidancePrice"), new DataColumn("Price"), new DataColumn("PortID"), 
            new DataColumn("PortName"), new DataColumn("Notes"), new DataColumn("Date"), new DataColumn("ReservationAndTransferIndex")
	    });

        int ReservationIndex = 0;
        int TransferIndex = 0;
        foreach (Dictionary<string, object> dc in ((ArrayList)Session["Reservations"])) {
            TransferIndex = 0;
            if (dc["Transfer"] != null)
            {
                foreach (DataRow dr in ((DataTable)dc["Transfer"]).Rows)
                {
                    dtTransfers.Rows.Add(
                        dr["TransferDirection"], dr["TransferType"], dr["GuestCount"], dr["GuidancePrice"],
                        (Convert.ToSingle(dr["GuestCount"]) * Convert.ToSingle(dr["Price"])), dr["PortID"], dr["PortName"], dr["Notes"], dr["Date"], ReservationIndex.ToString() + "|" + TransferIndex.ToString());
                    m_ReservationTotalPrice += (Convert.ToSingle(dr["GuestCount"]) * Convert.ToSingle(dr["Price"]));
                    TransferIndex++;
                }
            }
            ReservationIndex++;
        }
        dtTransfers.DefaultView.Sort = "Date";
        rptTransfers.DataSource = dtTransfers;
        rptTransfers.DataBind();
    }

    private void AddTourReservations_Guests(ref DataTable dtTourReservations_Guests, int ReservationNo, int TourIndex, string RoomBedPreferenceID, int GuestRowID) {

        DataRow dr = dtTourReservations_Guests.NewRow();

        dr["RowID"] = dtTourReservations_Guests.Rows.Count + 1;
        dr["ReservationNo"] = ReservationNo;
        dr["TourIndex"] = TourIndex;
        dr["RoomBedPreferenceID"] = RoomBedPreferenceID;
        dr["GuestRowID"] = GuestRowID;

        dtTourReservations_Guests.Rows.Add(dr);
    }

	protected void btnCheckOut_Click(object sender, EventArgs e) {

        ArrayList arrReservations = ((ArrayList)Session["Reservations"]);

        if (arrReservations.Count > 0)
        {
            DataTable dtRoom = null;
            DataTable dtTour = null;
            DataTable dtTransfer = null;
            DataTable dtTemp;
            DataTable dtTempGuests = null;

            DataTable dtNewGuests = new DataTable();
            dtNewGuests.Columns.AddRange(new DataColumn[] { new DataColumn("RowID"), new DataColumn("RoomIndex"), new DataColumn("GuestNameTitle"), new DataColumn("GuestName") });

            DataTable dtTourReservations_Guests = new DataTable();
            dtTourReservations_Guests.Columns.AddRange(new DataColumn[] { new DataColumn("RowID"), 
                new DataColumn("ReservationNo"), new DataColumn("TourIndex"), new DataColumn("RoomBedPreferenceID"), new DataColumn("GuestRowID") });

            int tmpHotelID = 0;
            int RoomIndex = 0;
            DateTime tmpArrivalDate, tmpDepartureDate;

            HOTOMOTO.BUS.Enumerations.NewRequestable ReservationStatus = HOTOMOTO.BUS.Enumerations.NewRequestable.Confirmed;

            for (int i = 0; i < arrReservations.Count; i++) {

                // Room tablosunu hazýrla 
                dtTemp = (DataTable)(((Dictionary<string, object>)arrReservations[i])["Room"]);

                if (dtTemp != null)
                {
                    tmpHotelID = Convert.ToInt32((((Dictionary<string, object>)arrReservations[i])["HotelID"]));
                    tmpArrivalDate = Convert.ToDateTime(((Dictionary<string, object>)arrReservations[i])["ArrivalDate"]);
                    tmpDepartureDate = Convert.ToDateTime(((Dictionary<string, object>)arrReservations[i])["DepartureDate"]);
                    if ((((Dictionary<string, object>)arrReservations[i])["BookingStatus"]).ToString() == HOTOMOTO.BUS.Enumerations.NewRequestable.OnRequest.ToString())
                    {
                        ReservationStatus = HOTOMOTO.BUS.Enumerations.NewRequestable.OnRequest;
                    }

                    dtTemp.Columns.AddRange( new DataColumn[] { 
                                                new DataColumn("HotelID"), 
                                                new DataColumn("ArrivalDate"), new DataColumn("DepartureDate")
                                            } );

                    if (dtRoom == null) { dtRoom = dtTemp.Clone(); }

                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        dr["HotelID"] = tmpHotelID;
                        dr["ArrivalDate"] = tmpArrivalDate;
                        dr["DepartureDate"] = tmpDepartureDate;
                    }

                    dtTempGuests = ((DataTable)(((Dictionary<string, object>)arrReservations[i])["Guests"]));

                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        RoomIndex++;

                        foreach (DataRow drGuests in dtTempGuests.Rows)
                        {
                            if (drGuests["RoomRowID"].ToString() == dr["RowID"].ToString()) {
                                DataRow drNewGuests = dtNewGuests.NewRow();
                                drNewGuests["RowID"] = dtNewGuests.Rows.Count + 1;
                                drNewGuests["RoomIndex"] = RoomIndex;
                                drNewGuests["GuestNameTitle"] = drGuests["GuestNameTitle"];
                                drNewGuests["GuestName"] = drGuests["GuestName"];
                                dtNewGuests.Rows.Add(drNewGuests);

                                for (int x = 1; x < 4; x++)
                                {
                                    if (drGuests["T" + x].ToString().ToLower() != "false")
                                    {
                                        AddTourReservations_Guests(ref dtTourReservations_Guests, i + 1, x, drGuests["T" + x].ToString(), Convert.ToInt32(drNewGuests["RowID"]));
                                    }
                                }

                            }
                        }

                        dr["RowID"] = RoomIndex;
                        dtRoom.Rows.Add(dr.ItemArray);

                    }
                    
                }

                // Turun tablosunu hazýrla 
                dtTemp = (DataTable)(((Dictionary<string, object>)arrReservations[i])["Tour"]);

                if (dtTemp != null)
                {
                    if (dtTour == null) { 
                        dtTour = dtTemp;
                        dtTour.Columns.Add("ReservationNo");

                        foreach (DataRow dr in dtTour.Rows) { dr["ReservationNo"] = (i + 1).ToString(); }
                    }
                    else {
                        foreach (DataRow dr in dtTemp.Rows) {
                            dtTour.Rows.Add(dr.ItemArray); 
                            dtTour.Rows[dtTour.Rows.Count - 1]["ReservationNo"] = (i + 1).ToString(); 
                        }
                    }
                }

                // Transferin tablosunu hazýrla 
                dtTemp = (DataTable)(((Dictionary<string, object>)arrReservations[i])["Transfer"]);

                if (dtTemp != null) {
                    if (dtTransfer == null) { dtTransfer = dtTemp; }
                    else {  foreach (DataRow dr in dtTemp.Rows) { dtTransfer.Rows.Add(dr.ItemArray); }  }
                }

            }

            HOTOMOTO.BUS.Reservation objRes = new HOTOMOTO.BUS.Reservation();

            string ReservationCode = String.Empty;
            int ActiveReservationID = 0;
            float ResTotalPrice = 0;
            if (Session["ReservationID"] == null) {
                ReservationCode = HOTOMOTO.COM.Payment.CreateReservationCode(Convert.ToInt32(ConfigurationManager.AppSettings["ReservationCodeLength"]));
            }
            else {
                ActiveReservationID = Convert.ToInt32(Session["ReservationID"]);
                ResTotalPrice = float.Parse(ltlReservationTotalPrice.Text);
            }

            Session["ResTotalPrice"] = ResTotalPrice;

            int ReservationID = objRes.Save(HOTOMOTO.BUS.Enumerations.BookingStates.Unpaid, String.Empty, 
                            this.SessRoot.CustomerID, txtReservationDefiniton.Text, false, 
                            HOTOMOTO.BUS.Enumerations.PaymentTypes.Unpaid, ReservationCode, 
                            Convert.ToDouble(ConfigurationManager.AppSettings["TaxRatio"]), this.SessRoot.UserID, 
                            this.SessRoot.CurrencyID, Convert.ToInt16(ConfigurationManager.AppSettings["CurrUSDIndex"]),
                            ReservationStatus, CARETTA.COM.Util.FormatPrice(ltlReservationTotalPrice.Text),
                            dtRoom, dtNewGuests, dtTour, dtTransfer, dtTourReservations_Guests, ActiveReservationID);
            
            if (ReservationID>0)
            {
                Session["ReservationID"] = ReservationID;
                Session["ReservationCode"] = ReservationCode;
                Response.Redirect("~/" + ConfigurationManager.AppSettings["PaymentPage"].ToString());
            }
            else if (ReservationID == 0) {
                Session.Remove("ReservationID");
                Session.Remove("ReservationCode");
                Session.Remove("Room");
                Session.Remove("Tour");
                Session.Remove("Transfer");
                Session.Remove("Guest");
                Session.Remove("Reservations");
                Response.Redirect("~/Default.aspx");
            }

        }
        else { Response.Redirect("~/Default.aspx"); }
        
	}
    
    private float GetCurr() {    // Döviz çevrimini yap 
        
        DataTable dtCurr = HOTOMOTO.BUS.Payment.GetAllCurrencies();
        float Curr = 0;
        if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD) {
            Curr = Convert.ToSingle(dtCurr.Rows[Convert.ToInt16(ConfigurationManager.AppSettings["CurrUSDIndex"])]["Value"]);
        }
        else if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR) {
            Curr = Convert.ToSingle(dtCurr.Rows[Convert.ToInt16(ConfigurationManager.AppSettings["CurrUSDIndex"]) + 1]["Value"]);
        }
        return Curr;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if ((rptRooms.Items.Count + rptTours.Items.Count + rptTransfers.Items.Count) == 0) {
            Response.Redirect("~/Default.aspx");
        }
        ltlReservationTotalPrice.Text = CARETTA.COM.Util.FormatPriceToString(this.m_ReservationTotalPrice);
    }

    protected void Page_Unload(object sender, EventArgs e) {
        if (!this.isNewReservation) {
            //Session["Reservations"] = null;
        }
    }

    protected void rptTours_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (e.CommandName == "lnkTourDelete") {
                int ReservationIndex = Convert.ToInt32((e.CommandArgument.ToString().Split('|')).GetValue(0));
                int TourIndex = Convert.ToInt32((e.CommandArgument.ToString().Split('|')).GetValue(1));
                ArrayList arrSessReservations = ((ArrayList)Session["Reservations"]);
                foreach (Dictionary<string, object> dc in arrSessReservations) {
                    if (arrSessReservations.IndexOf(dc) == ReservationIndex)
                    {
                        if (dc["Tour"] != null)
                        {
                            foreach (DataRow dr in ((DataTable)dc["Tour"]).Rows)
                            {
                                if (((DataTable)dc["Tour"]).Rows.IndexOf(dr) == TourIndex)
                                {
                                    dr.Delete();
                                    break;
                                }
                            }
                        }
                    }
                }
                Session["Reservations"] = arrSessReservations;
                Response.Redirect("~/" + ConfigurationManager.AppSettings["SummaryPage"].ToString());
            }
        }
    }
    protected void rptTransfers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (e.CommandName == "lnkTransferDelete")
            {
                int ReservationIndex = Convert.ToInt32((e.CommandArgument.ToString().Split('|')).GetValue(0));
                int TransferIndex = Convert.ToInt32((e.CommandArgument.ToString().Split('|')).GetValue(1));
                ArrayList arrSessReservations = ((ArrayList)Session["Reservations"]);
                foreach (Dictionary<string, object> dc in arrSessReservations)
                {
                    if (arrSessReservations.IndexOf(dc) == ReservationIndex)
                    {
                        if (dc["Transfer"] != null)
                        {
                            foreach (DataRow dr in ((DataTable)dc["Transfer"]).Rows)
                            {
                                if (((DataTable)dc["Transfer"]).Rows.IndexOf(dr) == TransferIndex)
                                {
                                    dr.Delete();
                                    break;
                                }
                            }
                        }
                    }
                }
                Session["Reservations"] = arrSessReservations;
                Response.Redirect("~/" + ConfigurationManager.AppSettings["SummaryPage"].ToString());
            }
        }
    }
    protected void rptRooms_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (e.CommandName == "lnkHotelDelete")
            {
                int ReservationIndex = Convert.ToInt32(e.CommandArgument);
                ArrayList arrSessReservations = ((ArrayList)Session["Reservations"]);
                foreach (Dictionary<string, object> dc in arrSessReservations)
                {
                    if (arrSessReservations.IndexOf(dc) == ReservationIndex)
                    {
                        arrSessReservations.RemoveAt(ReservationIndex);
                        break;
                    }
                }
                Session["Reservations"] = arrSessReservations;
                Response.Redirect("~/" + ConfigurationManager.AppSettings["SummaryPage"].ToString());
            }
        }
    }

    protected void rptRooms_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (!this.isNewReservation)
            {
                ((LinkButton)e.Item.FindControl("lnkDeleteHotel")).Enabled = false;
                ((LinkButton)e.Item.FindControl("lnkDeleteHotel")).OnClientClick = "return false;";
            }
        }
    }
    protected void rptTours_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (!this.isNewReservation)
            {
                ((LinkButton)e.Item.FindControl("lnkDeleteTour")).Enabled = false;
                ((LinkButton)e.Item.FindControl("lnkDeleteTour")).OnClientClick = "return false;";
            }
        }
    }
    protected void rptTransfers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (!this.isNewReservation)
            {
                ((LinkButton)e.Item.FindControl("lnkDeleteTransfer")).Enabled = false;
                ((LinkButton)e.Item.FindControl("lnkDeleteTransfer")).OnClientClick = "return false;";
            }
        }
    }
}
