Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class EmployeeService
    Inherits Repository(Of EmployeeModel)
    Implements IEmployeeService

    Private ReadOnly _workRepo As IRepository(Of WorkModel)
    Private ReadOnly _salaryRepo As IRepository(Of SalaryModel)
    Private ReadOnly _employeeSalaryRepo As IRepository(Of EmployeeSalaryModel)
    Public Sub New(
                  workRepo As IRepository(Of WorkModel),
                  salaryRepo As IRepository(Of SalaryModel),
                  employeeSalaryRepo As IRepository(Of EmployeeSalaryModel))
        _workRepo = workRepo
        _salaryRepo = salaryRepo
        _employeeSalaryRepo = employeeSalaryRepo
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
        Dim salary = Await _salaryRepo.SelectQueryAsync(Of SalaryModel)("SELECT * FROM SalaryTable WHERE Id = @Id ORDER BY Id DESC", New With {.Id = salaryId})
        Return salary.FirstOrDefault()
    End Function

    Public Async Function UpdateEmployeeSalaryAsync(employeeSalaryModel As EmployeeSalaryModel) As Task Implements IEmployeeService.UpdateEmployeeSalaryAsync
        Dim employeeSalary = Await _employeeSalaryRepo.FindByIdAsync(employeeSalaryModel.Id)

        If employeeSalary IsNot Nothing Then
            Await _employeeSalaryRepo.UpdateAsync(employeeSalaryModel)
            Return
        End If
        Await _employeeSalaryRepo.AddAsync(employeeSalaryModel)
    End Function

    Public Async Function FetchSalaryTypes() As Task(Of IEnumerable(Of SalaryModel)) Implements IEmployeeService.FetchSalaryTypes
        Return Await _employeeSalaryRepo.SelectQueryAsync(Of SalaryModel)("SELECT * FROM SalaryTable", Nothing)
    End Function

    Public Async Function AddEmployeeSalaryAsync(employeeSalaryModel As EmployeeSalaryModel) As Task Implements IEmployeeService.AddEmployeeSalaryAsync
        Dim employeeSalary = Await _employeeSalaryRepo.SelectQueryAsync(Of EmployeeSalaryModel)("SELECT * FROM EmployeeSalaryTable WHERE Month = @Month AND Year = @Year AND EmployeeId = @EmployeeId", New With {.Month = employeeSalaryModel.Month, .Year = employeeSalaryModel.Year, .EmployeeId = employeeSalaryModel.EmployeeId})
        If (employeeSalary.Count = 0) Then
            Await _employeeSalaryRepo.AddAsync(employeeSalaryModel)
            Return
        End If

        Throw New SalaryException($"Cannot add salary for month:{employeeSalaryModel.Month} and year:{employeeSalaryModel.Year} and employeeId:{employeeSalaryModel.EmployeeId}. Data already exist")
    End Function
End Class
