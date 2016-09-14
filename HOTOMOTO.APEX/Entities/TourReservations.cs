using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class TourReservations {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intTourReservationID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intReservationID;
		private SqlDateTime m_dtBookingDate;
		private SqlInt32 m_intTourID;
		private SqlInt32 m_intTourType;
		private SqlInt32 m_intAdultCount;
		private SqlInt32 m_intChildCount;
		private SqlDouble m_dblTotalPriceUSD;
		private SqlDouble m_dblPerGuestPriceUSD;
		private SqlDouble m_dblTotalPriceEUR;
		private SqlDouble m_dblPerGuestPriceEUR;
		private SqlDateTime m_dtReservationStartDate;
		private SqlDateTime m_dtReservationEndDate;
		private SqlBoolean m_bolhasAccomodation;
		private SqlInt32 m_intAccomodationPrice;
		private SqlBoolean m_bolhasFlight;
		private SqlInt32 m_intFlightPrice;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public TourReservations() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all TourReservations from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the TourReservations</returns>
		public static SqlDataReader GetAllTourReservationsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourReservations__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllTourReservationsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_TourReservations__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all TourReservations from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTourReservations() {
			SqlDataReader dr = GetAllTourReservationsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates TourReservations for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the TourReservations records</param>
		/// <returns>The Hashtable containing TourReservations objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            TourReservations myTourReservations = new TourReservations();
            
            myTourReservations.m_intTourReservationID = dr.GetSqlInt32(0);
            myTourReservations.m_intCustomerID = dr.GetSqlInt32(1);
            myTourReservations.m_intReservationID = dr.GetSqlInt32(2);
            myTourReservations.m_dtBookingDate = dr.GetSqlDateTime(3);
            myTourReservations.m_intTourID = dr.GetSqlInt32(4);
            myTourReservations.m_intTourType = dr.GetSqlInt32(5);
            myTourReservations.m_intAdultCount = dr.GetSqlInt32(6);
            myTourReservations.m_intChildCount = dr.GetSqlInt32(7);
            myTourReservations.m_dblTotalPriceUSD = dr.GetSqlDouble(8);
            myTourReservations.m_dblPerGuestPriceUSD = dr.GetSqlDouble(9);
            myTourReservations.m_dblTotalPriceEUR = dr.GetSqlDouble(10);
            myTourReservations.m_dblPerGuestPriceEUR = dr.GetSqlDouble(11);
            myTourReservations.m_dtReservationStartDate = dr.GetSqlDateTime(12);
            myTourReservations.m_dtReservationEndDate = dr.GetSqlDateTime(13);
            myTourReservations.m_bolhasAccomodation = dr.GetSqlBoolean(14);
            myTourReservations.m_intAccomodationPrice = dr.GetSqlInt32(15);
            myTourReservations.m_bolhasFlight = dr.GetSqlBoolean(16);
            myTourReservations.m_intFlightPrice = dr.GetSqlInt32(17);
            
            result.Add(myTourReservations.TourReservationID, myTourReservations);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 TourReservationID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.TourReservationID = m_intTourReservationID;
				return pk;
			}
		}
			/// <summary>
		/// The TourReservationID column in the DB
		/// </summary>
		public int TourReservationID {
			get {
				return (int)m_intTourReservationID;
			}
			set {
				m_intTourReservationID = value;
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
		/// The TourType column in the DB
		/// </summary>
		public int TourType {
			get {
				return (int)m_intTourType;
			}
			set {
				m_intTourType = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The AdultCount column in the DB
		/// </summary>
		public int AdultCount {
			get {
				return (int)m_intAdultCount;
			}
			set {
				m_intAdultCount = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ChildCount column in the DB
		/// </summary>
		public int ChildCount {
			get {
				return (int)m_intChildCount;
			}
			set {
				m_intChildCount = value;
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
		/// The hasAccomodation column in the DB
		/// </summary>
		public bool hasAccomodation {
			get {
				return (bool)m_bolhasAccomodation;
			}
			set {
				m_bolhasAccomodation = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The AccomodationPrice column in the DB
		/// </summary>
		public int AccomodationPrice {
			get {
				return (int)m_intAccomodationPrice;
			}
			set {
				m_intAccomodationPrice = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The hasFlight column in the DB
		/// </summary>
		public bool hasFlight {
			get {
				return (bool)m_bolhasFlight;
			}
			set {
				m_bolhasFlight = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The FlightPrice column in the DB
		/// </summary>
		public int FlightPrice {
			get {
				return (int)m_intFlightPrice;
			}
			set {
				m_intFlightPrice = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.TourReservationID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intTourReservationID"> TourReservationID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intTourReservationID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TourReservations__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for TourReservationID column
        param = new SqlParameter("@TourReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intTourReservationID;
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
		            m_intTourReservationID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_intReservationID = reader.GetSqlInt32(2);
            m_dtBookingDate = reader.GetSqlDateTime(3);
            m_intTourID = reader.GetSqlInt32(4);
            m_intTourType = reader.GetSqlInt32(5);
            m_intAdultCount = reader.GetSqlInt32(6);
            m_intChildCount = reader.GetSqlInt32(7);
            m_dblTotalPriceUSD = reader.GetSqlDouble(8);
            m_dblPerGuestPriceUSD = reader.GetSqlDouble(9);
            m_dblTotalPriceEUR = reader.GetSqlDouble(10);
            m_dblPerGuestPriceEUR = reader.GetSqlDouble(11);
            m_dtReservationStartDate = reader.GetSqlDateTime(12);
            m_dtReservationEndDate = reader.GetSqlDateTime(13);
            m_bolhasAccomodation = reader.GetSqlBoolean(14);
            m_intAccomodationPrice = reader.GetSqlInt32(15);
            m_bolhasFlight = reader.GetSqlBoolean(16);
            m_intFlightPrice = reader.GetSqlInt32(17);
		
			} else {
					//	set key values
		            m_intTourReservationID = intTourReservationID;
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
							cmd = DBHelper.getSprocCmd("proc_TourReservations__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_TourReservations__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourReservationID column
        param = new SqlParameter("@TourReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourReservationID;
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
        
        // parameter for BookingDate column
        param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingDate;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for TourType column
        param = new SqlParameter("@TourType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourType;
        cmd.Parameters.Add(param);
        
        // parameter for AdultCount column
        param = new SqlParameter("@AdultCount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAdultCount;
        cmd.Parameters.Add(param);
        
        // parameter for ChildCount column
        param = new SqlParameter("@ChildCount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildCount;
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
        
        // parameter for hasAccomodation column
        param = new SqlParameter("@hasAccomodation", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasAccomodation;
        cmd.Parameters.Add(param);
        
        // parameter for AccomodationPrice column
        param = new SqlParameter("@AccomodationPrice", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccomodationPrice;
        cmd.Parameters.Add(param);
        
        // parameter for hasFlight column
        param = new SqlParameter("@hasFlight", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasFlight;
        cmd.Parameters.Add(param);
        
        // parameter for FlightPrice column
        param = new SqlParameter("@FlightPrice", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intFlightPrice;
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
				cmd = DBHelper.getSprocCmd("proc_TourReservations__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourReservations__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for TourReservationID column
        param = new SqlParameter("@TourReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourReservationID;
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
        
        // parameter for BookingDate column
        param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingDate;
        cmd.Parameters.Add(param);
        
        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for TourType column
        param = new SqlParameter("@TourType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourType;
        cmd.Parameters.Add(param);
        
        // parameter for AdultCount column
        param = new SqlParameter("@AdultCount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAdultCount;
        cmd.Parameters.Add(param);
        
        // parameter for ChildCount column
        param = new SqlParameter("@ChildCount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildCount;
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
        
        // parameter for hasAccomodation column
        param = new SqlParameter("@hasAccomodation", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasAccomodation;
        cmd.Parameters.Add(param);
        
        // parameter for AccomodationPrice column
        param = new SqlParameter("@AccomodationPrice", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccomodationPrice;
        cmd.Parameters.Add(param);
        
        // parameter for hasFlight column
        param = new SqlParameter("@hasFlight", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasFlight;
        cmd.Parameters.Add(param);
        
        // parameter for FlightPrice column
        param = new SqlParameter("@FlightPrice", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intFlightPrice;
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
				cmd = DBHelper.getSprocCmd("proc_TourReservations__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TourReservations__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourReservationID column
        param = new SqlParameter("@TourReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourReservationID;
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
		public static bool operator ==(TourReservations t1, TourReservations t2) {
			//	compare values
			if(t1.m_intTourReservationID != t2.m_intTourReservationID) {
				return false;	//	because "TourReservationID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intReservationID != t2.m_intReservationID) {
				return false;	//	because "ReservationID" values are Not equal
			}
	
			if(t1.m_dtBookingDate != t2.m_dtBookingDate) {
				return false;	//	because "BookingDate" values are Not equal
			}
	
			if(t1.m_intTourID != t2.m_intTourID) {
				return false;	//	because "TourID" values are Not equal
			}
	
			if(t1.m_intTourType != t2.m_intTourType) {
				return false;	//	because "TourType" values are Not equal
			}
	
			if(t1.m_intAdultCount != t2.m_intAdultCount) {
				return false;	//	because "AdultCount" values are Not equal
			}
	
			if(t1.m_intChildCount != t2.m_intChildCount) {
				return false;	//	because "ChildCount" values are Not equal
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
	
			if(t1.m_dtReservationStartDate != t2.m_dtReservationStartDate) {
				return false;	//	because "ReservationStartDate" values are Not equal
			}
	
			if(t1.m_dtReservationEndDate != t2.m_dtReservationEndDate) {
				return false;	//	because "ReservationEndDate" values are Not equal
			}
	
			if(t1.m_bolhasAccomodation != t2.m_bolhasAccomodation) {
				return false;	//	because "hasAccomodation" values are Not equal
			}
	
			if(t1.m_intAccomodationPrice != t2.m_intAccomodationPrice) {
				return false;	//	because "AccomodationPrice" values are Not equal
			}
	
			if(t1.m_bolhasFlight != t2.m_bolhasFlight) {
				return false;	//	because "hasFlight" values are Not equal
			}
	
			if(t1.m_intFlightPrice != t2.m_intFlightPrice) {
				return false;	//	because "FlightPrice" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(TourReservations t1, TourReservations t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" TourReservationID = \"");
			retValue.Append(m_intTourReservationID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    ReservationID = \"");
			retValue.Append(m_intReservationID);
			retValue.Append("\"\n");
				retValue.Append("    BookingDate = \"");
			retValue.Append(m_dtBookingDate);
			retValue.Append("\"\n");
				retValue.Append("    TourID = \"");
			retValue.Append(m_intTourID);
			retValue.Append("\"\n");
				retValue.Append("    TourType = \"");
			retValue.Append(m_intTourType);
			retValue.Append("\"\n");
				retValue.Append("    AdultCount = \"");
			retValue.Append(m_intAdultCount);
			retValue.Append("\"\n");
				retValue.Append("    ChildCount = \"");
			retValue.Append(m_intChildCount);
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
				retValue.Append("    ReservationStartDate = \"");
			retValue.Append(m_dtReservationStartDate);
			retValue.Append("\"\n");
				retValue.Append("    ReservationEndDate = \"");
			retValue.Append(m_dtReservationEndDate);
			retValue.Append("\"\n");
				retValue.Append("    hasAccomodation = \"");
			retValue.Append(m_bolhasAccomodation);
			retValue.Append("\"\n");
				retValue.Append("    AccomodationPrice = \"");
			retValue.Append(m_intAccomodationPrice);
			retValue.Append("\"\n");
				retValue.Append("    hasFlight = \"");
			retValue.Append(m_bolhasFlight);
			retValue.Append("\"\n");
				retValue.Append("    FlightPrice = \"");
			retValue.Append(m_intFlightPrice);
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
			if (!(o is TourReservations)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (TourReservations)o;
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
