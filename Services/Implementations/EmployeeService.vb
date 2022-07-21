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

    Private ReadOnly _workRepo As IRepository(Of WorkModel)
    Private ReadOnly _salaryRepo As IRepository(Of SalaryModel)
    Public Sub New(
                  workRepo As IRepository(Of WorkModel),
                  salaryRepo As IRepository(Of SalaryModel))
        _workRepo = workRepo
        _salaryRepo = salaryRepo
    End Sub

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

    Public Async Function ModifyEmployeeAsync(employee As EmployeeModel) As Task Implements IEmployeeService.ModifyEmployeeAsync
        Await UpdateAsync(employee)
    End Function

    Public Async Function FetchNumberOfWorksAsync(employeeId As Integer) As Task(Of Integer) Implements IEmployeeService.FetchNumberOfWorksAsync
        Dim results = Await _workRepo.SelectQueryAsync(Of Integer)("SELECT COUNT(*) FROM WorkTable WHERE EmployeeId = @EmployeeId", New With {.EmployeeId = employeeId})
        Return results.FirstOrDefault()
    End Function

    Public Async Function FindEmployeeSalaryAsync(employeeId As Integer) As Task(Of EmployeeSalaryModel) Implements IEmployeeService.FindEmployeeSalaryAsync
        Dim salary = Await _salaryRepo.SelectQueryAsync(Of EmployeeSalaryModel)("SELECT * FROM EmployeeSalaryTable WHERE EmployeeId = @EmployeeId", New With {.EmployeeId = employeeId})
        Return salary.FirstOrDefault()
    End Function

    Public Async Function FindSalaryAsync(salaryId As Integer) As Task(Of SalaryModel) Implements IEmployeeService.FindSalaryAsync
        Dim salary = Await _salaryRepo.SelectQueryAsync(Of SalaryModel)("SELECT * FROM SalaryTable WHERE Id = @Id", New With {.Id = salaryId})
        Return salary.FirstOrDefault()
    End Function
End Class
