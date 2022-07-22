Imports System.ComponentModel

Public Class EmployeeSalaryViewModel
    Public Property Id As Integer
    Public Property EmployeeId As Integer
    Public Property NumberOfAbsent As Integer
    Public Property NumberOfLate As Integer
    Public Property Allowance As Decimal
    Public Property Deductions As Decimal
    Public Property SalaryId As Integer
    Public Property SalaryName As String
    Public Property SalaryTypes As IEnumerable(Of SalaryViewModel)

    <DisplayName("Base Salary")>
    Public Property BaseSalary As Decimal

    <DisplayName("Net Salary")>
    Public Property Net As Decimal
End Class
