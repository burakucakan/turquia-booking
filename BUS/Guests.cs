using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace HOTOMOTO.BUS {

    public class Guests {

        /// <summary>
        /// �sme ve/veya soyada g�re ziyaret�ilerin listesini getirir.
        /// </summary>
        /// <param name="FirstName">Ziyaret�i ad�</param>
        /// <param name="LastName">Ziyaret�i soyad�</param>
        /// <returns>Ziyaret�i listesini DataTable olarak d�nd�r�r.</returns>
        public static DataTable FindGuestByName(string FirstName, string LastName) {
            return HOTOMOTO.APEX.Custom.SPExec_Guest.FindGuestByName(FirstName, LastName);
        }

        /// <summary>
        /// Telefon numaras�na g�re ziyaret�ileri getirir.
        /// </summary>
        /// <param name="Telephone">Ziyaret�inin telefon numaras�</param>
        /// <returns>Ziyaret�i listesini DataTable olarak d�nd�r�r.</returns>
        public static DataTable FindGuestByTelephone(string Telephone) {
            return HOTOMOTO.APEX.Custom.SPExec_Guest.FindGuestByPhone(Telephone);
        }

    }

}
