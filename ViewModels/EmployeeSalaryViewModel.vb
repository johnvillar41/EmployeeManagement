Imports System.ComponentModel
Imports EmployeeManagement.EmployeeSalaryModel

Public Class EmployeeSalaryViewModel
    Public Enum MonthType
        January
        February
        March
        April
        May
        June
        July
        August
        September
        October
        November
        December
    End Enum

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
    Public Property BaseNet As Decimal

    <DisplayName("Net Salary")>
    Public Property Net As Decimal

    <DisplayName("Month")>
    Public Property Month As MonthType
    Public Property Year As Integer
End Class
