using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class PackagedTransfer {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intPackagedTransferID;
		private SqlInt32 m_intPackageID;
		private SqlInt32 m_intTransferTypeID;
		private SqlBoolean m_bolhasGuidance;
		private SqlBoolean m_bolhasVIPReception;
		private SqlInt32 m_intArrivalPortID;
		private SqlInt32 m_intDeparturePortID;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public PackagedTransfer() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all PackagedTransfer from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the PackagedTransfer</returns>
		public static SqlDataReader GetAllPackagedTransferReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllPackagedTransferDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all PackagedTransfer from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllPackagedTransfer() {
			SqlDataReader dr = GetAllPackagedTransferReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates PackagedTransfer for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the PackagedTransfer records</param>
		/// <returns>The Hashtable containing PackagedTransfer objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            PackagedTransfer myPackagedTransfer = new PackagedTransfer();
            
            myPackagedTransfer.m_intPackagedTransferID = dr.GetSqlInt32(0);
            myPackagedTransfer.m_intPackageID = dr.GetSqlInt32(1);
            myPackagedTransfer.m_intTransferTypeID = dr.GetSqlInt32(2);
            myPackagedTransfer.m_bolhasGuidance = dr.GetSqlBoolean(3);
            myPackagedTransfer.m_bolhasVIPReception = dr.GetSqlBoolean(4);
            myPackagedTransfer.m_intArrivalPortID = dr.GetSqlInt32(5);
            myPackagedTransfer.m_intDeparturePortID = dr.GetSqlInt32(6);
            
            result.Add(myPackagedTransfer.PackagedTransferID, myPackagedTransfer);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 PackagedTransferID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.PackagedTransferID = m_intPackagedTransferID;
				return pk;
			}
		}
			/// <summary>
		/// The PackagedTransferID column in the DB
		/// </summary>
		public int PackagedTransferID {
			get {
				return (int)m_intPackagedTransferID;
			}
			set {
				m_intPackagedTransferID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PackageID column in the DB
		/// </summary>
		public int PackageID {
			get {
				return (int)m_intPackageID;
			}
			set {
				m_intPackageID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The TransferTypeID column in the DB
		/// </summary>
		public int TransferTypeID {
			get {
				return (int)m_intTransferTypeID;
			}
			set {
				m_intTransferTypeID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The hasGuidance column in the DB
		/// </summary>
		public bool hasGuidance {
			get {
				return (bool)m_bolhasGuidance;
			}
			set {
				m_bolhasGuidance = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The hasVIPReception column in the DB
		/// </summary>
		public bool hasVIPReception {
			get {
				return (bool)m_bolhasVIPReception;
			}
			set {
				m_bolhasVIPReception = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ArrivalPortID column in the DB
		/// </summary>
		public int ArrivalPortID {
			get {
				return (int)m_intArrivalPortID;
			}
			set {
				m_intArrivalPortID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The DeparturePortID column in the DB
		/// </summary>
		public int DeparturePortID {
			get {
				return (int)m_intDeparturePortID;
			}
			set {
				m_intDeparturePortID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.PackagedTransferID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intPackagedTransferID"> PackagedTransferID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intPackagedTransferID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for PackagedTransferID column
        param = new SqlParameter("@PackagedTransferID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intPackagedTransferID;
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
		            m_intPackagedTransferID = reader.GetSqlInt32(0);
            m_intPackageID = reader.GetSqlInt32(1);
            m_intTransferTypeID = reader.GetSqlInt32(2);
            m_bolhasGuidance = reader.GetSqlBoolean(3);
            m_bolhasVIPReception = reader.GetSqlBoolean(4);
            m_intArrivalPortID = reader.GetSqlInt32(5);
            m_intDeparturePortID = reader.GetSqlInt32(6);
		
			} else {
					//	set key values
		            m_intPackagedTransferID = intPackagedTransferID;
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
							cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PackagedTransferID column
        param = new SqlParameter("@PackagedTransferID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackagedTransferID;
        cmd.Parameters.Add(param);
        
        // parameter for PackageID column
        param = new SqlParameter("@PackageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackageID;
        cmd.Parameters.Add(param);
        
        // parameter for TransferTypeID column
        param = new SqlParameter("@TransferTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for hasGuidance column
        param = new SqlParameter("@hasGuidance", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasGuidance;
        cmd.Parameters.Add(param);
        
        // parameter for hasVIPReception column
        param = new SqlParameter("@hasVIPReception", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasVIPReception;
        cmd.Parameters.Add(param);
        
        // parameter for ArrivalPortID column
        param = new SqlParameter("@ArrivalPortID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArrivalPortID;
        cmd.Parameters.Add(param);
        
        // parameter for DeparturePortID column
        param = new SqlParameter("@DeparturePortID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intDeparturePortID;
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
				cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for PackagedTransferID column
        param = new SqlParameter("@PackagedTransferID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackagedTransferID;
        cmd.Parameters.Add(param);
        
        // parameter for PackageID column
        param = new SqlParameter("@PackageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackageID;
        cmd.Parameters.Add(param);
        
        // parameter for TransferTypeID column
        param = new SqlParameter("@TransferTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intTransferTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for hasGuidance column
        param = new SqlParameter("@hasGuidance", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasGuidance;
        cmd.Parameters.Add(param);
        
        // parameter for hasVIPReception column
        param = new SqlParameter("@hasVIPReception", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolhasVIPReception;
        cmd.Parameters.Add(param);
        
        // parameter for ArrivalPortID column
        param = new SqlParameter("@ArrivalPortID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArrivalPortID;
        cmd.Parameters.Add(param);
        
        // parameter for DeparturePortID column
        param = new SqlParameter("@DeparturePortID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intDeparturePortID;
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
				cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_PackagedTransfer__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PackagedTransferID column
        param = new SqlParameter("@PackagedTransferID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPackagedTransferID;
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
		public static bool operator ==(PackagedTransfer t1, PackagedTransfer t2) {
			//	compare values
			if(t1.m_intPackagedTransferID != t2.m_intPackagedTransferID) {
				return false;	//	because "PackagedTransferID" values are Not equal
			}
	
			if(t1.m_intPackageID != t2.m_intPackageID) {
				return false;	//	because "PackageID" values are Not equal
			}
	
			if(t1.m_intTransferTypeID != t2.m_intTransferTypeID) {
				return false;	//	because "TransferTypeID" values are Not equal
			}
	
			if(t1.m_bolhasGuidance != t2.m_bolhasGuidance) {
				return false;	//	because "hasGuidance" values are Not equal
			}
	
			if(t1.m_bolhasVIPReception != t2.m_bolhasVIPReception) {
				return false;	//	because "hasVIPReception" values are Not equal
			}
	
			if(t1.m_intArrivalPortID != t2.m_intArrivalPortID) {
				return false;	//	because "ArrivalPortID" values are Not equal
			}
	
			if(t1.m_intDeparturePortID != t2.m_intDeparturePortID) {
				return false;	//	because "DeparturePortID" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(PackagedTransfer t1, PackagedTransfer t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" PackagedTransferID = \"");
			retValue.Append(m_intPackagedTransferID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    PackageID = \"");
			retValue.Append(m_intPackageID);
			retValue.Append("\"\n");
				retValue.Append("    TransferTypeID = \"");
			retValue.Append(m_intTransferTypeID);
			retValue.Append("\"\n");
				retValue.Append("    hasGuidance = \"");
			retValue.Append(m_bolhasGuidance);
			retValue.Append("\"\n");
				retValue.Append("    hasVIPReception = \"");
			retValue.Append(m_bolhasVIPReception);
			retValue.Append("\"\n");
				retValue.Append("    ArrivalPortID = \"");
			retValue.Append(m_intArrivalPortID);
			retValue.Append("\"\n");
				retValue.Append("    DeparturePortID = \"");
			retValue.Append(m_intDeparturePortID);
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
			if (!(o is PackagedTransfer)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (PackagedTransfer)o;
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
