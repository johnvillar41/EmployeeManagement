Imports System.ComponentModel.DataAnnotations

Public Class EmployeeViewModel
    Public Property Id As Integer

    <Required(ErrorMessage:="Name is Required")>
    Public Property Name As String

    <Required(ErrorMessage:="Age is Required")>
    Public Property Age As Integer

    <Required(ErrorMessage:="Address is Required")>
    Public Property Address As String

    <Required(ErrorMessage:="BirthDate is Required")>
    Public Property BirthDate As Date

    <Required(ErrorMessage:="Status is Required")>
    Public Property IsActive As Integer

    <Required(ErrorMessage:="Salary Type is Required")>
    Public Property SalaryId As Integer

    Public Property SalaryTypes As IEnumerable(Of SalaryViewModel)
End Class
