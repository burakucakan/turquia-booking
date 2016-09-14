using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class UserRoles_UserPermissions {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRowID;
		private SqlInt32 m_intUserRoleID;
		private SqlInt32 m_intUserPermissionID;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public UserRoles_UserPermissions() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all UserRoles_UserPermissions from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the UserRoles_UserPermissions</returns>
		public static SqlDataReader GetAllUserRoles_UserPermissionsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllUserRoles_UserPermissionsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all UserRoles_UserPermissions from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllUserRoles_UserPermissions() {
			SqlDataReader dr = GetAllUserRoles_UserPermissionsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates UserRoles_UserPermissions for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the UserRoles_UserPermissions records</param>
		/// <returns>The Hashtable containing UserRoles_UserPermissions objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            UserRoles_UserPermissions myUserRoles_UserPermissions = new UserRoles_UserPermissions();
            
            myUserRoles_UserPermissions.m_intRowID = dr.GetSqlInt32(0);
            myUserRoles_UserPermissions.m_intUserRoleID = dr.GetSqlInt32(1);
            myUserRoles_UserPermissions.m_intUserPermissionID = dr.GetSqlInt32(2);
            
            result.Add(myUserRoles_UserPermissions.RowID, myUserRoles_UserPermissions);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 RowID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.RowID = m_intRowID;
				return pk;
			}
		}
			/// <summary>
		/// The RowID column in the DB
		/// </summary>
		public int RowID {
			get {
				return (int)m_intRowID;
			}
			set {
				m_intRowID = value;
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
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.RowID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intRowID"> RowID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intRowID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRowID;
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
		            m_intRowID = reader.GetSqlInt32(0);
            m_intUserRoleID = reader.GetSqlInt32(1);
            m_intUserPermissionID = reader.GetSqlInt32(2);
		
			} else {
					//	set key values
		            m_intRowID = intRowID;
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
							cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRowID;
        cmd.Parameters.Add(param);
        
        // parameter for UserRoleID column
        param = new SqlParameter("@UserRoleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserRoleID;
        cmd.Parameters.Add(param);
        
        // parameter for UserPermissionID column
        param = new SqlParameter("@UserPermissionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserPermissionID;
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
				cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRowID;
        cmd.Parameters.Add(param);
        
        // parameter for UserRoleID column
        param = new SqlParameter("@UserRoleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserRoleID;
        cmd.Parameters.Add(param);
        
        // parameter for UserPermissionID column
        param = new SqlParameter("@UserPermissionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserPermissionID;
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
				cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_UserRoles_UserPermissions__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RowID column
        param = new SqlParameter("@RowID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRowID;
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
		public static bool operator ==(UserRoles_UserPermissions t1, UserRoles_UserPermissions t2) {
			//	compare values
			if(t1.m_intRowID != t2.m_intRowID) {
				return false;	//	because "RowID" values are Not equal
			}
	
			if(t1.m_intUserRoleID != t2.m_intUserRoleID) {
				return false;	//	because "UserRoleID" values are Not equal
			}
	
			if(t1.m_intUserPermissionID != t2.m_intUserPermissionID) {
				return false;	//	because "UserPermissionID" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(UserRoles_UserPermissions t1, UserRoles_UserPermissions t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" RowID = \"");
			retValue.Append(m_intRowID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    UserRoleID = \"");
			retValue.Append(m_intUserRoleID);
			retValue.Append("\"\n");
				retValue.Append("    UserPermissionID = \"");
			retValue.Append(m_intUserPermissionID);
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
			if (!(o is UserRoles_UserPermissions)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (UserRoles_UserPermissions)o;
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
