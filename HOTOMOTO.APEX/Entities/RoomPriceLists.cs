using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomPriceLists {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRoomPriceListID;
		private SqlString m_strPriceListName;
		private SqlDateTime m_dtBookingStartDate;
		private SqlDateTime m_dtBookingEndDate;
		private SqlBoolean m_bolisBasePrice;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
		private SqlBoolean m_bolisActive;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomPriceLists() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomPriceLists from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomPriceLists</returns>
		public static SqlDataReader GetAllRoomPriceListsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomPriceListsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomPriceLists from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomPriceLists() {
			SqlDataReader dr = GetAllRoomPriceListsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomPriceLists for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomPriceLists records</param>
		/// <returns>The Hashtable containing RoomPriceLists objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomPriceLists myRoomPriceLists = new RoomPriceLists();
            
            myRoomPriceLists.m_intRoomPriceListID = dr.GetSqlInt32(0);
            myRoomPriceLists.m_strPriceListName = dr.GetSqlString(1);
            myRoomPriceLists.m_dtBookingStartDate = dr.GetSqlDateTime(2);
            myRoomPriceLists.m_dtBookingEndDate = dr.GetSqlDateTime(3);
            myRoomPriceLists.m_bolisBasePrice = dr.GetSqlBoolean(4);
            myRoomPriceLists.m_dtCreateDate = dr.GetSqlDateTime(5);
            myRoomPriceLists.m_intCreatedBy = dr.GetSqlInt32(6);
            myRoomPriceLists.m_dtModifyDate = dr.GetSqlDateTime(7);
            myRoomPriceLists.m_intModifiedBy = dr.GetSqlInt32(8);
            myRoomPriceLists.m_bolisActive = dr.GetSqlBoolean(9);
            
            result.Add(myRoomPriceLists.RoomPriceListID, myRoomPriceLists);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 RoomPriceListID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.RoomPriceListID = m_intRoomPriceListID;
				return pk;
			}
		}
			/// <summary>
		/// The RoomPriceListID column in the DB
		/// </summary>
		public int RoomPriceListID {
			get {
				return (int)m_intRoomPriceListID;
			}
			set {
				m_intRoomPriceListID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The PriceListName column in the DB
		/// </summary>
		public string PriceListName {
			get {
				return (string)m_strPriceListName;
			}
			set {
				m_strPriceListName = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The BookingStartDate column in the DB
		/// </summary>
		public DateTime BookingStartDate {
			get {
				return (DateTime)m_dtBookingStartDate;
			}
			set {
				m_dtBookingStartDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The BookingEndDate column in the DB
		/// </summary>
		public DateTime BookingEndDate {
			get {
				return (DateTime)m_dtBookingEndDate;
			}
			set {
				m_dtBookingEndDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isBasePrice column in the DB
		/// </summary>
		public bool isBasePrice {
			get {
				return (bool)m_bolisBasePrice;
			}
			set {
				m_bolisBasePrice = value;
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
			return Load(pk.RoomPriceListID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intRoomPriceListID"> RoomPriceListID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intRoomPriceListID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for RoomPriceListID column
        param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRoomPriceListID;
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
		            m_intRoomPriceListID = reader.GetSqlInt32(0);
            m_strPriceListName = reader.GetSqlString(1);
            m_dtBookingStartDate = reader.GetSqlDateTime(2);
            m_dtBookingEndDate = reader.GetSqlDateTime(3);
            m_bolisBasePrice = reader.GetSqlBoolean(4);
            m_dtCreateDate = reader.GetSqlDateTime(5);
            m_intCreatedBy = reader.GetSqlInt32(6);
            m_dtModifyDate = reader.GetSqlDateTime(7);
            m_intModifiedBy = reader.GetSqlInt32(8);
            m_bolisActive = reader.GetSqlBoolean(9);
		
			} else {
					//	set key values
		            m_intRoomPriceListID = intRoomPriceListID;
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
							cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomPriceListID column
        param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for PriceListName column
        param = new SqlParameter("@PriceListName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPriceListName;
        cmd.Parameters.Add(param);
        
        // parameter for BookingStartDate column
        param = new SqlParameter("@BookingStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for BookingEndDate column
        param = new SqlParameter("@BookingEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for isBasePrice column
        param = new SqlParameter("@isBasePrice", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisBasePrice;
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
				cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for RoomPriceListID column
        param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListID;
        cmd.Parameters.Add(param);
        
        // parameter for PriceListName column
        param = new SqlParameter("@PriceListName", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPriceListName;
        cmd.Parameters.Add(param);
        
        // parameter for BookingStartDate column
        param = new SqlParameter("@BookingStartDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingStartDate;
        cmd.Parameters.Add(param);
        
        // parameter for BookingEndDate column
        param = new SqlParameter("@BookingEndDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBookingEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for isBasePrice column
        param = new SqlParameter("@isBasePrice", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisBasePrice;
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
				cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomPriceLists__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomPriceListID column
        param = new SqlParameter("@RoomPriceListID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomPriceListID;
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
		public static bool operator ==(RoomPriceLists t1, RoomPriceLists t2) {
			//	compare values
			if(t1.m_intRoomPriceListID != t2.m_intRoomPriceListID) {
				return false;	//	because "RoomPriceListID" values are Not equal
			}
	
			if(t1.m_strPriceListName != t2.m_strPriceListName) {
				return false;	//	because "PriceListName" values are Not equal
			}
	
			if(t1.m_dtBookingStartDate != t2.m_dtBookingStartDate) {
				return false;	//	because "BookingStartDate" values are Not equal
			}
	
			if(t1.m_dtBookingEndDate != t2.m_dtBookingEndDate) {
				return false;	//	because "BookingEndDate" values are Not equal
			}
	
			if(t1.m_bolisBasePrice != t2.m_bolisBasePrice) {
				return false;	//	because "isBasePrice" values are Not equal
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
		public static bool operator !=(RoomPriceLists t1, RoomPriceLists t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" RoomPriceListID = \"");
			retValue.Append(m_intRoomPriceListID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    PriceListName = \"");
			retValue.Append(m_strPriceListName);
			retValue.Append("\"\n");
				retValue.Append("    BookingStartDate = \"");
			retValue.Append(m_dtBookingStartDate);
			retValue.Append("\"\n");
				retValue.Append("    BookingEndDate = \"");
			retValue.Append(m_dtBookingEndDate);
			retValue.Append("\"\n");
				retValue.Append("    isBasePrice = \"");
			retValue.Append(m_bolisBasePrice);
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
			if (!(o is RoomPriceLists)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomPriceLists)o;
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
