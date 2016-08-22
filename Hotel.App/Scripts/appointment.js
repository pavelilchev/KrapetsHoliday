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


$(document).ready(function () {
    var revType = $("#reviewType option:selected").val();
    var revOrder = $("#reviewSorting option:selected").val();
    $("#ReviewsType").prop("value", revType);
    $("#ReviewsSortOrder").prop("value", revOrder);

    var appType = $("#appType option:selected").val();
    var appOrder = $("#appSorting option:selected").val();
    $("#AppointmentType").prop("value", appType);
    $("#AppointmentSortOrder").prop("value", appOrder);

    $("#reviewType").change(function () {
        revType = $("#reviewType option:selected").val();
        $("#ReviewsType").prop("value", revType);
    });

    $("#reviewSorting").change(function () {
        revOrder = $("#reviewSorting option:selected").val();
        $("#ReviewsSortOrder").prop("value", revOrder);
    });

    $("#appType").change(function () {
        appType = $("#appType option:selected").val();
        $("#AppointmentType").prop("value", appType);
    });

    $("#appSorting").change(function () {
        appOrder = $("#appSorting option:selected").val();
        $("#AppointmentSortOrder").prop("value", appOrder);
    });
});