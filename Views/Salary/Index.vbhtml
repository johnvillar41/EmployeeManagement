@ModelType IEnumerable(Of EmployeeManagement.SalaryViewModel)
<div class="container">
    <div class="jumbotron shadow-sm bg-light rounded">
        <div class="container">
            <p>
                @Html.ActionLink("Create New", "CreateOrUpdateForm", Nothing, New With {.class = "btn btn-secondary"})
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
                                @Html.ActionLink("Edit", "CreateOrUpdateForm", New With {.salaryId = item.Id}) |
                                @Html.ActionLink("Delete", "Delete", New With {.salaryId = item.Id})
                            </td>
                        </tr>
                    Next

                </table>
            </div>
        </div>
    </div>
</div>