using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom
{
    public class SPExec_Help
    {

        // Rasgele Ýpucu Getir
        public static DataTable GetRandomTip(int LanguageID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetRandomTip", conn);
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
