@ModelType EmployeeManagement.EmployeeUpdateViewModel
@Code
    ViewData("Title") = "UpdateForm"
End Code

<div class="row mb-4">
    <div class="col">
        @Html.Partial("_PersonalDetailPartial", Model.EmployeeViewModel)
    </div>
    <div class="col">
        <div class="h-100 jumbotron bg-light rounded shadow-sm">
            <div class="container">
                <h2>Salary Details</h2>
                <hr />
            </div>
        </div>
    </div>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
