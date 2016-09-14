using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Help {
        private int LanguageID = 1;
        public Help(int LanguageID) {
            this.LanguageID = LanguageID;
        }

        //Help Tamamýný Getir
        public static DataTable GetAllHelp(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.Help.GetAllHelpDataSet(LanguageID).Tables[0];
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        // Random Ýpucu Getir
        public static DataTable GetRandomTip(int LanguageID)
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Help.GetRandomTip(LanguageID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }
    }
}
