Imports System.Threading.Tasks

Public Interface IEmployeeService
    Function AddNewEmployeeAsync(employee As EmployeeModel) As Task
    Function DeleteEmployeeAsync(employeeId As Integer) As Task
    Function UpdateEmployeeAsync(employeeId As Integer, employee As EmployeeModel) As Task
    Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel))
    Function FindEmployeeAsync(employeeId As Integer) As Task(Of EmployeeModel)
End Interface
