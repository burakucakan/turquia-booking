using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_GetHotel {

        //Hotel Arama Sonuçlarýný Döndür
        public DataTable GetHotels(int LanguageID, int CountryID, int CityID, string HotelName, string Class, DateTime ArrivalDate, DateTime DepartureDate) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetHotels", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CountryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CityID", SqlDbType.Int, 4);
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

            param = new SqlParameter("@ArrivalDate", SqlDbType.SmallDateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = ArrivalDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DepartureDate", SqlDbType.SmallDateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = DepartureDate;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Hotel Arama Sonuçlarýný Döndür

    }
}
