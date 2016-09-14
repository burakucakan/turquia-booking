using System;
using System.Collections.Generic;
using System.Text;

namespace HOTOMOTO.COM {
    public class Payment {

        // Order Kodu Oluþtur  
        public static string CreateOrderCode(int ReservationID, string ReservationCode, int UserID) {
            return DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + CARETTA.COM.Util.Right(DateTime.Now.Year.ToString(), 2) + ReservationID.ToString().PadLeft(4, '0') + ReservationCode + UserID.ToString().PadLeft(4, '0');
        }

        public static string CreateReservationCode(int Length) {
            return CARETTA.COM.Util.CreateRandomNumber(Length);
        }

    }
}
