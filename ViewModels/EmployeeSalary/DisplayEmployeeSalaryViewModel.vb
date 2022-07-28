Imports System.ComponentModel
Imports EmployeeManagement.EmployeeSalaryViewModel

Public Class DisplayEmployeeSalaryViewModel
    Public Property Id As Integer
    Public Property EmployeeId As Integer
    Public Property NumberOfAbsent As Integer
    Public Property NumberOfLate As Integer
    Public Property SalaryId As Integer
    Public Property Allowance As Decimal

    <DisplayName("Net Salary")>
    Public Property Net As Decimal

    Public Property Month As MonthType
    Public Property Year As Integer
End Class
