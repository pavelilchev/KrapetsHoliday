$(document).ready(function () {
    $("[data-url]").on("click", function () {
        $('.email-form').load($(this).data("url"));
    });

    resizeContactForm();
});


function closeEmailForm() {
    $(".email-form").empty();
}

function sendEmailSuccessfully() {
    $(".email-form").empty();
    $(".success-email-send").show();
    $('.success-email-send').delay(3000).fadeOut('slow');
}

function resizeContactForm() {
    var height = $(window).height();
    if (height < 680) {
        $(".email-form-wrapper").css({ "position": "absolute", "top": "20px" });
    } else {
        $(".email-form-wrapper").css({ "position": "fixed", "top": "200px" });
    }
}

$(window).resize(resizeContactForm);