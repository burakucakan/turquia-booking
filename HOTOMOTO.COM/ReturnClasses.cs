using System;
using System.Collections.Generic;
using System.Text;

namespace HOTOMOTO.COM {
    public class ReturnClasses {

        //Class a göre yýldýzlarý veya ismini döndürüyor
        public static string GetHotelClassFormat(string HotelClass) {
            if (HotelClass.Length > 1) {
                return HotelClass;
            }
            else {
                StringBuilder strStars = new StringBuilder();
                for (int i = 1; i <= int.Parse(HotelClass); i++) {
                    strStars.Append("<img width=13 height=13 src=Images/Icons/Star.gif />");
                }
                return strStars.ToString();
            }
        }

    }
}
