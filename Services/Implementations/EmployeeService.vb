Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class EmployeeService
    Implements IEmployeeService

    Private ReadOnly _db As IDbConnection
    Public Sub New()
        _db = New SqlConnection(ConfigurationManager.ConnectionStrings("EmployeeDBConnection").ConnectionString)
    End Sub
    Public Async Function AddAsync(dataObject As EmployeeModel) As Task Implements IAddRepository(Of EmployeeModel).AddAsync
        Await _db.ExecuteAsync("INSERT INTO EmployeeTable(Name, Age, Salary, Address, BirthDate, IsActive)
        VALUES(@Name, @Age, @Salary, @Address, @BirthDate, @IsActive)", New With {
            .Name = dataObject.Name,
            .Age = dataObject.Age,
            .Salary = dataObject.Salary,
            .Address = dataObject.Address,
            .BirthDate = dataObject.BirthDate,
            .IsActive = dataObject.IsActive
        })
    End Function

    Public Async Function FindByIdAsync(id As Integer) As Task(Of EmployeeModel) Implements IFindByIdRepository(Of EmployeeModel).FindByIdAsync
        Return Await _db.QueryFirstOrDefaultAsync(Of EmployeeModel)("SELECT * FROM EmployeeTable WHERE Id = @Id", New With {.Id = id})
    End Function

    Public Async Function FetchAllAsync() As Task(Of IEnumerable(Of EmployeeModel)) Implements IFetchAllRepository(Of EmployeeModel).FetchAllAsync
        Return Await _db.QueryAsync(Of EmployeeModel)("SELECT * FROM EmployeeTable")
    End Function

    Public Async Function UpdateAsync(dataObject As EmployeeModel, id As Integer) As Task Implements IUpdateRepository(Of EmployeeModel).UpdateAsync
        Await _db.ExecuteAsync("UPDATE EmployeeTable SET Name = @Name, Age = @Age, Salary = @Salary, Address = @Address, BirthDate = @BirthDate,
        IsActive = @IsActive", New With {
            .Name = dataObject.Name,
            .Age = dataObject.Age,
            .Salary = dataObject.Salary,
            .Address = dataObject.Address,
            .BirthDate = dataObject.BirthDate,
            .IsActive = dataObject.IsActive
        })
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task Implements IDeleteRepository(Of EmployeeModel).DeleteAsync
        Await _db.ExecuteAsync("DELETE FROM EmployeeTable WHERE Id = @Id", New With {.Id = id})
    End Function
End Class
