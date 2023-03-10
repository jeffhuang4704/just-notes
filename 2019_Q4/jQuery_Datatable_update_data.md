### jQuery DataTable update new data

```HTML
@section Styles{
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/select/1.2.7/css/select.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/responsive/2.2.3/css/responsive.dataTables.min.css">

    <link rel="stylesheet" type="text/css" href="~/vendors/fontawesome/css/all.css" />

    <link href="~/css/ModuleDistribution.css" rel="stylesheet" asp-append-version="true" />
}

...

<div class="modal-body">
    @*datatable*@
    <div class="row">
        <div class="col-lg-12" id="group_file_container">
            <table id="group_file_table" class="display responsive nowrap compact" style="width:100%"></table>
        </div>
    </div>
</div>
```

```C#
@section Scripts{
    @*datatable*@
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/select/1.2.7/js/dataTables.select.min.js"></script>

    <script src="~/js/vendor/Garlic.js-1.4.2/garlic.min.js"></script>
    <script src="~/vendors/json-viewer/jquery.json-viewer.js"></script>

    <script type="text/javascript">
        var files =@Html.Raw(Model.filesInfoJson);
        var tagsJson = @Html.Raw(Model.tagsJson);
        var groupTagsJson =@Html.Raw(Model.groupTagsJson);
        console.log("data", { files, tagsJson, groupTagsJson});
    </script>

    <script src="~/js/ModuleDistribution.js" asp-append-version="true"></script>
}
```


```JavaScript

// JavaScript
let groupFileDataTable = null;
$(document).ready(function () {
    // group files modal
    $('.group_details').click(function () {
        console.log("group_details clicked !");

        let grouptag = $(this).data('grouptag');
        // init datatable for group files
        let dataSet = fetchGroupFiles(grouptag);
        
        let title = `Total ${dataSet.length} files in "${grouptag}"`;
        $('#ModalGroupName').text(title);

        initDataTable(dataSet);

        $('#modal_group_files').modal('show');
    });
});


function initDataTable(dataSet) {
    if (groupFileDataTable) {
        // to change the content in datatable, following these steps
        // destroy current DataTable. Note it will crash if no table already created
        $("#group_file_table").dataTable().fnDestroy();
    }

    groupFileDataTable = $('#group_file_table').DataTable({
        pageLength: 20,
        data: dataSet,
        columns: [
            { title: "Filename" },
            { title: "Folder (in setup package)" },
            { title: "Size" },
            { title: "Tags" }
        ]
    });
}

function fetchGroupFiles(whichTag) {
    let dataSet = [];

    files.forEach(function (f) {

        let hasMatchedTag = f.tags.some(t => t.tag == whichTag);

        if (hasMatchedTag) {
            let fileInfo = [];
            fileInfo.push(f.filename);      // filename
            fileInfo.push(f.folder);        // folder
            fileInfo.push(f.fileSize);      // size
            let allTags = [];
            f.tags.forEach(function (t) {
                allTags.push(t.tag);
            });

            if (allTags.length > 0) {
                fileInfo.push(allTags.join(';'));    // tags
            }

            dataSet.push(fileInfo);
        }
    });

    return dataSet;
}

```