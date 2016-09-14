using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class CustomerTypes_ML {
	
		
		//	members
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intCustomerTypeID;
		private SqlInt32 m_intLanguageID;
		private SqlString m_strType;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public CustomerTypes_ML() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all CustomerTypes_ML from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the CustomerTypes_ML</returns>
		public static SqlDataReader GetAllCustomerTypes_MLReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_CustomerTypes_ML__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllCustomerTypes_MLDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_CustomerTypes_ML__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all CustomerTypes_ML from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllCustomerTypes_ML() {
			SqlDataReader dr = GetAllCustomerTypes_MLReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates CustomerTypes_ML for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the CustomerTypes_ML records</param>
		/// <returns>The Hashtable containing CustomerTypes_ML objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            CustomerTypes_ML myCustomerTypes_ML = new CustomerTypes_ML();
            
            myCustomerTypes_ML.m_intCustomerTypeID = dr.GetSqlInt32(0);
            myCustomerTypes_ML.m_intLanguageID = dr.GetSqlInt32(1);
            myCustomerTypes_ML.m_strType = dr.GetSqlString(2);
		}
	
			return result;
		}
		
	
			/// <summary>
		/// The CustomerTypeID column in the DB
		/// </summary>
		public int CustomerTypeID {
			get {
				return (int)m_intCustomerTypeID;
			}
			set {
				m_intCustomerTypeID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The LanguageID column in the DB
		/// </summary>
		public int LanguageID {
			get {
				return (int)m_intLanguageID;
			}
			set {
				m_intLanguageID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Type column in the DB
		/// </summary>
		public string Type {
			get {
				return (string)m_strType;
			}
			set {
				m_strType = value;
				m_bIsDirty = true;
			}
		}
		
		public static int Insert(int CustomerTypeID, int LanguageID, string Type) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_CustomerTypes_ML__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
					
			// parameter for CustomerTypeID column
			param = new SqlParameter("@CustomerTypeID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = CustomerTypeID;
			cmd.Parameters.Add(param);
			
					
			// parameter for LanguageID column
			param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Input;
			param.Value = LanguageID;
			cmd.Parameters.Add(param);
			
					
			// parameter for Type column
			param = new SqlParameter("@Type", SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Input;
			param.Value = Type;
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
			//m_bIsDirty = false;
		
			return retValue;
		}
		
		
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Update() {
			if(m_bIsDirty) {
				//	construct new connection and command objects
				SqlConnection conn = DBHelper.getConnection();
				SqlCommand cmd = DBHelper.getSprocCmd("proc_CustomerTypes_ML__upd", conn);
			
				SqlParameter param;
			
				//	add return value param
				param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
				param.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(param);
			
				//	add params
		        // parameter for CustomerTypeID column
        param = new SqlParameter("@CustomerTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for Type column
        param = new SqlParameter("@Type", SqlDbType.NVarChar, 32);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strType;
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
			return 0;
		}
		//	operators
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator ==(CustomerTypes_ML t1, CustomerTypes_ML t2) {
			//	compare values
			if(t1.m_intCustomerTypeID != t2.m_intCustomerTypeID) {
				return false;	//	because "CustomerTypeID" values are Not equal
			}
	
			if(t1.m_intLanguageID != t2.m_intLanguageID) {
				return false;	//	because "LanguageID" values are Not equal
			}
	
			if(t1.m_strType != t2.m_strType) {
				return false;	//	because "Type" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(CustomerTypes_ML t1, CustomerTypes_ML t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
			
			retValue.Append("Columns:\n");
				retValue.Append("    CustomerTypeID = \"");
			retValue.Append(m_intCustomerTypeID);
			retValue.Append("\"\n");
				retValue.Append("    LanguageID = \"");
			retValue.Append(m_intLanguageID);
			retValue.Append("\"\n");
				retValue.Append("    Type = \"");
			retValue.Append(m_strType);
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
			if (!(o is CustomerTypes_ML)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (CustomerTypes_ML)o;
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
		 
			m_bIsDirty = false;	//	Objectstring"clean" upon init
		}
	}
}
