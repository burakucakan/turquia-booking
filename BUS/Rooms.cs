using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlTypes;

namespace HOTOMOTO.BUS {
    public class Rooms {
        private int m_intRoomID;
        private int m_intHotelID;
        private int m_intRoomClassID;
        private int m_intPriceID;
        private bool m_bolisSmokable;
        private DateTime m_dtCreateDate;
        private int m_intCreatedBy;
        private DateTime m_dtModifyDate;
        private int m_intModifiedBy;
        private bool m_bolisActive;
        private string m_strRoomName;
        private string m_strDescription;

        public Rooms() {
        }

        public Rooms(int RoomID, int LanguageID) {
            this.Load(LanguageID, RoomID);
        }

        public void Load(int LanguageID, int RoomID) {
            try {
                APEX.Rooms objRoom = new HOTOMOTO.APEX.Rooms(LanguageID);
                objRoom.Load(RoomID);

                this.CreateDate = objRoom.CreateDate;
                this.CreatedBy = objRoom.CreatedBy;
                this.HotelID = objRoom.HotelID;
                this.isActive = objRoom.isActive;
                this.isSmokable = objRoom.isActive;
                this.ModifiedBy = objRoom.ModifiedBy;
                this.ModifyDate = objRoom.ModifyDate;
                this.RoomID = objRoom.RoomID;
                this.RoomName = objRoom.RoomName;
                this.Description = objRoom.Description;
            } catch(Exception) {
                throw;
            }
        }

        public int RoomID {
            get { return m_intRoomID; }
            set { m_intRoomID = value; }
        }
        public int HotelID {
            get { return m_intHotelID; }
            set { m_intHotelID = value; }
        }
        public int RoomClassID {
            get { return m_intRoomClassID; }
            set { m_intRoomClassID = value; }
        }
        public int PriceID {
            get { return m_intPriceID; }
            set { m_intPriceID = value; }
        }
        public bool isSmokable {
            get { return m_bolisSmokable; }
            set { m_bolisSmokable = value; }
        }
        public DateTime CreateDate {
            get { return m_dtCreateDate; }
            set { m_dtCreateDate = value; }
        }
        public int CreatedBy {
            get { return m_intCreatedBy; }
            set { m_intCreatedBy = value; }
        }
        public DateTime ModifyDate {
            get { return m_dtModifyDate; }
            set { m_dtModifyDate = value; }
        }
        public int ModifiedBy {
            get { return m_intModifiedBy; }
            set { m_intModifiedBy = value; }
        }
        public bool isActive {
            get { return m_bolisActive; }
            set { m_bolisActive = value; }
        }
        public string RoomName {
            get { return m_strRoomName; }
            set { m_strRoomName = value; }
        }
        public string Description {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }

