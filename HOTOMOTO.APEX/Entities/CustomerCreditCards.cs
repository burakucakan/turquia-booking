using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class CustomerCreditCards {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intCustomerCreditCardID;
		private SqlInt32 m_intCustomerID;
		private SqlString m_strDescription;
		private SqlString m_strCreditCardNO;
		private SqlString m_strExpireDateMonth;
		private SqlString m_strExpireDateYear;
		private SqlString m_strCVV;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
		private SqlBoolean m_bolisActive;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public CustomerCreditCards() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all CustomerCreditCards from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the CustomerCreditCards</returns>
		public static SqlDataReader GetAllCustomerCreditCardsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllCustomerCreditCardsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all CustomerCreditCards from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllCustomerCreditCards() {
			SqlDataReader dr = GetAllCustomerCreditCardsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates CustomerCreditCards for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the CustomerCreditCards records</param>
		/// <returns>The Hashtable containing CustomerCreditCards objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            CustomerCreditCards myCustomerCreditCards = new CustomerCreditCards();
            
            myCustomerCreditCards.m_intCustomerCreditCardID = dr.GetSqlInt32(0);
            myCustomerCreditCards.m_intCustomerID = dr.GetSqlInt32(1);
            myCustomerCreditCards.m_strDescription = dr.GetSqlString(2);
            myCustomerCreditCards.m_strCreditCardNO = dr.GetSqlString(3);
            myCustomerCreditCards.m_strExpireDateMonth = dr.GetSqlString(4);
            myCustomerCreditCards.m_strExpireDateYear = dr.GetSqlString(5);
            myCustomerCreditCards.m_strCVV = dr.GetSqlString(6);
            myCustomerCreditCards.m_dtModifyDate = dr.GetSqlDateTime(7);
            myCustomerCreditCards.m_intModifiedBy = dr.GetSqlInt32(8);
            myCustomerCreditCards.m_bolisActive = dr.GetSqlBoolean(9);
            
            result.Add(myCustomerCreditCards.CustomerCreditCardID, myCustomerCreditCards);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 CustomerCreditCardID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.CustomerCreditCardID = m_intCustomerCreditCardID;
				return pk;
			}
		}
			/// <summary>
		/// The CustomerCreditCardID column in the DB
		/// </summary>
		public int CustomerCreditCardID {
			get {
				return (int)m_intCustomerCreditCardID;
			}
			set {
				m_intCustomerCreditCardID = value;
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
		/// The CreditCardNO column in the DB
		/// </summary>
		public string CreditCardNO {
			get {
				return (string)m_strCreditCardNO;
			}
			set {
				m_strCreditCardNO = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ExpireDateMonth column in the DB
		/// </summary>
		public string ExpireDateMonth {
			get {
				return (string)m_strExpireDateMonth;
			}
			set {
				m_strExpireDateMonth = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ExpireDateYear column in the DB
		/// </summary>
		public string ExpireDateYear {
			get {
				return (string)m_strExpireDateYear;
			}
			set {
				m_strExpireDateYear = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CVV column in the DB
		/// </summary>
		public string CVV {
			get {
				return (string)m_strCVV;
			}
			set {
				m_strCVV = value;
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
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.CustomerCreditCardID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intCustomerCreditCardID"> CustomerCreditCardID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intCustomerCreditCardID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for CustomerCreditCardID column
        param = new SqlParameter("@CustomerCreditCardID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intCustomerCreditCardID;
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
		            m_intCustomerCreditCardID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_strDescription = reader.GetSqlString(2);
            m_strCreditCardNO = reader.GetSqlString(3);
            m_strExpireDateMonth = reader.GetSqlString(4);
            m_strExpireDateYear = reader.GetSqlString(5);
            m_strCVV = reader.GetSqlString(6);
            m_dtModifyDate = reader.GetSqlDateTime(7);
            m_intModifiedBy = reader.GetSqlInt32(8);
            m_bolisActive = reader.GetSqlBoolean(9);
		
			} else {
					//	set key values
		            m_intCustomerCreditCardID = intCustomerCreditCardID;
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
							cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for CustomerCreditCardID column
        param = new SqlParameter("@CustomerCreditCardID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerCreditCardID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for CreditCardNO column
        param = new SqlParameter("@CreditCardNO", SqlDbType.VarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCreditCardNO;
        cmd.Parameters.Add(param);
        
        // parameter for ExpireDateMonth column
        param = new SqlParameter("@ExpireDateMonth", SqlDbType.Char, 2);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strExpireDateMonth;
        cmd.Parameters.Add(param);
        
        // parameter for ExpireDateYear column
        param = new SqlParameter("@ExpireDateYear", SqlDbType.Char, 2);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strExpireDateYear;
        cmd.Parameters.Add(param);
        
        // parameter for CVV column
        param = new SqlParameter("@CVV", SqlDbType.Char, 3);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCVV;
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
				cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for CustomerCreditCardID column
        param = new SqlParameter("@CustomerCreditCardID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerCreditCardID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for CreditCardNO column
        param = new SqlParameter("@CreditCardNO", SqlDbType.VarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCreditCardNO;
        cmd.Parameters.Add(param);
        
        // parameter for ExpireDateMonth column
        param = new SqlParameter("@ExpireDateMonth", SqlDbType.Char, 2);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strExpireDateMonth;
        cmd.Parameters.Add(param);
        
        // parameter for ExpireDateYear column
        param = new SqlParameter("@ExpireDateYear", SqlDbType.Char, 2);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strExpireDateYear;
        cmd.Parameters.Add(param);
        
        // parameter for CVV column
        param = new SqlParameter("@CVV", SqlDbType.Char, 3);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCVV;
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
				cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_CustomerCreditCards__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for CustomerCreditCardID column
        param = new SqlParameter("@CustomerCreditCardID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerCreditCardID;
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
		public static bool operator ==(CustomerCreditCards t1, CustomerCreditCards t2) {
			//	compare values
			if(t1.m_intCustomerCreditCardID != t2.m_intCustomerCreditCardID) {
				return false;	//	because "CustomerCreditCardID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			if(t1.m_strCreditCardNO != t2.m_strCreditCardNO) {
				return false;	//	because "CreditCardNO" values are Not equal
			}
	
			if(t1.m_strExpireDateMonth != t2.m_strExpireDateMonth) {
				return false;	//	because "ExpireDateMonth" values are Not equal
			}
	
			if(t1.m_strExpireDateYear != t2.m_strExpireDateYear) {
				return false;	//	because "ExpireDateYear" values are Not equal
			}
	
			if(t1.m_strCVV != t2.m_strCVV) {
				return false;	//	because "CVV" values are Not equal
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
		public static bool operator !=(CustomerCreditCards t1, CustomerCreditCards t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" CustomerCreditCardID = \"");
			retValue.Append(m_intCustomerCreditCardID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
			retValue.Append("\"\n");
				retValue.Append("    CreditCardNO = \"");
			retValue.Append(m_strCreditCardNO);
			retValue.Append("\"\n");
				retValue.Append("    ExpireDateMonth = \"");
			retValue.Append(m_strExpireDateMonth);
			retValue.Append("\"\n");
				retValue.Append("    ExpireDateYear = \"");
			retValue.Append(m_strExpireDateYear);
			retValue.Append("\"\n");
				retValue.Append("    CVV = \"");
			retValue.Append(m_strCVV);
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
			if (!(o is CustomerCreditCards)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (CustomerCreditCards)o;
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
