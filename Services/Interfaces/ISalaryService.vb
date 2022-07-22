Imports System.Threading.Tasks

Public Interface ISalaryService
    Function FetchAllSalariesAsync() As Task(Of IEnumerable(Of SalaryModel))
    Function CreateSalaryAsync(salaryModel As SalaryModel) As Task
    Function UpdateSalaryAsync(salaryModel As SalaryModel) As Task
    Function FindSalaryAsync(salaryId As Integer?) As Task(Of SalaryModel)
    Function DeleteSalaryAsync(salaryId As Integer?) As Task
End Interface
