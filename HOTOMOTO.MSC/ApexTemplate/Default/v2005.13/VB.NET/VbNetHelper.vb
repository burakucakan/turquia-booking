Imports System.IO
Imports ApexSql.Code.ObjectModel

Public Class VbNetHelper

	Public Shared Sub MakeParameter(ByVal writer As TextWriter, ByVal column As Column, ByVal paramName As String, ByVal direction As String)

		MakeParameter(writer, column, paramName, direction, String.Empty)

	End Sub

	Public Shared Sub MakeParameter(ByVal writer As TextWriter, ByVal column As Column, ByVal paramName As String, ByVal direction As String, ByVal prefix As String)
	
		writer.WriteLine("' parameter for {0} column", column)		
		writer.WriteLine("{0} = New SqlParameter(""@{1}"", {2}, {3})", paramName, column.Name, column.AdoNetMapping.SqlDbType, column.Length )
		
		If IsColumnNumericOrDecimal( column ) Then
			writer.WriteLine("{0}.Precision = {1}", paramName, column.Precision)
			writer.WriteLine("{0}.Scale = {1}", paramName, column.Scale)
		End If
		
		writer.Write("{0}.Direction = ParameterDirection.{1}", paramName, direction)
		If direction <> "Output" Then
			writer.WriteLine()
			writer.Write("{0}.Value = {1}{2}{3}", paramName, prefix, column.GetPrefix("VB.NET"), column.Name)
		End If

	End Sub
	
	Public Shared Function IsColumnNumericOrDecimal(ByVal column As Column) As Boolean
		IsColumnNumericOrDecimal = column.SQLDatatype.StartsWith("decimal") Or column.SQLDatatype.StartsWith("numeric")
	End Function	
	

	Public Shared Sub MakeParameterFromParam(ByVal writer As TextWriter, ByVal param As Parameter, ByVal paramName As String)
	
		MakeParameterWithPrefixFromParam(writer, param, paramName, String.Empty)
	
	End Sub

	Public Shared Sub MakeParameterWithPrefixFromParam(ByVal writer As TextWriter, ByVal param As Parameter, ByVal paramName As String, ByVal prefix As String)

		MakeParameterWithPrefix(writer, param, paramName, param.ParamType.ToString(), prefix)

	End Sub

	Public Shared Sub MakeParameter(ByVal writer As TextWriter, ByVal param As Parameter, ByVal paramName As String, ByVal direction As String)

		MakeParameterWithPrefix(writer, param, paramName, direction, String.Empty)

	End Sub

	Public Shared Sub MakeParameterWithPrefix(ByVal writer As TextWriter, ByVal param As Parameter, ByVal paramName As String, ByVal direction As String, ByVal prefix As String)
	
		writer.WriteLine("' parameter for {0} column", param)		
		writer.WriteLine("{0} = New SqlParameter(""@{1}"", {2}, {3})", paramName, param.Name, param.AdoNetMapping.SqlDbType, param.Length )
		
		If IsParamNumericOrDecimal( param ) Then
			writer.WriteLine("{0}.Precision = {1}", paramName, param.Precision)
			writer.WriteLine("{0}.Scale = {1}", paramName, param.Scale)
		End If
		
		writer.Write("{0}.Direction = ParameterDirection.{1}", paramName, direction)
		If direction <> "Output" Then
			writer.WriteLine()
			writer.Write("{0}.Value = {1}{2}{3}", paramName, prefix, param.GetPrefix("VB.NET"), param.Name)
		End If

	End Sub
	
	Public Shared Function IsParamNumericOrDecimal(ByVal param As Parameter) As Boolean
		IsParamNumericOrDecimal = param.SQLDatatype.StartsWith("decimal") Or param.SQLDatatype.StartsWith("numeric")
	End Function

End Class
