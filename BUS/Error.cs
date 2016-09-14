using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Error {

        //Hata Mesajýný Dönder
        public static DataTable GetError(int LanguageID, HOTOMOTO.BUS.Enumerations.ErrorMessageTypes ErrorTypeID) {
            DataTable dt;
            try {
                APEX.Custom.SPExec_Error objError = new APEX.Custom.SPExec_Error();
                dt = objError.GetError(LanguageID, (int)ErrorTypeID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Hata Mesajýný Dönder

    }
}
