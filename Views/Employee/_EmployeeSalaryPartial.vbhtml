@ModelType EmployeeManagement.EmployeeSalaryViewModel

<div Class="h-100 jumbotron shadow-sm rounded bg-light">
    <div Class="container">
        <h2> Employee Salary Details</h2>
        <hr />
        <div Class="rounded shadow-sm p-4">
            <table class="table">
                <tbody>
                    <tr>
                        <th>
                            @Html.LabelFor(Function(model) model.NumberOfAbsent)
                        </th>
                        <th>
                            @Html.DisplayFor(Function(model) model.NumberOfAbsent)
                        </th>
                    </tr>
                    <tr>
                        <th>
                            @Html.LabelFor(Function(model) model.NumberOfLate)
                        </th>
                        <th>
                            @Html.DisplayFor(Function(model) model.NumberOfLate)
                        </th>
                    </tr>
                    <tr>
                        <th>
                            @Html.LabelFor(Function(model) model.Allowance)
                        </th>
                        <th>
                            @Html.DisplayFor(Function(model) model.Allowance)
                        </th>
                    </tr>
                    <tr>
                        <th>
                            @Html.LabelFor(Function(model) model.Deductions)
                        </th>
                        <th>
                            @Html.DisplayFor(Function(model) model.Deductions)
                        </th>
                    </tr>
                </tbody>
            </table>
            @Html.ActionLink("View Employee Salary Detail List", "Index", "EmployeeSalary", New With {.EmployeeId = Model.EmployeeId}, New With {.class = "btn btn-block btn-secondary"})
        </div>
    </div>
</div>
