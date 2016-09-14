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

public partial class UserControls_Common_uctPayment : BaseUserControl {

    public float TotalPrice {
        get {
            return (ViewState["m_TotalPrice"] == null ? -1 : float.Parse(ViewState["m_TotalPrice"].ToString()));
        }
        set {
            ViewState["m_TotalPrice"] = value;
        }
    }
    public float Credibility {
        get {
            return (ViewState["m_Credibility"] == null ? -1 : float.Parse(ViewState["m_Credibility"].ToString()));
        }
        set {
            ViewState["m_Credibility"] = value;
        }
    }

    public bool isCheckCredibility
    {
        get { return (ViewState["isCheck"] == null ? false : bool.Parse(ViewState["isCheck"].ToString())); }
        set { ViewState["isCheck"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e) {

        ReservationInfo();          // Rezervasyon Bilgisini Getir Yaz 

        if (!IsPostBack) {

            GetCustomerCredibility();   // Müþterinin Kredibilitesini Çek 

            Payment();                  // Kredibiliteyi kontrol et yetiyorsa kullan yetmiyorsa ödeme panelini aç 

        }
    }

    void RemoveSessions()
    {
        Session.Remove("Room");
        Session.Remove("Tour");
        Session.Remove("Transfer");
        Session.Remove("Guest");
        Session.Remove("Reservations");
    }

    private void ReservationInfo() {
        HOTOMOTO.BUS.Payment objPay = new HOTOMOTO.BUS.Payment();

        if (
            (Session["ReservationID"] != null) && 
            (CARETTA.COM.Util.IsNumeric(Session["ReservationID"].ToString())) && 
            (Session["ReservationCode"] != null) &&
            ((CARETTA.COM.Util.ClearString(Session["ReservationCode"].ToString())).Length == Convert.ToInt32(ConfigurationManager.AppSettings["ReservationCodeLength"]))
            ) 
        {
            RemoveSessions();
            objPay.Load(Convert.ToInt32(Session["ReservationID"]));
        } else {
            Response.Redirect("Default.aspx");
        }

        if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR) {
            this.TotalPrice = objPay.TotalPriceEUR; // ********** //
        } else if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD) {
            this.TotalPrice = objPay.TotalPriceUSD;
        }

        if (Session["ResTotalPrice"] != null) {
            this.TotalPrice -= float.Parse(Session["ResTotalPrice"].ToString());
        }
    }

    private void GetCustomerCredibility() {
        DataTable dtCredibility = HOTOMOTO.BUS.Payment.GetCredibilityByCustomerID(this.SessRoot.CustomerID);
        if (dtCredibility.Rows.Count < 1) {
            this.Credibility = 0;
        }
        else {
            this.Credibility = Convert.ToSingle(dtCredibility.Rows[0]["CreditLimit"]);
        }
    }

