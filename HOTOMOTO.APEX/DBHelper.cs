using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace HOTOMOTO.APEX {

    public static class DBHelper {
        
        /// <summary>
        /// Yeni bir SqlConnection instance'� d�nd�r�r.
        /// </summary>
        /// <returns>SqlConnection nesnesi.</returns>
        public static SqlConnection getConnection() {
            return new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        }
        
        /// <summary>
        /// �stenen stored procedure'un ismi ile, ilgili stored procedure'un, yeni bir instance'�n� yarat�p d�nd�r�r.
        /// </summary>
        /// <param name="strSprocName">Nesnesi istenen stored procedure'un ismi.</param>
        /// <param name="conn">Veritaban� ba�lant�s� nesnesi.</param>
        /// <returns>Yeni yarat�lan SQLCommand nesnesi.</returns>
        public static SqlCommand getSprocCmd(string strSprocName, SqlConnection conn) {
            SqlCommand cmd = new SqlCommand(strSprocName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

		/// <summary>
		/// �stenen stored procedure'un ismi ile, ilgili stored procedure'un, yeni bir instance'�n� yarat�p d�nd�r�r Transaction'l�.
		/// </summary>
		/// <param name="strSprocName">Nesnesi istenen stored procedure'un ismi.</param>
		/// <param name="conn">Veritaban� ba�lant�s� nesnesi.</param>
		/// <param name="transaction">Transaction nesnesi.</param>
		/// <returns>Yeni yarat�lan SQLCommand nesnesi.</returns>
		public static SqlCommand getSprocCmd(string strSprocName, SqlConnection conn, SqlTransaction transaction) {
			SqlCommand cmd = new SqlCommand(strSprocName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}
    }

}
