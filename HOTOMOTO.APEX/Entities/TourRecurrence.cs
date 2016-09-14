using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class TourRecurrence {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intTourRecurrenceID;
		private SqlInt32 m_intTourID;
		private SqlBoolean m_bolMonday;
		private SqlBoolean m_bolTuesday;
		private SqlBoolean m_bolWednesday;
		private SqlBoolean m_bolThursday;
		private SqlBoolean m_bolFriday;
		private SqlBoolean m_bolSaturday;
		private SqlBoolean m_bolSunday;
		private SqlInt32 m_intStartDay;
		private SqlBoolean m_bolisDaily;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public TourRecurrence() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all TourRecurrence from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the TourRecurrence</returns>
		public static SqlDataReader GetAllTourRecurrenceReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourRecurrence__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllTourRecurrenceDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_TourRecurrence__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all TourRecurrence from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTourRecurrence() {
			SqlDataReader dr = GetAllTourRecurrenceReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates TourRecurrence for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the TourRecurrence records</param>
		/// <returns>The Hashtable containing TourRecurrence objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            TourRecurrence myTourRecurrence = new TourRecurrence();
            
            myTourRecurrence.m_intTourRecurrenceID = dr.GetSqlInt32(0);
            myTourRecurrence.m_intTourID = dr.GetSqlInt32(1);
            myTourRecurrence.m_bolMonday = dr.GetSqlBoolean(2);
            myTourRecurrence.m_bolTuesday = dr.GetSqlBoolean(3);
            myTourRecurrence.m_bolWednesday = dr.GetSqlBoolean(4);
            myTourRecurrence.m_bolThursday = dr.GetSqlBoolean(5);
            myTourRecurrence.m_bolFriday = dr.GetSqlBoolean(6);
            myTourRecurrence.m_bolSaturday = dr.GetSqlBoolean(7);
            myTourRecurrence.m_bolSunday = dr.GetSqlBoolean(8);
            myTourRecurrence.m_intStartDay = dr.GetSqlInt32(9);
            myTourRecurrence.m_bolisDaily = dr.GetSqlBoolean(10);
            
            result.Add(myTourRecurrence.TourRecurrenceID, myTourRecurrence);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 TourRecurrenceID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.TourRecurrenceID = m_intTourRecurrenceID;
				return pk;
			}
		}
			/// <summary>
		/// The TourRecurrenceID column in the DB
		/// </summary>
		public int TourRecurrenceID {
			get {
				return (int)m_intTourRecurrenceID;
			}
			set {
				m_intTourRecurrenceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TourID column in the DB
		/// </summary>
		public int TourID {
			get {
				return (int)m_intTourID;
			}
			set {
				m_intTourID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Monday column in the DB
		/// </summary>
		public bool Monday {
			get {
				return (bool)m_bolMonday;
			}
			set {
				m_bolMonday = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Tuesday column in the DB
		/// </summary>
		public bool Tuesday {
			get {
				return (bool)m_bolTuesday;
			}
			set {
				m_bolTuesday = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Wednesday column in the DB
		/// </summary>
		public bool Wednesday {
			get {
				return (bool)m_bolWednesday;
			}
			set {
				m_bolWednesday = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Thursday column in the DB
		/// </summary>
		public bool Thursday {
			get {
				return (bool)m_bolThursday;
			}
			set {
				m_bolThursday = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Friday column in the DB
		/// </summary>
		public bool Friday {
			get {
				return (bool)m_bolFriday;
			}
			set {
				m_bolFriday = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Saturday column in the DB
		/// </summary>
		public bool Saturday {
			get {
				return (bool)m_bolSaturday;
			}
			set {
				m_bolSaturday = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Sunday column in the DB
		/// </summary>
		public bool Sunday {
			get {
				return (bool)m_bolSunday;
			}
			set {
				m_bolSunday = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The StartDay column in the DB
		/// </summary>
		public int StartDay {
			get {
				return (int)m_intStartDay;
			}
			set {
				m_intStartDay = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isDaily column in the DB
		/// </summary>
		public bool isDaily {
			get {
				return (bool)m_bolisDaily;
			}
			set {
				m_bolisDaily = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.TourRecurrenceID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intTourRecurrenceID"> TourRecurrenceID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intTourRecurrenceID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourRecurrence__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for TourRecurrenceID column
        param = new SqlParameter("@TourRecurrenceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intTourRecurrenceID;
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
		            m_intTourRecurrenceID = reader.GetSqlInt32(0);
            m_intTourID = reader.GetSqlInt32(1);
            m_bolMonday = reader.GetSqlBoolean(2);
            m_bolTuesday = reader.GetSqlBoolean(3);
            m_bolWednesday = reader.GetSqlBoolean(4);
            m_bolThursday = reader.GetSqlBoolean(5);
            m_bolFriday = reader.GetSqlBoolean(6);
            m_bolSaturday = reader.GetSqlBoolean(7);
            m_bolSunday = reader.GetSqlBoolean(8);
            m_intStartDay = reader.GetSqlInt32(9);
            m_bolisDaily = reader.GetSqlBoolean(10);
		
			} else {
					//	set key values
		            m_intTourRecurrenceID = intTourRecurrenceID;
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
							cmd = DBHelper.getSprocCmd("proc_TourRecurrence__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_TourRecurrence__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourRecurrenceID column
        param = new SqlParameter("@TourRecurrenceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourRecurrenceID;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for Monday column
        param = new SqlParameter("@Monday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolMonday;
        cmd.Parameters.Add(param);
        
        // parameter for Tuesday column
        param = new SqlParameter("@Tuesday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolTuesday;
        cmd.Parameters.Add(param);
        
        // parameter for Wednesday column
        param = new SqlParameter("@Wednesday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolWednesday;
        cmd.Parameters.Add(param);
        
        // parameter for Thursday column
        param = new SqlParameter("@Thursday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolThursday;
        cmd.Parameters.Add(param);
        
        // parameter for Friday column
        param = new SqlParameter("@Friday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolFriday;
        cmd.Parameters.Add(param);
        
        // parameter for Saturday column
        param = new SqlParameter("@Saturday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolSaturday;
        cmd.Parameters.Add(param);
        
        // parameter for Sunday column
        param = new SqlParameter("@Sunday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolSunday;
        cmd.Parameters.Add(param);
        
        // parameter for StartDay column
        param = new SqlParameter("@StartDay", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStartDay;
        cmd.Parameters.Add(param);
        
        // parameter for isDaily column
        param = new SqlParameter("@isDaily", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDaily;
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
				cmd = DBHelper.getSprocCmd("proc_TourRecurrence__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourRecurrence__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for TourRecurrenceID column
        param = new SqlParameter("@TourRecurrenceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourRecurrenceID;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for Monday column
        param = new SqlParameter("@Monday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolMonday;
        cmd.Parameters.Add(param);
        
        // parameter for Tuesday column
        param = new SqlParameter("@Tuesday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolTuesday;
        cmd.Parameters.Add(param);
        
        // parameter for Wednesday column
        param = new SqlParameter("@Wednesday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolWednesday;
        cmd.Parameters.Add(param);
        
        // parameter for Thursday column
        param = new SqlParameter("@Thursday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolThursday;
        cmd.Parameters.Add(param);
        
        // parameter for Friday column
        param = new SqlParameter("@Friday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolFriday;
        cmd.Parameters.Add(param);
        
        // parameter for Saturday column
        param = new SqlParameter("@Saturday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolSaturday;
        cmd.Parameters.Add(param);
        
        // parameter for Sunday column
        param = new SqlParameter("@Sunday", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolSunday;
        cmd.Parameters.Add(param);
        
        // parameter for StartDay column
        param = new SqlParameter("@StartDay", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStartDay;
        cmd.Parameters.Add(param);
        
        // parameter for isDaily column
        param = new SqlParameter("@isDaily", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDaily;
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
				cmd = DBHelper.getSprocCmd("proc_TourRecurrence__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourRecurrence__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourRecurrenceID column
        param = new SqlParameter("@TourRecurrenceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourRecurrenceID;
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
		public static bool operator ==(TourRecurrence t1, TourRecurrence t2) {
			//	compare values
			if(t1.m_intTourRecurrenceID != t2.m_intTourRecurrenceID) {
				return false;	//	because "TourRecurrenceID" values are Not equal
			}
	
			if(t1.m_intTourID != t2.m_intTourID) {
				return false;	//	because "TourID" values are Not equal
			}
	
			if(t1.m_bolMonday != t2.m_bolMonday) {
				return false;	//	because "Monday" values are Not equal
			}
	
			if(t1.m_bolTuesday != t2.m_bolTuesday) {
				return false;	//	because "Tuesday" values are Not equal
			}
	
			if(t1.m_bolWednesday != t2.m_bolWednesday) {
				return false;	//	because "Wednesday" values are Not equal
			}
	
			if(t1.m_bolThursday != t2.m_bolThursday) {
				return false;	//	because "Thursday" values are Not equal
			}
	
			if(t1.m_bolFriday != t2.m_bolFriday) {
				return false;	//	because "Friday" values are Not equal
			}
	
			if(t1.m_bolSaturday != t2.m_bolSaturday) {
				return false;	//	because "Saturday" values are Not equal
			}
	
			if(t1.m_bolSunday != t2.m_bolSunday) {
				return false;	//	because "Sunday" values are Not equal
			}
	
			if(t1.m_intStartDay != t2.m_intStartDay) {
				return false;	//	because "StartDay" values are Not equal
			}
	
			if(t1.m_bolisDaily != t2.m_bolisDaily) {
				return false;	//	because "isDaily" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(TourRecurrence t1, TourRecurrence t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" TourRecurrenceID = \"");
			retValue.Append(m_intTourRecurrenceID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    TourID = \"");
			retValue.Append(m_intTourID);
			retValue.Append("\"\n");
				retValue.Append("    Monday = \"");
			retValue.Append(m_bolMonday);
			retValue.Append("\"\n");
				retValue.Append("    Tuesday = \"");
			retValue.Append(m_bolTuesday);
			retValue.Append("\"\n");
				retValue.Append("    Wednesday = \"");
			retValue.Append(m_bolWednesday);
			retValue.Append("\"\n");
				retValue.Append("    Thursday = \"");
			retValue.Append(m_bolThursday);
			retValue.Append("\"\n");
				retValue.Append("    Friday = \"");
			retValue.Append(m_bolFriday);
			retValue.Append("\"\n");
				retValue.Append("    Saturday = \"");
			retValue.Append(m_bolSaturday);
			retValue.Append("\"\n");
				retValue.Append("    Sunday = \"");
			retValue.Append(m_bolSunday);
			retValue.Append("\"\n");
				retValue.Append("    StartDay = \"");
			retValue.Append(m_intStartDay);
			retValue.Append("\"\n");
				retValue.Append("    isDaily = \"");
			retValue.Append(m_bolisDaily);
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
			if (!(o is TourRecurrence)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (TourRecurrence)o;
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
