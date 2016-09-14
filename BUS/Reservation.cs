using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.BUS {
    public class Reservation {

        // Müþterinin Rezervasyonlarýný Getir 
        public static DataTable GetReservationByCustomerID(int LanguageID, int CustomerID, string UserID, string ReservationType) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Reservation.GetReservationByCustomerID(LanguageID, CustomerID, UserID, ReservationType);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        // Transfer Rezervasyonlarýný Getir 
        public static DataTable GetTransferReservation(int LanguageID, int ReservationID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Reservation.GetTransferReservation(LanguageID, ReservationID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }
 
        // Tour Rezervasyonlarýný Getir 
        public static DataTable GetTourReservation(int LanguageID, int ReservationID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Reservation.GetTourReservation(LanguageID, ReservationID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }
 
        // Room Rezervasyonlarýný Getir 
        public static DataTable GetReservationRooms(int LanguageID, int ReservationID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Reservation.GetReservationRooms(LanguageID, ReservationID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        // Rezervasyondaki Kiþileri Getir 
        public static DataTable GetReservationGuests(int ReservationID)
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Reservation.GetReservationGuests(ReservationID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public int Save(HOTOMOTO.BUS.Enumerations.BookingStates BookingStateID, string CampaignCode,
                        int CustomerID, string Description, bool isActive, 
                        Enumerations.PaymentTypes PaymentType, string ReservationCode, 
                        double TaxRatio, int UserID, 
                        BUS.Enumerations.CurrencyTypes CurrencyID, int CurrUSDIndex, 
                        HOTOMOTO.BUS.Enumerations.NewRequestable ReservationStatus, float ReservationTotalPrice,
                        DataTable dtRoom, DataTable dtGuests, DataTable dtTour, DataTable dtTransfer, 
                        DataTable dtTourReservations_Guests, int ActiveReservationID) {

            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlTransaction Tran;
            conn.Open();
            Tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            int rReservationID = 0;
            int rReservationType = 0;
            int RoomReservationIDforGuest = 0;
            int TourReservationIDforTourGuest = 0;
            int GuestIDforTourReservationGuest = 0;

            DataTable dtNewTourReservations_Guests = new DataTable();
            dtNewTourReservations_Guests.Columns.AddRange(new DataColumn[]{ new DataColumn("TourReservationID"), new DataColumn("RoomBedPreferenceID"), new DataColumn("GuestID")});

            DataTable dtSavedGuest = new DataTable();
            dtSavedGuest.Columns.AddRange(new DataColumn[] { new DataColumn("GuestID"), new DataColumn("RowID") });

            HOTOMOTO.APEX.Reservations objRes;
            HOTOMOTO.APEX.RoomReservations objRoomRes;
            HOTOMOTO.APEX.Guests objGuest;
            HOTOMOTO.APEX.TourReservations objTour;
            HOTOMOTO.APEX.TransferReservations objTres;
            HOTOMOTO.APEX.TourReservations_Guests objTresGuest;

            try
            {

                // Rezervasyonu Kaydet  
                objRes = new HOTOMOTO.APEX.Reservations();

                //if (ActiveReservationID > 0) {
                //    if (DeleteReservationDetails(ActiveReservationID)) {
                //        objRes.Load(ActiveReservationID);
                //        rReservationID = ActiveReservationID;
                //    }
                //}

                if (ReservationCode != String.Empty) {
                    objRes.ReservationCode = ReservationCode;
                }

                objRes.BookingDate = DateTime.Now;
                objRes.BookingStateID = (int)BookingStateID;
                objRes.CampaignCode = CampaignCode;
                objRes.CustomerID = CustomerID;
                objRes.Description = Description;
                objRes.DiscountRatio = 0;
                objRes.isActive = isActive;
                objRes.PaymentType = (int)PaymentType;
                objRes.ReservationStatus = (int)ReservationStatus;
                objRes.TaxRatio = TaxRatio;
                objRes.TaxYTL = 0;
                objRes.UserID = UserID;

                if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD)
                {
                    objRes.TotalPriceUSD = ReservationTotalPrice;
                    objRes.TotalPriceEUR = Convert.ToDouble(Payment.USDtoEUR(ReservationTotalPrice, CurrUSDIndex));
                    objRes.TotalPriceYTL = Convert.ToDouble(Payment.USDtoYTL(ReservationTotalPrice, CurrUSDIndex));
                }
                else if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR)
                {
                    objRes.TotalPriceEUR = ReservationTotalPrice;
                    objRes.TotalPriceUSD = Convert.ToDouble(Payment.EURtoUSD(ReservationTotalPrice, CurrUSDIndex));
                    objRes.TotalPriceYTL = Convert.ToDouble(Payment.EURtoYTL(ReservationTotalPrice, CurrUSDIndex));
                }

                objRes.ReservationType = 0;

                if (rReservationID > 0) {
                    objRes.Save(Tran);
                }
                else {
                    rReservationID = objRes.Save(Tran);
                }




                if (dtRoom != null)
                {
                    rReservationType += (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Hotel;
                    foreach (DataRow dr in  dtRoom.Rows)
                    {
                        objRoomRes = new HOTOMOTO.APEX.RoomReservations();

                        objRoomRes.BedTypeID = Convert.ToInt32(dr["BedTypeID"]);
                        objRoomRes.BookingDate = DateTime.Now;
                        objRoomRes.CustomerID = CustomerID;
                        objRoomRes.HotelID = Convert.ToInt32(dr["HotelID"]);

                        float PricePerson = Convert.ToSingle(dr["PricePerson"]);
                        float RoomTotalPrice = Convert.ToSingle(dr["RoomTotalPrice"]);

                        if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD)
                        {
                            objRoomRes.PerGuestPriceUSD = PricePerson;
                            objRoomRes.PerGuestPriceEUR = Convert.ToDouble(Payment.USDtoEUR(PricePerson, CurrUSDIndex));

                            objRoomRes.TotalPriceUSD = RoomTotalPrice;
                            objRoomRes.TotalPriceEUR = Convert.ToDouble(Payment.USDtoEUR(RoomTotalPrice, CurrUSDIndex));
                        }
                        else if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR)
                        {
                            objRoomRes.PerGuestPriceEUR = PricePerson;
                            objRoomRes.PerGuestPriceUSD = Convert.ToDouble(Payment.EURtoUSD(PricePerson, CurrUSDIndex));

                            objRoomRes.TotalPriceEUR = RoomTotalPrice;
                            objRoomRes.TotalPriceUSD = Convert.ToDouble(Payment.EURtoUSD(RoomTotalPrice, CurrUSDIndex));
                        }

                        objRoomRes.ReservationEndDate = Convert.ToDateTime(dr["DepartureDate"]);
                        objRoomRes.ReservationStartDate = Convert.ToDateTime(dr["ArrivalDate"]);
                        objRoomRes.ReservationID = rReservationID;
                        objRoomRes.RoomID = Convert.ToInt32(dr["RoomID"]);
                        RoomReservationIDforGuest = objRoomRes.Save(Tran);

                        if (dtGuests != null)
                        {
                            foreach (DataRow drGuest in dtGuests.Rows)
                            {
                                if (Convert.ToInt32(drGuest["RoomIndex"]) == Convert.ToInt32(dr["RowID"])) {
                                    objGuest = new HOTOMOTO.APEX.Guests();

                                    objGuest.CreateDate = DateTime.Now;
                                    objGuest.EmailAddress = String.Empty;
                                    objGuest.GuestNameTitle = drGuest["GuestNameTitle"].ToString();
                                    objGuest.GuestName = drGuest["GuestName"].ToString();
                                    objGuest.ReservationID = rReservationID;
                                    objGuest.RoomReservationID = RoomReservationIDforGuest;
                                    GuestIDforTourReservationGuest = objGuest.Save(Tran);

                                    DataRow drSavedGuest = dtSavedGuest.NewRow();
                                    drSavedGuest["GuestID"] = GuestIDforTourReservationGuest;
                                    drSavedGuest["RowID"] = drGuest["RowID"];
                                    dtSavedGuest.Rows.Add(drSavedGuest);
                                }
                            }
                        }

                    }
                }

                if (dtTour != null)
                {
                    rReservationType += (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Tour;
                    foreach (DataRow dr in dtTour.Rows)
                    {
                        objTour = new HOTOMOTO.APEX.TourReservations();

                        objTour.hasAccomodation = ((dtTour.Columns["hasAccomodation"] == null) ? false : Convert.ToBoolean(dr["hasAccomodation"]));
                        objTour.AccomodationPrice = ((dtTour.Columns["AccomodationPrice"] == null) ? 0 : Convert.ToInt32(dr["AccomodationPrice"]));

                        objTour.hasFlight = ((dtTour.Columns["hasFlight"] == null) ? false : Convert.ToBoolean(dr["hasFlight"]));
                        objTour.FlightPrice = ((dtTour.Columns["FlightPrice"] == null) ? 0 : Convert.ToInt32(dr["FlightPrice"]));

                        objTour.BookingDate = DateTime.Now;
                        objTour.CustomerID = CustomerID;

                        float TourPrice = Convert.ToSingle(dr["TourPrice"]);
                        float TourAdultCount = Convert.ToInt32(dr["AdultCount"]);
                        float TourChildCount = Convert.ToInt32(dr["ChildCount"]);

                        if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD)
                        {
                            objTour.PerGuestPriceUSD = TourPrice;
                            objTour.PerGuestPriceEUR = Convert.ToDouble(Payment.USDtoEUR(TourPrice, CurrUSDIndex));

                            objTour.TotalPriceUSD = (TourPrice * TourAdultCount) + ((TourPrice / 2) * TourChildCount);
                            objTour.TotalPriceEUR = Convert.ToDouble(Payment.USDtoEUR(Convert.ToSingle(objTour.TotalPriceUSD), CurrUSDIndex));
                        }
                        else if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR)
                        {
                            objTour.PerGuestPriceEUR = TourPrice;
                            objTour.PerGuestPriceUSD = Convert.ToDouble(Payment.EURtoUSD(TourPrice, CurrUSDIndex));

                            objTour.TotalPriceEUR = (TourPrice * TourAdultCount) + ((TourPrice / 2) * TourChildCount);
                            objTour.TotalPriceUSD = Convert.ToDouble(Payment.EURtoUSD(Convert.ToSingle(objTour.TotalPriceEUR), CurrUSDIndex));
                        }

                        char[] arrSep = { '-' };
                        string[] TourDate = dr["TourDate"].ToString().Trim().Split(arrSep, StringSplitOptions.RemoveEmptyEntries);
                        objTour.ReservationStartDate = Convert.ToDateTime(TourDate[0].ToString());
                        objTour.ReservationEndDate = ((TourDate.Length > 1) ? Convert.ToDateTime(TourDate[1].ToString()) : objTour.ReservationStartDate);
                        objTour.ReservationID = rReservationID;
                        objTour.TourID = Convert.ToInt32(dr["TourID"]);
                        objTour.TourType = Convert.ToInt32(dr["TourType"]);
                        objTour.AdultCount = Convert.ToInt32(TourAdultCount);
                        objTour.ChildCount = Convert.ToInt32(TourChildCount);
                        TourReservationIDforTourGuest = objTour.Save(Tran);

                        foreach (DataRow drTourGuest in dtTourReservations_Guests.Rows)
                        {
                            if ((drTourGuest["ReservationNo"].ToString() == dr["ReservationNo"].ToString()) && (drTourGuest["TourIndex"].ToString() == dr["RowID"].ToString()))
                            {
                                DataRow drNewTourGuest = dtNewTourReservations_Guests.NewRow();
                                drNewTourGuest["TourReservationID"] = TourReservationIDforTourGuest;
                                drNewTourGuest["RoomBedPreferenceID"] = drTourGuest["RoomBedPreferenceID"];

                                foreach (DataRow drSavedGuest in dtSavedGuest.Rows)
                                {
                                    if (drSavedGuest["RowID"].ToString() == drTourGuest["GuestRowID"].ToString()) { drNewTourGuest["GuestID"] = drSavedGuest["GuestID"].ToString(); break; }
                                }

                                dtNewTourReservations_Guests.Rows.Add(drNewTourGuest);
                            }
                        }

                    }
                }
                
                if (dtNewTourReservations_Guests.Rows.Count > 0) {
                    foreach (DataRow dr in dtNewTourReservations_Guests.Rows)
                    {
                        objTresGuest = new HOTOMOTO.APEX.TourReservations_Guests();
                        objTresGuest.GuestID = Convert.ToInt32(dr["GuestID"]);
                        if (!CARETTA.COM.Util.IsNumeric(dr["RoomBedPreferenceID"].ToString()))
                        {
                            objTresGuest.RoomBedPreferenceID = (int)HOTOMOTO.BUS.Enumerations.RoomBedPreferences.NoBed;
                        }
                        else {
                            objTresGuest.RoomBedPreferenceID = Convert.ToInt32(dr["RoomBedPreferenceID"]);
                        }

                        objTresGuest.TourReservationID = Convert.ToInt32(dr["TourReservationID"]);
                        objTresGuest.Save(Tran);
                    }
                }

                if (dtTransfer != null)
                {
                    rReservationType += (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Transfer;
                    foreach (DataRow dr in dtTransfer.Rows)
                    {
                        objTres = new HOTOMOTO.APEX.TransferReservations();
                        objTres.CustomerID = CustomerID;
                        objTres.GuestCount = Convert.ToInt32(dr["GuestCount"]);

                        if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD)
                        {
                            
                            objTres.GuidancePriceUSD = Convert.ToSingle(dr["GuidancePrice"]);
                            objTres.GuidancePriceEUR = Convert.ToDouble(Payment.USDtoEUR(Convert.ToSingle(dr["GuidancePrice"]), CurrUSDIndex));

                            objTres.PerGuestPriceUSD = Convert.ToSingle(dr["Price"]) / Convert.ToInt32(dr["GuestCount"]);
                            objTres.PerGuestPriceEUR = Convert.ToDouble(Payment.USDtoEUR((Convert.ToSingle(dr["Price"]) / Convert.ToInt32(dr["GuestCount"])), CurrUSDIndex));

                            objTres.TotalPriceUSD = Convert.ToSingle(dr["Price"]);
                            objTres.TotalPriceEUR = Convert.ToDouble(Payment.USDtoEUR(Convert.ToSingle(dr["Price"]), CurrUSDIndex));

                        }
                        else if (CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR)
                        {
                            objTres.GuidancePriceEUR = Convert.ToSingle(dr["GuidancePrice"]);                            
                            objTres.GuidancePriceUSD = Convert.ToDouble(Payment.EURtoUSD(Convert.ToSingle(dr["GuidancePrice"]), CurrUSDIndex));

                            objTres.PerGuestPriceEUR = Convert.ToSingle(dr["Price"]) / Convert.ToInt32(dr["GuestCount"]);
                            objTres.PerGuestPriceUSD = Convert.ToDouble(Payment.EURtoUSD((Convert.ToSingle(dr["Price"]) / Convert.ToInt32(dr["GuestCount"])), CurrUSDIndex));

                            objTres.TotalPriceEUR = Convert.ToSingle(dr["Price"]);
                            objTres.TotalPriceUSD = Convert.ToDouble(Payment.EURtoUSD(Convert.ToSingle(dr["Price"]), CurrUSDIndex));
                        }

                        objTres.Notes = dr["Notes"].ToString();
                        objTres.PortID = Convert.ToInt32(dr["PortID"]);
                        objTres.BookingDate = DateTime.Now;
                        objTres.ReservationID = rReservationID;
                        objTres.TransferDate = Convert.ToDateTime(dr["Date"]);
                        objTres.TransferDirection = Convert.ToInt16(dr["TransferDirection"]);
                        objTres.TransferType = Convert.ToInt16(dr["TransferType"]);
                        objTres.Save(Tran);
                    }
                }


                // Kaydedilen Rezervasyonu Güncelle 
                objRes = new HOTOMOTO.APEX.Reservations();
                objRes.Load(rReservationID);
                objRes.ReservationType = rReservationType;
                objRes.Save(Tran);

                Tran.Commit();
                return rReservationID;

            }
            catch (Exception)
            {
                Tran.Rollback();
                return 0;
            }

        }


        //// Rezervasyon Detaylarýný Sil 
        //public static bool DeleteReservationDetails(int ReservationID)
        //{
        //    return APEX.Custom.SPExec_Reservation.DeleteReservationDetails(ReservationID);
        //}

    }
}
