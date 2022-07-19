Public Interface IWorkService
    Function AddWorkAsync(employeeId As Integer, work As WorkModel)
    Function DeleteWorkAsync(workId As Integer)
    Function UpdateWorkAsync(workId As Integer, work As WorkModel)
    Function FetchWorksAsync(employeeId As Integer)

End Interface
