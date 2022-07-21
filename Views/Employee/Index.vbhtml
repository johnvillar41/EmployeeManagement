@ModelType IEnumerable(Of EmployeeViewModel)
<div class="jumbotron shadow-sm bg-light">
    <div class="container">
        @Html.ActionLink("Create New", "CreateForm", Nothing, New With {.class = "btn btn-secondary shadow-sm mb-2"})
        @If Model.Count = 0 Then
            @<h1>Empty Collection</h1>
        Else
            @<div class="table-responsive">
                <Table Class="table">
                    <thead>
                        <tr>
                            <td class="font-weight-bold">@Html.DisplayNameFor(Function(modelItem) modelItem.FirstOrDefault().Name)</td>
                            <td class="font-weight-bold">@Html.DisplayNameFor(Function(modelItem) modelItem.FirstOrDefault().Id)</td>
                            <td class="font-weight-bold">@Html.DisplayNameFor(Function(modelItem) modelItem.FirstOrDefault().BirthDate)</td>
                            <td class="font-weight-bold">Actions</td>
                        </tr>
                    </thead>
                    @For Each item In Model
                        @<tr>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Name)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Id)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.BirthDate)
                            </td>
                            <td>
                                @Html.ActionLink("Edit", "UpdateForm", New With {.employeeId = item.Id}) |
                                @Html.ActionLink("Details", "Detail", New With {.employeeId = item.Id}) |
                                @Html.ActionLink("Delete", "Delete", New With {.employeeId = item.Id}) |
                                @Html.ActionLink("Work Loads", "Index", "Work", New With {.employeeId = item.Id}, Nothing)
                            </td>
                        </tr>
                    Next
                </Table>
            </div>
        End If

    </div>

</div>

