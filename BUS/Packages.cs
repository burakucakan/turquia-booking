using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Packages {

        //Favori Otelleri Getir 
        public static DataTable GetFavoriteHotels(int CustomerID, int UserID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Packages.GetFavoriteHotels(CustomerID, UserID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Favori Otelleri Getir 

    }
}
