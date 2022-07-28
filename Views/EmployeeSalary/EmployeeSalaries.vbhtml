@ModelType IEnumerable(Of EmployeeViewModel)
<div class="jumbotron bg-light container shadow-sm">
    <h5> Legends </h5>
    <span class="badge badge-pill badge-danger"> </span> - No Salary implemented
    <br />
    <span class="badge badge-pill badge-success"> </span> - Salary implemented
    <div class="row mt-4">
        @For Each item In Model
            @<div Class="col-md-3">
                @If item.SalaryId = 0 Then
                    @<div Class="card shadow bg-danger">
                        <div class="p-2">
                            @item.ToString()
                        </div>
                        <div class="card-footer bg-light">
                            @Html.ActionLink("Implement Salary", "CreateForm", New With {.employeeId = item.Id}, New With {.class = "btn btn-secondary btn-block btn-success"})
                        </div>

                    </div>
                Else
                    @<div Class="card shadow bg-success">
                        <div class="p-2">
                            @item.ToString()
                        </div>

                        <div class="card-footer bg-light">
                            @Html.ActionLink("View Salaries", "Index", New With {.employeeId = item.Id}, New With {.class = "btn btn-secondary btn-block"})
                        </div>
                    </div>
                End If

            </div>
        Next
    </div>
</div>