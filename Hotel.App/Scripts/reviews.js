// Chose rating on Create a review 
$(document).ready(function () {
    $("#Rating").prop("value", 5);

    $("[data-star]").hover(function () {
        var myClass = $(this).attr("data-star");
        if (myClass === "creare-review-1star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-1star.jpg")');
        } else if (myClass === "creare-review-2star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-2star.jpg")');
        } else if (myClass === "creare-review-3star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-3star.jpg")');
        } else if (myClass === "creare-review-4star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-4star.jpg")');
        } else if (myClass === "creare-review-5star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/stars_sprite_icon.png") no-repeat 0 0');
        } else if (myClass === "creare-review-0star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/stars_sprite_icon.png") no-repeat -1px -24px');
        }

        var raiting = $(this).attr("value");
        $("#Rating").prop("value", raiting);
    });
});