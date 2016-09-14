using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HOTOMOTO.BUS {
    public class Tour {

        //Hotel Rezervasyon Sayfasýndaki Turlarý Getir Sadece ID     
        public static DataTable GetTours(int LanguageID, string CityID, DateTime ArrivalDate, DateTime DepartureDate, HOTOMOTO.BUS.Enumerations.TourTypes TourType, int MinCapacity, string TourID) {
            return GetTours(LanguageID, CityID, ArrivalDate, DepartureDate, TourType, MinCapacity, TourID, "%");
        }

        //Hotel Rezervasyon Sayfasýndaki Turlarý Getir Tur ID siz ve Tur Adýsýz           
        public static DataTable GetTours(int LanguageID, string CityID, DateTime ArrivalDate, DateTime DepartureDate, HOTOMOTO.BUS.Enumerations.TourTypes TourType, int MinCapacity) {
            return GetTours(LanguageID, CityID, ArrivalDate, DepartureDate, TourType, MinCapacity, "%", "%");
        }

        //Turlarý Getir      
        public static DataTable GetTours(int LanguageID, string CityID, DateTime ArrivalDate, DateTime DepartureDate, HOTOMOTO.BUS.Enumerations.TourTypes TourType, int MinCapacity, string TourID, string TourName) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Tour.GetTours(LanguageID, int.Parse(CityID), ArrivalDate, DepartureDate, (int)TourType, MinCapacity, TourID, TourName);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Hotel Rezervasyon Sayfasýndaki Turlarý Getir

        //Tüm Turlarý Getir      
        public static DataTable GetAllTours(int LanguageID, HOTOMOTO.BUS.Enumerations.TourTypes TourType) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Tour.GetAllTours(LanguageID, (int)TourType);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }//Hotel Rezervasyon Sayfasýndaki Turlarý Getir

        public static DataTable GetToursWithDetails(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Tour.GetToursWithDetails(LanguageID);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetTourImages(int TourID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_Tour.GetTourImages(TourID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetTour(int LanguageID, int TourID)
        {
            DataTable dt;
            try
            {
                dt = APEX.Custom.SPExec_Tour.GetTour(LanguageID, TourID);
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