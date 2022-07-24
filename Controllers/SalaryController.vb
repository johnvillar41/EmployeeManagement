Imports System.Threading.Tasks
Imports System.Web.Mvc

Namespace Controllers
    Public Class SalaryController
        Inherits Controller

        Private ReadOnly _salaryService As ISalaryService
        Private ReadOnly _mapper As IAutoMapper

        Public Sub New(salaryService As ISalaryService, mapper As IAutoMapper)
            _salaryService = salaryService
            _mapper = mapper
        End Sub

        Async Function Index() As Task(Of ActionResult)
            Dim salaryModels As IEnumerable(Of SalaryModel) = Await _salaryService.FetchAllSalariesAsync()
            Dim salaryViewModels = salaryModels.Select(Function(model) _mapper.MapObjects(Of SalaryViewModel, SalaryModel)(New SalaryViewModel(), model))
            Return View(salaryViewModels)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Async Function Create(salary As SalaryViewModel) As Task(Of ActionResult)
            If ModelState.IsValid Then
                Dim salaryModel = _mapper.MapObjects(Of SalaryModel, SalaryViewModel)(New SalaryModel(), salary)
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
            Dim salaryViewModel As SalaryViewModel = _mapper.MapObjects(Of SalaryViewModel, SalaryModel)(New SalaryViewModel(), salaryModel)
            Return View(salaryViewModel)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Async Function Update(salary As SalaryViewModel) As Task(Of ActionResult)
            If ModelState.IsValid Then
                Dim salaryModel = _mapper.MapObjects(Of SalaryModel, SalaryViewModel)(New SalaryModel(), salary)
                Await _salaryService.UpdateSalaryAsync(salaryModel)
                Return RedirectToAction(NameOf(Index))
            End If

            Return RedirectToAction(NameOf(UpdateForm))
        End Function
    End Class
End Namespace