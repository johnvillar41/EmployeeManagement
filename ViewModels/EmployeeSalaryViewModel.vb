Public Class EmployeeSalaryViewModel
    Public Property Id As Integer
    Public Property SalaryId As Integer
    Public Property EmployeeId As Integer
    Public Property NumberOfAbsent As Integer
    Public Property NumberOfLate As Integer
    Public Property Allowance As Decimal
    Public Property Deductions As Decimal
    Public Property BaseSalary As Decimal
    Public ReadOnly Property Net As Decimal
        Get
            Return BaseSalary = BaseSalary - (Deductions + Allowance)
        End Get
    End Property
End Class
