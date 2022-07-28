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

        Async Function Index(employeeId? As Integer, year? As Integer) As Task(Of ActionResult)
            If employeeId Is Nothing Then
                Return RedirectToAction("../Employee/Index")
            End If

            If year IsNot Nothing Then
                Dim _employeeSalaries = Await _employeeSalaryService.FetchAllSalaryGivenAYearAsync(year, employeeId)
                Dim _employeeSalaryViewModels As IEnumerable(Of DisplayEmployeeSalaryViewModel) = MapToDisplayEmployeeSalary(_employeeSalaries).OrderBy(Function(m) m.Year)

                Return View(_employeeSalaryViewModels)
            End If

            Dim employeeSalaries = Await _employeeSalaryService.FetchAllEmployeeSalaryAsync(employeeId)
            Dim employeeSalaryViewModels As IEnumerable(Of DisplayEmployeeSalaryViewModel) = MapToDisplayEmployeeSalary(employeeSalaries).OrderBy(Function(m) m.Year)
            Return View(employeeSalaryViewModels)
        End Function

        Async Function EmployeeSalaries() As Task(Of ActionResult)
            Dim employees As IEnumerable(Of EmployeeModel) = Await _employeeSalaryService.FetchAllEmployees()
            Dim employeeViewModels As IEnumerable(Of EmployeeViewModel) =
                employees.Select(Function(model) _autoMapper.MapObjects(Of EmployeeViewModel, EmployeeModel)(New EmployeeViewModel, model))
            Return View(employeeViewModels)
        End Function

        Function Sort(year As Integer, employeeId As Integer) As ActionResult
            Return RedirectToAction(NameOf(Index), New With {.employeeId = employeeId, .year = year})
        End Function

        Private Function MapToDisplayEmployeeSalary(employeeSalaries As IEnumerable(Of EmployeeSalaryModel)) As List(Of DisplayEmployeeSalaryViewModel)
            Return employeeSalaries.Select(Function(model) _autoMapper.MapObjects(Of DisplayEmployeeSalaryViewModel, EmployeeSalaryModel)(New DisplayEmployeeSalaryViewModel(), model)).ToList()
        End Function

    End Class
End Namespace