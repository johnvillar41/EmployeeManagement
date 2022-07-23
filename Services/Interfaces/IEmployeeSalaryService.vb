Imports System.Threading.Tasks

Public Interface IEmployeeSalaryService
    Function FetchAllEmployeeSalaryAsync(employeeId As Integer) As Task(Of IEnumerable(Of EmployeeSalaryModel))
End Interface
