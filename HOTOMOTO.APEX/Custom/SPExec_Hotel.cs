using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_Hotel {

        //Hotel Arama Sonuçlarýný Döndür
        public static DataTable GetHotels(int LanguageID, string CityID, string HotelName, string Class, int RoomQuantity, DateTime ArrivalDate, DateTime DepartureDate) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotels", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@RowCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CityID", SqlDbType.VarChar, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelName", SqlDbType.NVarChar, 300);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Class", SqlDbType.NVarChar, 16);
            param.Direction = ParameterDirection.Input;
            param.Value = Class;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoomQuantity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomQuantity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArrivalDate", SqlDbType.SmallDateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = ArrivalDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DepartureDate", SqlDbType.SmallDateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = DepartureDate;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }//Hotel Arama Sonuçlarýný Döndür

        public static DataTable GetHotelsWithDetails(int LanguageID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelsWithDetails", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetHotelPropertiesByID(int LanguageID, int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelPropertiesByHotelID", conn);
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

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Otel ID sine göre Otel Propertylerini Döndür

        public static int RemovePropertyFromHotel(int HotelID, int HotelPropertyID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemovePropertyFromHotel", conn);

            SqlParameter param;
            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelPropertyID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelPropertyID;
            cmd.Parameters.Add(param);

            conn.Open();
            int returnValue = cmd.ExecuteNonQuery();
            conn.Close();

            return returnValue;
        }

        public static DataTable GetHotelAddresses(int LanguageID, int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelAddresses", conn);
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

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetHotelImages(int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelImages", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetHotelPlacesAndDistances(int LanguageID, int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelPlacesAndDistances", conn);
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

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static int UpdateHotelPlaceAndDistance(int PlaceID, int HotelID, int Distance, int Time) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_UpdateHotelPlacesAndDistance", conn);

            SqlParameter param;
            param = new SqlParameter("@PlaceID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PlaceID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Distance", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Distance;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Time", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Time;
            cmd.Parameters.Add(param);

            conn.Open();
            int returnValue = cmd.ExecuteNonQuery();
            conn.Close();

            return returnValue;
        }

        public static int RemovePlaceDistanceFromHotel(int PlaceID, int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemovePlaceDistanceFromHotel", conn);

            SqlParameter param;
            param = new SqlParameter("@PlaceID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PlaceID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            conn.Open();
            int returnValue = cmd.ExecuteNonQuery();
            conn.Close();

            return returnValue;
        }

        public static int RemovePlaceDistanceByHotelID(int HotelID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemovePlaceDistanceByHotelID", conn);

            SqlParameter param;
            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
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

        






        //Hotel Detayýný Dönder
        public static DataTable GetHotelDetail(int LanguageID, int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelDetail", conn);
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

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Hotel Detayýný Dönder

		public static DataTable GetHotelListByCity(int LanguageID, int CityID) {
			SqlConnection conn = APEX.DBHelper.getConnection();
			SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_Paramsel", conn);
			SqlDataAdapter da;
			SqlParameter param;
			DataTable dt = new DataTable();

			param = new SqlParameter("@Columns", SqlDbType.NVarChar, 1024);
			param.Direction = ParameterDirection.Input;
			param.Value = "h.HotelID, hm.HotelName";
			cmd.Parameters.Add(param);

			param = new SqlParameter("@TableName", SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Input;
			param.Value = "Hotels h INNER JOIN Hotels_ML hm ON h.HotelID=hm.HotelID";
			cmd.Parameters.Add(param);

			param = new SqlParameter("@WhereClause", SqlDbType.NVarChar, 1024);
			param.Direction = ParameterDirection.Input;
			if(CityID == 0)
				param.Value = string.Format("hm.LanguageID = {0}", LanguageID);
			else
				param.Value = string.Format("hm.LanguageID = {0} AND h.CityID = {1}", LanguageID, CityID);
			cmd.Parameters.Add(param);

			param = new SqlParameter("@OrderParameter", SqlDbType.NVarChar, 256);
			param.Direction = ParameterDirection.Input;
			param.Value = "hm.HotelName";
			cmd.Parameters.Add(param);

			da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			return dt;
		}

		public static int GetHotelAddressRowID(int HotelID, int AddressID) {
			SqlConnection conn = APEX.DBHelper.getConnection();
			SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_Paramsel", conn);

			SqlParameter param;

			param = new SqlParameter("@Columns", SqlDbType.NVarChar, 1024);
			param.Direction = ParameterDirection.Input;
			param.Value = "RowID";
			cmd.Parameters.Add(param);

			param = new SqlParameter("@TableName", SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Input;
			param.Value = "Hotels_Addresses";
			cmd.Parameters.Add(param);

			param = new SqlParameter("@WhereClause", SqlDbType.NVarChar, 1024);
			param.Direction = ParameterDirection.Input;
			param.Value = string.Format("HotelID = {0} AND AddressID = {1}", HotelID, AddressID);
			cmd.Parameters.Add(param);

			int result;
			object objResult = cmd.ExecuteScalar();
			int.TryParse(objResult.ToString(), out result);
			conn.Close();
			
			return result;
        }

        public static DataTable GetHotelsByHotelChainID(int LanguageID, int HotelChainID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotelsByHotelChainID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelChainID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelChainID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }//Hotel Arama Sonuçlarýný Döndür

    }
}
