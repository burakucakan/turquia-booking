using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomPriceListPrices {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRoomPriceListPriceID;
		private SqlInt32 m_intRoomPriceListID;
		private SqlInt32 m_intRoomID;
		private SqlByte m_bytCapacity;
		private SqlDateTime m_dtDay;
		private SqlInt32 m_intPriceID;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomPriceListPrices() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomPriceListPrices from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomPriceListPrices</returns>
		public static SqlDataReader GetAllRoomPriceListPricesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomPriceListPricesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomPriceListPrices from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomPriceListPrices() {
			SqlDataReader dr = GetAllRoomPriceListPricesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomPriceListPrices for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomPriceListPrices records</param>
		/// <returns>The Hashtable containing RoomPriceListPrices objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomPriceListPrices myRoomPriceListPrices = new RoomPriceListPrices();
            
            myRoomPriceListPrices.m_intRoomPriceListPriceID = dr.GetSqlInt32(0);
            myRoomPriceListPrices.m_intRoomPriceListID = dr.GetSqlInt32(1);
            myRoomPriceListPrices.m_intRoomID = dr.GetSqlInt32(2);
            myRoomPriceListPrices.m_bytCapacity = dr.GetSqlByte(3);
            myRoomPriceListPrices.m_dtDay = dr.GetSqlDateTime(4);
            myRoomPriceListPrices.m_intPriceID = dr.GetSqlInt32(5);
            
            result.Add(myRoomPriceListPrices.RoomPriceListPriceID, myRoomPriceListPrices);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 RoomPriceListPriceID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.RoomPriceListPriceID = m_intRoomPriceListPriceID;
				return pk;
			}
		}
			/// <summary>
		/// The RoomPriceListPriceID column in the DB
		/// </summary>
		public int RoomPriceListPriceID {
			get {
				return (int)m_intRoomPriceListPriceID;
			}
			set {
				m_intRoomPriceListPriceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The RoomPriceListID column in the DB
		/// </summary>
		public int RoomPriceListID {
			get {
				return (int)m_intRoomPriceListID;
			}
			set {
				m_intRoomPriceListID = value;
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
		/// The Capacity column in the DB
		/// </summary>
		public byte Capacity {
			get {
				return (byte)m_bytCapacity;
			}
			set {
				m_bytCapacity = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Day column in the DB
		/// </summary>
		public DateTime Day {
			get {
				return (DateTime)m_dtDay;
			}
			set {
				m_dtDay = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PriceID column in the DB
		/// </summary>
		public int PriceID {
			get {
				return (int)m_intPriceID;
			}
			set {
				m_intPriceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.RoomPriceListPriceID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intRoomPriceListPriceID"> RoomPriceListPriceID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intRoomPriceListPriceID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for RoomPriceListPriceID column
        param = new SqlParameter("@RoomPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRoomPriceListPriceID;
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
		            m_intRoomPriceListPriceID = reader.GetSqlInt32(0);
            m_intRoomPriceListID = reader.GetSqlInt32(1);
            m_intRoomID = reader.GetSqlInt32(2);
            m_bytCapacity = reader.GetSqlByte(3);
            m_dtDay = reader.GetSqlDateTime(4);
            m_intPriceID = reader.GetSqlInt32(5);
		
			} else {
					//	set key values
		            m_intRoomPriceListPriceID = intRoomPriceListPriceID;
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
							cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomPriceListPriceID column
        param = new SqlParameter("@RoomPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomPriceListID column
        param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for Capacity column
        param = new SqlParameter("@Capacity", SqlDbType.TinyInt, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bytCapacity;
        cmd.Parameters.Add(param);
        
        // parameter for Day column
        param = new SqlParameter("@Day", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtDay;
        cmd.Parameters.Add(param);
        
        // parameter for PriceID column
        param = new SqlParameter("@PriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPriceID;
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
				cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for RoomPriceListPriceID column
        param = new SqlParameter("@RoomPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomPriceListID column
        param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for Capacity column
        param = new SqlParameter("@Capacity", SqlDbType.TinyInt, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bytCapacity;
        cmd.Parameters.Add(param);
        
        // parameter for Day column
        param = new SqlParameter("@Day", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtDay;
        cmd.Parameters.Add(param);
        
        // parameter for PriceID column
        param = new SqlParameter("@PriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPriceID;
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
				cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomPriceListPrices__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomPriceListPriceID column
        param = new SqlParameter("@RoomPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListPriceID;
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
		public static bool operator ==(RoomPriceListPrices t1, RoomPriceListPrices t2) {
			//	compare values
			if(t1.m_intRoomPriceListPriceID != t2.m_intRoomPriceListPriceID) {
				return false;	//	because "RoomPriceListPriceID" values are Not equal
			}
	
			if(t1.m_intRoomPriceListID != t2.m_intRoomPriceListID) {
				return false;	//	because "RoomPriceListID" values are Not equal
			}
	
			if(t1.m_intRoomID != t2.m_intRoomID) {
				return false;	//	because "RoomID" values are Not equal
			}
	
			if(t1.m_bytCapacity != t2.m_bytCapacity) {
				return false;	//	because "Capacity" values are Not equal
			}
	
			if(t1.m_dtDay != t2.m_dtDay) {
				return false;	//	because "Day" values are Not equal
			}
	
			if(t1.m_intPriceID != t2.m_intPriceID) {
				return false;	//	because "PriceID" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(RoomPriceListPrices t1, RoomPriceListPrices t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" RoomPriceListPriceID = \"");
			retValue.Append(m_intRoomPriceListPriceID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    RoomPriceListID = \"");
			retValue.Append(m_intRoomPriceListID);
			retValue.Append("\"\n");
				retValue.Append("    RoomID = \"");
			retValue.Append(m_intRoomID);
			retValue.Append("\"\n");
				retValue.Append("    Capacity = \"");
			retValue.Append(m_bytCapacity);
			retValue.Append("\"\n");
				retValue.Append("    Day = \"");
			retValue.Append(m_dtDay);
			retValue.Append("\"\n");
				retValue.Append("    PriceID = \"");
			retValue.Append(m_intPriceID);
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
			if (!(o is RoomPriceListPrices)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomPriceListPrices)o;
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
