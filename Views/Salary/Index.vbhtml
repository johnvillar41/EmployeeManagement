@ModelType IEnumerable(Of EmployeeManagement.SalaryViewModel)

<div class="jumbotron shadow-sm bg-light rounded">
    <div class="container">
        <p>
            @Html.ActionLink("Create New", "CreateForm", Nothing, New With {.class = "btn btn-secondary"})
        </p>
        <div class="table-responsive">
            <table class="table">
                <tr>
                    <th class="font-weight-bold">
                        @Html.DisplayNameFor(Function(model) model.Name)
                    </th>
                    <th class="font-weight-bold">
                        @Html.DisplayNameFor(Function(model) model.DateCreated)
                    </th>
                    <th class="font-weight-bold">
                        @Html.DisplayNameFor(Function(model) model.BaseNet)
                    </th>
                    <th class="font-weight-bold">Actions</th>
                </tr>

                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Name)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.DateCreated)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.BaseNet)
                        </td>
                        <td>
                            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                            @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                        </td>
                    </tr>
                Next

            </table>
        </div>
    </div>
</div>