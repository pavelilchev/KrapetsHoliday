$(document).ready(function () {

    // Home page slideshow settings
    $("#owl-demo").owlCarousel({
        autoPlay: 4000,
        navigation: false, // Show next and prev buttons
        slideSpeed: 300,
        paginationSpeed: 400,
        singleItem: true

        // "singleItem:true" is a shortcut for:
        // items : 1, 
        // itemsDesktop : false,
        // itemsDesktopSmall : false,
        // itemsTablet: false,
        // itemsMobile : false

    });
});


// Create a review chose rating
$(document).ready(function () {
    $("li").hover(function () {
        var myClass = $(this).attr("class");
        if (myClass == "creare-review-1star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-1star.jpg")');
        } else if (myClass == "creare-review-2star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-2star.jpg")');
        } else if (myClass == "creare-review-3star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-3star.jpg")');
        } else if (myClass == "creare-review-4star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/raiting-4star.jpg")');
        } else if (myClass == "creare-review-5star") {
            $(this).parent("ul").css("background", 'url("/Files/Images/stars_sprite_icon.png") no-repeat 0 0');
        }  
        
        var raiting = $(this).attr("value");
        document.getElementById("setRating").setAttribute("value", raiting);
    });
});