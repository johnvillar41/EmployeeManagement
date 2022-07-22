﻿Imports System.Threading.Tasks

Public Class EmployeeController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly _employeeService As IEmployeeService
    Public Sub New(employeeservice As IEmployeeService)
        _employeeService = employeeservice

    End Sub

    Async Function Index() As Task(Of ActionResult)
        Dim employees = Await _employeeService.ViewAllEmployeesAsync()
        Dim employeeViewModels = employees.Select(Of EmployeeViewModel)(Function(model) New EmployeeViewModel() With {
            .Id = model.Id,
            .Name = model.Name,
            .Age = model.Age,
            .Address = model.Address,
            .BirthDate = model.BirthDate,
            .IsActive = model.IsActive
        })
        Return View(employeeViewModels)
    End Function

    Async Function Delete(employeeId As Integer) As Task(Of ActionResult)
        Await _employeeService.DeleteEmployeeAsync(employeeId)
        Return RedirectToAction(NameOf(Index))
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Async Function Create(employee As EmployeeViewModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            Dim employeeModel = New EmployeeModel() With {
                .Address = employee.Address,
                .Age = employee.Age,
                .BirthDate = employee.BirthDate,
                .Id = employee.Id,
                .IsActive = employee.IsActive,
                .Name = employee.Name,
                .WorkLoad = Nothing
            }
            Await _employeeService.CreateNewEmployeeAsync(employeeModel)
            Return RedirectToAction(NameOf(Index))
        End If

        Return RedirectToAction(NameOf(CreateForm))
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Async Function Update(employee As EmployeeModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            Dim employeeModel = New EmployeeModel() With {
                .Address = employee.Address,
                .Age = employee.Age,
                .BirthDate = employee.BirthDate,
                .Id = employee.Id,
                .IsActive = employee.IsActive,
                .Name = employee.Name,
                .SalaryId = employee.SalaryId,
                .WorkLoad = Nothing
            }
            Await _employeeService.ModifyEmployeeAsync(employeeModel)
            Return RedirectToAction(NameOf(Index))
        End If

        Return View(NameOf(UpdateForm), employee)
    End Function

    Async Function UpdateForm(employeeId As Integer) As Task(Of ActionResult)
        Dim employeeDetail As EmployeeModel = Await _employeeService.FindEmployeeAsync(employeeId)
        Dim employeeViewModel As EmployeeViewModel = New EmployeeViewModel() With {
            .Id = employeeDetail.Id,
            .Name = employeeDetail.Name,
            .Age = employeeDetail.Age,
            .Address = employeeDetail.Address,
            .BirthDate = employeeDetail.BirthDate,
            .IsActive = employeeDetail.IsActive
        }
        Dim employeeSalary As EmployeeSalaryModel = Await _employeeService.FindEmployeeSalaryAsync(employeeId)
        If employeeSalary Is Nothing Then
            employeeSalary = New EmployeeSalaryModel()
        End If

        Dim salary As SalaryModel = Await _employeeService.FindSalaryAsync(employeeSalary.SalaryId)
        If salary Is Nothing Then
            salary = New SalaryModel()
        End If
        Dim employeeSalaryViewModel As EmployeeSalaryViewModel = New EmployeeSalaryViewModel() With {
            .Allowance = employeeSalary.Allowance,
            .Deductions = employeeSalary.Deductions,
            .EmployeeId = employeeSalary.EmployeeId,
            .Id = employeeSalary.Id,
            .BaseSalary = salary.BaseNet,
            .NumberOfAbsent = employeeSalary.NumberOfAbsent,
            .NumberOfLate = employeeSalary.NumberOfLate,
            .SalaryId = employeeSalary.SalaryId
        }
        Dim employeeUpdateViewModel As EmployeeUpdateViewModel = New EmployeeUpdateViewModel() With {
            .EmployeeViewModel = employeeViewModel,
            .EmployeeSalaryViewModel = employeeSalaryViewModel
        }
        Return View(NameOf(UpdateForm), employeeUpdateViewModel)
    End Function

    Function CreateForm() As ActionResult
        Return View(NameOf(CreateForm))
    End Function

    Async Function Detail(employeeId As Integer) As Task(Of ActionResult)
        Dim employeeDetail As EmployeeModel = Await _employeeService.FindEmployeeAsync(employeeId)
        Dim employeeNumberWork As Integer = Await _employeeService.FetchNumberOfWorksAsync(employeeId)
        Dim employeeDetailViewModel As EmployeeDetailViewModel = New EmployeeDetailViewModel() With {
            .Id = employeeDetail.Id,
            .Name = employeeDetail.Name,
            .Age = employeeDetail.Age,
            .Salary = employeeDetail.SalaryId,
            .Address = employeeDetail.Address,
            .BirthDate = employeeDetail.BirthDate,
            .IsActive = employeeDetail.IsActive,
            .NumberOfWork = employeeNumberWork
        }
        Return View(NameOf(Detail), employeeDetailViewModel)
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Async Function UpdateEmployeeSalary(employeeSalary As EmployeeSalaryViewModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            Dim employeeSalaryModel = New EmployeeSalaryModel() With {
                .Allowance = employeeSalary.Allowance,
                .Deductions = employeeSalary.Deductions,
                .EmployeeId = employeeSalary.EmployeeId,
                .NumberOfAbsent = employeeSalary.NumberOfAbsent,
                .NumberOfLate = employeeSalary.NumberOfLate,
                .SalaryId = employeeSalary.SalaryId,
                .Id = employeeSalary.Id
            }
            employeeSalaryModel.Net -= (employeeSalaryModel.Deductions + employeeSalaryModel.Allowance)
            Await _employeeService.UpdateEmployeeSalaryAsync(employeeSalaryModel)
            Return RedirectToAction(NameOf(Index))
        End If

        Return RedirectToAction("../Employee/UpdateForm")
    End Function
End Class
