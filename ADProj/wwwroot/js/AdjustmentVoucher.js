$(document).ready(function () {
	$("#select1").change(function () {
		if ($(this).data("options") === undefined) {
			/*Taking an array of all options-2 and kind of embedding it on the select1*/
			$(this).data("options", $("#selectTwo option").clone());
		}
		var id = $(this).val();
		var options = $(this)
			.data("options")
			.filter("[value=" + id + "]");
		$("#select2").html(options);

		var id = $("#select2").find(":selected").data("id");

		$("#select3").html(options);
		var uom = $("#select3").find(":selected").data("uom");
		$("#select4").html(options);
		var price = $("#select4").find(":selected").data("price");
		$("#select5").html(options);
		var currentQty = $("#select5").find(":selected").data("currentQty");
		$("#uom").val(uom);
		$("#price").val(price);
		$("#currentQty").val(currentQty);
	});
});
