﻿@ModelType EmployeeManagement.EmployeeSalaryViewModel
<div class="h-100 jumbotron shadow-sm rounded bg-light">
    <div class="container">
        <h2>Employee Salary Details</h2>
        <hr />
        <div class="rounded shadow-sm p-4">
            @Using (Html.BeginForm("UpdateEmployeeSalary", "Employee", FormMethod.Post))
                @Html.AntiForgeryToken()

                @<div class="form-horizontal">
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    @Html.HiddenFor(Function(model) model.Id)
                    @Html.HiddenFor(Function(model) model.EmployeeId)
                    @Html.HiddenFor(Function(model) model.SalaryId)

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Allowance, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.Allowance, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Allowance, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Deductions, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.Deductions, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Deductions, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.NumberOfAbsent, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.NumberOfAbsent, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.NumberOfAbsent, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.NumberOfLate, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.NumberOfLate, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.NumberOfLate, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="form-group mt-4">
                        <div class="col-md-offset-2 col-md-12">
                            <input type="submit" value="Save" class="btn btn-secondary btn-block" />
                        </div>
                    </div>
                    <hr />
                    <h5>Net Worth Details</h5>
                    <div class="card">
                        <div class="card-body">
                            @Html.LabelFor(Function(model) model.BaseSalary, New With {.class = "fw-bold text-warning font-weight-bold"}) : @Html.DisplayFor(Function(model) model.BaseSalary)
                            <br />
                            @Html.LabelFor(Function(model) model.Net, New With {.class = "fw-bold text-warning font-weight-bold"}) : @Html.DisplayFor(Function(model) model.Net)
                        </div>
                    </div>
                </div>
            End Using
        </div>
    </div>
</div>