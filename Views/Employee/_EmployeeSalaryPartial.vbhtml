@ModelType EmployeeManagement.EmployeeSalaryViewModel

<div Class="h-100 jumbotron shadow-sm rounded bg-light">
    <div Class="container">
        <h2> Employee Salary Details</h2>
        <hr />
        <div Class="rounded shadow-sm p-4">
            @Using (Html.BeginForm("UpdateEmployeeSalary", "Employee", FormMethod.Post))
                @Html.AntiForgeryToken()

                @<div class="form-horizontal">
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    @Html.HiddenFor(Function(model) model.Id)
                    @Html.HiddenFor(Function(model) model.EmployeeId)

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

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Year, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.Year, New With {.htmlAttributes = New With {.class = "form-control", .type = "number", .min = "1900", .max = "2099", .step = "1", .value = "2022"}})
                            @Html.ValidationMessageFor(Function(model) model.Year, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="form-inline">
                        <div class="form-group">
                            <div class="col-md-12 my-auto">
                                @Html.DisplayFor(Function(model) model.Month)
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12">
                                @Html.DropDownList(NameOf(Model.Month), [Enum].GetValues(GetType(EmployeeManagement.EmployeeSalaryViewModel.MonthType)).Cast(Of EmployeeManagement.EmployeeSalaryViewModel.MonthType)().ToList().Select(Function(model) New SelectListItem With {.Text = model.ToString(), .Value = model.ToString()}), New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Month, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                    </div>

                    <div class="form-inline">
                        <div class="form-group">
                            <div class="col-md-12 my-auto">
                                @Html.DisplayFor(Function(model) model.SalaryName)
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-12">
                                @Html.DropDownList(NameOf(Model.SalaryId), Model.SalaryTypes.Select(Function(model) New SelectListItem With {.Text = model.Name, .Value = model.Id}), New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.SalaryTypes, "", New With {.class = "text-danger"})
                            </div>
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
