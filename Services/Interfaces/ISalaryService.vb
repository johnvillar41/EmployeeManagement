Imports System.Threading.Tasks

Public Interface ISalaryService
    Function FetchAllSalariesAsync() As Task(Of IEnumerable(Of SalaryModel))
End Interface
