Imports System.Threading.Tasks

Public Interface IEmployeeSalaryService
    Function FetchAllEmployeeSalaryAsync(employeeId As Integer) As Task(Of IEnumerable(Of EmployeeSalaryModel))
    Function FetchAllSalaryGivenAYearAsync(year As Integer, employeeId As Integer) As Task(Of IEnumerable(Of EmployeeSalaryModel))
    Function FetchAllEmployees() As Task(Of IEnumerable(Of EmployeeModel))
    Function FetchEmployeeSalaryAsync(employeeId As Integer) As Task(Of EmployeeSalaryModel)
    Function CreateEmployeeSalaryForEmployeeAsync(employeeSalary As EmployeeSalaryModel) As Task
End Interface
