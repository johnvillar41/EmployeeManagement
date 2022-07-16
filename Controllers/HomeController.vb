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

End Class
