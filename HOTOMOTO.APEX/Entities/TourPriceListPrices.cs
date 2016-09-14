using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class TourPriceListPrices {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRowID;
		private SqlInt32 m_intTourPriceListID;
		private SqlInt32 m_intTourID;
		private SqlDateTime m_dtIntervalStartDate;
		private SqlDateTime m_dtIntervalEndDate;
		private SqlInt32 m_intPriceID;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public TourPriceListPrices() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all TourPriceListPrices from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the TourPriceListPrices</returns>
		public static SqlDataReader GetAllTourPriceListPricesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllTourPriceListPricesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all TourPriceListPrices from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTourPriceListPrices() {
			SqlDataReader dr = GetAllTourPriceListPricesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates TourPriceListPrices for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the TourPriceListPrices records</param>
		/// <returns>The Hashtable containing TourPriceListPrices objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            TourPriceListPrices myTourPriceListPrices = new TourPriceListPrices();
            
            myTourPriceListPrices.m_intRowID = dr.GetSqlInt32(0);
            myTourPriceListPrices.m_intTourPriceListID = dr.GetSqlInt32(1);
            myTourPriceListPrices.m_intTourID = dr.GetSqlInt32(2);
            myTourPriceListPrices.m_dtIntervalStartDate = dr.GetSqlDateTime(3);
            myTourPriceListPrices.m_dtIntervalEndDate = dr.GetSqlDateTime(4);
            myTourPriceListPrices.m_intPriceID = dr.GetSqlInt32(5);
            
            result.Add(myTourPriceListPrices.RowID, myTourPriceListPrices);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 RowID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.RowID = m_intRowID;
				return pk;
			}
		}
			/// <summary>
		/// The RowID column in the DB
		/// </summary>
		public int RowID {
			get {
				return (int)m_intRowID;
			}
			set {
				m_intRowID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TourPriceListID column in the DB
		/// </summary>
		public int TourPriceListID {
			get {
				return (int)m_intTourPriceListID;
			}
			set {
				m_intTourPriceListID = value;
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
		/// The IntervalStartDate column in the DB
		/// </summary>
		public DateTime IntervalStartDate {
			get {
				return (DateTime)m_dtIntervalStartDate;
			}
			set {
				m_dtIntervalStartDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The IntervalEndDate column in the DB
		/// </summary>
		public DateTime IntervalEndDate {
			get {
				return (DateTime)m_dtIntervalEndDate;
			}
			set {
				m_dtIntervalEndDate = value;
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
			return Load(pk.RowID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intRowID"> RowID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intRowID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRowID;
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
		            m_intRowID = reader.GetSqlInt32(0);
            m_intTourPriceListID = reader.GetSqlInt32(1);
            m_intTourID = reader.GetSqlInt32(2);
            m_dtIntervalStartDate = reader.GetSqlDateTime(3);
            m_dtIntervalEndDate = reader.GetSqlDateTime(4);
            m_intPriceID = reader.GetSqlInt32(5);
		
			} else {
					//	set key values
		            m_intRowID = intRowID;
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
							cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRowID;
        cmd.Parameters.Add(param);
        
        // parameter for TourPriceListID column
        param = new SqlParameter("@TourPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for IntervalStartDate column
        param = new SqlParameter("@IntervalStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtIntervalStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for IntervalEndDate column
        param = new SqlParameter("@IntervalEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtIntervalEndDate;
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
				cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRowID;
        cmd.Parameters.Add(param);
        
        // parameter for TourPriceListID column
        param = new SqlParameter("@TourPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for IntervalStartDate column
        param = new SqlParameter("@IntervalStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtIntervalStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for IntervalEndDate column
        param = new SqlParameter("@IntervalEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtIntervalEndDate;
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
				cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourPriceListPrices__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRowID;
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
		public static bool operator ==(TourPriceListPrices t1, TourPriceListPrices t2) {
			//	compare values
			if(t1.m_intRowID != t2.m_intRowID) {
				return false;	//	because "RowID" values are Not equal
			}
	
			if(t1.m_intTourPriceListID != t2.m_intTourPriceListID) {
				return false;	//	because "TourPriceListID" values are Not equal
			}
	
			if(t1.m_intTourID != t2.m_intTourID) {
				return false;	//	because "TourID" values are Not equal
			}
	
			if(t1.m_dtIntervalStartDate != t2.m_dtIntervalStartDate) {
				return false;	//	because "IntervalStartDate" values are Not equal
			}
	
			if(t1.m_dtIntervalEndDate != t2.m_dtIntervalEndDate) {
				return false;	//	because "IntervalEndDate" values are Not equal
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
		public static bool operator !=(TourPriceListPrices t1, TourPriceListPrices t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" RowID = \"");
			retValue.Append(m_intRowID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    TourPriceListID = \"");
			retValue.Append(m_intTourPriceListID);
			retValue.Append("\"\n");
				retValue.Append("    TourID = \"");
			retValue.Append(m_intTourID);
			retValue.Append("\"\n");
				retValue.Append("    IntervalStartDate = \"");
			retValue.Append(m_dtIntervalStartDate);
			retValue.Append("\"\n");
				retValue.Append("    IntervalEndDate = \"");
			retValue.Append(m_dtIntervalEndDate);
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
			if (!(o is TourPriceListPrices)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (TourPriceListPrices)o;
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
