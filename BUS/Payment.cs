using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Payment {

        #region :: REZERVASYON BÝLGÝLERÝNÝ LOAD PROPERTIES ::

        private int m_ReservationID;
        private int m_CustomerID;
        private int m_UserID;
        private int m_ReservationType;
        private string m_Description;
        private DateTime m_BookingDate;
        private int m_BookingStateID;
        private float m_TotalPriceEUR;
        private float m_TotalPriceUSD;
        private float m_TotalPriceYTL;
        private float m_TaxYTL;
        private float m_TaxRatio;
        private float m_DiscountRatio;
        private string m_CampaignCode;
        private int m_PaymentType;
        private bool m_isActive;

        public int ReservationID {
            get { return m_ReservationID; }
            set { m_ReservationID = value; }
        }
        public int CustomerID {
            get { return m_CustomerID; }
            set { m_CustomerID = value; }
        }
        public int UserID {
            get { return m_UserID; }
            set { m_UserID = value; }
        }
        public int ReservationType {
            get { return m_ReservationType; }
            set { m_ReservationType = value; }
        }
        public string Description {
            get { return m_Description; }
            set { m_Description = value; }
        }
        public DateTime BookingDate {
            get { return m_BookingDate; }
            set { m_BookingDate = value; }
        }
        public int BookingStateID {
            get { return m_BookingStateID; }
            set { m_BookingStateID = value; }
        }
        public float TotalPriceEUR {
            get { return m_TotalPriceEUR ; }
            set { m_TotalPriceEUR = value; }
        }
        public float TotalPriceUSD {
            get { return m_TotalPriceUSD; }
            set { m_TotalPriceUSD = value; }
        }
        public float TotalPriceYTL {
            get { return m_TotalPriceYTL; }
            set { m_TotalPriceYTL = value; }
        }
        public float TaxYTL {
            get { return m_TaxYTL; }
            set { m_TaxYTL = value; }
        }
        public float TaxRatio {
            get { return m_TaxRatio; }
            set { m_TaxRatio = value; }
        }
        public float DiscountRatio {
            get { return m_DiscountRatio; }
            set { m_DiscountRatio = value; }
        }
        public string CampaignCode {
            get { return m_CampaignCode; }
            set { m_CampaignCode = value; }
        }
        public int PaymentType {
            get { return m_PaymentType; }
            set { m_PaymentType = value; }
        }
        public bool isActive {
            get { return m_isActive; }
            set { m_isActive = value; }
        }

        #endregion

        #region :: KREDÝ KARTI BÝLGÝLERÝNÝ LOAD PROPERTIES ::

        private int m_CC_CustomerCreditCardID;
        private int m_CC_CustomerID;
        private string m_CC_Description;
        private string m_CC_CreditCardNO;
        private string m_CC_ExpireDateMonth;
        private string m_CC_ExpireDateYear;
        private string m_CC_CVV;
        private DateTime m_CC_ModifyDate;
        private int m_CC_ModifiedBy;
        private bool m_CC_isActive;

        public int CC_CustomerCreditCardID {
            get { return m_CC_CustomerCreditCardID; }
            set { m_CC_CustomerCreditCardID = value; }
        }
        public int CC_CustomerID {
            get { return m_CC_CustomerID; }
            set { m_CC_CustomerID = value; }
        }	
        public string CC_Description {
            get { return m_CC_Description; }
            set { m_CC_Description = value; }
        }	
        public string CC_CreditCardNO {
            get { return m_CC_CreditCardNO; }
            set { m_CC_CreditCardNO = value; }
        }
        public string CC_ExpireDateMonth {
            get { return m_CC_ExpireDateMonth; }
            set { m_CC_ExpireDateMonth = value; }
        }
        public string CC_ExpireDateYear {
            get { return m_CC_ExpireDateYear; }
            set { m_CC_ExpireDateYear = value; }
        }
        public string CC_CVV {
            get { return m_CC_CVV; }
            set { m_CC_CVV = value; }
        }
        public DateTime CC_ModifyDate {
            get { return m_CC_ModifyDate; }
            set { m_CC_ModifyDate = value; }
        }
        public int CC_ModifiedBy {
            get { return m_CC_ModifiedBy; }
            set { m_CC_ModifiedBy = value; }
        }
        public bool CC_isActive {
            get { return m_CC_isActive; }
            set { m_CC_isActive = value; }
        }
        
        #endregion

        #region :: LOADS ::

        // Kayýtlý Kredi Kartýnýn Bilgilerini Getir ID ye göre
        public void LoadSavedCreditCards(int CustomerCreditCardID) {
            try {
                APEX.CustomerCreditCards objCus = new HOTOMOTO.APEX.CustomerCreditCards();
                objCus.Load(CustomerCreditCardID);
                this.m_CC_CreditCardNO = objCus.CreditCardNO;
                this.m_CC_CustomerID = objCus.CustomerID;
                this.m_CC_CVV = objCus.CVV;
                this.m_CC_Description = objCus.Description;
                this.m_CC_ExpireDateMonth = objCus.ExpireDateMonth;
                this.m_CC_ExpireDateYear = objCus.ExpireDateYear;
                this.m_CC_isActive = objCus.isActive;
                this.m_CC_ModifiedBy = objCus.ModifiedBy;
                this.m_CC_ModifyDate = objCus.ModifyDate;
            }
            catch (Exception) {
                throw;
            }
        }

        //Rezervasyon Bilgisini Getir  
        public void Load(int ReservationID) {
            APEX.Reservations objRes;
            try {
                objRes = new HOTOMOTO.APEX.Reservations();
                objRes.Load(ReservationID);
                this.m_ReservationID = objRes.ReservationID;
                this.m_CustomerID = objRes.CustomerID;
                this.m_UserID = objRes.UserID;
                this.m_ReservationType = (int)objRes.ReservationType;
                this.m_Description = objRes.Description;
                this.m_BookingDate = objRes.BookingDate;
                this.m_BookingDate = objRes.BookingDate;
                this.m_BookingStateID = objRes.BookingStateID;
                this.m_TotalPriceEUR = (float)objRes.TotalPriceEUR;
                this.m_TotalPriceUSD = (float)objRes.TotalPriceUSD;
                this.m_TotalPriceYTL = (float)objRes.TotalPriceYTL;
                this.m_TaxYTL = (float)objRes.TaxYTL;
                this.m_TaxRatio = (float)objRes.TaxRatio;
                this.m_DiscountRatio = (float)objRes.DiscountRatio;
                this.m_CampaignCode = objRes.CampaignCode;
                this.m_PaymentType = objRes.PaymentType;
                this.m_isActive = objRes.isActive;
            }
            catch (Exception) {
                throw;
            }
        }

        #endregion

        // Müþterinin Kredibilitesini Getir 
        public static DataTable GetCredibilityByCustomerID(int CustomerID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Payment.GetCredibilityByCustomerID(CustomerID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        // Rezervasyonu Aktifleþtir 
        public bool ActivateReservation(int ReservationID, float NewTotalPriceYTL, Enumerations.BookingStates BookingState, Enumerations.PaymentTypes PaymentType) {
            try {
                APEX.Reservations objRes = new HOTOMOTO.APEX.Reservations();
                objRes.Load(ReservationID);
                objRes.TotalPriceYTL = NewTotalPriceYTL;
                objRes.BookingStateID = (int)BookingState;
                objRes.PaymentType = (int)PaymentType;
                objRes.isActive = true;
                objRes.Save();
                return true;
            }
            catch (Exception) {
                throw;
            }
        }

        // Kullanýcýný Kredisini Güncelle 
        public static bool UpdateCrediLimit(int CustomerID, float NewCredibility) {
            try {
                APEX.Custom.SPExec_Payment.UpdateCrediLimit(CustomerID, NewCredibility);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        // Tüm Döviz Kurlarýný Getir 
        public static DataTable GetAllCurrencies() {
            DataTable dt;
            try {
                dt = APEX.Currencies.GetAllCurrenciesDataSet().Tables[0];
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        // Müþterinin kurunu getir 
        public static float GetCurr(HOTOMOTO.BUS.Enumerations.CurrencyTypes CurrencyID, int CurrUSDIndex)
        {
            DataTable dtCurr = HOTOMOTO.BUS.Payment.GetAllCurrencies();
            if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD)
            {
                return Convert.ToSingle(dtCurr.Rows[CurrUSDIndex]["Value"]);
            }
            else if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR) {
                return Convert.ToSingle(dtCurr.Rows[CurrUSDIndex + 1]["Value"]);
            }
            return 0;
        }

        public static decimal EURtoYTL(float Price, int CurrUSDIndex)
        {
            return Math.Round((decimal)(Price * GetCurr(HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR, CurrUSDIndex)), 2);
        }

        public static decimal USDtoYTL(float Price, int CurrUSDIndex)
        {
            return Math.Round((decimal)(Price * GetCurr(HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD, CurrUSDIndex)), 2);
        }

        public static decimal EURtoUSD(float Price, int CurrUSDIndex)
        {
            return Math.Round((decimal)(((float)(EURtoYTL(Price, CurrUSDIndex))) * GetCurr(HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD, CurrUSDIndex)), 2);
        }

        public static decimal USDtoEUR(float Price, int CurrUSDIndex)
        {
            return Math.Round((decimal)(((float)(USDtoYTL(Price, CurrUSDIndex))) * GetCurr(HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR, CurrUSDIndex)), 2);
        }

        // Ödeme Tiplerini Ödeme Sayfasý Ýçin Getir 
        public static DataTable GetPaymentTypesForPaymentPage(int LanguageID)
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Payment.GetPaymentTypesForPaymentPage(LanguageID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        // Ödeme Tiplerini Getir 
        public static DataTable GetPaymentTypes(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.PaymentTypes.GetAllPaymentTypesDataSet(LanguageID).Tables[0];
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        // Kayýtlý Kredi Kartlarý Getir 
        public static DataTable GetSavedCreditCards(int CustomerID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Payment.GetSavedCreditCards(CustomerID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        // Kredi Kartý Daha Önce Kaydedilmiþ mi? 
        private int ExistCreditCard(string CardNO) {
            int Ctrl = 0;
            try {
                Ctrl = APEX.Custom.SPExec_Payment.ExistCreditCard(CardNO);
            }
            catch (Exception) {
                throw;
            }
            return Ctrl;
        }

        // Müþterinin Kredi Kartýný Kaydet   
        public void AddCreditCard(int CustomerID, string Description, string CardNO, string ExpireDateMonth, string ExpireDateYear, string CVV, int ModifiedBy) {
            try {
                APEX.CustomerCreditCards objCred = new HOTOMOTO.APEX.CustomerCreditCards();

                int CtrlCardID = ExistCreditCard(CardNO);
                if (CtrlCardID > 0) {
                    objCred.Load(CtrlCardID);
                }

                objCred.CustomerID = CustomerID;
                objCred.Description = Description;
                objCred.CreditCardNO = CardNO;
                objCred.ExpireDateMonth = ExpireDateMonth.PadLeft(2, '0');
                objCred.ExpireDateYear = ExpireDateYear.PadLeft(2, '0');
                objCred.CVV = CVV;
                objCred.ModifyDate = DateTime.Now;
                objCred.ModifiedBy = ModifiedBy;
                objCred.isActive = true;
                objCred.Save();
            }
            catch (Exception) {                
                throw;
            }
        }

        // WebPos Transactions u Kaydet      
        public void AddWebPostTransaction(float Amount, int CustomerID, string OrderCode, string ReservationCode, int ReservationID, string ReturnValue, string ReturnValueDescription, HOTOMOTO.BUS.Enumerations.PosStatus Status, int UserID) {
            try {
                APEX.WebPosTransactions objWebPos = new HOTOMOTO.APEX.WebPosTransactions();
                objWebPos.Amount = Amount;
                objWebPos.CustomerID = CustomerID;
                objWebPos.OrderCode = OrderCode;
                objWebPos.ReservationCode = ReservationCode;
                objWebPos.ReservationID = ReservationID;
                objWebPos.ReturnValue = ReturnValue;
                objWebPos.ReturnValueDescription = ReturnValueDescription;
                objWebPos.Status = (int)Status;
                objWebPos.TransactionDate = DateTime.Now;
                objWebPos.UserID = UserID;
                objWebPos.Save();
            }
            catch (Exception) {
                throw;
            }
        }

        // KREDÝ KARTI WEBPOS ÝÞLEMLERÝ  
        public Enumerations.PosStatus PaymentProcess(
            string HostIP, string OwnIP, string Port, string Mid, string Tid,
            float Amount, string CardNO, string ExpDate, string CVV, string OrderCode, 
            ref string ReturnValue, ref string ReturnValueDescription) {

            string YKBAmount = Convert.ToString(Amount * 100).Replace('.', ',');

            Enumerations.PosStatus Status = HOTOMOTO.BUS.Enumerations.PosStatus.ConnFailure;
            //YKBPosnetActiveX.YKBPosnetClass objYKB = new YKBPosnetActiveX.YKBPosnetClass();

            //objYKB.SetHostIP(HostIP);
            //objYKB.SetOwnIP(OwnIP);
            //objYKB.SetPort(Port);
            //objYKB.SetMid(Mid);
            //objYKB.SetTid(Tid);

            //string strResp = objYKB.DoSaleTran(CardNO, ExpDate, CVV, OrderCode, YKBAmount, "YT", "00", "00", "000000");
            //if (CARETTA.COM.Util.Left(strResp, 3) == Enumerations.PosStatus.YKBConnSuccess.ToString()) {

            //    ReturnValue = objYKB.GetResponseCode;
            //    ReturnValueDescription = objYKB.GetResponseText;

            //    switch (objYKB.GetApprovedCode)
            //    {

            //        case "1":
            //            Status = Enumerations.PosStatus.Approved; 
            //            break;

            //        case "0":
            //            Status = Enumerations.PosStatus.Rejected;
            //            break;

            //        case "2":   
            //            Status = Enumerations.PosStatus.Used; break;
            //    }

            //}

            return Status;

        }

    }
}
