using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Customers {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intCustomerID;
		private SqlString m_strCustomerCode;
		private SqlString m_strCompanyName;
		private SqlString m_strCustomerName;
		private SqlInt32 m_intCustomerTypeID;
		private SqlInt32 m_intCurrencyID;
		private SqlString m_strEmailAddress;
		private SqlString m_strWebsite;
		private SqlBoolean m_bolisActive;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Customers() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Customers from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Customers</returns>
		public static SqlDataReader GetAllCustomersReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Customers__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllCustomersDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Customers__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Customers from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllCustomers() {
			SqlDataReader dr = GetAllCustomersReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Customers for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Customers records</param>
		/// <returns>The Hashtable containing Customers objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Customers myCustomers = new Customers();
            
            myCustomers.m_intCustomerID = dr.GetSqlInt32(0);
            myCustomers.m_strCustomerCode = dr.GetSqlString(1);
            myCustomers.m_strCompanyName = dr.GetSqlString(2);
            myCustomers.m_strCustomerName = dr.GetSqlString(3);
            myCustomers.m_intCustomerTypeID = dr.GetSqlInt32(4);
            myCustomers.m_intCurrencyID = dr.GetSqlInt32(5);
            myCustomers.m_strEmailAddress = dr.GetSqlString(6);
            myCustomers.m_strWebsite = dr.GetSqlString(7);
            myCustomers.m_bolisActive = dr.GetSqlBoolean(8);
            myCustomers.m_dtCreateDate = dr.GetSqlDateTime(9);
            myCustomers.m_intCreatedBy = dr.GetSqlInt32(10);
            
            result.Add(myCustomers.CustomerID, myCustomers);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 CustomerID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.CustomerID = m_intCustomerID;
				return pk;
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
		/// The CustomerCode column in the DB
		/// </summary>
		public string CustomerCode {
			get {
				return (string)m_strCustomerCode;
			}
			set {
				m_strCustomerCode = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CompanyName column in the DB
		/// </summary>
		public string CompanyName {
			get {
				return (string)m_strCompanyName;
			}
			set {
				m_strCompanyName = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CustomerName column in the DB
		/// </summary>
		public string CustomerName {
			get {
				return (string)m_strCustomerName;
			}
			set {
				m_strCustomerName = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CustomerTypeID column in the DB
		/// </summary>
		public int CustomerTypeID {
			get {
				return (int)m_intCustomerTypeID;
			}
			set {
				m_intCustomerTypeID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CurrencyID column in the DB
		/// </summary>
		public int CurrencyID {
			get {
				return (int)m_intCurrencyID;
			}
			set {
				m_intCurrencyID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The EmailAddress column in the DB
		/// </summary>
		public string EmailAddress {
			get {
				return (string)m_strEmailAddress;
			}
			set {
				m_strEmailAddress = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Website column in the DB
		/// </summary>
		public string Website {
			get {
				return (string)m_strWebsite;
			}
			set {
				m_strWebsite = value;
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
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.CustomerID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intCustomerID"> CustomerID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intCustomerID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Customers__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intCustomerID;
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
		            m_intCustomerID = reader.GetSqlInt32(0);
            m_strCustomerCode = reader.GetSqlString(1);
            m_strCompanyName = reader.GetSqlString(2);
            m_strCustomerName = reader.GetSqlString(3);
            m_intCustomerTypeID = reader.GetSqlInt32(4);
            m_intCurrencyID = reader.GetSqlInt32(5);
            m_strEmailAddress = reader.GetSqlString(6);
            m_strWebsite = reader.GetSqlString(7);
            m_bolisActive = reader.GetSqlBoolean(8);
            m_dtCreateDate = reader.GetSqlDateTime(9);
            m_intCreatedBy = reader.GetSqlInt32(10);
		
			} else {
					//	set key values
		            m_intCustomerID = intCustomerID;
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
							cmd = DBHelper.getSprocCmd("proc_Customers__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Customers__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerCode column
        param = new SqlParameter("@CustomerCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCustomerCode;
        cmd.Parameters.Add(param);
        
        // parameter for CompanyName column
        param = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCompanyName;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerName column
        param = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCustomerName;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerTypeID column
        param = new SqlParameter("@CustomerTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for CurrencyID column
        param = new SqlParameter("@CurrencyID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCurrencyID;
        cmd.Parameters.Add(param);
        
        // parameter for EmailAddress column
        param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEmailAddress;
        cmd.Parameters.Add(param);
        
        // parameter for Website column
        param = new SqlParameter("@Website", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strWebsite;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
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
				cmd = DBHelper.getSprocCmd("proc_Customers__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Customers__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerCode column
        param = new SqlParameter("@CustomerCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCustomerCode;
        cmd.Parameters.Add(param);
        
        // parameter for CompanyName column
        param = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCompanyName;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerName column
        param = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCustomerName;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerTypeID column
        param = new SqlParameter("@CustomerTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for CurrencyID column
        param = new SqlParameter("@CurrencyID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCurrencyID;
        cmd.Parameters.Add(param);
        
        // parameter for EmailAddress column
        param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEmailAddress;
        cmd.Parameters.Add(param);
        
        // parameter for Website column
        param = new SqlParameter("@Website", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strWebsite;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
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
				cmd = DBHelper.getSprocCmd("proc_Customers__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Customers__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
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
		public static bool operator ==(Customers t1, Customers t2) {
			//	compare values
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_strCustomerCode != t2.m_strCustomerCode) {
				return false;	//	because "CustomerCode" values are Not equal
			}
	
			if(t1.m_strCompanyName != t2.m_strCompanyName) {
				return false;	//	because "CompanyName" values are Not equal
			}
	
			if(t1.m_strCustomerName != t2.m_strCustomerName) {
				return false;	//	because "CustomerName" values are Not equal
			}
	
			if(t1.m_intCustomerTypeID != t2.m_intCustomerTypeID) {
				return false;	//	because "CustomerTypeID" values are Not equal
			}
	
			if(t1.m_intCurrencyID != t2.m_intCurrencyID) {
				return false;	//	because "CurrencyID" values are Not equal
			}
	
			if(t1.m_strEmailAddress != t2.m_strEmailAddress) {
				return false;	//	because "EmailAddress" values are Not equal
			}
	
			if(t1.m_strWebsite != t2.m_strWebsite) {
				return false;	//	because "Website" values are Not equal
			}
	
			if(t1.m_bolisActive != t2.m_bolisActive) {
				return false;	//	because "isActive" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_intCreatedBy != t2.m_intCreatedBy) {
				return false;	//	because "CreatedBy" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Customers t1, Customers t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerCode = \"");
			retValue.Append(m_strCustomerCode);
			retValue.Append("\"\n");
				retValue.Append("    CompanyName = \"");
			retValue.Append(m_strCompanyName);
			retValue.Append("\"\n");
				retValue.Append("    CustomerName = \"");
			retValue.Append(m_strCustomerName);
			retValue.Append("\"\n");
				retValue.Append("    CustomerTypeID = \"");
			retValue.Append(m_intCustomerTypeID);
			retValue.Append("\"\n");
				retValue.Append("    CurrencyID = \"");
			retValue.Append(m_intCurrencyID);
			retValue.Append("\"\n");
				retValue.Append("    EmailAddress = \"");
			retValue.Append(m_strEmailAddress);
			retValue.Append("\"\n");
				retValue.Append("    Website = \"");
			retValue.Append(m_strWebsite);
			retValue.Append("\"\n");
				retValue.Append("    isActive = \"");
			retValue.Append(m_bolisActive);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
			retValue.Append("\"\n");
				retValue.Append("    CreatedBy = \"");
			retValue.Append(m_intCreatedBy);
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
			if (!(o is Customers)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Customers)o;
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
