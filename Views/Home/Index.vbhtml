@ModelType IEnumerable(Of EmployeeModel)
<div class="jumbotron shadow-sm">
    <div class="container">
        @Html.ActionLink("Create New", "CreateForm", Nothing, New With {.class = "btn btn-secondary shadow-sm"})
        <hr />
        @If Model.Count = 0 Then
            @<h1>Empty Collection</h1>
        Else
            @<Table Class="table table-bordered">
                @For Each item In Model
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Name)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Salary)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Id)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.BirthDate)
                        </td>
                        <td>
                            @Html.ActionLink("Edit", "Edit", New With {.employeeId = item.Id}) |
                            @Html.ActionLink("Details", "Detail", New With {.employeeId = item.Id}) |
                            @Html.ActionLink("Delete", "Delete", New With {.employeeId = item.Id})
                        </td>
                    </tr>
                Next
            </Table>
        End If

    </div>

</div>

