using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Errors {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intErrorID;
		private SqlInt32 m_intErrorTypeID;
// members from ml table
private int m_intLanguageID;
		private Dictionary<int, SqlString> m_strErrorTitle;
		private Dictionary<int, SqlString> m_strMessage;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Errors() {
			Init();	//	init Object	
				
			m_strErrorTitle = new Dictionary<int, SqlString>();				
			m_strMessage = new Dictionary<int, SqlString>();
		}
		
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Errors(int LanguageID) {
			Init();	//	init Object
			
			this.m_intLanguageID = LanguageID;
							
			m_strErrorTitle = new Dictionary<int, SqlString>();				
			m_strMessage = new Dictionary<int, SqlString>();
		}

		/// <summary>
		/// Gets all Errors from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Errors</returns>
		public static SqlDataReader GetAllErrorsReader(int LanguageID) {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Errors__sel_all", conn);

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
		
		public static DataSet GetAllErrorsDataSet(int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Errors__sel_all", conn);


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
		/// Gets all Errors from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllErrors(int LanguageID) {
			SqlDataReader dr = GetAllErrorsReader(LanguageID);
			return ConvertReaderToHashTable(dr, LanguageID);
		}
		
		/// <summary>
		/// Creates Errors for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Errors records</param>
		/// <returns>The Hashtable containing Errors objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr, int LanguageID) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Errors myErrors = new Errors(LanguageID);
            
            myErrors.m_intErrorID = dr.GetSqlInt32(0);
            myErrors.m_intErrorTypeID = dr.GetSqlInt32(1);
            
            result.Add(myErrors.ErrorID, myErrors);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 ErrorID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.ErrorID = m_intErrorID;
				return pk;
			}
		}
			/// <summary>
		/// The ErrorID column in the DB
		/// </summary>
		public int ErrorID {
			get {
				return (int)m_intErrorID;
			}
			set {
				m_intErrorID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ErrorTypeID column in the DB
		/// </summary>
		public int ErrorTypeID {
			get {
				return (int)m_intErrorTypeID;
			}
			set {
				m_intErrorTypeID = value;
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
		/// The ErrorTitle column from ML table
		/// </summary>
		public string ErrorTitle {
			get { 
				return this.GetErrorTitle(this.m_intLanguageID); 
			}
			set { 
				this.SetErrorTitle(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Message column from ML table
		/// </summary>
		public string Message {
			get { 
				return this.GetMessage(this.m_intLanguageID); 
			}
			set { 
				this.SetMessage(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The ErrorTitle column from ML table
		/// </summary>
		public string GetErrorTitle(int LanguageID) {
			return this.m_strErrorTitle[LanguageID].Value;
		}
		
		/// <summary>
		/// The ErrorTitle column from ML table
		/// </summary>
		public void SetErrorTitle(string ErrorTitle, int LanguageID) {
			this.m_strErrorTitle[LanguageID] = ErrorTitle;
		}
		
								
		/// <summary>
		/// The Message column from ML table
		/// </summary>
		public string GetMessage(int LanguageID) {
			return this.m_strMessage[LanguageID].Value;
		}
		
		/// <summary>
		/// The Message column from ML table
		/// </summary>
		public void SetMessage(string Message, int LanguageID) {
			this.m_strMessage[LanguageID] = Message;
		}
		
					/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.ErrorID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intErrorID"> ErrorID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intErrorID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Errors__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for ErrorID column
        param = new SqlParameter("@ErrorID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intErrorID;
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
		            m_intErrorID = reader.GetSqlInt32(0);
            m_intErrorTypeID = reader.GetSqlInt32(1);
		
			
				cmd = DBHelper.getSprocCmd("proc_Errors__sel_ml_data", conn);
				
				            // parameter for ErrorID column
            param = new SqlParameter("@ErrorID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intErrorID;
            cmd.Parameters.Add(param);
            
			
				reader.Close();
				reader = null;
				
				if(conn.State == ConnectionState.Closed) conn.Open();
				
				reader = cmd.ExecuteReader();

				//check if  anything was found
				while(reader.Read()) { 			
			m_strErrorTitle.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(2));			
			m_strMessage.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(3));				}
				
			} else {
					//	set key values
		            m_intErrorID = intErrorID;
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
							cmd = DBHelper.getSprocCmd("proc_Errors__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Errors__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ErrorID column
        param = new SqlParameter("@ErrorID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intErrorID;
        cmd.Parameters.Add(param);
        
        // parameter for ErrorTypeID column
        param = new SqlParameter("@ErrorTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intErrorTypeID;
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
			
								foreach(int langID in this.m_strMessage.Keys) {
						Errors_ML.Insert(retValue, langID, this.m_strErrorTitle[langID].ToString(), this.m_strMessage[langID].ToString());
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
				cmd = DBHelper.getSprocCmd("proc_Errors__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Errors__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for ErrorID column
        param = new SqlParameter("@ErrorID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intErrorID;
        cmd.Parameters.Add(param);
        
        // parameter for ErrorTypeID column
        param = new SqlParameter("@ErrorTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intErrorTypeID;
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
			
			
								Errors_ML objErrors_ML = new Errors_ML();
					foreach(int langID in this.m_strMessage.Keys) {
						objErrors_ML.ErrorID = (int)this.m_intErrorID;
						objErrors_ML.LanguageID = langID;
						objErrors_ML.ErrorTitle = this.m_strErrorTitle[langID].ToString();
objErrors_ML.Message = this.m_strMessage[langID].ToString();
 objErrors_ML.Update();
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
				cmd = DBHelper.getSprocCmd("proc_Errors__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Errors__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ErrorID column
        param = new SqlParameter("@ErrorID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intErrorID;
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
		public static bool operator ==(Errors t1, Errors t2) {
			//	compare values
			if(t1.m_intErrorID != t2.m_intErrorID) {
				return false;	//	because "ErrorID" values are Not equal
			}
	
			if(t1.m_intErrorTypeID != t2.m_intErrorTypeID) {
				return false;	//	because "ErrorTypeID" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Errors t1, Errors t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" ErrorID = \"");
			retValue.Append(m_intErrorID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    ErrorTypeID = \"");
			retValue.Append(m_intErrorTypeID);
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
			if (!(o is Errors)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Errors)o;
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
