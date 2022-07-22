Imports System.Threading.Tasks
Imports System.Web.Mvc

Namespace Controllers
    Public Class SalaryController
        Inherits Controller

        Private ReadOnly _salaryService As ISalaryService

        Public Sub New(salaryService As ISalaryService)
            _salaryService = salaryService
        End Sub

        Async Function Index() As Task(Of ActionResult)
            Dim salaryModels As IEnumerable(Of SalaryModel) = Await _salaryService.FetchAllSalariesAsync()
            Dim salaryViewModels = salaryModels.Select(Function(model) New SalaryViewModel() With {
                .BaseNet = model.BaseNet,
                .DateCreated = model.DateCreated,
                .Id = model.Id,
                .Name = model.Name
            })
            Return View(salaryViewModels)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Async Function Create(salary As SalaryViewModel) As Task(Of ActionResult)
            If ModelState.IsValid Then
                Dim salaryModel = New SalaryModel() With {
                    .BaseNet = salary.BaseNet,
                    .DateCreated = salary.DateCreated,
                    .Name = salary.Name
                }
                Await _salaryService.CreateSalaryAsync(salaryModel)
                Return RedirectToAction(NameOf(Index))
            End If

            Return RedirectToAction(NameOf(CreateForm))
        End Function

        Function CreateForm() As ActionResult
            Return View()
        End Function

        Async Function Delete(salaryId? As Integer) As Task(Of ActionResult)
            If salaryId Is Nothing Then
                Return RedirectToAction(NameOf(Index))
            End If

            Await _salaryService.DeleteSalaryAsync(salaryId)
            Return RedirectToAction(NameOf(Index))
        End Function

        Async Function UpdateForm(salaryId? As Integer) As Task(Of ActionResult)
            If salaryId Is Nothing Then
                Return RedirectToAction(NameOf(Index))
            End If

            Dim salaryModel As SalaryModel = Await _salaryService.FindSalaryAsync(salaryId)
            Dim salaryViewModel As SalaryViewModel = New SalaryViewModel() With {
                .BaseNet = salaryModel.BaseNet,
                .DateCreated = salaryModel.DateCreated,
                .Id = salaryModel.Id,
                .Name = salaryModel.Name
            }
            Return View(salaryViewModel)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Async Function Update(salary As SalaryViewModel) As Task(Of ActionResult)
            If ModelState.IsValid Then
                Dim salaryModel = New SalaryModel() With {
                    .BaseNet = salary.BaseNet,
                    .DateCreated = salary.DateCreated,
                    .Name = salary.Name,
                    .Id = salary.Id
                }
                Await _salaryService.UpdateSalaryAsync(salaryModel)
                Return RedirectToAction(NameOf(Index))
            End If

            Return RedirectToAction(NameOf(UpdateForm))
        End Function
    End Class
End Namespace