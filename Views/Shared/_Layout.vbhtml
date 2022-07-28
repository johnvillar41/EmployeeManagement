<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>    
    <nav class="navbar navbar-expand-lg navbar-light bg-light shadow-sm mb-4">
        <div class="container">
            @Html.ActionLink("Employee Management System", "Index", Nothing, New With {.class = "navbar-brand"})
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        @Html.ActionLink("Employee", "Index", "Employee", Nothing, New With {.class = "nav-link"})
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Salary", "Index", "Salary", Nothing, New With {.class = "nav-link"})
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("EmployeeSalary", "EmployeeSalaries", "EmployeeSalary", Nothing, New With {.class = "nav-link"})
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="body-content">
        @RenderBody()
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
