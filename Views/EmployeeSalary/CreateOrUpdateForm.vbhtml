@ModelType EmployeeManagement.EmployeeSalaryViewModel

<div class="jumbotron container card shadow-sm bg-light">
    <div class="card shadow-sm p-4 rounded">

        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-12">
                        @If Model.SalaryId = 0 Then
                            @<h3 class="text-dark font-weight-bold">Create Salary for Employee: @Model.EmployeeId</h3>
                        Else
                            @<h3 class="text-dark font-weight-bold">Update Salary for Employee: @Model.EmployeeId</h3>
                        End If
                    </div>
                </div>
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @Html.HiddenFor(Function(model) model.EmployeeId)
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.NumberOfAbsent, htmlAttributes:=New With {.class = "control-label col-md-12"})
                    <div class="col-md-12">
                        @Html.EditorFor(Function(model) model.NumberOfAbsent, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.NumberOfAbsent, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.NumberOfLate, htmlAttributes:=New With {.class = "control-label col-md-12"})
                    <div class="col-md-12">
                        @Html.EditorFor(Function(model) model.NumberOfLate, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.NumberOfLate, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Allowance, htmlAttributes:=New With {.class = "control-label col-md-12"})
                    <div class="col-md-12">
                        @Html.EditorFor(Function(model) model.Allowance, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Allowance, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Deductions, htmlAttributes:=New With {.class = "control-label col-md-12"})
                    <div class="col-md-12">
                        @Html.EditorFor(Function(model) model.Deductions, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Deductions, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-12">
                        <input type="submit" value="Create" class="btn btn-secondary btn-block" />
                    </div>
                </div>
            </div>

        End Using
    </div>
    <div class="mt-4">
        @Html.ActionLink("Back to List", "Index")
    </div>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
