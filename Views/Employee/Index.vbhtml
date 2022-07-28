@ModelType IEnumerable(Of EmployeeViewModel)
<div class="container">
    <div class="jumbotron shadow-sm bg-light">
        <div class="container">
            @Html.ActionLink("Create New", "CreateForm", Nothing, New With {.class = "btn btn-secondary shadow-sm mb-2"})
            @If Model.Count = 0 Then
                @<h1>Empty Collection</h1>
            Else
                @<div class="row">
                    @For Each item In Model
                        @<div class="col-md-3 h-100">
                            <div Class="shadow-sm card">
                                <div Class="card-body">
                                    <h5 Class="card-title">@item.Name</h5>
                                    <h6 Class="card-subtitle mb-2 text-muted">@item.Id</h6>
                                    <p Class="card-text">@item.Address</p>
                                </div>
                                <div class="card-footer">
                                    <a href="#" Class="card-link">@Html.ActionLink("Update", "UpdateForm", New With {.employeeId = item.Id}, New With {.class = "text-warning card-link"})</a>
                                    <a href="#" Class="card-link">@Html.ActionLink("Details", "Detail", New With {.employeeId = item.Id}, New With {.class = "text-warning card-link"})</a>
                                    <a href="#" Class="card-link">@Html.ActionLink("Work Loads", "Index", "Work", New With {.employeeId = item.Id}, New With {.class = "text-warning card-link"})</a>
                                    <a href="#" Class="card-link">@Html.ActionLink("Salaries", "Index", "EmployeeSalary", New With {.employeeId = item.Id}, New With {.class = "text-warning card-link"})</a>
                                    <a href="#" Class="card-link">@Html.ActionLink("Delete", "Delete", New With {.employeeId = item.Id}, New With {.class = "text-danger card-link"})</a>
                                </div>
                            </div>
                        </div>
                    Next
                </div>
            End If
        </div>
    </div>
</div>

