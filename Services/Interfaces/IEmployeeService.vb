﻿Imports System.Threading.Tasks

Public Interface IEmployeeService
    Function CreateNewEmployeeAsync(employee As EmployeeModel) As Task
    Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel))
    Function FindEmployeeAsync(id As Integer) As Task(Of EmployeeModel)
    Function DeleteEmployeeAsync(id As Integer) As Task
    Function ModifyEmployeeAsync(employee As EmployeeModel) As Task
End Interface