        public static DataTable GetPropertiesByRoomID(int LanguageID, int RoomID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetPropertiesByRoomID(LanguageID, RoomID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetRoomImages(int RoomID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetRoomImages(RoomID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static int RemovePropertyFromRoom(int RoomID, int RoomPropertyID) {
            return APEX.Custom.SPExec_Room.RemovePropertyFromRoom(RoomID, RoomPropertyID);
        }

        public static int RemoveRoomImage(int RoomImageID) {
            APEX.RoomImages objRoomImage = new HOTOMOTO.APEX.RoomImages();
            objRoomImage.Load(RoomImageID);
            return objRoomImage.Delete();
        }

        public static DataTable GetRoomsByHotelID(int LanguageID, int HotelID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetRoomsByHotelID(LanguageID, HotelID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        /// <summary>
        /// Odalar�n uygunluk ve fiyat listelerine g�re g�n ba�� fiyatlar�n� d�nd�r�r.
        /// </summary>
        /// <param name="RoomID">Oda numaras� (zorunlu)</param>
        /// <param name="CustomerID">M��teri numaras� (zorunlu)</param>
        /// <param name="Capacity">Odada kalacak ziyaret�i say�s�</param>
        /// <param name="ReservationStartDate">Rezervasyon ba�lang�� tarihi (zorunlu)</param>
        /// <param name="ReservationEndDate">Rezervasyon biti� tarihi (zorunlu)</param>
        /// <returns></returns>
        public static DataTable GetRoomPriceAndAvailability(int RoomID, int CustomerID, int Capacity, DateTime ReservationStartDate, DateTime ReservationEndDate) {
            return GetRoomPriceAndAvailability(RoomID, CustomerID, Capacity, ReservationStartDate, ReservationEndDate, 0, 0, 0, 0, 0);
        }

        /// <summary>
        /// Odalar�n uygunluk ve fiyat listelerine g�re g�n ba�� fiyatlar�n� d�nd�r�r.
        /// Zorunsuz alanlar kampanyalarda kullan�lmak i�indir. 0 olan de�erler "t�m�" anlam�na gelmektedir.
        /// </summary>
        /// <param name="RoomID">Oda numaras� (zorunlu)</param>
        /// <param name="CustomerID">M��teri numaras� (zorunlu)</param>
        /// <param name="Capacity">Odada kalacak ziyaret�i say�s�</param>
        /// <param name="ReservationStartDate">Rezervasyon ba�lang�� tarihi (zorunlu)</param>
        /// <param name="ReservationEndDate">Rezervasyon biti� tarihi (zorunlu)</param>
        /// <param name="HotelID">Otel numaras� (zorunsuz - 0)</param>
        /// <param name="HotelClassID">Otel s�n�f� (zorunsuz - 0)</param>
        /// <param name="RoomClassID">Oda s�n�f� (zorunsuz - 0)</param>
        /// <param name="CityID">�ehir numaras� (zorunsuz - 0)</param>
        /// <param name="CountryID">�lke numaras� (zorunsuz - 0)</param>
        /// <returns></returns>
        public static DataTable GetRoomPriceAndAvailability(int RoomID, int CustomerID, int Capacity, DateTime ReservationStartDate, DateTime ReservationEndDate, int HotelID, int HotelClassID, int RoomClassID, int CityID, int CountryID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetRoomPriceAndAvailability(RoomID, CustomerID, Capacity, ReservationStartDate, ReservationEndDate, HotelID, HotelClassID, RoomClassID, CityID, CountryID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        //Hotelin Tarih Aral���nda Bo� Olan Odalar�n� Getir
        public static DataTable GetRoomAvailability(int LanguageID, int HotelID, DateTime StartDate, DateTime EndDate) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetRoomAvailability(LanguageID, HotelID, StartDate, EndDate);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        //Kapasiteye G�re Yatak Tiplerini Getir
        public static DataTable GetBedPreferenceByCapacity(int LanguageID, int Capacity) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetBedPreferenceByCapacity(LanguageID, Capacity);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        //Hotel Arama Sonu�lar�nda En Uygun Odan�n Fiyatlar�
        public static DataTable GetHotelSearchRoomPrice(int HotelID, int CustomerID, int AdultCount, int ChildrenCount, int Child1Age, int Child2Age, DateTime ReservationStartDate, DateTime ReservationEndDate) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetHotelSearchRoomPrice(HotelID, CustomerID, AdultCount, ChildrenCount, Child1Age, Child2Age, ReservationStartDate, ReservationEndDate);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        //Rezervasyon Sayfas� i�in oda tiplerinin toplam fiyat�
        public static DataTable GetRoomPriceDetails(int RoomID, int CustomerID, int AdultCount, int ChildrenCount, int Child1Age, int Child2Age, DateTime ReservationStartDate, DateTime ReservationEndDate) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Room.GetRoomPriceDetails(RoomID, CustomerID, AdultCount, ChildrenCount, Child1Age, Child2Age, ReservationStartDate, ReservationEndDate);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

		/// <summary>
		/// Fiyat Listesi �eker. Fiyat listesi �ekli tek sat�rda yatak kapasiteleri ile birlikte gelmektedir.
		/// </summary>
		/// <param name="LanguageID">...</param>
		/// <param name="HotelID">...</param>
		/// <param name="CityID">...</param>
		/// <returns>DataTable cinsinden Fiyat listesi d�nd�r�r.</returns>
		public static DataTable GetRoomPriceListPrices(int LanguageID, int HotelID, int CityID, int HotelClassID) {
			DataTable dt;
			try {
				dt = APEX.Custom.SPExec_Room.GetRoomPriceListPrices(LanguageID, HotelID, CityID, HotelClassID);
			} catch(Exception) {
				dt = null;
				throw;
			}
			return dt;
		}

		public static DataTable GetAllRoomPriceLists() {
			return HOTOMOTO.APEX.RoomPriceLists.GetAllRoomPriceListsDataSet().Tables[0];
		}

        public static int RemoveRoomPropertiesByRoomID(int RoomID)
        {
            return APEX.Custom.SPExec_Room.RemoveRoomPropertiesByRoomID(RoomID);
        }

        public static int GetRoomAvailabilityAtDate(int RoomID, DateTime AvailabilityDate)
        {
            APEX.RoomAvailabilities objRoomAvalibility = new APEX.RoomAvailabilities();
            if (objRoomAvalibility.Load(AvailabilityDate, RoomID))
            {
                return objRoomAvalibility.Quantity;
            }
            else
            {
                return -1;
            }
            
            
        }

        public static DataTable GetRoomPrice(int RoomID, int PriceListID, int Capacity, DateTime Day)
        {
            return APEX.Custom.SPExec_Room.GetRoomPrice(RoomID, PriceListID, Capacity, Day);
        }



        /// <summary>
        /// Odan�n fiyat�n� kaydeder. Bunu Delete - Insert mant��� ile yapar
        /// </summary>
        /// <param name="RoomPriceListPriceID">Fiyat listesi fiyatlar�ndan silinmesi gereken ID - 0 girilirse silme olmaz</param>
        /// <param name="RoomID">Fiyat� girilen oda</param>
        /// <param name="Capacity">Odada ka� ki�iye g�re fiyat</param>
        /// <param name="Day">Hangi g�n i�in</param>
        /// <param name="USDPrice">USD Yeni Fiyat�</param>
        /// <param name="EURPrice">EUR Yeni Fiyat�</param>
        public static void SaveRoomPrice(int RoomPriceListPriceID, int RoomID, int PriceListID, int Capacity, DateTime Day, double USDPrice, double EURPrice)
        {
            APEX.Prices objPrices;
            APEX.RoomPriceListPrices objRoomPriceListPrices;

            int PriceID;

            DataTable dtRoomPrice;
            dtRoomPrice = GetRoomPrice(RoomID, PriceListID, Capacity, Day);
            if (dtRoomPrice.Rows.Count > 0)
            {
                objRoomPriceListPrices = new APEX.RoomPriceListPrices();
                objRoomPriceListPrices.Load(Convert.ToInt32(dtRoomPrice.Rows[0]["RoomPriceListPriceID"]));
                PriceID = objRoomPriceListPrices.PriceID;

                objPrices = new APEX.Prices();
                objPrices.PriceID = PriceID;
                objPrices.Delete();

                objRoomPriceListPrices.Delete();
            }

            objPrices = new APEX.Prices();
            objPrices.EURPrice = EURPrice;
            objPrices.USDPrice = USDPrice;
            

            objRoomPriceListPrices = new APEX.RoomPriceListPrices();
            objRoomPriceListPrices.Capacity = Convert.ToByte(Capacity);
            objRoomPriceListPrices.Day = Day;
            objRoomPriceListPrices.RoomID = RoomID;
            objRoomPriceListPrices.PriceID = objPrices.Save();
            objRoomPriceListPrices.RoomPriceListID = PriceListID;
            objRoomPriceListPrices.Save();

        }


    }
}