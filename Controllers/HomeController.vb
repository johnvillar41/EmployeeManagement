Imports System.Threading.Tasks

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly _employeeService As IEmployeeService
    Public Sub New(employeeservice As IEmployeeService)
        _employeeService = employeeservice
    End Sub

    Async Function Index() As Task(Of ActionResult)
        Dim employees = Await _employeeService.ViewAllEmployeesAsync()
        Dim employeeViewModels = employees.Select(Of EmployeeViewModel)(Function(model) New EmployeeViewModel() With {
            .Id = model.Id,
            .Name = model.Name,
            .Age = model.Age,
            .Salary = model.Salary,
            .Address = model.Address,
            .BirthDate = model.BirthDate,
            .IsActive = model.IsActive
        })
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
            Dim employeeModel = New EmployeeModel() With {
                .Address = employee.Address,
                .Age = employee.Age,
                .BirthDate = employee.BirthDate,
                .Id = employee.Id,
                .IsActive = employee.IsActive,
                .Name = employee.Name,
                .Salary = employee.Salary,
                .WorkLoad = Nothing
            }
            Await _employeeService.CreateNewEmployeeAsync(employeeModel)
            Return RedirectToAction(NameOf(Index))
        End If

        Return RedirectToAction(NameOf(CreateForm))
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Async Function Update(employee As EmployeeModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            Dim employeeModel = New EmployeeModel() With {
                .Address = employee.Address,
                .Age = employee.Age,
                .BirthDate = employee.BirthDate,
                .Id = employee.Id,
                .IsActive = employee.IsActive,
                .Name = employee.Name,
                .Salary = employee.Salary,
                .WorkLoad = Nothing
            }
            Await _employeeService.ModifyEmployeeAsync(employeeModel)
            Return RedirectToAction(NameOf(Index))
        End If

        Return View(NameOf(UpdateForm), employee)
    End Function

    Async Function UpdateForm(employeeId As Integer) As Task(Of ActionResult)
        Dim employeeDetail As EmployeeModel = Await _employeeService.FindEmployeeAsync(employeeId)
        Dim employeeDetailViewModel As EmployeeViewModel = New EmployeeViewModel() With {
            .Id = employeeDetail.Id,
            .Name = employeeDetail.Name,
            .Age = employeeDetail.Age,
            .Salary = employeeDetail.Salary,
            .Address = employeeDetail.Address,
            .BirthDate = employeeDetail.BirthDate,
            .IsActive = employeeDetail.IsActive
        }
        Return View(NameOf(UpdateForm), employeeDetailViewModel)
    End Function

    Function CreateForm() As ActionResult
        Return View(NameOf(CreateForm))
    End Function

    Async Function Detail(employeeId As Integer) As Task(Of ActionResult)
        Dim employeeDetail As EmployeeModel = Await _employeeService.FindEmployeeAsync(employeeId)
        Dim employeeDetailViewModel As EmployeeViewModel = New EmployeeViewModel() With {
            .Id = employeeDetail.Id,
            .Name = employeeDetail.Name,
            .Age = employeeDetail.Age,
            .Salary = employeeDetail.Salary,
            .Address = employeeDetail.Address,
            .BirthDate = employeeDetail.BirthDate,
            .IsActive = employeeDetail.IsActive
        }
        Return View(NameOf(Detail), employeeDetailViewModel)
    End Function
End Class
