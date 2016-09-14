using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Tours {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intTourID;
		private SqlDouble m_dblUSDPrice;
		private SqlDouble m_dblEURPrice;
		private SqlDateTime m_dtStartDate;
		private SqlDateTime m_dtEndDate;
		private SqlBoolean m_bolisRecurrent;
		private SqlInt32 m_intMinCapacity;
		private SqlInt32 m_intStartCityID;
		private SqlInt32 m_intEndCityID;
		private SqlInt32 m_intCountryID;
		private SqlBoolean m_bolhasAccomodation;
		private SqlDouble m_dblAccomodationPriceEUR;
		private SqlDouble m_dblAccomodationPriceUSD;
		private SqlBoolean m_bolhasFlight;
		private SqlDouble m_dblFlightPriceEUR;
		private SqlDouble m_dblFlightPriceUSD;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
		private SqlBoolean m_bolisActive;
// members from ml table
private int m_intLanguageID;
		private Dictionary<int, SqlString> m_strName;
		private Dictionary<int, SqlString> m_strDescription;
		private Dictionary<int, SqlString> m_strRecommendation;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Tours() {
			Init();	//	init Object	
				
			m_strName = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();				
			m_strRecommendation = new Dictionary<int, SqlString>();
		}
		
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Tours(int LanguageID) {
			Init();	//	init Object
			
			this.m_intLanguageID = LanguageID;
							
			m_strName = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();				
			m_strRecommendation = new Dictionary<int, SqlString>();
		}

		/// <summary>
		/// Gets all Tours from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Tours</returns>
		public static SqlDataReader GetAllToursReader(int LanguageID) {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Tours__sel_all", conn);

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
		
		public static DataSet GetAllToursDataSet(int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Tours__sel_all", conn);


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
		/// Gets all Tours from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTours(int LanguageID) {
			SqlDataReader dr = GetAllToursReader(LanguageID);
			return ConvertReaderToHashTable(dr, LanguageID);
		}
		
		/// <summary>
		/// Creates Tours for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Tours records</param>
		/// <returns>The Hashtable containing Tours objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr, int LanguageID) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Tours myTours = new Tours(LanguageID);
            
            myTours.m_intTourID = dr.GetSqlInt32(0);
            myTours.m_dblUSDPrice = dr.GetSqlDouble(1);
            myTours.m_dblEURPrice = dr.GetSqlDouble(2);
            myTours.m_dtStartDate = dr.GetSqlDateTime(3);
            myTours.m_dtEndDate = dr.GetSqlDateTime(4);
            myTours.m_bolisRecurrent = dr.GetSqlBoolean(5);
            myTours.m_intMinCapacity = dr.GetSqlInt32(6);
            myTours.m_intStartCityID = dr.GetSqlInt32(7);
            myTours.m_intEndCityID = dr.GetSqlInt32(8);
            myTours.m_intCountryID = dr.GetSqlInt32(9);
            myTours.m_bolhasAccomodation = dr.GetSqlBoolean(10);
            myTours.m_dblAccomodationPriceEUR = dr.GetSqlDouble(11);
            myTours.m_dblAccomodationPriceUSD = dr.GetSqlDouble(12);
            myTours.m_bolhasFlight = dr.GetSqlBoolean(13);
            myTours.m_dblFlightPriceEUR = dr.GetSqlDouble(14);
            myTours.m_dblFlightPriceUSD = dr.GetSqlDouble(15);
            myTours.m_dtCreateDate = dr.GetSqlDateTime(16);
            myTours.m_intCreatedBy = dr.GetSqlInt32(17);
            myTours.m_dtModifyDate = dr.GetSqlDateTime(18);
            myTours.m_intModifiedBy = dr.GetSqlInt32(19);
            myTours.m_bolisActive = dr.GetSqlBoolean(20);
            
            result.Add(myTours.TourID, myTours);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 TourID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.TourID = m_intTourID;
				return pk;
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
		/// The USDPrice column in the DB
		/// </summary>
		public double USDPrice {
			get {
				return (double)m_dblUSDPrice;
			}
			set {
				m_dblUSDPrice = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The EURPrice column in the DB
		/// </summary>
		public double EURPrice {
			get {
				return (double)m_dblEURPrice;
			}
			set {
				m_dblEURPrice = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The StartDate column in the DB
		/// </summary>
		public DateTime StartDate {
			get {
				return (DateTime)m_dtStartDate;
			}
			set {
				m_dtStartDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The EndDate column in the DB
		/// </summary>
		public DateTime EndDate {
			get {
				return (DateTime)m_dtEndDate;
			}
			set {
				m_dtEndDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isRecurrent column in the DB
		/// </summary>
		public bool isRecurrent {
			get {
				return (bool)m_bolisRecurrent;
			}
			set {
				m_bolisRecurrent = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The MinCapacity column in the DB
		/// </summary>
		public int MinCapacity {
			get {
				return (int)m_intMinCapacity;
			}
			set {
				m_intMinCapacity = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The StartCityID column in the DB
		/// </summary>
		public int StartCityID {
			get {
				return (int)m_intStartCityID;
			}
			set {
				m_intStartCityID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The EndCityID column in the DB
		/// </summary>
		public int EndCityID {
			get {
				return (int)m_intEndCityID;
			}
			set {
				m_intEndCityID = value;
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
		/// The AccomodationPriceEUR column in the DB
		/// </summary>
		public double AccomodationPriceEUR {
			get {
				return (double)m_dblAccomodationPriceEUR;
			}
			set {
				m_dblAccomodationPriceEUR = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The AccomodationPriceUSD column in the DB
		/// </summary>
		public double AccomodationPriceUSD {
			get {
				return (double)m_dblAccomodationPriceUSD;
			}
			set {
				m_dblAccomodationPriceUSD = value;
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
		/// The FlightPriceEUR column in the DB
		/// </summary>
		public double FlightPriceEUR {
			get {
				return (double)m_dblFlightPriceEUR;
			}
			set {
				m_dblFlightPriceEUR = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The FlightPriceUSD column in the DB
		/// </summary>
		public double FlightPriceUSD {
			get {
				return (double)m_dblFlightPriceUSD;
			}
			set {
				m_dblFlightPriceUSD = value;
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
		/// The Name column from ML table
		/// </summary>
		public string Name {
			get { 
				return this.GetName(this.m_intLanguageID); 
			}
			set { 
				this.SetName(value, this.m_intLanguageID);
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
		/// The Recommendation column from ML table
		/// </summary>
		public string Recommendation {
			get { 
				return this.GetRecommendation(this.m_intLanguageID); 
			}
			set { 
				this.SetRecommendation(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Name column from ML table
		/// </summary>
		public string GetName(int LanguageID) {
			return this.m_strName[LanguageID].Value;
		}
		
		/// <summary>
		/// The Name column from ML table
		/// </summary>
		public void SetName(string Name, int LanguageID) {
			this.m_strName[LanguageID] = Name;
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
		/// The Recommendation column from ML table
		/// </summary>
		public string GetRecommendation(int LanguageID) {
			return this.m_strRecommendation[LanguageID].Value;
		}
		
		/// <summary>
		/// The Recommendation column from ML table
		/// </summary>
		public void SetRecommendation(string Recommendation, int LanguageID) {
			this.m_strRecommendation[LanguageID] = Recommendation;
		}
		
					/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.TourID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intTourID"> TourID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intTourID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Tours__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intTourID;
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
		            m_intTourID = reader.GetSqlInt32(0);
            m_dblUSDPrice = reader.GetSqlDouble(1);
            m_dblEURPrice = reader.GetSqlDouble(2);
            m_dtStartDate = reader.GetSqlDateTime(3);
            m_dtEndDate = reader.GetSqlDateTime(4);
            m_bolisRecurrent = reader.GetSqlBoolean(5);
            m_intMinCapacity = reader.GetSqlInt32(6);
            m_intStartCityID = reader.GetSqlInt32(7);
            m_intEndCityID = reader.GetSqlInt32(8);
            m_intCountryID = reader.GetSqlInt32(9);
            m_bolhasAccomodation = reader.GetSqlBoolean(10);
            m_dblAccomodationPriceEUR = reader.GetSqlDouble(11);
            m_dblAccomodationPriceUSD = reader.GetSqlDouble(12);
            m_bolhasFlight = reader.GetSqlBoolean(13);
            m_dblFlightPriceEUR = reader.GetSqlDouble(14);
            m_dblFlightPriceUSD = reader.GetSqlDouble(15);
            m_dtCreateDate = reader.GetSqlDateTime(16);
            m_intCreatedBy = reader.GetSqlInt32(17);
            m_dtModifyDate = reader.GetSqlDateTime(18);
            m_intModifiedBy = reader.GetSqlInt32(19);
            m_bolisActive = reader.GetSqlBoolean(20);
		
			
				cmd = DBHelper.getSprocCmd("proc_Tours__sel_ml_data", conn);
				
				            // parameter for TourID column
            param = new SqlParameter("@TourID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intTourID;
            cmd.Parameters.Add(param);
            
			
				reader.Close();
				reader = null;
				
				if(conn.State == ConnectionState.Closed) conn.Open();
				
				reader = cmd.ExecuteReader();

				//check if  anything was found
				while(reader.Read()) { 			
			m_strName.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(2));			
			m_strDescription.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(3));			
			m_strRecommendation.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(4));				}
				
			} else {
					//	set key values
		            m_intTourID = intTourID;
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
							cmd = DBHelper.getSprocCmd("proc_Tours__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Tours__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for USDPrice column
        param = new SqlParameter("@USDPrice", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblUSDPrice;
        cmd.Parameters.Add(param);
        
        // parameter for EURPrice column
        param = new SqlParameter("@EURPrice", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblEURPrice;
        cmd.Parameters.Add(param);
        
        // parameter for StartDate column
        param = new SqlParameter("@StartDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for EndDate column
        param = new SqlParameter("@EndDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for isRecurrent column
        param = new SqlParameter("@isRecurrent", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisRecurrent;
        cmd.Parameters.Add(param);
        
        // parameter for MinCapacity column
        param = new SqlParameter("@MinCapacity", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMinCapacity;
        cmd.Parameters.Add(param);
        
        // parameter for StartCityID column
        param = new SqlParameter("@StartCityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStartCityID;
        cmd.Parameters.Add(param);
        
        // parameter for EndCityID column
        param = new SqlParameter("@EndCityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intEndCityID;
        cmd.Parameters.Add(param);
        
        // parameter for CountryID column
        param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCountryID;
        cmd.Parameters.Add(param);
        
        // parameter for hasAccomodation column
        param = new SqlParameter("@hasAccomodation", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasAccomodation;
        cmd.Parameters.Add(param);
        
        // parameter for AccomodationPriceEUR column
        param = new SqlParameter("@AccomodationPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblAccomodationPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for AccomodationPriceUSD column
        param = new SqlParameter("@AccomodationPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblAccomodationPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for hasFlight column
        param = new SqlParameter("@hasFlight", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasFlight;
        cmd.Parameters.Add(param);
        
        // parameter for FlightPriceEUR column
        param = new SqlParameter("@FlightPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblFlightPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for FlightPriceUSD column
        param = new SqlParameter("@FlightPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblFlightPriceUSD;
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
			
								foreach(int langID in this.m_strRecommendation.Keys) {
						Tours_ML.Insert(retValue, langID, this.m_strName[langID].ToString(), this.m_strDescription[langID].ToString(), this.m_strRecommendation[langID].ToString());
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
				cmd = DBHelper.getSprocCmd("proc_Tours__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Tours__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
        cmd.Parameters.Add(param);
        
        // parameter for USDPrice column
        param = new SqlParameter("@USDPrice", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblUSDPrice;
        cmd.Parameters.Add(param);
        
        // parameter for EURPrice column
        param = new SqlParameter("@EURPrice", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblEURPrice;
        cmd.Parameters.Add(param);
        
        // parameter for StartDate column
        param = new SqlParameter("@StartDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for EndDate column
        param = new SqlParameter("@EndDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for isRecurrent column
        param = new SqlParameter("@isRecurrent", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisRecurrent;
        cmd.Parameters.Add(param);
        
        // parameter for MinCapacity column
        param = new SqlParameter("@MinCapacity", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMinCapacity;
        cmd.Parameters.Add(param);
        
        // parameter for StartCityID column
        param = new SqlParameter("@StartCityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStartCityID;
        cmd.Parameters.Add(param);
        
        // parameter for EndCityID column
        param = new SqlParameter("@EndCityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intEndCityID;
        cmd.Parameters.Add(param);
        
        // parameter for CountryID column
        param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCountryID;
        cmd.Parameters.Add(param);
        
        // parameter for hasAccomodation column
        param = new SqlParameter("@hasAccomodation", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasAccomodation;
        cmd.Parameters.Add(param);
        
        // parameter for AccomodationPriceEUR column
        param = new SqlParameter("@AccomodationPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblAccomodationPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for AccomodationPriceUSD column
        param = new SqlParameter("@AccomodationPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblAccomodationPriceUSD;
        cmd.Parameters.Add(param);
        
        // parameter for hasFlight column
        param = new SqlParameter("@hasFlight", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasFlight;
        cmd.Parameters.Add(param);
        
        // parameter for FlightPriceEUR column
        param = new SqlParameter("@FlightPriceEUR", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblFlightPriceEUR;
        cmd.Parameters.Add(param);
        
        // parameter for FlightPriceUSD column
        param = new SqlParameter("@FlightPriceUSD", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblFlightPriceUSD;
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
			
			
								Tours_ML objTours_ML = new Tours_ML();
					foreach(int langID in this.m_strRecommendation.Keys) {
						objTours_ML.TourID = (int)this.m_intTourID;
						objTours_ML.LanguageID = langID;
						objTours_ML.Name = this.m_strName[langID].ToString();
objTours_ML.Description = this.m_strDescription[langID].ToString();
objTours_ML.Recommendation = this.m_strRecommendation[langID].ToString();
 objTours_ML.Update();
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
				cmd = DBHelper.getSprocCmd("proc_Tours__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Tours__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TourID column
        param = new SqlParameter("@TourID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTourID;
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
		public static bool operator ==(Tours t1, Tours t2) {
			//	compare values
			if(t1.m_intTourID != t2.m_intTourID) {
				return false;	//	because "TourID" values are Not equal
			}
	
			if(t1.m_dblUSDPrice != t2.m_dblUSDPrice) {
				return false;	//	because "USDPrice" values are Not equal
			}
	
			if(t1.m_dblEURPrice != t2.m_dblEURPrice) {
				return false;	//	because "EURPrice" values are Not equal
			}
	
			if(t1.m_dtStartDate != t2.m_dtStartDate) {
				return false;	//	because "StartDate" values are Not equal
			}
	
			if(t1.m_dtEndDate != t2.m_dtEndDate) {
				return false;	//	because "EndDate" values are Not equal
			}
	
			if(t1.m_bolisRecurrent != t2.m_bolisRecurrent) {
				return false;	//	because "isRecurrent" values are Not equal
			}
	
			if(t1.m_intMinCapacity != t2.m_intMinCapacity) {
				return false;	//	because "MinCapacity" values are Not equal
			}
	
			if(t1.m_intStartCityID != t2.m_intStartCityID) {
				return false;	//	because "StartCityID" values are Not equal
			}
	
			if(t1.m_intEndCityID != t2.m_intEndCityID) {
				return false;	//	because "EndCityID" values are Not equal
			}
	
			if(t1.m_intCountryID != t2.m_intCountryID) {
				return false;	//	because "CountryID" values are Not equal
			}
	
			if(t1.m_bolhasAccomodation != t2.m_bolhasAccomodation) {
				return false;	//	because "hasAccomodation" values are Not equal
			}
	
			if(t1.m_dblAccomodationPriceEUR != t2.m_dblAccomodationPriceEUR) {
				return false;	//	because "AccomodationPriceEUR" values are Not equal
			}
	
			if(t1.m_dblAccomodationPriceUSD != t2.m_dblAccomodationPriceUSD) {
				return false;	//	because "AccomodationPriceUSD" values are Not equal
			}
	
			if(t1.m_bolhasFlight != t2.m_bolhasFlight) {
				return false;	//	because "hasFlight" values are Not equal
			}
	
			if(t1.m_dblFlightPriceEUR != t2.m_dblFlightPriceEUR) {
				return false;	//	because "FlightPriceEUR" values are Not equal
			}
	
			if(t1.m_dblFlightPriceUSD != t2.m_dblFlightPriceUSD) {
				return false;	//	because "FlightPriceUSD" values are Not equal
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
		public static bool operator !=(Tours t1, Tours t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" TourID = \"");
			retValue.Append(m_intTourID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    USDPrice = \"");
			retValue.Append(m_dblUSDPrice);
			retValue.Append("\"\n");
				retValue.Append("    EURPrice = \"");
			retValue.Append(m_dblEURPrice);
			retValue.Append("\"\n");
				retValue.Append("    StartDate = \"");
			retValue.Append(m_dtStartDate);
			retValue.Append("\"\n");
				retValue.Append("    EndDate = \"");
			retValue.Append(m_dtEndDate);
			retValue.Append("\"\n");
				retValue.Append("    isRecurrent = \"");
			retValue.Append(m_bolisRecurrent);
			retValue.Append("\"\n");
				retValue.Append("    MinCapacity = \"");
			retValue.Append(m_intMinCapacity);
			retValue.Append("\"\n");
				retValue.Append("    StartCityID = \"");
			retValue.Append(m_intStartCityID);
			retValue.Append("\"\n");
				retValue.Append("    EndCityID = \"");
			retValue.Append(m_intEndCityID);
			retValue.Append("\"\n");
				retValue.Append("    CountryID = \"");
			retValue.Append(m_intCountryID);
			retValue.Append("\"\n");
				retValue.Append("    hasAccomodation = \"");
			retValue.Append(m_bolhasAccomodation);
			retValue.Append("\"\n");
				retValue.Append("    AccomodationPriceEUR = \"");
			retValue.Append(m_dblAccomodationPriceEUR);
			retValue.Append("\"\n");
				retValue.Append("    AccomodationPriceUSD = \"");
			retValue.Append(m_dblAccomodationPriceUSD);
			retValue.Append("\"\n");
				retValue.Append("    hasFlight = \"");
			retValue.Append(m_bolhasFlight);
			retValue.Append("\"\n");
				retValue.Append("    FlightPriceEUR = \"");
			retValue.Append(m_dblFlightPriceEUR);
			retValue.Append("\"\n");
				retValue.Append("    FlightPriceUSD = \"");
			retValue.Append(m_dblFlightPriceUSD);
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
			if (!(o is Tours)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Tours)o;
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
