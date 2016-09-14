using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HOTOMOTO.APEX
{
    public class SpRunner
    {

        public static SqlDataReader Paramsel(string TableName)
        {
            return Paramsel(TableName, 0, 0, "", "", "");
        }
        public static SqlDataReader Paramsel(string TableName, int RowStart, int RowLimit)
        {
            return Paramsel(TableName, RowStart, RowLimit, "", "", "");
        }
        public static SqlDataReader Paramsel(string TableName, int RowStart, int RowLimit, string Columns, string WhereClause, string OrderParameter)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_Paramsel", conn);
            SqlParameter param;

            if (Columns != "")
            {
                param = new SqlParameter("@Columns", SqlDbType.NVarChar, 1024);
                param.Direction = ParameterDirection.Input;
                param.Value = Columns.ToString();
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@TableName", SqlDbType.NVarChar, 100);
            param.Direction = ParameterDirection.Input;
            param.Value = TableName.ToString();
            cmd.Parameters.Add(param);

            if(WhereClause != "")
            {
                param = new SqlParameter("@WhereClause", SqlDbType.NVarChar, 1024);
                param.Direction = ParameterDirection.Input;
                param.Value = WhereClause.ToString();
                cmd.Parameters.Add(param);
            }

            if(OrderParameter != "")
            {
                param = new SqlParameter("@OrderParameter", SqlDbType.NVarChar, 256);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderParameter.ToString();
                cmd.Parameters.Add(param);
            }

            if (RowStart > 0)
            {
                param = new SqlParameter("@RowStart", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = RowStart.ToString();
                cmd.Parameters.Add(param);
            }

            if (RowLimit > 0)
            {
                param = new SqlParameter("@RowLimit", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = RowLimit.ToString();
                cmd.Parameters.Add(param);
            }

            conn.Open();
            SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Reader;
        }

        /// <summary>
        /// Parametre olarak verilen euro ve dolar de�erlerini veritaban�ndaki de�erler 
        /// ile kar��la�t�r�r. E�er kendisine e�it olan bir de�er bulursa o kay�t�n 
        /// PriceID de�erini d�nd�r�r. Yoksa yeni kay�t ekler ve yeni kay�t�n PriceID 
        /// de�erini d�nd�r�r.
        /// </summary>
        /// <param name="USDPrice">�cretin Amerikan Dolar� de�eri.</param>
        /// <param name="EURPrice">�cretin Euro de�eri.</param>
        /// <returns>Fiyatlar�n varoldu�u sat�r�n PriceID de�erini d�nd�r�r.</returns>
        public static int AddPrice(double USDPrice, double EURPrice) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_AddPrice", conn);
            
            SqlParameter param;
            param = new SqlParameter("@ReturnValue", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@USDPrice", SqlDbType.Float);
            param.Direction = ParameterDirection.Input;
            param.Value = USDPrice;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EURPrice", SqlDbType.Float);
            param.Direction = ParameterDirection.Input;
            param.Value = EURPrice;
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.ExecuteNonQuery();
            int returnValue = (int)cmd.Parameters["@ReturnValue"].Value;
            conn.Close();

            return returnValue;
        }
    }
}
