// appointment date picker
$(function () {
    $("#startDate").datepicker({
        numberOfMonths: 2,
        onSelect: function (selected) {
            $("#endDate").val('');
            var dt = new Date(selected);
            dt.setDate(dt.getDate() + 1);
            $("#endDate").datepicker("option", "minDate", dt);
        }
    });
    $("#endDate").datepicker({
        numberOfMonths: 2,
        onSelect: function (selected) {
            var dt = new Date(selected);
            dt.setDate(dt.getDate() - 1);
            $("#startDate").datepicker("option", "maxDate", dt);
        }
    });
});

$(function () {

    var date = new Date();
    $("#startDate").datepicker("option", "minDate", date);
    $("#startDate").datepicker();
    $("#endDate").datepicker();
});
