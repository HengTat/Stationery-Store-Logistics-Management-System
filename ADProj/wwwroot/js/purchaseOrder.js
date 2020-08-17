// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#btn_Add").click(function (event) {
        //Extracting all selected fields
        var txtSupplier = $("#selectOne option:selected").text().toString();
        var txtItemId = $("#selectTwo option:selected").text().toString();
        var qty = $("#orderQty").val();
        var UOM = $("#uom").val();
        var cat = $("#cat").val();

        if (qty <= 0) {
            alert("Please enter a positive quantity");
            return;
        }

        if (qty > 99) {
            alert("Unable make a request for more than 99 items");
            return;
        }
        if (txtSupplier == "" || txtSupplier == "Select a supplier") {
            alert("Please choose a supplier");
            return;
        }
        if (txtItemId == "" || txtItemId == "Select Item") {
            alert("Please choose an item");
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


        var cell1Text = document.createTextNode(txtSupplier);
        cell1.appendChild(cell1Text);

        var cell2Text = document.createTextNode(txtItemId);
        cell2.appendChild(cell2Text);

        var cell3Text = document.createTextNode(txtQty);
        cell3.appendChild(cell3Text);

        var cell4Text = document.createTextNode(UOM);
        cell4.appendChild(cell4Text);

        var cell5Text = document.createTextNode(cat);
        cell5.appendChild(cell5Text);

        cell6.innerHTML = '<button class="btn_Delete" type="button">'
            + 'Delete</button>'

        $('td:nth-child(5),th:nth-child(5)').hide();

        //Disable dropdown box to restrict 1 supplier
        document.getElementById("selectOne").disabled = true;
        $("#selectTwo").val('');
        $("#orderQty").val('');
        $("#uom").val('');
        $("#cat").val('');
    })

    $(".btn_Delete").click(function (event) {
        var currentTr = $(this).closest('tr');
        currentTr.remove();
    });

    $("#btnSubmit").click(function (event) {

        //valid if submitting an empty table
        var tbody = $("#tblOrderDetails tbody");
        if (tbody.children().length == 0) {
            alert("Unable to submit an empty request form");
            return;
        }

        var orderDetails = new Array();
        $("#tblOrderDetails TBODY TR").each(function () {
            var row = $(this);
            var rd = {};
            rd.SupplierId = row.find("TD").eq(0).html();
            rd.ItemId = row.find("TD").eq(1).html();
            rd.Quantity = row.find("TD").eq(2).html();
            rd.CategoryId = row.find("TD").eq(4).html();
            orderDetails.push(rd);
        });

        $.ajax({
            type: "POST",
            url: "/PurchaseOrder/InsertOrders",
            data: JSON.stringify(orderDetails),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
            }

        });
        $("#tblOrderDetails tbody tr").remove();
        //Enable combox box after submitting form
        document.getElementById("selectOne").disabled = false;

    });

    $("#btnReset").click(function (event) {
        $("#tblOrderDetails tbody tr").remove();
        //Enable combox box after resetting form
        document.getElementById("selectOne").disabled = false;
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
        $('#uom').val(uom);
        $('#cat').val(cat);


    });
    $("#selectTwo").change(function () {
        var uom = $(this).find(':selected').data('uom')
        var cat = $(this).find(':selected').data('cat')
        $('#uom').val(uom);
        $('#cat').val(cat);


    });
});
