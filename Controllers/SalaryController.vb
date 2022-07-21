Imports System.Web.Mvc

Namespace Controllers
    Public Class SalaryController
        Inherits Controller

        Private ReadOnly _salaryService As ISalaryService

        Public Sub New(salaryService As ISalaryService)
            _salaryService = salaryService
        End Sub

        Async Function IndexAsync() As Threading.Tasks.Task(Of ActionResult)
            Dim salaryModels As IEnumerable(Of SalaryModel) = Await _salaryService.FetchAllSalariesAsync()
            Dim salaryViewModels = salaryModels.Select(Function(model) New SalaryViewModel() With {
                .BaseNet = model.BaseNet,
                .DateCreated = model.DateCreated,
                .Id = model.Id,
                .Name = model.Name
            })
            Return View(salaryViewModels)
        End Function
    End Class
End Namespace