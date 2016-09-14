using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Hotels {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intHotelID;
		private SqlInt32 m_intHotelChainID;
		private SqlInt32 m_intHotelClassID;
		private SqlInt32 m_intCityID;
		private SqlInt32 m_intCountryID;
		private SqlString m_strCheckInTime;
		private SqlString m_strCheckOutTime;
		private SqlBoolean m_bolisNewRoomRequestable;
		private SqlInt32 m_intChildFirstAgeLimit;
		private SqlInt32 m_intChildFirstAgeDiscount;
		private SqlInt32 m_intChildSecondAgeLimit;
		private SqlInt32 m_intChildSecondAgeDiscount;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
		private SqlBoolean m_bolisActive;
// members from ml table
private int m_intLanguageID;
		private Dictionary<int, SqlString> m_strHotelName;
		private Dictionary<int, SqlString> m_strDescription;
		private Dictionary<int, SqlString> m_strMotto;
		private Dictionary<int, SqlString> m_strDirections;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Hotels() {
			Init();	//	init Object	
				
			m_strHotelName = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();				
			m_strMotto = new Dictionary<int, SqlString>();				
			m_strDirections = new Dictionary<int, SqlString>();
		}
		
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Hotels(int LanguageID) {
			Init();	//	init Object
			
			this.m_intLanguageID = LanguageID;
							
			m_strHotelName = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();				
			m_strMotto = new Dictionary<int, SqlString>();				
			m_strDirections = new Dictionary<int, SqlString>();
		}

		/// <summary>
		/// Gets all Hotels from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Hotels</returns>
		public static SqlDataReader GetAllHotelsReader(int LanguageID) {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Hotels__sel_all", conn);

			SqlParameter param;
			// parameter for LanguageID column
        	param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        	param.Direction = ParameterDirection.Input;
        	param.Value = LanguageID;
        	cmd.Parameters.Add(param);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllHotelsDataSet(int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Hotels__sel_all", conn);


			SqlParameter param;
			// parameter for LanguageID column
        	param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        	param.Direction = ParameterDirection.Input;
        	param.Value = LanguageID;
        	cmd.Parameters.Add(param);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Hotels from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllHotels(int LanguageID) {
			SqlDataReader dr = GetAllHotelsReader(LanguageID);
			return ConvertReaderToHashTable(dr, LanguageID);
		}
		
		/// <summary>
		/// Creates Hotels for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Hotels records</param>
		/// <returns>The Hashtable containing Hotels objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr, int LanguageID) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Hotels myHotels = new Hotels(LanguageID);
            
            myHotels.m_intHotelID = dr.GetSqlInt32(0);
            myHotels.m_intHotelChainID = dr.GetSqlInt32(1);
            myHotels.m_intHotelClassID = dr.GetSqlInt32(2);
            myHotels.m_intCityID = dr.GetSqlInt32(3);
            myHotels.m_intCountryID = dr.GetSqlInt32(4);
            myHotels.m_strCheckInTime = dr.GetSqlString(5);
            myHotels.m_strCheckOutTime = dr.GetSqlString(6);
            myHotels.m_bolisNewRoomRequestable = dr.GetSqlBoolean(7);
            myHotels.m_intChildFirstAgeLimit = dr.GetSqlInt32(8);
            myHotels.m_intChildFirstAgeDiscount = dr.GetSqlInt32(9);
            myHotels.m_intChildSecondAgeLimit = dr.GetSqlInt32(10);
            myHotels.m_intChildSecondAgeDiscount = dr.GetSqlInt32(11);
            myHotels.m_dtCreateDate = dr.GetSqlDateTime(12);
            myHotels.m_intCreatedBy = dr.GetSqlInt32(13);
            myHotels.m_dtModifyDate = dr.GetSqlDateTime(14);
            myHotels.m_intModifiedBy = dr.GetSqlInt32(15);
            myHotels.m_bolisActive = dr.GetSqlBoolean(16);
            
            result.Add(myHotels.HotelID, myHotels);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 HotelID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.HotelID = m_intHotelID;
				return pk;
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
		/// The HotelChainID column in the DB
		/// </summary>
		public int HotelChainID {
			get {
				return (int)m_intHotelChainID;
			}
			set {
				m_intHotelChainID = value;
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
		/// The CheckInTime column in the DB
		/// </summary>
		public string CheckInTime {
			get {
				return (string)m_strCheckInTime;
			}
			set {
				m_strCheckInTime = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CheckOutTime column in the DB
		/// </summary>
		public string CheckOutTime {
			get {
				return (string)m_strCheckOutTime;
			}
			set {
				m_strCheckOutTime = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isNewRoomRequestable column in the DB
		/// </summary>
		public bool isNewRoomRequestable {
			get {
				return (bool)m_bolisNewRoomRequestable;
			}
			set {
				m_bolisNewRoomRequestable = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ChildFirstAgeLimit column in the DB
		/// </summary>
		public int ChildFirstAgeLimit {
			get {
				return (int)m_intChildFirstAgeLimit;
			}
			set {
				m_intChildFirstAgeLimit = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ChildFirstAgeDiscount column in the DB
		/// </summary>
		public int ChildFirstAgeDiscount {
			get {
				return (int)m_intChildFirstAgeDiscount;
			}
			set {
				m_intChildFirstAgeDiscount = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ChildSecondAgeLimit column in the DB
		/// </summary>
		public int ChildSecondAgeLimit {
			get {
				return (int)m_intChildSecondAgeLimit;
			}
			set {
				m_intChildSecondAgeLimit = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ChildSecondAgeDiscount column in the DB
		/// </summary>
		public int ChildSecondAgeDiscount {
			get {
				return (int)m_intChildSecondAgeDiscount;
			}
			set {
				m_intChildSecondAgeDiscount = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CreateDate column in the DB
		/// </summary>
		public DateTime CreateDate {
			get {
				return (DateTime)m_dtCreateDate;
			}
			set {
				m_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CreatedBy column in the DB
		/// </summary>
		public int CreatedBy {
			get {
				return (int)m_intCreatedBy;
			}
			set {
				m_intCreatedBy = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ModifyDate column in the DB
		/// </summary>
		public DateTime ModifyDate {
			get {
				return (DateTime)m_dtModifyDate;
			}
			set {
				m_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ModifiedBy column in the DB
		/// </summary>
		public int ModifiedBy {
			get {
				return (int)m_intModifiedBy;
			}
			set {
				m_intModifiedBy = value;
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
			
		public int LanguageID {
			get { 
				return m_intLanguageID; 
			}
			set {
				m_intLanguageID = value;
			}
		}
							
		/// <summary>
		/// The HotelName column from ML table
		/// </summary>
		public string HotelName {
			get { 
				return this.GetHotelName(this.m_intLanguageID); 
			}
			set { 
				this.SetHotelName(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Description column from ML table
		/// </summary>
		public string Description {
			get { 
				return this.GetDescription(this.m_intLanguageID); 
			}
			set { 
				this.SetDescription(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Motto column from ML table
		/// </summary>
		public string Motto {
			get { 
				return this.GetMotto(this.m_intLanguageID); 
			}
			set { 
				this.SetMotto(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Directions column from ML table
		/// </summary>
		public string Directions {
			get { 
				return this.GetDirections(this.m_intLanguageID); 
			}
			set { 
				this.SetDirections(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The HotelName column from ML table
		/// </summary>
		public string GetHotelName(int LanguageID) {
			return this.m_strHotelName[LanguageID].Value;
		}
		
		/// <summary>
		/// The HotelName column from ML table
		/// </summary>
		public void SetHotelName(string HotelName, int LanguageID) {
			this.m_strHotelName[LanguageID] = HotelName;
		}
		
								
		/// <summary>
		/// The Description column from ML table
		/// </summary>
		public string GetDescription(int LanguageID) {
			return this.m_strDescription[LanguageID].Value;
		}
		
		/// <summary>
		/// The Description column from ML table
		/// </summary>
		public void SetDescription(string Description, int LanguageID) {
			this.m_strDescription[LanguageID] = Description;
		}
		
								
		/// <summary>
		/// The Motto column from ML table
		/// </summary>
		public string GetMotto(int LanguageID) {
			return this.m_strMotto[LanguageID].Value;
		}
		
		/// <summary>
		/// The Motto column from ML table
		/// </summary>
		public void SetMotto(string Motto, int LanguageID) {
			this.m_strMotto[LanguageID] = Motto;
		}
		
								
		/// <summary>
		/// The Directions column from ML table
		/// </summary>
		public string GetDirections(int LanguageID) {
			return this.m_strDirections[LanguageID].Value;
		}
		
		/// <summary>
		/// The Directions column from ML table
		/// </summary>
		public void SetDirections(string Directions, int LanguageID) {
			this.m_strDirections[LanguageID] = Directions;
		}
		
					/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.HotelID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intHotelID"> HotelID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intHotelID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Hotels__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intHotelID;
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
		            m_intHotelID = reader.GetSqlInt32(0);
            m_intHotelChainID = reader.GetSqlInt32(1);
            m_intHotelClassID = reader.GetSqlInt32(2);
            m_intCityID = reader.GetSqlInt32(3);
            m_intCountryID = reader.GetSqlInt32(4);
            m_strCheckInTime = reader.GetSqlString(5);
            m_strCheckOutTime = reader.GetSqlString(6);
            m_bolisNewRoomRequestable = reader.GetSqlBoolean(7);
            m_intChildFirstAgeLimit = reader.GetSqlInt32(8);
            m_intChildFirstAgeDiscount = reader.GetSqlInt32(9);
            m_intChildSecondAgeLimit = reader.GetSqlInt32(10);
            m_intChildSecondAgeDiscount = reader.GetSqlInt32(11);
            m_dtCreateDate = reader.GetSqlDateTime(12);
            m_intCreatedBy = reader.GetSqlInt32(13);
            m_dtModifyDate = reader.GetSqlDateTime(14);
            m_intModifiedBy = reader.GetSqlInt32(15);
            m_bolisActive = reader.GetSqlBoolean(16);
		
			
				cmd = DBHelper.getSprocCmd("proc_Hotels__sel_ml_data", conn);
				
				            // parameter for HotelID column
            param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intHotelID;
            cmd.Parameters.Add(param);
            
			
				reader.Close();
				reader = null;
				
				if(conn.State == ConnectionState.Closed) conn.Open();
				
				reader = cmd.ExecuteReader();

				//check if  anything was found
				while(reader.Read()) { 			
			m_strHotelName.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(2));			
			m_strDescription.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(3));			
			m_strMotto.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(4));			
			m_strDirections.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(5));				}
				
			} else {
					//	set key values
		            m_intHotelID = intHotelID;
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
							cmd = DBHelper.getSprocCmd("proc_Hotels__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Hotels__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelChainID column
        param = new SqlParameter("@HotelChainID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelChainID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelClassID column
        param = new SqlParameter("@HotelClassID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelClassID;
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
        
        // parameter for CheckInTime column
        param = new SqlParameter("@CheckInTime", SqlDbType.Char, 5);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCheckInTime;
        cmd.Parameters.Add(param);
        
        // parameter for CheckOutTime column
        param = new SqlParameter("@CheckOutTime", SqlDbType.Char, 5);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCheckOutTime;
        cmd.Parameters.Add(param);
        
        // parameter for isNewRoomRequestable column
        param = new SqlParameter("@isNewRoomRequestable", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisNewRoomRequestable;
        cmd.Parameters.Add(param);
        
        // parameter for ChildFirstAgeLimit column
        param = new SqlParameter("@ChildFirstAgeLimit", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildFirstAgeLimit;
        cmd.Parameters.Add(param);
        
        // parameter for ChildFirstAgeDiscount column
        param = new SqlParameter("@ChildFirstAgeDiscount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildFirstAgeDiscount;
        cmd.Parameters.Add(param);
        
        // parameter for ChildSecondAgeLimit column
        param = new SqlParameter("@ChildSecondAgeLimit", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildSecondAgeLimit;
        cmd.Parameters.Add(param);
        
        // parameter for ChildSecondAgeDiscount column
        param = new SqlParameter("@ChildSecondAgeDiscount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildSecondAgeDiscount;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for ModifyDate column
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtModifyDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifiedBy column
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intModifiedBy;
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
			
								foreach(int langID in this.m_strDirections.Keys) {
						Hotels_ML.Insert(retValue, langID, this.m_strHotelName[langID].ToString(), this.m_strDescription[langID].ToString(), this.m_strMotto[langID].ToString(), this.m_strDirections[langID].ToString());
					}
						
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
				cmd = DBHelper.getSprocCmd("proc_Hotels__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Hotels__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelChainID column
        param = new SqlParameter("@HotelChainID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelChainID;
        cmd.Parameters.Add(param);
        
        // parameter for HotelClassID column
        param = new SqlParameter("@HotelClassID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelClassID;
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
        
        // parameter for CheckInTime column
        param = new SqlParameter("@CheckInTime", SqlDbType.Char, 5);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCheckInTime;
        cmd.Parameters.Add(param);
        
        // parameter for CheckOutTime column
        param = new SqlParameter("@CheckOutTime", SqlDbType.Char, 5);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCheckOutTime;
        cmd.Parameters.Add(param);
        
        // parameter for isNewRoomRequestable column
        param = new SqlParameter("@isNewRoomRequestable", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisNewRoomRequestable;
        cmd.Parameters.Add(param);
        
        // parameter for ChildFirstAgeLimit column
        param = new SqlParameter("@ChildFirstAgeLimit", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildFirstAgeLimit;
        cmd.Parameters.Add(param);
        
        // parameter for ChildFirstAgeDiscount column
        param = new SqlParameter("@ChildFirstAgeDiscount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildFirstAgeDiscount;
        cmd.Parameters.Add(param);
        
        // parameter for ChildSecondAgeLimit column
        param = new SqlParameter("@ChildSecondAgeLimit", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildSecondAgeLimit;
        cmd.Parameters.Add(param);
        
        // parameter for ChildSecondAgeDiscount column
        param = new SqlParameter("@ChildSecondAgeDiscount", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intChildSecondAgeDiscount;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for ModifyDate column
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtModifyDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifiedBy column
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intModifiedBy;
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
			
			
								Hotels_ML objHotels_ML = new Hotels_ML();
					foreach(int langID in this.m_strDirections.Keys) {
						objHotels_ML.HotelID = (int)this.m_intHotelID;
						objHotels_ML.LanguageID = langID;
						objHotels_ML.HotelName = this.m_strHotelName[langID].ToString();
objHotels_ML.Description = this.m_strDescription[langID].ToString();
objHotels_ML.Motto = this.m_strMotto[langID].ToString();
objHotels_ML.Directions = this.m_strDirections[langID].ToString();
 objHotels_ML.Update();
					}
							
			
		
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
				cmd = DBHelper.getSprocCmd("proc_Hotels__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Hotels__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for HotelID column
        param = new SqlParameter("@HotelID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHotelID;
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
		public static bool operator ==(Hotels t1, Hotels t2) {
			//	compare values
			if(t1.m_intHotelID != t2.m_intHotelID) {
				return false;	//	because "HotelID" values are Not equal
			}
	
			if(t1.m_intHotelChainID != t2.m_intHotelChainID) {
				return false;	//	because "HotelChainID" values are Not equal
			}
	
			if(t1.m_intHotelClassID != t2.m_intHotelClassID) {
				return false;	//	because "HotelClassID" values are Not equal
			}
	
			if(t1.m_intCityID != t2.m_intCityID) {
				return false;	//	because "CityID" values are Not equal
			}
	
			if(t1.m_intCountryID != t2.m_intCountryID) {
				return false;	//	because "CountryID" values are Not equal
			}
	
			if(t1.m_strCheckInTime != t2.m_strCheckInTime) {
				return false;	//	because "CheckInTime" values are Not equal
			}
	
			if(t1.m_strCheckOutTime != t2.m_strCheckOutTime) {
				return false;	//	because "CheckOutTime" values are Not equal
			}
	
			if(t1.m_bolisNewRoomRequestable != t2.m_bolisNewRoomRequestable) {
				return false;	//	because "isNewRoomRequestable" values are Not equal
			}
	
			if(t1.m_intChildFirstAgeLimit != t2.m_intChildFirstAgeLimit) {
				return false;	//	because "ChildFirstAgeLimit" values are Not equal
			}
	
			if(t1.m_intChildFirstAgeDiscount != t2.m_intChildFirstAgeDiscount) {
				return false;	//	because "ChildFirstAgeDiscount" values are Not equal
			}
	
			if(t1.m_intChildSecondAgeLimit != t2.m_intChildSecondAgeLimit) {
				return false;	//	because "ChildSecondAgeLimit" values are Not equal
			}
	
			if(t1.m_intChildSecondAgeDiscount != t2.m_intChildSecondAgeDiscount) {
				return false;	//	because "ChildSecondAgeDiscount" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_intCreatedBy != t2.m_intCreatedBy) {
				return false;	//	because "CreatedBy" values are Not equal
			}
	
			if(t1.m_dtModifyDate != t2.m_dtModifyDate) {
				return false;	//	because "ModifyDate" values are Not equal
			}
	
			if(t1.m_intModifiedBy != t2.m_intModifiedBy) {
				return false;	//	because "ModifiedBy" values are Not equal
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
		public static bool operator !=(Hotels t1, Hotels t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" HotelID = \"");
			retValue.Append(m_intHotelID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    HotelChainID = \"");
			retValue.Append(m_intHotelChainID);
			retValue.Append("\"\n");
				retValue.Append("    HotelClassID = \"");
			retValue.Append(m_intHotelClassID);
			retValue.Append("\"\n");
				retValue.Append("    CityID = \"");
			retValue.Append(m_intCityID);
			retValue.Append("\"\n");
				retValue.Append("    CountryID = \"");
			retValue.Append(m_intCountryID);
			retValue.Append("\"\n");
				retValue.Append("    CheckInTime = \"");
			retValue.Append(m_strCheckInTime);
			retValue.Append("\"\n");
				retValue.Append("    CheckOutTime = \"");
			retValue.Append(m_strCheckOutTime);
			retValue.Append("\"\n");
				retValue.Append("    isNewRoomRequestable = \"");
			retValue.Append(m_bolisNewRoomRequestable);
			retValue.Append("\"\n");
				retValue.Append("    ChildFirstAgeLimit = \"");
			retValue.Append(m_intChildFirstAgeLimit);
			retValue.Append("\"\n");
				retValue.Append("    ChildFirstAgeDiscount = \"");
			retValue.Append(m_intChildFirstAgeDiscount);
			retValue.Append("\"\n");
				retValue.Append("    ChildSecondAgeLimit = \"");
			retValue.Append(m_intChildSecondAgeLimit);
			retValue.Append("\"\n");
				retValue.Append("    ChildSecondAgeDiscount = \"");
			retValue.Append(m_intChildSecondAgeDiscount);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
			retValue.Append("\"\n");
				retValue.Append("    CreatedBy = \"");
			retValue.Append(m_intCreatedBy);
			retValue.Append("\"\n");
				retValue.Append("    ModifyDate = \"");
			retValue.Append(m_dtModifyDate);
			retValue.Append("\"\n");
				retValue.Append("    ModifiedBy = \"");
			retValue.Append(m_intModifiedBy);
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
			if (!(o is Hotels)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Hotels)o;
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
