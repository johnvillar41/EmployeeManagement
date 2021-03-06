@ModelType EmployeeManagement.EmployeeUpdateViewModel
@Code
    ViewData("Title") = "UpdateForm"
End Code
<div class="container-fluid">
    <div class="row mb-4">
        <div class="col">
            @Html.Partial("_PersonalDetailPartial", Model.EmployeeViewModel)
        </div>
        <div class="col">
            @Html.Partial("_EmployeeSalaryPartial", Model.EmployeeSalaryViewModel)
        </div>
        <div class="col">
            @Html.Partial("_SalaryPartial", Model.SalaryViewModel)
        </div>
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
