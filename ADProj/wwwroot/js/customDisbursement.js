$(document).ready(function () {

    $('#disbursementCustom').click(function () {
        $('#customDate').removeAttr("disabled");
    });

    $('#disbursementDefault').click(function () {
        $('#customDate').prop('disabled', true);
    });

    const picker = document.getElementById('customDate');
    picker.addEventListener('input', function (e) {
        var day = new Date(this.value).getUTCDay();
        var today = new Date();
        if ([6, 0].includes(day)) {
            e.preventDefault();
            this.value = '';
            swal('Weekends not allowed');
        }
        var date = new Date(this.value);
        if (date < today) {
            e.preventDefault();
            this.value = '';
            swal('Disbursement date must be a future date')
        }
    });

    $('#submit').click(function () {
        if ($('#customDate').val() == '') {
            swal('Date is mandatory for ad-hoc disbursements')
            return false;
        }

        if ($('#disbursementDefault').prop('checked') === true) {
            var disbursedDate = $('#disbursementDefault').val();
            $('#disbursedDate').val(disbursedDate);
            $('#disbursementGenForm').submit();
        }
        else {
            var disbursedDate = $('#customDate').val();
            $('#disbursedDate').val(disbursedDate);
            $('#disbursementGenForm').submit();
        }
    });
})