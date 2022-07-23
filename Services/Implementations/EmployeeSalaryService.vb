Imports System.Threading.Tasks

Public Class EmployeeSalaryService
    Inherits Repository(Of EmployeeSalaryModel)
    Implements IEmployeeSalaryService

    Public Async Function FetchAllEmployeeSalaryAsync(employeeId As Integer) As Task(Of IEnumerable(Of EmployeeSalaryModel)) Implements IEmployeeSalaryService.FetchAllEmployeeSalaryAsync
        Return Await SelectQueryAsync(Of EmployeeSalaryModel)($"SELECT * FROM {GetTableName} WHERE EmployeeId @EmployeeId", New With {.EmployeeId = employeeId})
    End Function
End Class
