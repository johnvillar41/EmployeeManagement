Imports System.Threading.Tasks

Public Interface IWorkService
    Function AddWorkAsync(work As WorkModel) As Task
    Function DeleteWorkAsync(workId As Integer) As Task
    Function UpdateWorkAsync(work As WorkModel) As Task
    Function FetchWorksAsync(employeeId As Integer) As Task

End Interface
