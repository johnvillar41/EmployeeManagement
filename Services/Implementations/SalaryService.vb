Imports System.Threading.Tasks

Public Class SalaryService
    Inherits Repository(Of SalaryModel)
    Implements ISalaryService

    Public Async Function FetchAllSalariesAsync() As Task(Of IEnumerable(Of SalaryModel)) Implements ISalaryService.FetchAllSalariesAsync
        Return Await FetchAllAsync()
    End Function

    Public Async Function CreateSalaryAsync(salaryModel As SalaryModel) As Task Implements ISalaryService.CreateSalaryAsync
        Await AddAsync(salaryModel)
    End Function

    Public Function UpdateSalaryAsync(salaryModel As SalaryModel) As Task Implements ISalaryService.UpdateSalaryAsync
        Throw New NotImplementedException()
    End Function

    Public Async Function FindSalaryAsync(salaryId As Integer?) As Task(Of SalaryModel) Implements ISalaryService.FindSalaryAsync
        Return Await FindByIdAsync(salaryId)
    End Function

    Public Async Function DeleteSalaryAsync(salaryId As Integer?) As Task Implements ISalaryService.DeleteSalaryAsync
        Await DeleteAsync(salaryId)
    End Function
End Class
