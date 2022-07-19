Imports System.Threading.Tasks
Imports System.Web.Mvc

Namespace Controllers
    Public Class WorkController
        Inherits Controller
        Private ReadOnly _workService As IWorkService
        Public Sub New(workService As IWorkService)
            _workService = workService
        End Sub

        Async Function Index(employeeId? As Integer) As Task(Of ActionResult)
            If employeeId Is Nothing Then
                Return RedirectToAction("Index", "Home")
            End If

            Dim workLoads = Await _workService.FetchWorksAsync(employeeId)
            Dim workLoadViewModels = workLoads.Select(Of WorkViewModel)(Function(model) New WorkViewModel With {
                .Id = model.Id,
                .Description = model.Description,
                .EmployeeId = model.EmployeeId,
                .Title = model.Title
            })
            Dim displayWorkViewModel = New DisplayWorkViewModel() With {
                .WorkViewModels = workLoadViewModels,
                .EmployeeId = employeeId
            }
            Return View(displayWorkViewModel)
        End Function

        Async Function Delete(workId As Integer, employeeId As Integer) As Task(Of ActionResult)
            Await _workService.DeleteWorkAsync(workId)
            Return RedirectToAction(NameOf(Index), New With {employeeId})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Async Function Create(work As WorkModel) As Task(Of ActionResult)
            Await _workService.AddWorkAsync(work)
            Return RedirectToAction(NameOf(Index), New With {work.EmployeeId})
        End Function

        Function CreateForm(employeeId As Integer) As ActionResult
            Dim work = New WorkViewModel With {
                .EmployeeId = employeeId
            }
            Return View(NameOf(CreateForm), work)
        End Function
    End Class
End Namespace