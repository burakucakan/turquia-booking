using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Users {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intUserID;
		private SqlInt32 m_intCustomerID;
		private SqlString m_strFirstName;
		private SqlString m_strLastName;
		private SqlString m_strEmailAddress;
		private SqlBoolean m_bolisEmailConfirmed;
		private SqlString m_strUserName;
		private SqlString m_strPassword;
		private SqlInt32 m_intUserPermissionID;
		private SqlInt32 m_intUserRoleID;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
		private SqlBoolean m_bolisActive;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Users() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Users from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Users</returns>
		public static SqlDataReader GetAllUsersReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Users__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllUsersDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Users__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Users from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllUsers() {
			SqlDataReader dr = GetAllUsersReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Users for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Users records</param>
		/// <returns>The Hashtable containing Users objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Users myUsers = new Users();
            
            myUsers.m_intUserID = dr.GetSqlInt32(0);
            myUsers.m_intCustomerID = dr.GetSqlInt32(1);
            myUsers.m_strFirstName = dr.GetSqlString(2);
            myUsers.m_strLastName = dr.GetSqlString(3);
            myUsers.m_strEmailAddress = dr.GetSqlString(4);
            myUsers.m_bolisEmailConfirmed = dr.GetSqlBoolean(5);
            myUsers.m_strUserName = dr.GetSqlString(6);
            myUsers.m_strPassword = dr.GetSqlString(7);
            myUsers.m_intUserPermissionID = dr.GetSqlInt32(8);
            myUsers.m_intUserRoleID = dr.GetSqlInt32(9);
            myUsers.m_dtCreateDate = dr.GetSqlDateTime(10);
            myUsers.m_intCreatedBy = dr.GetSqlInt32(11);
            myUsers.m_dtModifyDate = dr.GetSqlDateTime(12);
            myUsers.m_intModifiedBy = dr.GetSqlInt32(13);
            myUsers.m_bolisActive = dr.GetSqlBoolean(14);
            
            result.Add(myUsers.UserID, myUsers);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 UserID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.UserID = m_intUserID;
				return pk;
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
		/// The FirstName column in the DB
		/// </summary>
		public string FirstName {
			get {
				return (string)m_strFirstName;
			}
			set {
				m_strFirstName = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The LastName column in the DB
		/// </summary>
		public string LastName {
			get {
				return (string)m_strLastName;
			}
			set {
				m_strLastName = value;
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
		/// The isEmailConfirmed column in the DB
		/// </summary>
		public bool isEmailConfirmed {
			get {
				return (bool)m_bolisEmailConfirmed;
			}
			set {
				m_bolisEmailConfirmed = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The UserName column in the DB
		/// </summary>
		public string UserName {
			get {
				return (string)m_strUserName;
			}
			set {
				m_strUserName = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Password column in the DB
		/// </summary>
		public string Password {
			get {
				return (string)m_strPassword;
			}
			set {
				m_strPassword = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The UserPermissionID column in the DB
		/// </summary>
		public int UserPermissionID {
			get {
				return (int)m_intUserPermissionID;
			}
			set {
				m_intUserPermissionID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The UserRoleID column in the DB
		/// </summary>
		public int UserRoleID {
			get {
				return (int)m_intUserRoleID;
			}
			set {
				m_intUserRoleID = value;
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
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.UserID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intUserID"> UserID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intUserID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Users__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intUserID;
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
		            m_intUserID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_strFirstName = reader.GetSqlString(2);
            m_strLastName = reader.GetSqlString(3);
            m_strEmailAddress = reader.GetSqlString(4);
            m_bolisEmailConfirmed = reader.GetSqlBoolean(5);
            m_strUserName = reader.GetSqlString(6);
            m_strPassword = reader.GetSqlString(7);
            m_intUserPermissionID = reader.GetSqlInt32(8);
            m_intUserRoleID = reader.GetSqlInt32(9);
            m_dtCreateDate = reader.GetSqlDateTime(10);
            m_intCreatedBy = reader.GetSqlInt32(11);
            m_dtModifyDate = reader.GetSqlDateTime(12);
            m_intModifiedBy = reader.GetSqlInt32(13);
            m_bolisActive = reader.GetSqlBoolean(14);
		
			} else {
					//	set key values
		            m_intUserID = intUserID;
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
							cmd = DBHelper.getSprocCmd("proc_Users__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Users__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for FirstName column
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFirstName;
        cmd.Parameters.Add(param);
        
        // parameter for LastName column
        param = new SqlParameter("@LastName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLastName;
        cmd.Parameters.Add(param);
        
        // parameter for EmailAddress column
        param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEmailAddress;
        cmd.Parameters.Add(param);
        
        // parameter for isEmailConfirmed column
        param = new SqlParameter("@isEmailConfirmed", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisEmailConfirmed;
        cmd.Parameters.Add(param);
        
        // parameter for UserName column
        param = new SqlParameter("@UserName", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strUserName;
        cmd.Parameters.Add(param);
        
        // parameter for Password column
        param = new SqlParameter("@Password", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPassword;
        cmd.Parameters.Add(param);
        
        // parameter for UserPermissionID column
        param = new SqlParameter("@UserPermissionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserPermissionID;
        cmd.Parameters.Add(param);
        
        // parameter for UserRoleID column
        param = new SqlParameter("@UserRoleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserRoleID;
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
				cmd = DBHelper.getSprocCmd("proc_Users__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Users__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for FirstName column
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFirstName;
        cmd.Parameters.Add(param);
        
        // parameter for LastName column
        param = new SqlParameter("@LastName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLastName;
        cmd.Parameters.Add(param);
        
        // parameter for EmailAddress column
        param = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEmailAddress;
        cmd.Parameters.Add(param);
        
        // parameter for isEmailConfirmed column
        param = new SqlParameter("@isEmailConfirmed", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisEmailConfirmed;
        cmd.Parameters.Add(param);
        
        // parameter for UserName column
        param = new SqlParameter("@UserName", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strUserName;
        cmd.Parameters.Add(param);
        
        // parameter for Password column
        param = new SqlParameter("@Password", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPassword;
        cmd.Parameters.Add(param);
        
        // parameter for UserPermissionID column
        param = new SqlParameter("@UserPermissionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserPermissionID;
        cmd.Parameters.Add(param);
        
        // parameter for UserRoleID column
        param = new SqlParameter("@UserRoleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserRoleID;
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
				cmd = DBHelper.getSprocCmd("proc_Users__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Users__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
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
		public static bool operator ==(Users t1, Users t2) {
			//	compare values
			if(t1.m_intUserID != t2.m_intUserID) {
				return false;	//	because "UserID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_strFirstName != t2.m_strFirstName) {
				return false;	//	because "FirstName" values are Not equal
			}
	
			if(t1.m_strLastName != t2.m_strLastName) {
				return false;	//	because "LastName" values are Not equal
			}
	
			if(t1.m_strEmailAddress != t2.m_strEmailAddress) {
				return false;	//	because "EmailAddress" values are Not equal
			}
	
			if(t1.m_bolisEmailConfirmed != t2.m_bolisEmailConfirmed) {
				return false;	//	because "isEmailConfirmed" values are Not equal
			}
	
			if(t1.m_strUserName != t2.m_strUserName) {
				return false;	//	because "UserName" values are Not equal
			}
	
			if(t1.m_strPassword != t2.m_strPassword) {
				return false;	//	because "Password" values are Not equal
			}
	
			if(t1.m_intUserPermissionID != t2.m_intUserPermissionID) {
				return false;	//	because "UserPermissionID" values are Not equal
			}
	
			if(t1.m_intUserRoleID != t2.m_intUserRoleID) {
				return false;	//	because "UserRoleID" values are Not equal
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
		public static bool operator !=(Users t1, Users t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" UserID = \"");
			retValue.Append(m_intUserID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    FirstName = \"");
			retValue.Append(m_strFirstName);
			retValue.Append("\"\n");
				retValue.Append("    LastName = \"");
			retValue.Append(m_strLastName);
			retValue.Append("\"\n");
				retValue.Append("    EmailAddress = \"");
			retValue.Append(m_strEmailAddress);
			retValue.Append("\"\n");
				retValue.Append("    isEmailConfirmed = \"");
			retValue.Append(m_bolisEmailConfirmed);
			retValue.Append("\"\n");
				retValue.Append("    UserName = \"");
			retValue.Append(m_strUserName);
			retValue.Append("\"\n");
				retValue.Append("    Password = \"");
			retValue.Append(m_strPassword);
			retValue.Append("\"\n");
				retValue.Append("    UserPermissionID = \"");
			retValue.Append(m_intUserPermissionID);
			retValue.Append("\"\n");
				retValue.Append("    UserRoleID = \"");
			retValue.Append(m_intUserRoleID);
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
			if (!(o is Users)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Users)o;
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
