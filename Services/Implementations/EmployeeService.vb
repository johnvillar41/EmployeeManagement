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
        Await AddAsync(employee)
    End Function

    Public Async Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel)) Implements IEmployeeService.ViewAllEmployeesAsync
        Return Await FetchAllAsync()
    End Function

    Public Async Function FindEmployeeAsync(id As Integer) As Task(Of EmployeeModel) Implements IEmployeeService.FindEmployeeAsync
        Return Await FindByIdAsync(id)
    End Function

    Public Async Function DeleteEmployeeAsync(id As Integer) As Task Implements IEmployeeService.DeleteEmployeeAsync
        Await DeleteAsync(id)
    End Function
End Class
