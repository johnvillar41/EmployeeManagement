@ModelType IEnumerable(Of DisplayEmployeeSalaryViewModel)

<div class="jumbotron bg-light rounded shadow-sm">
    <div class="container">
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
                            <a href="#" Class="card-link">Card link</a>
                            <a href="#" Class="card-link">Another link</a>
                        </div>
                    </div>
                </div>
            Next
        </div>
    </div>
</div>
