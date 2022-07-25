@ModelType EmployeeManagement.SalaryViewModel
<div class="container">
    <div class="jumbotron bg-light shadow-sm rounded">
        <div class="container">
            <h3>Create Salary</h3>
            <hr />
            <div class="shadow-sm p-4 rounded">
                @Using (Html.BeginForm("Update", "Salary", FormMethod.Post))
                    @Html.AntiForgeryToken()
                    @<div class="form-horizontal">
                        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                            <div class="col-md-12">
                                @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
                            </div>
                        </div>

                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.DateCreated, htmlAttributes:=New With {.class = "control-label col-md-2"})
                            <div class="col-md-12">
                                @Html.EditorFor(Function(model) model.DateCreated, New With {.htmlAttributes = New With {.class = "form-control", .type = "date"}})
                                @Html.ValidationMessageFor(Function(model) model.DateCreated, "", New With {.class = "text-danger"})
                            </div>
                        </div>

                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.BaseNet, htmlAttributes:=New With {.class = "control-label col-md-2"})
                            <div class="col-md-12">
                                @Html.EditorFor(Function(model) model.BaseNet, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.BaseNet, "", New With {.class = "text-danger"})
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
    </div>
</div>


@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
