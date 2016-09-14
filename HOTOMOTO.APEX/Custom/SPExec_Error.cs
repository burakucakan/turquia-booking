using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_Error {

        //Hata Mesajýný Dönder
        public DataTable GetError(int LanguageID, int ErrorTypeID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetError", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ErrorTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ErrorTypeID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Hata Mesajýný Dönder

    }
}
