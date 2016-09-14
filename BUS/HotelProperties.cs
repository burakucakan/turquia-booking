using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class HotelProperties {

        //Hotel Propertilerini Döndür
        public static DataTable GetHotelProperties(int LanguageID, int HotelID) {
            DataTable dt;
            try {
                APEX.Custom.SPExec_HotelProperties objHotelProperties = new APEX.Custom.SPExec_HotelProperties();
                dt = objHotelProperties.GetHotelPropertiesByID(LanguageID, HotelID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Hotel Propertilerini Döndür

    }
}
