using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class PackagedRooms {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intPackagedRoomID;
		private SqlInt32 m_intPackageID;
		private SqlInt32 m_intRoomID;
		private SqlInt32 m_intNights;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public PackagedRooms() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all PackagedRooms from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the PackagedRooms</returns>
		public static SqlDataReader GetAllPackagedRoomsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedRooms__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllPackagedRoomsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedRooms__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all PackagedRooms from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllPackagedRooms() {
			SqlDataReader dr = GetAllPackagedRoomsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates PackagedRooms for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the PackagedRooms records</param>
		/// <returns>The Hashtable containing PackagedRooms objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            PackagedRooms myPackagedRooms = new PackagedRooms();
            
            myPackagedRooms.m_intPackagedRoomID = dr.GetSqlInt32(0);
            myPackagedRooms.m_intPackageID = dr.GetSqlInt32(1);
            myPackagedRooms.m_intRoomID = dr.GetSqlInt32(2);
            myPackagedRooms.m_intNights = dr.GetSqlInt32(3);
            
            result.Add(myPackagedRooms.PackagedRoomID, myPackagedRooms);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 PackagedRoomID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.PackagedRoomID = m_intPackagedRoomID;
				return pk;
			}
		}
			/// <summary>
		/// The PackagedRoomID column in the DB
		/// </summary>
		public int PackagedRoomID {
			get {
				return (int)m_intPackagedRoomID;
			}
			set {
				m_intPackagedRoomID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PackageID column in the DB
		/// </summary>
		public int PackageID {
			get {
				return (int)m_intPackageID;
			}
			set {
				m_intPackageID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The RoomID column in the DB
		/// </summary>
		public int RoomID {
			get {
				return (int)m_intRoomID;
			}
			set {
				m_intRoomID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Nights column in the DB
		/// </summary>
		public int Nights {
			get {
				return (int)m_intNights;
			}
			set {
				m_intNights = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.PackagedRoomID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intPackagedRoomID"> PackagedRoomID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intPackagedRoomID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedRooms__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for PackagedRoomID column
        param = new SqlParameter("@PackagedRoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intPackagedRoomID;
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
		            m_intPackagedRoomID = reader.GetSqlInt32(0);
            m_intPackageID = reader.GetSqlInt32(1);
            m_intRoomID = reader.GetSqlInt32(2);
            m_intNights = reader.GetSqlInt32(3);
		
			} else {
					//	set key values
		            m_intPackagedRoomID = intPackagedRoomID;
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
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Delete() {
			m_aAction = Action.Delete;	//	actionstringdelete
			return Save();
		}
	
		//	private member functions
	
		/// <summary>
		/// Adds the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int ins() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedRooms__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PackagedRoomID column
        param = new SqlParameter("@PackagedRoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackagedRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for PackageID column
        param = new SqlParameter("@PackageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackageID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for Nights column
        param = new SqlParameter("@Nights", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intNights;
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
			SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedRooms__upd", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for PackagedRoomID column
        param = new SqlParameter("@PackagedRoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackagedRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for PackageID column
        param = new SqlParameter("@PackageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackageID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for Nights column
        param = new SqlParameter("@Nights", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intNights;
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
			SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedRooms__del", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PackagedRoomID column
        param = new SqlParameter("@PackagedRoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackagedRoomID;
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
		public static bool operator ==(PackagedRooms t1, PackagedRooms t2) {
			//	compare values
			if(t1.m_intPackagedRoomID != t2.m_intPackagedRoomID) {
				return false;	//	because "PackagedRoomID" values are Not equal
			}
	
			if(t1.m_intPackageID != t2.m_intPackageID) {
				return false;	//	because "PackageID" values are Not equal
			}
	
			if(t1.m_intRoomID != t2.m_intRoomID) {
				return false;	//	because "RoomID" values are Not equal
			}
	
			if(t1.m_intNights != t2.m_intNights) {
				return false;	//	because "Nights" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(PackagedRooms t1, PackagedRooms t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" PackagedRoomID = \"");
			retValue.Append(m_intPackagedRoomID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    PackageID = \"");
			retValue.Append(m_intPackageID);
			retValue.Append("\"\n");
				retValue.Append("    RoomID = \"");
			retValue.Append(m_intRoomID);
			retValue.Append("\"\n");
				retValue.Append("    Nights = \"");
			retValue.Append(m_intNights);
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
			if (!(o is PackagedRooms)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (PackagedRooms)o;
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
