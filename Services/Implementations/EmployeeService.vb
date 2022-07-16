Imports System.Threading.Tasks

Public Class EmployeeService
    Implements IEmployeeService

    Public Function AddNewEmployeeAsync(employee As EmployeeModel) As Task Implements IEmployeeService.AddNewEmployeeAsync
        Throw New NotImplementedException()
    End Function

    Public Function DeleteEmployeeAsync(employeeId As Integer) As Task Implements IEmployeeService.DeleteEmployeeAsync
        Throw New NotImplementedException()
    End Function

    Public Function UpdateEmployeeAsync(employeeId As Integer, employee As EmployeeModel) As Task Implements IEmployeeService.UpdateEmployeeAsync
        Throw New NotImplementedException()
    End Function

    Public Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel)) Implements IEmployeeService.ViewAllEmployeesAsync
        Throw New NotImplementedException()
    End Function
End Class
