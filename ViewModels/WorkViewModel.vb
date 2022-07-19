Imports System.ComponentModel.DataAnnotations

Public Class WorkViewModel
    Public Property Id As Integer
    Public Property EmployeeId As Integer

    <Required(ErrorMessage:="Title is required")>
    Public Property Title As String

    <Required(ErrorMessage:="Description is required")>
    Public Property Description As String
End Class
