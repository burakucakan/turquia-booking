using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class WebPosTransactions {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intWebPosTransactionID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intUserID;
		private SqlInt32 m_intReservationID;
		private SqlString m_strReservationCode;
		private SqlDouble m_dblAmount;
		private SqlString m_strOrderCode;
		private SqlInt32 m_intStatus;
		private SqlString m_strReturnValue;
		private SqlString m_strReturnValueDescription;
		private SqlDateTime m_dtTransactionDate;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public WebPosTransactions() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all WebPosTransactions from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the WebPosTransactions</returns>
		public static SqlDataReader GetAllWebPosTransactionsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllWebPosTransactionsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all WebPosTransactions from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllWebPosTransactions() {
			SqlDataReader dr = GetAllWebPosTransactionsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates WebPosTransactions for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the WebPosTransactions records</param>
		/// <returns>The Hashtable containing WebPosTransactions objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            WebPosTransactions myWebPosTransactions = new WebPosTransactions();
            
            myWebPosTransactions.m_intWebPosTransactionID = dr.GetSqlInt32(0);
            myWebPosTransactions.m_intCustomerID = dr.GetSqlInt32(1);
            myWebPosTransactions.m_intUserID = dr.GetSqlInt32(2);
            myWebPosTransactions.m_intReservationID = dr.GetSqlInt32(3);
            myWebPosTransactions.m_strReservationCode = dr.GetSqlString(4);
            myWebPosTransactions.m_dblAmount = dr.GetSqlDouble(5);
            myWebPosTransactions.m_strOrderCode = dr.GetSqlString(6);
            myWebPosTransactions.m_intStatus = dr.GetSqlInt32(7);
            myWebPosTransactions.m_strReturnValue = dr.GetSqlString(8);
            myWebPosTransactions.m_strReturnValueDescription = dr.GetSqlString(9);
            myWebPosTransactions.m_dtTransactionDate = dr.GetSqlDateTime(10);
            
            result.Add(myWebPosTransactions.WebPosTransactionID, myWebPosTransactions);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 WebPosTransactionID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.WebPosTransactionID = m_intWebPosTransactionID;
				return pk;
			}
		}
			/// <summary>
		/// The WebPosTransactionID column in the DB
		/// </summary>
		public int WebPosTransactionID {
			get {
				return (int)m_intWebPosTransactionID;
			}
			set {
				m_intWebPosTransactionID = value;
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
		/// The ReservationID column in the DB
		/// </summary>
		public int ReservationID {
			get {
				return (int)m_intReservationID;
			}
			set {
				m_intReservationID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReservationCode column in the DB
		/// </summary>
		public string ReservationCode {
			get {
				return (string)m_strReservationCode;
			}
			set {
				m_strReservationCode = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Amount column in the DB
		/// </summary>
		public double Amount {
			get {
				return (double)m_dblAmount;
			}
			set {
				m_dblAmount = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The OrderCode column in the DB
		/// </summary>
		public string OrderCode {
			get {
				return (string)m_strOrderCode;
			}
			set {
				m_strOrderCode = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Status column in the DB
		/// </summary>
		public int Status {
			get {
				return (int)m_intStatus;
			}
			set {
				m_intStatus = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReturnValue column in the DB
		/// </summary>
		public string ReturnValue {
			get {
				return (string)m_strReturnValue;
			}
			set {
				m_strReturnValue = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ReturnValueDescription column in the DB
		/// </summary>
		public string ReturnValueDescription {
			get {
				return (string)m_strReturnValueDescription;
			}
			set {
				m_strReturnValueDescription = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TransactionDate column in the DB
		/// </summary>
		public DateTime TransactionDate {
			get {
				return (DateTime)m_dtTransactionDate;
			}
			set {
				m_dtTransactionDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.WebPosTransactionID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intWebPosTransactionID"> WebPosTransactionID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intWebPosTransactionID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for WebPosTransactionID column
        param = new SqlParameter("@WebPosTransactionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intWebPosTransactionID;
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
		            m_intWebPosTransactionID = reader.GetSqlInt32(0);
            m_intCustomerID = reader.GetSqlInt32(1);
            m_intUserID = reader.GetSqlInt32(2);
            m_intReservationID = reader.GetSqlInt32(3);
            m_strReservationCode = reader.GetSqlString(4);
            m_dblAmount = reader.GetSqlDouble(5);
            m_strOrderCode = reader.GetSqlString(6);
            m_intStatus = reader.GetSqlInt32(7);
            m_strReturnValue = reader.GetSqlString(8);
            m_strReturnValueDescription = reader.GetSqlString(9);
            m_dtTransactionDate = reader.GetSqlDateTime(10);
		
			} else {
					//	set key values
		            m_intWebPosTransactionID = intWebPosTransactionID;
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
							cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for WebPosTransactionID column
        param = new SqlParameter("@WebPosTransactionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intWebPosTransactionID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationCode column
        param = new SqlParameter("@ReservationCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReservationCode;
        cmd.Parameters.Add(param);
        
        // parameter for Amount column
        param = new SqlParameter("@Amount", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblAmount;
        cmd.Parameters.Add(param);
        
        // parameter for OrderCode column
        param = new SqlParameter("@OrderCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strOrderCode;
        cmd.Parameters.Add(param);
        
        // parameter for Status column
        param = new SqlParameter("@Status", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStatus;
        cmd.Parameters.Add(param);
        
        // parameter for ReturnValue column
        param = new SqlParameter("@ReturnValue", SqlDbType.VarChar, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReturnValue;
        cmd.Parameters.Add(param);
        
        // parameter for ReturnValueDescription column
        param = new SqlParameter("@ReturnValueDescription", SqlDbType.NVarChar, 150);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReturnValueDescription;
        cmd.Parameters.Add(param);
        
        // parameter for TransactionDate column
        param = new SqlParameter("@TransactionDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtTransactionDate;
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
				cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for WebPosTransactionID column
        param = new SqlParameter("@WebPosTransactionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intWebPosTransactionID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationID column
        param = new SqlParameter("@ReservationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intReservationID;
        cmd.Parameters.Add(param);
        
        // parameter for ReservationCode column
        param = new SqlParameter("@ReservationCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReservationCode;
        cmd.Parameters.Add(param);
        
        // parameter for Amount column
        param = new SqlParameter("@Amount", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblAmount;
        cmd.Parameters.Add(param);
        
        // parameter for OrderCode column
        param = new SqlParameter("@OrderCode", SqlDbType.Char, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strOrderCode;
        cmd.Parameters.Add(param);
        
        // parameter for Status column
        param = new SqlParameter("@Status", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStatus;
        cmd.Parameters.Add(param);
        
        // parameter for ReturnValue column
        param = new SqlParameter("@ReturnValue", SqlDbType.VarChar, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReturnValue;
        cmd.Parameters.Add(param);
        
        // parameter for ReturnValueDescription column
        param = new SqlParameter("@ReturnValueDescription", SqlDbType.NVarChar, 150);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReturnValueDescription;
        cmd.Parameters.Add(param);
        
        // parameter for TransactionDate column
        param = new SqlParameter("@TransactionDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtTransactionDate;
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
				cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_WebPosTransactions__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for WebPosTransactionID column
        param = new SqlParameter("@WebPosTransactionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intWebPosTransactionID;
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
		public static bool operator ==(WebPosTransactions t1, WebPosTransactions t2) {
			//	compare values
			if(t1.m_intWebPosTransactionID != t2.m_intWebPosTransactionID) {
				return false;	//	because "WebPosTransactionID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intUserID != t2.m_intUserID) {
				return false;	//	because "UserID" values are Not equal
			}
	
			if(t1.m_intReservationID != t2.m_intReservationID) {
				return false;	//	because "ReservationID" values are Not equal
			}
	
			if(t1.m_strReservationCode != t2.m_strReservationCode) {
				return false;	//	because "ReservationCode" values are Not equal
			}
	
			if(t1.m_dblAmount != t2.m_dblAmount) {
				return false;	//	because "Amount" values are Not equal
			}
	
			if(t1.m_strOrderCode != t2.m_strOrderCode) {
				return false;	//	because "OrderCode" values are Not equal
			}
	
			if(t1.m_intStatus != t2.m_intStatus) {
				return false;	//	because "Status" values are Not equal
			}
	
			if(t1.m_strReturnValue != t2.m_strReturnValue) {
				return false;	//	because "ReturnValue" values are Not equal
			}
	
			if(t1.m_strReturnValueDescription != t2.m_strReturnValueDescription) {
				return false;	//	because "ReturnValueDescription" values are Not equal
			}
	
			if(t1.m_dtTransactionDate != t2.m_dtTransactionDate) {
				return false;	//	because "TransactionDate" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(WebPosTransactions t1, WebPosTransactions t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" WebPosTransactionID = \"");
			retValue.Append(m_intWebPosTransactionID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    UserID = \"");
			retValue.Append(m_intUserID);
			retValue.Append("\"\n");
				retValue.Append("    ReservationID = \"");
			retValue.Append(m_intReservationID);
			retValue.Append("\"\n");
				retValue.Append("    ReservationCode = \"");
			retValue.Append(m_strReservationCode);
			retValue.Append("\"\n");
				retValue.Append("    Amount = \"");
			retValue.Append(m_dblAmount);
			retValue.Append("\"\n");
				retValue.Append("    OrderCode = \"");
			retValue.Append(m_strOrderCode);
			retValue.Append("\"\n");
				retValue.Append("    Status = \"");
			retValue.Append(m_intStatus);
			retValue.Append("\"\n");
				retValue.Append("    ReturnValue = \"");
			retValue.Append(m_strReturnValue);
			retValue.Append("\"\n");
				retValue.Append("    ReturnValueDescription = \"");
			retValue.Append(m_strReturnValueDescription);
			retValue.Append("\"\n");
				retValue.Append("    TransactionDate = \"");
			retValue.Append(m_dtTransactionDate);
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
			if (!(o is WebPosTransactions)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (WebPosTransactions)o;
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
