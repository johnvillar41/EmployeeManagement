@ModelType EmployeeManagement.EmployeeModel
@Code
    ViewData("Title") = "Detail"
End Code



<div class="jumbotron shadow-sm">
    <div class="container">
        <h2>Detail</h2>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.Name)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Name)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Age)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Age)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Salary)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Salary)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Address)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Address)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.BirthDate)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.BirthDate)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.IsActive)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.IsActive)
            </dd>

        </dl>
    </div>
</div>
<p>
    @Html.ActionLink("Back to List", "Index")
</p>
