@ModelType EmployeeManagement.EmployeeViewModel
<div class="h-100 jumbotron shadow-sm rounded bg-light">
    <div class="container">
        <h2>Personal Details</h2>
        <hr />
        <div class="shadow-sm rounded p-4">
            @Using (Html.BeginForm("Update", "Employee", FormMethod.Post))
                @Html.AntiForgeryToken()

                @<div class="form-horizontal">

                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    @Html.HiddenFor(Function(model) model.Id)

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Age, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.Age, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Age, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.BirthDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.BirthDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.BirthDate, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.IsActive, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-12">
                            @Html.EditorFor(Function(model) model.IsActive, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.IsActive, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            @Html.DropDownList(NameOf(Model.SalaryId), Model.SalaryTypes.Select(Function(model) New SelectListItem With {.Text = model.Name, .Value = model.Id}), New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.SalaryId, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group mt-4">
                        <div class="col-md-offset-2 col-md-12">
                            <input type="submit" value="Save" class="btn btn-secondary btn-block" />
                        </div>
                    </div>
                </div>
            End Using
        </div>
    </div>
</div>
