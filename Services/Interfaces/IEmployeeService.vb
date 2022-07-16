Imports System.Threading.Tasks

Public Interface IEmployeeService
    Inherits IAddRepository(Of EmployeeModel),
        IUpdateRepository(Of EmployeeModel),
        IFindByIdRepository(Of EmployeeModel),
        IFetchAllRepository(Of EmployeeModel),
        IDeleteRepository(Of EmployeeModel)
End Interface
