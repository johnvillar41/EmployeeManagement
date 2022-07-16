Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class EmployeeService
    Implements IEmployeeService

    Private ReadOnly _db As IDbConnection
    Private Shared _instance As EmployeeService

    Public Shared ReadOnly Property Instance() As EmployeeService
        Get
            If (_instance Is Nothing) Then
                _instance = New EmployeeService()
            End If

            Return _instance
        End Get

    End Property
    Private Sub New()
        _db = New SqlConnection(ConfigurationManager.ConnectionStrings("EmployeeDBConnection").ConnectionString)
    End Sub
    Public Function AddNewEmployeeAsync(employee As EmployeeModel) As Task Implements IEmployeeService.AddNewEmployeeAsync
        Throw New NotImplementedException()
    End Function

    Public Function DeleteEmployeeAsync(employeeId As Integer) As Task Implements IEmployeeService.DeleteEmployeeAsync
        Throw New NotImplementedException()
    End Function

    Public Function UpdateEmployeeAsync(employeeId As Integer, employee As EmployeeModel) As Task Implements IEmployeeService.UpdateEmployeeAsync
        Throw New NotImplementedException()
    End Function

    Public Async Function ViewAllEmployeesAsync() As Task(Of IEnumerable(Of EmployeeModel)) Implements IEmployeeService.ViewAllEmployeesAsync
        Return Await _db.QueryAsync(Of EmployeeModel)("SELECT * FROM EmployeeTable")
    End Function
End Class
