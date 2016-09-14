using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_Reservation {

        // Müþterinin Rezervasyonlarýný Getir 
        public static DataTable GetReservationByCustomerID(int LanguageID, int CustomerID, string UserID, string ReservationType) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetReservationByCustomerID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.VarChar, 9);
            param.Direction = ParameterDirection.Input;
            param.Value = UserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationType", SqlDbType.Char, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationType;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // Transfer Rezervasyonlarýný Getir
        public static DataTable GetTransferReservation(int LanguageID, int ReservationID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTransferReservation", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // Tour Rezervasyonlarýný Getir
        public static DataTable GetTourReservation(int LanguageID, int ReservationID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTourReservation", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // Room Rezervasyonlarýný Getir
        public static DataTable GetReservationRooms(int LanguageID, int ReservationID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetReservationRooms", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


        // Rezervasyondaki Kiþileri Getir
        public static DataTable GetReservationGuests(int ReservationID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetReservationGuests", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

    //    @LanguageID int,
    //@CustomerID int,
    //@ReservationType char(1),
    //@HotelID int,
    //@TourID int,
    //@PortID int,
    //@RoomID int,
    //@BookingStartDate datetime,
    //@BookingEndDate datetime,
    //@ReservationStartDate datetime,
    //@ReservationEndDate datetime,
    //@PageSize bigint,
    //@PageNumber bigint

        public static DataTable GetReservationsForApproval(int LanguageID, 
            int CustomerID, 
            string ReservationType,
            int HotelID,
            int TourID,
            int PortID,
            int RoomID,
            DateTime BookingStartDate,
            DateTime BookingEndDate,
            DateTime ReservationStartDate,
            DateTime ReservationEndDate,
            int PageSize,
            int PageNumber)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetReservationsForApproval", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationType", SqlDbType.Char, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = HotelID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TourID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PortID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PortID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoomID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BookingStartDate", SqlDbType.DateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = BookingStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BookingEndDate", SqlDbType.DateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = BookingEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationStartDate", SqlDbType.DateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationEndDate", SqlDbType.DateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageSize", SqlDbType.BigInt, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageSize;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageNumber", SqlDbType.BigInt, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageNumber;
            cmd.Parameters.Add(param);

            try
            {
                conn.Open();

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

        public static DataTable ReservationApproval(int ReservationID,
            int isApproved,
            string DisApprovalNote,
            DateTime ApprovalDate,
            double TotalPriceUSD,
            double TotalPriceEUR,
            double TotalPriceYTL,
            int isCredibility
            )
        {

            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_ReservationApproval", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isApproved", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = isApproved;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DisApprovalNote", SqlDbType.NVarChar , 255);
            param.Direction = ParameterDirection.Input;
            param.Value = DisApprovalNote;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ApprovalDate", SqlDbType.DateTime , 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ApprovalDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalPriceUSD", SqlDbType.Float, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TotalPriceUSD;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalPriceEUR", SqlDbType.Float, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TotalPriceEUR;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalPriceYTL", SqlDbType.Float, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TotalPriceYTL;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isCredibility", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = isCredibility;
            cmd.Parameters.Add(param);

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();

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

    }
}
