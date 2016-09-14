using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class TransferReservations {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intTransferReservationID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intReservationID;
		private SqlInt32 m_intTransferDirection;
		private SqlInt32 m_intTransferType;
		private SqlInt32 m_intGuestCount;
		private SqlDouble m_dblTotalPriceUSD;
		private SqlDouble m_dblPerGuestPriceUSD;
		private SqlDouble m_dblTotalPriceEUR;
		private SqlDouble m_dblPerGuestPriceEUR;
		private SqlDateTime m_dtBookingDate;
		private SqlDateTime m_dtTransferDate;
		private SqlDouble m_dblGuidancePriceUSD;
		private SqlDouble m_dblGuidancePriceEUR;
		private SqlInt32 m_intPortID;
		private SqlString m_strNotes;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public TransferReservations() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all TransferReservations from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the TransferReservations</returns>
		public static SqlDataReader GetAllTransferReservationsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TransferReservations__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllTransferReservationsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_TransferReservations__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all TransferReservations from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTransferReservations() {
			SqlDataReader dr = GetAllTransferReservationsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates TransferReservations for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the TransferReservations records</param>
		/// <returns>The Hashtable containing TransferReservations objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            TransferReservations myTransferReservations = new TransferReservations();
            
            myTransferReservations.m_intTransferReservationID = dr.GetSqlInt32(0);
            myTransferReservations.m_intCustomerID = dr.GetSqlInt32(1);
            myTransferReservations.m_intReservationID = dr.GetSqlInt32(2);
            myTransferReservations.m_intTransferDirection = dr.GetSqlInt32(3);
            myTransferReservations.m_intTransferType = dr.GetSqlInt32(4);
            myTransferReservations.m_intGuestCount = dr.GetSqlInt32(5);
            myTransferReservations.m_dblTotalPriceUSD = dr.GetSqlDouble(6);
            myTransferReservations.m_dblPerGuestPriceUSD = dr.GetSqlDouble(7);
            myTransferReservations.m_dblTotalPriceEUR = dr.GetSqlDouble(8);
            myTransferReservations.m_dblPerGuestPriceEUR = dr.GetSqlDouble(9);
            myTransferReservations.m_dtBookingDate = dr.GetSqlDateTime(10);
            myTransferReservations.m_dtTransferDate = dr.GetSqlDateTime(11);
            myTransferReservations.m_dblGuidancePriceUSD = dr.GetSqlDouble(12);
            myTransferReservations.m_dblGuidancePriceEUR = dr.GetSqlDouble(13);
            myTransferReservations.m_intPortID = dr.GetSqlInt32(14);
            myTransferReservations.m_strNotes = dr.GetSqlString(15);
            
            result.Add(myTransferReservations.TransferReservationID, myTransferReservations);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 TransferReservationID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.TransferReservationID = m_intTransferReservationID;
				return pk;
			}
		}
			/// <summary>
		/// The TransferReservationID column in the DB
		/// </summary>
		public int TransferReservationID {
			get {
				return (int)m_intTransferReservationID;
			}
			set {
				m_intTransferReservationID = value;
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
		/// The TransferDirection column in the DB
		/// </summary>
		public int TransferDirection {
			get {
				return (int)m_intTransferDirection;
			}
			set {
				m_intTransferDirection = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TransferType column in the DB
		/// </summary>
		public int TransferType {
			get {
				return (int)m_intTransferType;
			}
			set {
				m_intTransferType = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The GuestCount column in the DB
		/// </summary>
		public int GuestCount {
			get {
				return (int)m_intGuestCount;
			}
			set {
				m_intGuestCount = value;
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
		/// The TransferDate column in the DB
		/// </summary>
		public DateTime TransferDate {
			get {
				return (DateTime)m_dtTransferDate;
			}
			set {
				m_dtTransferDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The GuidancePriceUSD column in the DB
		/// </summary>
		public double GuidancePriceUSD {
			get {
				return (double)m_dblGuidancePriceUSD;
			}
			set {
				m_dblGuidancePriceUSD = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The GuidancePriceEUR column in the DB
		/// </summary>
		public double GuidancePriceEUR {
			get {
				return (double)m_dblGuidancePriceEUR;
			}
			set {
				m_dblGuidancePriceEUR = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PortID column in the DB
		/// </summary>
		public int PortID {
			get {
				return (int)m_intPortID;
			}
			set {
				m_intPortID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Notes column in the DB
		/// </summary>
		public string Notes {
			get {
				return (string)m_strNotes;
			}
			set {
				m_strNotes = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.TransferReservationID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intTransferReservationID"> TransferReservationID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intTransferReservationID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TransferReservations__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for TransferReservationID column
        param = new SqlParameter("@TransferReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intTransferReservationID;
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
		            m_intTransferReservationID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_intReservationID = reader.GetSqlInt32(2);
            m_intTransferDirection = reader.GetSqlInt32(3);
            m_intTransferType = reader.GetSqlInt32(4);
            m_intGuestCount = reader.GetSqlInt32(5);
            m_dblTotalPriceUSD = reader.GetSqlDouble(6);
            m_dblPerGuestPriceUSD = reader.GetSqlDouble(7);
            m_dblTotalPriceEUR = reader.GetSqlDouble(8);
            m_dblPerGuestPriceEUR = reader.GetSqlDouble(9);
            m_dtBookingDate = reader.GetSqlDateTime(10);
            m_dtTransferDate = reader.GetSqlDateTime(11);
            m_dblGuidancePriceUSD = reader.GetSqlDouble(12);
            m_dblGuidancePriceEUR = reader.GetSqlDouble(13);
            m_intPortID = reader.GetSqlInt32(14);
            m_strNotes = reader.GetSqlString(15);
		
			} else {
					//	set key values
		            m_intTransferReservationID = intTransferReservationID;
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
							cmd = DBHelper.getSprocCmd("proc_TransferReservations__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_TransferReservations__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TransferReservationID column
        param = new SqlParameter("@TransferReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferReservationID;
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
        
        // parameter for TransferDirection column
        param = new SqlParameter("@TransferDirection", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferDirection;
        cmd.Parameters.Add(param);
        
        // parameter for TransferType column
        param = new SqlParameter("@TransferType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferType;
        cmd.Parameters.Add(param);
        
        // parameter for GuestCount column
        param = new SqlParameter("@GuestCount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuestCount;
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
        
        // parameter for TransferDate column
        param = new SqlParameter("@TransferDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtTransferDate;
        cmd.Parameters.Add(param);
        
        // parameter for GuidancePriceUSD column
        param = new SqlParameter("@GuidancePriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblGuidancePriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for GuidancePriceEUR column
        param = new SqlParameter("@GuidancePriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblGuidancePriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for PortID column
        param = new SqlParameter("@PortID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPortID;
        cmd.Parameters.Add(param);
        
        // parameter for Notes column
        param = new SqlParameter("@Notes", SqlDbType.NVarChar, 1024);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strNotes;
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
				cmd = DBHelper.getSprocCmd("proc_TransferReservations__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TransferReservations__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for TransferReservationID column
        param = new SqlParameter("@TransferReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferReservationID;
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
        
        // parameter for TransferDirection column
        param = new SqlParameter("@TransferDirection", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferDirection;
        cmd.Parameters.Add(param);
        
        // parameter for TransferType column
        param = new SqlParameter("@TransferType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferType;
        cmd.Parameters.Add(param);
        
        // parameter for GuestCount column
        param = new SqlParameter("@GuestCount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuestCount;
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
        
        // parameter for TransferDate column
        param = new SqlParameter("@TransferDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtTransferDate;
        cmd.Parameters.Add(param);
        
        // parameter for GuidancePriceUSD column
        param = new SqlParameter("@GuidancePriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblGuidancePriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for GuidancePriceEUR column
        param = new SqlParameter("@GuidancePriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblGuidancePriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for PortID column
        param = new SqlParameter("@PortID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPortID;
        cmd.Parameters.Add(param);
        
        // parameter for Notes column
        param = new SqlParameter("@Notes", SqlDbType.NVarChar, 1024);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strNotes;
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
				cmd = DBHelper.getSprocCmd("proc_TransferReservations__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TransferReservations__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TransferReservationID column
        param = new SqlParameter("@TransferReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferReservationID;
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
		public static bool operator ==(TransferReservations t1, TransferReservations t2) {
			//	compare values
			if(t1.m_intTransferReservationID != t2.m_intTransferReservationID) {
				return false;	//	because "TransferReservationID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intReservationID != t2.m_intReservationID) {
				return false;	//	because "ReservationID" values are Not equal
			}
	
			if(t1.m_intTransferDirection != t2.m_intTransferDirection) {
				return false;	//	because "TransferDirection" values are Not equal
			}
	
			if(t1.m_intTransferType != t2.m_intTransferType) {
				return false;	//	because "TransferType" values are Not equal
			}
	
			if(t1.m_intGuestCount != t2.m_intGuestCount) {
				return false;	//	because "GuestCount" values are Not equal
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
	
			if(t1.m_dtTransferDate != t2.m_dtTransferDate) {
				return false;	//	because "TransferDate" values are Not equal
			}
	
			if(t1.m_dblGuidancePriceUSD != t2.m_dblGuidancePriceUSD) {
				return false;	//	because "GuidancePriceUSD" values are Not equal
			}
	
			if(t1.m_dblGuidancePriceEUR != t2.m_dblGuidancePriceEUR) {
				return false;	//	because "GuidancePriceEUR" values are Not equal
			}
	
			if(t1.m_intPortID != t2.m_intPortID) {
				return false;	//	because "PortID" values are Not equal
			}
	
			if(t1.m_strNotes != t2.m_strNotes) {
				return false;	//	because "Notes" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(TransferReservations t1, TransferReservations t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" TransferReservationID = \"");
			retValue.Append(m_intTransferReservationID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    ReservationID = \"");
			retValue.Append(m_intReservationID);
			retValue.Append("\"\n");
				retValue.Append("    TransferDirection = \"");
			retValue.Append(m_intTransferDirection);
			retValue.Append("\"\n");
				retValue.Append("    TransferType = \"");
			retValue.Append(m_intTransferType);
			retValue.Append("\"\n");
				retValue.Append("    GuestCount = \"");
			retValue.Append(m_intGuestCount);
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
				retValue.Append("    TransferDate = \"");
			retValue.Append(m_dtTransferDate);
			retValue.Append("\"\n");
				retValue.Append("    GuidancePriceUSD = \"");
			retValue.Append(m_dblGuidancePriceUSD);
			retValue.Append("\"\n");
				retValue.Append("    GuidancePriceEUR = \"");
			retValue.Append(m_dblGuidancePriceEUR);
			retValue.Append("\"\n");
				retValue.Append("    PortID = \"");
			retValue.Append(m_intPortID);
			retValue.Append("\"\n");
				retValue.Append("    Notes = \"");
			retValue.Append(m_strNotes);
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
			if (!(o is TransferReservations)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (TransferReservations)o;
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
