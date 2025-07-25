$(function () {
    function slideMenu() {
        var activeState = $("#menu-container .menu-list").hasClass("active");
        if (activeState) {
            $("#menu-container .menu-list").css('display', 'block');
        } else {
            $("#menu-container .menu-list").css('display', 'none');
        }
        
    }
    $("#menu-wrapper").click(function (event) {
        event.stopPropagation();
        $("#hamburger-menu").toggleClass("open");
        $("#menu-container .menu-list").toggleClass("active");
        slideMenu();

        $("body").toggleClass("overflow-hidden");
    });

    $(".menu-list").find(".accordion-toggle").click(function () {
        $(this).toggleClass("active-tab").find(".menu-link").toggleClass("active");
    });
}); // jQuery load
