@ModelType SalaryViewModel
<div class="h-100 jumbotron shadow-sm rounded bg-light">
    <div class="container">
        <h2>Salary Details</h2>
        <hr />
        <div class="shadow-sm rounded p-4">
            <div class="form-horizontal">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-12">
                        @Html.DisplayFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.DateCreated, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-12">
                        @Html.DisplayFor(Function(model) model.DateCreated, New With {.htmlAttributes = New With {.class = "form-control"}})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.BaseNet, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-12">
                        @Html.DisplayFor(Function(model) model.BaseNet, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.BaseNet, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
