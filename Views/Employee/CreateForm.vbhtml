@ModelType EmployeeManagement.EmployeeViewModel
<div class="jumbotron shadow-sm bg-light">
    <div class="container">
        @Using (Html.BeginForm("Create", "Employee", FormMethod.Post))
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <h3>Create New Employee</h3>
                <hr />
                <div class="shadow-sm rounded p-4">
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
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
                            @Html.EditorFor(Function(model) model.BirthDate, New With {.htmlAttributes = New With {.class = "form-control", .type = "date"}})
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
                        <div class="col-md-offset-2 col-md-12">
                            <input type="submit" value="Create" class="btn btn-secondary btn-block" />
                        </div>
                    </div>
                </div>
                <div class="mt-4">
                    @Html.ActionLink("Back to List", "Index")
                </div>
            </div>
        End Using
    </div>
</div>



@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
