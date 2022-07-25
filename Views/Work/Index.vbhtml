@ModelType DisplayWorkViewModel
<div class="container">
    <div class="jumbotron bg-light shadow-sm rounded">
        <div Class="container">
            @If Model IsNot Nothing Then
                @Html.ActionLink("Create", "CreateForm", New With {.employeeId = Model.EmployeeId}, New With {.class = "btn btn-secondary"})
            End If
            <div Class="row">
                @For Each item As WorkViewModel In Model.WorkViewModels
                    @<div class="mt-2 mb-2 col-lg-3 col-md-4 col-sm-12">
                        <div Class="shadow-sm card">
                            <div Class="card-body">
                                <h5 Class="card-title">@item.Title</h5>
                                <h6 Class="card-subtitle mb-2 text-muted">@item.Id</h6>
                                <p Class="card-text text-truncate">@item.Description</p>

                            </div>
                            <div class="card-footer">
                                @Html.ActionLink("Delete", "Delete", New With {.workId = item.Id, .employeeId = item.EmployeeId}, New With {.class = "text-danger"})
                            </div>
                        </div>
                    </div>
                Next
            </div>
            <div>
                @Html.ActionLink("Back to List", "Index", "Employee", Nothing, Nothing)
            </div>
        </div>
    </div>
</div>