Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class EmployeeService
    Inherits Repository(Of EmployeeModel)
    Implements IEmployeeService

    Public Overrides ReadOnly Property GetTableName As String
        Get
            Return "EmployeeTable"
        End Get
    End Property

    Public Async Function CreateNewEmployeeAsync(employee As EmployeeModel) As Task Implements IEmployeeService.CreateNewEmployeeAsync
        Await AddAsync(employee, "EmployeeTable")
    End Function

    Public Async Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel)) Implements IEmployeeService.ViewAllEmployeesAsync
        Return Await _repository.FetchAllAsync("EmployeeTable")
    End Function

    Public Async Function FindEmployeeAsync(id As Integer) As Task(Of EmployeeModel) Implements IEmployeeService.FindEmployeeAsync
        Return Await _repository.FindByIdAsync(id, "EmployeeTable")
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task Implements IEmployeeService.DeleteAsync
        Await _repository.DeleteAsync(id, "EmployeeTable")
    End Function
End Class
