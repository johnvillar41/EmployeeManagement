Imports System.ComponentModel.DataAnnotations

Public Class WorkModel
    Public Property Id As Integer

    <Required(ErrorMessage:="Title is required")>
    Public Property Title As String

    <Required(ErrorMessage:="Description is required")>
    Public Property Description As String

End Class
