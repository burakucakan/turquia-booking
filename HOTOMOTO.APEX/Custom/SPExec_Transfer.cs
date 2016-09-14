using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_Transfer {

        //Ülkeye Göre Portlar
        public static DataTable GetPorts(int LanguageID, int CountryID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetPorts", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CountryID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Ülkeye Göre Portlar
    
        //Transfer için Regular ve Private Ödenecek Fiyatlarý Getirme
        public static DataTable GetTransferRegularPrivatePrices(int Capacity, int CustomerID, int CurrencyID, DateTime ReservationDate) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTransferRegularPrivatePrices", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@Capacity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Capacity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CurrencyID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Capacity;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ReservationDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ReservationDate;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Transfer için Regular ve Private Ödenecek Fiyatlarý Getirme

        //Transfer Fiyatlarýný Getir
        public static DataTable GetTransferPrices(int CustomerID, int Capacity) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTransferPrices", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Capacity", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Capacity;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Transfer Fiyatlarýný Getir

        //PortID = 0 olunca tüm transferleri getirir. Ayrýca pasifleri de getirir.
        public static DataTable GetPortDetails(int LanguageID, int PortID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetPortDetail", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PortID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PortID;
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

        //[cproc_GetPortAddresses]
        public static DataTable GetPortAddresses(int LanguageID, int PortID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetPortAddresses", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PortID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PortID;
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

        public static DataTable  GetTransferPriceListPrices(int TransferPriceListID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTransferPriceListPrices", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@TransferPriceListID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TransferPriceListID;
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

        public static DataTable GetTransferPriceListCustomers(int TransferPriceListID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetTransferPriceListCustomers", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@TransferPriceListID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = TransferPriceListID;
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

    }
}
