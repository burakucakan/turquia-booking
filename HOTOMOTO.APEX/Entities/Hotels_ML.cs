using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Hotels_ML {
	
		
		//	members
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intHotelID;
		private SqlInt32 m_intLanguageID;
		private SqlString m_strHotelName;
		private SqlString m_strDescription;
		private SqlString m_strMotto;
		private SqlString m_strDirections;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Hotels_ML() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Hotels_ML from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Hotels_ML</returns>
		public static SqlDataReader GetAllHotels_MLReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Hotels_ML__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllHotels_MLDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Hotels_ML__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Hotels_ML from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllHotels_ML() {
			SqlDataReader dr = GetAllHotels_MLReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Hotels_ML for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Hotels_ML records</param>
		/// <returns>The Hashtable containing Hotels_ML objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Hotels_ML myHotels_ML = new Hotels_ML();
            
            myHotels_ML.m_intHotelID = dr.GetSqlInt32(0);
            myHotels_ML.m_intLanguageID = dr.GetSqlInt32(1);
            myHotels_ML.m_strHotelName = dr.GetSqlString(2);
            myHotels_ML.m_strDescription = dr.GetSqlString(3);
            myHotels_ML.m_strMotto = dr.GetSqlString(4);
            myHotels_ML.m_strDirections = dr.GetSqlString(5);
		}
	
			return result;
		}
		
	
			/// <summary>
		/// The HotelID column in the DB
		/// </summary>
		public int HotelID {
			get {
				return (int)m_intHotelID;
			}
			set {
				m_intHotelID = value;
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
		/// The HotelName column in the DB
		/// </summary>
		public string HotelName {
			get {
				return (string)m_strHotelName;
			}
			set {
				m_strHotelName = value;
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
			/// <summary>
		/// The Motto column in the DB
		/// </summary>
		public string Motto {
			get {
				return (string)m_strMotto;
			}
			set {
				m_strMotto = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Directions column in the DB
		/// </summary>
		public string Directions {
			get {
				return (string)m_strDirections;
			}
			set {
				m_strDirections = value;
				m_bIsDirty = true;
			}
		}
		
		public static int Insert(int HotelID, int LanguageID, string HotelName, string Description, string Motto, string Directions) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Hotels_ML__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
					
			// parameter for HotelID column
			param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = HotelID;
			cmd.Parameters.Add(param);
			
					
			// parameter for LanguageID column
			param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = LanguageID;
			cmd.Parameters.Add(param);
			
					
			// parameter for HotelName column
			param = new SqlParameter("@HotelName", SqlDbType.NVarChar, 127);
			param.Direction = ParameterDirection.Input;
			param.Value = HotelName;
			cmd.Parameters.Add(param);
			
					
			// parameter for Description column
			param = new SqlParameter("@Description", SqlDbType.NVarChar, 2047);
			param.Direction = ParameterDirection.Input;
			param.Value = Description;
			cmd.Parameters.Add(param);
			
					
			// parameter for Motto column
			param = new SqlParameter("@Motto", SqlDbType.NVarChar, 255);
			param.Direction = ParameterDirection.Input;
			param.Value = Motto;
			cmd.Parameters.Add(param);
			
					
			// parameter for Directions column
			param = new SqlParameter("@Directions", SqlDbType.NVarChar, 255);
			param.Direction = ParameterDirection.Input;
			param.Value = Directions;
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
				SqlCommand cmd = DBHelper.getSprocCmd("proc_Hotels_ML__upd", conn);
			
				SqlParameter param;
			
				//	add return value param
				param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
				param.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(param);
			
				//	add params
		        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelName column
        param = new SqlParameter("@HotelName", SqlDbType.NVarChar, 127);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strHotelName;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 2047);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for Motto column
        param = new SqlParameter("@Motto", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strMotto;
        cmd.Parameters.Add(param);
        
        // parameter for Directions column
        param = new SqlParameter("@Directions", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDirections;
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
		public static bool operator ==(Hotels_ML t1, Hotels_ML t2) {
			//	compare values
			if(t1.m_intHotelID != t2.m_intHotelID) {
				return false;	//	because "HotelID" values are Not equal
			}
	
			if(t1.m_intLanguageID != t2.m_intLanguageID) {
				return false;	//	because "LanguageID" values are Not equal
			}
	
			if(t1.m_strHotelName != t2.m_strHotelName) {
				return false;	//	because "HotelName" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			if(t1.m_strMotto != t2.m_strMotto) {
				return false;	//	because "Motto" values are Not equal
			}
	
			if(t1.m_strDirections != t2.m_strDirections) {
				return false;	//	because "Directions" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Hotels_ML t1, Hotels_ML t2) {
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
				retValue.Append("    HotelID = \"");
			retValue.Append(m_intHotelID);
			retValue.Append("\"\n");
				retValue.Append("    LanguageID = \"");
			retValue.Append(m_intLanguageID);
			retValue.Append("\"\n");
				retValue.Append("    HotelName = \"");
			retValue.Append(m_strHotelName);
			retValue.Append("\"\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
			retValue.Append("\"\n");
				retValue.Append("    Motto = \"");
			retValue.Append(m_strMotto);
			retValue.Append("\"\n");
				retValue.Append("    Directions = \"");
			retValue.Append(m_strDirections);
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
			if (!(o is Hotels_ML)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Hotels_ML)o;
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