    private void Payment() {

        // Ödeme Tiplerini Getir   
        DataTable dtPaymentTypes = HOTOMOTO.BUS.Payment.GetPaymentTypesForPaymentPage(this.SessRoot.LanguageID);
        CARETTA.COM.DDLHelper.BindDDL(ref ddlPaymentTypes, dtPaymentTypes, "PaymentType", "PaymentTypeID", "0", ConfigurationManager.AppSettings["InitialText"].ToString(), "0");

        if (this.Credibility < this.TotalPrice)
        {
            string DBCredibilityID = ConfigurationManager.AppSettings["DBCredibilityID"].ToString();
            for (int i = 0; i < ddlPaymentTypes.Items.Count; i++)
            {
                if (ddlPaymentTypes.Items[i].Value == DBCredibilityID)
                {
                    ddlPaymentTypes.Items.RemoveAt(i);
                }
            }
        }
        else {
            SelectCredibility(); // Kredilibiliteyi seç 
        }

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

    protected void ddlPaymentTypes_SelectedIndexChanged(object sender, EventArgs e) {

        if (int.Parse(ddlPaymentTypes.SelectedValue) == (int)HOTOMOTO.BUS.Enumerations.PaymentTypes.Credibility)
        {
            SelectCredibility();
        }
        else if (int.Parse(ddlPaymentTypes.SelectedValue) == (int)HOTOMOTO.BUS.Enumerations.PaymentTypes.MoneyOrder)
        {
            pnlMoneyOrder.Visible = true;
            pnlCreditCard.Visible = false;

            // Rezervasyon Tutarýný Yaz 
            MoneyOrderltlResCurrLeft.Text = this.SessRoot.CurrencySymbolLeft.ToString();
            MoneyOrderltlResCurrRight.Text = this.SessRoot.CurrencySymbolRight.ToString();
            MoneyOrderlblReservationPrice.Text = CARETTA.COM.Util.FormatPriceToString(this.TotalPrice);
            btnCheckOut.Visible = true;

        }
        else if (int.Parse(ddlPaymentTypes.SelectedValue) == (int)HOTOMOTO.BUS.Enumerations.PaymentTypes.CreditCard)
        {
            pnlCreditCard.Visible = true;
            pnlMoneyOrder.Visible = false;

            // Rezervasyon Tutarýný Yaz 
            CreditCardltlResCurrLeft.Text = this.SessRoot.CurrencySymbolLeft.ToString();
            CreditCardltlResCurrRight.Text = this.SessRoot.CurrencySymbolRight.ToString();
            CreditCardlblReservationPrice.Text = CARETTA.COM.Util.FormatPriceToString(this.TotalPrice);

            DataTable dtSavedCreditCards = HOTOMOTO.BUS.Payment.GetSavedCreditCards(this.SessRoot.CustomerID);
            if (dtSavedCreditCards.Rows.Count < 1)
            {
                ddlSavedCreditCards.Visible = false;
                ltlNoSavedCreditCard.Visible = true;
            }
            else
            {
                CARETTA.COM.DDLHelper.BindDDL(ref ddlSavedCreditCards, dtSavedCreditCards, "Description", "CustomerCreditCardID", "");
            }

            CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlExpireDateMonth, 12, 1, 1, true);
            CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlExpireDateYear, DateTime.Now.Year + 9, 1, 7, true);

            btnCheckOut.Visible = true;
        }
        else
        {
            pnlCreditCard.Visible = false;
            pnlMoneyOrder.Visible = false;
            btnCheckOut.Visible = false;
        }

    }

    private void SelectCredibility()
    {
        // Rezervasyon Tutarýný Yaz 
        ltlResCurrLeft.Text = this.SessRoot.CurrencySymbolLeft.ToString();
        ltlResCurrRight.Text = this.SessRoot.CurrencySymbolRight.ToString();
        lblReservationPrice.Text = CARETTA.COM.Util.FormatPriceToString(this.TotalPrice);

        // Yeni Limiti Yaz 
        ltlCreditLeft.Text = this.SessRoot.CurrencySymbolLeft.ToString();
        ltlCreditRight.Text = this.SessRoot.CurrencySymbolRight.ToString();
        lblCreditLimit.Text = CARETTA.COM.Util.FormatPriceToString(this.Credibility - this.TotalPrice);

        pnlCredibilities.Visible = true;
        pnlPayment.Visible = false;
        tblPaymentTypes.Visible = false;
        btnCheckOut.Visible = true;
    }
    protected void btnCheckOut_Click(object sender, EventArgs e) {

        HOTOMOTO.BUS.Payment objPay = new HOTOMOTO.BUS.Payment();

        float NewTotalPriceYTL = GetCurr() * this.TotalPrice;

        if ((pnlCredibilities.Visible) || (pnlMoneyOrder.Visible)) {

            if (pnlMoneyOrder.Visible)
            {
                if (objPay.ActivateReservation((Convert.ToInt32(Session["ReservationID"])), NewTotalPriceYTL, HOTOMOTO.BUS.Enumerations.BookingStates.Pending, HOTOMOTO.BUS.Enumerations.PaymentTypes.MoneyOrder))
                {
                    Response.Redirect("ReservationFinish.aspx");
                }
            }
            else if (pnlCredibilities.Visible)
            {
                if (!isCheckCredibility)
                {
                    this.Credibility -= this.TotalPrice;

                    if (HOTOMOTO.BUS.Payment.UpdateCrediLimit(this.SessRoot.CustomerID, this.Credibility))
                    {
                        objPay = new HOTOMOTO.BUS.Payment();
                        if (objPay.ActivateReservation((Convert.ToInt32(Session["ReservationID"])), NewTotalPriceYTL, HOTOMOTO.BUS.Enumerations.BookingStates.Unpaid, HOTOMOTO.BUS.Enumerations.PaymentTypes.Credibility))
                        {
                            isCheckCredibility = true;
                            Response.Redirect("ReservationFinish.aspx");
                        }
                    }
                }
            }
        }
        else {
            if (pnlCreditCard.Visible) {

                // Kredi Kartý Ýþlemlerini Yap 
                int ReservationID = Convert.ToInt32(Session["ReservationID"]);
                string OrderCode = HOTOMOTO.COM.Payment.CreateOrderCode(Convert.ToInt32(Session["ReservationID"]), Session["ReservationCode"].ToString(), this.SessRoot.UserID);
                string ReservationCode = Session["ReservationCode"].ToString();
                string CreditCardNo = CARETTA.COM.Encryption.Encrypt(txtCreditCardNo.Text, ConfigurationManager.AppSettings["EncryptionKey"].ToString());
                string ExpireDateMonth = ddlExpireDateMonth.SelectedValue;
                string ExpireDateYear = ddlExpireDateYear.SelectedValue;
                string CVV = txtCVV.Text;

                string HostIP = ConfigurationManager.AppSettings["HostIP"].ToString();
                string OwnIP = ConfigurationManager.AppSettings["OwnIP"].ToString();
                string Port = ConfigurationManager.AppSettings["Port"].ToString();
                string Mid = ConfigurationManager.AppSettings["Mid"].ToString();
                string Tid = ConfigurationManager.AppSettings["Tid"].ToString();

                string ReturnValue = String.Empty;
                string ReturnValueDescription = String.Empty;

                objPay = new HOTOMOTO.BUS.Payment();
                HOTOMOTO.BUS.Enumerations.PosStatus Status = 
                    objPay.PaymentProcess(HostIP, OwnIP, Port, Mid, Tid, this.TotalPrice, CreditCardNo,
                    ExpireDateMonth + ExpireDateYear, CVV, OrderCode, ref ReturnValue, ref ReturnValueDescription);

                // Transactionu Kaydet         
                objPay = new HOTOMOTO.BUS.Payment();
                objPay.AddWebPostTransaction(this.TotalPrice, this.SessRoot.CustomerID,
                    OrderCode, ReservationCode, ReservationID, ReturnValue, 
                    ReturnValueDescription, Status, this.SessRoot.UserID);

                // KREDÝ KARTI BAÐLANTI KURULMADIYSA    
                if (Status.ToString() == HOTOMOTO.BUS.Enumerations.PosStatus.ConnFailure.ToString()) { pnlNoConn.Visible = true; }

                // KREDÝ KARTI KABUL EDÝLMEDÝ ÝSE 
                else if (Status == HOTOMOTO.BUS.Enumerations.PosStatus.Rejected) { pnlNoApprovedCard.Visible = true; } 
                
                // ÝÞLEM BAÞARILI ÝSE 
                else if ((Status == HOTOMOTO.BUS.Enumerations.PosStatus.Approved) || (Status == HOTOMOTO.BUS.Enumerations.PosStatus.Used))
                {

                    if (objPay.ActivateReservation((Convert.ToInt32(Session["ReservationID"])), NewTotalPriceYTL, HOTOMOTO.BUS.Enumerations.BookingStates.PaymentReceived, HOTOMOTO.BUS.Enumerations.PaymentTypes.CreditCard))
                    {

                        if (chAcceptSaveCardNO.Checked)
                        {
                            objPay = new HOTOMOTO.BUS.Payment();
                            objPay.AddCreditCard(this.SessRoot.CustomerID, txtCardDescription.Text, CreditCardNo, ExpireDateMonth, ExpireDateYear, CVV, this.SessRoot.UserID);
                        }
                        Response.Redirect("ReservationFinish.aspx");
                    }
                }

            }
        }

    }
    protected void ddlSavedCreditCards_SelectedIndexChanged(object sender, EventArgs e) {
        int CustomerCreditCardID = int.Parse(ddlSavedCreditCards.SelectedValue);

        HOTOMOTO.BUS.Payment objPay = new HOTOMOTO.BUS.Payment();
        objPay.LoadSavedCreditCards(CustomerCreditCardID);

        // kredi kartý bilgilerini form elementlerine doldur 
        txtCreditCardNo.Text = CARETTA.COM.Encryption.Decrypt(objPay.CC_CreditCardNO, ConfigurationManager.AppSettings["BUSE"]);
        txtCVV.Text = objPay.CC_CVV;
        ddlExpireDateMonth.SelectedValue = objPay.CC_ExpireDateMonth;
        ddlExpireDateYear.SelectedValue = objPay.CC_ExpireDateYear;
        txtCardDescription.Text = objPay.CC_Description;
    }
}