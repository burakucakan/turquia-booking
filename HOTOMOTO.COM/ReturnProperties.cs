using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.COM {
    public class ReturnProperties {

        public static string GetProperties(int LanguageID, int ID, HOTOMOTO.BUS.Enumerations.PropertyTypes PropertyType) {
            
            DataTable dtProperties = null;
            if (PropertyType == HOTOMOTO.BUS.Enumerations.PropertyTypes.Hotel) {
                dtProperties = HOTOMOTO.BUS.Hotels.GetHotelProperties(LanguageID, ID);
             }
             else if (PropertyType == HOTOMOTO.BUS.Enumerations.PropertyTypes.Room) {
                 dtProperties = HOTOMOTO.BUS.Rooms.GetPropertiesByRoomID(LanguageID, ID);
             }

            StringBuilder strProperties = new StringBuilder();
            if (dtProperties.Rows.Count > 0) {
                foreach (DataRow dr in dtProperties.Rows) {
                    strProperties.Append("<img width=19 height=19 src=Images/Properties/" + PropertyType.ToString() + "Properties/");
                    strProperties.Append(dr["IconFileName"].ToString());
                    strProperties.Append(" alt='");
                    strProperties.Append(dr["Property"].ToString());
                    strProperties.Append("' />&nbsp;&nbsp;&nbsp;");
                }
            }
            return strProperties.ToString();
        }

    }
}
