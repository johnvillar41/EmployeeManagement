Imports System.Reflection

Public Class AutoMapper(Of TDestination, TSource)
    Private ReadOnly _destinationObject As TDestination
    Private ReadOnly _sourceObject As TSource
    Public Sub New(destination As TDestination, source As TSource)
        _destinationObject = destination
        _sourceObject = source
    End Sub

    Public Function MapObjects() As TDestination
        Dim destinationProperties = _destinationObject.GetType().GetProperties()
        Dim sourceProperties = _sourceObject.GetType().GetProperties()

        For Each source In sourceProperties
            For Each destination In destinationProperties
                If source.Name.Equals(destination.Name) Then
                    destination.SetValue(_destinationObject, source.GetValue(_sourceObject))
                    Exit For
                End If
            Next
        Next

        Return _destinationObject
    End Function
End Class
