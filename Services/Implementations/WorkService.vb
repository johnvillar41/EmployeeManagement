Imports System.Threading.Tasks

Public Class WorkService
    Inherits Repository(Of WorkModel)
    Implements IWorkService

    Public Async Function AddWorkAsync(work As WorkModel) As Task Implements IWorkService.AddWorkAsync
        Await AddAsync(work)
    End Function

    Public Async Function DeleteWorkAsync(workId As Integer) As Task Implements IWorkService.DeleteWorkAsync
        Await DeleteAsync(workId)
    End Function

    Public Async Function UpdateWorkAsync(work As WorkModel) As Task Implements IWorkService.UpdateWorkAsync
        Await UpdateAsync(work)
    End Function

    Public Async Function FetchWorksAsync(employeeId As Integer) As Task(Of IEnumerable(Of WorkModel)) Implements IWorkService.FetchWorksAsync
        Return Await SelectQueryAsync(Of WorkModel)("SELECT * FROM " & GetTableName & " WHERE EmployeeId = @EmployeeId", New With {.EmployeeId = employeeId})
    End Function
End Class
