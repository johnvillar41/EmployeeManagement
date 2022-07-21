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
    End Class
End Namespace