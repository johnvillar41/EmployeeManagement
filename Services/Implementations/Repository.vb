Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public MustInherit Class Repository(Of T)
    Implements IRepository(Of T)


    Private ReadOnly _db As IDbConnection
    Public Sub New()
        _db = New SqlConnection(ConfigurationManager.ConnectionStrings("EmployeeDBConnection").ConnectionString)
    End Sub

    Public MustOverride ReadOnly Property GetTableName() As String

    Public Async Function AddAsync(dataObject As T) As Task Implements IAddRepository(Of T).AddAsync
        Dim tupleValue = BuildInsertQueryString(dataObject)
        Dim valueString = tupleValue.Item1
        Dim tableString = tupleValue.Item2

        Dim sqlString As String = "INSERT INTO " & GetTableName() & "(" & tableString & ")
        VALUES(" & valueString & ")"

        Await _db.ExecuteAsync(sqlString, dataObject)
    End Function

    Public Async Function FindByIdAsync(id As Integer) As Task(Of T) Implements IFindByIdRepository(Of T).FindByIdAsync
        Return Await _db.QueryFirstOrDefaultAsync(Of T)("SELECT * FROM " & GetTableName() & " WHERE Id = @id", New With {id})
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task Implements IDeleteRepository(Of T).DeleteAsync
        Await _db.ExecuteAsync("DELETE FROM " & GetTableName() & " WHERE Id = @id", New With {id})
    End Function

    Public Async Function FetchAllAsync(tableName As String) As Task(Of IEnumerable(Of T)) Implements IFetchAllRepository(Of T).FetchAllAsync
        Return Await _db.QueryAsync(Of T)("SELECT * FROM " & tableName)
    End Function

    Public Async Function UpdateAsync(dataObject As T) As Task Implements IUpdateRepository(Of T).UpdateAsync
        Dim queryString = BuildUpdateQueryString(dataObject)

        Dim sqlString As String = "UPDATE " & GetTableName() & "SET " & queryString

        Await _db.ExecuteAsync("", dataObject)
    End Function

    Private Function BuildUpdateQueryString(dataObject As T) As String
        Dim queryBuilder As New StringBuilder
        Dim m_property = dataObject.GetType().GetProperties()
        Dim propertyCount = dataObject.GetType().GetProperties().Count
        Dim limit As Integer = propertyCount - 1

        For i As Integer = 1 To propertyCount
            If i >= propertyCount Then
                Exit For
            End If

            queryBuilder.Append(m_property(i).Name)
            queryBuilder.Append("@" & m_property(i).Name)

            If i + +1 >= propertyCount Then
                Exit For
            End If

            queryBuilder.Append(",")
        Next

        Return queryBuilder.ToString()
    End Function

    Private Function BuildInsertQueryString(dataObject As T) As (String, String)
        Dim tableBuilder As New StringBuilder
        Dim valueBuilder As New StringBuilder

        Dim m_property = dataObject.GetType().GetProperties()
        Dim propertyCount = dataObject.GetType().GetProperties().Count
        Dim limit As Integer = propertyCount - 1

        For i As Integer = 1 To propertyCount
            If i >= propertyCount Then
                Exit For
            End If

            tableBuilder.Append(m_property(i).Name)
            valueBuilder.Append("@" & m_property(i).Name)

            If i + +1 >= propertyCount Then
                Exit For
            End If

            tableBuilder.Append(",")
            valueBuilder.Append(",")
        Next

        Dim tableString As String = tableBuilder.ToString()
        Dim valueString As String = valueBuilder.ToString()

        Dim tupleString = (tableString, valueString)
        Return tupleString
    End Function



End Class
