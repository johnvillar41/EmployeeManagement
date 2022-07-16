@ModelType EmployeeManagement.EmployeeModel
<div class="jumbotron shadow-sm">
    <div class="container">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <h4>Create New Employee</h4>
                <hr />
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
                    @Html.LabelFor(Function(model) model.Salary, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-12">
                        @Html.EditorFor(Function(model) model.Salary, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Salary, "", New With {.class = "text-danger"})
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
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Create" class="btn btn-success" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</div>


<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
