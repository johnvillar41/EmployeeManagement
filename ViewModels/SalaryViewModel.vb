Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class SalaryViewModel
    Public Property Id As Integer

    <Required(ErrorMessage:="Name is required")>
    Public Property Name As String

    <DisplayName("Date Created")>
    <Required(ErrorMessage:="Date is required")>
    Public Property DateCreated As Date

    <DisplayName("Base Networth")>
    <Required(ErrorMessage:="Networth is required")>
    Public Property BaseNet As Decimal
End Class
