@ModelType EmployeeManagement.WorkViewModel

@Using (Html.BeginForm("Create", "Work", FormMethod.Post))
    @Html.AntiForgeryToken()

    @<div class="bg-light shadow rounded jumbotron">
        @Html.HiddenFor(Of Integer)(Function(model) model.EmployeeId)
        <div class="form-horizontal">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Title, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-12">
                    @Html.EditorFor(Function(model) model.Title, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Title, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-12">
                    @Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Create" class="btn btn-success btn-sm" />
                </div>
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index", New With {Model.EmployeeId})
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
