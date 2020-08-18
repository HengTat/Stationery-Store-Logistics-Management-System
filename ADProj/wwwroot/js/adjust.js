// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {




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
        var price = $("#selectTwo").find(':selected').data('price')
        var currentQty = $("#selectTwo").find(':selected').data('yy')

        $('#demo').val(uom);
        $('#demo2').val(id);
        $('#demo4').val(price);
        $('#demo5').val(currentQty);

    });

    $("#selectTwo").change(function () {
        var id = $(this).find(':selected').data('id')
        var uom = $(this).find(':selected').data('uom')

        var price = $(this).find(':selected').data('price')
        var currentQty = $(this).find(':selected').data('yy')

        var currentAmt = parseFloat(price) * parseFloat(currentQty);

        $('#demo').val(uom);
        $('#demo2').val(id);

        $('#demo4').val(price);
        $('#demo5').val(currentQty);
        $('#demo6').val(currentAmt);





    });






});
