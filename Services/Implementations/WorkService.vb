Public Class WorkService
    Inherits Repository(Of WorkModel)
    Implements IWorkService

    Public Overrides ReadOnly Property GetTableName As String
        Get
            Return "WorkTable"
        End Get
    End Property

    Public Function AddWorkAsync(employeeId As Integer, work As WorkModel) As Object Implements IWorkService.AddWorkAsync
        Throw New NotImplementedException()
    End Function

    Public Function DeleteWorkAsync(workId As Integer) As Object Implements IWorkService.DeleteWorkAsync
        Throw New NotImplementedException()
    End Function

    Public Function UpdateWorkAsync(workId As Integer, work As WorkModel) As Object Implements IWorkService.UpdateWorkAsync
        Throw New NotImplementedException()
    End Function

    Public Function FetchWorksAsync(employeeId As Integer) As Object Implements IWorkService.FetchWorksAsync
        Throw New NotImplementedException()
    End Function
End Class
