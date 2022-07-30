﻿<div class="container">
    <div class="jumbotron bg-light card shadow-sm bg-img">
        <div class="d-flex justify-content-between card-choices">
            <div class="card-employee shadow-sm card w-100 shadow-sm m-1 text-center">
                <div class="my-auto">
                    <h3 class="font-weight-bold text-warning">Employee List</h3>
                    @Html.ActionLink("View Employees", "Index", "Employee", Nothing, New With {.class = "btn btn-warning"})
                </div>
            </div>
            <div class="card shadow-sm w-100 m-1">
                <h3>Salaries</h3>
            </div>
            <div class="card shadow-sm w-100 m-1">
                <h3>Employees</h3>
            </div>
        </div>
    </div>

</div>
