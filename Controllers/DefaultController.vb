Imports System.Web.Mvc

Namespace Controllers
    Public Class DefaultController
        Inherits Controller

        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace