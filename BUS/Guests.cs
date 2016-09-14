using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace HOTOMOTO.BUS {

    public class Guests {

        /// <summary>
        /// Ýsme ve/veya soyada göre ziyaretçilerin listesini getirir.
        /// </summary>
        /// <param name="FirstName">Ziyaretçi adý</param>
        /// <param name="LastName">Ziyaretçi soyadý</param>
        /// <returns>Ziyaretçi listesini DataTable olarak döndürür.</returns>
        public static DataTable FindGuestByName(string FirstName, string LastName) {
            return HOTOMOTO.APEX.Custom.SPExec_Guest.FindGuestByName(FirstName, LastName);
        }

        /// <summary>
        /// Telefon numarasýna göre ziyaretçileri getirir.
        /// </summary>
        /// <param name="Telephone">Ziyaretçinin telefon numarasý</param>
        /// <returns>Ziyaretçi listesini DataTable olarak döndürür.</returns>
        public static DataTable FindGuestByTelephone(string Telephone) {
            return HOTOMOTO.APEX.Custom.SPExec_Guest.FindGuestByPhone(Telephone);
        }

    }

}
