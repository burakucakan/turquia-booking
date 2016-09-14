using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom 
{
   public class SPExec_Customer
    {
        public static DataTable GetCustomerAddresses(int LanguageID, int CustomerID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetCustomerAddresses", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
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

       //cproc_GetCustomerAccessOptions
       public static DataTable GetCustomerAccessOptions(int LanguageID, int CustomerID)
       {
           SqlConnection conn = APEX.DBHelper.getConnection();
           SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetCustomerAccessOptions", conn);
           SqlDataAdapter da;
           SqlParameter param;
           DataTable dt = new DataTable();

           param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
           param.Direction = ParameterDirection.Input;
           param.Value = CustomerID;
           cmd.Parameters.Add(param);

           param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
           param.Direction = ParameterDirection.Input;
           param.Value = LanguageID;
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

       public static DataTable GetAccessTypesByMainTypeID(int LanguageID, int AccessMainTypeID)
       {
           SqlConnection conn = APEX.DBHelper.getConnection();
           SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetAccessOptionsByMainTypeID", conn);
           SqlDataAdapter da;
           SqlParameter param;
           DataTable dt = new DataTable();

           param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
           param.Direction = ParameterDirection.Input;
           param.Value = LanguageID;
           cmd.Parameters.Add(param);

           param = new SqlParameter("@AccessMainTypeID", SqlDbType.Int, 4);
           param.Direction = ParameterDirection.Input;
           param.Value = AccessMainTypeID;
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
