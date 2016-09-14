using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Errors_ML {
	
		
		//	members
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intErrorID;
		private SqlInt32 m_intLanguageID;
		private SqlString m_strErrorTitle;
		private SqlString m_strMessage;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Errors_ML() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Errors_ML from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Errors_ML</returns>
		public static SqlDataReader GetAllErrors_MLReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Errors_ML__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllErrors_MLDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Errors_ML__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Errors_ML from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllErrors_ML() {
			SqlDataReader dr = GetAllErrors_MLReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Errors_ML for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Errors_ML records</param>
		/// <returns>The Hashtable containing Errors_ML objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Errors_ML myErrors_ML = new Errors_ML();
            
            myErrors_ML.m_intErrorID = dr.GetSqlInt32(0);
            myErrors_ML.m_intLanguageID = dr.GetSqlInt32(1);
            myErrors_ML.m_strErrorTitle = dr.GetSqlString(2);
            myErrors_ML.m_strMessage = dr.GetSqlString(3);
		}
	
			return result;
		}
		
	
			/// <summary>
		/// The ErrorID column in the DB
		/// </summary>
		public int ErrorID {
			get {
				return (int)m_intErrorID;
			}
			set {
				m_intErrorID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The LanguageID column in the DB
		/// </summary>
		public int LanguageID {
			get {
				return (int)m_intLanguageID;
			}
			set {
				m_intLanguageID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ErrorTitle column in the DB
		/// </summary>
		public string ErrorTitle {
			get {
				return (string)m_strErrorTitle;
			}
			set {
				m_strErrorTitle = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Message column in the DB
		/// </summary>
		public string Message {
			get {
				return (string)m_strMessage;
			}
			set {
				m_strMessage = value;
				m_bIsDirty = true;
			}
		}
		
		public static int Insert(int ErrorID, int LanguageID, string ErrorTitle, string Message) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Errors_ML__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
					
			// parameter for ErrorID column
			param = new SqlParameter("@ErrorID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = ErrorID;
			cmd.Parameters.Add(param);
			
					
			// parameter for LanguageID column
			param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = LanguageID;
			cmd.Parameters.Add(param);
			
					
			// parameter for ErrorTitle column
			param = new SqlParameter("@ErrorTitle", SqlDbType.NVarChar, 512);
			param.Direction = ParameterDirection.Input;
			param.Value = ErrorTitle;
			cmd.Parameters.Add(param);
			
					
			// parameter for Message column
			param = new SqlParameter("@Message", SqlDbType.NVarChar, 2048);
			param.Direction = ParameterDirection.Input;
			param.Value = Message;
			cmd.Parameters.Add(param);
			
				
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			//m_bIsDirty = false;
		
			return retValue;
		}
		
		
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Update() {
			if(m_bIsDirty) {
				//	construct new connection and command objects
				SqlConnection conn = DBHelper.getConnection();
				SqlCommand cmd = DBHelper.getSprocCmd("proc_Errors_ML__upd", conn);
			
				SqlParameter param;
			
				//	add return value param
				param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
				param.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(param);
			
				//	add params
		        // parameter for ErrorID column
        param = new SqlParameter("@ErrorID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intErrorID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for ErrorTitle column
        param = new SqlParameter("@ErrorTitle", SqlDbType.NVarChar, 512);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strErrorTitle;
        cmd.Parameters.Add(param);
        
        // parameter for Message column
        param = new SqlParameter("@Message", SqlDbType.NVarChar, 2048);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strMessage;
        cmd.Parameters.Add(param);
        
				//	open connection
				conn.Open();
				//	Execute command
				cmd.ExecuteNonQuery();
				//	get return value
				int retValue = 0;
				try {
					//	get return value of the sproc
					retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
				} catch(System.Exception) {	//	catch all possible exceptions
					retValue = 0;	//	set retValue To 0 (all ok)
				}
				
				//	close connection
				conn.Close();
			
				//	set dirty flag To false
				m_bIsDirty = false;
			
				return retValue;
			}
			return 0;
		}
		//	operators
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator ==(Errors_ML t1, Errors_ML t2) {
			//	compare values
			if(t1.m_intErrorID != t2.m_intErrorID) {
				return false;	//	because "ErrorID" values are Not equal
			}
	
			if(t1.m_intLanguageID != t2.m_intLanguageID) {
				return false;	//	because "LanguageID" values are Not equal
			}
	
			if(t1.m_strErrorTitle != t2.m_strErrorTitle) {
				return false;	//	because "ErrorTitle" values are Not equal
			}
	
			if(t1.m_strMessage != t2.m_strMessage) {
				return false;	//	because "Message" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Errors_ML t1, Errors_ML t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
			
			retValue.Append("Columns:\n");
				retValue.Append("    ErrorID = \"");
			retValue.Append(m_intErrorID);
			retValue.Append("\"\n");
				retValue.Append("    LanguageID = \"");
			retValue.Append(m_intLanguageID);
			retValue.Append("\"\n");
				retValue.Append("    ErrorTitle = \"");
			retValue.Append(m_strErrorTitle);
			retValue.Append("\"\n");
				retValue.Append("    Message = \"");
			retValue.Append(m_strMessage);
			retValue.Append("\"\n");
				return retValue.ToString();
		}
	
		/// <summary>
		/// Overrides the Equals Function.
		/// </summary>
		/// <param name="o">The Object To compare With</param>
		/// <returns>Bool if the two objects are identical.</returns>
		public override bool Equals(System.Object o) {
			//	check the type of o
			if (!(o is Errors_ML)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Errors_ML)o;
		}
	
		/// <summary>
		/// Overrides the GetHashCode Function.
		/// </summary>
		/// <returns>Bool if the two objects are identical.</returns>
		public override int GetHashCode() {
			return this.ToString().GetHashCode();
		}
		
		
		
		
			
		/// <summary>
		/// The init Function.
		/// </summary>
		private void Init() {
		 
			m_bIsDirty = false;	//	Objectstring"clean" upon init
		}
	}
}
