Imports System.ComponentModel.DataAnnotations

Public Class EmployeeModel
    Public Property Id As Integer

    <Required(ErrorMessage:="Name is Required")>
    Public Property Name As String

    <Required(ErrorMessage:="Age is Required")>
    Public Property Age As Integer

    <Required(ErrorMessage:="Salary is Required")>
    Public Property Salary As Decimal

    <Required(ErrorMessage:="Address is Required")>
    Public Property Address As String

    <Required(ErrorMessage:="BirthDate is Required")>
    Public Property BirthDate As Date

    <Required(ErrorMessage:="Status is Required")>
    Public Property IsActive As Integer

    Public Property WorkLoad As IEnumerable(Of WorkModel)
End Class
