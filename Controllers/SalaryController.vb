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
        Async Function CreateOrUpdate(salary As SalaryViewModel, salaryId? As Integer) As Task(Of ActionResult)
            If ModelState.IsValid = False Then
                Return RedirectToAction(NameOf(CreateOrUpdateForm))
            End If

            Dim salaryModel = _mapper.MapObjects(Of SalaryModel, SalaryViewModel)(New SalaryModel(), salary)
            If salaryId Is Nothing Then
                Await _salaryService.CreateSalaryAsync(salaryModel)
            Else
                Await _salaryService.UpdateSalaryAsync(salaryModel)
            End If

            Return RedirectToAction(NameOf(Index))
        End Function

        Async Function CreateOrUpdateForm(salaryId? As Integer) As Task(Of ActionResult)
            Dim salaryViewModel As SalaryViewModel = Nothing
            If salaryId IsNot Nothing Then
                Dim salaryModel As SalaryModel = Await _salaryService.FindSalaryAsync(salaryId)
                salaryViewModel = _mapper.MapObjects(Of SalaryViewModel, SalaryModel)(New SalaryViewModel, salaryModel)
            End If

            Return View(salaryViewModel)
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

    End Class
End Namespace