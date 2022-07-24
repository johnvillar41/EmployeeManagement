Imports System.Reflection

Public Class AutoMapper
    Implements IAutoMapper

    Public Function MapObjects(Of TDestination, TSource)(destinationObject As TDestination, sourceObject As TSource) As TDestination Implements IAutoMapper.MapObjects
        Dim destinationProperties = destinationObject.GetType().GetProperties()
        Dim sourceProperties = sourceObject.GetType().GetProperties()

        For Each source In sourceProperties
            For Each destination In destinationProperties
                If source.Name.Equals(destination.Name) And source.PropertyType().Equals(destination.PropertyType()) Then
                    destination.SetValue(destinationObject, source.GetValue(sourceObject))
                    Exit For
                Else
                    Throw New AutoMapperException($"Property source:{source.Name} and destination:{destination.Name} 
                            are not equal for classes of{destinationObject.GetType().Name} and {sourceObject.GetType().Name}")
                End If
            Next
        Next

        Return destinationObject
    End Function
End Class
