using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using CARETTA.COM;

public partial class UserControls_Hotel_uctHotelReservation : BaseUserControl {

    protected void Page_Load(object sender, EventArgs e) {

        ((Literal)this.Page.Form.FindControl("ltlScript")).Text = "";

        RightVisible();             //Sað Kýsýmý Gizle        

        PopulateRooms();            //Odalar Tablosunu Oluþtur

        if (!IsPostBack) {

            RemoveSession();

            WriteTitle();           //Hotel Adýný ve Tarihi Yaz         

            LoadTours();            //Turlarý Yükle                     

            UctTransfer1.MaxPerson = GetGuestCount(); //Transferdeki Kiþi Sayýsý DDL için max Kiþi Sayýsý 
            
        }
        else {

            //Silinecek tur varsa sil                                                            
            if ((Request.Form["hdTours"] != null) && (Request.Form["hdTours"].ToString() != "")) {
                RemoveTour(int.Parse(Request.Form["hdTours"].ToString()));
            }

            //Dahil et checkboxlarýný sessiona at      
            UpdateCheckTourSession();
     
        }
    }

    private void RemoveSession() { 
        Session.Remove("Guest");
        Session.Remove("Room");
        Session.Remove("Tour");
        Session.Remove("Transfer");
    }

    private void RightVisible() {
        ((Literal)this.Page.Form.FindControl("ltlScript")).Text = ((Literal)this.Page.Form.FindControl("ltlScript")).Text + "<script>SideVisible('Right','none')</script>";
    }

    private void WriteTitle() {
        ltlHotelName.Text = this.SessRoot.CurrentHotelName;
        ltlArrivalDate.Text = this.SessRoot.ArrivalDate.ToShortDateString();
        ltlDeparture.Text = this.SessRoot.DepartureDate.ToShortDateString();
    }

    private int GetGuestCount() {
        int GuestCount = 0;
        foreach (DataRow dr in this.SessRoot.RoomsDetail.Rows) {
            GuestCount += (Convert.ToInt32(dr["AdultCount"]) + Convert.ToInt32(dr["ChildCount"]));
        }
        return GuestCount;        
    }



    //ROOM ÝÞLEMLER -------------------------------------------------------------------------------------------------------

    protected void PopulateRooms() {

        Table tblRoom = new Table();
        tblRoom.CssClass = "rptTable";
        tblRoom.CellPadding = 5;
        tblRoom.CellSpacing = 1;
        tblRoom.BorderWidth = Unit.Pixel(1);
        tblRoom.Width = Unit.Percentage(100);

        TableRow tblRow;

        tblRow = new TableRow();
        tblRow.CssClass = "rptHeader";

        //Resx
        tblRow.Cells.Add(HTMLHelper.GetTdLiteral("Oda Tipi"));
        tblRow.Cells.Add(HTMLHelper.GetTdLiteral("Bed Type"));
        tblRow.Cells.Add(HTMLHelper.GetTdLiteral("Kiþi Baþý Fiyatý"));
        tblRow.Cells.Add(HTMLHelper.GetTdLiteral("Toplam Fiyat"));

        tblRoom.Rows.Add(tblRow);

        foreach (DataRow dr in this.SessRoot.RoomsDetail.Rows) {
            tblRow = new TableRow();
            tblRow.CssClass = "rptItem";
            TableCell tblCell;

            tblCell = new TableCell();
            DropDownList ddlRoomTypes = GetDDLRoomTypes(dr["RoomIndex"].ToString());
            tblCell.Controls.Add(ddlRoomTypes);

            tblRow.Cells.Add(tblCell);

            tblCell = new TableCell();
            int GuestCount = Convert.ToInt16(dr["AdultCount"]) + Convert.ToInt16(dr["ChildCount"]);
            tblCell.Controls.Add(GetDDLGetBedPreferences(dr["RoomIndex"].ToString(), GuestCount, 156, "BedType"));
            tblRow.Cells.Add(tblCell);
            
            tblCell = new TableCell();
            Literal ltlPP = new Literal();
            ltlPP.ID = "ltlPP" + dr["RoomIndex"].ToString();

            Literal ltlCurrLeft;
            Literal ltlCurrRight;            
            ltlCurrLeft = new Literal();
            ltlCurrRight = new Literal();
            ltlCurrLeft.Text = this.SessRoot.CurrencySymbolLeft + " ";
            ltlCurrRight.Text = " " + this.SessRoot.CurrencySymbolRight;

            tblCell.Controls.Add(ltlCurrLeft);
            tblCell.Controls.Add(ltlPP);
            tblCell.Controls.Add(ltlCurrRight);

            tblRow.Cells.Add(tblCell);

            tblCell = new TableCell();            

            Literal ltlTP = new Literal();
            ltlTP.ID = "ltlTP" + dr["RoomIndex"].ToString();

            ltlCurrLeft = new Literal();
            ltlCurrRight = new Literal();
            ltlCurrLeft.Text = this.SessRoot.CurrencySymbolLeft + " ";
            ltlCurrRight.Text = " " + this.SessRoot.CurrencySymbolRight;

            tblCell.Controls.Add(ltlCurrLeft);
            tblCell.Controls.Add(ltlTP);
            tblCell.Controls.Add(ltlCurrRight);

            tblRow.Cells.Add(tblCell);

            tblRoom.Rows.Add(tblRow);
        }

        pnlRoomList.Controls.Add(tblRoom);
        
    }

    private DropDownList GetDDLRoomTypes(string ddlID) {
        DropDownList ddl = new DropDownList();
        ddl.ID = "ddlRoomTypes" + ddlID;
        ddl.AutoPostBack = true;
        ddl.Width = Unit.Pixel(156);
        ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
        ddl.DataSource = HOTOMOTO.BUS.Rooms.GetRoomAvailability(this.SessRoot.LanguageID, this.SessRoot.CurrentHotelID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate);
        ddl.DataTextField = "RoomName";
        ddl.DataValueField = "RoomID";
        ddl.DataBind();
        return ddl;
    }

