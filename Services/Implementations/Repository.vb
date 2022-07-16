Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class Repository(Of T)
    Implements IRepository(Of T)


    Private ReadOnly _db As IDbConnection
    Public Sub New()
        _db = New SqlConnection(ConfigurationManager.ConnectionStrings("EmployeeDBConnection").ConnectionString)
    End Sub

    Public Async Function AddAsync(dataObject As T, sqlQuery As String) As Task Implements IAddRepository(Of T).AddAsync
        Await _db.ExecuteAsync(sqlQuery, dataObject)
    End Function

    Public Async Function FindByIdAsync(id As Integer, tableName As String) As Task(Of T) Implements IFindByIdRepository(Of T).FindByIdAsync
        Return Await _db.QueryFirstOrDefaultAsync(Of T)("SELECT * FROM " & tableName & " WHERE Id = @id", New With {id})
    End Function

    Public Async Function DeleteAsync(id As Integer, tableName As String) As Task Implements IDeleteRepository(Of T).DeleteAsync
        Await _db.ExecuteAsync("DELETE FROM " & tableName & " WHERE Id = @id", New With {id})
    End Function

    Public Async Function FetchAllAsync(tableName As String) As Task(Of IEnumerable(Of T)) Implements IFetchAllRepository(Of T).FetchAllAsync
        Return Await _db.QueryAsync(Of T)("SELECT * FROM " & tableName)
    End Function

    Public Async Function UpdateAsync(dataObject As T, sqlQuery As String) As Task Implements IUpdateRepository(Of T).UpdateAsync
        Await _db.ExecuteAsync(sqlQuery, dataObject)
    End Function
End Class
