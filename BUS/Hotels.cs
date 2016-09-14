using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HOTOMOTO;

namespace HOTOMOTO.BUS {
    public class Hotels {

        private int m_intHotelID;
		private int m_intHotelChainID;
		private int m_intHotelClassID;
		private int m_intCityID;
		private int m_intCountryID;
		private string m_strHotelName;
		private string m_strDescription;
		private string m_strMotto;
		private string m_strDirections;

        public Hotels() {
        }

        public Hotels(int HotelID, int LanguageID) {
            this.Load(HotelID, LanguageID);
        }

        public void Load(int HotelID, int LanguageID) {
            HOTOMOTO.APEX.Hotels hotel = new HOTOMOTO.APEX.Hotels(LanguageID);
            hotel.Load(HotelID);

            this.m_intHotelID = hotel.HotelID;
            this.m_intHotelChainID = hotel.HotelChainID;
            this.m_intHotelClassID = hotel.HotelClassID;
            this.m_intCityID = hotel.CityID;
            this.m_intCountryID = hotel.CountryID;
            this.m_strHotelName = hotel.HotelName;
            this.m_strMotto = hotel.Motto;
            this.m_strDirections = hotel.Directions;
            this.m_strDescription = hotel.Description;
        }

        //Hotel Sýnýflarýný Getir
        public static DataTable GetHotelClasses(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.HotelClasses.GetAllHotelClassesDataSet(LanguageID).Tables[0];
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Hotel Sýnýflarý

        //Hotel Arama Sonuçlarýný Döndür
        public static DataTable GetHotelList(int LanguageID, string CityID, string HotelName, string Class, int RoomQuantity, DateTime ArrivalDate, DateTime DepartureDate) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Hotel.GetHotels(LanguageID, CityID, HotelName, Class, RoomQuantity, ArrivalDate, DepartureDate);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Hotel Arama Sonuçlarýný Döndür

        public static DataTable GetHotelsWithDetails(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Hotel.GetHotelsWithDetails(LanguageID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetHotelProperties(int LanguageID, int HotelID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Hotel.GetHotelPropertiesByID(LanguageID, HotelID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static int RemovePropertyFromHotel(int HotelID, int HotelPropertyID) {
            return APEX.Custom.SPExec_Hotel.RemovePropertyFromHotel(HotelID, HotelPropertyID);
        }

        public static DataTable GetHotelAddresses(int LanguageID, int HotelID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Hotel.GetHotelAddresses(LanguageID, HotelID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetHotelImages(int HotelID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Hotel.GetHotelImages(HotelID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetHotelPlacesAndDistances(int LanguageID, int HotelID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Hotel.GetHotelPlacesAndDistances(LanguageID, HotelID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static int Update(int PlaceID, int HotelID, int Distance, int Time) {
            return APEX.Custom.SPExec_Hotel.UpdateHotelPlaceAndDistance(PlaceID, HotelID, Distance, Time);
        }

        public static int RemovePlaceDistanceFromHotel(int PlaceID, int HotelID) {
            return APEX.Custom.SPExec_Hotel.RemovePlaceDistanceFromHotel(PlaceID, HotelID);
        }

        public static int RemovePlaceDistanceByHotelID(int HotelID)
        {
            return APEX.Custom.SPExec_Hotel.RemovePlaceDistanceByHotelID(HotelID);
        }

        

        public static int RemoveHotelImage(int HotelImageID) {
            APEX.HotelImages objHotelImage = new HOTOMOTO.APEX.HotelImages();
            objHotelImage.Load(HotelImageID);
            return objHotelImage.Delete();
        }

        //Hotel Sýnýflarýný Getir
        public static DataTable GetHotelDetail(int LanguageID, int HotelID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Hotel.GetHotelDetail(LanguageID, HotelID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Hotel Sýnýflarý

		public static DataTable GetHotelListByCity(int LanguageID, int CityID) {
			DataTable dt = new DataTable();

			try {
				dt = HOTOMOTO.APEX.Custom.SPExec_Hotel.GetHotelListByCity(LanguageID, CityID);
			} catch(Exception) {
				dt = null;
				throw;
			}

			return dt;
		}

		public static int GetHotelAddressRowID(int HotelID, int AddressID) {
			return HOTOMOTO.APEX.Custom.SPExec_Hotel.GetHotelAddressRowID(HotelID, AddressID);
		}

        public int HotelID {
            get { return m_intHotelID; }
            set { m_intHotelID = value; }
        }
        public int HotelChainID {
            get { return m_intHotelChainID; }
            set { m_intHotelChainID = value; }
        }
        public int HotelClassID {
            get { return m_intHotelClassID; }
            set { m_intHotelClassID = value; }
        }
        public int CityID {
            get { return m_intCityID; }
            set { m_intCityID = value; }
        }
        public int CountryID {
            get { return m_intCountryID; }
            set { m_intCountryID = value; }
        }
        public string HotelName {
            get { return this.m_strHotelName; }
            set { this.m_strHotelName = value; }
        }
        public string Description {
            get { return this.m_strDescription; }
            set { this.m_strDescription = value; }
        }
        public string Motto {
            get { return this.m_strMotto; }
            set { this.m_strMotto = value; }
        }
        public string Directions {
            get { return this.m_strDirections; }
            set { this.m_strDirections = value; }
        }
    }
}
