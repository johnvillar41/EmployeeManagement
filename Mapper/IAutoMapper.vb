Public Interface IAutoMapper
    Function MapObjects(Of TDestination, TSource)(destinationObject As TDestination, sourceObject As TSource) As TDestination
End Interface
