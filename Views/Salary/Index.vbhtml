@ModelType IEnumerable(Of EmployeeManagement.SalaryViewModel)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateFrom)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateTo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateCreated)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BaseNet)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DateFrom)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DateTo)
        </td>
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
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
