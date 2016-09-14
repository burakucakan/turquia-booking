using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class AccessTypes {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intAccessTypeID;
		private SqlInt32 m_intAccessMainTypeID;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
		private SqlBoolean m_bolisActive;
// members from ml table
private int m_intLanguageID;
		private Dictionary<int, SqlString> m_strType;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public AccessTypes() {
			Init();	//	init Object	
				
			m_strType = new Dictionary<int, SqlString>();
		}
		
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public AccessTypes(int LanguageID) {
			Init();	//	init Object
			
			this.m_intLanguageID = LanguageID;
							
			m_strType = new Dictionary<int, SqlString>();
		}

		/// <summary>
		/// Gets all AccessTypes from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the AccessTypes</returns>
		public static SqlDataReader GetAllAccessTypesReader(int LanguageID) {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_AccessTypes__sel_all", conn);

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
		
		public static DataSet GetAllAccessTypesDataSet(int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_AccessTypes__sel_all", conn);


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
		/// Gets all AccessTypes from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllAccessTypes(int LanguageID) {
			SqlDataReader dr = GetAllAccessTypesReader(LanguageID);
			return ConvertReaderToHashTable(dr, LanguageID);
		}
		
		/// <summary>
		/// Creates AccessTypes for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the AccessTypes records</param>
		/// <returns>The Hashtable containing AccessTypes objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr, int LanguageID) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            AccessTypes myAccessTypes = new AccessTypes(LanguageID);
            
            myAccessTypes.m_intAccessTypeID = dr.GetSqlInt32(0);
            myAccessTypes.m_intAccessMainTypeID = dr.GetSqlInt32(1);
            myAccessTypes.m_dtCreateDate = dr.GetSqlDateTime(2);
            myAccessTypes.m_intCreatedBy = dr.GetSqlInt32(3);
            myAccessTypes.m_dtModifyDate = dr.GetSqlDateTime(4);
            myAccessTypes.m_intModifiedBy = dr.GetSqlInt32(5);
            myAccessTypes.m_bolisActive = dr.GetSqlBoolean(6);
            
            result.Add(myAccessTypes.AccessTypeID, myAccessTypes);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 AccessTypeID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.AccessTypeID = m_intAccessTypeID;
				return pk;
			}
		}
			/// <summary>
		/// The AccessTypeID column in the DB
		/// </summary>
		public int AccessTypeID {
			get {
				return (int)m_intAccessTypeID;
			}
			set {
				m_intAccessTypeID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The AccessMainTypeID column in the DB
		/// </summary>
		public int AccessMainTypeID {
			get {
				return (int)m_intAccessMainTypeID;
			}
			set {
				m_intAccessMainTypeID = value;
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
		/// The Type column from ML table
		/// </summary>
		public string Type {
			get { 
				return this.GetType(this.m_intLanguageID); 
			}
			set { 
				this.SetType(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Type column from ML table
		/// </summary>
		public string GetType(int LanguageID) {
			return this.m_strType[LanguageID].Value;
		}
		
		/// <summary>
		/// The Type column from ML table
		/// </summary>
		public void SetType(string Type, int LanguageID) {
			this.m_strType[LanguageID] = Type;
		}
		
					/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.AccessTypeID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intAccessTypeID"> AccessTypeID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intAccessTypeID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_AccessTypes__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for AccessTypeID column
        param = new SqlParameter("@AccessTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intAccessTypeID;
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
		            m_intAccessTypeID = reader.GetSqlInt32(0);
            m_intAccessMainTypeID = reader.GetSqlInt32(1);
            m_dtCreateDate = reader.GetSqlDateTime(2);
            m_intCreatedBy = reader.GetSqlInt32(3);
            m_dtModifyDate = reader.GetSqlDateTime(4);
            m_intModifiedBy = reader.GetSqlInt32(5);
            m_bolisActive = reader.GetSqlBoolean(6);
		
			
				cmd = DBHelper.getSprocCmd("proc_AccessTypes__sel_ml_data", conn);
				
				            // parameter for AccessTypeID column
            param = new SqlParameter("@AccessTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intAccessTypeID;
            cmd.Parameters.Add(param);
            
			
				reader.Close();
				reader = null;
				
				if(conn.State == ConnectionState.Closed) conn.Open();
				
				reader = cmd.ExecuteReader();

				//check if  anything was found
				while(reader.Read()) { 			
			m_strType.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(2));				}
				
			} else {
					//	set key values
		            m_intAccessTypeID = intAccessTypeID;
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
							cmd = DBHelper.getSprocCmd("proc_AccessTypes__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_AccessTypes__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AccessTypeID column
        param = new SqlParameter("@AccessTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for AccessMainTypeID column
        param = new SqlParameter("@AccessMainTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessMainTypeID;
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
			
								foreach(int langID in this.m_strType.Keys) {
						AccessTypes_ML.Insert(retValue, langID, this.m_strType[langID].ToString());
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
				cmd = DBHelper.getSprocCmd("proc_AccessTypes__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_AccessTypes__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for AccessTypeID column
        param = new SqlParameter("@AccessTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for AccessMainTypeID column
        param = new SqlParameter("@AccessMainTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessMainTypeID;
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
			
			
								AccessTypes_ML objAccessTypes_ML = new AccessTypes_ML();
					foreach(int langID in this.m_strType.Keys) {
						objAccessTypes_ML.AccessTypeID = (int)this.m_intAccessTypeID;
						objAccessTypes_ML.LanguageID = langID;
						objAccessTypes_ML.Type = this.m_strType[langID].ToString();
 objAccessTypes_ML.Update();
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
				cmd = DBHelper.getSprocCmd("proc_AccessTypes__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_AccessTypes__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AccessTypeID column
        param = new SqlParameter("@AccessTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessTypeID;
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
		public static bool operator ==(AccessTypes t1, AccessTypes t2) {
			//	compare values
			if(t1.m_intAccessTypeID != t2.m_intAccessTypeID) {
				return false;	//	because "AccessTypeID" values are Not equal
			}
	
			if(t1.m_intAccessMainTypeID != t2.m_intAccessMainTypeID) {
				return false;	//	because "AccessMainTypeID" values are Not equal
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
		public static bool operator !=(AccessTypes t1, AccessTypes t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" AccessTypeID = \"");
			retValue.Append(m_intAccessTypeID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    AccessMainTypeID = \"");
			retValue.Append(m_intAccessMainTypeID);
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
			if (!(o is AccessTypes)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (AccessTypes)o;
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
