Imports System.Threading.Tasks
Public Interface IAddRepository(Of T)
    Function AddAsync(dataObject As T) As Task
End Interface

Public Interface IUpdateRepository(Of T)
    Function UpdateAsync(dataObject As T, id As Integer) As Task
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