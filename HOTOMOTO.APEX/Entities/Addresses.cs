using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Addresses {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intAddressID;
		private SqlInt32 m_intAddressTypeID;
		private SqlString m_strStreetAddress;
		private SqlString m_strPostalCode;
		private SqlString m_strTown;
		private SqlInt32 m_intCityID;
		private SqlInt32 m_intCountryID;
		private SqlDateTime m_dtCreateDate;
		private SqlBoolean m_bolisDefault;
		private SqlBoolean m_bolisActive;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Addresses() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Addresses from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Addresses</returns>
		public static SqlDataReader GetAllAddressesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Addresses__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllAddressesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Addresses__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Addresses from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllAddresses() {
			SqlDataReader dr = GetAllAddressesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Addresses for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Addresses records</param>
		/// <returns>The Hashtable containing Addresses objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Addresses myAddresses = new Addresses();
            
            myAddresses.m_intAddressID = dr.GetSqlInt32(0);
            myAddresses.m_intAddressTypeID = dr.GetSqlInt32(1);
            myAddresses.m_strStreetAddress = dr.GetSqlString(2);
            myAddresses.m_strPostalCode = dr.GetSqlString(3);
            myAddresses.m_strTown = dr.GetSqlString(4);
            myAddresses.m_intCityID = dr.GetSqlInt32(5);
            myAddresses.m_intCountryID = dr.GetSqlInt32(6);
            myAddresses.m_dtCreateDate = dr.GetSqlDateTime(7);
            myAddresses.m_bolisDefault = dr.GetSqlBoolean(8);
            myAddresses.m_bolisActive = dr.GetSqlBoolean(9);
            
            result.Add(myAddresses.AddressID, myAddresses);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 AddressID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.AddressID = m_intAddressID;
				return pk;
			}
		}
			/// <summary>
		/// The AddressID column in the DB
		/// </summary>
		public int AddressID {
			get {
				return (int)m_intAddressID;
			}
			set {
				m_intAddressID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The AddressTypeID column in the DB
		/// </summary>
		public int AddressTypeID {
			get {
				return (int)m_intAddressTypeID;
			}
			set {
				m_intAddressTypeID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The StreetAddress column in the DB
		/// </summary>
		public string StreetAddress {
			get {
				return (string)m_strStreetAddress;
			}
			set {
				m_strStreetAddress = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PostalCode column in the DB
		/// </summary>
		public string PostalCode {
			get {
				return (string)m_strPostalCode;
			}
			set {
				m_strPostalCode = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Town column in the DB
		/// </summary>
		public string Town {
			get {
				return (string)m_strTown;
			}
			set {
				m_strTown = value;
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
		/// The isDefault column in the DB
		/// </summary>
		public bool isDefault {
			get {
				return (bool)m_bolisDefault;
			}
			set {
				m_bolisDefault = value;
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
			return Load(pk.AddressID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intAddressID"> AddressID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intAddressID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Addresses__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for AddressID column
        param = new SqlParameter("@AddressID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intAddressID;
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
		            m_intAddressID = reader.GetSqlInt32(0);
            m_intAddressTypeID = reader.GetSqlInt32(1);
            m_strStreetAddress = reader.GetSqlString(2);
            m_strPostalCode = reader.GetSqlString(3);
            m_strTown = reader.GetSqlString(4);
            m_intCityID = reader.GetSqlInt32(5);
            m_intCountryID = reader.GetSqlInt32(6);
            m_dtCreateDate = reader.GetSqlDateTime(7);
            m_bolisDefault = reader.GetSqlBoolean(8);
            m_bolisActive = reader.GetSqlBoolean(9);
		
			} else {
					//	set key values
		            m_intAddressID = intAddressID;
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
							cmd = DBHelper.getSprocCmd("proc_Addresses__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Addresses__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AddressID column
        param = new SqlParameter("@AddressID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAddressID;
        cmd.Parameters.Add(param);
        
        // parameter for AddressTypeID column
        param = new SqlParameter("@AddressTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAddressTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for StreetAddress column
        param = new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 256);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strStreetAddress;
        cmd.Parameters.Add(param);
        
        // parameter for PostalCode column
        param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 16);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPostalCode;
        cmd.Parameters.Add(param);
        
        // parameter for Town column
        param = new SqlParameter("@Town", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTown;
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
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for isDefault column
        param = new SqlParameter("@isDefault", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDefault;
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
				cmd = DBHelper.getSprocCmd("proc_Addresses__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Addresses__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for AddressID column
        param = new SqlParameter("@AddressID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAddressID;
        cmd.Parameters.Add(param);
        
        // parameter for AddressTypeID column
        param = new SqlParameter("@AddressTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAddressTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for StreetAddress column
        param = new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 256);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strStreetAddress;
        cmd.Parameters.Add(param);
        
        // parameter for PostalCode column
        param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 16);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPostalCode;
        cmd.Parameters.Add(param);
        
        // parameter for Town column
        param = new SqlParameter("@Town", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTown;
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
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for isDefault column
        param = new SqlParameter("@isDefault", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDefault;
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
				cmd = DBHelper.getSprocCmd("proc_Addresses__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Addresses__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AddressID column
        param = new SqlParameter("@AddressID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAddressID;
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
		public static bool operator ==(Addresses t1, Addresses t2) {
			//	compare values
			if(t1.m_intAddressID != t2.m_intAddressID) {
				return false;	//	because "AddressID" values are Not equal
			}
	
			if(t1.m_intAddressTypeID != t2.m_intAddressTypeID) {
				return false;	//	because "AddressTypeID" values are Not equal
			}
	
			if(t1.m_strStreetAddress != t2.m_strStreetAddress) {
				return false;	//	because "StreetAddress" values are Not equal
			}
	
			if(t1.m_strPostalCode != t2.m_strPostalCode) {
				return false;	//	because "PostalCode" values are Not equal
			}
	
			if(t1.m_strTown != t2.m_strTown) {
				return false;	//	because "Town" values are Not equal
			}
	
			if(t1.m_intCityID != t2.m_intCityID) {
				return false;	//	because "CityID" values are Not equal
			}
	
			if(t1.m_intCountryID != t2.m_intCountryID) {
				return false;	//	because "CountryID" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_bolisDefault != t2.m_bolisDefault) {
				return false;	//	because "isDefault" values are Not equal
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
		public static bool operator !=(Addresses t1, Addresses t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" AddressID = \"");
			retValue.Append(m_intAddressID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    AddressTypeID = \"");
			retValue.Append(m_intAddressTypeID);
			retValue.Append("\"\n");
				retValue.Append("    StreetAddress = \"");
			retValue.Append(m_strStreetAddress);
			retValue.Append("\"\n");
				retValue.Append("    PostalCode = \"");
			retValue.Append(m_strPostalCode);
			retValue.Append("\"\n");
				retValue.Append("    Town = \"");
			retValue.Append(m_strTown);
			retValue.Append("\"\n");
				retValue.Append("    CityID = \"");
			retValue.Append(m_intCityID);
			retValue.Append("\"\n");
				retValue.Append("    CountryID = \"");
			retValue.Append(m_intCountryID);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
			retValue.Append("\"\n");
				retValue.Append("    isDefault = \"");
			retValue.Append(m_bolisDefault);
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
			if (!(o is Addresses)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Addresses)o;
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
