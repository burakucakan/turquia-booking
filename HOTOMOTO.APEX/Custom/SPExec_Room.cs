using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace HOTOMOTO.APEX.Custom {

    public class SPExec_Room {
        public static DataTable GetPropertiesByRoomID(int LanguageID, int RoomID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomPropertiesByRoomID", conn);
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            SqlParameter param;

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);
            
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static int RemovePropertyFromRoom(int RoomID, int RoomPropertyID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemovePropertyFromRoom", conn);

            SqlParameter param;

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoomPropertyID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomPropertyID;
            cmd.Parameters.Add(param);

            conn.Open();

            return cmd.ExecuteNonQuery();
        }

        public static DataTable GetRoomImages(int RoomID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomImages", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }



        public static DataTable GetRoomsByHotelID(int LanguageID, int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomsByHotelID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);


            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Odalarýn uygunluk ve fiyat listelerine göre gün baþý fiyatlarýný döndürür.
        /// Zorunsuz alanlar kampanyalarda kullanýlmak içindir. 0 olan deðerler "tümü" anlamýna gelmektedir.
        /// </summary>
        /// <param name="RoomID">Oda numarasý (zorunlu)</param>
        /// <param name="CustomerID">Müþteri numarasý (zorunlu)</param>
        /// <param name="ReservationStartDate">Rezervasyon baþlangýç tarihi (zorunlu)</param>
        /// <param name="ReservationEndDate">Rezervasyon bitiþ tarihi (zorunlu)</param>
        /// <param name="HotelID">Otel numarasý (zorunsuz - 0)</param>
        /// <param name="HotelClassID">Otel sýnýfý (zorunsuz - 0)</param>
        /// <param name="RoomClassID">Oda sýnýfý (zorunsuz - 0)</param>
        /// <param name="CityID">Þehir numarasý (zorunsuz - 0)</param>
        /// <param name="CountryID">Ülke numarasý (zorunsuz - 0)</param>
        /// <returns></returns>
        public static DataTable GetRoomPriceAndAvailability(int RoomID, int CustomerID, int Capacity, DateTime ReservationStartDate, DateTime ReservationEndDate, int HotelID, int HotelClassID, int RoomClassID, int CityID, int CountryID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomPriceAndAvailability", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Capacity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Capacity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationStartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationEndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelClassID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelClassID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoomClassID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomClassID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CityID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CountryID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        //Hotelin Tarih Aralýðýnda Boþ Olan Odalarýný Getir
        public static DataTable GetRoomAvailability(int LanguageID, int HotelID, DateTime StartDate, DateTime EndDate) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomAvailability", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = StartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = EndDate;
            cmd.Parameters.Add(param);


            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Hotel Detayýný Dönder

        //Kapasiteye Göre Yatak Tiplerini Döndür
        public static DataTable GetBedPreferenceByCapacity(int LanguageID, int Capacity) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetBedPreferenceByCapacity", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Capacity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Capacity;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Kapasiteye Göre Yatak Tiplerini Döndür

        
        public static DataTable SearchRooms(int HotelChainID, int HotelID, int RoomID, int Capacity)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_SearchRooms", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@HotelChainID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelChainID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Capacity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Capacity;
            cmd.Parameters.Add(param);

            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                throw ex;
            }

            return dt;
        }

        public static DataTable GetRoomPrice(int RoomID, int PriceListID, int Capacity, DateTime Day)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomPrice", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Capacity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Capacity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Day", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Day;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PriceListID;
            cmd.Parameters.Add(param);


            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                throw ex;
            }

            return dt;
        }


        //Hotel Arama Sonuçlarýnda En Uygun Odanýn Fiyatlarý
        public static DataTable GetHotelSearchRoomPrice(int HotelID, int CustomerID, int AdultCount, int ChildrenCount, int Child1Age, int Child2Age, DateTime ReservationStartDate, DateTime ReservationEndDate) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelSearchRoomPrice", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);
            
            param = new SqlParameter("@AdultCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = AdultCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ChildrenCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ChildrenCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Child1Age", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Child1Age;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Child2Age", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Child2Age;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationStartDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationEndDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationEndDate;
            cmd.Parameters.Add(param);


            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Hotel Arama Sonuçlarýnda En Uygun Odanýn Fiyatlarý

        //Rezervasyon Sayfasý için oda tiplerinin toplam fiyatý
        public static DataTable GetRoomPriceDetails(int RoomID, int CustomerID, int AdultCount, int ChildrenCount, int Child1Age, int Child2Age, DateTime ReservationStartDate, DateTime ReservationEndDate) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomPriceDetails", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AdultCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = AdultCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ChildrenCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ChildrenCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Child1Age", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Child1Age;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Child2Age", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Child2Age;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationStartDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationEndDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationEndDate;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Rezervasyon Sayfasý için oda tiplerinin toplam fiyatý

		public static DataTable GetRoomPriceListPrices(int LanguageID, int HotelID, int CityID, int HotelClassID) {
			SqlConnection conn = APEX.DBHelper.getConnection();
			SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomPriceListPrices", conn);
			SqlDataAdapter da;
			SqlParameter param;
			DataTable dt = new DataTable();

			param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = LanguageID;
			cmd.Parameters.Add(param);

			param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = HotelID;
			cmd.Parameters.Add(param);

			param = new SqlParameter("@CityID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = CityID;
			cmd.Parameters.Add(param);

			param = new SqlParameter("@HotelClassID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = HotelClassID;
			cmd.Parameters.Add(param);

			da = new SqlDataAdapter(cmd);
			da.Fill(dt);
			return dt;
		}

        //[cproc_GetRoomPriceListCustomers]

        public static DataTable GetRoomPriceListCustomers(int RoomPriceListID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRoomPriceListCustomers", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomPriceListID;
            cmd.Parameters.Add(param);

            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                throw ex;
            }

            return dt;
        }

        public static int RemoveRoomPropertiesByRoomID(int RoomID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemoveRoomPropertiesByRoomID", conn);

            SqlParameter param;
            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            conn.Open();
            int returnValue;
            try
            {
                returnValue = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }

            return returnValue;
        }

    }
}