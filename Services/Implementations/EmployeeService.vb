Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class EmployeeService
    Implements IEmployeeService

    Private ReadOnly _db As IDbConnection
    Public Sub New()
        _db = New SqlConnection(ConfigurationManager.ConnectionStrings("EmployeeDBConnection").ConnectionString)
    End Sub
    Public Async Function AddNewEmployeeAsync(employee As EmployeeModel) As Task Implements IEmployeeService.AddNewEmployeeAsync
        Await _db.ExecuteAsync("INSERT INTO EmployeeTable(Name, Age, Salary, Address, BirthDate, IsActive)
        VALUES(@Name, @Age, @Salary, @Address, @BirthDate, @IsActive)", New With {
            .Name = employee.Name,
            .Age = employee.Age,
            .Address = employee.Address,
            .BirthDate = employee.BirthDate,
            .IsActive = employee.IsActive
        })
    End Function

    Public Async Function DeleteEmployeeAsync(employeeId As Integer) As Task Implements IEmployeeService.DeleteEmployeeAsync
        Await _db.ExecuteAsync("DELETE FROM EmployeeTable WHERE Id = @Id", New With {.Id = employeeId})
    End Function

    Public Function UpdateEmployeeAsync(employeeId As Integer, employee As EmployeeModel) As Task Implements IEmployeeService.UpdateEmployeeAsync
        Throw New NotImplementedException()
    End Function

    Public Async Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel)) Implements IEmployeeService.ViewAllEmployeesAsync
        Return Await _db.QueryAsync(Of EmployeeModel)("SELECT * FROM EmployeeTable")
    End Function
End Class
