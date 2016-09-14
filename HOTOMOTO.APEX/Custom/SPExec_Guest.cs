using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace HOTOMOTO.APEX.Custom {

    public class SPExec_Guest {

        /// <summary>
        /// Ýsme ve/veya soyada göre ziyaretçilerin listesini getirir.
        /// </summary>
        /// <param name="FirstName">Ziyaretçi adý</param>
        /// <param name="LastName">Ziyaretçi soyadý</param>
        /// <returns>Ziyaretçi listesini DataTable olarak döndürür.</returns>
        public static DataTable FindGuestByName(string FirstName, string LastName) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_FindGuestByName", conn);
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            SqlParameter param;

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 32);
            param.Direction = ParameterDirection.Input;
            param.Value = FirstName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastName", SqlDbType.NVarChar, 32);
            param.Direction = ParameterDirection.Input;
            param.Value = LastName;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Telefon numarasýna göre ziyaretçileri getirir.
        /// </summary>
        /// <param name="Telephone">Ziyaretçinin telefon numarasý</param>
        /// <returns>Ziyaretçi listesini DataTable olarak döndürür.</returns>
        public static DataTable FindGuestByPhone(string Telephone) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_FindGuestByPhone", conn);
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            SqlParameter param;

            param = new SqlParameter("@Telephone", SqlDbType.NVarChar, 32);
            param.Direction = ParameterDirection.Input;
            param.Value = Telephone;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }

}
