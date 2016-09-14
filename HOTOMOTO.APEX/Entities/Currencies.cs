using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Currencies {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intCurrencyID;
		private SqlString m_strTitle;
		private SqlString m_strCode;
		private SqlString m_strSymbolLeft;
		private SqlString m_strSymbolRight;
		private SqlString m_strDecimalPoint;
		private SqlString m_strThousandsPoint;
		private SqlByte m_bytDecimalPlaces;
		private SqlDouble m_dblValue;
		private SqlDateTime m_dtLastUpdated;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Currencies() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all Currencies from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Currencies</returns>
		public static SqlDataReader GetAllCurrenciesReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Currencies__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllCurrenciesDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Currencies__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Currencies from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllCurrencies() {
			SqlDataReader dr = GetAllCurrenciesReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Currencies for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Currencies records</param>
		/// <returns>The Hashtable containing Currencies objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Currencies myCurrencies = new Currencies();
            
            myCurrencies.m_intCurrencyID = dr.GetSqlInt32(0);
            myCurrencies.m_strTitle = dr.GetSqlString(1);
            myCurrencies.m_strCode = dr.GetSqlString(2);
            myCurrencies.m_strSymbolLeft = dr.GetSqlString(3);
            myCurrencies.m_strSymbolRight = dr.GetSqlString(4);
            myCurrencies.m_strDecimalPoint = dr.GetSqlString(5);
            myCurrencies.m_strThousandsPoint = dr.GetSqlString(6);
            myCurrencies.m_bytDecimalPlaces = dr.GetSqlByte(7);
            myCurrencies.m_dblValue = dr.GetSqlDouble(8);
            myCurrencies.m_dtLastUpdated = dr.GetSqlDateTime(9);
            
            result.Add(myCurrencies.CurrencyID, myCurrencies);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 CurrencyID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.CurrencyID = m_intCurrencyID;
				return pk;
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
		/// The Title column in the DB
		/// </summary>
		public string Title {
			get {
				return (string)m_strTitle;
			}
			set {
				m_strTitle = value;
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
		/// The SymbolLeft column in the DB
		/// </summary>
		public string SymbolLeft {
			get {
				return (string)m_strSymbolLeft;
			}
			set {
				m_strSymbolLeft = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The SymbolRight column in the DB
		/// </summary>
		public string SymbolRight {
			get {
				return (string)m_strSymbolRight;
			}
			set {
				m_strSymbolRight = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The DecimalPoint column in the DB
		/// </summary>
		public string DecimalPoint {
			get {
				return (string)m_strDecimalPoint;
			}
			set {
				m_strDecimalPoint = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ThousandsPoint column in the DB
		/// </summary>
		public string ThousandsPoint {
			get {
				return (string)m_strThousandsPoint;
			}
			set {
				m_strThousandsPoint = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The DecimalPlaces column in the DB
		/// </summary>
		public byte DecimalPlaces {
			get {
				return (byte)m_bytDecimalPlaces;
			}
			set {
				m_bytDecimalPlaces = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Value column in the DB
		/// </summary>
		public double Value {
			get {
				return (double)m_dblValue;
			}
			set {
				m_dblValue = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The LastUpdated column in the DB
		/// </summary>
		public DateTime LastUpdated {
			get {
				return (DateTime)m_dtLastUpdated;
			}
			set {
				m_dtLastUpdated = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.CurrencyID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intCurrencyID"> CurrencyID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intCurrencyID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Currencies__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for CurrencyID column
        param = new SqlParameter("@CurrencyID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intCurrencyID;
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
		            m_intCurrencyID = reader.GetSqlInt32(0);
            m_strTitle = reader.GetSqlString(1);
            m_strCode = reader.GetSqlString(2);
            m_strSymbolLeft = reader.GetSqlString(3);
            m_strSymbolRight = reader.GetSqlString(4);
            m_strDecimalPoint = reader.GetSqlString(5);
            m_strThousandsPoint = reader.GetSqlString(6);
            m_bytDecimalPlaces = reader.GetSqlByte(7);
            m_dblValue = reader.GetSqlDouble(8);
            m_dtLastUpdated = reader.GetSqlDateTime(9);
		
			} else {
					//	set key values
		            m_intCurrencyID = intCurrencyID;
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
							cmd = DBHelper.getSprocCmd("proc_Currencies__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Currencies__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for CurrencyID column
        param = new SqlParameter("@CurrencyID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCurrencyID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for Code column
        param = new SqlParameter("@Code", SqlDbType.Char, 3);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCode;
        cmd.Parameters.Add(param);
        
        // parameter for SymbolLeft column
        param = new SqlParameter("@SymbolLeft", SqlDbType.NVarChar, 12);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSymbolLeft;
        cmd.Parameters.Add(param);
        
        // parameter for SymbolRight column
        param = new SqlParameter("@SymbolRight", SqlDbType.NVarChar, 12);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSymbolRight;
        cmd.Parameters.Add(param);
        
        // parameter for DecimalPoint column
        param = new SqlParameter("@DecimalPoint", SqlDbType.Char, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDecimalPoint;
        cmd.Parameters.Add(param);
        
        // parameter for ThousandsPoint column
        param = new SqlParameter("@ThousandsPoint", SqlDbType.Char, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strThousandsPoint;
        cmd.Parameters.Add(param);
        
        // parameter for DecimalPlaces column
        param = new SqlParameter("@DecimalPlaces", SqlDbType.TinyInt, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bytDecimalPlaces;
        cmd.Parameters.Add(param);
        
        // parameter for Value column
        param = new SqlParameter("@Value", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblValue;
        cmd.Parameters.Add(param);
        
        // parameter for LastUpdated column
        param = new SqlParameter("@LastUpdated", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtLastUpdated;
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
				cmd = DBHelper.getSprocCmd("proc_Currencies__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Currencies__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for CurrencyID column
        param = new SqlParameter("@CurrencyID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCurrencyID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for Code column
        param = new SqlParameter("@Code", SqlDbType.Char, 3);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCode;
        cmd.Parameters.Add(param);
        
        // parameter for SymbolLeft column
        param = new SqlParameter("@SymbolLeft", SqlDbType.NVarChar, 12);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSymbolLeft;
        cmd.Parameters.Add(param);
        
        // parameter for SymbolRight column
        param = new SqlParameter("@SymbolRight", SqlDbType.NVarChar, 12);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSymbolRight;
        cmd.Parameters.Add(param);
        
        // parameter for DecimalPoint column
        param = new SqlParameter("@DecimalPoint", SqlDbType.Char, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDecimalPoint;
        cmd.Parameters.Add(param);
        
        // parameter for ThousandsPoint column
        param = new SqlParameter("@ThousandsPoint", SqlDbType.Char, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strThousandsPoint;
        cmd.Parameters.Add(param);
        
        // parameter for DecimalPlaces column
        param = new SqlParameter("@DecimalPlaces", SqlDbType.TinyInt, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bytDecimalPlaces;
        cmd.Parameters.Add(param);
        
        // parameter for Value column
        param = new SqlParameter("@Value", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblValue;
        cmd.Parameters.Add(param);
        
        // parameter for LastUpdated column
        param = new SqlParameter("@LastUpdated", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtLastUpdated;
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
				cmd = DBHelper.getSprocCmd("proc_Currencies__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Currencies__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for CurrencyID column
        param = new SqlParameter("@CurrencyID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCurrencyID;
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
		public static bool operator ==(Currencies t1, Currencies t2) {
			//	compare values
			if(t1.m_intCurrencyID != t2.m_intCurrencyID) {
				return false;	//	because "CurrencyID" values are Not equal
			}
	
			if(t1.m_strTitle != t2.m_strTitle) {
				return false;	//	because "Title" values are Not equal
			}
	
			if(t1.m_strCode != t2.m_strCode) {
				return false;	//	because "Code" values are Not equal
			}
	
			if(t1.m_strSymbolLeft != t2.m_strSymbolLeft) {
				return false;	//	because "SymbolLeft" values are Not equal
			}
	
			if(t1.m_strSymbolRight != t2.m_strSymbolRight) {
				return false;	//	because "SymbolRight" values are Not equal
			}
	
			if(t1.m_strDecimalPoint != t2.m_strDecimalPoint) {
				return false;	//	because "DecimalPoint" values are Not equal
			}
	
			if(t1.m_strThousandsPoint != t2.m_strThousandsPoint) {
				return false;	//	because "ThousandsPoint" values are Not equal
			}
	
			if(t1.m_bytDecimalPlaces != t2.m_bytDecimalPlaces) {
				return false;	//	because "DecimalPlaces" values are Not equal
			}
	
			if(t1.m_dblValue != t2.m_dblValue) {
				return false;	//	because "Value" values are Not equal
			}
	
			if(t1.m_dtLastUpdated != t2.m_dtLastUpdated) {
				return false;	//	because "LastUpdated" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Currencies t1, Currencies t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" CurrencyID = \"");
			retValue.Append(m_intCurrencyID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    Title = \"");
			retValue.Append(m_strTitle);
			retValue.Append("\"\n");
				retValue.Append("    Code = \"");
			retValue.Append(m_strCode);
			retValue.Append("\"\n");
				retValue.Append("    SymbolLeft = \"");
			retValue.Append(m_strSymbolLeft);
			retValue.Append("\"\n");
				retValue.Append("    SymbolRight = \"");
			retValue.Append(m_strSymbolRight);
			retValue.Append("\"\n");
				retValue.Append("    DecimalPoint = \"");
			retValue.Append(m_strDecimalPoint);
			retValue.Append("\"\n");
				retValue.Append("    ThousandsPoint = \"");
			retValue.Append(m_strThousandsPoint);
			retValue.Append("\"\n");
				retValue.Append("    DecimalPlaces = \"");
			retValue.Append(m_bytDecimalPlaces);
			retValue.Append("\"\n");
				retValue.Append("    Value = \"");
			retValue.Append(m_dblValue);
			retValue.Append("\"\n");
				retValue.Append("    LastUpdated = \"");
			retValue.Append(m_dtLastUpdated);
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
			if (!(o is Currencies)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Currencies)o;
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
