Imports System.Threading.Tasks

Public Interface IRepository(Of T)
    Inherits IAddRepository(Of T),
        IUpdateRepository(Of T),
        IFindByIdRepository(Of T),
        IFetchAllRepository(Of T),
        IDeleteRepository(Of T)

End Interface
Public Interface IAddRepository(Of T)
    Function AddAsync(dataObject As T, sqlQuery As String) As Task
End Interface

Public Interface IUpdateRepository(Of T)
    Function UpdateAsync(dataObject As T, sqlQuery As String) As Task
End Interface

Public Interface IFindByIdRepository(Of T)
    Function FindByIdAsync(id As Integer, tableName As String) As Task(Of T)
End Interface

Public Interface IFetchAllRepository(Of T)
    Function FetchAllAsync(tableName As String) As Task(Of IEnumerable(Of T))
End Interface

Public Interface IDeleteRepository(Of T)
    Function DeleteAsync(id As Integer, tableName As String) As Task
End Interface