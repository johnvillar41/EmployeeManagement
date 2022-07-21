@ModelType EmployeeManagement.EmployeeUpdateViewModel
@Code
    ViewData("Title") = "UpdateForm"
End Code

<div class="row mb-4">
    <div class="col">
        @Html.Partial("_PersonalDetailPartial", Model.EmployeeViewModel)
    </div>
    <div class="col">
        @Html.Partial("../Salary/_EmployeeSalaryPartial", Model.EmployeeSalaryViewModel)
    </div>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
