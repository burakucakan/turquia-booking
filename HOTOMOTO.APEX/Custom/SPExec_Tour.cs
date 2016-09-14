using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_Tour {


        //Turlarý Getir  
        public static DataTable GetTours(int LanguageID, int CityID, DateTime ArrivalDate, DateTime DepartureDate, int TourType, int MinCapacity, string TourID, string TourName) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTours", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CityID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArrivalDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ArrivalDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DepartureDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = DepartureDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isDaily", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MinCapacity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = MinCapacity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TourID", SqlDbType.VarChar, 6);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TourName", SqlDbType.NVarChar, 128);
            param.Direction = ParameterDirection.Input;
            param.Value = TourName;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Hotel Rezervasyon Sayfasýndaki Turlarý Getir

        //Turlarý Getir  
        public static DataTable GetAllTours(int LanguageID, int TourType) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetAllTours", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isDaily", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourType;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Hotel Rezervasyon Sayfasýndaki Turlarý Getir

        public static DataTable GetToursWithDetails(int LanguageID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetToursWithDetails", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetTourImages(int TourID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTourImages", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // ID ile turu getir
        public static DataTable GetTour(int LanguageID, int TourID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTour", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetTourPropertiesByTourID(int LanguageID, int TourID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTourPropertiesByTourID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            try
            {

                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                throw ex;
            }

            return dt;
        }
       
        public static DataTable GetTourCitiesByTourID(int LanguageID, int TourID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTourCitiesByTourID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                throw ex;
            }

            return dt;
        }

        public static DataTable GetTourRecurrencesByTourID(int TourID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTourRecurrencesByTourID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                throw ex;
            }

            return dt;
        }


        public static int RemoveTourPropertiesByTourID(int TourID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemoveTourPropertiesByTourID", conn);

            SqlParameter param;
            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            conn.Open();
            int returnValue;
            try
            {
                returnValue = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }

            return returnValue;
        }

        public static int RemoveTourCitiesByTourID(int TourID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemoveTourCitiesByTourID", conn);

            SqlParameter param;
            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            conn.Open();
            int returnValue;
            try
            {
                returnValue = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }

            return returnValue;
        }

        public static int RemoveTourRecurrenceByTourID(int TourID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_RemoveTourRecurrenceByTourID", conn);

            SqlParameter param;
            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            conn.Open();
            int returnValue;
            try
            {
                returnValue = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }

            return returnValue;
        }


    }
}
