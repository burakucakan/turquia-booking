using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomProperties_ML {
	
		
		//	members
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRoomPropertyID;
		private SqlInt32 m_intLanguageID;
		private SqlString m_strProperty;
		private SqlString m_strDescription;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomProperties_ML() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomProperties_ML from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomProperties_ML</returns>
		public static SqlDataReader GetAllRoomProperties_MLReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomProperties_ML__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomProperties_MLDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomProperties_ML__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomProperties_ML from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomProperties_ML() {
			SqlDataReader dr = GetAllRoomProperties_MLReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomProperties_ML for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomProperties_ML records</param>
		/// <returns>The Hashtable containing RoomProperties_ML objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomProperties_ML myRoomProperties_ML = new RoomProperties_ML();
            
            myRoomProperties_ML.m_intRoomPropertyID = dr.GetSqlInt32(0);
            myRoomProperties_ML.m_intLanguageID = dr.GetSqlInt32(1);
            myRoomProperties_ML.m_strProperty = dr.GetSqlString(2);
            myRoomProperties_ML.m_strDescription = dr.GetSqlString(3);
		}
	
			return result;
		}
		
	
			/// <summary>
		/// The RoomPropertyID column in the DB
		/// </summary>
		public int RoomPropertyID {
			get {
				return (int)m_intRoomPropertyID;
			}
			set {
				m_intRoomPropertyID = value;
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
		/// The Property column in the DB
		/// </summary>
		public string Property {
			get {
				return (string)m_strProperty;
			}
			set {
				m_strProperty = value;
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
		
		public static int Insert(int RoomPropertyID, int LanguageID, string Property, string Description) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomProperties_ML__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
					
			// parameter for RoomPropertyID column
			param = new SqlParameter("@RoomPropertyID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = RoomPropertyID;
			cmd.Parameters.Add(param);
			
					
			// parameter for LanguageID column
			param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = LanguageID;
			cmd.Parameters.Add(param);
			
					
			// parameter for Property column
			param = new SqlParameter("@Property", SqlDbType.NVarChar, 127);
			param.Direction = ParameterDirection.Input;
			param.Value = Property;
			cmd.Parameters.Add(param);
			
					
			// parameter for Description column
			param = new SqlParameter("@Description", SqlDbType.NVarChar, 400);
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
				SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomProperties_ML__upd", conn);
			
				SqlParameter param;
			
				//	add return value param
				param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
				param.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(param);
			
				//	add params
		        // parameter for RoomPropertyID column
        param = new SqlParameter("@RoomPropertyID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPropertyID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for Property column
        param = new SqlParameter("@Property", SqlDbType.NVarChar, 127);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strProperty;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 400);
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
		public static bool operator ==(RoomProperties_ML t1, RoomProperties_ML t2) {
			//	compare values
			if(t1.m_intRoomPropertyID != t2.m_intRoomPropertyID) {
				return false;	//	because "RoomPropertyID" values are Not equal
			}
	
			if(t1.m_intLanguageID != t2.m_intLanguageID) {
				return false;	//	because "LanguageID" values are Not equal
			}
	
			if(t1.m_strProperty != t2.m_strProperty) {
				return false;	//	because "Property" values are Not equal
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
		public static bool operator !=(RoomProperties_ML t1, RoomProperties_ML t2) {
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
				retValue.Append("    RoomPropertyID = \"");
			retValue.Append(m_intRoomPropertyID);
			retValue.Append("\"\n");
				retValue.Append("    LanguageID = \"");
			retValue.Append(m_intLanguageID);
			retValue.Append("\"\n");
				retValue.Append("    Property = \"");
			retValue.Append(m_strProperty);
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
			if (!(o is RoomProperties_ML)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomProperties_ML)o;
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
