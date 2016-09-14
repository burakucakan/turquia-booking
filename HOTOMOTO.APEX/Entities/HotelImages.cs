using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class HotelImages {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intHotelImageID;
		private SqlInt32 m_intHotelID;
		private SqlString m_strFilename;
		private SqlBoolean m_bolisDefault;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public HotelImages() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all HotelImages from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the HotelImages</returns>
		public static SqlDataReader GetAllHotelImagesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_HotelImages__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllHotelImagesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_HotelImages__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all HotelImages from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllHotelImages() {
			SqlDataReader dr = GetAllHotelImagesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates HotelImages for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the HotelImages records</param>
		/// <returns>The Hashtable containing HotelImages objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            HotelImages myHotelImages = new HotelImages();
            
            myHotelImages.m_intHotelImageID = dr.GetSqlInt32(0);
            myHotelImages.m_intHotelID = dr.GetSqlInt32(1);
            myHotelImages.m_strFilename = dr.GetSqlString(2);
            myHotelImages.m_bolisDefault = dr.GetSqlBoolean(3);
            
            result.Add(myHotelImages.HotelImageID, myHotelImages);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 HotelImageID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.HotelImageID = m_intHotelImageID;
				return pk;
			}
		}
			/// <summary>
		/// The HotelImageID column in the DB
		/// </summary>
		public int HotelImageID {
			get {
				return (int)m_intHotelImageID;
			}
			set {
				m_intHotelImageID = value;
				m_bIsDirty = true;
			}
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
		/// The Filename column in the DB
		/// </summary>
		public string Filename {
			get {
				return (string)m_strFilename;
			}
			set {
				m_strFilename = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isDefault column in the DB
		/// </summary>
		public bool isDefault {
			get {
				return (bool)m_bolisDefault;
			}
			set {
				m_bolisDefault = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.HotelImageID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intHotelImageID"> HotelImageID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intHotelImageID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_HotelImages__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for HotelImageID column
        param = new SqlParameter("@HotelImageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intHotelImageID;
        cmd.Parameters.Add(param);
        
		//	open connection
				conn.Open();
				//	Execute command And get reader
				SqlDataReader reader = cmd.ExecuteReader();
		
				bool found = false;	//	false solution
		
				//	check if  anything was found
				if(reader.Read()) {
					found = true;	//	corresponding row found
					m_aAction = Action.Update;	//	future action
		
					//	set member values
		            m_intHotelImageID = reader.GetSqlInt32(0);
            m_intHotelID = reader.GetSqlInt32(1);
            m_strFilename = reader.GetSqlString(2);
            m_bolisDefault = reader.GetSqlBoolean(3);
		
			} else {
					//	set key values
		            m_intHotelImageID = intHotelImageID;
	}
		
			//	close connection
			conn.Close();
			//	set dirty flag To false
			m_bIsDirty = false;
			//	return true if  a row found, otherwise false
			return found;
			
		}
		
		/// <summary>
		/// Updates the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Save() {
			int retValue;
			switch(m_aAction) {
				case Action.Insert:
					//	insert row
					retValue = ins();
					//	future action To be update
					m_aAction = Action.Update;
					//	return retValue from insert
					return retValue;
				case Action.Update:
					//	check if  Objectstringdirty
					if (m_bIsDirty)	{
						//	update row And return retValue
						return upd();
					} else {
						//	return 0 (all ok)
						return 0;
					}
				case Action.Delete:
					//	delete row
					retValue = del();
					//	future action To be insert
					m_aAction = Action.Insert;
					//	return retValue from delete
					return retValue;
			}
	
			throw new System.Exception("Unknown action.");
		}
	
		/// <summary>
		/// Updates the DB with transaction.
		/// </summary>
		/// <returns>0 if success</returns>	
		public int Save(SqlTransaction transaction) {	
            this.m_Transaction = transaction;
            return this.Save();
		}	
	
		/// <summary>
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Delete() {
			m_aAction = Action.Delete;	//	actionstringdelete
			return Save();
		}
	
		/// <summary>
		/// Deletes the Object from the DB with transaction.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Delete(SqlTransaction transaction) {
			m_aAction = Action.Delete;       //            actionstringdelete
			return Save(transaction);
		}
	
		//	private member functions
	
		/// <summary>
		/// Adds the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int ins() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
							cmd = DBHelper.getSprocCmd("proc_HotelImages__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_HotelImages__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for HotelImageID column
        param = new SqlParameter("@HotelImageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelImageID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for Filename column
        param = new SqlParameter("@Filename", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFilename;
        cmd.Parameters.Add(param);
        
        // parameter for isDefault column
        param = new SqlParameter("@isDefault", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDefault;
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
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
				cmd = DBHelper.getSprocCmd("proc_HotelImages__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_HotelImages__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for HotelImageID column
        param = new SqlParameter("@HotelImageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelImageID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for Filename column
        param = new SqlParameter("@Filename", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFilename;
        cmd.Parameters.Add(param);
        
        // parameter for isDefault column
        param = new SqlParameter("@isDefault", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDefault;
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
	
		/// <summary>
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int del() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
				cmd = DBHelper.getSprocCmd("proc_HotelImages__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_HotelImages__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for HotelImageID column
        param = new SqlParameter("@HotelImageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelImageID;
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
	
		//	operators
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator ==(HotelImages t1, HotelImages t2) {
			//	compare values
			if(t1.m_intHotelImageID != t2.m_intHotelImageID) {
				return false;	//	because "HotelImageID" values are Not equal
			}
	
			if(t1.m_intHotelID != t2.m_intHotelID) {
				return false;	//	because "HotelID" values are Not equal
			}
	
			if(t1.m_strFilename != t2.m_strFilename) {
				return false;	//	because "Filename" values are Not equal
			}
	
			if(t1.m_bolisDefault != t2.m_bolisDefault) {
				return false;	//	because "isDefault" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(HotelImages t1, HotelImages t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" HotelImageID = \"");
			retValue.Append(m_intHotelImageID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    HotelID = \"");
			retValue.Append(m_intHotelID);
			retValue.Append("\"\n");
				retValue.Append("    Filename = \"");
			retValue.Append(m_strFilename);
			retValue.Append("\"\n");
				retValue.Append("    isDefault = \"");
			retValue.Append(m_bolisDefault);
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
			if (!(o is HotelImages)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (HotelImages)o;
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
			m_aAction = Action.Insert;	//	initial action  
			m_bIsDirty = false;	//	Objectstring"clean" upon init
		}
	}
}
