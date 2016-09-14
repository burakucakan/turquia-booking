using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class UserCommands {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intUserCommandID;
		private SqlString m_strCode;
		private SqlString m_strValue;
		private SqlBoolean m_bolisHidden;
		private SqlInt32 m_intParentID;
		private SqlInt32 m_intShowOrder;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
		private SqlBoolean m_bolisActive;
// members from ml table
private int m_intLanguageID;
		private Dictionary<int, SqlString> m_strTitle;
		private Dictionary<int, SqlString> m_strDescription;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public UserCommands() {
			Init();	//	init Object	
				
			m_strTitle = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();
		}
		
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public UserCommands(int LanguageID) {
			Init();	//	init Object
			
			this.m_intLanguageID = LanguageID;
							
			m_strTitle = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();
		}

		/// <summary>
		/// Gets all UserCommands from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the UserCommands</returns>
		public static SqlDataReader GetAllUserCommandsReader(int LanguageID) {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_UserCommands__sel_all", conn);

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
		
		public static DataSet GetAllUserCommandsDataSet(int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_UserCommands__sel_all", conn);


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
		/// Gets all UserCommands from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllUserCommands(int LanguageID) {
			SqlDataReader dr = GetAllUserCommandsReader(LanguageID);
			return ConvertReaderToHashTable(dr, LanguageID);
		}
		
		/// <summary>
		/// Creates UserCommands for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the UserCommands records</param>
		/// <returns>The Hashtable containing UserCommands objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr, int LanguageID) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            UserCommands myUserCommands = new UserCommands(LanguageID);
            
            myUserCommands.m_intUserCommandID = dr.GetSqlInt32(0);
            myUserCommands.m_strCode = dr.GetSqlString(1);
            myUserCommands.m_strValue = dr.GetSqlString(2);
            myUserCommands.m_bolisHidden = dr.GetSqlBoolean(3);
            myUserCommands.m_intParentID = dr.GetSqlInt32(4);
            myUserCommands.m_intShowOrder = dr.GetSqlInt32(5);
            myUserCommands.m_dtCreateDate = dr.GetSqlDateTime(6);
            myUserCommands.m_intCreatedBy = dr.GetSqlInt32(7);
            myUserCommands.m_dtModifyDate = dr.GetSqlDateTime(8);
            myUserCommands.m_intModifiedBy = dr.GetSqlInt32(9);
            myUserCommands.m_bolisActive = dr.GetSqlBoolean(10);
            
            result.Add(myUserCommands.UserCommandID, myUserCommands);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 UserCommandID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.UserCommandID = m_intUserCommandID;
				return pk;
			}
		}
			/// <summary>
		/// The UserCommandID column in the DB
		/// </summary>
		public int UserCommandID {
			get {
				return (int)m_intUserCommandID;
			}
			set {
				m_intUserCommandID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Code column in the DB
		/// </summary>
		public string Code {
			get {
				return (string)m_strCode;
			}
			set {
				m_strCode = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Value column in the DB
		/// </summary>
		public string Value {
			get {
				return (string)m_strValue;
			}
			set {
				m_strValue = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isHidden column in the DB
		/// </summary>
		public bool isHidden {
			get {
				return (bool)m_bolisHidden;
			}
			set {
				m_bolisHidden = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ParentID column in the DB
		/// </summary>
		public int ParentID {
			get {
				return (int)m_intParentID;
			}
			set {
				m_intParentID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ShowOrder column in the DB
		/// </summary>
		public int ShowOrder {
			get {
				return (int)m_intShowOrder;
			}
			set {
				m_intShowOrder = value;
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
		/// The Title column from ML table
		/// </summary>
		public string Title {
			get { 
				return this.GetTitle(this.m_intLanguageID); 
			}
			set { 
				this.SetTitle(value, this.m_intLanguageID);
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
		/// The Title column from ML table
		/// </summary>
		public string GetTitle(int LanguageID) {
			return this.m_strTitle[LanguageID].Value;
		}
		
		/// <summary>
		/// The Title column from ML table
		/// </summary>
		public void SetTitle(string Title, int LanguageID) {
			this.m_strTitle[LanguageID] = Title;
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
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.UserCommandID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intUserCommandID"> UserCommandID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intUserCommandID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_UserCommands__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for UserCommandID column
        param = new SqlParameter("@UserCommandID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intUserCommandID;
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
		            m_intUserCommandID = reader.GetSqlInt32(0);
            m_strCode = reader.GetSqlString(1);
            m_strValue = reader.GetSqlString(2);
            m_bolisHidden = reader.GetSqlBoolean(3);
            m_intParentID = reader.GetSqlInt32(4);
            m_intShowOrder = reader.GetSqlInt32(5);
            m_dtCreateDate = reader.GetSqlDateTime(6);
            m_intCreatedBy = reader.GetSqlInt32(7);
            m_dtModifyDate = reader.GetSqlDateTime(8);
            m_intModifiedBy = reader.GetSqlInt32(9);
            m_bolisActive = reader.GetSqlBoolean(10);
		
			
				cmd = DBHelper.getSprocCmd("proc_UserCommands__sel_ml_data", conn);
				
				            // parameter for UserCommandID column
            param = new SqlParameter("@UserCommandID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intUserCommandID;
            cmd.Parameters.Add(param);
            
			
				reader.Close();
				reader = null;
				
				if(conn.State == ConnectionState.Closed) conn.Open();
				
				reader = cmd.ExecuteReader();

				//check if  anything was found
				while(reader.Read()) { 			
			m_strTitle.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(2));			
			m_strDescription.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(3));				}
				
			} else {
					//	set key values
		            m_intUserCommandID = intUserCommandID;
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
							cmd = DBHelper.getSprocCmd("proc_UserCommands__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_UserCommands__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for UserCommandID column
        param = new SqlParameter("@UserCommandID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserCommandID;
        cmd.Parameters.Add(param);
        
        // parameter for Code column
        param = new SqlParameter("@Code", SqlDbType.NVarChar, 16);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCode;
        cmd.Parameters.Add(param);
        
        // parameter for Value column
        param = new SqlParameter("@Value", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strValue;
        cmd.Parameters.Add(param);
        
        // parameter for isHidden column
        param = new SqlParameter("@isHidden", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisHidden;
        cmd.Parameters.Add(param);
        
        // parameter for ParentID column
        param = new SqlParameter("@ParentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentID;
        cmd.Parameters.Add(param);
        
        // parameter for ShowOrder column
        param = new SqlParameter("@ShowOrder", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intShowOrder;
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
			
								foreach(int langID in this.m_strDescription.Keys) {
						UserCommands_ML.Insert(retValue, langID, this.m_strTitle[langID].ToString(), this.m_strDescription[langID].ToString());
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
				cmd = DBHelper.getSprocCmd("proc_UserCommands__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_UserCommands__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for UserCommandID column
        param = new SqlParameter("@UserCommandID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserCommandID;
        cmd.Parameters.Add(param);
        
        // parameter for Code column
        param = new SqlParameter("@Code", SqlDbType.NVarChar, 16);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCode;
        cmd.Parameters.Add(param);
        
        // parameter for Value column
        param = new SqlParameter("@Value", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strValue;
        cmd.Parameters.Add(param);
        
        // parameter for isHidden column
        param = new SqlParameter("@isHidden", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisHidden;
        cmd.Parameters.Add(param);
        
        // parameter for ParentID column
        param = new SqlParameter("@ParentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentID;
        cmd.Parameters.Add(param);
        
        // parameter for ShowOrder column
        param = new SqlParameter("@ShowOrder", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intShowOrder;
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
			
			
								UserCommands_ML objUserCommands_ML = new UserCommands_ML();
					foreach(int langID in this.m_strDescription.Keys) {
						objUserCommands_ML.UserCommandID = (int)this.m_intUserCommandID;
						objUserCommands_ML.LanguageID = langID;
						objUserCommands_ML.Title = this.m_strTitle[langID].ToString();
objUserCommands_ML.Description = this.m_strDescription[langID].ToString();
 objUserCommands_ML.Update();
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
				cmd = DBHelper.getSprocCmd("proc_UserCommands__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_UserCommands__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for UserCommandID column
        param = new SqlParameter("@UserCommandID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserCommandID;
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
		public static bool operator ==(UserCommands t1, UserCommands t2) {
			//	compare values
			if(t1.m_intUserCommandID != t2.m_intUserCommandID) {
				return false;	//	because "UserCommandID" values are Not equal
			}
	
			if(t1.m_strCode != t2.m_strCode) {
				return false;	//	because "Code" values are Not equal
			}
	
			if(t1.m_strValue != t2.m_strValue) {
				return false;	//	because "Value" values are Not equal
			}
	
			if(t1.m_bolisHidden != t2.m_bolisHidden) {
				return false;	//	because "isHidden" values are Not equal
			}
	
			if(t1.m_intParentID != t2.m_intParentID) {
				return false;	//	because "ParentID" values are Not equal
			}
	
			if(t1.m_intShowOrder != t2.m_intShowOrder) {
				return false;	//	because "ShowOrder" values are Not equal
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
		public static bool operator !=(UserCommands t1, UserCommands t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" UserCommandID = \"");
			retValue.Append(m_intUserCommandID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    Code = \"");
			retValue.Append(m_strCode);
			retValue.Append("\"\n");
				retValue.Append("    Value = \"");
			retValue.Append(m_strValue);
			retValue.Append("\"\n");
				retValue.Append("    isHidden = \"");
			retValue.Append(m_bolisHidden);
			retValue.Append("\"\n");
				retValue.Append("    ParentID = \"");
			retValue.Append(m_intParentID);
			retValue.Append("\"\n");
				retValue.Append("    ShowOrder = \"");
			retValue.Append(m_intShowOrder);
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
			if (!(o is UserCommands)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (UserCommands)o;
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
