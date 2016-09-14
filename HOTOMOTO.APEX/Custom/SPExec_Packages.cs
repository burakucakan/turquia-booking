using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HOTOMOTO.APEX.Custom {
    public class SPExec_Packages {

        //Favori Otelleri Getir  
        public static DataTable GetFavoriteHotels(int CustomerID, int UserID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetFavoriteHotels", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = UserID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Favori Otelleri Getir  

    }
}
