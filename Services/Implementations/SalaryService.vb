Imports System.Threading.Tasks

Public Class SalaryService
    Inherits Repository(Of SalaryModel)
    Implements ISalaryService

    Public Overrides ReadOnly Property GetTableName As String
        Get
            Return "SalaryTable"
        End Get
    End Property

    Public Async Function FetchAllSalariesAsync() As Task(Of IEnumerable(Of SalaryModel)) Implements ISalaryService.FetchAllSalariesAsync
        Return Await FetchAllAsync()
    End Function
End Class
