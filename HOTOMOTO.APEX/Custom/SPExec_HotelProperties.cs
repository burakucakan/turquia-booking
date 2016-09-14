using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_HotelProperties {


        //Otel ID sine göre Otel Propertylerini Döndür
        public DataTable GetHotelPropertiesByID(int LanguageID, int HotelID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetPropertiesByHotelID", conn);
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

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Otel ID sine göre Otel Propertylerini Döndür

    }
}
