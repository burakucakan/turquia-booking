using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class sysdiagrams {
	
		
		//	members
		private Action m_aAction;
		private bool m_bIsDirty;
		//private bool m_bIsMLDirty;
		
		//	members from table
		private SqlString m_strname;
		private SqlInt32 m_intprincipal_id;
		private SqlInt32 m_intdiagram_id;
		private SqlInt32 m_intversion;
		private SqlBinary m_definition;
		
		// members from ml table
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public sysdiagrams() {
			Init();	//	init Object
			
		
		}
	
		/// <summary>
		/// Gets all sysdiagrams from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the sysdiagrams</returns>
		public static SqlDataReader GetAllsysdiagramsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_sysdiagrams__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllsysdiagramsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_sysdiagrams__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all sysdiagrams from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllsysdiagrams() {
			SqlDataReader dr = GetAllsysdiagramsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates sysdiagrams for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the sysdiagrams records</param>
		/// <returns>The Hashtable containing sysdiagrams objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            sysdiagrams mysysdiagrams = new sysdiagrams();
            
            mysysdiagrams.m_strname = dr.GetSqlString(0);
            mysysdiagrams.m_intprincipal_id = dr.GetSqlInt32(1);
            mysysdiagrams.m_intdiagram_id = dr.GetSqlInt32(2);
            mysysdiagrams.m_intversion = dr.GetSqlInt32(3);
            mysysdiagrams.m_definition = dr.GetSqlBinary(4);
            
            result.Add(mysysdiagrams.diagram_id, mysysdiagrams);
		}
	
			return result;
		}
	
		//	enum types
		enum Action { Insert, Update, Delete };
	
		//	Sub-types
		public struct PK {
			public SqlInt32 diagram_id;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.diagram_id = m_intdiagram_id;
				return pk;
			}
		}
			/// <summary>
		/// The name column in the DB
		/// </summary>
		public string name {
			get {
				return (string)m_strname;
			}
			set {
				m_strname = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The principal_id column in the DB
		/// </summary>
		public int principal_id {
			get {
				return (int)m_intprincipal_id;
			}
			set {
				m_intprincipal_id = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The diagram_id column in the DB
		/// </summary>
		public int diagram_id {
			get {
				return (int)m_intdiagram_id;
			}
			set {
				m_intdiagram_id = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The version column in the DB
		/// </summary>
		public int version {
			get {
				return (int)m_intversion;
			}
			set {
				m_intversion = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The definition column in the DB
		/// </summary>
		public byte[] definition {
			get {
				return (byte[])m_definition;
			}
			set {
				m_definition = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.diagram_id.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intdiagram_id"> diagram_id key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intdiagram_id) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_sysdiagrams__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for diagram_id column
        param = new SqlParameter("@diagram_id", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intdiagram_id;
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
		            m_strname = reader.GetSqlString(0);
            m_intprincipal_id = reader.GetSqlInt32(1);
            m_intdiagram_id = reader.GetSqlInt32(2);
            m_intversion = reader.GetSqlInt32(3);
            m_definition = reader.GetSqlBinary(4);
		
			} else {
					//	set key values
		            m_intdiagram_id = intdiagram_id;
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
		public int Update() {
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
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Delete() {
			m_aAction = Action.Delete;	//	actionstringdelete
			return Update();
		}
	
		//	private member functions
	
		/// <summary>
		/// Adds the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int ins() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_sysdiagrams__ins", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for name column
        param = new SqlParameter("@name", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strname;
        cmd.Parameters.Add(param);
        
        // parameter for principal_id column
        param = new SqlParameter("@principal_id", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intprincipal_id;
        cmd.Parameters.Add(param);
        
        // parameter for diagram_id column
        param = new SqlParameter("@diagram_id", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intdiagram_id;
        cmd.Parameters.Add(param);
        
        // parameter for version column
        param = new SqlParameter("@version", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intversion;
        cmd.Parameters.Add(param);
        
        // parameter for definition column
        param = new SqlParameter("@definition", SqlDbType.VarBinary, -1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_definition;
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
			SqlCommand cmd = DBHelper.getSprocCmd("proc_sysdiagrams__upd", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for diagram_id column
        param = new SqlParameter("@diagram_id", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intdiagram_id;
        cmd.Parameters.Add(param);
        
        // parameter for name column
        param = new SqlParameter("@name", SqlDbType.NVarChar, 128);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strname;
        cmd.Parameters.Add(param);
        
        // parameter for principal_id column
        param = new SqlParameter("@principal_id", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intprincipal_id;
        cmd.Parameters.Add(param);
        
        // parameter for version column
        param = new SqlParameter("@version", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intversion;
        cmd.Parameters.Add(param);
        
        // parameter for definition column
        param = new SqlParameter("@definition", SqlDbType.VarBinary, -1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_definition;
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
			SqlCommand cmd = DBHelper.getSprocCmd("proc_sysdiagrams__del", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for diagram_id column
        param = new SqlParameter("@diagram_id", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intdiagram_id;
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
		public static bool operator ==(sysdiagrams t1, sysdiagrams t2) {
			//	compare values
			if(t1.m_strname != t2.m_strname) {
				return false;	//	because "name" values are Not equal
			}
	
			if(t1.m_intprincipal_id != t2.m_intprincipal_id) {
				return false;	//	because "principal_id" values are Not equal
			}
	
			if(t1.m_intdiagram_id != t2.m_intdiagram_id) {
				return false;	//	because "diagram_id" values are Not equal
			}
	
			if(t1.m_intversion != t2.m_intversion) {
				return false;	//	because "version" values are Not equal
			}
	
			if(t1.m_definition != t2.m_definition) {
				return false;	//	because "definition" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(sysdiagrams t1, sysdiagrams t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" diagram_id = \"");
			retValue.Append(m_intdiagram_id);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    name = \"");
			retValue.Append(m_strname);
			retValue.Append("\"\n");
				retValue.Append("    principal_id = \"");
			retValue.Append(m_intprincipal_id);
			retValue.Append("\"\n");
				retValue.Append("    version = \"");
			retValue.Append(m_intversion);
			retValue.Append("\"\n");
				retValue.Append("    definition = \"");
			retValue.Append(m_definition);
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
			if (!(o is sysdiagrams)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (sysdiagrams)o;
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
