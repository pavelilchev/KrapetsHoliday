$(document).ready(function () {
    $("[data-url]").on("click", function () {
        $('.email-form').load($(this).data("url"));
    });
});


function closeEmailForm() {
    $(".email-form").empty();
}

function sendEmailSuccessfully() {
    $(".email-form").empty();
    $(".success-email-send").show();
    $('.success-email-send').delay(3000).fadeOut('slow');
}
