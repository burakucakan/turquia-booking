using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.BUS
{
    public class Recommendations
    {

        // Önerilenleri Getir 
        public static DataTable GetRecommendations()
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Recommendations.GetRecommendations();
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

    }
}
