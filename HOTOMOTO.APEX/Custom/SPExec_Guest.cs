using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace HOTOMOTO.APEX.Custom {

    public class SPExec_Guest {

        /// <summary>
        /// �sme ve/veya soyada g�re ziyaret�ilerin listesini getirir.
        /// </summary>
        /// <param name="FirstName">Ziyaret�i ad�</param>
        /// <param name="LastName">Ziyaret�i soyad�</param>
        /// <returns>Ziyaret�i listesini DataTable olarak d�nd�r�r.</returns>
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
        /// Telefon numaras�na g�re ziyaret�ileri getirir.
        /// </summary>
        /// <param name="Telephone">Ziyaret�inin telefon numaras�</param>
        /// <returns>Ziyaret�i listesini DataTable olarak d�nd�r�r.</returns>
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
