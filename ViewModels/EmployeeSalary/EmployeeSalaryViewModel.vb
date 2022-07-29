Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
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
    <Required(ErrorMessage:="Please fill up Total Number of Absences!")>
    Public Property NumberOfAbsent As Integer

    <DisplayName("Total Number Of Lates")>
    <Required(ErrorMessage:="Please fill up Total Number of Lates!")>
    Public Property NumberOfLate As Integer

    <Required(ErrorMessage:="Please fill up Total value of Allowance!")>
    Public Property Allowance As Decimal

    <Required(ErrorMessage:="Please fill up Total value of Deductions!")>
    Public Property Deductions As Decimal
    Public Property SalaryId As Integer
End Class
