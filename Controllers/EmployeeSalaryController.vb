Imports System.Threading.Tasks
Imports System.Web.Mvc

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
                .Month = model.Month,
                .Year = model.Year
            })
            Return View(employeeSalaryViewModels)
        End Function
    End Class
End Namespace