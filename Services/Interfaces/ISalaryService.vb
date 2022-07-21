Imports System.Threading.Tasks

Public Interface ISalaryService
    Function FetchAllSalariesAsync() As Task(Of IEnumerable(Of SalaryModel))
    Function CreateSalaryAsync(salaryModel As SalaryModel) As Task
    Function UpdateEmployeeSalaryAsync(employeeSalaryModel As EmployeeSalaryModel) As Task
    Function UpdateSalaryAsync(salaryModel As SalaryModel) As Task
    Function FindSalaryAsync(salaryId As Integer?) As Task(Of SalaryModel)
End Interface
