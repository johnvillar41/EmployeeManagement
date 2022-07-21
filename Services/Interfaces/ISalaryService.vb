Imports System.Threading.Tasks

Public Interface ISalaryService
    Function FetchAllSalariesAsync() As Task(Of IEnumerable(Of SalaryModel))
    Function CreateSalaryAsync(salaryModel As SalaryModel) As Task
End Interface
