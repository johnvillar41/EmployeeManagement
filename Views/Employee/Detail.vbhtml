@ModelType EmployeeManagement.EmployeeDetailViewModel
<div class="row">
    <div class="col">
        <div class="jumbotron bg-light shadow-sm rounded h-100">
            <div class="container">
                <h3>Employee Personal Details</h3>
                <hr />
                <div class="table-responsive">
                    <table class="table table-borderless">
                        <thead>
                            <tr>
                                <td>@Html.LabelFor(Function(model) model.Id, New With {.class = "text-dark font-weight-bold"})</td>
                                <td>@Html.LabelFor(Function(model) model.Name, New With {.class = "text-dark font-weight-bold"})</td>
                                <td>@Html.LabelFor(Function(model) model.Address, New With {.class = "text-dark font-weight-bold"})</td>
                                <td>@Html.LabelFor(Function(model) model.Age, New With {.class = "text-dark font-weight-bold"})</td>
                                <td>@Html.LabelFor(Function(model) model.BirthDate, New With {.class = "text-dark font-weight-bold"})</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>@Html.DisplayFor(Function(model) model.Id)</td>
                                <td>@Html.DisplayFor(Function(model) model.Name)</td>
                                <td>@Html.DisplayFor(Function(model) model.Address)</td>
                                <td>@Html.DisplayFor(Function(model) model.Age)</td>
                                <td>@Html.DisplayFor(Function(model) model.BirthDate)</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div Class="col">
        <div Class="jumbotron bg-light shadow-sm rounded h-100">
            <div Class="container">
                <h3> Employee Work Details</h3>
                <hr />
                <div class="table-responsive">
                    <table class="table table-borderless">
                        <thead>
                            <tr>
                                <td>@Html.LabelFor(Function(model) model.IsActive, New With {.class = "text-dark font-weight-bold"})</td>
                                <td>@Html.LabelFor(Function(model) model.NumberOfWork, New With {.class = "text-dark font-weight-bold"})</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>@Html.DisplayFor(Function(model) model.IsActive)</td>
                                <td>@Html.DisplayFor(Function(model) model.NumberOfWork)</td>                                
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
