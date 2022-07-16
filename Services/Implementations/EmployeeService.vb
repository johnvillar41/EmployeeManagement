Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class EmployeeService
    Implements IEmployeeService

    Private ReadOnly _repository As IRepository(Of EmployeeModel)
    Public Sub New(repository As IRepository(Of EmployeeModel))
        _repository = repository
    End Sub
    Public Async Function CreateNewEmployeeAsync(employee As EmployeeModel) As Task Implements IEmployeeService.CreateNewEmployeeAsync
        Await _repository.AddAsync(employee, "INSERT INTO EmployeeTable(Name, Age, Salary, Address, BirthDate, IsActive)
        VALUES(@Name, @Age, @Salary, @Address, @BirthDate, @IsActive)")
    End Function

    Public Async Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel)) Implements IEmployeeService.ViewAllEmployeesAsync
        Return Await _repository.FetchAllAsync("SELECT * FROM EmployeeTable")
    End Function

    Public Async Function FindEmployeeAsync(id As Integer) As Task(Of EmployeeModel) Implements IEmployeeService.FindEmployeeAsync
        Return Await _repository.FindByIdAsync(id, "SELECT * FROM EmployeeTable WHERE Id = @id")
    End Function

    Private Async Function IEmployeeService_DeleteAsync(id As Integer) As Task Implements IEmployeeService.DeleteAsync
        Await _repository.DeleteAsync(id, "DELETE FROM EmployeeTable WHERE Id = @id")
    End Function
End Class
