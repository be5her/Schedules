var Channels_table;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    Channels_table = $('#Channels_table').DataTable({
        "ajax": {
            "url": "/Channels/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "added_date", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">                                                    
                                <a class="btn btn-danger text-white" style="cursor:pointer;"'
                                  onclick=Delete('/Channels/Delete?id='+${data})>
                                  Delete    
                                </a>
                                &nbsp;
                                <a class="btn btn-danger text-white" style="cursor:pointer;"'
                                  onclick=Delete('/Channels/Details?id='+${data})>
                                  Details
                                </a>
                                &nbsp;
                                <a href="/Books/Edit?id=${data}" class="btn btn-success text-white" style=""cursor:pointer;'>
                                  Edit    
                                </a>
                            </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        Channels_table.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }

                }
            });
        }
    });
}