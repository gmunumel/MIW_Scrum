// JavaScript Document

$(document).ready(function () {



    // Add smooth scrolling to all links in navbar + footer link
    $(".navbar a[href='/#myPage'], .navbar a[href='#featurette1'], .navbar a[href='#featurette2'], .navbar a[href='#featurette3'], .navbar a[href='#featurette4'], .navbar a[href='/#about'], .navbar a[href='/#services'], .navbar a[href='/#contact'], footer a[href='/#myPage']").on('click', function (event) {

        // Prevent default anchor click behavior
        event.preventDefault();

        // Store hash
        var hash = this.hash;

        // Using jQuery's animate() method to add smooth page scroll
        // The optional number (900) specifies the number of milliseconds it takes to scroll to the specified area
        $('html, body').animate({
            scrollTop: $(hash).offset().top
        }, 900, function () {

            // Add hash (#) to URL when done scrolling (default click behavior)
            window.location.hash = hash;
        });
    });

    // Slide in elements on scroll
    $(window).scroll(function () {
        $(".slideanim").each(function () {
            var pos = $(this).offset().top;

            var winTop = $(window).scrollTop();
            if (pos < winTop + 600) {
                $(this).addClass("slide");
            }
        });
    });




})