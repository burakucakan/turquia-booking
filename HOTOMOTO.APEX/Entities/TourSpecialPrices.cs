using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class TourSpecialPrices {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intTourSpecialPriceID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intTourID;
		private SqlInt32 m_intCountryID;
		private SqlInt32 m_intCityID;
		private SqlDateTime m_dtBookingStartDate;
		private SqlDateTime m_dtBookingEndDate;
		private SqlDateTime m_dtReservationStartDate;
		private SqlDateTime m_dtReservationEndDate;
		private SqlInt32 m_intPriceID;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public TourSpecialPrices() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all TourSpecialPrices from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the TourSpecialPrices</returns>
		public static SqlDataReader GetAllTourSpecialPricesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllTourSpecialPricesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all TourSpecialPrices from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTourSpecialPrices() {
			SqlDataReader dr = GetAllTourSpecialPricesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates TourSpecialPrices for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the TourSpecialPrices records</param>
		/// <returns>The Hashtable containing TourSpecialPrices objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            TourSpecialPrices myTourSpecialPrices = new TourSpecialPrices();
            
            myTourSpecialPrices.m_intTourSpecialPriceID = dr.GetSqlInt32(0);
            myTourSpecialPrices.m_intCustomerID = dr.GetSqlInt32(1);
            myTourSpecialPrices.m_intTourID = dr.GetSqlInt32(2);
            myTourSpecialPrices.m_intCountryID = dr.GetSqlInt32(3);
            myTourSpecialPrices.m_intCityID = dr.GetSqlInt32(4);
            myTourSpecialPrices.m_dtBookingStartDate = dr.GetSqlDateTime(5);
            myTourSpecialPrices.m_dtBookingEndDate = dr.GetSqlDateTime(6);
            myTourSpecialPrices.m_dtReservationStartDate = dr.GetSqlDateTime(7);
            myTourSpecialPrices.m_dtReservationEndDate = dr.GetSqlDateTime(8);
            myTourSpecialPrices.m_intPriceID = dr.GetSqlInt32(9);
            
            result.Add(myTourSpecialPrices.TourSpecialPriceID, myTourSpecialPrices);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 TourSpecialPriceID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.TourSpecialPriceID = m_intTourSpecialPriceID;
				return pk;
			}
		}
			/// <summary>
		/// The TourSpecialPriceID column in the DB
		/// </summary>
		public int TourSpecialPriceID {
			get {
				return (int)m_intTourSpecialPriceID;
			}
			set {
				m_intTourSpecialPriceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CustomerID column in the DB
		/// </summary>
		public int CustomerID {
			get {
				return (int)m_intCustomerID;
			}
			set {
				m_intCustomerID = value;
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
		/// The CountryID column in the DB
		/// </summary>
		public int CountryID {
			get {
				return (int)m_intCountryID;
			}
			set {
				m_intCountryID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CityID column in the DB
		/// </summary>
		public int CityID {
			get {
				return (int)m_intCityID;
			}
			set {
				m_intCityID = value;
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
			return Load(pk.TourSpecialPriceID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intTourSpecialPriceID"> TourSpecialPriceID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intTourSpecialPriceID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for TourSpecialPriceID column
        param = new SqlParameter("@TourSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intTourSpecialPriceID;
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
		            m_intTourSpecialPriceID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_intTourID = reader.GetSqlInt32(2);
            m_intCountryID = reader.GetSqlInt32(3);
            m_intCityID = reader.GetSqlInt32(4);
            m_dtBookingStartDate = reader.GetSqlDateTime(5);
            m_dtBookingEndDate = reader.GetSqlDateTime(6);
            m_dtReservationStartDate = reader.GetSqlDateTime(7);
            m_dtReservationEndDate = reader.GetSqlDateTime(8);
            m_intPriceID = reader.GetSqlInt32(9);
		
			} else {
					//	set key values
		            m_intTourSpecialPriceID = intTourSpecialPriceID;
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
							cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourSpecialPriceID column
        param = new SqlParameter("@TourSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourSpecialPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for CountryID column
        param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCountryID;
        cmd.Parameters.Add(param);
        
        // parameter for CityID column
        param = new SqlParameter("@CityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCityID;
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
				cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for TourSpecialPriceID column
        param = new SqlParameter("@TourSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourSpecialPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for CountryID column
        param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCountryID;
        cmd.Parameters.Add(param);
        
        // parameter for CityID column
        param = new SqlParameter("@CityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCityID;
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
				cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourSpecialPrices__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourSpecialPriceID column
        param = new SqlParameter("@TourSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourSpecialPriceID;
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
		public static bool operator ==(TourSpecialPrices t1, TourSpecialPrices t2) {
			//	compare values
			if(t1.m_intTourSpecialPriceID != t2.m_intTourSpecialPriceID) {
				return false;	//	because "TourSpecialPriceID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intTourID != t2.m_intTourID) {
				return false;	//	because "TourID" values are Not equal
			}
	
			if(t1.m_intCountryID != t2.m_intCountryID) {
				return false;	//	because "CountryID" values are Not equal
			}
	
			if(t1.m_intCityID != t2.m_intCityID) {
				return false;	//	because "CityID" values are Not equal
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
		public static bool operator !=(TourSpecialPrices t1, TourSpecialPrices t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" TourSpecialPriceID = \"");
			retValue.Append(m_intTourSpecialPriceID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    TourID = \"");
			retValue.Append(m_intTourID);
			retValue.Append("\"\n");
				retValue.Append("    CountryID = \"");
			retValue.Append(m_intCountryID);
			retValue.Append("\"\n");
				retValue.Append("    CityID = \"");
			retValue.Append(m_intCityID);
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
			if (!(o is TourSpecialPrices)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (TourSpecialPrices)o;
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
