Imports System.ComponentModel.DataAnnotations

Public Class EmployeeModel
    Public Property Id As Integer
    Public Property Name As String
    Public Property Age As Integer
    Public Property SalaryId As Integer
    Public Property Address As String
    Public Property BirthDate As Date
    Public Property IsActive As Integer
    Public Property WorkLoad As IEnumerable(Of WorkModel)
End Class
