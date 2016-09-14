using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class TourPriceLists {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intTourPriceListID;
		private SqlString m_strTitle;
		private SqlString m_strDescription;
		private SqlDateTime m_dtBookingStartDate;
		private SqlDateTime m_dtBookingEndDate;
		private SqlDateTime m_dtReservationStartDate;
		private SqlDateTime m_dtReservationEndDate;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public TourPriceLists() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all TourPriceLists from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the TourPriceLists</returns>
		public static SqlDataReader GetAllTourPriceListsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourPriceLists__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllTourPriceListsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_TourPriceLists__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all TourPriceLists from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTourPriceLists() {
			SqlDataReader dr = GetAllTourPriceListsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates TourPriceLists for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the TourPriceLists records</param>
		/// <returns>The Hashtable containing TourPriceLists objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            TourPriceLists myTourPriceLists = new TourPriceLists();
            
            myTourPriceLists.m_intTourPriceListID = dr.GetSqlInt32(0);
            myTourPriceLists.m_strTitle = dr.GetSqlString(1);
            myTourPriceLists.m_strDescription = dr.GetSqlString(2);
            myTourPriceLists.m_dtBookingStartDate = dr.GetSqlDateTime(3);
            myTourPriceLists.m_dtBookingEndDate = dr.GetSqlDateTime(4);
            myTourPriceLists.m_dtReservationStartDate = dr.GetSqlDateTime(5);
            myTourPriceLists.m_dtReservationEndDate = dr.GetSqlDateTime(6);
            
            result.Add(myTourPriceLists.TourPriceListID, myTourPriceLists);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 TourPriceListID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.TourPriceListID = m_intTourPriceListID;
				return pk;
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
		/// The Title column in the DB
		/// </summary>
		public string Title {
			get {
				return (string)m_strTitle;
			}
			set {
				m_strTitle = value;
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
		/// The BookingStartDate column in the DB
		/// </summary>
		public DateTime BookingStartDate {
			get {
				return (DateTime)m_dtBookingStartDate;
			}
			set {
				m_dtBookingStartDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The BookingEndDate column in the DB
		/// </summary>
		public DateTime BookingEndDate {
			get {
				return (DateTime)m_dtBookingEndDate;
			}
			set {
				m_dtBookingEndDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReservationStartDate column in the DB
		/// </summary>
		public DateTime ReservationStartDate {
			get {
				return (DateTime)m_dtReservationStartDate;
			}
			set {
				m_dtReservationStartDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReservationEndDate column in the DB
		/// </summary>
		public DateTime ReservationEndDate {
			get {
				return (DateTime)m_dtReservationEndDate;
			}
			set {
				m_dtReservationEndDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.TourPriceListID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intTourPriceListID"> TourPriceListID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intTourPriceListID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourPriceLists__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for TourPriceListID column
        param = new SqlParameter("@TourPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intTourPriceListID;
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
		            m_intTourPriceListID = reader.GetSqlInt32(0);
            m_strTitle = reader.GetSqlString(1);
            m_strDescription = reader.GetSqlString(2);
            m_dtBookingStartDate = reader.GetSqlDateTime(3);
            m_dtBookingEndDate = reader.GetSqlDateTime(4);
            m_dtReservationStartDate = reader.GetSqlDateTime(5);
            m_dtReservationEndDate = reader.GetSqlDateTime(6);
		
			} else {
					//	set key values
		            m_intTourPriceListID = intTourPriceListID;
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
							cmd = DBHelper.getSprocCmd("proc_TourPriceLists__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_TourPriceLists__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourPriceListID column
        param = new SqlParameter("@TourPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 400);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for BookingStartDate column
        param = new SqlParameter("@BookingStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for BookingEndDate column
        param = new SqlParameter("@BookingEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationStartDate column
        param = new SqlParameter("@ReservationStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtReservationStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationEndDate column
        param = new SqlParameter("@ReservationEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtReservationEndDate;
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
				cmd = DBHelper.getSprocCmd("proc_TourPriceLists__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourPriceLists__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for TourPriceListID column
        param = new SqlParameter("@TourPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 400);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for BookingStartDate column
        param = new SqlParameter("@BookingStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for BookingEndDate column
        param = new SqlParameter("@BookingEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationStartDate column
        param = new SqlParameter("@ReservationStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtReservationStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationEndDate column
        param = new SqlParameter("@ReservationEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtReservationEndDate;
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
				cmd = DBHelper.getSprocCmd("proc_TourPriceLists__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourPriceLists__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourPriceListID column
        param = new SqlParameter("@TourPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourPriceListID;
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
		public static bool operator ==(TourPriceLists t1, TourPriceLists t2) {
			//	compare values
			if(t1.m_intTourPriceListID != t2.m_intTourPriceListID) {
				return false;	//	because "TourPriceListID" values are Not equal
			}
	
			if(t1.m_strTitle != t2.m_strTitle) {
				return false;	//	because "Title" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			if(t1.m_dtBookingStartDate != t2.m_dtBookingStartDate) {
				return false;	//	because "BookingStartDate" values are Not equal
			}
	
			if(t1.m_dtBookingEndDate != t2.m_dtBookingEndDate) {
				return false;	//	because "BookingEndDate" values are Not equal
			}
	
			if(t1.m_dtReservationStartDate != t2.m_dtReservationStartDate) {
				return false;	//	because "ReservationStartDate" values are Not equal
			}
	
			if(t1.m_dtReservationEndDate != t2.m_dtReservationEndDate) {
				return false;	//	because "ReservationEndDate" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(TourPriceLists t1, TourPriceLists t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" TourPriceListID = \"");
			retValue.Append(m_intTourPriceListID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    Title = \"");
			retValue.Append(m_strTitle);
			retValue.Append("\"\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
			retValue.Append("\"\n");
				retValue.Append("    BookingStartDate = \"");
			retValue.Append(m_dtBookingStartDate);
			retValue.Append("\"\n");
				retValue.Append("    BookingEndDate = \"");
			retValue.Append(m_dtBookingEndDate);
			retValue.Append("\"\n");
				retValue.Append("    ReservationStartDate = \"");
			retValue.Append(m_dtReservationStartDate);
			retValue.Append("\"\n");
				retValue.Append("    ReservationEndDate = \"");
			retValue.Append(m_dtReservationEndDate);
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
			if (!(o is TourPriceLists)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (TourPriceLists)o;
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
