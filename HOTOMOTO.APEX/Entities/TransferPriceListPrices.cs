using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class TransferPriceListPrices {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intTransferPriceListPriceID;
		private SqlInt32 m_intGuestCapacity;
		private SqlInt32 m_intTransferPriceListID;
		private SqlInt32 m_intRegularPriceID;
		private SqlInt32 m_intPrivatePriceID;
		private SqlInt32 m_intGuidancePriceID;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public TransferPriceListPrices() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all TransferPriceListPrices from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the TransferPriceListPrices</returns>
		public static SqlDataReader GetAllTransferPriceListPricesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllTransferPriceListPricesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all TransferPriceListPrices from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllTransferPriceListPrices() {
			SqlDataReader dr = GetAllTransferPriceListPricesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates TransferPriceListPrices for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the TransferPriceListPrices records</param>
		/// <returns>The Hashtable containing TransferPriceListPrices objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            TransferPriceListPrices myTransferPriceListPrices = new TransferPriceListPrices();
            
            myTransferPriceListPrices.m_intTransferPriceListPriceID = dr.GetSqlInt32(0);
            myTransferPriceListPrices.m_intGuestCapacity = dr.GetSqlInt32(1);
            myTransferPriceListPrices.m_intTransferPriceListID = dr.GetSqlInt32(2);
            myTransferPriceListPrices.m_intRegularPriceID = dr.GetSqlInt32(3);
            myTransferPriceListPrices.m_intPrivatePriceID = dr.GetSqlInt32(4);
            myTransferPriceListPrices.m_intGuidancePriceID = dr.GetSqlInt32(5);
            
            result.Add(myTransferPriceListPrices.TransferPriceListPriceID, myTransferPriceListPrices);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 TransferPriceListPriceID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.TransferPriceListPriceID = m_intTransferPriceListPriceID;
				return pk;
			}
		}
			/// <summary>
		/// The TransferPriceListPriceID column in the DB
		/// </summary>
		public int TransferPriceListPriceID {
			get {
				return (int)m_intTransferPriceListPriceID;
			}
			set {
				m_intTransferPriceListPriceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The GuestCapacity column in the DB
		/// </summary>
		public int GuestCapacity {
			get {
				return (int)m_intGuestCapacity;
			}
			set {
				m_intGuestCapacity = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TransferPriceListID column in the DB
		/// </summary>
		public int TransferPriceListID {
			get {
				return (int)m_intTransferPriceListID;
			}
			set {
				m_intTransferPriceListID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The RegularPriceID column in the DB
		/// </summary>
		public int RegularPriceID {
			get {
				return (int)m_intRegularPriceID;
			}
			set {
				m_intRegularPriceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PrivatePriceID column in the DB
		/// </summary>
		public int PrivatePriceID {
			get {
				return (int)m_intPrivatePriceID;
			}
			set {
				m_intPrivatePriceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The GuidancePriceID column in the DB
		/// </summary>
		public int GuidancePriceID {
			get {
				return (int)m_intGuidancePriceID;
			}
			set {
				m_intGuidancePriceID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.TransferPriceListPriceID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intTransferPriceListPriceID"> TransferPriceListPriceID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intTransferPriceListPriceID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for TransferPriceListPriceID column
        param = new SqlParameter("@TransferPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intTransferPriceListPriceID;
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
		            m_intTransferPriceListPriceID = reader.GetSqlInt32(0);
            m_intGuestCapacity = reader.GetSqlInt32(1);
            m_intTransferPriceListID = reader.GetSqlInt32(2);
            m_intRegularPriceID = reader.GetSqlInt32(3);
            m_intPrivatePriceID = reader.GetSqlInt32(4);
            m_intGuidancePriceID = reader.GetSqlInt32(5);
		
			} else {
					//	set key values
		            m_intTransferPriceListPriceID = intTransferPriceListPriceID;
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
							cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TransferPriceListPriceID column
        param = new SqlParameter("@TransferPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferPriceListPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for GuestCapacity column
        param = new SqlParameter("@GuestCapacity", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuestCapacity;
        cmd.Parameters.Add(param);
        
        // parameter for TransferPriceListID column
        param = new SqlParameter("@TransferPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for RegularPriceID column
        param = new SqlParameter("@RegularPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRegularPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for PrivatePriceID column
        param = new SqlParameter("@PrivatePriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPrivatePriceID;
        cmd.Parameters.Add(param);
        
        // parameter for GuidancePriceID column
        param = new SqlParameter("@GuidancePriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuidancePriceID;
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
				cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for TransferPriceListPriceID column
        param = new SqlParameter("@TransferPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferPriceListPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for GuestCapacity column
        param = new SqlParameter("@GuestCapacity", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuestCapacity;
        cmd.Parameters.Add(param);
        
        // parameter for TransferPriceListID column
        param = new SqlParameter("@TransferPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for RegularPriceID column
        param = new SqlParameter("@RegularPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRegularPriceID;
        cmd.Parameters.Add(param);
        
        // parameter for PrivatePriceID column
        param = new SqlParameter("@PrivatePriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPrivatePriceID;
        cmd.Parameters.Add(param);
        
        // parameter for GuidancePriceID column
        param = new SqlParameter("@GuidancePriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intGuidancePriceID;
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
				cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_TransferPriceListPrices__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for TransferPriceListPriceID column
        param = new SqlParameter("@TransferPriceListPriceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferPriceListPriceID;
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
		public static bool operator ==(TransferPriceListPrices t1, TransferPriceListPrices t2) {
			//	compare values
			if(t1.m_intTransferPriceListPriceID != t2.m_intTransferPriceListPriceID) {
				return false;	//	because "TransferPriceListPriceID" values are Not equal
			}
	
			if(t1.m_intGuestCapacity != t2.m_intGuestCapacity) {
				return false;	//	because "GuestCapacity" values are Not equal
			}
	
			if(t1.m_intTransferPriceListID != t2.m_intTransferPriceListID) {
				return false;	//	because "TransferPriceListID" values are Not equal
			}
	
			if(t1.m_intRegularPriceID != t2.m_intRegularPriceID) {
				return false;	//	because "RegularPriceID" values are Not equal
			}
	
			if(t1.m_intPrivatePriceID != t2.m_intPrivatePriceID) {
				return false;	//	because "PrivatePriceID" values are Not equal
			}
	
			if(t1.m_intGuidancePriceID != t2.m_intGuidancePriceID) {
				return false;	//	because "GuidancePriceID" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(TransferPriceListPrices t1, TransferPriceListPrices t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" TransferPriceListPriceID = \"");
			retValue.Append(m_intTransferPriceListPriceID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    GuestCapacity = \"");
			retValue.Append(m_intGuestCapacity);
			retValue.Append("\"\n");
				retValue.Append("    TransferPriceListID = \"");
			retValue.Append(m_intTransferPriceListID);
			retValue.Append("\"\n");
				retValue.Append("    RegularPriceID = \"");
			retValue.Append(m_intRegularPriceID);
			retValue.Append("\"\n");
				retValue.Append("    PrivatePriceID = \"");
			retValue.Append(m_intPrivatePriceID);
			retValue.Append("\"\n");
				retValue.Append("    GuidancePriceID = \"");
			retValue.Append(m_intGuidancePriceID);
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
			if (!(o is TransferPriceListPrices)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (TransferPriceListPrices)o;
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
