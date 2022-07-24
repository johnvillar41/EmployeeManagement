@ModelType IEnumerable(Of DisplayEmployeeSalaryViewModel)

<div class="jumbotron bg-light rounded shadow-sm">
    <div class="container">
        @If Model Is Nothing Or Model.Count = 0 Then
            @<h3>Empty item</h3>
            Return
        End If
        <h3>Sort By Year</h3>
        <hr />
        @Using (Html.BeginForm("Sort", "EmployeeSalary", FormMethod.Post))
            @<div Class="col-3">
                @Html.Hidden("EmployeeId", Model.FirstOrDefault().EmployeeId)
                @Html.TextBox("Year", 2022, New With {.class = "form-control", .type = "number", .step = "1"})
            </div>
            @<div Class="col-3">
                <input type="submit" value="Search" class="btn btn-block btn-secondary" />
            </div>
        End Using
        <div class="col-12">
            <div Class="row">
                @For Each item In Model
                    @<div class="col-4">
                        <div Class="card rounded shadow-sm">
                            <div Class="card-body">
                                <h5 Class="card-title">@item.Month, @item.Year</h5>
                                <h6 Class="card-subtitle mb-2 text-muted">@item.Id</h6>
                                <table class="table">
                                    <tbody>

                                        <tr>
                                            <td>@NameOf(item.Allowance) </td>
                                            <td>@item.Allowance</td>
                                        </tr>
                                        <tr>
                                            <td>@NameOf(item.BaseSalary)</td>
                                            <td>@item.BaseSalary</td>
                                        </tr>
                                        <tr>
                                            <td>@NameOf(item.EmployeeId)</td>
                                            <td>@item.EmployeeId</td>
                                        </tr>
                                        <tr>
                                            <td>@NameOf(item.NumberOfAbsent)</td>
                                            <td>@item.NumberOfAbsent</td>
                                        </tr>
                                        <tr>
                                            <td>@NameOf(item.NumberOfLate)</td>
                                            <td>@item.NumberOfLate</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                Next
            </div>
        </div>

    </div>
</div>
