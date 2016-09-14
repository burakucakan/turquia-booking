using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Cities {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intCityID;
		private SqlInt32 m_intCountryID;
		private SqlBoolean m_bolisActive;
// members from ml table
private int m_intLanguageID;
		private Dictionary<int, SqlString> m_strCityName;
		private Dictionary<int, SqlString> m_strLink;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Cities() {
			Init();	//	init Object	
				
			m_strCityName = new Dictionary<int, SqlString>();				
			m_strLink = new Dictionary<int, SqlString>();
		}
		
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Cities(int LanguageID) {
			Init();	//	init Object
			
			this.m_intLanguageID = LanguageID;
							
			m_strCityName = new Dictionary<int, SqlString>();				
			m_strLink = new Dictionary<int, SqlString>();
		}

		/// <summary>
		/// Gets all Cities from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Cities</returns>
		public static SqlDataReader GetAllCitiesReader(int LanguageID) {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Cities__sel_all", conn);

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
		
		public static DataSet GetAllCitiesDataSet(int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Cities__sel_all", conn);


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
		/// Gets all Cities from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllCities(int LanguageID) {
			SqlDataReader dr = GetAllCitiesReader(LanguageID);
			return ConvertReaderToHashTable(dr, LanguageID);
		}
		
		/// <summary>
		/// Creates Cities for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Cities records</param>
		/// <returns>The Hashtable containing Cities objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr, int LanguageID) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Cities myCities = new Cities(LanguageID);
            
            myCities.m_intCityID = dr.GetSqlInt32(0);
            myCities.m_intCountryID = dr.GetSqlInt32(1);
            myCities.m_bolisActive = dr.GetSqlBoolean(2);
            
            result.Add(myCities.CityID, myCities);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 CityID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.CityID = m_intCityID;
				return pk;
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
		/// The CityName column from ML table
		/// </summary>
		public string CityName {
			get { 
				return this.GetCityName(this.m_intLanguageID); 
			}
			set { 
				this.SetCityName(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Link column from ML table
		/// </summary>
		public string Link {
			get { 
				return this.GetLink(this.m_intLanguageID); 
			}
			set { 
				this.SetLink(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The CityName column from ML table
		/// </summary>
		public string GetCityName(int LanguageID) {
			return this.m_strCityName[LanguageID].Value;
		}
		
		/// <summary>
		/// The CityName column from ML table
		/// </summary>
		public void SetCityName(string CityName, int LanguageID) {
			this.m_strCityName[LanguageID] = CityName;
		}
		
								
		/// <summary>
		/// The Link column from ML table
		/// </summary>
		public string GetLink(int LanguageID) {
			return this.m_strLink[LanguageID].Value;
		}
		
		/// <summary>
		/// The Link column from ML table
		/// </summary>
		public void SetLink(string Link, int LanguageID) {
			this.m_strLink[LanguageID] = Link;
		}
		
					/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.CityID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intCityID"> CityID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intCityID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Cities__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for CityID column
        param = new SqlParameter("@CityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intCityID;
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
		            m_intCityID = reader.GetSqlInt32(0);
            m_intCountryID = reader.GetSqlInt32(1);
            m_bolisActive = reader.GetSqlBoolean(2);
		
			
				cmd = DBHelper.getSprocCmd("proc_Cities__sel_ml_data", conn);
				
				            // parameter for CityID column
            param = new SqlParameter("@CityID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intCityID;
            cmd.Parameters.Add(param);
            
			
				reader.Close();
				reader = null;
				
				if(conn.State == ConnectionState.Closed) conn.Open();
				
				reader = cmd.ExecuteReader();

				//check if  anything was found
				while(reader.Read()) { 			
			m_strCityName.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(2));			
			m_strLink.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(3));				}
				
			} else {
					//	set key values
		            m_intCityID = intCityID;
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
							cmd = DBHelper.getSprocCmd("proc_Cities__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Cities__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
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
			
								foreach(int langID in this.m_strLink.Keys) {
						Cities_ML.Insert(retValue, langID, this.m_strCityName[langID].ToString(), this.m_strLink[langID].ToString());
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
				cmd = DBHelper.getSprocCmd("proc_Cities__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Cities__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
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
			
			
								Cities_ML objCities_ML = new Cities_ML();
					foreach(int langID in this.m_strLink.Keys) {
						objCities_ML.CityID = (int)this.m_intCityID;
						objCities_ML.LanguageID = langID;
						objCities_ML.CityName = this.m_strCityName[langID].ToString();
objCities_ML.Link = this.m_strLink[langID].ToString();
 objCities_ML.Update();
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
				cmd = DBHelper.getSprocCmd("proc_Cities__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Cities__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for CityID column
        param = new SqlParameter("@CityID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCityID;
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
		public static bool operator ==(Cities t1, Cities t2) {
			//	compare values
			if(t1.m_intCityID != t2.m_intCityID) {
				return false;	//	because "CityID" values are Not equal
			}
	
			if(t1.m_intCountryID != t2.m_intCountryID) {
				return false;	//	because "CountryID" values are Not equal
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
		public static bool operator !=(Cities t1, Cities t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" CityID = \"");
			retValue.Append(m_intCityID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CountryID = \"");
			retValue.Append(m_intCountryID);
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
			if (!(o is Cities)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Cities)o;
		}
	
		/// <summary>
		/// Overrides the GetHashCode Function.
		/// </summary>
		/// <returns>Bool if the two objects are identical.</returns>
		public override int GetHashCode() {
			return this.ToString().GetHashCode();
		}
		
		
		
		
				public static DataSet GetCitiesByCountry(int CountryID, int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Cities__sel_by_country", conn);


			SqlParameter param;
			// parameter for CountryID column
        	param = new SqlParameter("@CountryID", SqlDbType.Int, 4);
        	param.Direction = ParameterDirection.Input;
        	param.Value = CountryID;
        	cmd.Parameters.Add(param);
			
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
		/// The init Function.
		/// </summary>
		private void Init() {
			m_aAction = Action.Insert;	//	initial action  
			m_bIsDirty = false;	//	Objectstring"clean" upon init
		}
	}
}
