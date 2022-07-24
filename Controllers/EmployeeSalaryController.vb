Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports EmployeeManagement.EmployeeSalaryViewModel

Namespace Controllers
    Public Class EmployeeSalaryController
        Inherits Controller

        Private ReadOnly _employeeSalaryService As IEmployeeSalaryService
        Private ReadOnly _autoMapper As IAutoMapper

        Public Sub New(employeeSalaryService As IEmployeeSalaryService, autoMapper As IAutoMapper)
            _employeeSalaryService = employeeSalaryService
            _autoMapper = autoMapper
        End Sub

        Async Function Index(employeeId? As Integer) As Task(Of ActionResult)
            If employeeId Is Nothing Then
                Return RedirectToAction("../Employee/Index")
            End If

            Dim employeeSalaries = Await _employeeSalaryService.FetchAllEmployeeSalaryAsync(employeeId)
            Dim employeeSalaryViewModels As IEnumerable(Of DisplayEmployeeSalaryViewModel) = MapToDisplayEmployeeSalary(employeeSalaries)
            Return View(employeeSalaryViewModels)
        End Function

        Async Function Sort(year As Integer, employeeId As Integer) As Task(Of ActionResult)
            Dim employeeSalaries = Await _employeeSalaryService.FetchAllSalaryGivenAYearAsync(year, employeeId)
            Dim employeeSalaryViewModels As IEnumerable(Of DisplayEmployeeSalaryViewModel) = MapToDisplayEmployeeSalary(employeeSalaries)

            Return View(NameOf(Index), employeeSalaryViewModels)
        End Function

        Private Function MapToDisplayEmployeeSalary(employeeSalaries As IEnumerable(Of EmployeeSalaryModel)) As IEnumerable(Of DisplayEmployeeSalaryViewModel)
            Return employeeSalaries.Select(Function(model) _autoMapper.MapObjects(Of DisplayEmployeeSalaryViewModel, EmployeeSalaryModel)(New DisplayEmployeeSalaryViewModel(), model))
        End Function

    End Class
End Namespace