$(document).ready(function () {
    $("[data-url]").on("click", function () {
        $('.email-form').load($(this).data("url"));
    });
});


function closeEmailForm() {
    $(".email-form").empty();
}