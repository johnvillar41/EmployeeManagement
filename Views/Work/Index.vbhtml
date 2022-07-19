@ModelType IEnumerable(Of WorkModel)
<div Class="container">
    @For Each item As WorkModel In Model

        @<div Class="shadow-sm bg-light" style="width: 18rem;">
            <div Class="card-body">
                <h5 Class="card-title">@item.Title</h5>
                <h6 Class="card-subtitle mb-2 text-muted">@item.Id</h6>
                <p Class="card-text">@item.Description</p>
                <a href="#" Class="card-link">Card link</a>
                <a href="#" Class="card-link">Another link</a>
            </div>
        </div>
    Next
</div>