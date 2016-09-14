using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Language {

		/// <summary>
		/// Aktif dillerin listesini getirir.
		/// </summary>
		/// <returns><para>DataTable</para> olarak diller listesini döndürür</returns>
        public static DataTable GetAllLanguages() {
            DataTable dt;
            try {
                APEX.Languages obj = new APEX.Languages();
                dt = APEX.Languages.GetAllLanguagesDataSet().Tables[0];
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }		
    }
}
