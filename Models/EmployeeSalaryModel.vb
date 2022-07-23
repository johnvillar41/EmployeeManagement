Public Class EmployeeSalaryModel
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
    Public Property SalaryId As Integer
    Public Property EmployeeId As Integer
    Public Property NumberOfAbsent As Integer
    Public Property NumberOfLate As Integer
    Public Property Allowance As Decimal
    Public Property Deductions As Decimal
    Public Property Net As Decimal
    Public Property Month As MonthType
    Public Property Year As Integer
End Class
