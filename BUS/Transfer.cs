using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Transfer {

        //Portlarýn Tamamýný Döndür
        public static DataTable GetPorts(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.Ports.GetAllPortsDataSet(LanguageID).Tables[0];
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Portlarýn Tamamýný Döndür

        //Portlarý Ülkeye Göre Döndür
        public static DataTable GetPortsByCountry(int LanguageID, int CountryID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Transfer.GetPorts(LanguageID, CountryID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Portlarý Ülkeye Göre Döndür

        //Transfer için Regular ve Private Ödenecek Fiyatlarý Getirme
        public static DataTable GetTransferRegularPrivatePrices(int Capacity, int CustomerID, int CurrencyID, DateTime ReservationDate) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Transfer.GetTransferRegularPrivatePrices(Capacity, CustomerID, CurrencyID, ReservationDate);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Transfer için Regular ve Private Ödenecek Fiyatlarý Getirme

        //Transfer Fiyatlarýný Döndür 
        public static DataTable GetTransferPrices(int CustomerID, int Capacity) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Transfer.GetTransferPrices(CustomerID, Capacity);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Transfer Fiyatlarýný Döndür

        public static DataTable GetPortDetails(int LanguageID, int PortID)
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Transfer.GetPortDetails(LanguageID, PortID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetPortAddresses(int LanguageID, int PortID)
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Transfer.GetPortAddresses(LanguageID, PortID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetTransferPriceListPrices(int TranferPriceListID)
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Transfer.GetTransferPriceListPrices(TranferPriceListID);
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
