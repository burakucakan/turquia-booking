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

public partial class UserControls_Transfer_uctTransfer : BaseUserControl {

    private int m_MaxPerson = 20;

    public int MaxPerson {
        get { return m_MaxPerson; }
        set { m_MaxPerson = value; }
    }
	

    public bool TransferPage{
        get { return btnTransfer.Visible; }
        set { btnTransfer.Visible = value; }
    }	

    public bool ArrivalSabihaGokcen {
        get { return (ViewState["ArrivalSabihaGokcen"] == null ? false : bool.Parse(ViewState["ArrivalSabihaGokcen"].ToString())); }
        set { ViewState["ArrivalSabihaGokcen"] = value; }
    }

    public bool DepartureSabihaGokcen {
        get { return (ViewState["DepartureSabihaGokcen"] == null ? false : bool.Parse(ViewState["DepartureSabihaGokcen"].ToString())); }
        set { ViewState["DepartureSabihaGokcen"] = value; }
    }

    public float OriginalArrivalRegularPrice {
        get { return (ViewState["OriginalArrivalRegularPrice"] == null ? -1 : float.Parse(ViewState["OriginalArrivalRegularPrice"].ToString())); }
        set { ViewState["OriginalArrivalRegularPrice"] = value; }
    }

    public float OriginalArrivalPrivatePrice {
        get { return (ViewState["OriginalArrivalPrivatePrice"] == null ? -1 : float.Parse(ViewState["OriginalArrivalPrivatePrice"].ToString())); }
        set { ViewState["OriginalArrivalPrivatePrice"] = value; }
    }
	
    public float OriginalDepartureRegularPrice {
        get { return (ViewState["OriginalDepartureRegularPrice"] == null ? -1 : float.Parse(ViewState["OriginalDepartureRegularPrice"].ToString())); }
        set { ViewState["OriginalDepartureRegularPrice"] = value; }
    }

