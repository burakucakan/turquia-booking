using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace HOTOMOTO.APEX {

    public static class DBHelper {
        
        /// <summary>
        /// Yeni bir SqlConnection instance'ý döndürür.
        /// </summary>
        /// <returns>SqlConnection nesnesi.</returns>
        public static SqlConnection getConnection() {
            return new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        }
        
        /// <summary>
        /// Ýstenen stored procedure'un ismi ile, ilgili stored procedure'un, yeni bir instance'ýný yaratýp döndürür.
        /// </summary>
        /// <param name="strSprocName">Nesnesi istenen stored procedure'un ismi.</param>
        /// <param name="conn">Veritabaný baðlantýsý nesnesi.</param>
        /// <returns>Yeni yaratýlan SQLCommand nesnesi.</returns>
        public static SqlCommand getSprocCmd(string strSprocName, SqlConnection conn) {
            SqlCommand cmd = new SqlCommand(strSprocName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

		/// <summary>
		/// Ýstenen stored procedure'un ismi ile, ilgili stored procedure'un, yeni bir instance'ýný yaratýp döndürür Transaction'lý.
		/// </summary>
		/// <param name="strSprocName">Nesnesi istenen stored procedure'un ismi.</param>
		/// <param name="conn">Veritabaný baðlantýsý nesnesi.</param>
		/// <param name="transaction">Transaction nesnesi.</param>
		/// <returns>Yeni yaratýlan SQLCommand nesnesi.</returns>
		public static SqlCommand getSprocCmd(string strSprocName, SqlConnection conn, SqlTransaction transaction) {
			SqlCommand cmd = new SqlCommand(strSprocName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}
    }

}
