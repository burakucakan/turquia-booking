using System.Collections.Specialized;
using ApexSql.Code.ObjectModel;

public class CSharpHelper
{
	/// <summary>
	/// Checks whether a datatype of column is numeric or decimal.
	/// </summary>
	/// <param name="objColumn">A column to check.</param>
	/// <returns>'true' if datatype of column is numeric or decimal, 'false' - otherwise.</returns>
	public static bool IsColumnNumericOrDecimal(Column objColumn)
	{
		return 0 == string.Compare(objColumn.SQLDatatype, "numeric", true) ||
			0 == string.Compare(objColumn.SQLDatatype, "decimal", true);
	}

	/// <summary>
	/// Makes a parameter declaration for specified column.
	/// </summary>
	/// <param name="column">A column for which parameter should be made.</param>
	/// <param name="variableName">A name variable for parameter.</param>
	/// <param name="direction">Parameter direction.</param>
	/// <returns>String collection with parameter declaration.</returns>
	public static StringCollection MakeParameter(Column column, string variableName, string direction)
	{
		return MakeParameter(column, variableName, direction, string.Empty);	
	}
	
	/// <summary>
	/// Makes a parameter declaration for specified column.
	/// </summary>
	/// <param name="column">A column for which parameter should be made.</param>
	/// <param name="variableName">A name variable for parameter.</param>
	/// <param name="direction">Parameter direction.</param>
	/// <param name="prefix">A prefix for parameter variable.</param>
	/// <returns>String collection with parameter declaration.</returns>
	public static StringCollection MakeParameter(Column column, string variableName, string direction, string prefix)
	{
		StringCollection coll = new StringCollection();
		coll.Add(string.Format("// parameter for {0} column", column.Name));
		
		coll.Add(string.Format("{0} = new SqlParameter(\"@{1}\", {2}, {3});", variableName, column.Name, column.AdoNetMapping.SqlDbType, column.Length));
		
		if(IsColumnNumericOrDecimal(column))
		{
			coll.Add(string.Format("{0}.Precision ={1};", variableName, column.Precision));
			coll.Add(string.Format("{0}.Scale = {1};", variableName, column.Scale));
		}
		
		coll.Add(string.Format("{0}.Direction = ParameterDirection.{1};", variableName, direction));

		if(direction != "Output")
		{
			coll.Add(string.Format("{0}.Value = {1}{2}{3};",  variableName, prefix, column.GetPrefix("C#"), column.Name));
		}

		return coll;
	}
}