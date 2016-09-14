using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomBedPreferences_ML {
	
		
		//	members
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRoomBedPreferenceID;
		private SqlInt32 m_intLanguageID;
		private SqlString m_strBedType;
		private SqlString m_strShortBedType;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomBedPreferences_ML() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomBedPreferences_ML from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomBedPreferences_ML</returns>
		public static SqlDataReader GetAllRoomBedPreferences_MLReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomBedPreferences_ML__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomBedPreferences_MLDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomBedPreferences_ML__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomBedPreferences_ML from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomBedPreferences_ML() {
			SqlDataReader dr = GetAllRoomBedPreferences_MLReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomBedPreferences_ML for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomBedPreferences_ML records</param>
		/// <returns>The Hashtable containing RoomBedPreferences_ML objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomBedPreferences_ML myRoomBedPreferences_ML = new RoomBedPreferences_ML();
            
            myRoomBedPreferences_ML.m_intRoomBedPreferenceID = dr.GetSqlInt32(0);
            myRoomBedPreferences_ML.m_intLanguageID = dr.GetSqlInt32(1);
            myRoomBedPreferences_ML.m_strBedType = dr.GetSqlString(2);
            myRoomBedPreferences_ML.m_strShortBedType = dr.GetSqlString(3);
		}
	
			return result;
		}
		
	
			/// <summary>
		/// The RoomBedPreferenceID column in the DB
		/// </summary>
		public int RoomBedPreferenceID {
			get {
				return (int)m_intRoomBedPreferenceID;
			}
			set {
				m_intRoomBedPreferenceID = value;
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
		/// The BedType column in the DB
		/// </summary>
		public string BedType {
			get {
				return (string)m_strBedType;
			}
			set {
				m_strBedType = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ShortBedType column in the DB
		/// </summary>
		public string ShortBedType {
			get {
				return (string)m_strShortBedType;
			}
			set {
				m_strShortBedType = value;
				m_bIsDirty = true;
			}
		}
		
		public static int Insert(int RoomBedPreferenceID, int LanguageID, string BedType, string ShortBedType) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomBedPreferences_ML__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
					
			// parameter for RoomBedPreferenceID column
			param = new SqlParameter("@RoomBedPreferenceID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = RoomBedPreferenceID;
			cmd.Parameters.Add(param);
			
					
			// parameter for LanguageID column
			param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = LanguageID;
			cmd.Parameters.Add(param);
			
					
			// parameter for BedType column
			param = new SqlParameter("@BedType", SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Input;
			param.Value = BedType;
			cmd.Parameters.Add(param);
			
					
			// parameter for ShortBedType column
			param = new SqlParameter("@ShortBedType", SqlDbType.NVarChar, 16);
			param.Direction = ParameterDirection.Input;
			param.Value = ShortBedType;
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
				SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomBedPreferences_ML__upd", conn);
			
				SqlParameter param;
			
				//	add return value param
				param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
				param.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(param);
			
				//	add params
		        // parameter for RoomBedPreferenceID column
        param = new SqlParameter("@RoomBedPreferenceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomBedPreferenceID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for BedType column
        param = new SqlParameter("@BedType", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strBedType;
        cmd.Parameters.Add(param);
        
        // parameter for ShortBedType column
        param = new SqlParameter("@ShortBedType", SqlDbType.NVarChar, 16);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strShortBedType;
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
		public static bool operator ==(RoomBedPreferences_ML t1, RoomBedPreferences_ML t2) {
			//	compare values
			if(t1.m_intRoomBedPreferenceID != t2.m_intRoomBedPreferenceID) {
				return false;	//	because "RoomBedPreferenceID" values are Not equal
			}
	
			if(t1.m_intLanguageID != t2.m_intLanguageID) {
				return false;	//	because "LanguageID" values are Not equal
			}
	
			if(t1.m_strBedType != t2.m_strBedType) {
				return false;	//	because "BedType" values are Not equal
			}
	
			if(t1.m_strShortBedType != t2.m_strShortBedType) {
				return false;	//	because "ShortBedType" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(RoomBedPreferences_ML t1, RoomBedPreferences_ML t2) {
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
				retValue.Append("    RoomBedPreferenceID = \"");
			retValue.Append(m_intRoomBedPreferenceID);
			retValue.Append("\"\n");
				retValue.Append("    LanguageID = \"");
			retValue.Append(m_intLanguageID);
			retValue.Append("\"\n");
				retValue.Append("    BedType = \"");
			retValue.Append(m_strBedType);
			retValue.Append("\"\n");
				retValue.Append("    ShortBedType = \"");
			retValue.Append(m_strShortBedType);
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
			if (!(o is RoomBedPreferences_ML)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomBedPreferences_ML)o;
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
