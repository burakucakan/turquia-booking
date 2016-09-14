using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class BannerPositions_ML {
	
		
		//	members
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intBannerPositionID;
		private SqlInt32 m_intLanguageID;
		private SqlString m_strTitle;
		private SqlString m_strDescription;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public BannerPositions_ML() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all BannerPositions_ML from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the BannerPositions_ML</returns>
		public static SqlDataReader GetAllBannerPositions_MLReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_BannerPositions_ML__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllBannerPositions_MLDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_BannerPositions_ML__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all BannerPositions_ML from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllBannerPositions_ML() {
			SqlDataReader dr = GetAllBannerPositions_MLReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates BannerPositions_ML for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the BannerPositions_ML records</param>
		/// <returns>The Hashtable containing BannerPositions_ML objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            BannerPositions_ML myBannerPositions_ML = new BannerPositions_ML();
            
            myBannerPositions_ML.m_intBannerPositionID = dr.GetSqlInt32(0);
            myBannerPositions_ML.m_intLanguageID = dr.GetSqlInt32(1);
            myBannerPositions_ML.m_strTitle = dr.GetSqlString(2);
            myBannerPositions_ML.m_strDescription = dr.GetSqlString(3);
		}
	
			return result;
		}
		
	
			/// <summary>
		/// The BannerPositionID column in the DB
		/// </summary>
		public int BannerPositionID {
			get {
				return (int)m_intBannerPositionID;
			}
			set {
				m_intBannerPositionID = value;
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
		/// The Title column in the DB
		/// </summary>
		public string Title {
			get {
				return (string)m_strTitle;
			}
			set {
				m_strTitle = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Description column in the DB
		/// </summary>
		public string Description {
			get {
				return (string)m_strDescription;
			}
			set {
				m_strDescription = value;
				m_bIsDirty = true;
			}
		}
		
		public static int Insert(int BannerPositionID, int LanguageID, string Title, string Description) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_BannerPositions_ML__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
					
			// parameter for BannerPositionID column
			param = new SqlParameter("@BannerPositionID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = BannerPositionID;
			cmd.Parameters.Add(param);
			
					
			// parameter for LanguageID column
			param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = LanguageID;
			cmd.Parameters.Add(param);
			
					
			// parameter for Title column
			param = new SqlParameter("@Title", SqlDbType.NVarChar, 128);
			param.Direction = ParameterDirection.Input;
			param.Value = Title;
			cmd.Parameters.Add(param);
			
					
			// parameter for Description column
			param = new SqlParameter("@Description", SqlDbType.NVarChar, 512);
			param.Direction = ParameterDirection.Input;
			param.Value = Description;
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
				SqlCommand cmd = DBHelper.getSprocCmd("proc_BannerPositions_ML__upd", conn);
			
				SqlParameter param;
			
				//	add return value param
				param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
				param.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(param);
			
				//	add params
		        // parameter for BannerPositionID column
        param = new SqlParameter("@BannerPositionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerPositionID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 512);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
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
		public static bool operator ==(BannerPositions_ML t1, BannerPositions_ML t2) {
			//	compare values
			if(t1.m_intBannerPositionID != t2.m_intBannerPositionID) {
				return false;	//	because "BannerPositionID" values are Not equal
			}
	
			if(t1.m_intLanguageID != t2.m_intLanguageID) {
				return false;	//	because "LanguageID" values are Not equal
			}
	
			if(t1.m_strTitle != t2.m_strTitle) {
				return false;	//	because "Title" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(BannerPositions_ML t1, BannerPositions_ML t2) {
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
				retValue.Append("    BannerPositionID = \"");
			retValue.Append(m_intBannerPositionID);
			retValue.Append("\"\n");
				retValue.Append("    LanguageID = \"");
			retValue.Append(m_intLanguageID);
			retValue.Append("\"\n");
				retValue.Append("    Title = \"");
			retValue.Append(m_strTitle);
			retValue.Append("\"\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
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
			if (!(o is BannerPositions_ML)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (BannerPositions_ML)o;
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
