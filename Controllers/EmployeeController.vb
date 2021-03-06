Imports System.Threading.Tasks
Imports EmployeeManagement.EmployeeSalaryViewModel

Public Class EmployeeController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly _employeeService As IEmployeeService
    Private ReadOnly _mapper As IAutoMapper
    Public Sub New(employeeservice As IEmployeeService, mapper As IAutoMapper)
        _employeeService = employeeservice
        _mapper = mapper
    End Sub

    Async Function Index() As Task(Of ActionResult)
        Dim employees = Await _employeeService.ViewAllEmployeesAsync()
        Dim employeeViewModels = employees.Select(Function(model) _mapper.MapObjects(Of EmployeeViewModel, EmployeeModel)(New EmployeeViewModel(), model))

        Return View(employeeViewModels)
    End Function

    Async Function Delete(employeeId As Integer) As Task(Of ActionResult)
        Await _employeeService.DeleteEmployeeAsync(employeeId)
        Return RedirectToAction(NameOf(Index))
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Async Function Create(employee As EmployeeViewModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            Dim employeeModel = _mapper.MapObjects(Of EmployeeModel, EmployeeViewModel)(New EmployeeModel(), employee)
            Await _employeeService.CreateNewEmployeeAsync(employeeModel)
            Return RedirectToAction(NameOf(Index))
        End If

        Return RedirectToAction(NameOf(CreateForm))
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Async Function Update(employee As EmployeeViewModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            Dim employeeModel = _mapper.MapObjects(Of EmployeeModel, EmployeeViewModel)(New EmployeeModel(), employee)
            Await _employeeService.ModifyEmployeeAsync(employeeModel)
            Return RedirectToAction(NameOf(Index))
        End If

        Return View(NameOf(UpdateForm), employee)
    End Function

    Async Function UpdateForm(employeeId As Integer, errorMessage As String) As Task(Of ActionResult)
        If errorMessage IsNot Nothing Then
            ViewBag.ErrorMessage = errorMessage
        Else
            ViewBag.ErrorMessage = Nothing
        End If

        Dim employeeDetail As EmployeeModel = Await _employeeService.FindEmployeeAsync(employeeId)
        Dim employeeViewModel As EmployeeViewModel = _mapper.MapObjects(Of EmployeeViewModel, EmployeeModel)(New EmployeeViewModel(), employeeDetail)
        Dim salaryTypes = Await _employeeService.FetchSalaryTypes()
        employeeViewModel.SalaryTypes = salaryTypes.Select(Function(model) _mapper.MapObjects(Of SalaryViewModel, SalaryModel)(New SalaryViewModel, model))

        Dim employeeSalary As EmployeeSalaryModel = Nothing
        Try
            employeeSalary = Await _employeeService.FindEmployeeSalaryAsync(employeeId)
        Catch ex As SalaryException
            My.Application.Log.WriteEntry(ex.Message)
            employeeSalary = New EmployeeSalaryModel
        End Try

        Dim salary As SalaryModel = Await _employeeService.FindSalaryAsync(employeeSalary.SalaryId)
        If salary Is Nothing Then
            salary = New SalaryModel()
        End If

        Dim employeeSalaryViewModel As EmployeeSalaryViewModel = _mapper.MapObjects(Of EmployeeSalaryViewModel, EmployeeSalaryModel)(New EmployeeSalaryViewModel(), employeeSalary)
        employeeSalaryViewModel.SalaryId = salary.Id

        Dim employeeUpdateViewModel As EmployeeUpdateViewModel = New EmployeeUpdateViewModel() With {
            .EmployeeViewModel = employeeViewModel,
            .EmployeeSalaryViewModel = employeeSalaryViewModel,
            .SalaryViewModel = _mapper.MapObjects(Of SalaryViewModel, SalaryModel)(New SalaryViewModel(), salary)
        }
        Return View(NameOf(UpdateForm), employeeUpdateViewModel)
    End Function

    Async Function CreateForm() As Task(Of ActionResult)
        Dim salaryTypes As IEnumerable(Of SalaryModel) = Await _employeeService.FetchSalaryTypes()
        Dim employeeViewModel As EmployeeViewModel = New EmployeeViewModel() With {
            .SalaryTypes = salaryTypes.Select(Function(model) _mapper.MapObjects(Of SalaryViewModel, SalaryModel)(New SalaryViewModel(), model))
        }
        Return View(employeeViewModel)
    End Function

    Async Function Detail(employeeId As Integer) As Task(Of ActionResult)
        Dim employeeDetail As EmployeeModel = Await _employeeService.FindEmployeeAsync(employeeId)
        Dim employeeNumberWork As Integer = Await _employeeService.FetchNumberOfWorksAsync(employeeId)
        Dim employeeDetailViewModel As EmployeeDetailViewModel = _mapper.MapObjects(Of EmployeeDetailViewModel, EmployeeModel)(New EmployeeDetailViewModel(), employeeDetail)
        employeeDetailViewModel.NumberOfWork = employeeNumberWork
        Return View(NameOf(Detail), employeeDetailViewModel)
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Async Function AddEmployeeSalary(employeeSalary As EmployeeSalaryViewModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            Dim employeeSalaryModel = _mapper.MapObjects(Of EmployeeSalaryModel, EmployeeSalaryViewModel)(New EmployeeSalaryModel(), employeeSalary)
            Dim salaryModel As SalaryModel = Await _employeeService.FindSalaryAsync(employeeSalaryModel.SalaryId)
            employeeSalaryModel.Net = salaryModel.BaseNet - Math.Abs(employeeSalaryModel.Allowance - employeeSalaryModel.Deductions)
            employeeSalaryModel.Net -= (employeeSalaryModel.NumberOfLate * 20 + employeeSalaryModel.NumberOfAbsent * 100)
            Try
                Await _employeeService.AddEmployeeSalaryAsync(employeeSalaryModel)
            Catch ex As SalaryException
                Return RedirectToAction(NameOf(UpdateForm), New With {.employeeId = employeeSalary.EmployeeId, .errorMessage = ex.Message})
            End Try
        End If

        Return RedirectToAction(NameOf(UpdateForm), New With {.employeeId = employeeSalary.EmployeeId})
    End Function
End Class
