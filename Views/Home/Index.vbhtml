@ModelType IEnumerable(Of EmployeeModel)
<div class="jumbotron shadow">
    <table class="table-bordered">
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
                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                </td>
            </tr>
        Next
    </table>
</div>

