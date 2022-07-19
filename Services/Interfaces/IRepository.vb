Imports System.Threading.Tasks

Public Interface IRepository(Of T)
    Inherits IAddRepository(Of T),
        IUpdateRepository(Of T),
        IFindByIdRepository(Of T),
        IFetchAllRepository(Of T),
        IDeleteRepository(Of T),
        IQueryRepository(Of T)


End Interface
Public Interface IQueryRepository(Of T)
    Function SelectQueryAsync(queryString As String, objectParams As Object) As Task(Of IEnumerable(Of T))
End Interface
Public Interface IAddRepository(Of T)
    Function AddAsync(dataObject As T) As Task
End Interface

Public Interface IUpdateRepository(Of T)
    Function UpdateAsync(dataObject As T) As Task
End Interface

Public Interface IFindByIdRepository(Of T)
    Function FindByIdAsync(id As Integer) As Task(Of T)
End Interface

Public Interface IFetchAllRepository(Of T)
    Function FetchAllAsync() As Task(Of IEnumerable(Of T))
End Interface

Public Interface IDeleteRepository(Of T)
    Function DeleteAsync(id As Integer) As Task
End Interface