    public float OriginalDeparturePrivatePrice {
        get { return (ViewState["OriginalDeparturePrivatePrice"] == null ? -1 : float.Parse(ViewState["OriginalDeparturePrivatePrice"].ToString())); }
        set { ViewState["OriginalDeparturePrivatePrice"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            if (!FillPorts()) {
                this.Visible = false;
            }
            else {
                SetDefaultValue();              //Döviz Prefixleri ve Tarihleri Yaz 

                LoadTransfer(m_MaxPerson);     //Transfer Bilgilerini Çek Deðerleri Ekrana Yaz 

                Session.Remove("Transfer");
            }
        }
    }

    private void LoadTransfer(int MaxPerson) {
        DataTable dtTransfer = HOTOMOTO.BUS.Transfer.GetTransferPrices(this.SessRoot.CustomerID, MaxPerson);

        ltlGuidePrice.Text = dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Guidance"].ToString();

        lblArrivalRegularPrice.Text = dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Regular"].ToString();
        lblArrivalPrivatePrice.Text = dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Private"].ToString();
    
        OriginalArrivalRegularPrice = float.Parse(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Regular"].ToString());
        OriginalArrivalPrivatePrice = float.Parse(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Private"].ToString());

        lblDepartureRegularPrice.Text = dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Regular"].ToString();
        lblDeparturePrivatePrice.Text = dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Private"].ToString();

        OriginalDepartureRegularPrice = float.Parse(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Regular"].ToString());
        OriginalDeparturePrivatePrice = float.Parse(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Private"].ToString());
    }

    private void SetDefaultValue() {
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlTransferArrivalGuestCount, m_MaxPerson, 1, 1);
        ddlTransferArrivalGuestCount.SelectedValue = m_MaxPerson.ToString();
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlTransferDepartureGuestCount, m_MaxPerson, 1, 1);
        ddlTransferDepartureGuestCount.SelectedValue = m_MaxPerson.ToString();

        ltlGuideCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        ltlGuideCurrencyRight.Text = this.SessRoot.CurrencySymbolLeft;

        ltlArrivalRegularCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        ltlArrivalRegularCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        ltlArrivalPrivateCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        ltlArrivalPrivateCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        ltlDepartureRegularCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        ltlDepartureRegularCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        ltlDeparturePrivateCurrencyLeft.Text = this.SessRoot.CurrencySymbolLeft;
        ltlDeparturePrivateCurrencyRight.Text = this.SessRoot.CurrencySymbolRight;

        txtArrivalDate.Text = this.SessRoot.ArrivalDate.ToShortDateString();
        txtDepartureDate.Text = this.SessRoot.DepartureDate.ToShortDateString();
    }
 
    private bool FillPorts() {
        DataTable dtPorts = HOTOMOTO.BUS.Transfer.GetPortsByCountry(this.SessRoot.LanguageID, this.SessRoot.SearchCountryID);
        if (dtPorts.Rows.Count > 0) {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlArrivalPorts, dtPorts, "Title", "PortID", "");
            CARETTA.COM.DDLHelper.BindDDL(ref ddlDeparturePorts, dtPorts, "Title", "PortID", "");
            return true;
        }
        else {
            return false;
        }

    }



    //ARRIVAL ÝÞLEMLER -------------------------------------------------------------------------------------------------

    protected void chArrival_CheckedChanged(object sender, EventArgs e) {
        pnlArrival.Enabled = chArrival.Checked;
    }

    protected void ddlArrivalPorts_SelectedIndexChanged(object sender, EventArgs e) {
        int SabihaGokcenPortID = Convert.ToInt16(ConfigurationManager.AppSettings["SabihaGokcenPortID"]);

        if (int.Parse(ddlArrivalPorts.SelectedValue) == SabihaGokcenPortID) {
            lblArrivalPrivatePrice.Text = (float.Parse(lblArrivalPrivatePrice.Text) + (OriginalArrivalPrivatePrice)).ToString();
            lblArrivalRegularPrice.Text = (float.Parse(lblArrivalRegularPrice.Text) + (OriginalArrivalRegularPrice)).ToString();
            ArrivalSabihaGokcen = true;
        }
        else if (ArrivalSabihaGokcen) {
            lblArrivalPrivatePrice.Text = (float.Parse(lblArrivalPrivatePrice.Text) - (OriginalArrivalPrivatePrice)).ToString();
            lblArrivalRegularPrice.Text = (float.Parse(lblArrivalRegularPrice.Text) - (OriginalArrivalRegularPrice)).ToString();
            ArrivalSabihaGokcen = false;
        }
    }

    protected void chGuide_CheckedChanged(object sender, EventArgs e) {
        float RegularPrice = float.Parse(lblArrivalRegularPrice.Text);
        float PrivatePrice = float.Parse(lblArrivalPrivatePrice.Text);

        if (chGuide.Checked) {
            RegularPrice += float.Parse(ltlGuidePrice.Text);
            PrivatePrice += float.Parse(ltlGuidePrice.Text);
        }
        else {
            RegularPrice -= float.Parse(ltlGuidePrice.Text);
            PrivatePrice -= float.Parse(ltlGuidePrice.Text);
        }

        lblArrivalRegularPrice.Text = RegularPrice.ToString();
        lblArrivalPrivatePrice.Text = PrivatePrice.ToString();
    }

    protected void ddlTransferArrivalGuestCount_SelectedIndexChanged(object sender, EventArgs e) {      
        DataTable dtTransfer = HOTOMOTO.BUS.Transfer.GetTransferPrices(this.SessRoot.CustomerID, int.Parse(ddlTransferArrivalGuestCount.SelectedValue));

        OriginalArrivalRegularPrice = Convert.ToSingle(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Regular"]);
        OriginalArrivalPrivatePrice = Convert.ToSingle(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Private"]);

        float RegularPrice = 0;
        float PrivatePrice = 0;

        RegularPrice += OriginalArrivalRegularPrice;
        PrivatePrice += OriginalArrivalPrivatePrice;

        if (ArrivalSabihaGokcen) {
            RegularPrice += OriginalArrivalRegularPrice;
            PrivatePrice += OriginalArrivalPrivatePrice;
        }

        if (chGuide.Checked) {
            RegularPrice += float.Parse(ltlGuidePrice.Text);
            PrivatePrice += float.Parse(ltlGuidePrice.Text);
        }

        lblArrivalRegularPrice.Text = RegularPrice.ToString();
        lblArrivalPrivatePrice.Text = PrivatePrice.ToString();
    }


    //SESSION ÝÞLEMLER ----------------------------------------------------------------------------------------------------

    private DataTable InitializeTransferDt() {
        DataTable dtTransfer = new DataTable();
        dtTransfer.Columns.AddRange(new DataColumn[] { 
                                new DataColumn("TransferDirection"), new DataColumn("TransferType"), new DataColumn("GuestCount"), 
                                new DataColumn("GuidancePrice"), new DataColumn("Price"), new DataColumn("PortID"), 
                                new DataColumn("PortName"), new DataColumn("Notes"), new DataColumn("Date") });
        return dtTransfer;        
    }

    private void AddTransfer(HOTOMOTO.BUS.Enumerations.TransferDirections TransferDirection,
                             HOTOMOTO.BUS.Enumerations.TransferTypes TransferType, int GuestCount, float GuidancePrice, 
                             float Price, int PortID, string PortName, string Notes, DateTime Date) {

        DataTable dtTransfer;
        if (Session["Transfer"] != null) { dtTransfer = ((DataTable)Session["Transfer"]); }
        else { dtTransfer = InitializeTransferDt(); }

        DataRow drTransfer = dtTransfer.NewRow();

        drTransfer["TransferDirection"] = (int)TransferDirection;
        drTransfer["TransferType"] = (int)TransferType;
        drTransfer["GuestCount"] = GuestCount;
        drTransfer["GuidancePrice"] = GuidancePrice;
        drTransfer["Price"] = Price;
        drTransfer["PortID"] = PortID;
        drTransfer["PortName"] = PortName;
        drTransfer["Notes"] = Notes;
        drTransfer["Date"] = Date;

        dtTransfer.Rows.Add(drTransfer);
        Session["Transfer"] = dtTransfer;

    }


    public void SessionTransfer(bool Transfer) {
        if (Transfer) {
            HOTOMOTO.BUS.Enumerations.TransferTypes TransferType;
            float Price = 0;
            DateTime TransferDate;

            if (chArrival.Checked) {

                float GuidancePrice = 0;

                if (rdArrivalRegular.Checked) {
                    TransferType = HOTOMOTO.BUS.Enumerations.TransferTypes.Regular;
                    Price = float.Parse(lblArrivalRegularPrice.Text);

                }
                else {
                    TransferType = HOTOMOTO.BUS.Enumerations.TransferTypes.Private;
                    Price = float.Parse(lblArrivalPrivatePrice.Text);
                }

                if (chGuide.Checked) {
                    GuidancePrice = float.Parse(ltlGuidePrice.Text);
                }

                TransferDate = Convert.ToDateTime(txtArrivalDate.Text);
                TransferDate = TransferDate.AddHours(UctDDLTimeArrival.Hour);
                TransferDate = TransferDate.AddMinutes(UctDDLTimeArrival.Minute);

                int GuestCount = int.Parse(ddlTransferArrivalGuestCount.SelectedValue);

                AddTransfer(HOTOMOTO.BUS.Enumerations.TransferDirections.Arrival, TransferType, GuestCount,
                            GuidancePrice, Price, int.Parse(ddlArrivalPorts.SelectedValue),
                            ddlArrivalPorts.SelectedItem.Text, txtArrivalDetail.Text, TransferDate);
            }

            if (chDeparture.Checked) {
                if (rdDepartureRegular.Checked) {
                    TransferType = HOTOMOTO.BUS.Enumerations.TransferTypes.Regular;
                    Price = float.Parse(lblDepartureRegularPrice.Text);

                }
                else {
                    TransferType = HOTOMOTO.BUS.Enumerations.TransferTypes.Private;
                    Price = float.Parse(lblDeparturePrivatePrice.Text);
                }

                TransferDate = Convert.ToDateTime(txtDepartureDate.Text);
                TransferDate = TransferDate.AddHours(UctDDLTimeDeparture.Hour);
                TransferDate = TransferDate.AddMinutes(UctDDLTimeDeparture.Minute);

                int GuestCount = int.Parse(ddlTransferDepartureGuestCount.SelectedValue);

                AddTransfer(HOTOMOTO.BUS.Enumerations.TransferDirections.Departure, TransferType, GuestCount, 0, Price, 
                            int.Parse(ddlDeparturePorts.SelectedValue), ddlDeparturePorts.SelectedItem.Text, 
                            txtDepartureDetail.Text, TransferDate);
            }
        }
    }


    //DEPARTURE ÝÞLEMLER -------------------------------------------------------------------------------------------------

    protected void chDeparture_CheckedChanged(object sender, EventArgs e) {
        pnlDeparture.Enabled = chDeparture.Checked;
    }

    protected void ddlDeparturePorts_SelectedIndexChanged(object sender, EventArgs e) {
        int SabihaGokcenPortID = Convert.ToInt16(ConfigurationManager.AppSettings["SabihaGokcenPortID"]);

        if (int.Parse(ddlDeparturePorts.SelectedValue) == SabihaGokcenPortID) {
            lblDeparturePrivatePrice.Text = (float.Parse(lblDeparturePrivatePrice.Text) + (OriginalArrivalPrivatePrice)).ToString();
            lblDepartureRegularPrice.Text = (float.Parse(lblDepartureRegularPrice.Text) + (OriginalArrivalRegularPrice)).ToString();
            DepartureSabihaGokcen = true;
        }
        else if (DepartureSabihaGokcen) {
            lblDeparturePrivatePrice.Text = (float.Parse(lblDeparturePrivatePrice.Text) - (OriginalArrivalPrivatePrice)).ToString();
            lblDepartureRegularPrice.Text = (float.Parse(lblDepartureRegularPrice.Text) - (OriginalArrivalRegularPrice)).ToString();
            DepartureSabihaGokcen = false;
        }
    }

    protected void ddlTransferDepartureGuestCount_SelectedIndexChanged(object sender, EventArgs e) {
        DataTable dtTransfer = HOTOMOTO.BUS.Transfer.GetTransferPrices(this.SessRoot.CustomerID, int.Parse(ddlTransferDepartureGuestCount.SelectedValue));

        OriginalDepartureRegularPrice = Convert.ToSingle(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Regular"]);
        OriginalDeparturePrivatePrice = Convert.ToSingle(dtTransfer.Rows[0][this.SessRoot.CurrencyID.ToString() + "Private"]);

        float RegularPrice = 0;
        float PrivatePrice = 0;

        RegularPrice += OriginalDepartureRegularPrice;
        PrivatePrice += OriginalDeparturePrivatePrice;

        if (DepartureSabihaGokcen) {
            RegularPrice += OriginalDepartureRegularPrice;
            PrivatePrice += OriginalDeparturePrivatePrice;
        }

        lblDepartureRegularPrice.Text = RegularPrice.ToString();
        lblDeparturePrivatePrice.Text = PrivatePrice.ToString();
    }

    protected void btnTransfer_Click(object sender, EventArgs e) {
        if (Validation()) {
            SessionTransfer(true);
            Response.Redirect("~/" + ConfigurationManager.AppSettings["SummaryPage"].ToString());
        }
    
    }

    public bool Validation() {
        string ErrorMessage = String.Empty;
        DateTime TransferDate =     new DateTime();
        if (chArrival.Checked) {
            try { TransferDate = DateTime.Parse(txtArrivalDate.Text); }
            catch (Exception) { ErrorMessage += "<br><br>Lütfen Transfer Gidiþ Tarihini Doðru Giriniz<br>"; }
        }

        if (chDeparture.Checked) {
            try { TransferDate = DateTime.Parse(txtDepartureDate.Text); }
            catch (Exception) { ErrorMessage += "<br>Lütfen Transfer Geliþ Tarihini Doðru Giriniz<br>"; }
        }

        if (ErrorMessage != string.Empty) {
            ModalPopupTransfer.Show(UserControls_ModalPopup_ModalPopup.Icons.error, "TRANSFER HATASI", ErrorMessage);
            return false;
        }
        else {
            return true;
        }

    }

}