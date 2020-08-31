

//AUTHOR: JAMES FOO

$(document).ready(function () {
    $("#btn_Add").click(function (event) {
        //Extracting all selected fields
        var txtCategroy = $("#selectOne option:selected").text().toString();
        var txtDescription = $("#selectTwo option:selected").text().toString();
        var txtItemCode = $("#itemId").val().toString();
        var qty = $("#requestQty").val();

        //validations for quantity, category,item
        if (txtCategroy == "" || txtCategroy == "Select Category") {
            swal("Please select a category");
            return;
        }
        if (txtDescription == "" || txtDescription == "Select Item") {
            swal("Please select a category");
            return;
        }
        if (isNaN(qty)) {
            swal("Please enter a positive integer");
            return;
        }
        if (qty <= 0) {
            swal("Please enter a positive quantity");
            return;
        }

        if (qty > 99) {
            swal("Unable make a request for more than 99 items");
            return;
        }


        var txtQty = qty.toString().toString();

        var tableRef = document.getElementById('tblRequestsDetails').getElementsByTagName('tbody')[0];
        var newRow = tableRef.insertRow();
        var cell1 = newRow.insertCell(0);
        var cell2 = newRow.insertCell(1);
        var cell3 = newRow.insertCell(2);
        var cell4 = newRow.insertCell(3);
        var cell5 = newRow.insertCell(4);

        var cell1Text = document.createTextNode(txtCategroy);
        cell1.appendChild(cell1Text);

        var cell2Text = document.createTextNode(txtDescription);
        cell2.appendChild(cell2Text);

        var cell3Text = document.createTextNode(txtItemCode);
        cell3.appendChild(cell3Text);

        var cell4Text = document.createTextNode(txtQty);
        cell4.appendChild(cell4Text);


        cell5.innerHTML = '<button class="btn_Delete" type="button">'
            + 'Delete</button>'
        $("#selectOne").val('');
        $("#selectTwo").val('');
        $("#requestQty").val('');
        $("#itemId").val('');
        $("#uom").val('');

        $('td:nth-child(3),th:nth-child(3)').hide();

        swal("Item has been added to the list");
    })
    $(".btn_Delete").click(function (event) {
        var currentTr = $(this).closest('tr');
        currentTr.remove();
    });
    $("#btnSubmit").click(function (event) {

        //valid if submitting an empty table
        var tbody = $("#tblRequestsDetails tbody");
        if (tbody.children().length == 0) {
            swal("Error!", "Unable to submit an empty form", "error");
            return;
        }

        var requestDetails = new Array();
        $("#tblRequestsDetails TBODY TR").each(function () {
            var row = $(this);
            var rd = {};
            rd.Category = row.find("TD").eq(0).html();
            rd.Description = row.find("TD").eq(1).html();
            rd.ItemId = row.find("TD").eq(2).html();
            rd.Qty = row.find("TD").eq(3).html();
            requestDetails.push(rd);
        });
        $.ajax({
            type: "POST",
            url: "/Request/InsertRequests",
            data: JSON.stringify(requestDetails),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
            }

        });
        $("#tblRequestsDetails tbody tr").remove();

        swal("Success", "Your request has been submitted!", "success");

    });

    $("#btnReset").click(function (event) {
        var tbody = $("#tblRequestsDetails tbody");
        if (tbody.children().length != 0) {
            swal({
                title: "Are you sure you want to clear the list?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        $("#tblRequestsDetails tbody tr").remove();
                        //Enable combox box after resetting form
                        document.getElementById("selectOne").disabled = false;
                        swal("Request form has been cleared", {
                            icon: "success",
                        });
                    } else {
                    }
                });
        }
    });

    $(document).on('click', '.btn_Delete', function () {
        var currentTr = $(this).closest('tr');
        currentTr.remove();
    });

    $("#selectOne").change(function () {
        if ($(this).data('options') === undefined) {
            /*Taking an array of all options-2 and kind of embedding it on the select1*/
            $(this).data('options', $('#selectTwo option').clone());
        }
        var id = $(this).val();
        var options = $(this).data('options').filter('[value=' + id + ']');
        $('#selectTwo').html(options);

        var id = $("#selectTwo").find(':selected').data('id')
        var uom = $("#selectTwo").find(':selected').data('uom')
        $('#uom').val(uom);
        $('#itemId').val(id);
    });
    $("#selectTwo").change(function () {
        var id = $(this).find(':selected').data('id')
        var uom = $(this).find(':selected').data('uom')
        $('#uom').val(uom);
        $('#itemId').val(id);
    });
});