    void ddl_SelectedIndexChanged(object sender, EventArgs e) {
        UpdatePrices();
    }

    private DropDownList GetDDLGetBedPreferences(string ddlID, int GuestCount, int Width, string TextField) {
        DropDownList ddl = new DropDownList();
        ddl.ID = "ddlBedPreferences" + ddlID.ToString();
        ddl.Width = Unit.Pixel(Width);
        ddl.AutoPostBack = true;
        ddl.DataSource = HOTOMOTO.BUS.Rooms.GetBedPreferenceByCapacity(this.SessRoot.LanguageID, GuestCount);
        ddl.DataTextField = TextField;
        ddl.DataValueField = "RoomBedPreferenceID";
        ddl.DataBind();
        return ddl;
    }




    //GUEST ÝÞLEMLER -------------------------------------------------------------------------------------------------------

    protected void PopulateGuests() {
        Table tbl = new Table();
        tbl.CellPadding = 5;
        tbl.CellSpacing = 1;
        tbl.CssClass = "rptTable";

        TableRow Row;
        Row = new TableRow();
        Row.CssClass = "rptHeader";

        Row.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("ROOM", "left", "25%"));
        Row.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("GUEST NAMES", "left", "75%"));
        DataTable dtTour = new DataTable();
        if (Session["Tour"] != null) {
            dtTour = ((DataTable)Session["Tour"]);
        }
        for (int i = 1; i <= dtTour.Rows.Count; i++) {
            Row.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral(dtTour.Rows[i - 1]["TourName"].ToString() + "<br>" + CARETTA.COM.Util.Left(dtTour.Rows[i - 1]["TourDate"].ToString(), 10)));
        }

        tbl.Rows.Add(Row);

        for (int i = 1; i <= this.SessRoot.RoomsDetail.Rows.Count; i++) {
            Row = new TableRow();

            if (i % 2 != 0) { Row.CssClass = "rptItem7"; }
            else { Row.CssClass = "rptItem4"; }

            string RoomType = ((DropDownList)pnlRoomList.FindControl("ddlRoomTypes" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).SelectedItem.Text;
            string BedPreferences = ((DropDownList)pnlRoomList.FindControl("ddlBedPreferences" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).SelectedItem.Text;
            
            Row.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral(RoomType + "<br><br>" + BedPreferences, "left"));

            TableCell Cell = new TableCell();
            int AdultCount = Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[i - 1]["AdultCount"]);
            int ChildCount = Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[i - 1]["ChildCount"]);
            int FirstChildAge = Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[i - 1]["FirstChildAge"]);
            int SecondChildAge = Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[i - 1]["SecondChildAge"]);
            Cell.Controls.Add(PopulateGuestNames(this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString(), AdultCount, ChildCount, FirstChildAge, SecondChildAge));

            Row.Cells.Add(Cell);
            int GuestCount = 0;
            int GuestStartIndex = 0;
            for (int j = 1; j <= dtTour.Rows.Count; j++) {
                GuestStartIndex = 0;
                Cell = new TableCell();
                GuestCount = (Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[i - 1]["AdultCount"]) + Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[i - 1]["ChildCount"]));
                if (i>1) {
                    for (int y = i - 1; y > 0; y--) {
                        GuestStartIndex += (Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[y - 1]["AdultCount"]) + Convert.ToInt32(this.SessRoot.RoomsDetail.Rows[y - 1]["ChildCount"]));
                    }
                }
                Cell.Controls.Add(GetTourCheckTable(this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString(), j, GuestCount, GuestStartIndex));
                Row.Cells.Add(Cell);
            }

            tbl.Rows.Add(Row);
        }

        if (dtTour.Rows.Count > 0) {
            Row = new TableRow();
            Row.CssClass = "rptItem";
            TableCell Cell;
            Cell = new TableCell();
            Cell.ColumnSpan = 2;
            Row.Cells.Add(Cell);

            for (int i = 1; i <= dtTour.Rows.Count; i++) {
                Cell = new TableCell();
                LinkButton lbRemove = new LinkButton();
                lbRemove.CssClass = "rptItem";
                lbRemove.CausesValidation = false;
                lbRemove.CommandArgument = dtTour.Rows[i - 1]["RowID"].ToString();
                lbRemove.ID = "lbRemove" + lbRemove.CommandArgument;
                //lbRemove.Click += new EventHandler(lbRemove_Click);
                lbRemove.OnClientClick = "document.getElementById('hdTours').value='" + lbRemove.CommandArgument + "'";
                lbRemove.Text = "Remove";
                Cell.Controls.Add(lbRemove);
                Cell.Style.Add("text-align", "center");
                Row.Cells.Add(Cell);
            }

            tbl.Rows.Add(Row);
        }


        pnlGuestsAndTours.Controls.Add(tbl);
    }

    private Table PopulateGuestNames(string RoomIndex, int AdultCount, int ChildCount, int FirstChildAge, int SecondChildAge) {
        Table tbl = new Table();
        tbl.CellPadding = 2;
        tbl.CellSpacing = 2;
        tbl.Width = Unit.Percentage(100);

        TableRow Row;
        int ChildAge = 0;
        HOTOMOTO.BUS.Enumerations.GuestType GuestType = HOTOMOTO.BUS.Enumerations.GuestType.Adult;
        for (int i = 1; i <= AdultCount + ChildCount; i++) {
            Row = new TableRow();
            if (i > AdultCount) {
                GuestType = HOTOMOTO.BUS.Enumerations.GuestType.Child;
            }
            
            if (i == AdultCount + 1) { ChildAge = FirstChildAge; } else { ChildAge = SecondChildAge; }

            Row.Cells.Add(GetTdDDLGuestNameTitle(RoomIndex, i.ToString(), GuestType, ChildAge));
            Row.Cells.Add(GetTdTxtGuestName(RoomIndex, i.ToString()));
            tbl.Rows.Add(Row);
            if (i != AdultCount + ChildCount) {
                tbl.Rows.Add(GetTrSeperator());
            }
        }

        return tbl;
    }

    private TableCell GetTdDDLGuestNameTitle(string RoomIndex, string ID, HOTOMOTO.BUS.Enumerations.GuestType GuestType, int ChildAge) {

        DropDownList ddlNameTitle = new DropDownList();
        ddlNameTitle.ID = "ddlNameTitle" + RoomIndex + "|" + ID.ToString();
        ddlNameTitle.Width = Unit.Pixel(80);
        ddlNameTitle.CssClass = "DropDownList";
        if (GuestType == HOTOMOTO.BUS.Enumerations.GuestType.Adult) {
            ddlNameTitle.Items.Add(new ListItem("Mr.", "Mr."));
            ddlNameTitle.Items.Add(new ListItem("Mrs.", "Mrs."));
        }
        else if (GuestType == HOTOMOTO.BUS.Enumerations.GuestType.Child) {
            ddlNameTitle.Items.Add(new ListItem("Ch. " + "(" + ChildAge.ToString() + ")", ChildAge.ToString()));
        }


        TableCell Cell = new TableCell();
        Cell.Width = Unit.Percentage(15);
        Cell.Controls.Add(ddlNameTitle);
        return Cell;

    }
    private TableCell GetTdTxtGuestName(string RoomIndex, string ID) {
        TextBox txtNameGuestName = new TextBox();
        txtNameGuestName.ID = "txtGuestName" + RoomIndex + "|" + ID.ToString();
        txtNameGuestName.Width = Unit.Percentage(96);
        txtNameGuestName.CssClass = "TextBox";

        TableCell Cell = new TableCell();
        Cell.Width = Unit.Percentage(85);
        Cell.Controls.Add(txtNameGuestName);

        return Cell;
    }
    private TableRow GetTrSeperator() {
        TableRow Row = new TableRow();
        
        TableCell Cell = new TableCell();
        Cell.ColumnSpan = 2;
        Literal ltlHr = new Literal();
        ltlHr.Text = "<hr noshade color='#FFFFFF' size='1'>";
        Cell.Controls.Add(ltlHr);

        Row.Cells.Add(Cell);

        return Row;
    }

    private Table GetTourCheckTable(string RoomIndex, int TourRowID, int RowCount, int GuestStartIndex) {
        Table tbl = new Table();
        tbl.CellPadding = 2;
        tbl.CellSpacing = 2;
        tbl.Width = Unit.Percentage(100);

        TableRow Row;
        TableCell Cell;
        DataTable dtGuest = ((DataTable)Session["Guest"]);
        DataTable dtTour = ((DataTable)Session["Tour"]);
        for (int i = 1; i <= RowCount; i++) {
            Row = new TableRow();
            Cell = new TableCell();

            if (((HOTOMOTO.BUS.Enumerations.TourTypes)Convert.ToInt16(dtTour.Rows[TourRowID - 1]["TourType"])) == HOTOMOTO.BUS.Enumerations.TourTypes.Excursion) {
                CheckBox chInside = new CheckBox();
                chInside.ID = "chInside" + RoomIndex + "|" + i.ToString() + "|" + TourRowID.ToString();
                chInside.Checked = Convert.ToBoolean(dtGuest.Rows[(GuestStartIndex + i) - 1]["T" + TourRowID.ToString()]);
                chInside.AutoPostBack = true;
                ////chInside.CheckedChanged += new EventHandler(chInside_CheckedChanged);  :(( 
                chInside.Text = "Dahil";  //RESX
                Cell.Controls.Add(chInside);
            }
            else {
                DropDownList ddlCheckTour = GetDDLGetBedPreferences(RoomIndex + "|" + i.ToString() + "|" + TourRowID.ToString(), RowCount, 60, "ShortBedType");
                ddlCheckTour.Items.Insert(0, new ListItem("-", "False"));
                if (IsPostBack) {
                    ddlCheckTour.SelectedIndex = 1;
                }
                Cell.Controls.Add(ddlCheckTour);
            }
            
            Row.Cells.Add(Cell);
            tbl.Rows.Add(Row);

            if (i != RowCount) {
                Row = new TableRow();
                Cell = new TableCell();
                Literal ltlHr = new Literal();
                ltlHr.Text = "<hr noshade color='#FFFFFF' size='1'>";
                Cell.Controls.Add(ltlHr);
                Cell.Height = Unit.Pixel(1);
                Row.Cells.Add(Cell);
                tbl.Rows.Add(Row);
            }
        }

        return tbl;

    }




    //TUR ÝÞLEMLER --------------------------------------------------------------------------------------------------------

    protected void LoadTours() {

        DataTable dt = HOTOMOTO.BUS.Tour.GetTours(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate, HOTOMOTO.BUS.Enumerations.TourTypes.Excursion, GetGuestCount());
        
        if (dt.Rows.Count > 0) {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlExcTours, dt, "Name", "TourID", "");
            ltlExcCurrLeft.Text = this.SessRoot.CurrencySymbolLeft.ToString();
            ltlExcCurrRight.Text = this.SessRoot.CurrencySymbolRight.ToString();
            ddlExcTours_SelectedIndexChanged(new object(), new EventArgs());
        }
        else {
            pnlExcTours.Visible = false;
        }

        dt = HOTOMOTO.BUS.Tour.GetTours(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate, HOTOMOTO.BUS.Enumerations.TourTypes.Circuits, GetGuestCount());

        if (dt.Rows.Count > 0) {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlCircTours, dt, "Name", "TourID", "");
            ltlCircCurrLeft.Text = this.SessRoot.CurrencySymbolLeft.ToString();
            ltlCircCurrRight.Text = this.SessRoot.CurrencySymbolRight.ToString();
            ddlCircTours_SelectedIndexChanged(new object(), new EventArgs());
        }
        else {
            pnlCircTours.Visible = false;
        }

    }

    protected void ddlExcTours_SelectedIndexChanged(object sender, EventArgs e) {

        int TourID = Convert.ToInt32(ddlExcTours.SelectedValue);
        DataTable dtTour = HOTOMOTO.BUS.Tour.GetTours(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate, HOTOMOTO.BUS.Enumerations.TourTypes.Excursion, GetGuestCount(), TourID.ToString());
        
        ltlExcPrice.Text = dtTour.Rows[0][this.SessRoot.CurrencyID.ToString() + "Price"].ToString();
        DateTime StartDate = Convert.ToDateTime(dtTour.Rows[0]["StartDate"]);
        DateTime EndDate = Convert.ToDateTime(dtTour.Rows[0]["EndDate"]);
        string HasDays = dtTour.Rows[0]["HasDays"].ToString();

        ltlExcMinCapacity.Text = dtTour.Rows[0]["MinCapacity"].ToString();

        HOTOMOTO.COM.Tour.GetExcDDLDate(ref ddlExcTourDates, StartDate, EndDate, HasDays, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate); 
    }
    protected void ddlCircTours_SelectedIndexChanged(object sender, EventArgs e) {

        int TourID = Convert.ToInt32(ddlCircTours.SelectedValue);
        DataTable dtTour = HOTOMOTO.BUS.Tour.GetTours(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate, HOTOMOTO.BUS.Enumerations.TourTypes.Circuits, GetGuestCount(), TourID.ToString());

        ltlCircPrice.Text = dtTour.Rows[0][this.SessRoot.CurrencyID.ToString() + "Price"].ToString();
        DateTime StartDate = Convert.ToDateTime(dtTour.Rows[0]["StartDate"]);
        DateTime EndDate = Convert.ToDateTime(dtTour.Rows[0]["EndDate"]);
        string HasDays = dtTour.Rows[0]["HasDays"].ToString();
        int StartDay = Convert.ToInt16(dtTour.Rows[0]["StartDay"]);

        ltlCircMinCapacity.Text = dtTour.Rows[0]["MinCapacity"].ToString();

        HOTOMOTO.COM.Tour.GetCircDDLDate(ref ddlCircTourDates, StartDate, EndDate, HasDays, StartDay, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate); 
    }

    protected void btnAddExcTour_Click(object sender, EventArgs e) {
        int TourID = Convert.ToInt32(ddlExcTours.SelectedValue);
        string TourName = ddlExcTours.SelectedItem.Text;        
        float TourPrice = float.Parse(ltlExcPrice.Text);            
        string TourDate = ddlExcTourDates.SelectedValue;
        int MinCapacity = int.Parse(ltlExcMinCapacity.Text);
        AddTour(TourID, HOTOMOTO.BUS.Enumerations.TourTypes.Excursion, TourName, 0, 0, TourPrice, TourDate, MinCapacity);
    }
    protected void btnAddCircTour_Click(object sender, EventArgs e) {
        int TourID = Convert.ToInt32(ddlCircTours.SelectedValue);
        string TourName = ddlCircTours.SelectedItem.Text;
        float TourPrice = float.Parse(ltlCircPrice.Text);
        string TourDate = ddlCircTourDates.SelectedValue;
        int MinCapacity = int.Parse(ltlCircMinCapacity.Text);
        AddTour(TourID, HOTOMOTO.BUS.Enumerations.TourTypes.Circuits, TourName, 0, 0, TourPrice, TourDate, MinCapacity);
    }

    private void lbRemove_Click(object sender, EventArgs e) {
        int TourRowID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
        RemoveTour(TourRowID);
    }




    //FÝYAT ÝÞLEMLERÝ -------------------------------------------------------------------------------------------------------

    private void UpdatePrices() {       //Sayfadaki Fiyatlarý Son Seçilen Deðerlere Update Et     
        float TotalPrice = 0;        
        for (int i = 1; i <= this.SessRoot.RoomsDetail.Rows.Count; i++) {
            int RoomID = int.Parse(((DropDownList)pnlRoomList.FindControl("ddlRoomTypes" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).SelectedValue);
            DataTable RoomAvgPrice = HOTOMOTO.BUS.Rooms.GetRoomPriceDetails(RoomID, this.SessRoot.CustomerID, Convert.ToInt16(this.SessRoot.RoomsDetail.Rows[i - 1]["AdultCount"]), Convert.ToInt16(this.SessRoot.RoomsDetail.Rows[i - 1]["ChildCount"]), Convert.ToInt16(this.SessRoot.RoomsDetail.Rows[i - 1]["FirstChildAge"]), Convert.ToInt16(this.SessRoot.RoomsDetail.Rows[i - 1]["SecondChildAge"]), this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate);
            string PricePP = "";
            string PriceTP = "";
            if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD) {
                PricePP = String.Format("{0:0.00}", float.Parse(RoomAvgPrice.Rows[0]["USDAvgPP"].ToString()));
                PriceTP = String.Format("{0:0.00}", float.Parse(RoomAvgPrice.Rows[0]["USDTotal"].ToString()));
                TotalPrice += float.Parse(RoomAvgPrice.Rows[0]["USDTotal"].ToString());
            }
            else if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR) {
                PricePP = String.Format("{0:0.00}", float.Parse(RoomAvgPrice.Rows[0]["EURAvgPP"].ToString()));
                PriceTP = String.Format("{0:0.00}", float.Parse(RoomAvgPrice.Rows[0]["EURTotal"].ToString()));
                TotalPrice += float.Parse(RoomAvgPrice.Rows[0]["EURTotal"].ToString());
            }

            ((Literal)pnlRoomList.FindControl("ltlPP" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).Text = PricePP.ToString();
            ((Literal)pnlRoomList.FindControl("ltlTP" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).Text = PriceTP.ToString();
        }

        
        if ((DataTable)(Session["Tour"]) != null) {
            DataTable dtTour = ((DataTable)(Session["Tour"]));
            DataTable dtGuest = ((DataTable)(Session["Guest"]));
            int ChildMaxAgeOfTour = Convert.ToInt16(ConfigurationManager.AppSettings["ChildMaxAgeOfTour"]);
            int ExcDiscountMaxAge = Convert.ToInt16(ConfigurationManager.AppSettings["ExcDiscountMaxAge"]);
            int ExcDiscountProportion = Convert.ToInt16(ConfigurationManager.AppSettings["ExcDiscountProportion"]);            

            foreach (DataRow dr in dtGuest.Rows) {
                for (int i = 1; i <= dtTour.Rows.Count; i++) {
                    if (dr["T" + i.ToString()].ToString() != "False") {
                        if ((!CARETTA.COM.Util.IsNumeric(dr["GuestNameTitle"].ToString())) || ((CARETTA.COM.Util.IsNumeric(dr["GuestNameTitle"].ToString())) && (Convert.ToInt16(dr["GuestNameTitle"]) >= ChildMaxAgeOfTour))) {
                            if ((Convert.ToInt16(dtTour.Rows[i - 1]["TourType"]) == (int)HOTOMOTO.BUS.Enumerations.TourTypes.Excursion) && ((CARETTA.COM.Util.IsNumeric(dr["GuestNameTitle"].ToString())) && Convert.ToInt16(dr["GuestNameTitle"]) <= ExcDiscountMaxAge)) {
                                TotalPrice += Convert.ToSingle((Convert.ToSingle(dtTour.Rows[i - 1]["TourPrice"]) / 2));
                            }
                            else {
                                TotalPrice += Convert.ToSingle(dtTour.Rows[i - 1]["TourPrice"]);
                            }                            
                        }                        
                    }//if  
                }//for   
            }//foreach 
        }

        lblTotalPriceCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        lblTotalPriceCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;
        lblTotalPrice.Text = String.Format("{0:0.00}", TotalPrice);
    }



    
    //TRANSFER ÝÞLEMLER ----------------------------------------------------------------------------------------------------

    protected void chTransfer_CheckedChanged(object sender, EventArgs e) {

        UctTransfer1.Visible = chTransfer.Checked;

    }



    //REZERVASYON YAP BUTTON CLICK ------------------------------------------------------------------------------------------

    protected void btnCheckOut_Click(object sender, EventArgs e) {

        bool Status = true;
        if ((chTransfer.Checked) && (!UctTransfer1.Validation())) {
            Status = false;
        }

        if (Status) {

            RoomSession();                          //Odalarý Sessiona al        

            PopulateGuests();                       //Ýsimler ve Eklenen Turlarýn Tablosunu Oluþtur     

            SessionViewState();                     //Sessiondaki bilgileri gir (Viewstate görevi gör)

            GuestSession();                         //Guestleri Sessiona al      

            if (CtrlTourMinCapacity()) {            //Turlara Atanan Kiþi Sayýsýnýn o turun MinCapacity sinden azmý kontrol et  
                
                UctTransfer1.SessionTransfer(chTransfer.Checked);         //Transfer Sessiona al      

                Response.Redirect("~/" + ConfigurationManager.AppSettings["SummaryPage"].ToString());
            }
        }
    }

    private bool CtrlTourMinCapacity() {

        DataTable dtGuest = ((DataTable)Session["Guest"]);

        if (Session["Tour"] != null) {

            DataTable dtTour = ((DataTable)Session["Tour"]);

            foreach (DataRow dr in dtGuest.Rows) {
                for (int i = 1; i <= 4; i++) {

                    if (dr["T" + i.ToString()].ToString().ToLower() != "false") {
                        if (!CARETTA.COM.Util.IsNumeric(dr["GuestNameTitle"].ToString()))
                        {
                            dtTour.Rows[i - 1]["AdultCount"] = Convert.ToInt32(dtTour.Rows[i - 1]["AdultCount"]) + 1;
                        }
                        else if (Convert.ToInt32(dr["GuestNameTitle"]) > 2)
                        {
                            dtTour.Rows[i - 1]["ChildCount"] = Convert.ToInt32(dtTour.Rows[i - 1]["ChildCount"]) + 1;
                        }

                    }
                }
            }

            string ErrorMsg = String.Empty;
            int CtrlGuestCount = 0;
            for (int i = 1; i <= dtTour.Rows.Count; i++) {

                CtrlGuestCount +=  Convert.ToInt32(dtTour.Rows[i - 1]["AdultCount"]) + Convert.ToInt32(dtTour.Rows[i - 1]["ChildCount"]);

                if (Convert.ToInt32(dtTour.Rows[i - 1]["TourMinCapacity"]) > CtrlGuestCount) {
                    ErrorMsg += i.ToString() + ". Tur Ýçin Minimum " + dtTour.Rows[0]["TourMinCapacity"].ToString() + " Kiþi Katýlmalýdýr<br>";
                    // Resxlerden hata mesajlarýný al 
                }
            }

            Session["Tour"] = dtTour;
            
            if (ErrorMsg != String.Empty) {
                ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.error2, "TURLARA KÝÞÝ ATAMA HATASI", ErrorMsg);
                return false;
            }

        }

        return true;

    }




    //SESSION ÝÞLEMLER --------------------------------------------------------------------------------------------------------

    private void AddTour(int TourID, HOTOMOTO.BUS.Enumerations.TourTypes TourTypeID, string TourName, int AdultCount, int ChildCount, float TourPrice, string TourDate, int MinCapacity) {

        DataTable dtTour;
        if (Session["Tour"] != null) {
            dtTour = ((DataTable)Session["Tour"]);
        }
        else {
            dtTour = InitializeTourDt();
        }

        bool Status = true;
        if (dtTour.Rows.Count > 3) {
            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.error, "TUR EKLEME HATASI", "En fazla 4 tur ekleyebilirsiniz");
            Status = false;
        }
        else {

            foreach (DataRow dr in dtTour.Rows) {
                if ((Convert.ToInt32(dr["TourID"]) == TourID) && (dr["TourDate"].ToString() == TourDate)) {
                    ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.error2, "TUR EKLEME HATASI", "Bu Tur Daha Önce Eklenmiþ");
                    Status = false;
                }
            }
        }

        if (Status) {
            DataRow drTour = dtTour.NewRow();

            drTour["RowID"] = dtTour.Rows.Count + 1;
            drTour["TourID"] = TourID;
            drTour["TourType"] = (int)TourTypeID;
            drTour["TourName"] = TourName;
            drTour["AdultCount"] = AdultCount;
            drTour["ChildCount"] = ChildCount;
            drTour["TourPrice"] = TourPrice;
            drTour["TourDate"] = TourDate;
            drTour["TourMinCapacity"] = MinCapacity;

            dtTour.Rows.Add(drTour);
            Session["Tour"] = dtTour;

            DataTable dtGuest = ((DataTable)Session["Guest"]);

            foreach (DataRow drGuest in dtGuest.Rows) {
                drGuest["T" + drTour["RowID"].ToString()] = true;
            }
        }
    }
    private void AddRoom(int RowID, int RoomID, int Capacity, string RoomName, int BedTypeID, string BedTypeName, float PricePerson, float RoomTotalPrice) {
        DataTable dtRoom;
        if (Session["Room"] != null) {
            dtRoom = ((DataTable)Session["Room"]);
        }
        else {
            dtRoom = InitializeRoomDt();
        }

        int DrIndex = -1;

        for (int i = 0; i < dtRoom.Rows.Count; i++) {
            if (dtRoom.Rows[i]["RowID"].ToString() == RowID.ToString()) {
                DrIndex = i;
                break;
            }
        }

        if (DrIndex == -1) {
            DataRow drRoom = dtRoom.NewRow();

            drRoom["RowID"] = RowID;
            drRoom["Capacity"] = Capacity;
            drRoom["RoomID"] = RoomID;
            drRoom["RoomName"] = RoomName;
            drRoom["BedTypeID"] = BedTypeID;
            drRoom["BedTypeName"] = BedTypeName;
            drRoom["PricePerson"] = PricePerson;
            drRoom["RoomTotalPrice"] = RoomTotalPrice;

            dtRoom.Rows.Add(drRoom);
        }
        else {
            dtRoom.Rows[DrIndex]["RowID"] = RowID;
            dtRoom.Rows[DrIndex]["Capacity"] = Capacity;
            dtRoom.Rows[DrIndex]["RoomID"] = RoomID;
            dtRoom.Rows[DrIndex]["RoomName"] = RoomName;
            dtRoom.Rows[DrIndex]["BedTypeID"] = BedTypeID;
            dtRoom.Rows[DrIndex]["BedTypeName"] = BedTypeName;
            dtRoom.Rows[DrIndex]["PricePerson"] = PricePerson;
            dtRoom.Rows[DrIndex]["RoomTotalPrice"] = RoomTotalPrice;            
        }

        Session["Room"] = dtRoom;
    }
    private void AddGuest(int RowID,int RoomRowID, string GuestNameTitle, string GuestName, string T1, string T2, string T3, string T4) {
        DataTable dtGuest;
        if (Session["Guest"] != null) {
            dtGuest = ((DataTable)Session["Guest"]);
        }
        else {
            dtGuest = InitializeGuestDt();
        }


        int DrIndex = -1;

        for (int i = 0; i < dtGuest.Rows.Count; i++) {
            if (dtGuest.Rows[i]["RowID"].ToString() == RowID.ToString()) {
                DrIndex = i;
                break;
            }
        }

        if (DrIndex == -1) {
            DataRow drGuest = dtGuest.NewRow();

            drGuest["RowID"] = RowID;
            drGuest["RoomRowID"] = RoomRowID;
            drGuest["GuestNameTitle"] = GuestNameTitle;
            drGuest["GuestName"] = GuestName;
            drGuest["T1"] = T1;
            drGuest["T2"] = T2;
            drGuest["T3"] = T3;
            drGuest["T4"] = T4;

            dtGuest.Rows.Add(drGuest);
        }
        else {
            dtGuest.Rows[DrIndex]["RowID"] = RowID;
            dtGuest.Rows[DrIndex]["RoomRowID"] = RoomRowID;
            dtGuest.Rows[DrIndex]["GuestNameTitle"] = GuestNameTitle;
            dtGuest.Rows[DrIndex]["GuestName"] = GuestName;
            dtGuest.Rows[DrIndex]["T1"] = T1;
            dtGuest.Rows[DrIndex]["T2"] = T2;
            dtGuest.Rows[DrIndex]["T3"] = T3;
            dtGuest.Rows[DrIndex]["T4"] = T4;
        }

        Session["Guest"] = dtGuest;

    }    
    
    private void RoomSession() {
        for (int i = 1; i <= this.SessRoot.RoomsDetail.Rows.Count; i++) {
            
            string RoomName = ((DropDownList)pnlRoomList.FindControl("ddlRoomTypes" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).SelectedItem.Text;
            int RoomID = int.Parse(((DropDownList)pnlRoomList.FindControl("ddlRoomTypes" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).SelectedValue);

            int Capacity = Convert.ToInt16(this.SessRoot.RoomsDetail.Rows[i - 1]["AdultCount"]) + Convert.ToInt16(this.SessRoot.RoomsDetail.Rows[i - 1]["ChildCount"]);

            string BedTypeName= ((DropDownList)pnlRoomList.FindControl("ddlBedPreferences" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).SelectedItem.Text;
            int BedTypeID = int.Parse(((DropDownList)pnlRoomList.FindControl("ddlBedPreferences" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).SelectedValue);

            float PricePerson = float.Parse(((Literal)pnlRoomList.FindControl("ltlPP" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).Text);
            float RoomTotalPrice = float.Parse(((Literal)pnlRoomList.FindControl("ltlTP" + this.SessRoot.RoomsDetail.Rows[i - 1]["RoomIndex"].ToString())).Text);
            
            AddRoom(i, RoomID, Capacity, RoomName, BedTypeID, BedTypeName, PricePerson, RoomTotalPrice);
        }
    }                  //Odalarý Sessiona al           

    private void GuestSession() {
        DataTable dtRoom = ((DataTable)Session["Room"]);
        DataTable dtGuest = new DataTable();
        string GuestNameTitle = string.Empty;
        string GuestName = string.Empty;

        ArrayList arrChInside = new ArrayList();
        for (int i = 0; i < 4; i++) {
            arrChInside.Add(false);            
        }
        
        int GuestRowID = 0;
        for (int i = 1; i <= dtRoom.Rows.Count; i++) {

            for (int j = 1; j <= int.Parse(dtRoom.Rows[i-1]["Capacity"].ToString()); j++) {
                GuestNameTitle = Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlNameTitle" + i.ToString() + "|" + j.ToString()];
                GuestName = Request.Form[this.ClientID.Replace("_", "$") + "$" + "txtGuestName" + i.ToString() + "|" + j.ToString()];

                if (Session["Tour"] != null) {
                    DataTable dtTour = ((DataTable)Session["Tour"]);
                    for (int x = 1; x <= dtTour.Rows.Count; x++) {
                        if (((HOTOMOTO.BUS.Enumerations.TourTypes)Convert.ToInt16(dtTour.Rows[x - 1]["TourType"])) == HOTOMOTO.BUS.Enumerations.TourTypes.Excursion) {
                            arrChInside[x - 1] = ((CheckBox)pnlGuestsAndTours.FindControl("chInside" + i.ToString() + "|" + j.ToString() + "|" + x.ToString())).Checked.ToString();
                        }
                        else {
                            arrChInside[x - 1] = ((DropDownList)pnlGuestsAndTours.FindControl("ddlBedPreferences" + i.ToString() + "|" + j.ToString() + "|" + x.ToString())).SelectedValue;
                        }
                    }
                }
                GuestRowID++;
                AddGuest(GuestRowID, Convert.ToInt16(dtRoom.Rows[i - 1]["RowID"]), GuestNameTitle, GuestName, arrChInside[0].ToString(), arrChInside[1].ToString(), arrChInside[2].ToString(), arrChInside[3].ToString());
            }

        }
    }                 //Guestleri Sessiona al         

    private void RemoveTour(int RowID) {
        DataTable dtTour = ((DataTable)Session["Tour"]);
        foreach (DataRow dr in dtTour.Rows) {
            if (Convert.ToInt16(dr["RowID"]) == RowID) {
                dtTour.Rows.Remove(dr);
                break;
            }
        }

        for (int i = 1; i <= dtTour.Rows.Count; i++) {
            dtTour.Rows[i - 1]["RowID"] = i.ToString();
        }

        Session["Tour"] = dtTour;


    }          //Tur Sil                        

    private void UpdateCheckTourSession() {
        DataTable dtRoom = ((DataTable)Session["Room"]);
        DataTable dtTour = null;
        if (Session["Tour"] != null) {
            dtTour = ((DataTable)Session["Tour"]);
        }
        string GuestNameTitle = string.Empty;
        string GuestName = string.Empty;
        string strClientID = "";
        int GuestRowID = 0;

        ArrayList arrChInside = new ArrayList();
        for (int i = 0; i < 4; i++) {
            arrChInside.Add(false);
        }

        for (int i = 1; i <= dtRoom.Rows.Count; i++) {
            for (int j = 1; j <= int.Parse(dtRoom.Rows[i - 1]["Capacity"].ToString()); j++) {                
                GuestNameTitle = Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlNameTitle" + i.ToString() + "|" + j.ToString()];
                GuestName = Request.Form[this.ClientID.Replace("_", "$") + "$" + "txtGuestName" + i.ToString() + "|" + j.ToString()];
                ////strClientID = this.ClientID.Replace("_", "$") + "$" + "chInside" + i.ToString() + "|" + j.ToString() + "|";                
                string InsideID = "";
                if (dtTour != null) {
                    for (int x = 1; x <= dtTour.Rows.Count; x++) {
                        if (((HOTOMOTO.BUS.Enumerations.TourTypes)Convert.ToInt16((dtTour.Rows[x - 1]["TourType"]))) == HOTOMOTO.BUS.Enumerations.TourTypes.Excursion) {
                            InsideID = "chInside";
                        }
                        else {
                            InsideID = "ddlBedPreferences";
                        }
                        strClientID = this.UniqueID + "$" + InsideID + i.ToString() + "|" + j.ToString() + "|";
                        if ((Request.Form[strClientID + x.ToString()] != null) && (Request.Form[strClientID + x.ToString()] != "")) {
                            if (((HOTOMOTO.BUS.Enumerations.TourTypes)Convert.ToInt16((dtTour.Rows[x - 1]["TourType"]))) == HOTOMOTO.BUS.Enumerations.TourTypes.Excursion) {
                                arrChInside[x - 1] = "True";
                            }
                            else {
                                arrChInside[x - 1] = Request.Form[strClientID + x.ToString()];
                            }
                        }
                        else {
                            arrChInside[x - 1] = "False";
                        }
                    }
                }

                GuestRowID++;
                AddGuest(GuestRowID, Convert.ToInt16(dtRoom.Rows[i - 1]["RowID"]), GuestNameTitle, GuestName, arrChInside[0].ToString(), arrChInside[1].ToString(), arrChInside[2].ToString(), arrChInside[3].ToString());
            }
        }
    }       //CheckBoxlarý Kontrol et Son durumu Guest Sessiona Update Et 

    private void SessionViewState() {

        if ((Session["Guest"] != null) && (Session["Room"] != null)) { // if null Control

            DataTable dtRoom = ((DataTable)Session["Room"]);
            DataTable dtGuest = ((DataTable)Session["Guest"]);
            DataTable dtTour = new DataTable();
            int TourCount = 0;
            if (Session["Tour"] != null) {
                dtTour = ((DataTable)Session["Tour"]);
                TourCount = dtTour.Rows.Count;
            }

            int GuestIndex = 0;
            string CheckID = String.Empty;
            for (int i = 1; i <= dtRoom.Rows.Count; i++) { //for Room

                for (int j = 1; j <= int.Parse(dtRoom.Rows[i - 1]["Capacity"].ToString()); j++) { //for Capacity      
                    ((DropDownList)pnlGuestsAndTours.FindControl("ddlNameTitle" + i.ToString() + "|" + j.ToString())).SelectedValue = dtGuest.Rows[GuestIndex]["GuestNameTitle"].ToString();
                    ((TextBox)pnlGuestsAndTours.FindControl("txtGuestName" + i.ToString() + "|" + j.ToString())).Text = dtGuest.Rows[GuestIndex]["GuestName"].ToString();

                    for (int x = 1; x <= TourCount; x++) {
                        if (((HOTOMOTO.BUS.Enumerations.TourTypes)Convert.ToInt16(dtTour.Rows[x - 1]["TourType"])) == HOTOMOTO.BUS.Enumerations.TourTypes.Excursion) {
                            CheckID = "chInside" + dtRoom.Rows[i - 1]["RowID"].ToString() + "|" + j.ToString() + "|" + x.ToString();
                            ((CheckBox)pnlGuestsAndTours.FindControl(CheckID)).Checked = Convert.ToBoolean(dtGuest.Rows[GuestIndex]["T" + x.ToString()].ToString());
                        }
                        else {
                            CheckID = "ddlBedPreferences" + dtRoom.Rows[i - 1]["RowID"].ToString() + "|" + j.ToString() + "|" + x.ToString();
                            ((DropDownList)pnlGuestsAndTours.FindControl(CheckID)).SelectedValue = dtGuest.Rows[GuestIndex]["T" + x.ToString()].ToString();
                        }
                    }
                    GuestIndex++;

                }//for Capacity      

            }//for Room

        }// if null Control

    }             //Viewstate gibi seçilen bilgileri seçili hale getir          




    //INITALIZE SESSION DATATABLE -------------------------------------------------------------------------------------------

    private DataTable InitializeRoomDt() {
        DataTable dtRoom = new DataTable();
        dtRoom.Columns.Add(new DataColumn("RowID"));        
        dtRoom.Columns.Add(new DataColumn("RoomID"));
        dtRoom.Columns.Add(new DataColumn("Capacity"));
        dtRoom.Columns.Add(new DataColumn("RoomName"));
        dtRoom.Columns.Add(new DataColumn("BedTypeID"));
        dtRoom.Columns.Add(new DataColumn("BedTypeName"));
        dtRoom.Columns.Add(new DataColumn("PricePerson"));
        dtRoom.Columns.Add(new DataColumn("RoomTotalPrice"));
        return dtRoom;
    }        //Room Session için DataTable ýn Yapýsýný Oluþtur  
    private DataTable InitializeTourDt() {
        DataTable dtTour = new DataTable();
        dtTour.Columns.Add(new DataColumn("RowID"));
        dtTour.Columns.Add(new DataColumn("TourID"));
        dtTour.Columns.Add(new DataColumn("TourType"));
        dtTour.Columns.Add(new DataColumn("TourName"));
        dtTour.Columns.Add(new DataColumn("AdultCount"));
        dtTour.Columns.Add(new DataColumn("ChildCount"));
        dtTour.Columns.Add(new DataColumn("TourPrice"));
        dtTour.Columns.Add(new DataColumn("TourDate"));
        dtTour.Columns.Add(new DataColumn("TourMinCapacity"));
        return dtTour;
    }        //Tur Session için DataTable ýn Yapýsýný Oluþtur  
    private DataTable InitializeGuestDt() {
        DataTable dtGuest = new DataTable();
        dtGuest.Columns.Add(new DataColumn("RowID"));
        dtGuest.Columns.Add(new DataColumn("RoomRowID"));
        dtGuest.Columns.Add(new DataColumn("GuestNameTitle"));
        dtGuest.Columns.Add(new DataColumn("GuestName"));
        dtGuest.Columns.Add(new DataColumn("T1"));
        dtGuest.Columns.Add(new DataColumn("T2"));
        dtGuest.Columns.Add(new DataColumn("T3"));
        dtGuest.Columns.Add(new DataColumn("T4"));
        return dtGuest;
    }       //Guest Session için DataTable ýn Yapýsýný Oluþtur  




    //PAGE PRE_RENDER ------------------------------------------------------------------------------------------------------

    protected void Page_PreRender(object sender, EventArgs e) {
        
        UpdatePrices();             //Toplam Fiyatý Güncelle                            

        RoomSession();              //Odalarý Sessiona al                               

        if ((Request.Form[btnCheckOut.UniqueID]==null) || (Request.Form[btnCheckOut.UniqueID]=="")) {

            PopulateGuests();           //Ýsimler ve Eklenen Turlarýn Tablosunu Oluþtur  

            SessionViewState();         //Sessiondaki bilgileri gir (Viewstate görevi gör)
            
            GuestSession();             //Guestleri Sessiona al                             

        }

        //SessionViewState();         //Sessiondaki bilgileri gir (Viewstate görevi gör)  
    }

}
