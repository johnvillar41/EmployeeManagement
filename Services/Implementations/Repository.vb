Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class Repository(Of T)
    Implements IRepository(Of T)


    Private ReadOnly _db As IDbConnection
    Public Sub New()
        _db = New SqlConnection(ConfigurationManager.ConnectionStrings("EmployeeDBConnection").ConnectionString)
    End Sub

    Public Overridable ReadOnly Property GetTableName As String Implements IRepository(Of T).GetTableName
        Get
            Dim className As String = GetType(T).Name
            Dim tableName = className.Replace("Model", "Table")
            Return tableName
        End Get
    End Property

    Public Async Function AddAsync(dataObject As T) As Task Implements IAddRepository(Of T).AddAsync
        Dim tupleValue = BuildInsertQueryString(dataObject)
        Dim tableString = tupleValue.Item1
        Dim valueString = tupleValue.Item2

        Dim sqlString As String = "INSERT INTO " & GetTableName & "(" & tableString & ")
        VALUES(" & valueString & ")"

        Await _db.ExecuteAsync(sqlString, dataObject)
    End Function

    Public Async Function FindByIdAsync(id As Integer) As Task(Of T) Implements IFindByIdRepository(Of T).FindByIdAsync
        Return Await _db.QueryFirstOrDefaultAsync(Of T)("SELECT * FROM " & GetTableName & " WHERE Id = @id", New With {id})
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task Implements IDeleteRepository(Of T).DeleteAsync
        Await _db.ExecuteAsync("DELETE FROM " & GetTableName & " WHERE Id = @id", New With {id})
    End Function

    Public Async Function FetchAllAsync() As Task(Of IEnumerable(Of T)) Implements IFetchAllRepository(Of T).FetchAllAsync
        Return Await _db.QueryAsync(Of T)("SELECT * FROM " & GetTableName)
    End Function

    Public Async Function UpdateAsync(dataObject As T) As Task Implements IUpdateRepository(Of T).UpdateAsync
        Dim queryString = BuildUpdateQueryString(dataObject)
        Dim sqlString As String = "UPDATE " & GetTableName & " SET " & queryString & " WHERE Id = @Id"
        Await _db.ExecuteAsync(sqlString, dataObject)
    End Function

    Public Async Function SelectQueryAsync(Of T)(queryString As String, objectParams As Object) As Task(Of IEnumerable(Of T)) Implements IQueryRepository.SelectQueryAsync
        Return Await _db.QueryAsync(Of T)(queryString, objectParams)
    End Function

    Private Function BuildUpdateQueryString(dataObject As T) As String
        Dim queryBuilder As New StringBuilder
        Dim m_property = dataObject.GetType().GetProperties()
        Dim propertyCount = dataObject.GetType().GetProperties().Count

        For i As Integer = 1 To propertyCount
            If i >= propertyCount Then
                Exit For
            End If

            If m_property(i).GetValue(dataObject) IsNot Nothing Then
                queryBuilder.Append(m_property(i).Name & "=")
                queryBuilder.Append("@" & m_property(i).Name)
                If i + 1 < propertyCount Then
                    If (m_property(i + 1)).GetValue(dataObject) IsNot Nothing Then
                        queryBuilder.Append(",")
                    End If
                End If
            End If

        Next
        Dim queryString = queryBuilder.ToString()
        Return queryString
    End Function

    Private Function BuildInsertQueryString(dataObject As T) As (String, String)
        Dim tableBuilder As New StringBuilder
        Dim valueBuilder As New StringBuilder

        Dim m_property = dataObject.GetType().GetProperties()
        Dim propertyCount = dataObject.GetType().GetProperties().Count

        For i As Integer = 1 To propertyCount
            If i >= propertyCount Then
                Exit For
            End If

            If m_property(i).GetValue(dataObject) IsNot Nothing Then
                tableBuilder.Append(m_property(i).Name)
                valueBuilder.Append("@" & m_property(i).Name)
                If i + 1 < propertyCount Then
                    If (m_property(i + 1)).GetValue(dataObject) IsNot Nothing Then
                        tableBuilder.Append(",")
                        valueBuilder.Append(",")
                    End If
                End If
            End If
        Next

        Dim tableString As String = tableBuilder.ToString()
        Dim valueString As String = valueBuilder.ToString()

        Dim tupleString = (tableString, valueString)
        Return tupleString
    End Function

End Class
