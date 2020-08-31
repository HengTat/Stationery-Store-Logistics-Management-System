

//AUTHOR: JAMES FOO

$(document).ready(function () {
    $("#btn_Add").click(function (event) {
        //Extracting all selected fields
        var txtSupplier = $("#selectOne option:selected").text().toString();
        var txtDescription = $("#selectTwo option:selected").text().toString();
        var itemId = $("#itemid").val();
        var qty = $("#orderQty").val();
        var UOM = $("#uom").val();
        var cat = $("#cat").val();

        if (txtDescription == "" || txtDescription == "Select Item") {
            swal("Please select an item");
            return;
        }
        if (txtSupplier == "" || txtSupplier == "Select a supplier") {
            swal("Please select a supplier");
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



        var txtQty = qty.toString();

        var tableRef = document.getElementById('tblOrderDetails').getElementsByTagName('tbody')[0];
        var newRow = tableRef.insertRow();
        var cell1 = newRow.insertCell(0);
        var cell2 = newRow.insertCell(1);
        var cell3 = newRow.insertCell(2);
        var cell4 = newRow.insertCell(3);
        var cell5 = newRow.insertCell(4);
        var cell6 = newRow.insertCell(5);
        var cell7 = newRow.insertCell(6);

        var cell1Text = document.createTextNode(txtSupplier);
        cell1.appendChild(cell1Text);

        var cell2Text = document.createTextNode(txtDescription);
        cell2.appendChild(cell2Text);

        var cell3Text = document.createTextNode(itemId);
        cell3.appendChild(cell3Text);

        var cell4Text = document.createTextNode(txtQty);
        cell4.appendChild(cell4Text);

        var cell5Text = document.createTextNode(UOM);
        cell5.appendChild(cell5Text);

        var cell6Text = document.createTextNode(cat);
        cell6.appendChild(cell6Text);

        cell7.innerHTML = '<button class="btn_Delete" type="button">'
            + 'Delete</button>'

        $('td:nth-child(6),th:nth-child(6)').hide();
        swal("Item has been added to the list");

        //Disable dropdown box to restrict 1 supplier
        document.getElementById("selectOne").disabled = true;
        $("#selectTwo").val('');
        $("#orderQty").val('');
        $("#uom").val('');
        $("#cat").val('');
        $("#itemid").val('');

    })

    $(".btn_Delete").click(function (event) {
        var currentTr = $(this).closest('tr');
        currentTr.remove();
    });

    $("#btnSubmit").click(function (event) {

        //valid if submitting an empty table
        var tbody = $("#tblOrderDetails tbody");
        if (tbody.children().length == 0) {
            swal("Error!", "Unable to submit an empty form", "error");

            return;
        }

        var orderDetails = new Array();
        $("#tblOrderDetails TBODY TR").each(function () {
            var row = $(this);
            var rd = {};
            rd.SupplierId = row.find("TD").eq(0).html();
            rd.ItemId = row.find("TD").eq(2).html();
            rd.Quantity = row.find("TD").eq(3).html();
            rd.CategoryId = row.find("TD").eq(5).html();
            orderDetails.push(rd);
        });

        $.ajax({
            type: "POST",
            url: "/PurchaseOrder/InsertOrders",
            data: JSON.stringify(orderDetails),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
            }
        });
        $("#tblOrderDetails tbody tr").remove();
        //Enable combox box after submitting form
        document.getElementById("selectOne").disabled = false;

        swal("Success!", "Purchase order form has been created", "success");

    });

    $("#btnReset").click(function (event) {

        var tbody = $("#tblOrderDetails tbody");
        if (tbody.children().length != 0) {

            swal({
                title: "Are you sure you want to clear the list?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        $("#tblOrderDetails tbody tr").remove();
                        //Enable combox box after resetting form
                        document.getElementById("selectOne").disabled = false;
                        swal("Purchase form has been cleared", {
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

        var uom = $("#selectTwo").find(':selected').data('uom')
        var cat = $("#selectTwo").find(':selected').data('cat')
        var itemid = $("#selectTwo").find(':selected').data('itemid')

        $('#uom').val(uom);
        $('#cat').val(cat);
        $('#itemid').val(itemid);



    });
    $("#selectTwo").change(function () {
        var uom = $(this).find(':selected').data('uom')
        var cat = $(this).find(':selected').data('cat')
        var itemid = $("#selectTwo").find(':selected').data('itemid')
        $('#uom').val(uom);
        $('#cat').val(cat);
        $('#itemid').val(itemid);
    });
});
