Public Class EmployeeSalaryModel
    Public Property Id As Integer
    Public Property SalaryId As Integer
    Public Property EmployeeId As Integer
    Public Property NumberOfAbsent As Integer
    Public Property NumberOfLate As Integer
    Public Property Allowance As Decimal
    Public Property Deductions As Decimal
    Public Property Net As Decimal
    Public Property Month As String
    Public Property Year As Integer
    Public Sub New()
        Id = -1
        SalaryId = -1
        EmployeeId = -1
        NumberOfAbsent = 0
        NumberOfLate = 0
        Allowance = 0
        Deductions = 0
        Net = 0
        Month = "January"
        Year = -1
    End Sub
End Class
