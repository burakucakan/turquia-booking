using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomReservations {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRoomReservationID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intReservationID;
		private SqlInt32 m_intHotelID;
		private SqlInt32 m_intRoomID;
		private SqlInt32 m_intBedTypeID;
		private SqlDouble m_dblTotalPriceUSD;
		private SqlDouble m_dblPerGuestPriceUSD;
		private SqlDouble m_dblTotalPriceEUR;
		private SqlDouble m_dblPerGuestPriceEUR;
		private SqlDateTime m_dtBookingDate;
		private SqlDateTime m_dtReservationStartDate;
		private SqlDateTime m_dtReservationEndDate;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomReservations() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomReservations from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomReservations</returns>
		public static SqlDataReader GetAllRoomReservationsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomReservations__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomReservationsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomReservations__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomReservations from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomReservations() {
			SqlDataReader dr = GetAllRoomReservationsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomReservations for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomReservations records</param>
		/// <returns>The Hashtable containing RoomReservations objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomReservations myRoomReservations = new RoomReservations();
            
            myRoomReservations.m_intRoomReservationID = dr.GetSqlInt32(0);
            myRoomReservations.m_intCustomerID = dr.GetSqlInt32(1);
            myRoomReservations.m_intReservationID = dr.GetSqlInt32(2);
            myRoomReservations.m_intHotelID = dr.GetSqlInt32(3);
            myRoomReservations.m_intRoomID = dr.GetSqlInt32(4);
            myRoomReservations.m_intBedTypeID = dr.GetSqlInt32(5);
            myRoomReservations.m_dblTotalPriceUSD = dr.GetSqlDouble(6);
            myRoomReservations.m_dblPerGuestPriceUSD = dr.GetSqlDouble(7);
            myRoomReservations.m_dblTotalPriceEUR = dr.GetSqlDouble(8);
            myRoomReservations.m_dblPerGuestPriceEUR = dr.GetSqlDouble(9);
            myRoomReservations.m_dtBookingDate = dr.GetSqlDateTime(10);
            myRoomReservations.m_dtReservationStartDate = dr.GetSqlDateTime(11);
            myRoomReservations.m_dtReservationEndDate = dr.GetSqlDateTime(12);
            
            result.Add(myRoomReservations.RoomReservationID, myRoomReservations);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 RoomReservationID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.RoomReservationID = m_intRoomReservationID;
				return pk;
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
		/// The BedTypeID column in the DB
		/// </summary>
		public int BedTypeID {
			get {
				return (int)m_intBedTypeID;
			}
			set {
				m_intBedTypeID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TotalPriceUSD column in the DB
		/// </summary>
		public double TotalPriceUSD {
			get {
				return (double)m_dblTotalPriceUSD;
			}
			set {
				m_dblTotalPriceUSD = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PerGuestPriceUSD column in the DB
		/// </summary>
		public double PerGuestPriceUSD {
			get {
				return (double)m_dblPerGuestPriceUSD;
			}
			set {
				m_dblPerGuestPriceUSD = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TotalPriceEUR column in the DB
		/// </summary>
		public double TotalPriceEUR {
			get {
				return (double)m_dblTotalPriceEUR;
			}
			set {
				m_dblTotalPriceEUR = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PerGuestPriceEUR column in the DB
		/// </summary>
		public double PerGuestPriceEUR {
			get {
				return (double)m_dblPerGuestPriceEUR;
			}
			set {
				m_dblPerGuestPriceEUR = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The BookingDate column in the DB
		/// </summary>
		public DateTime BookingDate {
			get {
				return (DateTime)m_dtBookingDate;
			}
			set {
				m_dtBookingDate = value;
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
			return Load(pk.RoomReservationID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intRoomReservationID"> RoomReservationID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intRoomReservationID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomReservations__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for RoomReservationID column
        param = new SqlParameter("@RoomReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRoomReservationID;
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
		            m_intRoomReservationID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_intReservationID = reader.GetSqlInt32(2);
            m_intHotelID = reader.GetSqlInt32(3);
            m_intRoomID = reader.GetSqlInt32(4);
            m_intBedTypeID = reader.GetSqlInt32(5);
            m_dblTotalPriceUSD = reader.GetSqlDouble(6);
            m_dblPerGuestPriceUSD = reader.GetSqlDouble(7);
            m_dblTotalPriceEUR = reader.GetSqlDouble(8);
            m_dblPerGuestPriceEUR = reader.GetSqlDouble(9);
            m_dtBookingDate = reader.GetSqlDateTime(10);
            m_dtReservationStartDate = reader.GetSqlDateTime(11);
            m_dtReservationEndDate = reader.GetSqlDateTime(12);
		
			} else {
					//	set key values
		            m_intRoomReservationID = intRoomReservationID;
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
							cmd = DBHelper.getSprocCmd("proc_RoomReservations__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_RoomReservations__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomReservationID column
        param = new SqlParameter("@RoomReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for BedTypeID column
        param = new SqlParameter("@BedTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBedTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceUSD column
        param = new SqlParameter("@TotalPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for PerGuestPriceUSD column
        param = new SqlParameter("@PerGuestPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblPerGuestPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceEUR column
        param = new SqlParameter("@TotalPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for PerGuestPriceEUR column
        param = new SqlParameter("@PerGuestPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblPerGuestPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for BookingDate column
        param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationStartDate column
        param = new SqlParameter("@ReservationStartDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtReservationStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationEndDate column
        param = new SqlParameter("@ReservationEndDate", SqlDbType.DateTime, 8);
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
				cmd = DBHelper.getSprocCmd("proc_RoomReservations__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomReservations__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for RoomReservationID column
        param = new SqlParameter("@RoomReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for BedTypeID column
        param = new SqlParameter("@BedTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBedTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceUSD column
        param = new SqlParameter("@TotalPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for PerGuestPriceUSD column
        param = new SqlParameter("@PerGuestPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblPerGuestPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceEUR column
        param = new SqlParameter("@TotalPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for PerGuestPriceEUR column
        param = new SqlParameter("@PerGuestPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblPerGuestPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for BookingDate column
        param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationStartDate column
        param = new SqlParameter("@ReservationStartDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtReservationStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationEndDate column
        param = new SqlParameter("@ReservationEndDate", SqlDbType.DateTime, 8);
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
				cmd = DBHelper.getSprocCmd("proc_RoomReservations__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomReservations__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomReservationID column
        param = new SqlParameter("@RoomReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomReservationID;
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
		public static bool operator ==(RoomReservations t1, RoomReservations t2) {
			//	compare values
			if(t1.m_intRoomReservationID != t2.m_intRoomReservationID) {
				return false;	//	because "RoomReservationID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intReservationID != t2.m_intReservationID) {
				return false;	//	because "ReservationID" values are Not equal
			}
	
			if(t1.m_intHotelID != t2.m_intHotelID) {
				return false;	//	because "HotelID" values are Not equal
			}
	
			if(t1.m_intRoomID != t2.m_intRoomID) {
				return false;	//	because "RoomID" values are Not equal
			}
	
			if(t1.m_intBedTypeID != t2.m_intBedTypeID) {
				return false;	//	because "BedTypeID" values are Not equal
			}
	
			if(t1.m_dblTotalPriceUSD != t2.m_dblTotalPriceUSD) {
				return false;	//	because "TotalPriceUSD" values are Not equal
			}
	
			if(t1.m_dblPerGuestPriceUSD != t2.m_dblPerGuestPriceUSD) {
				return false;	//	because "PerGuestPriceUSD" values are Not equal
			}
	
			if(t1.m_dblTotalPriceEUR != t2.m_dblTotalPriceEUR) {
				return false;	//	because "TotalPriceEUR" values are Not equal
			}
	
			if(t1.m_dblPerGuestPriceEUR != t2.m_dblPerGuestPriceEUR) {
				return false;	//	because "PerGuestPriceEUR" values are Not equal
			}
	
			if(t1.m_dtBookingDate != t2.m_dtBookingDate) {
				return false;	//	because "BookingDate" values are Not equal
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
		public static bool operator !=(RoomReservations t1, RoomReservations t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" RoomReservationID = \"");
			retValue.Append(m_intRoomReservationID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    ReservationID = \"");
			retValue.Append(m_intReservationID);
			retValue.Append("\"\n");
				retValue.Append("    HotelID = \"");
			retValue.Append(m_intHotelID);
			retValue.Append("\"\n");
				retValue.Append("    RoomID = \"");
			retValue.Append(m_intRoomID);
			retValue.Append("\"\n");
				retValue.Append("    BedTypeID = \"");
			retValue.Append(m_intBedTypeID);
			retValue.Append("\"\n");
				retValue.Append("    TotalPriceUSD = \"");
			retValue.Append(m_dblTotalPriceUSD);
			retValue.Append("\"\n");
				retValue.Append("    PerGuestPriceUSD = \"");
			retValue.Append(m_dblPerGuestPriceUSD);
			retValue.Append("\"\n");
				retValue.Append("    TotalPriceEUR = \"");
			retValue.Append(m_dblTotalPriceEUR);
			retValue.Append("\"\n");
				retValue.Append("    PerGuestPriceEUR = \"");
			retValue.Append(m_dblPerGuestPriceEUR);
			retValue.Append("\"\n");
				retValue.Append("    BookingDate = \"");
			retValue.Append(m_dtBookingDate);
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
			if (!(o is RoomReservations)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomReservations)o;
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
