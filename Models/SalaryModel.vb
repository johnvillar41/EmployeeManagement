Public Class SalaryModel
    Public Property Id As Integer
    Public Property Name As String
    Public Property DateCreated As Date
    Public Property BaseNet As Decimal
    Public Sub New()
        Id = -1
        Name = String.Empty
        DateCreated = DateTime.Now
        BaseNet = 0
    End Sub
End Class
