Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports EmployeeManagement.EmployeeSalaryViewModel

Namespace Controllers
    Public Class EmployeeSalaryController
        Inherits Controller
        Private ReadOnly _employeeSalaryService As IEmployeeSalaryService

        Public Sub New(employeeSalaryService As IEmployeeSalaryService)
            _employeeSalaryService = employeeSalaryService
        End Sub

        Async Function Index(employeeId? As Integer) As Task(Of ActionResult)
            If employeeId Is Nothing Then
                Return RedirectToAction("../Employee/Index")
            End If

            Dim employeeSalaries = Await _employeeSalaryService.FetchAllEmployeeSalaryAsync(employeeId)
            Dim employeeSalaryViewModels = employeeSalaries.Select(Function(model) New DisplayEmployeeSalaryViewModel() With {
                .Id = model.Id,
                .EmployeeId = model.EmployeeId,
                .SalaryId = model.SalaryId,
                .Allowance = model.Allowance,
                .Net = model.Net,
                .NumberOfAbsent = model.NumberOfAbsent,
                .NumberOfLate = model.NumberOfLate,
                .Month = [Enum].Parse(GetType(MonthType), model.Month),
                .Year = model.Year
            })
            Return View(employeeSalaryViewModels)
        End Function

        Async Function Sort(year As Integer, employeeId As Integer) As Task(Of ActionResult)
            Dim employeeSalaries = Await _employeeSalaryService.FetchAllSalaryGivenAYearAsync(year, employeeId)
            Dim employeeSalaryViewModels = employeeSalaries.Select(Function(model) New DisplayEmployeeSalaryViewModel() With {
                .Id = model.Id,
                .EmployeeId = model.EmployeeId,
                .SalaryId = model.SalaryId,
                .Allowance = model.Allowance,
                .Net = model.Net,
                .NumberOfAbsent = model.NumberOfAbsent,
                .NumberOfLate = model.NumberOfLate,
                .Month = [Enum].Parse(GetType(MonthType), model.Month),
                .Year = model.Year
            })

            Return View(NameOf(Index), employeeSalaryViewModels)
        End Function
    End Class
End Namespace