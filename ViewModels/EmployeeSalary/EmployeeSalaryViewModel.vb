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

    <DisplayName("Total Number Of Absences")>
    Public Property NumberOfAbsent As Integer

    <DisplayName("Total Number Of Lates")>
    Public Property NumberOfLate As Integer
    Public Property Allowance As Decimal
    Public Property Deductions As Decimal
    Public Property SalaryId As Integer
End Class
