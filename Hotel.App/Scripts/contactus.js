$(document).ready(function () {
    $("[data-url]").on("click", function () {
        $('.email-form').load($(this).data("url"));
    });

    var height = $(window).height();
    if (height < 680) {
        $(".email-form-wrapper").css({"position":"absolute", "top":"20px"});
    }
});


function closeEmailForm() {
    $(".email-form").empty();
}

function sendEmailSuccessfully() {
    $(".email-form").empty();
    $(".success-email-send").show();
    $('.success-email-send').delay(3000).fadeOut('slow');
}
