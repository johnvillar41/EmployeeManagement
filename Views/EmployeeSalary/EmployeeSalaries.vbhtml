@ModelType IEnumerable(Of EmployeeViewModel)
<div class="jumbotron bg-light container shadow-sm">
    <h5> Legends </h5>
    <span class="badge badge-pill badge-danger"> </span> - No Salary implemented
    <br />
    <span class="badge badge-pill badge-success"> </span> - Salary implemented
    <div class="row mt-4">
        @For Each item In Model
            @<div Class="col-md-4 col-lg-3 p-4 align-items-stretch">
                <div class="card shadow-sm ">
                    @If item.SalaryId = 0 Then
                        @<div Class="p-2">
                            <h4 class="text-truncate">@item.Name</h4>
                            <h6 class="text-dark">@item.Id</h6>
                            <p class="badge-pill badge-danger badge text-truncate">No Salary Implemented!</p>
                        </div>
                    Else
                        @<div Class="p-2">
                            <h4 class="text-truncate">@item.Name</h4>
                            <h6 class="text-dark">@item.Id</h6>
                            <p class="badge-pill badge-success badge text-truncate">Salary Implemented!</p>
                        </div>
                    End If
                    <div class="p-2">
                        @If item.SalaryId = 0 Then
                            @Html.ActionLink("Create Salary", "CreateForm", New With {.employeeId = item.Id}, New With {.class = "btn btn-secondary btn-block"})
                        Else
                            @Html.ActionLink("View Salaries", "Index", New With {.employeeId = item.Id}, New With {.class = "btn btn-secondary btn-block"})
                            @Html.ActionLink("Update Salary", "Index", New With {.employeeId = item.Id}, New With {.class = "btn btn-secondary btn-block"})
                        End If
                    </div>
                </div>
            </div>
        Next
    </div>
</div>