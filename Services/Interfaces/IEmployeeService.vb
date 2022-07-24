Imports System.Threading.Tasks

Public Interface IEmployeeService
    Function CreateNewEmployeeAsync(employee As EmployeeModel) As Task
    Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel))
    Function FindEmployeeAsync(id As Integer) As Task(Of EmployeeModel)
    Function DeleteEmployeeAsync(id As Integer) As Task
    Function ModifyEmployeeAsync(employee As EmployeeModel) As Task
    Function FetchNumberOfWorksAsync(employeeId As Integer) As Task(Of Integer)
    Function FindEmployeeSalaryAsync(employeeId As Integer) As Task(Of EmployeeSalaryModel)
    Function FindSalaryAsync(salaryId As Integer) As Task(Of SalaryModel)
    Function UpdateEmployeeSalaryAsync(employeeSalaryModel As EmployeeSalaryModel) As Task
    Function FetchSalaryTypes() As Task(Of IEnumerable(Of SalaryModel))
    Function AddEmployeeSalaryAsync(employeeSalaryModel As EmployeeSalaryModel) As Task
End Interface
