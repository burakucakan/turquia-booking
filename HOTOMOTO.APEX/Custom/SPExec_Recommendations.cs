using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom
{
    public class SPExec_Recommendations
    {
        // Önerilenleri Getir 
        public static DataTable GetRecommendations()
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRecommendations", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


    }
}
