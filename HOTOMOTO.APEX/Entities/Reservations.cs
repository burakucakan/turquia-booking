using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Reservations {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intReservationID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intUserID;
		private SqlInt32 m_intReservationType;
		private SqlString m_strDescription;
		private SqlString m_strReservationCode;
		private SqlDateTime m_dtBookingDate;
		private SqlInt32 m_intBookingStateID;
		private SqlDouble m_dblTotalPriceEUR;
		private SqlDouble m_dblTotalPriceUSD;
		private SqlDouble m_dblTotalPriceYTL;
		private SqlDouble m_dblTaxYTL;
		private SqlDouble m_dblTaxRatio;
		private SqlDouble m_dblDiscountRatio;
		private SqlString m_strCampaignCode;
		private SqlInt32 m_intPaymentType;
		private SqlInt32 m_intReservationStatus;
		private SqlBoolean m_bolisActive;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Reservations() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Reservations from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Reservations</returns>
		public static SqlDataReader GetAllReservationsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Reservations__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllReservationsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Reservations__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Reservations from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllReservations() {
			SqlDataReader dr = GetAllReservationsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Reservations for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Reservations records</param>
		/// <returns>The Hashtable containing Reservations objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Reservations myReservations = new Reservations();
            
            myReservations.m_intReservationID = dr.GetSqlInt32(0);
            myReservations.m_intCustomerID = dr.GetSqlInt32(1);
            myReservations.m_intUserID = dr.GetSqlInt32(2);
            myReservations.m_intReservationType = dr.GetSqlInt32(3);
            myReservations.m_strDescription = dr.GetSqlString(4);
            myReservations.m_strReservationCode = dr.GetSqlString(5);
            myReservations.m_dtBookingDate = dr.GetSqlDateTime(6);
            myReservations.m_intBookingStateID = dr.GetSqlInt32(7);
            myReservations.m_dblTotalPriceEUR = dr.GetSqlDouble(8);
            myReservations.m_dblTotalPriceUSD = dr.GetSqlDouble(9);
            myReservations.m_dblTotalPriceYTL = dr.GetSqlDouble(10);
            myReservations.m_dblTaxYTL = dr.GetSqlDouble(11);
            myReservations.m_dblTaxRatio = dr.GetSqlDouble(12);
            myReservations.m_dblDiscountRatio = dr.GetSqlDouble(13);
            myReservations.m_strCampaignCode = dr.GetSqlString(14);
            myReservations.m_intPaymentType = dr.GetSqlInt32(15);
            myReservations.m_intReservationStatus = dr.GetSqlInt32(16);
            myReservations.m_bolisActive = dr.GetSqlBoolean(17);
            
            result.Add(myReservations.ReservationID, myReservations);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 ReservationID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.ReservationID = m_intReservationID;
				return pk;
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
		/// The UserID column in the DB
		/// </summary>
		public int UserID {
			get {
				return (int)m_intUserID;
			}
			set {
				m_intUserID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReservationType column in the DB
		/// </summary>
		public int ReservationType {
			get {
				return (int)m_intReservationType;
			}
			set {
				m_intReservationType = value;
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
		/// The ReservationCode column in the DB
		/// </summary>
		public string ReservationCode {
			get {
				return (string)m_strReservationCode;
			}
			set {
				m_strReservationCode = value;
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
		/// The BookingStateID column in the DB
		/// </summary>
		public int BookingStateID {
			get {
				return (int)m_intBookingStateID;
			}
			set {
				m_intBookingStateID = value;
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
		/// The TotalPriceYTL column in the DB
		/// </summary>
		public double TotalPriceYTL {
			get {
				return (double)m_dblTotalPriceYTL;
			}
			set {
				m_dblTotalPriceYTL = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TaxYTL column in the DB
		/// </summary>
		public double TaxYTL {
			get {
				return (double)m_dblTaxYTL;
			}
			set {
				m_dblTaxYTL = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TaxRatio column in the DB
		/// </summary>
		public double TaxRatio {
			get {
				return (double)m_dblTaxRatio;
			}
			set {
				m_dblTaxRatio = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The DiscountRatio column in the DB
		/// </summary>
		public double DiscountRatio {
			get {
				return (double)m_dblDiscountRatio;
			}
			set {
				m_dblDiscountRatio = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CampaignCode column in the DB
		/// </summary>
		public string CampaignCode {
			get {
				return (string)m_strCampaignCode;
			}
			set {
				m_strCampaignCode = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PaymentType column in the DB
		/// </summary>
		public int PaymentType {
			get {
				return (int)m_intPaymentType;
			}
			set {
				m_intPaymentType = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReservationStatus column in the DB
		/// </summary>
		public int ReservationStatus {
			get {
				return (int)m_intReservationStatus;
			}
			set {
				m_intReservationStatus = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isActive column in the DB
		/// </summary>
		public bool isActive {
			get {
				return (bool)m_bolisActive;
			}
			set {
				m_bolisActive = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.ReservationID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intReservationID"> ReservationID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intReservationID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Reservations__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intReservationID;
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
		            m_intReservationID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_intUserID = reader.GetSqlInt32(2);
            m_intReservationType = reader.GetSqlInt32(3);
            m_strDescription = reader.GetSqlString(4);
            m_strReservationCode = reader.GetSqlString(5);
            m_dtBookingDate = reader.GetSqlDateTime(6);
            m_intBookingStateID = reader.GetSqlInt32(7);
            m_dblTotalPriceEUR = reader.GetSqlDouble(8);
            m_dblTotalPriceUSD = reader.GetSqlDouble(9);
            m_dblTotalPriceYTL = reader.GetSqlDouble(10);
            m_dblTaxYTL = reader.GetSqlDouble(11);
            m_dblTaxRatio = reader.GetSqlDouble(12);
            m_dblDiscountRatio = reader.GetSqlDouble(13);
            m_strCampaignCode = reader.GetSqlString(14);
            m_intPaymentType = reader.GetSqlInt32(15);
            m_intReservationStatus = reader.GetSqlInt32(16);
            m_bolisActive = reader.GetSqlBoolean(17);
		
			} else {
					//	set key values
		            m_intReservationID = intReservationID;
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
							cmd = DBHelper.getSprocCmd("proc_Reservations__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Reservations__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationType column
        param = new SqlParameter("@ReservationType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationType;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 256);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationCode column
        param = new SqlParameter("@ReservationCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReservationCode;
        cmd.Parameters.Add(param);
        
        // parameter for BookingDate column
        param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingDate;
        cmd.Parameters.Add(param);
        
        // parameter for BookingStateID column
        param = new SqlParameter("@BookingStateID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBookingStateID;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceEUR column
        param = new SqlParameter("@TotalPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceUSD column
        param = new SqlParameter("@TotalPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceYTL column
        param = new SqlParameter("@TotalPriceYTL", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceYTL;
        cmd.Parameters.Add(param);
        
        // parameter for TaxYTL column
        param = new SqlParameter("@TaxYTL", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTaxYTL;
        cmd.Parameters.Add(param);
        
        // parameter for TaxRatio column
        param = new SqlParameter("@TaxRatio", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTaxRatio;
        cmd.Parameters.Add(param);
        
        // parameter for DiscountRatio column
        param = new SqlParameter("@DiscountRatio", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblDiscountRatio;
        cmd.Parameters.Add(param);
        
        // parameter for CampaignCode column
        param = new SqlParameter("@CampaignCode", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCampaignCode;
        cmd.Parameters.Add(param);
        
        // parameter for PaymentType column
        param = new SqlParameter("@PaymentType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPaymentType;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationStatus column
        param = new SqlParameter("@ReservationStatus", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationStatus;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
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
				cmd = DBHelper.getSprocCmd("proc_Reservations__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Reservations__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationType column
        param = new SqlParameter("@ReservationType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationType;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 256);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationCode column
        param = new SqlParameter("@ReservationCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReservationCode;
        cmd.Parameters.Add(param);
        
        // parameter for BookingDate column
        param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingDate;
        cmd.Parameters.Add(param);
        
        // parameter for BookingStateID column
        param = new SqlParameter("@BookingStateID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBookingStateID;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceEUR column
        param = new SqlParameter("@TotalPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceUSD column
        param = new SqlParameter("@TotalPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for TotalPriceYTL column
        param = new SqlParameter("@TotalPriceYTL", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTotalPriceYTL;
        cmd.Parameters.Add(param);
        
        // parameter for TaxYTL column
        param = new SqlParameter("@TaxYTL", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTaxYTL;
        cmd.Parameters.Add(param);
        
        // parameter for TaxRatio column
        param = new SqlParameter("@TaxRatio", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblTaxRatio;
        cmd.Parameters.Add(param);
        
        // parameter for DiscountRatio column
        param = new SqlParameter("@DiscountRatio", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblDiscountRatio;
        cmd.Parameters.Add(param);
        
        // parameter for CampaignCode column
        param = new SqlParameter("@CampaignCode", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCampaignCode;
        cmd.Parameters.Add(param);
        
        // parameter for PaymentType column
        param = new SqlParameter("@PaymentType", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPaymentType;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationStatus column
        param = new SqlParameter("@ReservationStatus", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationStatus;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
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
				cmd = DBHelper.getSprocCmd("proc_Reservations__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Reservations__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
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
		public static bool operator ==(Reservations t1, Reservations t2) {
			//	compare values
			if(t1.m_intReservationID != t2.m_intReservationID) {
				return false;	//	because "ReservationID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intUserID != t2.m_intUserID) {
				return false;	//	because "UserID" values are Not equal
			}
	
			if(t1.m_intReservationType != t2.m_intReservationType) {
				return false;	//	because "ReservationType" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			if(t1.m_strReservationCode != t2.m_strReservationCode) {
				return false;	//	because "ReservationCode" values are Not equal
			}
	
			if(t1.m_dtBookingDate != t2.m_dtBookingDate) {
				return false;	//	because "BookingDate" values are Not equal
			}
	
			if(t1.m_intBookingStateID != t2.m_intBookingStateID) {
				return false;	//	because "BookingStateID" values are Not equal
			}
	
			if(t1.m_dblTotalPriceEUR != t2.m_dblTotalPriceEUR) {
				return false;	//	because "TotalPriceEUR" values are Not equal
			}
	
			if(t1.m_dblTotalPriceUSD != t2.m_dblTotalPriceUSD) {
				return false;	//	because "TotalPriceUSD" values are Not equal
			}
	
			if(t1.m_dblTotalPriceYTL != t2.m_dblTotalPriceYTL) {
				return false;	//	because "TotalPriceYTL" values are Not equal
			}
	
			if(t1.m_dblTaxYTL != t2.m_dblTaxYTL) {
				return false;	//	because "TaxYTL" values are Not equal
			}
	
			if(t1.m_dblTaxRatio != t2.m_dblTaxRatio) {
				return false;	//	because "TaxRatio" values are Not equal
			}
	
			if(t1.m_dblDiscountRatio != t2.m_dblDiscountRatio) {
				return false;	//	because "DiscountRatio" values are Not equal
			}
	
			if(t1.m_strCampaignCode != t2.m_strCampaignCode) {
				return false;	//	because "CampaignCode" values are Not equal
			}
	
			if(t1.m_intPaymentType != t2.m_intPaymentType) {
				return false;	//	because "PaymentType" values are Not equal
			}
	
			if(t1.m_intReservationStatus != t2.m_intReservationStatus) {
				return false;	//	because "ReservationStatus" values are Not equal
			}
	
			if(t1.m_bolisActive != t2.m_bolisActive) {
				return false;	//	because "isActive" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Reservations t1, Reservations t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" ReservationID = \"");
			retValue.Append(m_intReservationID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    UserID = \"");
			retValue.Append(m_intUserID);
			retValue.Append("\"\n");
				retValue.Append("    ReservationType = \"");
			retValue.Append(m_intReservationType);
			retValue.Append("\"\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
			retValue.Append("\"\n");
				retValue.Append("    ReservationCode = \"");
			retValue.Append(m_strReservationCode);
			retValue.Append("\"\n");
				retValue.Append("    BookingDate = \"");
			retValue.Append(m_dtBookingDate);
			retValue.Append("\"\n");
				retValue.Append("    BookingStateID = \"");
			retValue.Append(m_intBookingStateID);
			retValue.Append("\"\n");
				retValue.Append("    TotalPriceEUR = \"");
			retValue.Append(m_dblTotalPriceEUR);
			retValue.Append("\"\n");
				retValue.Append("    TotalPriceUSD = \"");
			retValue.Append(m_dblTotalPriceUSD);
			retValue.Append("\"\n");
				retValue.Append("    TotalPriceYTL = \"");
			retValue.Append(m_dblTotalPriceYTL);
			retValue.Append("\"\n");
				retValue.Append("    TaxYTL = \"");
			retValue.Append(m_dblTaxYTL);
			retValue.Append("\"\n");
				retValue.Append("    TaxRatio = \"");
			retValue.Append(m_dblTaxRatio);
			retValue.Append("\"\n");
				retValue.Append("    DiscountRatio = \"");
			retValue.Append(m_dblDiscountRatio);
			retValue.Append("\"\n");
				retValue.Append("    CampaignCode = \"");
			retValue.Append(m_strCampaignCode);
			retValue.Append("\"\n");
				retValue.Append("    PaymentType = \"");
			retValue.Append(m_intPaymentType);
			retValue.Append("\"\n");
				retValue.Append("    ReservationStatus = \"");
			retValue.Append(m_intReservationStatus);
			retValue.Append("\"\n");
				retValue.Append("    isActive = \"");
			retValue.Append(m_bolisActive);
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
			if (!(o is Reservations)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Reservations)o;
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
