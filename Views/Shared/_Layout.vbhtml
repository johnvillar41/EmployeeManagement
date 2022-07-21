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
    <nav class="navbar navbar-light bg-light mb-4 shadow-sm">
        <div class="container">
            @Html.ActionLink("Employee Management System", "Index", Nothing, New With {.class = "navbar-brand"})
        </div>
    </nav>
    <div class="container body-content">
        @RenderBody()
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
