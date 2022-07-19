Imports System.Threading.Tasks
Imports System.Web.Mvc

Namespace Controllers
    Public Class WorkController
        Inherits Controller
        Private ReadOnly _workService As IWorkService
        Public Sub New(workService As IWorkService)
            _workService = workService
        End Sub

        Async Function Index(employeeId As Integer) As Task(Of ActionResult)
            Dim workLoads = Await _workService.FetchWorksAsync(employeeId)
            Return View(workLoads)
        End Function

    End Class
End Namespace