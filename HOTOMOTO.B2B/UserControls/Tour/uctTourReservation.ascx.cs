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

public partial class UserControls_Tour_uctTourReservation : BaseUserControl {

    private int MinCapacity = 1000; // Kapasite önemsiz olduðu için Maximum Rakam  
    private int TourID = 0;

    public HOTOMOTO.BUS.Enumerations.TourTypes TourType {
        get {
            return (ViewState["TourType"] == null ? HOTOMOTO.BUS.Enumerations.TourTypes.Excursion : ((HOTOMOTO.BUS.Enumerations.TourTypes)((int)ViewState["TourType"])));
        }
        set {
            ViewState["TourType"] = value;
        }
    }

    public int vMinCapacity
    {
        get { return (ViewState["MinCapacity"] == null ? -1 : int.Parse(ViewState["MinCapacity"].ToString())); }
        set { ViewState["MinCapacity"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            QueryStringControl();   // Query String den gelen deðerleri local deðiþkenler at 

            WriteTourInfo();        // Tur Bilgilerini Yaz  

        }
    }

    private void QueryStringControl() {
        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["TourType"])) {
            this.TourType = (HOTOMOTO.BUS.Enumerations.TourTypes)(int.Parse(Request.QueryString["TourType"]));
        }
        else {
            Response.Redirect("Default.aspx");
        }

        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["TourID"])) {
            this.TourID = int.Parse(Request.QueryString["TourID"]);
        }
        else {
            Response.Redirect("Default.aspx");
        }
    }

    private void WriteTourInfo() {

        ltlTourName.Text = this.SessRoot.CurrentTourName;        
        ltlTourID.Text = this.TourID.ToString();

        DataTable dtTour = GetTour(this.TourID);
        
        ltlArrivalDate.Text = Convert.ToDateTime(dtTour.Rows[0]["StartDate"]).ToShortDateString();
        ltlDepartureDate.Text = Convert.ToDateTime(dtTour.Rows[0]["EndDate"]).ToShortDateString();

        ltlMinCapacity.Text = dtTour.Rows[0]["MinCapacity"].ToString();
        this.vMinCapacity = Convert.ToInt32(dtTour.Rows[0]["MinCapacity"]);

        if (this.TourType == HOTOMOTO.BUS.Enumerations.TourTypes.Excursion) {
            HOTOMOTO.COM.Tour.GetExcDDLDate(ref ddlDates, Convert.ToDateTime(ltlArrivalDate.Text), Convert.ToDateTime(ltlDepartureDate.Text), dtTour.Rows[0]["HasDays"].ToString(), this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate);
        }
        else if (this.TourType == HOTOMOTO.BUS.Enumerations.TourTypes.Circuits) {
            HOTOMOTO.COM.Tour.GetCircDDLDate(ref ddlDates, Convert.ToDateTime(ltlArrivalDate.Text), Convert.ToDateTime(ltlDepartureDate.Text), dtTour.Rows[0]["HasDays"].ToString(), Convert.ToInt32(dtTour.Rows[0]["StartDay"]), this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate);
        }        

        ltlDesc.Text = dtTour.Rows[0]["Description"].ToString();

        ltlChildCountMinAge.Text = ConfigurationManager.AppSettings["ChildMaxAgeOfTour"];
        ltlChildCountMaxAge.Text = ConfigurationManager.AppSettings["ExcDiscountMaxAge"];

        lblTotalPriceCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        lblTotalPriceCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        lblAdultPPCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        lblAdultPPCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        lblAdultTotalPriceCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        lblAdultTotalPriceCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        lblChildPPCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        lblChildPPCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        lblChildTotalPriceCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        lblChildTotalPriceCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        lblAdultPP.Text = CARETTA.COM.Util.FormatPrice(dtTour.Rows[0][this.SessRoot.CurrencyID.ToString() + "Price"]).ToString();
        lblChildPP.Text = Convert.ToString(float.Parse(CARETTA.COM.Util.FormatPrice(dtTour.Rows[0][this.SessRoot.CurrencyID.ToString() + "Price"]).ToString()) * 0.5);        
    }

    private void UpdatePrices() {

        if ((CARETTA.COM.Util.IsNumeric(txtAdultCount.Text)) && (CARETTA.COM.Util.IsNumeric(txtChildCount.Text))) {
            int AdultCount = int.Parse(txtAdultCount.Text);
            int ChildCount = int.Parse(txtChildCount.Text);
            float AdultPrice = float.Parse(lblAdultPP.Text);
            float ChildPrice = float.Parse(lblChildPP.Text);

            lblAdultTotalPrice.Text = Convert.ToString(AdultCount * AdultPrice);
            lblChildTotalPrice.Text = Convert.ToString(ChildCount * ChildPrice);

            lblTotalPrice.Text = Convert.ToString(float.Parse(lblAdultTotalPrice.Text) + float.Parse(lblChildTotalPrice.Text));
        }
    }

    private DataTable GetTour(int TourID) {
        DataTable dt = HOTOMOTO.BUS.Tour.GetTours(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate, this.TourType, MinCapacity, TourID.ToString());
        if (dt.Rows.Count > 0) {
            return dt;
        }
        else {
            Response.Redirect("Default.aspx");
            return null;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e) {
        UpdatePrices();
    }

    //REZERVASYON YAP BUTTON CLICK ------------------------------------------------------------------------------------------
    protected void btnCheckOut_Click(object sender, EventArgs e) {

        UpdatePrices();

        int TourID = int.Parse(ltlTourID.Text);

        DataTable dtTour = GetTour(TourID);

        int AdultCount = 0;
        int ChildCount = 0;

        if (txtAdultCount.Text.Trim() != String.Empty) {
            AdultCount = int.Parse(txtAdultCount.Text.Trim());
        }

        if (txtChildCount.Text.Trim() != String.Empty) {
            ChildCount = int.Parse(txtChildCount.Text.Trim());
        }

        if (vMinCapacity > (AdultCount + ChildCount))
        {
            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.error, "TUR EKLEME HATASI", "Seçtiðiniz tur en az " + this.vMinCapacity.ToString() + " kiþi katýlmalýdýr.");
        }
        else
        {

            AddTour(TourID, this.TourType, ltlTourName.Text, AdultCount, ChildCount, float.Parse(lblAdultPP.Text), ddlDates.SelectedValue,
                int.Parse(ltlMinCapacity.Text));

            Response.Redirect("~/" + ConfigurationManager.AppSettings["SummaryPage"].ToString());
        }
    }

    private void AddTour(int TourID, HOTOMOTO.BUS.Enumerations.TourTypes TourTypeID, string TourName, int AdultCount, int ChildCount, float TourPrice, string TourDate, int MinCapacity) {

        DataTable dtTour;
        if (Session["Tour"] != null) {
            dtTour = ((DataTable)Session["Tour"]);
        }
        else {
            dtTour = InitializeTourDt();
        }

        DataRow drTour = dtTour.NewRow();

        drTour["RowID"] = 1;
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
    }

    //Tur Session için DataTable ýn Yapýsýný Oluþtur  
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
    }

    protected void txtAdultCount_Unload(object sender, EventArgs e) {
        UpdatePrices();
    }
    protected void txtChildCount_Unload(object sender, EventArgs e) {
        UpdatePrices();
    }
}
