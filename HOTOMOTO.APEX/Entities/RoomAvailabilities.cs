using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomAvailabilities {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlDateTime m_dtAvailabilityDate;
		private SqlInt32 m_intRoomID;
		private SqlInt32 m_intQuantity;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomAvailabilities() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomAvailabilities from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomAvailabilities</returns>
		public static SqlDataReader GetAllRoomAvailabilitiesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomAvailabilitiesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomAvailabilities from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomAvailabilities() {
			SqlDataReader dr = GetAllRoomAvailabilitiesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomAvailabilities for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomAvailabilities records</param>
		/// <returns>The Hashtable containing RoomAvailabilities objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomAvailabilities myRoomAvailabilities = new RoomAvailabilities();
            
            myRoomAvailabilities.m_dtAvailabilityDate = dr.GetSqlDateTime(0);
            myRoomAvailabilities.m_intRoomID = dr.GetSqlInt32(1);
            myRoomAvailabilities.m_intQuantity = dr.GetSqlInt32(2);
            
            result.Add(myRoomAvailabilities.AvailabilityDate, myRoomAvailabilities);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlDateTime AvailabilityDate;
		public SqlInt32 RoomID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.AvailabilityDate = m_dtAvailabilityDate;
			pk.RoomID = m_intRoomID;
				return pk;
			}
		}
			/// <summary>
		/// The AvailabilityDate column in the DB
		/// </summary>
		public DateTime AvailabilityDate {
			get {
				return (DateTime)m_dtAvailabilityDate;
			}
			set {
				m_dtAvailabilityDate = value;
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
		/// The Quantity column in the DB
		/// </summary>
		public int Quantity {
			get {
				return (int)m_intQuantity;
			}
			set {
				m_intQuantity = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.AvailabilityDate.Value, pk.RoomID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="dtAvailabilityDate"> AvailabilityDate key value</param>
	/// <param name="intRoomID"> RoomID key value</param>
	/// <returns>true if success</returns>
		public bool Load(DateTime dtAvailabilityDate, Int32 intRoomID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for AvailabilityDate column
        param = new SqlParameter("@AvailabilityDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = dtAvailabilityDate;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRoomID;
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
		            m_dtAvailabilityDate = reader.GetSqlDateTime(0);
            m_intRoomID = reader.GetSqlInt32(1);
            m_intQuantity = reader.GetSqlInt32(2);
		
			} else {
					//	set key values
		            m_dtAvailabilityDate = dtAvailabilityDate;
            m_intRoomID = intRoomID;
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
							cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AvailabilityDate column
        param = new SqlParameter("@AvailabilityDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtAvailabilityDate;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for Quantity column
        param = new SqlParameter("@Quantity", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intQuantity;
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
				cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for AvailabilityDate column
        param = new SqlParameter("@AvailabilityDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtAvailabilityDate;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for Quantity column
        param = new SqlParameter("@Quantity", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intQuantity;
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
				cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomAvailabilities__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AvailabilityDate column
        param = new SqlParameter("@AvailabilityDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtAvailabilityDate;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
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
		public static bool operator ==(RoomAvailabilities t1, RoomAvailabilities t2) {
			//	compare values
			if(t1.m_dtAvailabilityDate != t2.m_dtAvailabilityDate) {
				return false;	//	because "AvailabilityDate" values are Not equal
			}
	
			if(t1.m_intRoomID != t2.m_intRoomID) {
				return false;	//	because "RoomID" values are Not equal
			}
	
			if(t1.m_intQuantity != t2.m_intQuantity) {
				return false;	//	because "Quantity" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(RoomAvailabilities t1, RoomAvailabilities t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" AvailabilityDate = \"");
			retValue.Append(m_dtAvailabilityDate);
			retValue.Append("\"\n");
				retValue.Append(" RoomID = \"");
			retValue.Append(m_intRoomID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    Quantity = \"");
			retValue.Append(m_intQuantity);
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
			if (!(o is RoomAvailabilities)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomAvailabilities)o;
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
