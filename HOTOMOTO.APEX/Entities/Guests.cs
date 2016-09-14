using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Guests {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intGuestID;
		private SqlInt32 m_intRoomReservationID;
		private SqlInt32 m_intReservationID;
		private SqlString m_strGuestNameTitle;
		private SqlString m_strGuestName;
		private SqlString m_strEmailAddress;
		private SqlDateTime m_dtCreateDate;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Guests() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Guests from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Guests</returns>
		public static SqlDataReader GetAllGuestsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Guests__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllGuestsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Guests__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Guests from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllGuests() {
			SqlDataReader dr = GetAllGuestsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Guests for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Guests records</param>
		/// <returns>The Hashtable containing Guests objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Guests myGuests = new Guests();
            
            myGuests.m_intGuestID = dr.GetSqlInt32(0);
            myGuests.m_intRoomReservationID = dr.GetSqlInt32(1);
            myGuests.m_intReservationID = dr.GetSqlInt32(2);
            myGuests.m_strGuestNameTitle = dr.GetSqlString(3);
            myGuests.m_strGuestName = dr.GetSqlString(4);
            myGuests.m_strEmailAddress = dr.GetSqlString(5);
            myGuests.m_dtCreateDate = dr.GetSqlDateTime(6);
            
            result.Add(myGuests.GuestID, myGuests);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 GuestID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.GuestID = m_intGuestID;
				return pk;
			}
		}
			/// <summary>
		/// The GuestID column in the DB
		/// </summary>
		public int GuestID {
			get {
				return (int)m_intGuestID;
			}
			set {
				m_intGuestID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The RoomReservationID column in the DB
		/// </summary>
		public int RoomReservationID {
			get {
				return (int)m_intRoomReservationID;
			}
			set {
				m_intRoomReservationID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReservationID column in the DB
		/// </summary>
		public int ReservationID {
			get {
				return (int)m_intReservationID;
			}
			set {
				m_intReservationID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The GuestNameTitle column in the DB
		/// </summary>
		public string GuestNameTitle {
			get {
				return (string)m_strGuestNameTitle;
			}
			set {
				m_strGuestNameTitle = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The GuestName column in the DB
		/// </summary>
		public string GuestName {
			get {
				return (string)m_strGuestName;
			}
			set {
				m_strGuestName = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The EmailAddress column in the DB
		/// </summary>
		public string EmailAddress {
			get {
				return (string)m_strEmailAddress;
			}
			set {
				m_strEmailAddress = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CreateDate column in the DB
		/// </summary>
		public DateTime CreateDate {
			get {
				return (DateTime)m_dtCreateDate;
			}
			set {
				m_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.GuestID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intGuestID"> GuestID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intGuestID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Guests__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for GuestID column
        param = new SqlParameter("@GuestID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intGuestID;
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
		            m_intGuestID = reader.GetSqlInt32(0);
            m_intRoomReservationID = reader.GetSqlInt32(1);
            m_intReservationID = reader.GetSqlInt32(2);
            m_strGuestNameTitle = reader.GetSqlString(3);
            m_strGuestName = reader.GetSqlString(4);
            m_strEmailAddress = reader.GetSqlString(5);
            m_dtCreateDate = reader.GetSqlDateTime(6);
		
			} else {
					//	set key values
		            m_intGuestID = intGuestID;
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
							cmd = DBHelper.getSprocCmd("proc_Guests__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Guests__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for GuestID column
        param = new SqlParameter("@GuestID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuestID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomReservationID column
        param = new SqlParameter("@RoomReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for GuestNameTitle column
        param = new SqlParameter("@GuestNameTitle", SqlDbType.NVarChar, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strGuestNameTitle;
        cmd.Parameters.Add(param);
        
        // parameter for GuestName column
        param = new SqlParameter("@GuestName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strGuestName;
        cmd.Parameters.Add(param);
        
        // parameter for EmailAddress column
        param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEmailAddress;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
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
				cmd = DBHelper.getSprocCmd("proc_Guests__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Guests__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for GuestID column
        param = new SqlParameter("@GuestID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuestID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomReservationID column
        param = new SqlParameter("@RoomReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for GuestNameTitle column
        param = new SqlParameter("@GuestNameTitle", SqlDbType.NVarChar, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strGuestNameTitle;
        cmd.Parameters.Add(param);
        
        // parameter for GuestName column
        param = new SqlParameter("@GuestName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strGuestName;
        cmd.Parameters.Add(param);
        
        // parameter for EmailAddress column
        param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEmailAddress;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
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
				cmd = DBHelper.getSprocCmd("proc_Guests__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Guests__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for GuestID column
        param = new SqlParameter("@GuestID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuestID;
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
		public static bool operator ==(Guests t1, Guests t2) {
			//	compare values
			if(t1.m_intGuestID != t2.m_intGuestID) {
				return false;	//	because "GuestID" values are Not equal
			}
	
			if(t1.m_intRoomReservationID != t2.m_intRoomReservationID) {
				return false;	//	because "RoomReservationID" values are Not equal
			}
	
			if(t1.m_intReservationID != t2.m_intReservationID) {
				return false;	//	because "ReservationID" values are Not equal
			}
	
			if(t1.m_strGuestNameTitle != t2.m_strGuestNameTitle) {
				return false;	//	because "GuestNameTitle" values are Not equal
			}
	
			if(t1.m_strGuestName != t2.m_strGuestName) {
				return false;	//	because "GuestName" values are Not equal
			}
	
			if(t1.m_strEmailAddress != t2.m_strEmailAddress) {
				return false;	//	because "EmailAddress" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Guests t1, Guests t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" GuestID = \"");
			retValue.Append(m_intGuestID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    RoomReservationID = \"");
			retValue.Append(m_intRoomReservationID);
			retValue.Append("\"\n");
				retValue.Append("    ReservationID = \"");
			retValue.Append(m_intReservationID);
			retValue.Append("\"\n");
				retValue.Append("    GuestNameTitle = \"");
			retValue.Append(m_strGuestNameTitle);
			retValue.Append("\"\n");
				retValue.Append("    GuestName = \"");
			retValue.Append(m_strGuestName);
			retValue.Append("\"\n");
				retValue.Append("    EmailAddress = \"");
			retValue.Append(m_strEmailAddress);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
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
			if (!(o is Guests)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Guests)o;
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
