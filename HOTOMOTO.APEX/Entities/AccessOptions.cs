using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class AccessOptions {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intAccessOptionID;
		private SqlInt32 m_intAccessTypeID;
		private SqlInt32 m_intShowOrder;
		private SqlString m_strAccessValue;
		private SqlDateTime m_dtCreateDate;
		private SqlBoolean m_bolisDefault;
		private SqlBoolean m_bolisActive;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public AccessOptions() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all AccessOptions from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the AccessOptions</returns>
		public static SqlDataReader GetAllAccessOptionsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_AccessOptions__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllAccessOptionsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_AccessOptions__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all AccessOptions from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllAccessOptions() {
			SqlDataReader dr = GetAllAccessOptionsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates AccessOptions for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the AccessOptions records</param>
		/// <returns>The Hashtable containing AccessOptions objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            AccessOptions myAccessOptions = new AccessOptions();
            
            myAccessOptions.m_intAccessOptionID = dr.GetSqlInt32(0);
            myAccessOptions.m_intAccessTypeID = dr.GetSqlInt32(1);
            myAccessOptions.m_intShowOrder = dr.GetSqlInt32(2);
            myAccessOptions.m_strAccessValue = dr.GetSqlString(3);
            myAccessOptions.m_dtCreateDate = dr.GetSqlDateTime(4);
            myAccessOptions.m_bolisDefault = dr.GetSqlBoolean(5);
            myAccessOptions.m_bolisActive = dr.GetSqlBoolean(6);
            
            result.Add(myAccessOptions.AccessOptionID, myAccessOptions);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 AccessOptionID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.AccessOptionID = m_intAccessOptionID;
				return pk;
			}
		}
			/// <summary>
		/// The AccessOptionID column in the DB
		/// </summary>
		public int AccessOptionID {
			get {
				return (int)m_intAccessOptionID;
			}
			set {
				m_intAccessOptionID = value;
				m_bIsDirty = true;
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
		/// The AccessValue column in the DB
		/// </summary>
		public string AccessValue {
			get {
				return (string)m_strAccessValue;
			}
			set {
				m_strAccessValue = value;
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
			return Load(pk.AccessOptionID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intAccessOptionID"> AccessOptionID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intAccessOptionID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_AccessOptions__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for AccessOptionID column
        param = new SqlParameter("@AccessOptionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intAccessOptionID;
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
		            m_intAccessOptionID = reader.GetSqlInt32(0);
            m_intAccessTypeID = reader.GetSqlInt32(1);
            m_intShowOrder = reader.GetSqlInt32(2);
            m_strAccessValue = reader.GetSqlString(3);
            m_dtCreateDate = reader.GetSqlDateTime(4);
            m_bolisDefault = reader.GetSqlBoolean(5);
            m_bolisActive = reader.GetSqlBoolean(6);
		
			} else {
					//	set key values
		            m_intAccessOptionID = intAccessOptionID;
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
							cmd = DBHelper.getSprocCmd("proc_AccessOptions__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_AccessOptions__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AccessOptionID column
        param = new SqlParameter("@AccessOptionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessOptionID;
        cmd.Parameters.Add(param);
        
        // parameter for AccessTypeID column
        param = new SqlParameter("@AccessTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for ShowOrder column
        param = new SqlParameter("@ShowOrder", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intShowOrder;
        cmd.Parameters.Add(param);
        
        // parameter for AccessValue column
        param = new SqlParameter("@AccessValue", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strAccessValue;
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
				cmd = DBHelper.getSprocCmd("proc_AccessOptions__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_AccessOptions__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for AccessOptionID column
        param = new SqlParameter("@AccessOptionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessOptionID;
        cmd.Parameters.Add(param);
        
        // parameter for AccessTypeID column
        param = new SqlParameter("@AccessTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for ShowOrder column
        param = new SqlParameter("@ShowOrder", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intShowOrder;
        cmd.Parameters.Add(param);
        
        // parameter for AccessValue column
        param = new SqlParameter("@AccessValue", SqlDbType.NVarChar, 64);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strAccessValue;
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
				cmd = DBHelper.getSprocCmd("proc_AccessOptions__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_AccessOptions__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for AccessOptionID column
        param = new SqlParameter("@AccessOptionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intAccessOptionID;
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
		public static bool operator ==(AccessOptions t1, AccessOptions t2) {
			//	compare values
			if(t1.m_intAccessOptionID != t2.m_intAccessOptionID) {
				return false;	//	because "AccessOptionID" values are Not equal
			}
	
			if(t1.m_intAccessTypeID != t2.m_intAccessTypeID) {
				return false;	//	because "AccessTypeID" values are Not equal
			}
	
			if(t1.m_intShowOrder != t2.m_intShowOrder) {
				return false;	//	because "ShowOrder" values are Not equal
			}
	
			if(t1.m_strAccessValue != t2.m_strAccessValue) {
				return false;	//	because "AccessValue" values are Not equal
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
		public static bool operator !=(AccessOptions t1, AccessOptions t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" AccessOptionID = \"");
			retValue.Append(m_intAccessOptionID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    AccessTypeID = \"");
			retValue.Append(m_intAccessTypeID);
			retValue.Append("\"\n");
				retValue.Append("    ShowOrder = \"");
			retValue.Append(m_intShowOrder);
			retValue.Append("\"\n");
				retValue.Append("    AccessValue = \"");
			retValue.Append(m_strAccessValue);
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
			if (!(o is AccessOptions)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (AccessOptions)o;
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
