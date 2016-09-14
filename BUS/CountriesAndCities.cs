using System;
using System.Collections.Generic;
using System.Text;
using HOTOMOTO;
using System.Data;

namespace HOTOMOTO.BUS {
    public class CountriesAndCities {

        //Ülkeleri Getir
        public static DataTable GetCountries(int LanguageID) {
            DataTable dt;
            try {
                APEX.Countries obj = new APEX.Countries(LanguageID);
                dt = APEX.Countries.GetAllCountriesDataSet(LanguageID).Tables[0];
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Ülkeleri Getir

        //Þehirleri Getir
        public static DataTable GetCities(int LanguageID) {
            DataTable dt;
            try {
                APEX.Cities obj = new APEX.Cities(LanguageID);
                dt = APEX.Cities.GetAllCitiesDataSet(LanguageID).Tables[0];
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Þehirleri Getir

        public static int AddCountry(string[] CountryNames) {
            //HOTOMOTO.APEX.Countries country = new HOTOMOTO.APEX.Countries(1);

            //StringBuilder sb = new StringBuilder();
            //for(int i = 0; i < CountryNames.Length; i++) {
            //    if(i > 0)
            //        sb.Append(" OR ");
            //    sb.Append("Name = '" + CountryNames[i] + "'");
            //}

            //System.Data.SqlClient.SqlDataReader reader = HOTOMOTO.APEX.SpRunner.Paramsel("Countries_ML", 0, 0, "Name", sb.ToString(), "");
            //if(!reader.HasRows) {
            //    //iþlem yap
            //}

            return 0;
        }

        public static int UpdateCountry(string[] CountryNames) {
            return 0;
        }

        //Þehirleri Getir
        public static DataTable GetCitiesByCountryID(int LanguageID, int CountryID)
        {
            DataSet ds;
            try
            {
                APEX.Cities obj = new APEX.Cities(LanguageID);
                ds = APEX.Cities.GetCitiesByCountry(CountryID,LanguageID);
            }
            catch (Exception)
            {
                ds = null;
                throw;
            }
            return ds.Tables[0];
        }
    }
}
