using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_Payment {

        // M��terinin Kredibilitesini Getir 
        public static DataTable GetCredibilityByCustomerID(int CustomerID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetCredibilityByCustomerID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // M��terinin Kredibilitesini G�ncelle 
        public static void UpdateCrediLimit(int CustomerID, float NewCredibility) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_UpdateCustomerCredibility", conn);

            SqlParameter param;

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NewCredibility", SqlDbType.Float, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = NewCredibility;
            cmd.Parameters.Add(param);

            conn.Open();

            cmd.ExecuteNonQuery();
        }

        // Kay�tl� Kredi Kartlar�n� Getir 
        public static DataTable GetSavedCreditCards(int CustomerID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetSavedCreditCards", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // Kredi Kart� Daha �nce Kaydedilmi� mi 
        public static int ExistCreditCard(string CreditCardNO) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_ExistCreditCard", conn);

            SqlParameter param;

            param = new SqlParameter("@CreditCardNO", SqlDbType.VarChar, 128);
            param.Direction = ParameterDirection.Input;
            param.Value = CreditCardNO;
            cmd.Parameters.Add(param);

            conn.Open();

            object Ctrl = cmd.ExecuteScalar();

            if (Ctrl!=null) {
                return Convert.ToInt16(Ctrl);
            }
            else {
                return 0;
            }
        }

        // �deme Sayfas�ndaki �deme Se�eneklerini G�ster
        public static DataTable GetPaymentTypesForPaymentPage(int LanguageID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetPaymentTypesForPaymentPage", conn);
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
    }
}
