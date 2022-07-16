Imports System.Threading.Tasks

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly _employeeService As IEmployeeService
    Public Sub New(employeeservice As IEmployeeService)
        _employeeService = employeeservice
    End Sub

    Async Function Index() As Task(Of ActionResult)
        Dim employees = Await _employeeService.ViewAllEmployeesAsync()
        Return View(employees)
    End Function

    Async Function Delete(employeeId As Integer) As Task(Of ActionResult)
        Await _employeeService.DeleteEmployeeAsync(employeeId)
        Return RedirectToAction(NameOf(Index))
    End Function

    Async Function Create(employee As EmployeeModel) As Task(Of ActionResult)
        Await _employeeService.AddNewEmployeeAsync(employee)
        Return RedirectToAction(NameOf(Index))
    End Function
    Function CreateForm() As ActionResult
        Return View("CreateForm")
    End Function
End Class
