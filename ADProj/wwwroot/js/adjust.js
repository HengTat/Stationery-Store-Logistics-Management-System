// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $("#selectTwo").change(function () {
        var id = $(this).find(':selected').data('id')
        var uom = $(this).find(':selected').data('uom')
        var description = $(this).find(':selected').data('desription')
        var price = $(this).find(':selected').data('price')
        var currentQty = $(this).find(':selected').data('yy')

        $('#demo').val(uom);
        $('#demo2').val(id);
        $('#demo3').val(description);
        $('#demo4').val(price);
        $('#demo5').val(currentQty);


    });
});
