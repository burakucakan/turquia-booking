using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Authentication {

        //Login Kontrol
        public static DataTable LoginControl(string CustomerCode, string UserName, string Password) {

            DataTable dt;
            try {
                string strEncKey = "BUSE"; // ConfigurationManager.AppSettings["EncyriptionKey"].ToString();
                CustomerCode = CARETTA.COM.Util.ClearString(CustomerCode);
                UserName = CARETTA.COM.Encryption.Encrypt(UserName, strEncKey);
                Password = CARETTA.COM.Encryption.Encrypt(Password, strEncKey);

                dt = APEX.Custom.SPExec_Authentication.LoginControl(CustomerCode, UserName, Password);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;

        }//Login Kontrol

        //Yetkiler
        public static DataTable GetUserPermissions(int UserRoleID, int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Authentication.GetUserPermissions(LanguageID, UserRoleID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Yetkiler

        //Login Loglarýný Kaydet
        public static bool LogSave(int UserID, string UserIP, DateTime LastLoginDate) {

            APEX.LoginLogs objLog;
            bool bolStatus = false;

            try {
                objLog = new HOTOMOTO.APEX.LoginLogs();
                objLog.UserID = UserID;
                objLog.IP = UserIP;
                objLog.LastLoginDate = LastLoginDate;
                objLog.Save();
                bolStatus = true;
            } catch(Exception) {
                bolStatus = false;
                throw;
            }
            return bolStatus;
        }//Login Loglarýný Kaydet

    }
}
