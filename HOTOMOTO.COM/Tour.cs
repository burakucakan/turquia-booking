using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace HOTOMOTO.COM {
    public class Tour {

        /// <summary>
        /// G�nderilen Tarih Aral���nda Excursion Turlar hani g�nler varsa onlar� ddl e doldurur.
        /// </summary>
        /// <param name="ddl">REF DDL</param>
        /// <param name="StartDate">Aramadaki Arrival Date</param>
        /// <param name="EndDate">Aramadaki Departure Date</param>
        /// <param name="HasDays">Haftan�n G�nleri 1 li 0 l� �ekilde birle�mi� olarak</param>
        public static void GetExcDDLDate(ref DropDownList ddl, DateTime StartDate, DateTime EndDate, string HasDays, DateTime SessArrivalDate, DateTime SessDepartureDate) {
            ddl.Items.Clear();
            for (DateTime i = SessArrivalDate; i <= SessDepartureDate; i = i.Date.AddDays(1)) {
                if ((i.Date >= StartDate.Date) && (i.Date <= EndDate.Date) && (HasDays.Substring((((int)i.Date.AddDays(-1).DayOfWeek)), 1) == "1")) {
                    ddl.Items.Add(new ListItem(i.Date.ToShortDateString(), i.Date.ToShortDateString()));
                }
            }
        }

        /// <summary>
        /// G�nderilen Tarih Aral���nda Circuato Turlar hani g�n aral�klar�nda varsa onlar� ddl e doldurur.
        /// </summary>
        /// <param name="ddl">REF DDL</param>
        /// <param name="StartDate">Aramadaki Arrival Date</param>
        /// <param name="EndDate">Aramadaki Departure Date</param>
        /// <param name="HasDays">Haftan�n G�nleri 1 li 0 l� �ekilde birle�mi� olarak</param>
        /// <param name="StartDay">Turun Haftada ba�lang�� g�n�n�n indexi </param>
        public static void GetCircDDLDate(ref DropDownList ddl, DateTime StartDate, DateTime EndDate, string HasDays, int StartDay, DateTime SessArrivalDate, DateTime SessDepartureDate) {
            ddl.Items.Clear();
            DateTime ItemStartDate = DateTime.MinValue;
            DateTime ItemEndDate = DateTime.MaxValue;
            int CIndex = 0;
            for (DateTime i = SessArrivalDate; i <= SessDepartureDate; i = i.Date.AddDays(1)) {
                if ((i.Date >= StartDate.Date) && (i.Date <= EndDate.Date) && ((int)i.Date.DayOfWeek == (StartDay % 7))) {
                    ItemStartDate = i.Date;
                    CIndex = ((HasDays.LastIndexOf('1') - (StartDay - 1)) + (HasDays.IndexOf('0')));
                    ItemEndDate = ItemStartDate.Date.AddDays(CIndex);
                    ddl.Items.Add(new ListItem(ItemStartDate.ToShortDateString() + " - " + ItemEndDate.ToShortDateString(), ItemStartDate.ToShortDateString() + " - " + ItemEndDate.ToShortDateString()));
                }
            }
        }

    }
}
