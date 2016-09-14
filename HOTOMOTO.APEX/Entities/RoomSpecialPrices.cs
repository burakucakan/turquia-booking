using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomSpecialPrices {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRoomSpecialPriceID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intHotelID;
		private SqlInt32 m_intHotelClassID;
		private SqlInt32 m_intRoomID;
		private SqlInt32 m_intRoomClassID;
		private SqlInt32 m_intCityID;
		private SqlInt32 m_intCountryID;
		private SqlDateTime m_dtBookingStartDate;
		private SqlDateTime m_dtBookingEndDate;
		private SqlDateTime m_dtReservationStartDate;
		private SqlDateTime m_dtReservationEndDate;
		private SqlInt32 m_intPriceID;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomSpecialPrices() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomSpecialPrices from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomSpecialPrices</returns>
		public static SqlDataReader GetAllRoomSpecialPricesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomSpecialPricesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomSpecialPrices from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomSpecialPrices() {
			SqlDataReader dr = GetAllRoomSpecialPricesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomSpecialPrices for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomSpecialPrices records</param>
		/// <returns>The Hashtable containing RoomSpecialPrices objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomSpecialPrices myRoomSpecialPrices = new RoomSpecialPrices();
            
            myRoomSpecialPrices.m_intRoomSpecialPriceID = dr.GetSqlInt32(0);
            myRoomSpecialPrices.m_intCustomerID = dr.GetSqlInt32(1);
            myRoomSpecialPrices.m_intHotelID = dr.GetSqlInt32(2);
            myRoomSpecialPrices.m_intHotelClassID = dr.GetSqlInt32(3);
            myRoomSpecialPrices.m_intRoomID = dr.GetSqlInt32(4);
            myRoomSpecialPrices.m_intRoomClassID = dr.GetSqlInt32(5);
            myRoomSpecialPrices.m_intCityID = dr.GetSqlInt32(6);
            myRoomSpecialPrices.m_intCountryID = dr.GetSqlInt32(7);
            myRoomSpecialPrices.m_dtBookingStartDate = dr.GetSqlDateTime(8);
            myRoomSpecialPrices.m_dtBookingEndDate = dr.GetSqlDateTime(9);
            myRoomSpecialPrices.m_dtReservationStartDate = dr.GetSqlDateTime(10);
            myRoomSpecialPrices.m_dtReservationEndDate = dr.GetSqlDateTime(11);
            myRoomSpecialPrices.m_intPriceID = dr.GetSqlInt32(12);
            
            result.Add(myRoomSpecialPrices.RoomSpecialPriceID, myRoomSpecialPrices);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 RoomSpecialPriceID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.RoomSpecialPriceID = m_intRoomSpecialPriceID;
				return pk;
			}
		}
			/// <summary>
		/// The RoomSpecialPriceID column in the DB
		/// </summary>
		public int RoomSpecialPriceID {
			get {
				return (int)m_intRoomSpecialPriceID;
			}
			set {
				m_intRoomSpecialPriceID = value;
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
		/// The HotelClassID column in the DB
		/// </summary>
		public int HotelClassID {
			get {
				return (int)m_intHotelClassID;
			}
			set {
				m_intHotelClassID = value;
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
		/// The RoomClassID column in the DB
		/// </summary>
		public int RoomClassID {
			get {
				return (int)m_intRoomClassID;
			}
			set {
				m_intRoomClassID = value;
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
			return Load(pk.RoomSpecialPriceID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intRoomSpecialPriceID"> RoomSpecialPriceID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intRoomSpecialPriceID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for RoomSpecialPriceID column
        param = new SqlParameter("@RoomSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRoomSpecialPriceID;
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
		            m_intRoomSpecialPriceID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_intHotelID = reader.GetSqlInt32(2);
            m_intHotelClassID = reader.GetSqlInt32(3);
            m_intRoomID = reader.GetSqlInt32(4);
            m_intRoomClassID = reader.GetSqlInt32(5);
            m_intCityID = reader.GetSqlInt32(6);
            m_intCountryID = reader.GetSqlInt32(7);
            m_dtBookingStartDate = reader.GetSqlDateTime(8);
            m_dtBookingEndDate = reader.GetSqlDateTime(9);
            m_dtReservationStartDate = reader.GetSqlDateTime(10);
            m_dtReservationEndDate = reader.GetSqlDateTime(11);
            m_intPriceID = reader.GetSqlInt32(12);
		
			} else {
					//	set key values
		            m_intRoomSpecialPriceID = intRoomSpecialPriceID;
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
							cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomSpecialPriceID column
        param = new SqlParameter("@RoomSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomSpecialPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelClassID column
        param = new SqlParameter("@HotelClassID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelClassID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomClassID column
        param = new SqlParameter("@RoomClassID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomClassID;
        cmd.Parameters.Add(param);
        
        // parameter for CityID column
        param = new SqlParameter("@CityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCityID;
        cmd.Parameters.Add(param);
        
        // parameter for CountryID column
        param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCountryID;
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
				cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for RoomSpecialPriceID column
        param = new SqlParameter("@RoomSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomSpecialPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelClassID column
        param = new SqlParameter("@HotelClassID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelClassID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomClassID column
        param = new SqlParameter("@RoomClassID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomClassID;
        cmd.Parameters.Add(param);
        
        // parameter for CityID column
        param = new SqlParameter("@CityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCityID;
        cmd.Parameters.Add(param);
        
        // parameter for CountryID column
        param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCountryID;
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
				cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomSpecialPrices__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomSpecialPriceID column
        param = new SqlParameter("@RoomSpecialPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomSpecialPriceID;
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
		public static bool operator ==(RoomSpecialPrices t1, RoomSpecialPrices t2) {
			//	compare values
			if(t1.m_intRoomSpecialPriceID != t2.m_intRoomSpecialPriceID) {
				return false;	//	because "RoomSpecialPriceID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intHotelID != t2.m_intHotelID) {
				return false;	//	because "HotelID" values are Not equal
			}
	
			if(t1.m_intHotelClassID != t2.m_intHotelClassID) {
				return false;	//	because "HotelClassID" values are Not equal
			}
	
			if(t1.m_intRoomID != t2.m_intRoomID) {
				return false;	//	because "RoomID" values are Not equal
			}
	
			if(t1.m_intRoomClassID != t2.m_intRoomClassID) {
				return false;	//	because "RoomClassID" values are Not equal
			}
	
			if(t1.m_intCityID != t2.m_intCityID) {
				return false;	//	because "CityID" values are Not equal
			}
	
			if(t1.m_intCountryID != t2.m_intCountryID) {
				return false;	//	because "CountryID" values are Not equal
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
		public static bool operator !=(RoomSpecialPrices t1, RoomSpecialPrices t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" RoomSpecialPriceID = \"");
			retValue.Append(m_intRoomSpecialPriceID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    HotelID = \"");
			retValue.Append(m_intHotelID);
			retValue.Append("\"\n");
				retValue.Append("    HotelClassID = \"");
			retValue.Append(m_intHotelClassID);
			retValue.Append("\"\n");
				retValue.Append("    RoomID = \"");
			retValue.Append(m_intRoomID);
			retValue.Append("\"\n");
				retValue.Append("    RoomClassID = \"");
			retValue.Append(m_intRoomClassID);
			retValue.Append("\"\n");
				retValue.Append("    CityID = \"");
			retValue.Append(m_intCityID);
			retValue.Append("\"\n");
				retValue.Append("    CountryID = \"");
			retValue.Append(m_intCountryID);
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
			if (!(o is RoomSpecialPrices)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomSpecialPrices)o;
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
